using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sacristan.Utils.Average
{
    public class QuaternionAveraged //TODO inherit Average<Quaternion>
    {
        List<Quaternion> stack;
        readonly byte maxSamples;

        public QuaternionAveraged(byte maxSamples)
        {
            this.maxSamples = maxSamples;
            stack = new List<Quaternion>();
        }

        public void Sample(Quaternion quaternion)
        {
            stack.Add(quaternion);
            if (stack.Count > maxSamples) stack.RemoveAt(0);
        }

        public Quaternion GetAverage()
        {
            return GetAverageQuaternion(stack);
        }

        private static Quaternion GetAverageQuaternion(List<Quaternion> quaternions)
        {
            Vector4 cumulativeValue = Vector4.zero;

            for (int i = 1; i < quaternions.Count; i++)
            {
                AverageQuaternion(ref cumulativeValue, quaternions[i], quaternions[0], i);
            }

            return new Quaternion(cumulativeValue.x, cumulativeValue.y, cumulativeValue.z, cumulativeValue.w);
        }

        private static Quaternion AverageQuaternion(ref Vector4 cumulative, Quaternion newRotation, Quaternion firstRotation, int addAmount)
        {
            float w = 0.0f;
            float x = 0.0f;
            float y = 0.0f;
            float z = 0.0f;

            //Before we add the new rotation to the average (mean), we have to check whether the quaternion has to be inverted. Because
            //q and -q are the same rotation, but cannot be averaged, we have to make sure they are all the same.
            if (!AreQuaternionsClose(newRotation, firstRotation))
            {
                newRotation = InverseSignQuaternion(newRotation);
            }

            //Average the values
            float addDet = 1f / (float)addAmount;
            cumulative.w += newRotation.w;
            w = cumulative.w * addDet;
            cumulative.x += newRotation.x;
            x = cumulative.x * addDet;
            cumulative.y += newRotation.y;
            y = cumulative.y * addDet;
            cumulative.z += newRotation.z;
            z = cumulative.z * addDet;

            //note: if speed is an issue, you can skip the normalization step
            return NormalizeQuaternion(x, y, z, w);
        }

        private static Quaternion NormalizeQuaternion(float x, float y, float z, float w)
        {

            float lengthD = 1.0f / (w * w + x * x + y * y + z * z);
            w *= lengthD;
            x *= lengthD;
            y *= lengthD;
            z *= lengthD;

            return new Quaternion(x, y, z, w);
        }

        //Changes the sign of the quaternion components. This is not the same as the inverse.
        private static Quaternion InverseSignQuaternion(Quaternion q)
        {
            return new Quaternion(-q.x, -q.y, -q.z, -q.w);
        }

        //Returns true if the two input quaternions are close to each other. This can
        //be used to check whether or not one of two quaternions which are supposed to
        //be very similar but has its component signs reversed (q has the same rotation as
        //-q)
        private static bool AreQuaternionsClose(Quaternion q1, Quaternion q2)
        {
            float dot = Quaternion.Dot(q1, q2);
            return dot >= 0.0f;
        }
    }
}