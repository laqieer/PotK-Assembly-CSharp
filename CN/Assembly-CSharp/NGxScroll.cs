// Decompiled with JetBrains decompiler
// Type: NGxScroll
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UniLinq;
using UnityEngine;

#nullable disable
public class NGxScroll : MonoBehaviour
{
  public UIScrollView scrollView;
  public UIGrid grid;

  private void Awake()
  {
    this.scrollView.contentPivot = UIWidget.Pivot.TopLeft;
    this.scrollView.disableDragIfFits = true;
    this.grid.animateSmoothly = false;
    this.grid.keepWithinPanel = true;
  }

  public IEnumerable<GameObject> GridChildren()
  {
    return ((Component) this.grid).transform.GetChildren().Select<Transform, GameObject>((Func<Transform, GameObject>) (t => ((Component) t).gameObject));
  }

  public void Clear() => ((Component) this.grid).transform.Clear();

  public void Add(GameObject obj, bool ignoreResizeCollider = false)
  {
    obj.transform.parent = ((Component) this.grid).transform;
    obj.transform.localPosition = Vector3.zero;
    obj.transform.localScale = Vector3.one;
    if (ignoreResizeCollider)
      return;
    BoxCollider componentInChildren = obj.GetComponentInChildren<BoxCollider>();
    if (!Object.op_Inequality((Object) componentInChildren, (Object) null))
      return;
    componentInChildren.size = new Vector3(this.grid.cellWidth, this.grid.cellHeight);
  }

  public Vector2 GetScrollPosition()
  {
    Vector2 pivotOffset = NGUIMath.GetPivotOffset(this.scrollView.contentPivot);
    return new Vector2(!Object.op_Inequality((Object) this.scrollView.horizontalScrollBar, (Object) null) ? pivotOffset.x : this.scrollView.horizontalScrollBar.value, !Object.op_Inequality((Object) this.scrollView.verticalScrollBar, (Object) null) ? 1f - pivotOffset.y : this.scrollView.verticalScrollBar.value);
  }

  public void ResolvePosition(Vector2 pos)
  {
    this.grid.Reposition();
    this.scrollView.ResetPosition();
    this.scrollView.SetDragAmount(pos.x, pos.y, false);
    this.scrollView.SetDragAmount(pos.x, pos.y, true);
  }

  public void ResolvePosition(int index)
  {
    this.grid.Reposition();
    this.scrollView.ResetPosition();
    Bounds bounds1 = this.scrollView.bounds;
    int num1 = (int) ((double) ((Bounds) ref bounds1).size.x / (double) this.grid.cellWidth);
    if (num1 < 1)
      num1 = 1;
    float num2 = (float) (((Component) this.grid).transform.childCount / num1);
    if (((Component) this.grid).transform.childCount % num1 > 0)
      ++num2;
    if ((double) num2 < 1.0)
      num2 = 1f;
    Bounds bounds2 = this.scrollView.bounds;
    float num3 = ((Bounds) ref bounds2).size.y - this.scrollView.panel.height;
    Bounds bounds3 = this.scrollView.bounds;
    float num4 = ((Bounds) ref bounds3).size.y / num2;
    float num5 = num4 / 2f / num3;
    float num6 = this.scrollView.panel.height / 2f / num3;
    float num7 = (float) ((double) num4 * (double) (index / num1) / (double) num3 - ((double) num6 - (double) num5));
    if ((double) num3 <= 0.0)
      num7 = 0.0f;
    else if ((double) num7 < 0.0)
      num7 = 0.0f;
    else if ((double) num7 > 1.0)
      num7 = 1f;
    this.ResolvePosition(new Vector2(0.0f, num7));
  }

  public void ResolvePosition()
  {
    this.grid.Reposition();
    this.scrollView.ResetPosition();
  }

  public void Reset() => ((Component) this.grid).transform.DetachChildren();
}
