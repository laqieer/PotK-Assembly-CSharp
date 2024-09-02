// Decompiled with JetBrains decompiler
// Type: UIKeyBinding
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FC6F22C0-326E-48ED-B5EE-59590337E752
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp-firstpass.dll

using UnityEngine;

#nullable disable
[AddComponentMenu("Game/UI/Key Binding")]
public class UIKeyBinding : MonoBehaviour
{
  public KeyCode keyCode;
  public UIKeyBinding.Modifier modifier;
  public UIKeyBinding.Action action;
  private bool mIgnoreUp;
  private bool mIsInput;

  private void Start()
  {
    UIInput component = ((Component) this).GetComponent<UIInput>();
    this.mIsInput = Object.op_Inequality((Object) component, (Object) null);
    if (!Object.op_Inequality((Object) component, (Object) null))
      return;
    EventDelegate.Add(component.onSubmit, new EventDelegate.Callback(this.OnSubmit));
  }

  private void OnSubmit()
  {
    if (UICamera.currentKey != this.keyCode || !this.IsModifierActive())
      return;
    this.mIgnoreUp = true;
  }

  private bool IsModifierActive()
  {
    if (this.modifier == UIKeyBinding.Modifier.None)
      return true;
    if (this.modifier == UIKeyBinding.Modifier.Alt)
    {
      if (Input.GetKey((KeyCode) 308) || Input.GetKey((KeyCode) 307))
        return true;
    }
    else if (this.modifier == UIKeyBinding.Modifier.Control)
    {
      if (Input.GetKey((KeyCode) 306) || Input.GetKey((KeyCode) 305))
        return true;
    }
    else if (this.modifier == UIKeyBinding.Modifier.Shift && (Input.GetKey((KeyCode) 304) || Input.GetKey((KeyCode) 303)))
      return true;
    return false;
  }

  private void Update()
  {
    if (this.keyCode == null || !this.IsModifierActive())
      return;
    if (this.action == UIKeyBinding.Action.PressAndClick)
    {
      if (UICamera.inputHasFocus)
        return;
      UICamera.currentTouch = UICamera.controller;
      UICamera.currentScheme = UICamera.ControlScheme.Mouse;
      UICamera.currentTouch.current = ((Component) this).gameObject;
      if (Input.GetKeyDown(this.keyCode))
        UICamera.Notify(((Component) this).gameObject, "OnPress", (object) true);
      if (Input.GetKeyUp(this.keyCode))
      {
        UICamera.Notify(((Component) this).gameObject, "OnPress", (object) false);
        UICamera.Notify(((Component) this).gameObject, "OnClick", (object) null);
      }
      UICamera.currentTouch.current = (GameObject) null;
    }
    else
    {
      if (this.action != UIKeyBinding.Action.Select || !Input.GetKeyUp(this.keyCode))
        return;
      if (this.mIsInput)
      {
        if (!this.mIgnoreUp && !UICamera.inputHasFocus)
          UICamera.selectedObject = ((Component) this).gameObject;
        this.mIgnoreUp = false;
      }
      else
        UICamera.selectedObject = ((Component) this).gameObject;
    }
  }

  public enum Action
  {
    PressAndClick,
    Select,
  }

  public enum Modifier
  {
    None,
    Shift,
    Control,
    Alt,
  }
}
