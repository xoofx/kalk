using System;
using Scriban;
using Scriban.Helpers;
using Scriban.Parsing;
using Scriban.Runtime;
using Scriban.Syntax;

namespace Kalk.Core
{
    public class KalkCompositeValue : IScriptConvertibleFrom, IScriptTransformable
    {
        public IScriptTransformable Transformable;

        public object Value;

        public KalkCompositeValue()
        {
        }

        public KalkCompositeValue(object value)
        {
            Transformable = value as IScriptTransformable;
            Value = Transformable == null ? value : null;
        }

        public KalkCompositeValue(IScriptTransformable transformable)
        {
            Transformable = transformable;
        }
        
        public object TransformArg<TFrom, TTo>(TemplateContext context, Func<TFrom, TTo> apply)
        {
            try
            {
                return Transform(context, apply);
            }
            catch (ScriptRuntimeException ex)
            {
                throw new ScriptArgumentException(0, ex.OriginalMessage);
            }
            catch (Exception ex)
            {
                throw new ScriptArgumentException(0, ex.Message);
            }
        }

        public object Transform<TFrom, TTo>(TemplateContext context, Func<TFrom, TTo> apply)
        {
            if (Transformable != null)
            {
                return Transformable.Transform(context, context.CurrentSpan, value =>
                {
                    var nestedValue = (KalkCompositeValue)context.ToObject(context.CurrentSpan, value, this.GetType());
                    // Recursively apply the transformation with the same value
                    return nestedValue.Transform(context, apply);
                }, typeof(TTo));
            }

            return apply(context.ToObject<TFrom>(context.CurrentSpan, Value));
        }


        public virtual Type ElementType => typeof(object);

        public virtual bool CanTransform(Type transformType)
        {
            return true;
        }

        public bool Visit(TemplateContext context, SourceSpan span, Func<object, bool> visit)
        {
            if (Transformable != null)
            {
                return Transformable.Visit(context, span, visit);
            }
            return visit(Value);
        }

        public object Transform(TemplateContext context, SourceSpan span, Func<object, object> apply, Type destType)
        {
            if (Transformable != null) return Transformable.Transform(context, span, apply, destType);
            return apply(Value);
        }
        
        public bool TryConvertFrom(TemplateContext context, SourceSpan span, object value)
        {
            if (value is IScriptTransformable valuable)
            {
                if (!CanTransform(valuable))
                {
                    throw new ScriptRuntimeException(span, $"Cannot transform the value `{value}` between the element type `{valuable.ElementType.ScriptPrettyName()}` and the target function `{ElementType.ScriptPrettyName()}`.");
                }

                Transformable = valuable;
            }
            else Value = Accept(context, span, value);
            return true;
        }

        protected virtual bool CanTransform(IScriptTransformable valuable)
        {
            return true;
        }

        protected virtual object Accept(TemplateContext context, SourceSpan span, object value)
        {
            return value;
        }
    }

    public class KalkDoubleValue : KalkCompositeValue
    {
        public KalkDoubleValue()
        {
        }

        public KalkDoubleValue(IScriptTransformable transformable) : base(transformable)
        {
        }

        public KalkDoubleValue(object value) : base(value)
        {
        }


        public override Type ElementType => typeof(double);

        public override bool CanTransform(Type transformType)
        {
            return transformType == typeof(double) || transformType == typeof(float);
        }

        protected override bool CanTransform(IScriptTransformable valuable)
        {
            return valuable.CanTransform(typeof(double));
        }
        
        protected override object Accept(TemplateContext context, SourceSpan span, object value)
        {
            return context.ToObject<double>(span, value);
        }
    }


    public class KalkTrigDoubleValue : KalkDoubleValue
    {
        public override Type ElementType => typeof(double);

        public override bool CanTransform(Type transformType)
        {
            return transformType == typeof(double) || transformType == typeof(float);
        }

        protected override bool CanTransform(IScriptTransformable valuable)
        {
            return valuable.CanTransform(typeof(double));
        }

        protected override object Accept(TemplateContext context, SourceSpan span, object value)
        {
            return context.ToObject<double>(span, value);
        }
    }

    public class KalkLongValue : KalkCompositeValue
    {
        public override Type ElementType => typeof(long);

        public override bool CanTransform(Type transformType)
        {
            return transformType == typeof(long) || transformType == typeof(int);
        }

        protected override bool CanTransform(IScriptTransformable valuable)
        {
            return valuable.CanTransform(typeof(long));
        }

        protected override object Accept(TemplateContext context, SourceSpan span, object value)
        {
            return context.ToObject<long>(span, value);
        }
    }

    public class KalkIntValue : KalkCompositeValue
    {
        public override Type ElementType => typeof(int);

        public override bool CanTransform(Type transformType)
        {
            return transformType == typeof(int);
        }

        protected override bool CanTransform(IScriptTransformable valuable)
        {
            return valuable.CanTransform(typeof(int));
        }

        protected override object Accept(TemplateContext context, SourceSpan span, object value)
        {
            return context.ToObject<int>(span, value);
        }
    }

}