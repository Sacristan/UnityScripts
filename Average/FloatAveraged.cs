using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sacristan.Utils.Average
{
    public class FloatAveraged : Averaged<float>
    {
        public FloatAveraged(byte maxSamples) : base(maxSamples) { }
        public override float Add(float a, float b) => a + b;
        public override float Divide(float a, int b) => a / (float)b;
    }
}