// Decompiled with JetBrains decompiler
// Type: AnchorCustomAdjustment
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class AnchorCustomAdjustment : MonoBehaviour
{
  [SerializeField]
  private AnchorCustomAdjustment.AnchorSetting[] settings_ = new AnchorCustomAdjustment.AnchorSetting[1];

  [DebuggerHidden]
  private IEnumerator Start()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new AnchorCustomAdjustment.\u003CStart\u003Ec__IteratorACD()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void OnDisable() => this.resetAnchors();

  public void resetAnchors()
  {
    List<AnchorCustomAdjustment.AnchorSetting> list = ((IEnumerable<AnchorCustomAdjustment.AnchorSetting>) this.settings_).Where<AnchorCustomAdjustment.AnchorSetting>((Func<AnchorCustomAdjustment.AnchorSetting, bool>) (s => Object.op_Inequality((Object) s.widget_, (Object) null) || Object.op_Inequality((Object) s.panel_, (Object) null))).ToList<AnchorCustomAdjustment.AnchorSetting>();
    Dictionary<string, Transform> dictionary = new Dictionary<string, Transform>();
    foreach (AnchorCustomAdjustment.AnchorSetting anchorSetting in list)
    {
      Transform transform = (Transform) null;
      if (!string.IsNullOrEmpty(anchorSetting.targetParentName_) && !dictionary.TryGetValue(anchorSetting.targetParentName_, out transform))
      {
        transform = (!Object.op_Inequality((Object) anchorSetting.widget_, (Object) null) ? ((Component) anchorSetting.panel_).transform : ((Component) anchorSetting.widget_).transform).GetParentInFind(anchorSetting.targetParentName_);
        dictionary.Add(anchorSetting.targetParentName_, transform);
      }
      if (Object.op_Inequality((Object) anchorSetting.widget_, (Object) null))
      {
        if (Object.op_Inequality((Object) transform, (Object) null))
        {
          if (anchorSetting.isTargetLeft_)
            anchorSetting.widget_.leftAnchor.target = transform;
          if (anchorSetting.isTargetRight_)
            anchorSetting.widget_.rightAnchor.target = transform;
          if (anchorSetting.isTargetTop_)
            anchorSetting.widget_.topAnchor.target = transform;
          if (anchorSetting.isTargetBottom_)
            anchorSetting.widget_.bottomAnchor.target = transform;
        }
        anchorSetting.widget_.ResetAnchors();
      }
      if (Object.op_Inequality((Object) anchorSetting.panel_, (Object) null))
      {
        if (Object.op_Inequality((Object) transform, (Object) null))
        {
          if (anchorSetting.isTargetLeft_)
            anchorSetting.panel_.leftAnchor.target = transform;
          if (anchorSetting.isTargetRight_)
            anchorSetting.panel_.rightAnchor.target = transform;
          if (anchorSetting.isTargetTop_)
            anchorSetting.panel_.topAnchor.target = transform;
          if (anchorSetting.isTargetBottom_)
            anchorSetting.panel_.bottomAnchor.target = transform;
        }
        anchorSetting.panel_.Update();
      }
    }
    List<AnchorCustomAdjustment.AnchorSetting> anchorSettingList = new List<AnchorCustomAdjustment.AnchorSetting>((IEnumerable<AnchorCustomAdjustment.AnchorSetting>) list);
    anchorSettingList.Reverse();
    foreach (AnchorCustomAdjustment.AnchorSetting anchorSetting in anchorSettingList)
    {
      if (Object.op_Inequality((Object) anchorSetting.widget_, (Object) null))
        anchorSetting.widget_.Update();
      if (Object.op_Inequality((Object) anchorSetting.panel_, (Object) null))
        anchorSetting.panel_.Update();
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
