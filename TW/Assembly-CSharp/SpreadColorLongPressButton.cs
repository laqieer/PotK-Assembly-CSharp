// Decompiled with JetBrains decompiler
// Type: SpreadColorLongPressButton
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class SpreadColorLongPressButton : LongPressButton
{
  private UISprite btnSprite;
  private UIWidget[] objs;

  protected override void OnInit()
  {
    base.OnInit();
    this.btnSprite = this.mWidget as UISprite;
    this.objs = ((Component) this).gameObject.GetComponentsInChildren<UIWidget>(true);
  }

  public void SetTweenColor(bool instant, float duration, Color color)
  {
    foreach (UIRect uiRect in this.objs)
    {
      TweenColor tweenColor = TweenColor.Begin(uiRect.cachedGameObject, duration, color);
      if (instant && Object.op_Inequality((Object) tweenColor, (Object) null) || (double) duration <= 0.0)
      {
        tweenColor.value = tweenColor.to;
        ((Behaviour) tweenColor).enabled = false;
      }
    }
  }

  protected override void SetState(UIButtonColor.State state, bool instant)
  {
    UIButtonColor.State mState = this.mState;
    base.SetState(state, instant);
    if (mState == state)
      return;
    Color color = this.mColor;
    switch (state)
    {
      case UIButtonColor.State.Hover:
        color = this.hover;
        break;
      case UIButtonColor.State.Pressed:
        color = this.pressed;
        break;
      case UIButtonColor.State.Disabled:
        color = this.disabledColor;
        break;
    }
    this.SetTweenColor(instant, this.duration, color);
  }

  public void SetColor(Color color)
  {
    this.defaultColor = color;
    this.SetTweenColor(false, 0.0f, color);
  }
}
