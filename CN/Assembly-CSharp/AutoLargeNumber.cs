// Decompiled with JetBrains decompiler
// Type: AutoLargeNumber
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class AutoLargeNumber : MonoBehaviour
{
  private UILabel textbox;

  private void Awake() => this.textbox = ((Component) this).GetComponent<UILabel>();

  private void Start()
  {
  }

  private void Update() => this.textbox.SetTextLocalize(this.textbox.text);
}
