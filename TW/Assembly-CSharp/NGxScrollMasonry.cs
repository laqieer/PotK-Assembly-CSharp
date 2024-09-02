// Decompiled with JetBrains decompiler
// Type: NGxScrollMasonry
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UniLinq;
using UnityEngine;

#nullable disable
public class NGxScrollMasonry : MonoBehaviour
{
  [SerializeField]
  public UIScrollView Scroll;
  private List<GameObject> Arr = new List<GameObject>();

  private void Awake()
  {
    this.Scroll.contentPivot = UIWidget.Pivot.TopLeft;
    this.Scroll.disableDragIfFits = true;
  }

  public void Add(GameObject obj)
  {
    obj.transform.parent = ((Component) this.Scroll).transform;
    obj.transform.localPosition = this.CalcLocalPosition(obj);
    obj.transform.localScale = Vector3.one;
    this.Arr.Add(obj);
    this.SetCollider(obj);
  }

  private Vector3 CalcLocalPosition(GameObject go)
  {
    float offsetTop = (float) this.GetOffsetTop(this.Arr);
    UIWidget component = go.GetComponent<UIWidget>();
    switch (component.pivot)
    {
      case UIWidget.Pivot.Left:
      case UIWidget.Pivot.Center:
      case UIWidget.Pivot.Right:
        offsetTop -= (float) (component.height / 2);
        break;
      case UIWidget.Pivot.BottomLeft:
      case UIWidget.Pivot.Bottom:
      case UIWidget.Pivot.BottomRight:
        offsetTop -= (float) component.height;
        break;
    }
    return new Vector3(0.0f, offsetTop, 0.0f);
  }

  private void SetCollider(GameObject go)
  {
    UIWidget component1 = go.GetComponent<UIWidget>();
    BoxCollider component2 = go.GetComponent<BoxCollider>();
    if (Object.op_Inequality((Object) component1, (Object) null) && Object.op_Inequality((Object) component2, (Object) null))
    {
      Vector4 drawingDimensions = component1.drawingDimensions;
      component2.center = new Vector3((float) (((double) drawingDimensions.x + (double) drawingDimensions.z) * 0.5), (float) (((double) drawingDimensions.y + (double) drawingDimensions.w) * 0.5));
      component2.size = new Vector3(drawingDimensions.z - drawingDimensions.x, drawingDimensions.w - drawingDimensions.y);
    }
    else
      Debug.LogError((object) "UIWidget or collider is none");
  }

  private int GetOffsetTop(List<GameObject> list)
  {
    return list.Sum<GameObject>((Func<GameObject, int>) (go => go.GetComponent<UIWidget>().height)) * -1;
  }

  public void ResolvePosition() => this.Scroll.ResetPosition();

  public void ResolvePosition(int index)
  {
    if (this.Arr.Count <= 0)
      return;
    index = this.Arr.Count <= index ? 0 : index;
    float num1 = 0.0f;
    foreach (GameObject gameObject in this.Arr)
      num1 += (float) gameObject.GetComponent<UIWidget>().height;
    Bounds bounds = this.Scroll.bounds;
    float num2 = ((Bounds) ref bounds).size.y - this.Scroll.panel.height;
    float y = (this.Arr[index].transform.localPosition.y * -1f - num2 / 2f) / num1;
    if ((double) y < 0.0 || index == 0)
      y = 0.0f;
    else if ((double) y > 1.0)
      y = 1f;
    this.ResolvePosition();
    this.Scroll.SetDragAmount(0.0f, y, false);
    this.Scroll.SetDragAmount(0.0f, y, true);
  }

  public void Reset()
  {
    ((Component) this.Scroll).transform.DetachChildren();
    this.Arr.Clear();
  }
}
