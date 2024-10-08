﻿// Decompiled with JetBrains decompiler
// Type: SnapWidget
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class SnapWidget : MonoBehaviour
{
  [SerializeField]
  private bool isCalculateLocalPosition_ = true;
  private UIWidget widget_;
  private bool resetPosition_ = true;
  private Vector3 posOrigin_;

  private UIWidget myWidget
  {
    get
    {
      if (Object.op_Equality((Object) this.widget_, (Object) null))
        this.widget_ = ((Component) this).GetComponent<UIWidget>();
      return this.widget_;
    }
  }

  private Vector3 posOrigin
  {
    get
    {
      if (this.resetPosition_)
      {
        this.resetPosition_ = false;
        this.posOrigin_ = ((Component) this).transform.localPosition;
      }
      return this.posOrigin_;
    }
  }

  private void Awake()
  {
    UIGrid component = ((Component) this).GetComponent<UIGrid>();
    if (!Object.op_Inequality((Object) component, (Object) null) || !Object.op_Inequality((Object) this.myWidget, (Object) null))
      return;
    component.onReposition = new UIGrid.OnReposition(this.snapChildWidgets);
  }

  public void snapChildWidgets()
  {
    if (Object.op_Equality((Object) this.myWidget, (Object) null) || ((Component) this).transform.childCount == 0)
    {
      if (!Object.op_Inequality((Object) this.myWidget, (Object) null))
        return;
      ((Behaviour) this.myWidget).enabled = false;
    }
    else
    {
      ((Behaviour) this.myWidget).enabled = false;
      if (this.isCalculateLocalPosition_)
        ((Component) this).transform.localPosition = this.posOrigin;
      Bounds relativeWidgetBounds = NGUIMath.CalculateRelativeWidgetBounds(((Component) this).transform);
      ((Behaviour) this.myWidget).enabled = true;
      this.myWidget.width = Mathf.FloorToInt(((Bounds) ref relativeWidgetBounds).size.x);
      this.myWidget.height = Mathf.FloorToInt(((Bounds) ref relativeWidgetBounds).size.y);
      Vector3 zero = Vector3.zero;
      switch (this.myWidget.pivot)
      {
        case UIWidget.Pivot.TopLeft:
          // ISSUE: explicit constructor call
          ((Vector3) ref zero).\u002Ector(((Bounds) ref relativeWidgetBounds).min.x, ((Bounds) ref relativeWidgetBounds).max.y, 0.0f);
          break;
        case UIWidget.Pivot.Top:
          // ISSUE: explicit constructor call
          ((Vector3) ref zero).\u002Ector(((Bounds) ref relativeWidgetBounds).center.x, ((Bounds) ref relativeWidgetBounds).max.y, 0.0f);
          break;
        case UIWidget.Pivot.TopRight:
          // ISSUE: explicit constructor call
          ((Vector3) ref zero).\u002Ector(((Bounds) ref relativeWidgetBounds).max.x, ((Bounds) ref relativeWidgetBounds).max.y, 0.0f);
          break;
        case UIWidget.Pivot.Left:
          // ISSUE: explicit constructor call
          ((Vector3) ref zero).\u002Ector(((Bounds) ref relativeWidgetBounds).min.x, ((Bounds) ref relativeWidgetBounds).center.y, 0.0f);
          break;
        case UIWidget.Pivot.Center:
          // ISSUE: explicit constructor call
          ((Vector3) ref zero).\u002Ector(((Bounds) ref relativeWidgetBounds).center.x, ((Bounds) ref relativeWidgetBounds).center.y, 0.0f);
          break;
        case UIWidget.Pivot.Right:
          // ISSUE: explicit constructor call
          ((Vector3) ref zero).\u002Ector(((Bounds) ref relativeWidgetBounds).max.x, ((Bounds) ref relativeWidgetBounds).center.y, 0.0f);
          break;
        case UIWidget.Pivot.BottomLeft:
          // ISSUE: explicit constructor call
          ((Vector3) ref zero).\u002Ector(((Bounds) ref relativeWidgetBounds).min.x, ((Bounds) ref relativeWidgetBounds).min.y, 0.0f);
          break;
        case UIWidget.Pivot.Bottom:
          // ISSUE: explicit constructor call
          ((Vector3) ref zero).\u002Ector(((Bounds) ref relativeWidgetBounds).center.x, ((Bounds) ref relativeWidgetBounds).min.y, 0.0f);
          break;
        case UIWidget.Pivot.BottomRight:
          // ISSUE: explicit constructor call
          ((Vector3) ref zero).\u002Ector(((Bounds) ref relativeWidgetBounds).max.x, ((Bounds) ref relativeWidgetBounds).min.y, 0.0f);
          break;
      }
      if (this.isCalculateLocalPosition_)
        ((Component) this).transform.localPosition = Vector3.op_Addition(this.posOrigin, zero);
      foreach (Transform child in ((Component) this).transform.GetChildren())
        child.localPosition = Vector3.op_Subtraction(child.localPosition, zero);
    }
  }
}
