// Decompiled with JetBrains decompiler
// Type: ScrollViewSpecifyBounds
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UniLinq;
using UnityEngine;

public class ScrollViewSpecifyBounds : UIScrollView
{
  [SerializeField]
  [Tooltip("スクロール可動範囲の参考データ")]
  private UIWidget[] boundArray_;

  public UIWidget[] boundArray => this.boundArray_;

  public void AddBound(UIWidget w)
  {
    if ((Object) w == (Object) null)
      return;
    if (this.boundArray_ == null)
    {
      this.boundArray_ = new UIWidget[1]{ w };
      this.mCalculatedBounds = false;
    }
    else
    {
      if (((IEnumerable<UIWidget>) this.boundArray_).Contains<UIWidget>(w))
        return;
      List<UIWidget> list = ((IEnumerable<UIWidget>) this.boundArray_).ToList<UIWidget>();
      list.Add(w);
      this.boundArray_ = list.ToArray();
      this.mCalculatedBounds = false;
    }
  }

  public void AddBounds(IEnumerable<UIWidget> ws)
  {
    if (ws == null || !ws.Any<UIWidget>())
      return;
    List<UIWidget> uiWidgetList = this.boundArray_ != null ? ((IEnumerable<UIWidget>) this.boundArray_).ToList<UIWidget>() : new List<UIWidget>(ws.Count<UIWidget>());
    uiWidgetList.AddRange(ws);
    this.boundArray_ = uiWidgetList.ToArray();
    this.mCalculatedBounds = false;
  }

  public void RemoveBound(UIWidget w)
  {
    if ((Object) w == (Object) null)
      return;
    List<UIWidget> list = ((IEnumerable<UIWidget>) this.boundArray_).ToList<UIWidget>();
    if (!list.Remove(w))
      return;
    this.boundArray_ = list.Any<UIWidget>() ? list.ToArray() : (UIWidget[]) null;
    this.mCalculatedBounds = false;
  }

  public void ClearBounds()
  {
    if (this.boundArray_ == null || this.boundArray_.Length == 0)
      return;
    this.boundArray_ = (UIWidget[]) null;
    this.mCalculatedBounds = false;
  }

  public override Bounds bounds
  {
    get
    {
      if (!this.mCalculatedBounds)
      {
        this.mCalculatedBounds = true;
        this.mTrans = this.transform;
        this.mBounds = this.CalculateRelativeWidgetBounds(this.mTrans, this.boundArray_);
      }
      return this.mBounds;
    }
  }

  private Bounds CalculateRelativeWidgetBounds(Transform relativeTo, UIWidget[] widgets)
  {
    if (widgets != null && widgets.Length != 0)
    {
      Vector3 vector3_1 = new Vector3(float.MaxValue, float.MaxValue, float.MaxValue);
      Vector3 vector3_2 = new Vector3(float.MinValue, float.MinValue, float.MinValue);
      Matrix4x4 worldToLocalMatrix = relativeTo.worldToLocalMatrix;
      bool flag = false;
      int index1 = 0;
      for (int length = widgets.Length; index1 < length; ++index1)
      {
        UIWidget widget = widgets[index1];
        if (widget.enabled)
        {
          Vector3[] worldCorners = widget.worldCorners;
          for (int index2 = 0; index2 < 4; ++index2)
          {
            Vector3 lhs = worldToLocalMatrix.MultiplyPoint3x4(worldCorners[index2]);
            vector3_2 = Vector3.Max(lhs, vector3_2);
            vector3_1 = Vector3.Min(lhs, vector3_1);
          }
          flag = true;
        }
      }
      if (flag)
      {
        Bounds bounds = new Bounds(vector3_1, Vector3.zero);
        bounds.Encapsulate(vector3_2);
        return bounds;
      }
    }
    return new Bounds(Vector3.zero, Vector3.zero);
  }
}
