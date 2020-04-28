using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MinMax
{
    [System.Serializable]
    public class Float
    {
        [SerializeField] private float min;
        [SerializeField] private float max;

        public float Min => min;
        public float Max => max;

        public float GetRandomValue()
        {
            return Random.Range(min, max);
        }

        public float GetValueFromPerc(float perc)
        {
            return Mathf.Lerp(min, max, perc);
        }

        public float GetPercFromValue(float value)
        {
            return Mathf.InverseLerp(min, max, value);
        }
    }

    [System.Serializable]
    public class Int
    {
        [SerializeField] private int min;
        [SerializeField] private int max;
        public int Min => min;
        public int Max => max;

        public int GetRandomValue()
        {
            return Random.Range(min, max);
        }

        public int GetValueFromPerc(float perc)
        {
            return (int)Mathf.Lerp(min, max, perc);
        }

        public float GetPercFromValue(int value)
        {
            return Mathf.InverseLerp(min, max, value);
        }
    }
}
