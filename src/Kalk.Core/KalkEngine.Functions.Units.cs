using System;
using System.Collections.Generic;
using System.Linq;
using Scriban.Syntax;

namespace Kalk.Core
{
    public partial class KalkEngine
    {
        public const string CategoryUnits = "Unit Functions";
        
        /// <summary>
        /// If used in an expression, returns an object containing all units defined.
        /// Otherwise it will display units in a friendly format.
        /// By default, no units are defined. You can define units by using the `unit` function
        /// and you can also import predefined units or currencies via `import StandardUnits` or
        /// `import Currencies`.
        /// </summary>
        /// <example>
        /// ```kalk
        /// >>> unit(tomato, "A tomato unit", prefix: "decimal")
        /// # unit(tomato, "A tomato unit", prefix: "decimal")
        /// out = tomato
        /// >>> unit(ketchup, "A ketchup unit", kup, 5 tomato, prefix: "decimal")
        /// # unit(ketchup, "A ketchup unit", kup, 5 * tomato, prefix: "decimal")
        /// out = kup
        /// >>> units
        /// # User Defined Units
        /// unit(ketchup, "A ketchup unit", kup, 5 * tomato, prefix: "decimal")
        ///   - yottaketchup/Ykup, zettaketchup/Zkup, exaketchup/Ekup, petaketchup/Pkup, teraketchup/Tkup,
        ///     gigaketchup/Gkup, megaketchup/Mkup, kiloketchup/kkup, hectoketchup/hkup, decaketchup/dakup,
        ///     deciketchup/dkup, centiketchup/ckup, milliketchup/mkup, microketchup/µkup, nanoketchup/nkup,
        ///     picoketchup/pkup, femtoketchup/fkup, attoketchup/akup, zeptoketchup/zkup, yoctoketchup/ykup
        /// 
        /// unit(tomato, "A tomato unit", tomato, prefix: "decimal")
        ///   - yottatomato/Ytomato, zettatomato/Ztomato, exatomato/Etomato, petatomato/Ptomato,
        ///     teratomato/Ttomato, gigatomato/Gtomato, megatomato/Mtomato, kilotomato/ktomato,
        ///     hectotomato/htomato, decatomato/datomato, decitomato/dtomato, centitomato/ctomato,
        ///     millitomato/mtomato, microtomato/µtomato, nanotomato/ntomato, picotomato/ptomato,
        ///     femtotomato/ftomato, attotomato/atomato, zeptotomato/ztomato, yoctotomato/ytomato
        /// ```
        /// </example>
        [KalkExport("units", CategoryUnits)]
        public KalkUnits Units { get; }

        /// <summary>
        /// Converts from one value unit to a destination unit.
        ///
        /// The pipe operator |> can be used between the src and destination unit to make it
        /// more readable. Example: `105 g |> to kg`
        /// </summary>
        /// <param name="src">The source value with units.</param>
        /// <param name="dst">The destination unit.</param>
        /// <returns>The result of the calculation.</returns>
        /// <example>
        /// ```kalk
        /// >>> import StandardUnits
        /// # 1294 units successfully imported from module `StandardUnits`.
        /// >>> 10 kg/s |> to kg/h
        /// # ((10 * kg) / s) |> to(kg / h)
        /// out = 36000 * kg / h
        /// >>> 50 kg/m |> to g/km
        /// # ((50 * kg) / m) |> to(g / km)
        /// out = 50000000 * g / km
        /// ```
        /// </example>
        [KalkExport("to", CategoryUnits)]
        public KalkExpression ConvertTo(KalkExpression src, KalkExpression dst)
        {
            return src.ConvertTo(this, dst);
        }

        /// <summary>
        /// Defines a unit with the specified name and characteristics.
        /// </summary>
        /// <param name="name">Long name of the unit.</param>
        /// <param name="description">A description of the unit. This value is optional.</param>
        /// <param name="symbol">Short name (symbol) of the unit. This value is optional.</param>
        /// <param name="value">The expression value of this unit. This value is optional.</param>
        /// <param name="plural">The plural name of this unit. This value is optional.</param>
        /// <param name="prefix">A comma list separated of prefix kinds:
        /// - "decimal": Defines the twenty prefixes for the International System of Units (SI). Example: Yotta/Y, kilo/k, milli/m...
        /// - "binary": Defines the binary prefixes. See https://en.wikipedia.org/wiki/Binary_prefix. Example: kibbi/Ki, mebi/Mi...
        /// - Individual prefixes:
        ///   Decimal prefixes:
        ///   - `Y` - `Yotta` (10^24)
        ///   - `Z` - `Zetta` (10^21)
        ///   - `E` - `Exa` (10^18)
        ///   - `P` - `Peta` (10^15)
        ///   - `T` - `Tera` (10^12)
        ///   - `G` - `Giga` (10^9)
        ///   - `M` - `Mega` (10^6)
        ///   - `k` - `kilo` (10^3)
        ///   - `h` - `hecto` (10^2)
        ///   - `da` - `deca` (10^1)
        ///   - `d` - `deci` (10^)-1
        ///   - `c` - `centi` (10^)-2
        ///   - `m` - `milli` (10^)-3
        ///   - `µ` - `micro` (10^-6)
        ///   - `n` - `nano` (10^)-9
        ///   - `p` - `pico` (10^)-12
        ///   - `f` - `femto` (10^)-15
        ///   - `a` - `atto` (10^)-18
        ///   - `z` - `zepto` (10^)-21
        ///   - `y` - `yocto` (10^)-24
        ///   
        ///   Binary prefixes:
        ///   - `Ki` - `Kibi` (2^10)
        ///   - `Mi` - `Mibi` (2^20)
        ///   - `Gi` - `Gibi` (2^30)
        ///   - `Ti` - `Tibi` (2^40)
        ///   - `Pi` - `Pibi` (2^50)
        ///   - `Ei` - `Eibi` (2^60)
        ///   - `Zi` - `Zibi` (2^70)
        ///   - `Yi` - `Yibi` (2^80)
        /// </param>
        /// <returns>The associated unit object.</returns>
        /// <example>
        /// ```kalk
        /// >>> unit(tomato, "A tomato unit", prefix: "decimal")
        /// # unit(tomato, "A tomato unit", prefix: "decimal")
        /// out = tomato
        /// >>> unit(ketchup, "A ketchup unit", kup, 5 tomato, prefix: "decimal")
        /// # unit(ketchup, "A ketchup unit", kup, 5 * tomato, prefix: "decimal")
        /// out = kup
        /// >>> 4 kup
        /// # 4 * kup
        /// out = 20 * tomato
        /// >>> tomato
        /// unit(tomato, "A tomato unit", tomato, prefix: "decimal")
        ///   - yottatomato/Ytomato, zettatomato/Ztomato, exatomato/Etomato, petatomato/Ptomato, 
        ///     teratomato/Ttomato, gigatomato/Gtomato, megatomato/Mtomato, kilotomato/ktomato, 
        ///     hectotomato/htomato, decatomato/datomato, decitomato/dtomato, centitomato/ctomato, 
        ///     millitomato/mtomato, microtomato/µtomato, nanotomato/ntomato, picotomato/ptomato, 
        ///     femtotomato/ftomato, attotomato/atomato, zeptotomato/ztomato, yoctotomato/ytomato
        /// >>> ketchup
        /// unit(ketchup, "A ketchup unit", kup, 5 * tomato, prefix: "decimal")
        ///   - yottaketchup/Ykup, zettaketchup/Zkup, exaketchup/Ekup, petaketchup/Pkup, teraketchup/Tkup, 
        ///     gigaketchup/Gkup, megaketchup/Mkup, kiloketchup/kkup, hectoketchup/hkup, decaketchup/dakup, 
        ///     deciketchup/dkup, centiketchup/ckup, milliketchup/mkup, microketchup/µkup, nanoketchup/nkup, 
        ///     picoketchup/pkup, femtoketchup/fkup, attoketchup/akup, zeptoketchup/zkup, yoctoketchup/ykup
        /// ```
        /// </example>
        /// 
        [KalkExport("unit", CategoryUnits)]
        public KalkExpression DefineUserUnit(ScriptVariable name, string description = null, ScriptVariable symbol = null, KalkExpression value = null, string plural = null, string prefix = null)
        {
            if (name == null || string.IsNullOrEmpty(name.Name)) throw new ArgumentNullException(nameof(name));
            return RegisterUnit(new KalkUnit(name.Name), description, symbol?.Name, value, plural, prefix, isUser: true);
        }

        public KalkExpression RegisterUnit(KalkUnit unit, string description = null, string symbol = null, KalkExpression value = null, string plural = null, string prefix = null, bool isUser = false)
        {
            if (unit == null) throw new ArgumentNullException(nameof(unit));
            var name = unit.Name;
            symbol ??= name;

            // Override isUser
            if (_registerAsSystem) isUser = false;

            CheckVariableAvailable(name, nameof(name), false);

            var prefixList = new List<KalkUnitPrefix>();
            if (prefix != null)
            {
                var prefixes = prefix.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);
                foreach(var prefixItem in prefixes)
                {
                    if (prefixItem == "decimal")
                    {
                        prefixList.AddRange(KalkUnitPrefix.GetDecimals());
                    }
                    else if (prefixItem == "binary")
                    {
                        prefixList.AddRange(KalkUnitPrefix.GetBinaries());
                    }
                    else if (KalkUnitPrefix.TryGet(prefixItem, out var descriptor))
                    {
                        prefixList.Add(descriptor);
                    }
                    else
                    {
                        throw new ArgumentException($"The prefix `{prefixItem}` does not exist.", nameof(prefix));
                    }
                }
                prefixList = prefixList.Distinct().ToList();
            }

            // Pre-check all prefix with name/symbol
            foreach (var prefixDesc in prefixList)
            {
                var prefixWithName = $"{prefixDesc.Name}{name}";
                CheckVariableAvailable(prefixWithName, nameof(name), false);

                var prefixWithSymbol = $"{prefixDesc.Prefix}{symbol}";
                CheckVariableAvailable(prefixWithSymbol, nameof(name), false);
            }

            unit.Description = description;
            unit.Symbol = symbol;
            unit.Value = value;
            unit.IsUser = isUser;
            unit.Prefix = prefix;
            if (plural != null)
            {
                unit.Plural = plural;
            }

            if (unit.Symbol != unit.Name)
            {
                CheckVariableAvailable(unit.Symbol, nameof(symbol), false);
            }

            if (unit.Plural != unit.Name)
            {
                CheckVariableAvailable(unit.Plural, nameof(plural), false);
            }

            // Here we are all done after checking everything

            Units.Add(name, unit);


            if (unit.Symbol != unit.Name)
            {
                Units.Add(unit.Symbol, unit);
            }

            if (unit.Plural != unit.Name)
            {
                Units.Add(unit.Plural, unit);
            }
            
            // Register prefixes
            foreach (var prefixDesc in prefixList)
            {
                var prefixWithName = $"{prefixDesc.Name}{unit.Name}";
                var prefixWithSymbol = $"{prefixDesc.Prefix}{unit.Symbol}";

                var unitPrefix = new KalkUnit(prefixWithName)
                {
                    Description = description,
                    Symbol = prefixWithSymbol,
                    Value = new KalkBinaryExpression(Math.Pow(prefixDesc.Base, prefixDesc.Exponent), ScriptBinaryOperator.Multiply, unit),
                    IsUser = isUser,
                    Parent = unit,
                };
                unit.Derived.Add(unitPrefix);

                Units.Add(prefixWithName, unitPrefix);
                Units.Add(prefixWithSymbol, unitPrefix);
            }

            return unit;
        }

        private void CheckVariableAvailable(string name, string nameOf, bool prefix)
        {
            if (Units.ContainsKey(name))
            {
                throw new ArgumentException(prefix ? $"The name with prefix `{name}` is already used by another unit." : $"The name `{name}` is already used by another unit.", nameOf);
            }

            if (Builtins.ContainsKey(name))
            {
                throw new ArgumentException(prefix ? $"The name with prefix `{name}` is already used a builtin variable or function." : $"The name `{name}` is already used a builtin variable or function.", nameOf);
            }
        }
    }
}