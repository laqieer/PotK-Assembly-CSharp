// Decompiled with JetBrains decompiler
// Type: NGxScrollMasonry
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
    obj.transform.localPosition = new Vector3(0.0f, (float) this.GetOffsetTop(this.Arr), 0.0f);
    obj.transform.localScale = Vector3.one;
    this.Arr.Add(obj);
    this.SetCollider(obj);
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
