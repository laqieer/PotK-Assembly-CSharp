// Decompiled with JetBrains decompiler
// Type: SeaDateSpotUIButton
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class SeaDateSpotUIButton : UIButton
{
  protected override void SetState(UIButtonColor.State state, bool immediate)
  {
    base.SetState(state, immediate);
    if (state != UIButtonColor.State.Pressed)
      this.playTweenScale(false);
    else
      this.playTweenScale(true);
  }

  protected void playTweenScale(bool isPressed)
  {
    TweenScale componentInChildren = this.GetComponentInChildren<TweenScale>();
    if (!((Object) componentInChildren != (Object) null))
      return;
    if (isPressed)
      componentInChildren.PlayForward();
    else
      componentInChildren.ResetToBeginning();
  }
}
