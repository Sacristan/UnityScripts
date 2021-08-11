using System;

namespace Sacristan.Utils.Safe
{
    public abstract class Safe<T> where T : struct, IComparable<T>
    {
        private const int RandomRange = 1000;
        int offset;
        T value;

        public Safe(T value)
        {
            offset = RandomOffset();
            this.value = AddOffset(value, offset);
        }

        public T GetValue() => SubstractOffset(value, offset);

        public void Reset()
        {
            offset = default(int);
            value = default(T);
        }

        public override string ToString() => GetValue().ToString();
        public abstract T AddOffset(T a, int b);
        public abstract T SubstractOffset(T a, int b);

        private static int RandomOffset()
        {
            int offset = 0;
            Random rnd = new Random();

            do
            {
                offset = rnd.Next(-RandomRange, RandomRange);
            }
            while (offset == 0);

            return offset;
        }
    }

    public class Int : Safe<int>
    {
        public Int(int value) : base(value) { }
        public override int AddOffset(int a, int b) => a + b;
        public override int SubstractOffset(int a, int b) => a - b;
    }

    public class Float : Safe<float>
    {
        public Float(float value) : base(value) { }
        public override float AddOffset(float a, int b) => a + b;
        public override float SubstractOffset(float a, int b) => a - b;
    }
}
