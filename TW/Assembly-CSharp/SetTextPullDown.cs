// Decompiled with JetBrains decompiler
// Type: SetTextPullDown
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
