// Decompiled with JetBrains decompiler
// Type: PressSpriteChangeButton
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class PressSpriteChangeButton : UIButton
{
  [SerializeField]
  public UnityEngine.Sprite idle;
  [SerializeField]
  public UnityEngine.Sprite press;

  protected override void OnPress(bool isPressed)
  {
    base.OnPress(isPressed);
    if (!this.enabled)
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
