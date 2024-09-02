﻿// Decompiled with JetBrains decompiler
// Type: SpriteNumberSelectDirect
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
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
    if (!Object.op_Equality((Object) this.sprite, (Object) null))
      return;
    this.sprite = ((Component) this).gameObject.GetComponent<UISprite>();
  }

  public void setNumber(int n, Color col)
  {
    this.initialize();
    this.sprite.spriteName = this.spritePrefix + (object) n + this.spriteExt;
    UISpriteData atlasSprite = this.sprite.GetAtlasSprite();
    this.sprite.width = atlasSprite.width;
    this.sprite.height = atlasSprite.height;
    this.sprite.color = col;
  }
}
