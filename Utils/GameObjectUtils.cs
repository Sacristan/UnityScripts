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

        public static void EnableGameObjects(GameObject[] objects, bool flag)
        {
            for (int i = 0; i < objects.Length; i++)
            {
                objects[i].SetActive(flag);
            }
        }
    }
}