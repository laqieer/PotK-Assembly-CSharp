// Decompiled with JetBrains decompiler
// Type: CommonElementIcon
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using MasterDataTable;
using UnityEngine;

public class CommonElementIcon : MonoBehaviour
{
  public UI2DSprite iconSprite;
  [SerializeField]
  private UnityEngine.Sprite[] icons;
  private const int DEPTH = 10000;

  public UnityEngine.Sprite getIcon(CommonElement element)
  {
    int index = (int) (element - 1);
    return index < 0 || index >= this.icons.Length ? (UnityEngine.Sprite) null : this.icons[index];
  }

  public void Init(CommonElement element, bool resize = false)
  {
    this.iconSprite.sprite2D = this.getIcon(element);
    if (resize && (Object) this.iconSprite.sprite2D != (Object) null)
      this.iconSprite.SetDimensions(this.iconSprite.sprite2D.texture.width, this.iconSprite.sprite2D.texture.height);
    this.iconSprite.depth = 10000;
  }

  public void SetDimensions(int width, int height) => this.GetComponent<UIWidget>().SetDimensions(width, height);
}
