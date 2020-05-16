using System;
using System.Collections.Generic;
using System.Diagnostics;
using Scriban;
using Scriban.Syntax;

namespace Kalk.Core
{
    internal class KalkExpressionSimplifier
    {
        private readonly TemplateContext _context;
        private object _value;
        private List<KalkBinaryExpression> _powers;
        
        public KalkExpressionSimplifier(TemplateContext context)
        {
            _context = context;
            _value = 1;
        }
        
        public (object, KalkExpression) Canonical(KalkExpression value)
        {
            Collect(value);
            SquashPowers();

            // Compute the final canonical value
            KalkExpression leftValue = null;
            if (_powers != null)
            {
                for (var i = 0; i < _powers.Count; i++)
                {
                    var power = _powers[i];
                    var powerValue = _context.ToObject<double>(_context.CurrentSpan, power.Unit);
                    if (powerValue < 0)
                    {
                        powerValue = -powerValue;
                        power.Unit = powerValue;
                        object left = leftValue ?? (object)1.0;
                        leftValue = new KalkBinaryExpression(left, ScriptBinaryOperator.Divide, KalkValue.AlmostEqual(powerValue, 1.0) ? power.Value : power);
                    }
                    else
                    {
                        var nextMul = KalkValue.AlmostEqual(powerValue, 1.0) ? (KalkUnit) power.Value : (KalkExpression) power;
                        leftValue = leftValue == null ? nextMul : new KalkBinaryExpression(leftValue, ScriptBinaryOperator.Multiply, nextMul);
                    }
                }
            }


            return (_value, leftValue);
        }

        private int SortPowerPerSymbol(KalkBinaryExpression left, KalkBinaryExpression right)
        {
            var leftSymbol = (KalkUnit) left.Value;
            var rightSymbol = (KalkUnit) right.Value;

            Debug.Assert(leftSymbol.Value == null);
            Debug.Assert(rightSymbol.Value == null);

            return string.Compare(leftSymbol.Symbol, rightSymbol.Symbol, StringComparison.Ordinal);
        }

        private int SortPowerPerPower(KalkBinaryExpression left, KalkBinaryExpression right)
        {
            var leftPowerValue = _context.ToObject<double>(_context.CurrentSpan, left.Unit);
            var rightPowerValue = _context.ToObject<double>(_context.CurrentSpan, right.Unit);

            var comparePower = rightPowerValue.CompareTo(leftPowerValue);
            if (comparePower != 0) return comparePower;

            // Then compare per symbol
            return SortPowerPerSymbol(left, right);
        }

        private void SquashPowers()
        {
            if (_powers == null) return;
            _powers.Sort(SortPowerPerSymbol);

            // Compress the powers: a^x * a^y = a^(x+y)
            KalkBinaryExpression previousPower = null;
            for (var i = 0; i < _powers.Count; i++)
            {
                var power = _powers[i];
                if (previousPower != null && ReferenceEquals(power.Value, previousPower.Value))
                {
                    var powerResult = ScriptBinaryExpression.Evaluate(_context, _context.CurrentSpan, ScriptBinaryOperator.Add, power.Unit, previousPower.Unit);
                    _powers[i - 1] = new KalkBinaryExpression(power.Value, ScriptBinaryOperator.Power, powerResult);
                    _powers.RemoveAt(i);
                    i--;
                    continue;
                }

                previousPower = power;
            }

            // Remove any powers a^0.0
            for (var i = 0; i < _powers.Count; i++)
            {
                var power = _powers[i];
                var powerValue = _context.ToObject<double>(_context.CurrentSpan, power.Unit);
                if (Math.Abs(powerValue) < (float.Epsilon * 4))
                {
                    _powers.RemoveAt(i);
                    i--;
                }
            }

            // Sort power per Power first and symbol after
            // From largest to smallest
            _powers.Sort(SortPowerPerPower);
        }

        private void Collect(KalkExpressionSimplifier simplifier)
        {
            Collect(simplifier._value);
            if (simplifier._powers != null)
            {
                foreach (var power in simplifier._powers)
                {
                    Collect(power);
                }
            }
        }

        private void Collect(object value)
        {
            if (value == null) return;

            if (value is KalkUnit symbol)
            {
                if (symbol.Value != null)
                {
                    Collect(symbol.Value);
                }
                else
                {
                    if (_powers == null) _powers = new List<KalkBinaryExpression>();
                    _powers.Add(new KalkBinaryExpression(symbol, ScriptBinaryOperator.Power, 1));
                }
            }
            else if (value is KalkBinaryExpression binary)
            {
                if (binary.Operator == ScriptBinaryOperator.Multiply)
                {
                    var leftSimplifier = new KalkExpressionSimplifier(_context);
                    leftSimplifier.Collect(binary.Value);
                    Collect(leftSimplifier);

                    var rightSimplifier = new KalkExpressionSimplifier(_context);
                    rightSimplifier.Collect(binary.Unit);
                    Collect(rightSimplifier);
                }
                else if (binary.Operator == ScriptBinaryOperator.Divide)
                {
                    Collect(binary.Value);
                    if (binary.Unit is KalkExpression)
                    {
                        Collect(new KalkBinaryExpression(binary.Unit, ScriptBinaryOperator.Power, -1));
                    }
                    else
                    {
                        var result = ScriptBinaryExpression.Evaluate(_context, _context.CurrentSpan, ScriptBinaryOperator.Divide, 1, binary.Unit);
                        SquashValue(result);
                    }
                }
                else
                {
                    Debug.Assert(binary.Operator == ScriptBinaryOperator.Power);
                    if (_powers == null) _powers = new List<KalkBinaryExpression>();

                    // (a * b^2) ^ 5
                    // a ^ 5 * b ^ 10
                    var subSimplifier = new KalkExpressionSimplifier(_context);
                    subSimplifier.Collect(binary.Value);

                    var subValue = _context.ToObject<double>(_context.CurrentSpan, subSimplifier._value);

                    if (!KalkValue.AlmostEqual(subValue, 1.0))
                    {
                        var result = ScriptBinaryExpression.Evaluate(_context, _context.CurrentSpan, ScriptBinaryOperator.Power, subSimplifier._value, binary.Unit);
                        SquashValue(result);
                    }

                    if (subSimplifier._powers != null)
                    {
                        foreach (var powerExpression in subSimplifier._powers)
                        {
                            var powerResult = ScriptBinaryExpression.Evaluate(_context, _context.CurrentSpan, ScriptBinaryOperator.Multiply, powerExpression.Unit, binary.Unit);
                            var newPower = new KalkBinaryExpression(powerExpression.Value, ScriptBinaryOperator.Power, powerResult);
                            _powers.Add(newPower);
                        }
                    }
                }
            }
            else
            {
                SquashValue(value);
            }
        }

        private void SquashValue(object value)
        {
            _value = ScriptBinaryExpression.Evaluate(_context, _context.CurrentSpan, ScriptBinaryOperator.Multiply, _value, value);
        }
    }
}