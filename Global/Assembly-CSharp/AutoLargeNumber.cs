// Decompiled with JetBrains decompiler
// Type: AutoLargeNumber
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class AutoLargeNumber : MonoBehaviour
{
  private UILabel textbox;

  private void Awake() => this.textbox = ((Component) this).GetComponent<UILabel>();

  private void Update() => this.textbox.SetTextLocalize(this.textbox.text);
}
