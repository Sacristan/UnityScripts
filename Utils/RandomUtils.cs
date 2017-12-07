using System;
using System.Collections.Generic;

namespace Sacristan.Utils
{
    public static class RandomUtils
    {
        public class RandomCountBiggerThanRange : Exception
        {
            private int min;
            private int max;
            private int count; 

            private int Range { get { return max - min; } }

            public RandomCountBiggerThanRange(int count, int min, int max)
            {
                this.count = count;
                this.min = min;
                this.max = max;
            }

            public override string Message
            {
                get
                {
                    return string.Format("Count {0} was greater than assigned min {1} max {2} range {3}", this.count, this.min, this.max, Range);
                }
            }
        }

        public static int[] GenerateRandom(int count)
        {
            System.Random random = new System.Random();

            // generate count random values.
            HashSet<int> candidates = new HashSet<int>();
            while (candidates.Count < count)
            {
                // May strike a duplicate.
                candidates.Add(random.Next());
            }

            // load them in to a list.
            List<int> result = new List<int>();
            result.AddRange(candidates);

            // shuffle the results:
            int i = result.Count;
            while (i > 1)
            {
                i--;
                int k = random.Next(i + 1);
                int value = result[k];
                result[k] = result[i];
                result[i] = value;
            }
            return result.ToArray();
        }

        public static int[] GenerateNonRepeatingRandomIndexSequence(int count, int min=0, int max=100)
        {
            System.Random random = new System.Random();

            int diff = max - min;
            if (diff <= count) throw new RandomCountBiggerThanRange(count, min, max);

            List<int> result = new List<int>();

            while (result.Count < count)
            {
                int generatedIndex = random.Next(min, max-1);
                if (!result.Contains(generatedIndex)) result.Add(generatedIndex);
            }

            return result.ToArray();
        }
    }
}
