using ArchNet.Extension.Enum;
using ArchNet.Library.Enum;
using ArchNet.Library.Image;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static ArchNet.Extension.Sprite.SpriteExtension;

namespace ArchNet.Extension.Sprite.Editor
{
    /// <summary>
    /// Description : Load a sprite from an image Library inside a Image
    /// @Author : Louis PAKEL
    /// </summary>
    [CustomEditor(typeof(SpriteExtension))]
    public class SpriteExtensionEditor : UnityEditor.Editor
    {
        #region Private Fields
        private List<string> _keyChoices = new List<string>();
        private List<string> _enumChoices = new List<string>();

        private SpriteExtension _manager = null;

        private GUIStyle _warningInfos = null;

        private SerializedProperty _enumLibrary = null;
        private SerializedProperty _imageLibrary = null;
        private SerializedProperty _keyType = null;
        private SerializedProperty _enumIndex = null;
        private SerializedProperty _enumChoice = null;
        private SerializedProperty _sprite = null;
        #endregion

        #region Unity Methods
        private void OnEnable()
        {
            _warningInfos = new GUIStyle();
            _warningInfos.normal.textColor = Color.red;
            _warningInfos.fontStyle = FontStyle.Bold;

            _keyChoices.Add("Enum");
            _keyChoices.Add("Int");

            _manager = target as SpriteExtension;
        }

        private void OnDisable()
        {
            _manager = null;
            _warningInfos = null;
        }

      

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.LabelField("SPRITE EXTENSION");
            EditorGUILayout.LabelField("This extension can allow to get a sprite from an image Library");

            _enumLibrary = serializedObject.FindProperty("_enumLibrary");
            _imageLibrary = serializedObject.FindProperty("_imageLibrary");
            _keyType = serializedObject.FindProperty("_keyType");
            _enumIndex = serializedObject.FindProperty("_enumIndex");
            _enumChoice = serializedObject.FindProperty("_enumChoice");
            _sprite = serializedObject.FindProperty("_sprite");

            EditorGUILayout.Space(10);

            DisplaySpriteData();

            // Sprite Data is set
            if (true == IsConditionsOK())
            {
                EditorGUILayout.BeginHorizontal();

                DisplayEnum();

                EditorGUILayout.EndHorizontal();
            }

            EditorGUILayout.Space(10);

            // Apply modifications
            serializedObject.ApplyModifiedProperties();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Description : Display Sprite Data Values
        /// </summary>
        private void DisplaySpriteData()
        {
            EditorGUILayout.BeginHorizontal();

            _keyType.intValue = EditorGUILayout.Popup(_keyType.intValue, _keyChoices.ToArray());
            _manager._keyType = (keyType)_keyType.intValue;

            EditorGUILayout.Space(15);
            EditorGUILayout.EndHorizontal();

            if (_manager._keyType == keyType.ENUM)
            {
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField("Enum Library");

                _enumLibrary.objectReferenceValue = (EnumLibrary)EditorGUILayout.ObjectField(_enumLibrary.objectReferenceValue, typeof(EnumLibrary), true);

                EditorGUILayout.EndHorizontal();
            }

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Image Library");

            _imageLibrary.objectReferenceValue = (ImageLibrary)EditorGUILayout.ObjectField(_imageLibrary.objectReferenceValue, typeof(ImageLibrary), true);

            EditorGUILayout.EndHorizontal();
            EditorGUILayout.Space(5);


            _manager._enumLibrary = (EnumLibrary)_enumLibrary.objectReferenceValue;
            _manager._imageLibrary = (ImageLibrary)_imageLibrary.objectReferenceValue;
        }

        /// <summary>
        /// Description : Display Enum Value
        /// </summary>
        private void DisplayEnum()
        {
            EditorGUILayout.BeginVertical();
            EditorGUILayout.Space(10);

            if (_manager._keyType == keyType.INT)
            {
                EditorGUILayout.LabelField("Int Value");
                EditorGUILayout.Space(5);

                _enumIndex.intValue = EditorGUILayout.IntField(_manager._enumIndex);             
            }
            else if (_manager._keyType == keyType.ENUM)
            {
                EditorGUILayout.LabelField("Enum Value");
                EditorGUILayout.Space(5);

                _enumChoice.stringValue = _manager.GetEnumName();

                if (_enumChoice.stringValue == "")
                {
                    return;
                }

                _enumChoices = EnumExtension.GetEnumKeys(_enumChoice.stringValue);

                _enumIndex.intValue = EditorGUILayout.Popup(_manager._enumIndex, _enumChoices.ToArray());
            }

            _manager._enumIndex = _enumIndex.intValue;

            if (_manager._keyType == keyType.ENUM)
            {
                // Set enum string value
                _manager._enumChoice = _enumChoices[_enumIndex.intValue];
            }

            EditorGUILayout.EndVertical();

            EditorGUILayout.Space(5);

            _manager.LoadSprite();
        }



        /// <summary>
        /// Description : check if every condition are respected
        /// </summary>
        /// <returns></returns>
        private bool IsConditionsOK()
        {
            if (_imageLibrary == null ||( _enumLibrary == null && _manager._keyType == keyType.ENUM))
            {
                return false;
            }

            if (_imageLibrary.objectReferenceValue == null || (_enumLibrary.objectReferenceValue == null && _manager._keyType == keyType.ENUM))
            {
                return false;
            }

            if (_manager._imageLibrary == null || ( _manager._enumLibrary == null && _manager._keyType == keyType.ENUM))
            {
                return false;
            }

            return true;
        }


        #endregion

    }
}
