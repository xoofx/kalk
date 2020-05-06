namespace Kalk.Core
{
    public struct KalkMeasure
    {
        public KalkMeasure(object value, KalkUnit unit)
        {
            Value = value;
            Unit = unit;
        }

        public object Value { get; }

        public KalkUnit Unit { get; }
    }
}