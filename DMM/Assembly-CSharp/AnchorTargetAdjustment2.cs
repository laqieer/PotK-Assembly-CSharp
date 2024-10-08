﻿// Decompiled with JetBrains decompiler
// Type: AnchorTargetAdjustment2
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class AnchorTargetAdjustment2 : MonoBehaviour
{
  public string targetLeft = "Left";
  public string targetRight = "Right";
  public string targetTop = "Top";
  public string targetBottom = "Bottom";
  public string rootSearchName;
  [Space(8f)]
  [SerializeField]
  private bool onStartAdjust = true;
  public bool LateAdjustDirty;

  private void Start()
  {
    if (!this.onStartAdjust)
      return;
    this.Adjust();
  }

  private void LateUpdate()
  {
    if (!this.LateAdjustDirty)
      return;
    this.LateAdjustDirty = false;
    this.Adjust();
  }

  public void Adjust()
  {
    UIWidget component = this.GetComponent<UIWidget>();
    if ((Object) component == (Object) null)
      return;
    AnchorAdjustmentController.AdjustAnchorByObjects(component, new string[4]
    {
      this.targetLeft,
      this.targetRight,
      this.targetTop,
      this.targetBottom
    }, this.rootSearchName);
  }
}
