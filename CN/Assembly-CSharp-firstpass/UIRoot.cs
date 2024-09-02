// Decompiled with JetBrains decompiler
// Type: UIRoot
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FC6F22C0-326E-48ED-B5EE-59590337E752
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp-firstpass.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
[AddComponentMenu("NGUI/UI/Root")]
[ExecuteInEditMode]
public class UIRoot : MonoBehaviour
{
  public static List<UIRoot> list = new List<UIRoot>();
  public UIRoot.Scaling scalingStyle;
  public int manualHeight = 720;
  public int minimumHeight = 320;
  public int maximumHeight = 1536;
  public bool adjustByDPI;
  public bool shrinkPortraitUI;
  private Transform mTrans;

  public int activeHeight
  {
    get
    {
      int height1 = Screen.height;
      int height2 = Mathf.Max(2, height1);
      if (this.scalingStyle == UIRoot.Scaling.FixedSize)
        return this.manualHeight;
      int width = Screen.width;
      if (this.scalingStyle == UIRoot.Scaling.FixedSizeOnMobiles)
        return this.manualHeight;
      if (height2 < this.minimumHeight)
        height2 = this.minimumHeight;
      if (height2 > this.maximumHeight)
        height2 = this.maximumHeight;
      if (this.shrinkPortraitUI && height1 > width)
        height2 = Mathf.RoundToInt((float) height2 * ((float) height1 / (float) width));
      return this.adjustByDPI ? NGUIMath.AdjustByDPI((float) height2) : height2;
    }
  }

  public float pixelSizeAdjustment => this.GetPixelSizeAdjustment(Screen.height);

  public static float GetPixelSizeAdjustment(GameObject go)
  {
    UIRoot inParents = NGUITools.FindInParents<UIRoot>(go);
    return Object.op_Inequality((Object) inParents, (Object) null) ? inParents.pixelSizeAdjustment : 1f;
  }

  public float GetPixelSizeAdjustment(int height)
  {
    height = Mathf.Max(2, height);
    if (this.scalingStyle == UIRoot.Scaling.FixedSize)
      return (float) this.manualHeight / (float) height;
    if (this.scalingStyle == UIRoot.Scaling.FixedSizeOnMobiles)
      return (float) this.manualHeight / (float) height;
    if (height < this.minimumHeight)
      return (float) this.minimumHeight / (float) height;
    return height > this.maximumHeight ? (float) this.maximumHeight / (float) height : 1f;
  }

  protected virtual void Awake() => this.mTrans = ((Component) this).transform;

  protected virtual void OnEnable() => UIRoot.list.Add(this);

  protected virtual void OnDisable() => UIRoot.list.Remove(this);

  protected virtual void Start()
  {
    UIOrthoCamera componentInChildren = ((Component) this).GetComponentInChildren<UIOrthoCamera>();
    if (Object.op_Inequality((Object) componentInChildren, (Object) null))
    {
      Debug.LogWarning((object) "UIRoot should not be active at the same time as UIOrthoCamera. Disabling UIOrthoCamera.", (Object) componentInChildren);
      Camera component = ((Component) componentInChildren).gameObject.GetComponent<Camera>();
      ((Behaviour) componentInChildren).enabled = false;
      if (!Object.op_Inequality((Object) component, (Object) null))
        return;
      component.orthographicSize = 1f;
    }
    else
      this.Update();
  }

  private void Update()
  {
    if (!Object.op_Inequality((Object) this.mTrans, (Object) null))
      return;
    float activeHeight = (float) this.activeHeight;
    if ((double) activeHeight <= 0.0)
      return;
    float num = 2f / activeHeight;
    Vector3 localScale = this.mTrans.localScale;
    if ((double) Mathf.Abs(localScale.x - num) <= 1.4012984643248171E-45 && (double) Mathf.Abs(localScale.y - num) <= 1.4012984643248171E-45 && (double) Mathf.Abs(localScale.z - num) <= 1.4012984643248171E-45)
      return;
    this.mTrans.localScale = new Vector3(num, num, num);
  }

  public static void Broadcast(string funcName)
  {
    int index = 0;
    for (int count = UIRoot.list.Count; index < count; ++index)
    {
      UIRoot uiRoot = UIRoot.list[index];
      if (Object.op_Inequality((Object) uiRoot, (Object) null))
        ((Component) uiRoot).BroadcastMessage(funcName, (SendMessageOptions) 1);
    }
  }

  public static void Broadcast(string funcName, object param)
  {
    if (param == null)
    {
      Debug.LogError((object) "SendMessage is bugged when you try to pass 'null' in the parameter field. It behaves as if no parameter was specified.");
    }
    else
    {
      int index = 0;
      for (int count = UIRoot.list.Count; index < count; ++index)
      {
        UIRoot uiRoot = UIRoot.list[index];
        if (Object.op_Inequality((Object) uiRoot, (Object) null))
          ((Component) uiRoot).BroadcastMessage(funcName, param, (SendMessageOptions) 1);
      }
    }
  }

  public enum Scaling
  {
    PixelPerfect,
    FixedSize,
    FixedSizeOnMobiles,
  }
}
