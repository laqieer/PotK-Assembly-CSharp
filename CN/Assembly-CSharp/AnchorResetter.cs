// Decompiled with JetBrains decompiler
// Type: AnchorResetter
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
