// Decompiled with JetBrains decompiler
// Type: UIButtonMessage
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FC6F22C0-326E-48ED-B5EE-59590337E752
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp-firstpass.dll

using UnityEngine;

#nullable disable
[AddComponentMenu("NGUI/Interaction/Button Message (Legacy)")]
public class UIButtonMessage : MonoBehaviour
{
  public GameObject target;
  public string functionName;
  public UIButtonMessage.Trigger trigger;
  public bool includeChildren;
  private bool mStarted;

  private void Start() => this.mStarted = true;

  private void OnEnable()
  {
    if (!this.mStarted)
      return;
    this.OnHover(UICamera.IsHighlighted(((Component) this).gameObject));
  }

  private void OnHover(bool isOver)
  {
    if (!((Behaviour) this).enabled || (!isOver || this.trigger != UIButtonMessage.Trigger.OnMouseOver) && (isOver || this.trigger != UIButtonMessage.Trigger.OnMouseOut))
      return;
    this.Send();
  }

  private void OnPress(bool isPressed)
  {
    if (!((Behaviour) this).enabled || (!isPressed || this.trigger != UIButtonMessage.Trigger.OnPress) && (isPressed || this.trigger != UIButtonMessage.Trigger.OnRelease))
      return;
    this.Send();
  }

  private void OnSelect(bool isSelected)
  {
    if (!((Behaviour) this).enabled || isSelected && UICamera.currentScheme != UICamera.ControlScheme.Controller)
      return;
    this.OnHover(isSelected);
  }

  private void OnClick()
  {
    if (!((Behaviour) this).enabled || this.trigger != UIButtonMessage.Trigger.OnClick)
      return;
    this.Send();
  }

  private void OnDoubleClick()
  {
    if (!((Behaviour) this).enabled || this.trigger != UIButtonMessage.Trigger.OnDoubleClick)
      return;
    this.Send();
  }

  private void Send()
  {
    if (string.IsNullOrEmpty(this.functionName))
      return;
    if (Object.op_Equality((Object) this.target, (Object) null))
      this.target = ((Component) this).gameObject;
    if (this.includeChildren)
    {
      Transform[] componentsInChildren = this.target.GetComponentsInChildren<Transform>();
      int index = 0;
      for (int length = componentsInChildren.Length; index < length; ++index)
        ((Component) componentsInChildren[index]).gameObject.SendMessage(this.functionName, (object) ((Component) this).gameObject, (SendMessageOptions) 1);
    }
    else
      this.target.SendMessage(this.functionName, (object) ((Component) this).gameObject, (SendMessageOptions) 1);
  }

  public enum Trigger
  {
    OnClick,
    OnMouseOver,
    OnMouseOut,
    OnPress,
    OnRelease,
    OnDoubleClick,
  }
}
