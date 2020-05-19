namespace Kalk.Core
{
    public class KalkColorRgbConstructor : KalkColorConstructor
    {
        public KalkColorRgbConstructor() : base(3)
        {
        }

        protected override KalkVector<int> NewVector(int dimension) => new KalkColorRgb();
    }
}