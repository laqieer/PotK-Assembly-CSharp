// Decompiled with JetBrains decompiler
// Type: SpriteNumberSelectDirect
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class SpriteNumberSelectDirect : MonoBehaviour
{
  [SerializeField]
  private string spritePrefix = "slc_SetupTime";
  [SerializeField]
  private string spriteExt = ".png__GUI__battleUI_01__battleUI_01_prefab";
  private UISprite sprite;

  private void Awake() => this.initialize();

  private void initialize()
  {
    if (!((Object) this.sprite == (Object) null))
      return;
    this.sprite = this.gameObject.GetComponent<UISprite>();
  }

  public void setNumber(int n) => this.setName(n.ToString());

  public void setName(string name)
  {
    this.initialize();
    this.setSprite(name);
  }

  public void setNumber(int n, Color col)
  {
    this.initialize();
    this.setName(n.ToString(), col);
  }

  public void setName(string name, Color col)
  {
    this.initialize();
    this.setSprite(name);
    this.sprite.color = col;
  }

  private void setSprite(string name)
  {
    this.sprite.spriteName = string.Format("{0}{1}{2}", (object) this.spritePrefix, (object) name, (object) this.spriteExt);
    UISpriteData atlasSprite = this.sprite.GetAtlasSprite();
    this.sprite.width = atlasSprite.width;
    this.sprite.height = atlasSprite.height;
  }
}
