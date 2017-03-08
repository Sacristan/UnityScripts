using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sacristan.Utils
{
    public class MoveFromToOrigin : MonoBehaviour
    {
        [SerializeField]
        private float speed = 1f;

        private float t=0f;

        protected Vector3 targetPos;
        protected Vector3 fromPos;

        protected virtual void Awake()
        {
            targetPos = transform.localPosition;
            fromPos = Vector3.zero;
        }

        protected virtual IEnumerator Start()
        {
            float step = Time.deltaTime * speed;

            do
            {
                t += step;
                transform.localPosition = Vector3.Lerp(fromPos, targetPos, t);
                yield return null;
            }
            while (t < 1f);
        }

    }
}