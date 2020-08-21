/*
    A tool to migrate serialized data from monobehaviours to scriptable objects    
    Author: Ģirts Ķesteris 2020
*/

using UnityEngine;
using UnityEditor;
using System.Reflection;

public class MigrateSerializedData : EditorWindow
{
    [MenuItem("Window/Tools/MigrateSerializedData")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(MigrateSerializedData));
    }

    private MonoBehaviour monoBehaviour;
    private ScriptableObject scriptableObject;

    void OnGUI()
    {
        GUILayout.Label("SerializedDataMigrationTool 3k", EditorStyles.boldLabel);

        monoBehaviour = EditorGUILayout.ObjectField("MonoBehaviour:", monoBehaviour, typeof(MonoBehaviour), true) as MonoBehaviour;
        scriptableObject = EditorGUILayout.ObjectField("ScriptableObject:", scriptableObject, typeof(ScriptableObject), false) as ScriptableObject;

        if (GUILayout.Button("Migrate!")) Migrate();
    }

    public void Migrate()
    {
        SerializedObject serObj = new SerializedObject(monoBehaviour);

        SerializedProperty prop = serObj.GetIterator();

        while (prop.NextVisible(true))
        {
            FieldInfo monoBehaviourFieldInfo = monoBehaviour.GetType().GetField(prop.name, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

            if (monoBehaviourFieldInfo != null)
            {
                Debug.LogFormat("Migrating {0} ...", monoBehaviourFieldInfo);

                FieldInfo scriptableObjectFieldInfo = scriptableObject.GetType().GetField(prop.name, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

                if (scriptableObjectFieldInfo == null)
                {
                    Debug.LogWarningFormat("There was no field {0}. Continuing...", monoBehaviourFieldInfo);
                }
                else
                {
                    object data = monoBehaviourFieldInfo.GetValue(monoBehaviour);
                    Debug.LogFormat("Setting data {0} to scriptable object {1}", data, scriptableObject);
                    scriptableObjectFieldInfo.SetValue(scriptableObject, data);
                }

            }
        }

        EditorUtility.SetDirty(scriptableObject);
    }

}