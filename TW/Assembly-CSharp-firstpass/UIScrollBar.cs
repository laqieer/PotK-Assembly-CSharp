﻿// Decompiled with JetBrains decompiler
// Type: UIScrollBar
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ECB926DA-6BA5-4E91-81B4-E3750A024FEA
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp-firstpass.dll

using System;
using UnityEngine;

#nullable disable
[AddComponentMenu("NGUI/Interaction/NGUI Scroll Bar")]
[ExecuteInEditMode]
public class UIScrollBar : UISlider
{
  [SerializeField]
  [HideInInspector]
  protected float mSize = 1f;
  [SerializeField]
  [HideInInspector]
  private float mScroll;
  [HideInInspector]
  [SerializeField]
  private UIScrollBar.Direction mDir = UIScrollBar.Direction.Upgraded;

  [Obsolete("Use 'value' instead")]
  public float scrollValue
  {
    get => this.value;
    set => this.value = value;
  }

  public float barSize
  {
    get => this.mSize;
    set
    {
      float num = Mathf.Clamp01(value);
      if ((double) this.mSize == (double) num)
        return;
      this.mSize = num;
      this.mIsDirty = true;
      if (!NGUITools.GetActive((Behaviour) this))
        return;
      if (this.onChange != null)
      {
        UIProgressBar.current = (UIProgressBar) this;
        EventDelegate.Execute(this.onChange);
        UIProgressBar.current = (UIProgressBar) null;
      }
      this.ForceUpdate();
    }
  }

  protected override void Upgrade()
  {
    if (this.mDir == UIScrollBar.Direction.Upgraded)
      return;
    this.mValue = this.mScroll;
    if (this.mDir == UIScrollBar.Direction.Horizontal)
      this.mFill = !this.mInverted ? UIProgressBar.FillDirection.LeftToRight : UIProgressBar.FillDirection.RightToLeft;
    else
      this.mFill = !this.mInverted ? UIProgressBar.FillDirection.TopToBottom : UIProgressBar.FillDirection.BottomToTop;
    this.mDir = UIScrollBar.Direction.Upgraded;
  }

  protected override void OnStart()
  {
    base.OnStart();
    if (!Object.op_Inequality((Object) this.mFG, (Object) null) || !Object.op_Inequality((Object) ((Component) this.mFG).GetComponent<Collider>(), (Object) null) || !Object.op_Inequality((Object) ((Component) this.mFG).gameObject, (Object) ((Component) this).gameObject))
      return;
    UIEventListener uiEventListener = UIEventListener.Get(((Component) this.mFG).gameObject);
    uiEventListener.onPress += new UIEventListener.BoolDelegate(((UISlider) this).OnPressForeground);
    uiEventListener.onDrag += new UIEventListener.VectorDelegate(((UISlider) this).OnDragForeground);
    this.mFG.autoResizeBoxCollider = true;
  }

  protected override float LocalToValue(Vector2 localPos)
  {
    if (!Object.op_Inequality((Object) this.mFG, (Object) null))
      return base.LocalToValue(localPos);
    float num1 = Mathf.Clamp01(this.mSize) * 0.5f;
    float num2 = num1;
    float num3 = 1f - num1;
    Vector3[] localCorners = this.mFG.localCorners;
    if (this.isHorizontal)
    {
      float num4 = Mathf.Lerp(localCorners[0].x, localCorners[2].x, num2);
      float num5 = Mathf.Lerp(localCorners[0].x, localCorners[2].x, num3);
      float num6 = num5 - num4;
      if ((double) num6 == 0.0)
        return this.value;
      return this.isInverted ? (num5 - localPos.x) / num6 : (localPos.x - num4) / num6;
    }
    float num7 = Mathf.Lerp(localCorners[0].y, localCorners[1].y, num2);
    float num8 = Mathf.Lerp(localCorners[3].y, localCorners[2].y, num3);
    float num9 = num8 - num7;
    if ((double) num9 == 0.0)
      return this.value;
    return this.isInverted ? (num8 - localPos.y) / num9 : (localPos.y - num7) / num9;
  }

  public override void ForceUpdate()
  {
    if (Object.op_Inequality((Object) this.mFG, (Object) null))
    {
      this.mIsDirty = false;
      float num1 = Mathf.Clamp01(this.mSize) * 0.5f;
      float num2 = Mathf.Lerp(num1, 1f - num1, this.value);
      float num3 = num2 - num1;
      float num4 = num2 + num1;
      if (this.isHorizontal)
        this.mFG.drawRegion = !this.isInverted ? new Vector4(num3, 0.0f, num4, 1f) : new Vector4(1f - num4, 0.0f, 1f - num3, 1f);
      else
        this.mFG.drawRegion = !this.isInverted ? new Vector4(0.0f, num3, 1f, num4) : new Vector4(0.0f, 1f - num4, 1f, 1f - num3);
      if (!Object.op_Inequality((Object) this.thumb, (Object) null))
        return;
      Vector4 drawingDimensions = this.mFG.drawingDimensions;
      Vector3 vector3;
      // ISSUE: explicit constructor call
      ((Vector3) ref vector3).\u002Ector(Mathf.Lerp(drawingDimensions.x, drawingDimensions.z, 0.5f), Mathf.Lerp(drawingDimensions.y, drawingDimensions.w, 0.5f));
      this.SetThumbPosition(this.mFG.cachedTransform.TransformPoint(vector3));
    }
    else
      base.ForceUpdate();
  }

  private new enum Direction
  {
    Horizontal,
    Vertical,
    Upgraded,
  }
}
