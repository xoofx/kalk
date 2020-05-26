namespace Kalk.Core
{
    public class KalkColorRgbaConstructor : KalkColorConstructor
    {
        public KalkColorRgbaConstructor() : base(4)
        {
        }

        protected override KalkVector<byte> NewVector(int dimension) => new KalkColorRgba();
    }
}