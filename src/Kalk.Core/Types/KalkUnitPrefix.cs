using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Kalk.Core
{
    [Flags]
    public enum KalkUnitPrefix
    {
        Peta, // -   P   10^15    
        Tera, // -   T   10^12    
        Giga, // -   G   10^9     
        Mega, // -   M   10^6     
        kilo, // -   k   10^3     
        centi, // -  c   10^-2    
        milli, // -  m   10^-3    
        micro, // -  u   10^-6    
        nano,  // -  n   10^-9    
        pico,  // -  p   10^-12   
        femto, // -  f   10^-15   
        atto,  // -  a   10^-18   
    }

    public static class KalkUnitPrefixExtension
    {
        private static string[] PrefixNames = Enum.GetNames(typeof(KalkUnitPrefix));
        private static Array PrefixValues = Enum.GetValues(typeof(KalkUnitPrefix));
        private static KalkUnitPrefixDescriptor[] _descriptors = new KalkUnitPrefixDescriptor[PrefixNames.Length];

        static KalkUnitPrefixExtension()
        {
            for (int i = 0; i < PrefixValues.Length; i++)
            {
                var toMatch = (KalkUnitPrefix)PrefixValues.GetValue(i);
                _descriptors[i] = GetDescriptor(toMatch);
            }
        }

        public static List<KalkUnitPrefixDescriptor> Descriptors(this KalkUnitPrefix prefix)
        {
            var descriptors = new List<KalkUnitPrefixDescriptor>();
            for (int i = 0; i < PrefixValues.Length; i++)
            {
                var toMatch = (KalkUnitPrefix) PrefixValues.GetValue(i);
                if ((toMatch & prefix) != 0)
                {
                    descriptors.Add(_descriptors[i]);
                }
            }

            return descriptors;
        }

        private static KalkUnitPrefixDescriptor GetDescriptor(KalkUnitPrefix singlePrefix)
        {
            switch (singlePrefix)
            {
                case KalkUnitPrefix.Peta: 
                    return new KalkUnitPrefixDescriptor(nameof(KalkUnitPrefix.Peta), 15);
                case KalkUnitPrefix.Tera:
                    return new KalkUnitPrefixDescriptor(nameof(KalkUnitPrefix.Tera), 12);
                case KalkUnitPrefix.Giga:
                    return new KalkUnitPrefixDescriptor(nameof(KalkUnitPrefix.Giga), 9);
                case KalkUnitPrefix.Mega:
                    return new KalkUnitPrefixDescriptor(nameof(KalkUnitPrefix.Mega), 6);
                case KalkUnitPrefix.kilo:
                    return new KalkUnitPrefixDescriptor(nameof(KalkUnitPrefix.kilo), 3);
                case KalkUnitPrefix.centi:
                    return new KalkUnitPrefixDescriptor(nameof(KalkUnitPrefix.centi), -2);
                case KalkUnitPrefix.milli:
                    return new KalkUnitPrefixDescriptor(nameof(KalkUnitPrefix.milli), -3);
                case KalkUnitPrefix.micro:
                    return new KalkUnitPrefixDescriptor(nameof(KalkUnitPrefix.milli), -6);
                case KalkUnitPrefix.nano:
                    return new KalkUnitPrefixDescriptor(nameof(KalkUnitPrefix.milli), -9);
                case KalkUnitPrefix.pico:
                    return new KalkUnitPrefixDescriptor(nameof(KalkUnitPrefix.milli), -12);
                case KalkUnitPrefix.femto:
                    return new KalkUnitPrefixDescriptor(nameof(KalkUnitPrefix.milli), -15);
                case KalkUnitPrefix.atto:
                    return new KalkUnitPrefixDescriptor(nameof(KalkUnitPrefix.milli), -18);
                default:
                    throw new ArgumentOutOfRangeException(nameof(singlePrefix), singlePrefix, null);
            }
        }
    }

    public readonly struct KalkUnitPrefixDescriptor
    {
        public KalkUnitPrefixDescriptor(string name, int exponent) : this()
        {
            Name = name;
            Abbreviation = name[0];
            Exponent = exponent;
        }

        public KalkUnitPrefixDescriptor(string name, char abbreviation, int exponent)
        {
            Name = name;
            Abbreviation = abbreviation;
            Exponent = exponent;
        }

        public string Name { get; }

        public char Abbreviation { get; }

        public int Exponent { get; }


        public override string ToString()
        {
            return $"{Name,10} - {Abbreviation} 10^{Exponent}";
        }
    }
}