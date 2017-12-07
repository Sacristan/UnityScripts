using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sacristan.Utils
{
    public class MoveFromOffsetToOrigin : MoveFromToOrigin
    {
        [SerializeField]
        private Vector3 fromOffset;

        protected override void Awake()
        {
            base.Awake();
            this.fromPos = targetPos + fromOffset;
        }
    }
}