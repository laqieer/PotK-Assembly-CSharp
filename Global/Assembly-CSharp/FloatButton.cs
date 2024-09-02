// Decompiled with JetBrains decompiler
// Type: FloatButton
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System.Collections.Generic;

#nullable disable
public class FloatButton : UIButton
{
  public List<EventDelegate> onOver = new List<EventDelegate>();
  public List<EventDelegate> onOut = new List<EventDelegate>();
  protected bool isActive;

  protected override void OnPress(bool isPressed)
  {
    base.OnPress(isPressed);
    if (isPressed)
      this.OnOver();
    else
      this.OnOut();
  }

  protected override void OnDragOver()
  {
    base.OnDragOver();
    this.OnOver();
  }

  protected override void OnDragOut()
  {
    base.OnDragOut();
    this.OnOut();
  }

  protected virtual void doExecute(List<EventDelegate> events, bool active)
  {
    if (!this.isEnabled || this.isActive != !active)
      return;
    UIButton.current = (UIButton) this;
    EventDelegate.Execute(events);
    UIButton.current = (UIButton) null;
    this.isActive = active;
  }

  protected virtual void OnOver() => this.doExecute(this.onOver, true);

  protected virtual void OnOut() => this.doExecute(this.onOut, false);
}
