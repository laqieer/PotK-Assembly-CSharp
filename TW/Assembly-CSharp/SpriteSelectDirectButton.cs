// Decompiled with JetBrains decompiler
// Type: SpriteSelectDirectButton
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
[RequireComponent(typeof (UISprite))]
public class SpriteSelectDirectButton : SpriteSelectDirect
{
  [SerializeField]
  private UIButton button;

  public override void SetSpriteName<T>(T n)
  {
    base.SetSpriteName<T>(n);
    this.button.normalSprite = this.spriteName;
    this.button.pressedSprite = this.spriteName;
  }
}
