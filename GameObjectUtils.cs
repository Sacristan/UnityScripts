using UnityEngine;

namespace Sacristan.Utils
{
    public static class GameObjectUtils
    {
        public static void SetLayerRecursively(GameObject obj, int layer)
        {
            obj.layer = layer;

            for (int i = 0; i < obj.transform.childCount; i++)
            {
                Transform child = obj.transform.GetChild(i);
                SetLayerRecursively(child.gameObject, layer);
            }
        }
    }
}