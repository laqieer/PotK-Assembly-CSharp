// Decompiled with JetBrains decompiler
// Type: PressSpriteChangeButton
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class PressSpriteChangeButton : UIButton
{
  [SerializeField]
  public Sprite idle;
  [SerializeField]
  public Sprite press;

  protected override void OnPress(bool isPressed)
  {
    base.OnPress(isPressed);
    if (!((Behaviour) this).enabled)
      return;
    UI2DSprite component = this.tweenTarget.GetComponent<UI2DSprite>();
    if (isPressed)
    {
      component.sprite2D = this.press;
    }
    else
    {
      component.sprite2D = this.idle;
      Singleton<NGSoundManager>.GetInstance().PlaySe("SE_1002");
    }
  }
}
