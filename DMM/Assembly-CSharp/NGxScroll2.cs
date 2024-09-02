// Decompiled with JetBrains decompiler
// Type: NGxScroll2
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UniLinq;
using UnityEngine;

public class NGxScroll2 : MonoBehaviour
{
  public UIScrollView scrollView;
  public int topSpace = 2;
  public int bottomSpace = 2;
  private const int DEFAULT_ICONS_PER_LINE = 5;
  private int ColumnSize;
  private int iconHeight;
  [SerializeField]
  [Tooltip("scrollView がScrollViewSpecifyBounds の時、スクロールビュー可動範囲計算にTop, Bottomしか見ない")]
  private bool isSpecalMode;
  private List<GameObject> arr = new List<GameObject>();
  private GameObject Top;
  private GameObject Bottom;

  private int TopSpace => (Mathf.Max(2, this.topSpace) + 1) / 2 * 2;

  private int BottomSpace => (Mathf.Max(2, this.bottomSpace) + 1) / 2 * 2;

  public GameObject TopObject => this.Top;

  public GameObject BottomObject => this.Bottom;

  public IEnumerator<GameObject> GetEnumerator() => (IEnumerator<GameObject>) this.arr.GetEnumerator();

  private void Awake()
  {
    this.scrollView.contentPivot = UIWidget.Pivot.TopLeft;
    this.scrollView.disableDragIfFits = true;
    this.Top = (GameObject) null;
    this.Bottom = (GameObject) null;
  }

  private void Start()
  {
    foreach (Transform child in this.scrollView.verticalScrollBar.transform.GetChildren())
    {
      if ((UnityEngine.Object) child.GetComponent<Collider>() != (UnityEngine.Object) null)
        child.GetComponent<Collider>().enabled = true;
    }
  }

  public IEnumerable<GameObject> GridChildren() => this.scrollView.transform.GetChildren().Select<Transform, GameObject>((Func<Transform, GameObject>) (t => t.gameObject));

  public void Clear()
  {
    if ((UnityEngine.Object) this.Top != (UnityEngine.Object) null)
      this.Top = (GameObject) null;
    if ((UnityEngine.Object) this.Bottom != (UnityEngine.Object) null)
      this.Bottom = (GameObject) null;
    this.arr.Clear();
    this.scrollView.transform.Clear();
  }

  public void Add(GameObject obj, int width, int height, bool ignoreResizeCollider = false)
  {
    this.iconHeight = height;
    this.ColumnSize = 5;
    obj.transform.parent = this.scrollView.transform;
    int num = this.scrollView.transform.childCount - 1;
    obj.transform.localPosition = new Vector3((float) (num % this.ColumnSize * width - width * 2), (float) -(num / this.ColumnSize * height), 0.0f);
    obj.transform.localScale = Vector3.one;
    this.arr.Add(obj);
    if (ignoreResizeCollider)
      return;
    BoxCollider componentInChildren = obj.GetComponentInChildren<BoxCollider>();
    if (!((UnityEngine.Object) componentInChildren != (UnityEngine.Object) null))
      return;
    componentInChildren.size = new Vector3((float) width, (float) height);
  }

  public void AddColumn3(GameObject obj, int width, int height, int startIndex)
  {
    this.iconHeight = height;
    this.ColumnSize = 3;
    obj.transform.parent = this.scrollView.transform;
    int num = startIndex / this.ColumnSize;
    Vector3 vector3 = new Vector3((float) ((startIndex - 1 - num * this.ColumnSize) * width), (float) (-num * height), 0.0f);
    obj.transform.localPosition = vector3;
    obj.transform.localScale = Vector3.one;
    this.arr.Add(obj);
    BoxCollider componentInChildren = obj.GetComponentInChildren<BoxCollider>();
    if (!((UnityEngine.Object) componentInChildren != (UnityEngine.Object) null))
      return;
    componentInChildren.size = new Vector3((float) width, (float) height);
  }

  public Vector3 Add(
    GameObject obj,
    int width,
    int height,
    int startIndex,
    bool ignoreResizeCollider = false)
  {
    this.iconHeight = height;
    this.ColumnSize = 5;
    obj.transform.parent = this.scrollView.transform;
    Vector3 vector3 = this.CalcLocalPosition(width, height, startIndex);
    obj.transform.localPosition = vector3;
    obj.transform.localScale = Vector3.one;
    this.arr.Add(obj);
    if (ignoreResizeCollider)
      return vector3;
    BoxCollider componentInChildren = obj.GetComponentInChildren<BoxCollider>();
    if ((UnityEngine.Object) componentInChildren != (UnityEngine.Object) null)
      componentInChildren.size = new Vector3((float) width, (float) height);
    return vector3;
  }

  public Vector3 CalcLocalPosition(int width, int height, int startIndex) => new Vector3((float) (startIndex % this.ColumnSize * width - width * 2), (float) -(startIndex / this.ColumnSize * height), 0.0f);

  public void AddColumn1(GameObject obj, int width, int height, bool ignoreResizeCollider = false)
  {
    this.ColumnSize = 1;
    this.iconHeight = height;
    obj.transform.parent = this.scrollView.transform;
    int num = this.scrollView.transform.childCount - 1;
    obj.transform.localPosition = new Vector3(0.0f, (float) -(num * height), 0.0f);
    obj.transform.localScale = Vector3.one;
    this.arr.Add(obj);
    if (ignoreResizeCollider)
      return;
    BoxCollider componentInChildren = obj.GetComponentInChildren<BoxCollider>();
    if (!((UnityEngine.Object) componentInChildren != (UnityEngine.Object) null))
      return;
    componentInChildren.size = new Vector3((float) width, (float) height);
  }

  public void ResetScrollRange(int width, int height, int numObject)
  {
    this.ColumnSize = 5;
    Vector3 rhs1 = new Vector3(float.MaxValue, float.MaxValue, 0.0f);
    Vector3 rhs2 = new Vector3(float.MinValue, float.MinValue, 0.0f);
    Vector3 lhs1 = this.CalcLocalPosition(width, height, 0);
    Vector3 rhs3 = Vector3.Min(lhs1, rhs1);
    Vector3 rhs4 = Vector3.Max(lhs1, rhs2);
    Vector3 lhs2 = this.CalcLocalPosition(width, height, this.ColumnSize - 1);
    Vector3 rhs5 = Vector3.Min(lhs2, rhs3);
    Vector3 rhs6 = Vector3.Max(lhs2, rhs4);
    if (numObject > this.ColumnSize)
    {
      Vector3 lhs3 = this.CalcLocalPosition(width, height, numObject - 1);
      rhs5 = Vector3.Min(lhs3, rhs5);
      rhs6 = Vector3.Max(lhs3, rhs6);
    }
    float num1 = (float) width / 2f;
    float num2 = (float) height / 2f;
    rhs5.x -= num1;
    rhs5.y -= num2;
    rhs6.x += num1;
    rhs6.y += num2;
    this.resetTopObject(new Vector3(rhs5.x, rhs6.y, 0.0f));
    this.resetBottomObject(new Vector3(rhs6.x, rhs5.y, 0.0f));
    this.setSpecialMode();
  }

  private void resetTopObject(Vector3 pos)
  {
    if ((UnityEngine.Object) this.Top == (UnityEngine.Object) null)
    {
      this.Top = new GameObject("Top");
      this.Top.layer = this.scrollView.gameObject.layer;
      this.Top.transform.parent = this.scrollView.transform;
      this.Top.AddComponent<UIWidget>().SetDimensions(2, this.TopSpace);
    }
    this.Top.transform.localPosition = pos;
    this.Top.transform.localScale = Vector3.one;
    this.Top.SetActive(true);
  }

  private void resetBottomObject(Vector3 pos)
  {
    if ((UnityEngine.Object) this.Bottom == (UnityEngine.Object) null)
    {
      this.Bottom = new GameObject("Bottom");
      this.Bottom.layer = this.scrollView.gameObject.layer;
      this.Bottom.transform.parent = this.scrollView.transform;
      this.Bottom.AddComponent<UIWidget>().SetDimensions(2, this.BottomSpace);
    }
    this.Bottom.transform.localPosition = pos;
    this.Bottom.transform.localScale = Vector3.one;
    this.Bottom.SetActive(true);
  }

  private void clearSpecialMode()
  {
    if (!this.isSpecalMode)
      return;
    ScrollViewSpecifyBounds scrollView = this.scrollView as ScrollViewSpecifyBounds;
    if (!((UnityEngine.Object) scrollView != (UnityEngine.Object) null))
      return;
    scrollView.ClearBounds();
  }

  private void setSpecialMode()
  {
    if (!this.isSpecalMode)
      return;
    ScrollViewSpecifyBounds scrollView = this.scrollView as ScrollViewSpecifyBounds;
    if ((UnityEngine.Object) scrollView == (UnityEngine.Object) null)
      return;
    scrollView.ClearBounds();
    scrollView.AddBound(this.Top.GetComponent<UIWidget>());
    scrollView.AddBound(this.Bottom.GetComponent<UIWidget>());
  }

  public void CreateScrollPoint(int height, int count)
  {
    if ((UnityEngine.Object) this.Top == (UnityEngine.Object) null)
    {
      this.Top = new GameObject("Top");
      this.Top.layer = this.scrollView.gameObject.layer;
      this.Top.transform.parent = this.scrollView.transform;
      UIWidget uiWidget = this.Top.AddComponent<UIWidget>();
      uiWidget.SetDimensions(2, this.TopSpace);
      uiWidget.panel = this.scrollView.panel;
    }
    this.Top.transform.localPosition = new Vector3(0.0f, (float) (height / 2), 0.0f);
    this.Top.transform.localScale = Vector3.one;
    this.Top.SetActive(true);
    if ((UnityEngine.Object) this.Bottom == (UnityEngine.Object) null)
    {
      this.Bottom = new GameObject("Bottom");
      this.Bottom.layer = this.scrollView.gameObject.layer;
      this.Bottom.transform.parent = this.scrollView.transform;
      UIWidget uiWidget = this.Bottom.AddComponent<UIWidget>();
      uiWidget.SetDimensions(2, this.BottomSpace);
      uiWidget.panel = this.scrollView.panel;
    }
    this.Bottom.transform.parent = this.scrollView.transform;
    this.Bottom.transform.localPosition = new Vector3(0.0f, (float) (-(Mathf.Max(0, count - 1) / 5 * height) - height / 2), 0.0f);
    this.Bottom.transform.localScale = Vector3.one;
    this.Bottom.SetActive(true);
  }

  public void CreateScrollPointHeight(int height, int count)
  {
    if ((UnityEngine.Object) this.Top == (UnityEngine.Object) null)
    {
      this.Top = new GameObject("Top");
      this.Top.layer = this.scrollView.gameObject.layer;
      this.Top.transform.parent = this.scrollView.transform;
      UIWidget uiWidget = this.Top.AddComponent<UIWidget>();
      uiWidget.SetDimensions(2, this.TopSpace);
      uiWidget.panel = this.scrollView.panel;
    }
    this.Top.transform.localPosition = new Vector3(0.0f, (float) (height / 2), 0.0f);
    this.Top.transform.localScale = Vector3.one;
    this.Top.SetActive(true);
    if ((UnityEngine.Object) this.Bottom == (UnityEngine.Object) null)
    {
      this.Bottom = new GameObject("Bottom");
      this.Bottom.layer = this.scrollView.gameObject.layer;
      this.Bottom.transform.parent = this.scrollView.transform;
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
    if ((double) this.scrollView.panel.height > (double) this.scrollView.bounds.size.y)
      return;
    int num1 = this.ColumnSize;
    if (num1 < 1)
      num1 = 1;
    float num2 = (float) (iconCount / num1);
    if ((double) num2 > 0.0)
      ++num2;
    if ((double) num2 < 1.0)
      ;
    float num3 = Mathf.Abs(this.scrollView.bounds.size.y - this.scrollView.panel.height);
    float y = (float) this.iconHeight * (float) (index / num1) / num3;
    if ((double) y < 0.0)
      y = 0.0f;
    else if ((double) y > 1.0)
      y = 1f;
    this.ResolvePosition(new Vector2(0.0f, y));
  }

  public void ResolvePosition() => this.scrollView.ResetPosition();

  public void ResolvePositionFromScrollValue(float pos)
  {
    this.scrollView.ResetPosition();
    if ((double) this.scrollView.panel.height > (double) this.scrollView.bounds.size.y)
      return;
    float num1 = Mathf.Abs(this.scrollView.bounds.size.y - this.scrollView.panel.height);
    float num2 = (float) this.iconHeight / 2f / num1;
    float num3 = this.scrollView.panel.height / 2f / num1;
    float y = (float) ((double) pos / (double) num1 - ((double) num3 - (double) num2));
    if ((double) y < 0.0)
      y = 0.0f;
    else if ((double) y > 1.0)
      y = 1f;
    this.ResolvePosition(new Vector2(0.0f, y));
  }

  public void Reset()
  {
    this.clearSpecialMode();
    if ((UnityEngine.Object) this.Top != (UnityEngine.Object) null)
    {
      UnityEngine.Object.Destroy((UnityEngine.Object) this.Top);
      this.Top = (GameObject) null;
    }
    if ((UnityEngine.Object) this.Bottom != (UnityEngine.Object) null)
    {
      UnityEngine.Object.Destroy((UnityEngine.Object) this.Bottom);
      this.Bottom = (GameObject) null;
    }
    this.scrollView.transform.DetachChildren();
    this.arr.Clear();
  }
}
