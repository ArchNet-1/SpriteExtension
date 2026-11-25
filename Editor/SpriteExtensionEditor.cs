// ArchNet · Sprite Extension — inspector
// Shows the library's keys as a dropdown (enum names) and swaps the sprite right away.
// Docs: https://archnet-plateform.fr/#SpriteExtension

using ArchNet.Library;
using ArchNet.Library.Editor;
using UnityEditor;
using UnityEngine;

namespace ArchNet.Extension.Editor
{
    [CustomEditor(typeof(SpriteExtension))]
    public class SpriteExtensionEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            SerializedProperty library = serializedObject.FindProperty("_library");
            SerializedProperty key = serializedObject.FindProperty("_key");

            EditorGUILayout.PropertyField(library, new GUIContent("Image Library"));
            if (library.objectReferenceValue is ImageLibrary imageLibrary)
            {
                key.intValue = KeyGUI.KeyField(new GUIContent("Sprite"), key.intValue, imageLibrary.EnumType);
                if (!imageLibrary.TryGetSprite(key.intValue, out _))
                    EditorGUILayout.HelpBox($"The library has no sprite for key {key.intValue}.", MessageType.Warning);
            }

            if (serializedObject.ApplyModifiedProperties()) ((SpriteExtension)target).Apply();
        }
    }
}
