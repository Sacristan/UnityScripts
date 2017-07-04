using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sacristan.Utils
{
    public static class CommonUtils
    {
        //public static void EnableComponents(Component[] components, bool flag)
        //{
        //    for (int i = 0; i < components.Length; i++)
        //    {
        //        components[i].enabled = flag;
        //    }
        //}

        public static void UpdateRenderersColor(Renderer[] renderers, Color color)
        {
            for (int i = 0; i < renderers.Length; i++)
            {
                renderers[i].material.color = color;
            }
        }
    }
}
