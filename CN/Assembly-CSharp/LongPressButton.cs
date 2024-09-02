// Decompiled with JetBrains decompiler
// Type: LongPressButton
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

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
    return (IEnumerator) new LongPressButton.\u003CDoLongPress\u003Ec__Iterator9FE()
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
      Debug.Log((object) "Pressed");
      this.StartCoroutine("DoLongPress");
      this.longPressed = false;
    }
    else
    {
      Debug.Log((object) "Released");
      this.StopCoroutine("DoLongPress");
    }
  }

  protected override void OnClick()
  {
    if (this.longPressed)
      return;
    base.OnClick();
  }
}
