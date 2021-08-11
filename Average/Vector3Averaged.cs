using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sacristan.Utils.Average
{
    public class Vector3Averaged : Averaged<Vector3>
    {
        public Vector3Averaged(byte maxSamples) : base(maxSamples) { }
        public override Vector3 Add(Vector3 a, Vector3 b) => a + b;
        public override Vector3 Divide(Vector3 a, int b) => a / b;

    }
}
