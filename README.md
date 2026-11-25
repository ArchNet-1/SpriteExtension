<p align="center">
  <a href="https://archnet-plateform.fr"><img src="https://archnet-plateform.fr/ArchNetLogoWithBck.png" alt="ArchNet" width="240"></a>
</p>

# ArchNet · Sprite Extension

Shows a sprite from an Image Library key on a UI Image or a SpriteRenderer, so icons are picked by name.

- Unity **6000.0** or newer · Needs `com.archnet.library.image`, `com.archnet.library.core` (the ArchNet installer adds them for you).
- Part of [ArchNet](https://archnet-plateform.fr), free and open-source Unity packages

## Install

*Window > Package Manager > + > Install package from git URL…*

```
https://github.com/ArchNet-1/SpriteExtension.git
```

## Use

Add **ArchNet > Library Sprite**, pick the Image Library and the sprite. From code: `GetComponent<SpriteExtension>().Key = (int)Icon.Sword;`

## License

MIT, see [LICENSE.md](LICENSE.md).
