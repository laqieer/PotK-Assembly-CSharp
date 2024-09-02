// Decompiled with JetBrains decompiler
// Type: DisableButtonLabel
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
[RequireComponent(typeof (UIButton))]
public class DisableButtonLabel : MonoBehaviour
{
  public Color EnabledColor = Color.white;
  public Color DisabledColor = Color.grey;
  private UIButton button;
  private UILabel[] labels;
  private bool buttonEnabled;
  private bool initialized;

  private void Awake()
  {
    this.button = ((Component) this).gameObject.GetComponent<UIButton>();
    this.labels = ((Component) this).gameObject.GetComponentsInChildren<UILabel>();
  }

  private void Update()
  {
    if (Object.op_Equality((Object) this.button, (Object) null) || this.initialized && this.buttonEnabled == this.button.isEnabled)
      return;
    this.buttonEnabled = this.button.isEnabled;
    this.initialized = true;
    foreach (UIWidget label in this.labels)
      label.color = !this.buttonEnabled ? this.DisabledColor : this.EnabledColor;
  }
}
