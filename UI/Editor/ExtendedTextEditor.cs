using UnityEditor;
using UnityEngine;

namespace Sacristan.Utils.UI
{
    [CustomEditor(typeof(ExtendedText))]
    public class ExtendedTextEditor : Editor
    {
        private ExtendedText myTarget;

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            myTarget = (ExtendedText)target;
            myTarget.UpdateUnderline();
        }
    }
}
