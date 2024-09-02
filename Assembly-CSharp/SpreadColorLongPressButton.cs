// Decompiled with JetBrains decompiler
// Type: SpreadColorLongPressButton
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class SpreadColorLongPressButton : LongPressButton
{
  private UISprite btnSprite;
  private UIWidget[] objs;

  protected override void OnInit()
  {
    base.OnInit();
    this.btnSprite = this.mWidget as UISprite;
    this.objs = this.gameObject.GetComponentsInChildren<UIWidget>(true);
  }

  public void SetTweenColor(bool instant, float duration, Color color)
  {
    foreach (UIRect uiRect in this.objs)
    {
      TweenColor tweenColor = TweenColor.Begin(uiRect.cachedGameObject, duration, color);
      if (instant && (Object) tweenColor != (Object) null || (double) duration <= 0.0)
      {
        tweenColor.value = tweenColor.to;
        tweenColor.enabled = false;
      }
    }
  }

  protected override void SetState(UIButtonColor.State state, bool instant)
  {
    int mState = (int) this.mState;
    base.SetState(state, instant);
    int num = (int) state;
    if (mState == num)
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
