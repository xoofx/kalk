using System;
using System.Collections;
using Scriban;
using Scriban.Syntax;

namespace Kalk.Core
{
    public abstract class KalkColorConstructor : KalkVectorConstructor<int>
    {
        protected KalkColorConstructor(int dimension) : base(dimension)
        {
        }

        protected abstract override KalkVector<int> NewVector(int dimension);

        protected override int GetArgumentValue(TemplateContext context, object arg)
        {
            switch (arg)
            {
                case float f32:
                    return (int)(255 * Math.Clamp(f32, 0.0f, 1.0f));
                case double f64:
                    return (int)(255 * Math.Clamp(f64, 0.0, 1.0));
                case decimal dec:
                    return (int)(255 * Math.Clamp(dec, 0.0m, 1.0m));
                default:
                    return Math.Clamp(base.GetArgumentValue(context, arg), 0, 255);
            }
        }

        protected override void ProcessSingleArgument(TemplateContext context, ref int index, object arg, KalkVector<int> vector)
        {
            int value;
            switch (arg)
            {
                case string rgbStr:
                    try
                    {
                        if (!KalkColorRgb.TryGetKnownColor(rgbStr, out value))
                        {
                            value = int.Parse(rgbStr.TrimStart('#'), System.Globalization.NumberStyles.HexNumber);
                        }
                    }
                    catch
                    {
                        throw new ScriptArgumentException(0, $"Expecting a known css_colors (e.g `AliceBlue`) or an hexadecimal rgb string (e.g #FF80C2) instead of {rgbStr}");
                    }
                    break;
                default:
                    if (arg is IList)
                    {
                        base.ProcessSingleArgument(context, ref index, arg, vector);
                        return;
                    }
                    value = context.ToObject<int>(context.CurrentSpan, arg);
                    break;
            }

            if (Dimension == 4)
            {
                vector[index++] = (value >> 24) & 0xFF;
            }
            vector[index++] = (value >> 16) & 0xFF;
            vector[index++] = (value >> 8) & 0xFF;
            vector[index++] = value & 0xFF;
        }




    }
}