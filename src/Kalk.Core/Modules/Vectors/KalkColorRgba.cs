using Scriban.Syntax;

namespace Kalk.Core
{
    [ScriptTypeName("rgba")]
    public class KalkColorRgba : KalkColor
    {
        public KalkColorRgba() : base(4)
        {
        }

        public KalkColorRgba(byte  r, byte g, byte b, byte a) : this()
        {
            this[0] = r;
            this[1] = g;
            this[2] = b;
            this[3] = a;
        }

        public KalkColorRgba(int rgb) : this()
        {
            this[0] = (byte)((rgb >> 16) & 0xFF);
            this[1] = (byte)((rgb >> 8) & 0xFF);
            this[2] = (byte)(rgb & 0xFF);
            this[3] = (byte)((rgb >> 24) & 0xFF);
        }
        
        public KalkColorRgba(KalkColorRgba values) : base(values)
        {
        }

        public override string TypeName => "rgba";

        public override KalkVector Clone()
        {
            return new KalkColorRgba(this);
        }


        protected override KalkVector<byte> NewVector(int length) => new KalkColorRgba();
    }
}