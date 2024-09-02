// Decompiled with JetBrains decompiler
// Type: LongPressButton
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongPressButton : UIButton
{
  public List<EventDelegate> onLongPress = new List<EventDelegate>();
  public Func<IEnumerator> onLongPressLoop;
  public float longPressDuration = 1f;
  private bool longPressed;
  private bool isActiveLongPress_;

  private void startLongPress()
  {
    this.isActiveLongPress_ = true;
    this.StartCoroutine("DoLongPress");
    this.longPressed = false;
  }

  private void stopLongPress()
  {
    if (!this.isActiveLongPress_)
      return;
    this.StopCoroutine("DoLongPress");
    this.isActiveLongPress_ = false;
  }

  private IEnumerator DoLongPress()
  {
    LongPressButton longPressButton = this;
    yield return (object) new WaitForSeconds(longPressButton.longPressDuration);
    longPressButton.longPressed = true;
    UIButton.current = (UIButton) longPressButton;
    EventDelegate.Execute(longPressButton.onLongPress);
    if (longPressButton.onLongPressLoop != null)
    {
      IEnumerator e = longPressButton.onLongPressLoop();
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
    }
    UIButton.current = (UIButton) null;
    longPressButton.isActiveLongPress_ = false;
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
    if (this.longPressed)
      return;
    base.OnClick();
  }

  protected override void OnDisable()
  {
    base.OnDisable();
    this.stopLongPress();
  }
}
