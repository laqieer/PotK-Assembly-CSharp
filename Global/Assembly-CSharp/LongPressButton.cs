// Decompiled with JetBrains decompiler
// Type: LongPressButton
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

#nullable disable
public class LongPressButton : UIButton
{
  public List<EventDelegate> onLongPress = new List<EventDelegate>();
  public Func<IEnumerator> onLongPressLoop;
  public float longPressDuration = 1f;
  private bool longPressed;

  [DebuggerHidden]
  private IEnumerator DoLongPress()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new LongPressButton.\u003CDoLongPress\u003Ec__Iterator883()
    {
      \u003C\u003Ef__this = this
    };
  }

  protected void OnDragStart() => this.StopCoroutine("DoLongPress");

  protected override void OnPress(bool isPressed)
  {
    base.OnPress(isPressed);
    if (isPressed)
    {
      this.StartCoroutine("DoLongPress");
      this.longPressed = false;
    }
    else
      this.StopCoroutine("DoLongPress");
  }

  protected override void OnClick()
  {
    if (this.longPressed)
      return;
    base.OnClick();
  }
}
