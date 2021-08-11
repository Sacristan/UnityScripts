using System.Collections.Generic;

namespace Sacristan.Utils.Average
{
    public abstract class Averaged<T> where T : struct
    {
        List<T> stack;
        readonly byte maxSamples;

        public Averaged(byte maxSamples)
        {
            this.maxSamples = maxSamples;
            stack = new List<T>();
        }

        public bool EnoughSamples() => stack.Count >= maxSamples;

        public void Sample(T sample)
        {
            stack.Add(sample);
            if (stack.Count > maxSamples) stack.RemoveAt(0);
        }

        public T GetAverage()
        {
            T sum = default(T);

            for (int i = 0; i < stack.Count; i++)
            {
                sum = Add(sum, stack[i]);
            }

            return Divide(sum, stack.Count);
        }

        public T GetAverageOrLastValIfNotSampled()
        {
            if (EnoughSamples()) return GetAverage();
            else
            {
                if (stack.Count > 1) return stack[stack.Count - 1];
                else return default(T);
            }
        }

        public abstract T Add(T a, T b);
        public abstract T Divide(T a, int b);
    }
}