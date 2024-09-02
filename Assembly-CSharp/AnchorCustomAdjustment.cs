// Decompiled with JetBrains decompiler
// Type: AnchorCustomAdjustment
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[AddComponentMenu("Utility/Behaviour/AnchorCustomAdjustment")]
public class AnchorCustomAdjustment : MonoBehaviour
{
  [SerializeField]
  [Tooltip("自動で実行しない")]
  private bool isManualReset_;
  [SerializeField]
  private AnchorCustomAdjustment.AnchorSetting[] settings_ = new AnchorCustomAdjustment.AnchorSetting[1];

  private void Start()
  {
    if (this.isManualReset_)
      return;
    AnchorAdjustmentController.AdjustAnchor(this.settings_);
  }

  private void OnDisable()
  {
    if (this.isManualReset_)
      return;
    AnchorAdjustmentController.AdjustAnchor(this.settings_);
  }

  public void resetAnchors() => AnchorAdjustmentController.AdjustAnchor(this.settings_);

  public void resetAnchors(Transform[] subTargets)
  {
    Dictionary<string, Transform> dictionary = subTargets != null ? ((IEnumerable<Transform>) subTargets).ToDictionary<Transform, string>((Func<Transform, string>) (x => x.name)) : new Dictionary<string, Transform>();
    foreach (AnchorCustomAdjustment.AnchorSetting setting in this.settings_)
    {
      Transform parentInFind;
      if (!dictionary.TryGetValue(setting.targetParentName_, out parentInFind))
      {
        parentInFind = ((bool) (UnityEngine.Object) setting.widget_ ? setting.widget_.transform : setting.panel_.transform).GetParentInFind(setting.targetParentName_);
        dictionary.Add(setting.targetParentName_, parentInFind);
      }
      if ((UnityEngine.Object) setting.widget_ != (UnityEngine.Object) null)
      {
        if (setting.isTargetLeft_)
          setting.widget_.leftAnchor.target = parentInFind;
        if (setting.isTargetRight_)
          setting.widget_.rightAnchor.target = parentInFind;
        if (setting.isTargetTop_)
          setting.widget_.topAnchor.target = parentInFind;
        if (setting.isTargetBottom_)
          setting.widget_.bottomAnchor.target = parentInFind;
      }
      if ((UnityEngine.Object) setting.panel_ != (UnityEngine.Object) null)
      {
        if (setting.isTargetLeft_)
          setting.panel_.leftAnchor.target = parentInFind;
        if (setting.isTargetRight_)
          setting.panel_.rightAnchor.target = parentInFind;
        if (setting.isTargetTop_)
          setting.panel_.topAnchor.target = parentInFind;
        if (setting.isTargetBottom_)
          setting.panel_.bottomAnchor.target = parentInFind;
      }
    }
    foreach (UIRect uiRect in ((IEnumerable<UIRect>) this.GetComponentsInChildren<UIRect>()).Where<UIRect>((Func<UIRect, bool>) (x => x.isAnchored)))
    {
      uiRect.ResetAnchors();
      uiRect.Update();
    }
  }

  [Serializable]
  public class AnchorSetting
  {
    public UIWidget widget_;
    public UIPanel panel_;
    public string targetParentName_;
    public bool isTargetLeft_ = true;
    public bool isTargetRight_ = true;
    public bool isTargetTop_ = true;
    public bool isTargetBottom_ = true;
  }
}
