﻿using ArchNet.Library.Enum;
using ArchNet.Library.Image;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ArchNet.Extension.Sprite
{
    /// <summary>
    /// [EXTENSION] - [ARCH NET] - [SPRITE] Extension sprite
    /// author : LOUIS PAKEL
    /// </summary>s
    [System.Serializable]
    public class SpriteExtension : MonoBehaviour
    {
        #region Publics Fields

        public enum keyType
        {
            ENUM,
            INT
        }

        public EnumLibrary _enumLibrary;

        public keyType _keyType;

        public ImageLibrary _imageLibrary;

        public string _enumChoice;

        public int _enumIndex = 0;

        public UnityEngine.Sprite _sprite;

        #endregion

        #region Public Methods

        /// <summary>
        /// Description : Load Sprite from enum choice
        /// </summary>
        public void LoadSprite()
        {
            _sprite = _imageLibrary.GetSprite(_enumIndex);
        }

        public Type GetEnum()
        {
            return _enumLibrary.GetEnum(_imageLibrary);
        }

        public string GetEnumName()
        {
            return _enumLibrary.GetEnumName(_enumIndex);
        }


        public void OnValidate()
        {
            if (_sprite != null)
            {
                gameObject.GetComponent<Image>().sprite = _sprite;
            }
        }

        public void Start()
        {
            if (_sprite != null)
            {
                gameObject.GetComponent<Image>().sprite = _sprite;
            }
        }

        #endregion
    }
}
