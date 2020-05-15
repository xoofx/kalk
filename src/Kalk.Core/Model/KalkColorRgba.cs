﻿using System.Collections.Generic;
using MathNet.Numerics.Financial;

namespace Kalk.Core
{
    public class KalkColorRgba : KalkColor
    {
        public KalkColorRgba() : base(4)
        {
        }

        public KalkColorRgba(int r, int g, int b, int a) : this()
        {
            this[0] = r & 0xFF;
            this[1] = g & 0xFF;
            this[2] = b & 0xFF;
            this[3] = a & 0xFF;
        }

        public KalkColorRgba(int rgb) : this()
        {
            this[0] = (rgb >> 24) & 0xFF;
            this[1] = (rgb >> 16) & 0xFF;
            this[2] = (rgb >> 8) & 0xFF;
            this[3] = rgb & 0xFF;
        }
        
        public KalkColorRgba(KalkColorRgba values) : base(values)
        {
        }

        public override string Kind => "rgba";

        public override KalkVector<int> Clone()
        {
            return new KalkColorRgba(this);
        }


        protected override KalkVector<int> NewVector(int length) => new KalkColorRgba();
    }
}