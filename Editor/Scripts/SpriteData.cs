using UnityEngine;
using UnityEngine.UI;

namespace ArchNet.Extension.Sprite
{
    /// <summary>
    /// Description : Sprite data to store non persistent 
    /// </summary>
    public class SpriteData : MonoBehaviour
    {
        #region Private Field

        private SpriteExtension _spriteExtension = null;

        private Image _image = null;

        #endregion

        #region Private Fields

        private int _index = 0;

        #endregion

        #region Unity Methods

        private void Start()
        {
            OnValidate();
        }

        public void OnValidate()
        {
            if(IsInit() == false)
            {
                Init();
            }

            if (IsUpdate() == false)
            {
                UpdateDatas();
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Description : init the sprite data
        /// </summary>
        /// <returns></returns>
        private void Init()
        {
            if (gameObject.GetComponent<SpriteExtension>() == null)
            {
                gameObject.AddComponent<SpriteExtension>();
            }

            if (gameObject.GetComponent<Image>() == null)
            {
                gameObject.AddComponent<Image>();
            }

            _image = gameObject.GetComponent<Image>();

            // Set SpriteExtension
            _spriteExtension = gameObject.GetComponent<SpriteExtension>();
        }


        /// <summary>
        /// Description : Update Image source
        /// </summary>
        private void UpdateDatas()
        {
            _spriteExtension = gameObject.GetComponent<SpriteExtension>();

            _index = _spriteExtension._enumIndex;

            _image.sprite = _spriteExtension._imageLibrary.GetSprite(_index);
        }

        /// <summary>
        /// Description : Sprite Data need update
        /// </summary>
        /// <returns></returns>
        private bool IsUpdate()
        {
            bool lResult = true;

            if (_spriteExtension._enumIndex != _index)
            {
                lResult = false;
            }

            return lResult;
        }


        /// <summary>
        /// Description : check if the sprite data is init
        /// </summary>
        /// <returns></returns>
        private bool IsInit()
        {
            bool lResult = true;

            if(_spriteExtension == null || _image == null)
            {
                lResult = false;
            }

            return lResult;
        }

        #endregion
    }
}
