using System;

namespace Sacristan.Utils
{
    public class Safe<T> where T : struct
    {
        private const int RandomRange = 1000;
        int offset;
        T value;

        public Safe(T value = default(T))
        {
            offset = RandomOffset();
            this.value = Add(value, offset);
        }

        public T GetValue() => Substract(value, offset);

        public void Reset()
        {
            offset = default(int);
            value = default(T);
        }

        public override string ToString() => GetValue().ToString();

        static T Add(T x, T y)
        {
            dynamic dx = x, dy = y;
            return dx + dy;
        }
        static T Substract(T x, T y)
        {
            dynamic dx = x, dy = y;
            return dx - dy;
        }

        static T Add(T a, int b)
        {
            dynamic ax = a;
            return ax + b;
        }
        static T Substract(T a, int b)
        {
            dynamic ax = a;
            return ax - b;
        }

        public static Safe<T> operator +(Safe<T> a, Safe<T> b) => new Safe<T>(Add(a.GetValue(), b.GetValue()));
        public static Safe<T> operator -(Safe<T> a, Safe<T> b) => new Safe<T>(Substract(a.GetValue(), b.GetValue()));
        public static Safe<T> operator +(Safe<T> a, T b) => new Safe<T>(Add(a.GetValue(), b));
        public static Safe<T> operator -(Safe<T> a, T b) => new Safe<T>(Substract(a.GetValue(), b));

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
}