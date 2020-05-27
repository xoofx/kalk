using System;
using System.Collections.Generic;
using System.Text;
using Consolus;
using Scriban;
using Scriban.Parsing;
using Scriban.Syntax;

namespace Kalk.Core
{
    // https://github.com/google/palette.js/tree/master

    [ScriptTypeName("color")]
    public abstract class KalkColor : KalkVector<byte>
    {
        protected KalkColor(int dimension) : base(dimension)
        {
        }

        protected KalkColor(IReadOnlyList<byte> list) : base(list)
        {
        }

        protected KalkColor(KalkVector<byte> values) : base(values)
        {
        }

        public int rgb => (int)((r << 16) | (g << 8) | b);

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

        private static float Clamp01(float value) => Math.Clamp(value, 0.0f, 1.0f);

        public KalkVector<float> GetFloatVector(int targetDimension)
        {
            return this is KalkColorRgb
                ? targetDimension == 4 ? 
                    new KalkVector<float>(Clamp01(this[0] / 255.0f), Clamp01(this[1] / 255.0f), Clamp01(this[2] / 255.0f), 1.0f):
                    new KalkVector<float>(Clamp01(this[0] / 255.0f), Clamp01(this[1] / 255.0f), Clamp01(this[2] / 255.0f))
                : new KalkVector<float>(Clamp01(this[0] / 255.0f), Clamp01(this[1] / 255.0f), Clamp01(this[2] / 255.0f), Clamp01(this[3] / 255.0f));
        }

        protected override object GetSwizzleValue(ComponentKind kind, byte result)
        {
            return kind == ComponentKind.xyzw ? (object)Clamp01(result / 255.0f) : result;
        }

        protected override byte TransformComponentToSet(TemplateContext context, SourceSpan span, ComponentKind kind, object value)
        {
            return kind == ComponentKind.xyzw ? (byte)(Clamp01(context.ToObject<float>(span, value)) * 255) : base.TransformComponentToSet(context, span, kind, value);
        }

        protected override KalkVector NewVector(ComponentKind kind, IReadOnlyList<byte> list)
        {
            if (kind == ComponentKind.xyzw)
            {
                if (list.Count == 4)
                {
                    return new KalkVector<float>(Clamp01(list[0] / 255.0f), Clamp01(list[1] / 255.0f), Clamp01(list[2] / 255.0f), Clamp01(list[3] / 255.0f));
                }

                if (list.Count == 3)
                {
                    return new KalkVector<float>(Clamp01(list[0] / 255.0f), Clamp01(list[1] / 255.0f), Clamp01(list[2] / 255.0f));
                }

                if (list.Count == 2)
                {
                    return new KalkVector<float>(Clamp01(list[0] / 255.0f), Clamp01(list[1] / 255.0f));
                }

                throw new InvalidOperationException("Cannot create a float vector type from this rgba components");
            }
            else
            {
                return list.Count == 4 ? new KalkColorRgba(list[0], list[1], list[2], list[3]) : list.Count == 3 ? new KalkColorRgb(list[0], list[1], list[2]) : base.NewVector(kind, list);
            }
        }

        protected abstract override KalkVector<byte> NewVector(int length);

        public abstract override string TypeName { get; }

        public override string ToString(string format, IFormatProvider formatProvider)
        {
            var engine = formatProvider as KalkEngine;
            var builder = new StringBuilder();
            builder.Append(TypeName);
            builder.Append('(');
            var length = this is KalkColorRgb ? 3 : 4;
            for (int i = 0; i < length; i++)
            {
                if (i > 0) builder.Append(", ");
                builder.Append(engine != null ? engine.ObjectToString(this[i]) : this[i].ToString(null, formatProvider));
            }
            builder.Append(')');

            bool isAligned = format == "aligned";

            // rgb(240, 248, 255)
            // rgb(255, 255, 255, 255)
            if (isAligned)
            {
                if (length == 3)
                {
                    builder.Append(' ', "rgb(255, 255, 255)".Length - builder.Length);
                }
                else if (length == 4)
                {
                    builder.Append(' ', "rgb(255, 255, 255, 255)".Length - builder.Length);
                }
            }

            builder.Append(" ## ");
            for (int i = 0; i < length; i++)
            {
                builder.Append($"{this[i]:X2}");
            }

            if (engine != null && engine.IsOutputSupportHighlighting)
            {
                builder.Append(" ");
                builder.Append(ConsoleStyle.BackgroundRgb(this[0], this[1], this[2]));
                builder.Append("    ");
                builder.Append(ConsoleStyle.Reset);
            }

            // Add known color name
            if (KalkColorRgb.TryGetKnownColor(rgb, out var colorName))
            {
                builder.Append(isAligned ? $" {colorName,-20}" : $" {colorName}");
            }

            builder.Append(" ##");
            return builder.ToString();
        }
    }
}