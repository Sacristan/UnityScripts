using UnityEngine;

public static class TransformUtils
{
    public static Transform FindChildDeep(this Transform parent, string name)
    {
        Transform result = parent.Find(name);

        if (result != null) return result;

        for (int i = 0; i < parent.childCount; i++)
        {
            Transform child = parent.GetChild(i);
            result = child.FindChildDeep(name);

            if (result != null) return result;
        }

        return null;
    }
}