// ArchNet · Sprite Extension
// Shows a sprite from an Image Library key on a UI Image or a SpriteRenderer, so icons are
// picked by name (Icon.Sword) and swapped in one place.
// Docs: https://archnet-plateform.fr/#SpriteExtension

using ArchNet.Library;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace ArchNet.Extension
{
    [ExecuteAlways]
    [AddComponentMenu("ArchNet/Library Sprite")]
    public class SpriteExtension : MonoBehaviour
    {
        [FormerlySerializedAs("_imageLibrary")]
        [SerializeField] ImageLibrary _library;
        [FormerlySerializedAs("_enumIndex")]
        [SerializeField] int _key;

        public ImageLibrary Library { get => _library; set { _library = value; Apply(); } }

        /// <summary>The library key of the sprite; setting it swaps the sprite.</summary>
        public int Key { get => _key; set { _key = value; Apply(); } }

        /// <summary>Shows the sprite of the current key on the Image or SpriteRenderer on this object.</summary>
        public void Apply()
        {
            if (_library == null || !_library.TryGetSprite(_key, out Sprite sprite)) return;
            if (TryGetComponent(out Image image)) image.sprite = sprite;
            else if (TryGetComponent(out SpriteRenderer spriteRenderer)) spriteRenderer.sprite = sprite;
        }

        void OnEnable() => Apply();
        void OnValidate() => Apply();
    }
}
