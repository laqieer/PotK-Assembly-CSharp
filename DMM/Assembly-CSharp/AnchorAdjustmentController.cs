// Decompiled with JetBrains decompiler
// Type: AnchorAdjustmentController
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections;
using System.Collections.Generic;
using UniLinq;
using UnityEngine;

public class AnchorAdjustmentController : MonoBehaviour
{
  public const float maxRetryTime = 2f;
  public float currentRetryTime;
  public string adjustedObjName;
  public string targetObjName;

  public static void AdjustAnchor(
    UIWidget adjustedObj,
    string targetObjName,
    string rootSearchName = null)
  {
    GameObject gameObject = new GameObject();
    gameObject.name = string.Format("AnchorAdjustmentController({0}-{1})", (object) adjustedObj.gameObject.name, (object) targetObjName);
    AnchorAdjustmentController adjustmentController = gameObject.AddComponent<AnchorAdjustmentController>();
    adjustmentController.adjustedObjName = adjustedObj.name;
    adjustmentController.targetObjName = targetObjName;
    adjustmentController.StartCoroutine(adjustmentController.AdjustAnchorCoroutine(adjustedObj, targetObjName, rootSearchName));
  }

  public static void AdjustAnchorByObjects(
    UIWidget adjustedObj,
    string[] objNames,
    string rootSearchName = null)
  {
    GameObject gameObject = new GameObject();
    gameObject.name = string.Format("AnchorAdjustmentController({0}-{1})", (object) adjustedObj.gameObject.name, (object) rootSearchName);
    AnchorAdjustmentController adjustmentController = gameObject.AddComponent<AnchorAdjustmentController>();
    adjustmentController.adjustedObjName = adjustedObj.name;
    adjustmentController.ProcAdjustAnchorByObjects(adjustedObj, objNames, rootSearchName);
  }

  private void ProcAdjustAnchorByObjects(
    UIWidget adjustedObj,
    string[] objNames,
    string rootSearchName = null)
  {
    Transform transform1 = (Transform) null;
    Transform transform2 = (Transform) null;
    Transform transform3 = (Transform) null;
    Transform transform4 = (Transform) null;
    for (int index = 0; index < objNames.Length; ++index)
    {
      Transform targetObject = this.GetTargetObject(adjustedObj, objNames[index], rootSearchName);
      if (!((UnityEngine.Object) targetObject == (UnityEngine.Object) null))
      {
        switch (index)
        {
          case 0:
            transform1 = targetObject;
            continue;
          case 1:
            transform2 = targetObject;
            continue;
          case 2:
            transform3 = targetObject;
            continue;
          case 3:
            transform4 = targetObject;
            continue;
          default:
            continue;
        }
      }
    }
    adjustedObj.leftAnchor.target = transform1;
    adjustedObj.rightAnchor.target = transform2;
    adjustedObj.topAnchor.target = transform3;
    adjustedObj.bottomAnchor.target = transform4;
    adjustedObj.ResetAnchors();
    adjustedObj.Update();
    UnityEngine.Object.Destroy((UnityEngine.Object) this.gameObject);
  }

  public IEnumerator AdjustAnchorCoroutine(
    UIWidget adjustedObj,
    string targetObjName,
    string rootSearchName = null)
  {
    AnchorAdjustmentController adjustmentController = this;
    Transform newTarget = adjustmentController.GetTargetObject(adjustedObj, targetObjName, rootSearchName);
    while ((UnityEngine.Object) newTarget == (UnityEngine.Object) null)
    {
      if ((double) adjustmentController.currentRetryTime >= 2.0)
      {
        Debug.LogError((object) ("Failed to find target object: " + adjustedObj.gameObject.name + "->" + targetObjName));
        UnityEngine.Object.Destroy((UnityEngine.Object) adjustmentController.gameObject);
      }
      Debug.LogWarning((object) string.Format("Target {0} does not exist!!!", (object) targetObjName));
      string str = adjustmentController.gameObject.name;
      for (Transform parent = adjustmentController.transform.parent; (UnityEngine.Object) parent != (UnityEngine.Object) null; parent = parent.parent)
        str = str + " -> " + parent.gameObject.name;
      newTarget = adjustmentController.GetTargetObject(adjustedObj, targetObjName, rootSearchName);
      adjustmentController.currentRetryTime += Time.deltaTime;
      yield return (object) null;
    }
    adjustedObj.leftAnchor.target = newTarget;
    adjustedObj.rightAnchor.target = newTarget;
    adjustedObj.topAnchor.target = newTarget;
    adjustedObj.bottomAnchor.target = newTarget;
    adjustedObj.ResetAnchors();
    adjustedObj.Update();
    UnityEngine.Object.Destroy((UnityEngine.Object) adjustmentController.gameObject);
  }

  private Transform GetTargetObject(
    UIWidget adjustedObj,
    string targetObjName,
    string rootSearchName = null)
  {
    Transform transform = (Transform) null;
    if (!string.IsNullOrEmpty(rootSearchName))
    {
      GameObject gameObject = GameObject.Find(rootSearchName);
      if ((UnityEngine.Object) gameObject != (UnityEngine.Object) null)
        transform = gameObject.transform.GetChildInFind(targetObjName);
    }
    else
      transform = adjustedObj.transform.GetParentInFind(targetObjName);
    return transform;
  }

  public static void AdjustAnchor(AnchorCustomAdjustment.AnchorSetting[] settings)
  {
    AnchorAdjustmentController adjustmentController = new GameObject().AddComponent<AnchorAdjustmentController>();
    adjustmentController.StartCoroutine(adjustmentController.AdjustAnchorCoroutine(settings));
  }

  public IEnumerator AdjustAnchorCoroutine(
    AnchorCustomAdjustment.AnchorSetting[] settings)
  {
    AnchorAdjustmentController adjustmentController = this;
    List<AnchorCustomAdjustment.AnchorSetting> listset = ((IEnumerable<AnchorCustomAdjustment.AnchorSetting>) settings).Where<AnchorCustomAdjustment.AnchorSetting>((Func<AnchorCustomAdjustment.AnchorSetting, bool>) (s => (UnityEngine.Object) s.widget_ != (UnityEngine.Object) null || (UnityEngine.Object) s.panel_ != (UnityEngine.Object) null)).ToList<AnchorCustomAdjustment.AnchorSetting>();
    Dictionary<string, Transform> dictarget = new Dictionary<string, Transform>();
    foreach (AnchorCustomAdjustment.AnchorSetting anchorSetting in listset)
    {
      AnchorCustomAdjustment.AnchorSetting s = anchorSetting;
      Transform tr = (Transform) null;
      while (!string.IsNullOrEmpty(s.targetParentName_) && !dictarget.TryGetValue(s.targetParentName_, out tr))
      {
        yield return (object) null;
        if (!((UnityEngine.Object) s.widget_ == (UnityEngine.Object) null) || !((UnityEngine.Object) s.panel_ == (UnityEngine.Object) null))
        {
          tr = ((UnityEngine.Object) s.widget_ != (UnityEngine.Object) null ? s.widget_.transform : s.panel_.transform).GetParentInFind(s.targetParentName_);
          dictarget.Add(s.targetParentName_, tr);
        }
        else
          break;
      }
      if ((UnityEngine.Object) s.widget_ != (UnityEngine.Object) null)
      {
        if ((UnityEngine.Object) tr != (UnityEngine.Object) null)
        {
          if (s.isTargetLeft_)
            s.widget_.leftAnchor.target = tr;
          if (s.isTargetRight_)
            s.widget_.rightAnchor.target = tr;
          if (s.isTargetTop_)
            s.widget_.topAnchor.target = tr;
          if (s.isTargetBottom_)
            s.widget_.bottomAnchor.target = tr;
        }
        s.widget_.ResetAnchors();
      }
      if ((UnityEngine.Object) s.panel_ != (UnityEngine.Object) null)
      {
        if ((UnityEngine.Object) tr != (UnityEngine.Object) null)
        {
          if (s.isTargetLeft_)
            s.panel_.leftAnchor.target = tr;
          if (s.isTargetRight_)
            s.panel_.rightAnchor.target = tr;
          if (s.isTargetTop_)
            s.panel_.topAnchor.target = tr;
          if (s.isTargetBottom_)
            s.panel_.bottomAnchor.target = tr;
        }
        s.panel_.Update();
      }
      tr = (Transform) null;
      s = (AnchorCustomAdjustment.AnchorSetting) null;
    }
    List<AnchorCustomAdjustment.AnchorSetting> anchorSettingList = new List<AnchorCustomAdjustment.AnchorSetting>((IEnumerable<AnchorCustomAdjustment.AnchorSetting>) listset);
    anchorSettingList.Reverse();
    foreach (AnchorCustomAdjustment.AnchorSetting anchorSetting in anchorSettingList)
    {
      if ((UnityEngine.Object) anchorSetting.widget_ != (UnityEngine.Object) null)
        anchorSetting.widget_.Update();
      if ((UnityEngine.Object) anchorSetting.panel_ != (UnityEngine.Object) null)
        anchorSetting.panel_.Update();
    }
    UnityEngine.Object.Destroy((UnityEngine.Object) adjustmentController.gameObject);
  }
}
