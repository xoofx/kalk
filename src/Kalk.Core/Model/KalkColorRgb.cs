using System.Collections.Generic;

namespace Kalk.Core
{
    public class KalkColorRgb : KalkColor
    {
        public KalkColorRgb() : base(3)
        {
        }

        public KalkColorRgb(KalkColorRgb values) : base(values)
        {
        }

        public KalkColorRgb(int r, int g, int b) : this()
        {
            this[0] = r & 0xFF;
            this[1] = g & 0xFF;
            this[2] = b & 0xFF;
        }

        public KalkColorRgb(int rgb) : this()
        {
            this[0] = (rgb >> 16) & 0xFF;
            this[1] = (rgb >> 8) & 0xFF;
            this[2] = rgb & 0xFF;
        }

        public override string TypeName => "rgb";

        public override KalkVector Clone()
        {
            return new KalkColorRgb(this);
        }

        protected override KalkVector<int> NewVector(int length) => new KalkColorRgb();
    }
}