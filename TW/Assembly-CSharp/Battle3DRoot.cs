// Decompiled with JetBrains decompiler
// Type: Battle3DRoot
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Battle3DRoot : BattleMonoBehaviour
{
  public Transform mapPoint;
  public Transform panelPoint;
  private Transform panels;
  private Transform units;

  [DebuggerHidden]
  protected override IEnumerator Start_Battle()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Battle3DRoot.\u003CStart_Battle\u003Ec__IteratorA74()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void initialize()
  {
    if (!Object.op_Equality((Object) this.panels, (Object) null) && !Object.op_Equality((Object) this.units, (Object) null))
      return;
    Singleton<NGBattleManager>.GetInstance().battleCamera = ((Component) ((Component) this).gameObject.transform.GetChildInFind("CameraNode")).gameObject;
    this.panels = ((Component) this.panelPoint).transform.GetChildInFind("Panels");
    this.units = ((Component) this.panelPoint).transform.GetChildInFind("Units");
  }

  public void objectsAcitve(bool active)
  {
    foreach (Component componentsInChild in ((Component) this).GetComponentsInChildren<Camera>(true))
      componentsInChild.gameObject.SetActive(active);
    if (Object.op_Inequality((Object) this.panels, (Object) null))
      ((Component) this.panels).gameObject.SetActive(active);
    if (Object.op_Inequality((Object) this.units, (Object) null))
    {
      foreach (BattleUnitParts componentsInChild in ((Component) this.units).GetComponentsInChildren<BattleUnitParts>())
        componentsInChild.setActive(active);
    }
    ((Component) this.mapPoint).gameObject.SetActive(active);
  }
}
