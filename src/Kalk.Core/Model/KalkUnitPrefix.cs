using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;

namespace Kalk.Core
{
    public sealed class KalkUnitPrefix
    {
        private static readonly string[] PrefixNames = Enum.GetNames(typeof(KalkUnitPrefixCode));
        private static readonly Array PrefixValues = Enum.GetValues(typeof(KalkUnitPrefixCode));
        private static readonly KalkUnitPrefix[] DescriptorArray = new KalkUnitPrefix[PrefixNames.Length - 1];
        private static readonly List<KalkUnitPrefix> Decimals = new List<KalkUnitPrefix>();
        private static readonly List<KalkUnitPrefix> Binaries = new List<KalkUnitPrefix>();
        private static readonly Dictionary<string, KalkUnitPrefix> MapAbbreviationToDescriptor = new Dictionary<string, KalkUnitPrefix>();

        static KalkUnitPrefix()
        {
            for (int i = 1; i < PrefixValues.Length; i++)
            {
                var toMatch = (KalkUnitPrefixCode)PrefixValues.GetValue(i);
                var descriptor = GetDescriptor(toMatch);
                DescriptorArray[i - 1] = descriptor;
                MapAbbreviationToDescriptor[descriptor.Abbreviation] = descriptor;
                if (descriptor.Base == 10) Decimals.Add(descriptor);
                else if (descriptor.Base == 2) Binaries.Add(descriptor);
            }
        }

        public KalkUnitPrefix(KalkUnitPrefixCode code, int exponent)
        {
            Code = code;
            Name = code.ToString();
            Abbreviation = Name[0].ToString(CultureInfo.InvariantCulture);
            Name = Name.ToLowerInvariant();
            Prefix = Abbreviation;
            Base = 10;
            Exponent = exponent;
        }

        public KalkUnitPrefix(KalkUnitPrefixCode code, string abbreviation, int exponent) : this(code, abbreviation, abbreviation, 10, exponent)
        {
        }

        public KalkUnitPrefix(KalkUnitPrefixCode code, string abbreviation, int @base, int exponent) : this(code, abbreviation, abbreviation, @base, exponent)
        {
        }

        public KalkUnitPrefix(KalkUnitPrefixCode code, string abbreviation, string prefix, int @base, int exponent)
        {
            Code = code;
            Name = code.ToString().ToLowerInvariant();
            Abbreviation = abbreviation;
            Prefix = prefix;
            Base = @base;
            Exponent = exponent;
        }

        public KalkUnitPrefixCode Code { get; }

        public string Name { get; }

        public string Abbreviation { get; }

        public string Prefix { get; }

        public int Base { get; }

        public int Exponent { get; }

        public override string ToString()
        {
            return $"{Name,10} - {Abbreviation,2} '{Prefix,2}' {Base,2}^{Exponent}";
        }

        public static bool TryGet(string abbreviation, out KalkUnitPrefix descriptor)
        {
            if (abbreviation == null) throw new ArgumentNullException(nameof(abbreviation));

            return MapAbbreviationToDescriptor.TryGetValue(abbreviation, out descriptor);
        }

        public static IReadOnlyList<KalkUnitPrefix> GetDecimals()
        {
            return Decimals;
        }

        public static IReadOnlyList<KalkUnitPrefix> GetBinaries()
        {
            return Binaries;
        }

        public static List<KalkUnitPrefix> GetListFromCode(KalkUnitPrefixCode prefixCode)
        {
            var descriptors = new List<KalkUnitPrefix>();
            for (int i = 0; i < PrefixValues.Length; i++)
            {
                var toMatch = (KalkUnitPrefixCode)PrefixValues.GetValue(i);
                if ((toMatch & prefixCode) != 0)
                {
                    descriptors.Add(DescriptorArray[i]);
                }
            }

            return descriptors;
        }

        private static KalkUnitPrefix GetDescriptor(KalkUnitPrefixCode singlePrefixCode)
        {
            switch (singlePrefixCode)
            {
                case KalkUnitPrefixCode.Zetta:
                    return new KalkUnitPrefix(KalkUnitPrefixCode.Zetta, 24);
                case KalkUnitPrefixCode.Yotta:
                    return new KalkUnitPrefix(KalkUnitPrefixCode.Yotta, 21);
                case KalkUnitPrefixCode.Exa:
                    return new KalkUnitPrefix(KalkUnitPrefixCode.Exa, 18);
                case KalkUnitPrefixCode.Peta:
                    return new KalkUnitPrefix(KalkUnitPrefixCode.Peta, 15);
                case KalkUnitPrefixCode.Tera:
                    return new KalkUnitPrefix(KalkUnitPrefixCode.Tera, 12);
                case KalkUnitPrefixCode.Giga:
                    return new KalkUnitPrefix(KalkUnitPrefixCode.Giga, 9);
                case KalkUnitPrefixCode.Mega:
                    return new KalkUnitPrefix(KalkUnitPrefixCode.Mega, 6);
                case KalkUnitPrefixCode.kilo:
                    return new KalkUnitPrefix(KalkUnitPrefixCode.kilo, 3);
                case KalkUnitPrefixCode.hecto:
                    return new KalkUnitPrefix(KalkUnitPrefixCode.hecto, 2);
                case KalkUnitPrefixCode.deca:
                    return new KalkUnitPrefix(KalkUnitPrefixCode.deca, "da", 10, 1);
                case KalkUnitPrefixCode.deci:
                    return new KalkUnitPrefix(KalkUnitPrefixCode.deci, -1);
                case KalkUnitPrefixCode.centi:
                    return new KalkUnitPrefix(KalkUnitPrefixCode.centi, -2);
                case KalkUnitPrefixCode.milli:
                    return new KalkUnitPrefix(KalkUnitPrefixCode.milli, -3);
                case KalkUnitPrefixCode.micro:
                    return new KalkUnitPrefix(KalkUnitPrefixCode.micro, "µ", -6);
                case KalkUnitPrefixCode.nano:
                    return new KalkUnitPrefix(KalkUnitPrefixCode.nano, -9);
                case KalkUnitPrefixCode.pico:
                    return new KalkUnitPrefix(KalkUnitPrefixCode.pico, -12);
                case KalkUnitPrefixCode.femto:
                    return new KalkUnitPrefix(KalkUnitPrefixCode.femto, -15);
                case KalkUnitPrefixCode.atto:
                    return new KalkUnitPrefix(KalkUnitPrefixCode.atto, -18);
                case KalkUnitPrefixCode.zepto:
                    return new KalkUnitPrefix(KalkUnitPrefixCode.zepto, -21);
                case KalkUnitPrefixCode.yocto:
                    return new KalkUnitPrefix(KalkUnitPrefixCode.yocto, -24);

                case KalkUnitPrefixCode.Kibi: //  - Ki   2^10 kibibit
                    return new KalkUnitPrefix(KalkUnitPrefixCode.Kibi, "Ki", 2, 10);
                case KalkUnitPrefixCode.Mibi: //  - Mi   2^20 mibibit
                    return new KalkUnitPrefix(KalkUnitPrefixCode.Mibi, "Mi", 2, 20);
                case KalkUnitPrefixCode.Gibi: //  - Gi   2^30 gibibit
                    return new KalkUnitPrefix(KalkUnitPrefixCode.Gibi, "Gi", 2, 30);
                case KalkUnitPrefixCode.Tibi: //  - Ti   2^40 tebibit
                    return new KalkUnitPrefix(KalkUnitPrefixCode.Tibi, "Ti", 2, 40);
                case KalkUnitPrefixCode.Pibi: //  - Pi   2^50 pebibit
                    return new KalkUnitPrefix(KalkUnitPrefixCode.Pibi, "Pi", 2, 50);
                case KalkUnitPrefixCode.Eibi: //  - Ei   2^60 exbibit
                    return new KalkUnitPrefix(KalkUnitPrefixCode.Eibi, "Ei", 2, 60);
                case KalkUnitPrefixCode.Zibi: //  - Zi   2^70 zebibit
                    return new KalkUnitPrefix(KalkUnitPrefixCode.Zibi, "Zi", 2, 70);
                case KalkUnitPrefixCode.Yibi: //  - Yi   2^80 yobibit
                    return new KalkUnitPrefix(KalkUnitPrefixCode.Yibi, "Yi", 2, 80);

                //case KalkUnitPrefixCode.Kbit: //  - Kb   2^10 kilobit
                //    return new KalkUnitPrefix(KalkUnitPrefixCode.Kbit, "Kb", "K", 2, 10);
                //case KalkUnitPrefixCode.Mbit: //  - Mb   2^20 megabit
                //    return new KalkUnitPrefix(KalkUnitPrefixCode.Mbit, "Mb", "M", 2, 20);
                //case KalkUnitPrefixCode.Gbi: //  - Gb   2^30 gigabit
                //    return new KalkUnitPrefix(KalkUnitPrefixCode.Gbi, "Gb", "G", 2, 30);

                default:
                    throw new ArgumentOutOfRangeException(nameof(singlePrefixCode), singlePrefixCode, null);
            }
        }
    }
}