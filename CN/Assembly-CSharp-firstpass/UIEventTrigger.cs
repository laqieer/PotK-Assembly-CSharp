// Decompiled with JetBrains decompiler
// Type: UIEventTrigger
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FC6F22C0-326E-48ED-B5EE-59590337E752
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp-firstpass.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
[AddComponentMenu("NGUI/Interaction/Event Trigger")]
public class UIEventTrigger : MonoBehaviour
{
  public static UIEventTrigger current;
  public List<EventDelegate> onHoverOver = new List<EventDelegate>();
  public List<EventDelegate> onHoverOut = new List<EventDelegate>();
  public List<EventDelegate> onPress = new List<EventDelegate>();
  public List<EventDelegate> onRelease = new List<EventDelegate>();
  public List<EventDelegate> onSelect = new List<EventDelegate>();
  public List<EventDelegate> onDeselect = new List<EventDelegate>();
  public List<EventDelegate> onClick = new List<EventDelegate>();
  public List<EventDelegate> onDoubleClick = new List<EventDelegate>();

  private void OnHover(bool isOver)
  {
    UIEventTrigger.current = this;
    if (isOver)
      EventDelegate.Execute(this.onHoverOver);
    else
      EventDelegate.Execute(this.onHoverOut);
    UIEventTrigger.current = (UIEventTrigger) null;
  }

  private void OnPress(bool pressed)
  {
    UIEventTrigger.current = this;
    if (pressed)
      EventDelegate.Execute(this.onPress);
    else
      EventDelegate.Execute(this.onRelease);
    UIEventTrigger.current = (UIEventTrigger) null;
  }

  private void OnSelect(bool selected)
  {
    UIEventTrigger.current = this;
    if (selected)
      EventDelegate.Execute(this.onSelect);
    else
      EventDelegate.Execute(this.onDeselect);
    UIEventTrigger.current = (UIEventTrigger) null;
  }

  private void OnClick()
  {
    UIEventTrigger.current = this;
    EventDelegate.Execute(this.onClick);
    UIEventTrigger.current = (UIEventTrigger) null;
  }

  private void OnDoubleClick()
  {
    UIEventTrigger.current = this;
    EventDelegate.Execute(this.onDoubleClick);
    UIEventTrigger.current = (UIEventTrigger) null;
  }
}
