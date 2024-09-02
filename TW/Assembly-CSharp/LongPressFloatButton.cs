// Decompiled with JetBrains decompiler
// Type: LongPressFloatButton
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

#nullable disable
public class LongPressFloatButton : FloatButton
{
  public List<EventDelegate> onLongPress_ = new List<EventDelegate>();
  public float longPressDuration_ = 1f;
  private bool isActiveLongPress_;
  private bool longPressed_;

  private void startLongPress()
  {
    this.isActiveLongPress_ = true;
    this.StartCoroutine("DoLongPress");
    this.longPressed_ = false;
  }

  private void stopLongPress()
  {
    if (!this.isActiveLongPress_)
      return;
    this.StopCoroutine("DoLongPress");
    this.isActiveLongPress_ = false;
  }

  [DebuggerHidden]
  private IEnumerator DoLongPress()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new LongPressFloatButton.\u003CDoLongPress\u003Ec__IteratorAD9()
    {
      \u003C\u003Ef__this = this
    };
  }

  protected void OnDragStart() => this.stopLongPress();

  protected override void OnPress(bool isPressed)
  {
    base.OnPress(isPressed);
    if (!this.isEnabled)
      return;
    if (isPressed)
      this.startLongPress();
    else
      this.stopLongPress();
  }

  protected override void OnClick()
  {
    if (this.longPressed_)
      return;
    base.OnClick();
  }

  protected override void OnDisable()
  {
    base.OnDisable();
    this.stopLongPress();
  }
}
