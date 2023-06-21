using Windows;
using UI.API;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(WindowsManager))]
    public class WindowObjectsCollector : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            DrawDefaultInspector();

            WindowsManager parentObject = (WindowsManager)target;

            if (GUILayout.Button("Collect All Windows"))
            {
                AWindow[] childWindows = parentObject.GetComponentsInChildren<AWindow>(true);
                RefreshArray(childWindows);
            }
            if (GUI.changed)
                EditorUtility.SetDirty(parentObject);
            serializedObject.ApplyModifiedProperties();
        }

        private void RefreshArray(AWindow[] array)
        {
            var mapProperty = serializedObject.FindProperty("_windows");
            mapProperty.ClearArray();
            
            foreach (var item in array)
            {
                mapProperty.InsertArrayElementAtIndex(0);
                var element = mapProperty.GetArrayElementAtIndex(0);
                element.objectReferenceValue = item;
            }
        }
    }
}