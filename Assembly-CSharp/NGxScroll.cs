// Decompiled with JetBrains decompiler
// Type: NGxScroll
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UniLinq;
using UnityEngine;

public class NGxScroll : MonoBehaviour
{
  public UIScrollView scrollView;
  public UIGrid grid;
  [SerializeField]
  [Tooltip("Awake()でのscrollView,gridの設定行為を止めます")]
  private bool disabledAwakeSetting;

  private void Awake()
  {
    if (this.disabledAwakeSetting)
      return;
    this.scrollView.contentPivot = UIWidget.Pivot.TopLeft;
    this.scrollView.disableDragIfFits = true;
    if (!((UnityEngine.Object) this.grid != (UnityEngine.Object) null))
      return;
    this.grid.animateSmoothly = false;
    this.grid.keepWithinPanel = true;
  }

  public IEnumerable<GameObject> GridChildren() => this.grid.transform.GetChildren().Select<Transform, GameObject>((Func<Transform, GameObject>) (t => t.gameObject));

  public void Clear() => this.grid.transform.Clear();

  public void Add(GameObject obj, bool ignoreResizeCollider = false)
  {
    Transform transform = obj.transform;
    transform.parent = this.grid.transform;
    transform.localPosition = Vector3.zero;
    transform.localScale = Vector3.one;
    if (ignoreResizeCollider)
      return;
    BoxCollider componentInChildren = obj.GetComponentInChildren<BoxCollider>();
    if (!((UnityEngine.Object) componentInChildren != (UnityEngine.Object) null))
      return;
    componentInChildren.size = new Vector3(this.grid.cellWidth, this.grid.cellHeight);
  }

  public Vector2 GetScrollPosition()
  {
    Vector2 pivotOffset = NGUIMath.GetPivotOffset(this.scrollView.contentPivot);
    return new Vector2((UnityEngine.Object) this.scrollView.horizontalScrollBar != (UnityEngine.Object) null ? this.scrollView.horizontalScrollBar.value : pivotOffset.x, (UnityEngine.Object) this.scrollView.verticalScrollBar != (UnityEngine.Object) null ? this.scrollView.verticalScrollBar.value : 1f - pivotOffset.y);
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
    int num1 = (int) ((double) this.scrollView.bounds.size.x / (double) this.grid.cellWidth);
    if (num1 < 1)
      num1 = 1;
    float num2 = (float) (this.grid.transform.childCount / num1);
    if (this.grid.transform.childCount % num1 > 0)
      ++num2;
    if ((double) num2 < 1.0)
      num2 = 1f;
    float num3 = this.scrollView.bounds.size.y - this.scrollView.panel.height;
    double num4 = (double) this.scrollView.bounds.size.y / (double) num2;
    float num5 = (float) (num4 / 2.0) / num3;
    float num6 = this.scrollView.panel.height / 2f / num3;
    float y = (float) (num4 * (double) (index / num1) / (double) num3 - ((double) num6 - (double) num5));
    if ((double) num3 <= 0.0)
      y = 0.0f;
    else if ((double) y < 0.0)
      y = 0.0f;
    else if ((double) y > 1.0)
      y = 1f;
    this.ResolvePosition(new Vector2(0.0f, y));
  }

  public void ResolvePosition()
  {
    this.grid.Reposition();
    this.scrollView.ResetPosition();
  }

  public void GridReposition(UIGrid.OnReposition afterGridReposition, bool oneshot = true)
  {
    if (afterGridReposition != null)
      this.grid.onReposition = !oneshot ? afterGridReposition : (UIGrid.OnReposition) (() =>
      {
        afterGridReposition();
        this.grid.onReposition = (UIGrid.OnReposition) null;
      });
    this.grid.repositionNow = true;
    this.grid.Reposition();
  }

  public void Reset() => this.grid.transform.DetachChildren();
}
