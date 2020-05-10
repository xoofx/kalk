using System;
using System.ComponentModel.Design;
using System.Linq;

namespace Kalk.Core
{
    [Flags]
    public enum KalkUnitPrefixCode
    {
        None = 0,

        // Decimal
        Yotta ,// -  Y   10^24
        Zetta,// -   Z   10^21
        Exa, //  -   E   10^18
        Peta, // -   P   10^15
        Tera, // -   T   10^12
        Giga, // -   G   10^9
        Mega, // -   M   10^6
        kilo, // -   k   10^3
        hecto, // -  h   10^2
        deca, //  -  da  10^1
        deci, //  -  d   10^-1
        centi, // -  c   10^-2
        milli, // -  m   10^-3
        micro, // -  µ   10^-6
        nano,  // -  n   10^-9
        pico,  // -  p   10^-12
        femto, // -  f   10^-15
        atto,  // -  a   10^-18
        zepto, // -  z   10^-21
        yocto, // -  y   10^-24

        // Binary
        Kibi, //  - Ki   2^10 kibibit
        Mibi, //  - Mi   2^20 mibibit
        Gibi, //  - Gi   2^30 gibibit
        Tibi, //  - Ti   2^40 tebibit
        Pibi, //  - Pi   2^50 pebibit
        Eibi, //  - Ei   2^60 exbibit
        Zibi, //  - Zi   2^70 zebibit
        Yibi, //  - Yi   2^80 yobibit

        //Kbit, //  - Kb   2^10 kilobit
        //Mbit, //  - Mb   2^20 megabit
        //Gbi,  //  - Gb   2^30 gigabit
    }
}