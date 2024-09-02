// Decompiled with JetBrains decompiler
// Type: NGxScrollMasonry
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UniLinq;
using UnityEngine;

public class NGxScrollMasonry : MonoBehaviour
{
  [SerializeField]
  public UIScrollView Scroll;
  public List<GameObject> Arr = new List<GameObject>();
  private List<GameObject> nArr = new List<GameObject>();

  private void Awake()
  {
    this.Scroll.contentPivot = UIWidget.Pivot.TopLeft;
    this.Scroll.disableDragIfFits = true;
  }

  public void Add(GameObject obj, bool resize = false)
  {
    if (!resize)
    {
      obj.transform.parent = this.Scroll.transform;
      obj.transform.localPosition = this.CalcLocalPosition(obj);
      obj.transform.localScale = Vector3.one;
      this.Arr.Add(obj);
    }
    else
    {
      obj.transform.localPosition = this.CalcLocalPosition(obj, true);
      this.nArr.Add(obj);
    }
    this.SetCollider(obj);
  }

  public void Insert(int index, GameObject obj, bool resize = false)
  {
    if (!resize)
    {
      obj.transform.parent = this.Scroll.transform;
      obj.transform.localPosition = this.CalcLocalPosition(obj);
      obj.transform.localScale = Vector3.one;
      this.Arr.Insert(index, obj);
    }
    else
    {
      obj.transform.localPosition = this.CalcLocalPosition(obj, true);
      this.nArr.Insert(index, obj);
    }
    this.SetCollider(obj);
  }

  private Vector3 CalcLocalPosition(GameObject go, bool resize = false)
  {
    float y = resize ? (float) this.GetOffsetTop(this.nArr) : (float) this.GetOffsetTop(this.Arr);
    UIWidget component = go.GetComponent<UIWidget>();
    switch (component.pivot)
    {
      case UIWidget.Pivot.Left:
      case UIWidget.Pivot.Center:
      case UIWidget.Pivot.Right:
        y -= (float) (component.height / 2);
        break;
      case UIWidget.Pivot.BottomLeft:
      case UIWidget.Pivot.Bottom:
      case UIWidget.Pivot.BottomRight:
        y -= (float) component.height;
        break;
    }
    return new Vector3(0.0f, y, 0.0f);
  }

  private void SetCollider(GameObject go)
  {
    UIWidget component1 = go.GetComponent<UIWidget>();
    BoxCollider component2 = go.GetComponent<BoxCollider>();
    if ((UnityEngine.Object) component1 != (UnityEngine.Object) null && (UnityEngine.Object) component2 != (UnityEngine.Object) null)
    {
      Vector4 drawingDimensions = component1.drawingDimensions;
      component2.center = new Vector3((float) (((double) drawingDimensions.x + (double) drawingDimensions.z) * 0.5), (float) (((double) drawingDimensions.y + (double) drawingDimensions.w) * 0.5));
      component2.size = new Vector3(drawingDimensions.z - drawingDimensions.x, drawingDimensions.w - drawingDimensions.y);
    }
    else
      Debug.LogError((object) "UIWidget or collider is none");
  }

  private int GetOffsetTop(List<GameObject> list) => list.Sum<GameObject>((Func<GameObject, int>) (go => go.GetComponent<UIWidget>().height)) * -1;

  public void ResolvePosition() => this.Scroll.ResetPosition();

  public void ResolvePosition(int index)
  {
    if (this.Arr.Count <= 0)
      return;
    index = this.Arr.Count > index ? index : 0;
    float num1 = 0.0f;
    foreach (GameObject gameObject in this.Arr)
      num1 += (float) gameObject.GetComponent<UIWidget>().height;
    float num2 = this.Scroll.bounds.size.y - this.Scroll.panel.height;
    float y = (float) ((double) this.Arr[index].transform.localPosition.y * -1.0 - (double) num2 / 2.0) / num1;
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
    this.Scroll.transform.DetachChildren();
    this.Arr.Clear();
  }

  public void Resize()
  {
    this.nArr.Clear();
    foreach (GameObject gameObject in this.Arr)
    {
      if (gameObject.activeSelf)
        this.Add(gameObject, true);
    }
  }
}
