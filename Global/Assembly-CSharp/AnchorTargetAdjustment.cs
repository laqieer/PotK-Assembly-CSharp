// Decompiled with JetBrains decompiler
// Type: AnchorTargetAdjustment
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class AnchorTargetAdjustment : MonoBehaviour
{
  public string targetParentName = "MainPanel";

  [DebuggerHidden]
  private IEnumerator Start()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new AnchorTargetAdjustment.\u003CStart\u003Ec__Iterator8D7()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void OnDisable()
  {
    UIWidget component = ((Component) this).GetComponent<UIWidget>();
    if (Object.op_Equality((Object) component, (Object) null))
      return;
    Transform parentInFind = ((Component) this).transform.GetParentInFind(this.targetParentName);
    if (Object.op_Equality((Object) parentInFind, (Object) null))
      return;
    component.leftAnchor.target = parentInFind;
    component.rightAnchor.target = parentInFind;
    component.topAnchor.target = parentInFind;
    component.bottomAnchor.target = parentInFind;
    component.ResetAnchors();
    component.Update();
  }
}
