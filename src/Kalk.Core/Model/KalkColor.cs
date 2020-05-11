using System;
using System.Collections.Generic;
using System.Text;
using Consolus;
using Scriban;

namespace Kalk.Core
{

    // https://github.com/google/palette.js/tree/master

    public abstract class KalkColor : KalkVector<int>, IKalkConsolable
    {
        protected KalkColor(int dimension) : base(dimension)
        {
        }

        protected KalkColor(IList<int> list) : base(list)
        {
        }

        protected KalkColor(KalkVector<int> values) : base(values)
        {
        }
        
        public override IEnumerable<string> GetMembers()
        {
            for (int i = 0; i < Math.Min(4, Length); i++)
            {
                switch (i)
                {
                    case 0:
                        yield return "r";
                        break;
                    case 1:
                        yield return "g";
                        break;
                    case 2:
                        yield return "b";
                        break;
                    case 3:
                        yield return "a";
                        break;
                }
            }
        }

        public abstract override KalkVector<int> Clone();

        protected override KalkVector<int> NewVector(IList<int> list) => list.Count == 4 ? new KalkColorRgba(list[0], list[1], list[2], list[3]) : list.Count == 3 ? new KalkColorRgb(list[0], list[1], list[2]) : base.NewVector(list);

        protected abstract override KalkVector<int> NewVector(int length);

        protected override void SetComponent(int index, int value)
        {
            value = value < 0 ? 0 : value > 255 ? 255 : value;
            base.SetComponent(index, value);
        }

        public abstract override string Kind { get; }

        public override string ToString(string format, IFormatProvider formatProvider)
        {
            var context = formatProvider as TemplateContext;
            var builder = new StringBuilder();
            builder.Append(Kind);
            builder.Append('(');
            for (int i = 0; i < Length; i++)
            {
                if (i > 0) builder.Append(", ");
                builder.Append(context != null ? context.ObjectToString(this[i]) : this[i].ToString(null, formatProvider));
            }
            builder.Append(')');

            return builder.ToString();
        }

        public void ToConsole(KalkEngine engine, ConsoleText text)
        {
            text.Append(ConsoleStyle.Green, true);
            text.Append(" #");
            for (int i = 0; i < Length; i++)
            {
                text.Append($"{this[i]:X2}");
            }
            text.Append(ConsoleStyle.Green, false);
            text.Append(" ");
            var style = ConsoleStyle.BackgroundRgb(this[0], this[1], this[2]);
            text.Append(style, true);
            text.Append("    ");
            text.Append(style, false);
        }
    }
}