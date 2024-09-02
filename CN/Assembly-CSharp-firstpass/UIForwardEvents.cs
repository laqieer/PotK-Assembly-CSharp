﻿// Decompiled with JetBrains decompiler
// Type: UIForwardEvents
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FC6F22C0-326E-48ED-B5EE-59590337E752
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp-firstpass.dll

using UnityEngine;

#nullable disable
[AddComponentMenu("NGUI/Interaction/Forward Events (Legacy)")]
public class UIForwardEvents : MonoBehaviour
{
  public GameObject target;
  public bool onHover;
  public bool onPress;
  public bool onClick;
  public bool onDoubleClick;
  public bool onSelect;
  public bool onDrag;
  public bool onDrop;
  public bool onSubmit;
  public bool onScroll;

  private void OnHover(bool isOver)
  {
    if (!this.onHover || !Object.op_Inequality((Object) this.target, (Object) null))
      return;
    this.target.SendMessage(nameof (OnHover), (object) isOver, (SendMessageOptions) 1);
  }

  private void OnPress(bool pressed)
  {
    if (!this.onPress || !Object.op_Inequality((Object) this.target, (Object) null))
      return;
    this.target.SendMessage(nameof (OnPress), (object) pressed, (SendMessageOptions) 1);
  }

  private void OnClick()
  {
    if (!this.onClick || !Object.op_Inequality((Object) this.target, (Object) null))
      return;
    this.target.SendMessage(nameof (OnClick), (SendMessageOptions) 1);
  }

  private void OnDoubleClick()
  {
    if (!this.onDoubleClick || !Object.op_Inequality((Object) this.target, (Object) null))
      return;
    this.target.SendMessage(nameof (OnDoubleClick), (SendMessageOptions) 1);
  }

  private void OnSelect(bool selected)
  {
    if (!this.onSelect || !Object.op_Inequality((Object) this.target, (Object) null))
      return;
    this.target.SendMessage(nameof (OnSelect), (object) selected, (SendMessageOptions) 1);
  }

  private void OnDrag(Vector2 delta)
  {
    if (!this.onDrag || !Object.op_Inequality((Object) this.target, (Object) null))
      return;
    this.target.SendMessage(nameof (OnDrag), (object) delta, (SendMessageOptions) 1);
  }

  private void OnDrop(GameObject go)
  {
    if (!this.onDrop || !Object.op_Inequality((Object) this.target, (Object) null))
      return;
    this.target.SendMessage(nameof (OnDrop), (object) go, (SendMessageOptions) 1);
  }

  private void OnSubmit()
  {
    if (!this.onSubmit || !Object.op_Inequality((Object) this.target, (Object) null))
      return;
    this.target.SendMessage(nameof (OnSubmit), (SendMessageOptions) 1);
  }

  private void OnScroll(float delta)
  {
    if (!this.onScroll || !Object.op_Inequality((Object) this.target, (Object) null))
      return;
    this.target.SendMessage(nameof (OnScroll), (object) delta, (SendMessageOptions) 1);
  }
}
