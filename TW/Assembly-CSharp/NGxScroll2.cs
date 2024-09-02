// Decompiled with JetBrains decompiler
// Type: NGxScroll2
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UniLinq;
using UnityEngine;

#nullable disable
public class NGxScroll2 : MonoBehaviour
{
  public UIScrollView scrollView;
  public int topSpace = 2;
  public int bottomSpace = 2;
  private int ColumnSize;
  private int iconHeight;
  private List<GameObject> arr = new List<GameObject>();
  private GameObject Top;
  private GameObject Bottom;

  private int TopSpace => (Mathf.Max(2, this.topSpace) + 1) / 2 * 2;

  private int BottomSpace => (Mathf.Max(2, this.bottomSpace) + 1) / 2 * 2;

  public IEnumerator<GameObject> GetEnumerator()
  {
    return (IEnumerator<GameObject>) this.arr.GetEnumerator();
  }

  private void Awake()
  {
    this.scrollView.contentPivot = UIWidget.Pivot.TopLeft;
    this.scrollView.disableDragIfFits = true;
    this.Top = (GameObject) null;
    this.Bottom = (GameObject) null;
  }

  private void Start()
  {
    foreach (Transform child in ((Component) this.scrollView.verticalScrollBar).transform.GetChildren())
    {
      if (Object.op_Inequality((Object) ((Component) child).GetComponent<Collider>(), (Object) null))
        ((Component) child).GetComponent<Collider>().enabled = true;
    }
  }

  public IEnumerable<GameObject> GridChildren()
  {
    return ((Component) this.scrollView).transform.GetChildren().Select<Transform, GameObject>((Func<Transform, GameObject>) (t => ((Component) t).gameObject));
  }

  public void Clear()
  {
    if (Object.op_Inequality((Object) this.Top, (Object) null))
      this.Top = (GameObject) null;
    if (Object.op_Inequality((Object) this.Bottom, (Object) null))
      this.Bottom = (GameObject) null;
    this.arr.Clear();
    ((Component) this.scrollView).transform.Clear();
  }

  public void Add(GameObject obj, int width, int height, bool ignoreResizeCollider = false)
  {
    this.iconHeight = height;
    this.ColumnSize = 5;
    obj.transform.parent = ((Component) this.scrollView).transform;
    int num = ((Component) this.scrollView).transform.childCount - 1;
    obj.transform.localPosition = new Vector3((float) (num % this.ColumnSize * width - width * 2), (float) -(num / this.ColumnSize * height), 0.0f);
    obj.transform.localScale = Vector3.one;
    this.arr.Add(obj);
    if (ignoreResizeCollider)
      return;
    BoxCollider componentInChildren = obj.GetComponentInChildren<BoxCollider>();
    if (!Object.op_Inequality((Object) componentInChildren, (Object) null))
      return;
    componentInChildren.size = new Vector3((float) width, (float) height);
  }

  public void AddColumn1(GameObject obj, int width, int height, bool ignoreResizeCollider = false)
  {
    this.ColumnSize = 1;
    this.iconHeight = height;
    obj.transform.parent = ((Component) this.scrollView).transform;
    int num = ((Component) this.scrollView).transform.childCount - 1;
    obj.transform.localPosition = new Vector3(0.0f, (float) -(num * height), 0.0f);
    obj.transform.localScale = Vector3.one;
    this.arr.Add(obj);
    if (ignoreResizeCollider)
      return;
    BoxCollider componentInChildren = obj.GetComponentInChildren<BoxCollider>();
    if (!Object.op_Inequality((Object) componentInChildren, (Object) null))
      return;
    componentInChildren.size = new Vector3((float) width, (float) height);
  }

  public void CreateScrollPoint(int height, int count)
  {
    if (Object.op_Equality((Object) this.Top, (Object) null))
    {
      this.Top = new GameObject("Top");
      this.Top.layer = ((Component) this.scrollView).gameObject.layer;
      this.Top.transform.parent = ((Component) this.scrollView).transform;
      UIWidget uiWidget = this.Top.AddComponent<UIWidget>();
      uiWidget.SetDimensions(2, this.TopSpace);
      uiWidget.panel = this.scrollView.panel;
    }
    this.Top.transform.localPosition = new Vector3(0.0f, (float) (height / 2), 0.0f);
    this.Top.transform.localScale = Vector3.one;
    this.Top.SetActive(true);
    if (Object.op_Equality((Object) this.Bottom, (Object) null))
    {
      this.Bottom = new GameObject("Bottom");
      this.Bottom.layer = ((Component) this.scrollView).gameObject.layer;
      this.Bottom.transform.parent = ((Component) this.scrollView).transform;
      UIWidget uiWidget = this.Bottom.AddComponent<UIWidget>();
      uiWidget.SetDimensions(2, this.BottomSpace);
      uiWidget.panel = this.scrollView.panel;
    }
    this.Bottom.transform.parent = ((Component) this.scrollView).transform;
    this.Bottom.transform.localPosition = new Vector3(0.0f, (float) (-(Mathf.Max(0, count - 1) / 5 * height) - height / 2), 0.0f);
    this.Bottom.transform.localScale = Vector3.one;
    this.Bottom.SetActive(true);
  }

  public void CreateScrollPointHeight(int height, int count)
  {
    if (Object.op_Equality((Object) this.Top, (Object) null))
    {
      this.Top = new GameObject("Top");
      this.Top.layer = ((Component) this.scrollView).gameObject.layer;
      this.Top.transform.parent = ((Component) this.scrollView).transform;
      UIWidget uiWidget = this.Top.AddComponent<UIWidget>();
      uiWidget.SetDimensions(2, this.TopSpace);
      uiWidget.panel = this.scrollView.panel;
    }
    this.Top.transform.localPosition = new Vector3(0.0f, (float) (height / 2), 0.0f);
    this.Top.transform.localScale = Vector3.one;
    this.Top.SetActive(true);
    if (Object.op_Equality((Object) this.Bottom, (Object) null))
    {
      this.Bottom = new GameObject("Bottom");
      this.Bottom.layer = ((Component) this.scrollView).gameObject.layer;
      this.Bottom.transform.parent = ((Component) this.scrollView).transform;
      UIWidget uiWidget = this.Bottom.AddComponent<UIWidget>();
      uiWidget.SetDimensions(2, this.BottomSpace);
      uiWidget.panel = this.scrollView.panel;
    }
    this.Bottom.transform.localPosition = new Vector3(0.0f, (float) (-((count - 1) * height) - height / 2), 0.0f);
    this.Bottom.transform.localScale = Vector3.one;
    this.Bottom.SetActive(true);
  }

  public void ResolvePosition(Vector2 pos)
  {
    this.scrollView.ResetPosition();
    this.scrollView.SetDragAmount(pos.x, pos.y, false);
    this.scrollView.SetDragAmount(pos.x, pos.y, true);
  }

  public void ResolvePosition(int index, int iconCount)
  {
    this.scrollView.ResetPosition();
    double height = (double) this.scrollView.panel.height;
    Bounds bounds1 = this.scrollView.bounds;
    double y = (double) ((Bounds) ref bounds1).size.y;
    if (height > y)
      return;
    int num1 = this.ColumnSize;
    if (num1 < 1)
      num1 = 1;
    float num2 = (float) (iconCount / num1);
    if ((double) num2 > 0.0)
      ++num2;
    if ((double) num2 < 1.0)
      ;
    Bounds bounds2 = this.scrollView.bounds;
    float num3 = Mathf.Abs(((Bounds) ref bounds2).size.y - this.scrollView.panel.height);
    float num4 = (float) this.iconHeight * (float) (index / num1) / num3;
    if ((double) num4 < 0.0)
      num4 = 0.0f;
    else if ((double) num4 > 1.0)
      num4 = 1f;
    this.ResolvePosition(new Vector2(0.0f, num4));
  }

  public void ResolvePosition() => this.scrollView.ResetPosition();

  public void Reset()
  {
    if (Object.op_Inequality((Object) this.Top, (Object) null))
    {
      Object.Destroy((Object) this.Top);
      this.Top = (GameObject) null;
    }
    if (Object.op_Inequality((Object) this.Bottom, (Object) null))
    {
      Object.Destroy((Object) this.Bottom);
      this.Bottom = (GameObject) null;
    }
    ((Component) this.scrollView).transform.DetachChildren();
    this.arr.Clear();
  }
}
