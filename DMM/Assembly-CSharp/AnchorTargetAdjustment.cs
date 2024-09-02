// Decompiled with JetBrains decompiler
// Type: AnchorTargetAdjustment
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class AnchorTargetAdjustment : MonoBehaviour
{
  public string targetParentName = "MainPanel";

  private void Start()
  {
    UIWidget component = this.GetComponent<UIWidget>();
    if ((Object) component == (Object) null)
      return;
    AnchorAdjustmentController.AdjustAnchor(component, this.targetParentName);
  }

  private void OnDisable()
  {
    UIWidget component = this.GetComponent<UIWidget>();
    if ((Object) component == (Object) null)
      return;
    Transform parentInFind = this.transform.GetParentInFind(this.targetParentName);
    if ((Object) parentInFind == (Object) null)
    {
      Debug.LogError((object) ("AnchorTargetAdjustment Not Parent Error. Parent Name is " + this.targetParentName));
    }
    else
    {
      component.leftAnchor.target = parentInFind;
      component.rightAnchor.target = parentInFind;
      component.topAnchor.target = parentInFind;
      component.bottomAnchor.target = parentInFind;
      component.ResetAnchors();
      component.Update();
    }
  }
}
