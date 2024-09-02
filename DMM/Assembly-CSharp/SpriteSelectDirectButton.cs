// Decompiled with JetBrains decompiler
// Type: SpriteSelectDirectButton
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

[RequireComponent(typeof (UISprite))]
public class SpriteSelectDirectButton : SpriteSelectDirect
{
  [SerializeField]
  private UIButton button;

  public override void SetSpriteName<T>(T n, bool resizeTarget = true)
  {
    base.SetSpriteName<T>(n, resizeTarget);
    this.button.normalSprite = this.spriteName;
    this.button.pressedSprite = this.spriteName;
  }
}
