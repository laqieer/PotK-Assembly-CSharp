// Decompiled with JetBrains decompiler
// Type: AnchorResetter
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class AnchorResetter : MonoBehaviour
{
  private bool firstEnable = true;

  private void Awake() => this.firstEnable = true;

  private void OnEnable()
  {
    if (!this.firstEnable)
      return;
    this.firstEnable = false;
    UIRect component = ((Component) this).GetComponent<UIRect>();
    if (!Object.op_Inequality((Object) component, (Object) null))
      return;
    component.ResetAnchors();
    component.Update();
  }
}
