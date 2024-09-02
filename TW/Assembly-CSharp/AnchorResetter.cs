// Decompiled with JetBrains decompiler
// Type: AnchorResetter
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
