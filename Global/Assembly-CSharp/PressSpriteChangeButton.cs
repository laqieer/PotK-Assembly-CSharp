// Decompiled with JetBrains decompiler
// Type: PressSpriteChangeButton
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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
