// Decompiled with JetBrains decompiler
// Type: Battle3DRoot
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System.Collections;
using UnityEngine;

public class Battle3DRoot : BattleMonoBehaviour
{
  public Transform mapPoint;
  public Transform panelPoint;
  private Transform panels;
  private Transform units;

  protected override IEnumerator Start_Battle()
  {
    this.initialize();
    yield break;
  }

  public void initialize()
  {
    if (!((Object) this.panels == (Object) null) && !((Object) this.units == (Object) null))
      return;
    Singleton<NGBattleManager>.GetInstance().battleCamera = this.gameObject.transform.GetChildInFind("CameraNode").gameObject;
    this.panels = this.panelPoint.transform.GetChildInFind("Panels");
    this.units = this.panelPoint.transform.GetChildInFind("Units");
  }

  public void objectsAcitve(bool active)
  {
    foreach (Component componentsInChild in this.GetComponentsInChildren<Camera>(true))
      componentsInChild.gameObject.SetActive(active);
    if ((Object) this.panels != (Object) null)
      this.panels.gameObject.SetActive(active);
    if ((Object) this.units != (Object) null)
    {
      foreach (BattleUnitParts componentsInChild in this.units.GetComponentsInChildren<BattleUnitParts>())
        componentsInChild.setActive(active);
    }
    this.mapPoint.gameObject.SetActive(active);
  }
}
