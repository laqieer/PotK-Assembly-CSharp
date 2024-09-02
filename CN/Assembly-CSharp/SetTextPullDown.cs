// Decompiled with JetBrains decompiler
// Type: SetTextPullDown
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class SetTextPullDown : MonoBehaviour
{
  [SerializeField]
  public UILabel label;
  [SerializeField]
  public UIPopupList popup;
  [SerializeField]
  public UIInput input;

  public void SetText() => this.label.text = this.popup.value;

  public void SetTextInput() => this.label.text = this.input.value;
}
