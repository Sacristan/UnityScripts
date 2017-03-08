using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sacristan.Utils
{
    public class MoveFromTo : MonoBehaviour
    {
        [SerializeField]
        private Vector3 fromOffset;

        [SerializeField]
        private float speed = 1f;

        private IEnumerator Start()
        {
            float t = 0f;

            Vector3 targetPos = transform.localPosition;
            Vector3 fromPos = targetPos + fromOffset;

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