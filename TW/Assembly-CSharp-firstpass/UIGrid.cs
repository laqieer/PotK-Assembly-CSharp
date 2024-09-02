// Decompiled with JetBrains decompiler
// Type: UIGrid
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ECB926DA-6BA5-4E91-81B4-E3750A024FEA
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp-firstpass.dll

using UnityEngine;

#nullable disable
[AddComponentMenu("NGUI/Interaction/Grid")]
public class UIGrid : UIWidgetContainer
{
  public UIGrid.Arrangement arrangement;
  public UIGrid.Sorting sorting;
  public UIWidget.Pivot pivot;
  public int maxPerLine;
  public float cellWidth = 200f;
  public float cellHeight = 200f;
  public bool animateSmoothly;
  public bool hideInactive = true;
  public bool keepWithinPanel;
  public UIGrid.OnReposition onReposition;
  [SerializeField]
  [HideInInspector]
  private bool sorted;
  protected bool mReposition;
  protected UIPanel mPanel;
  protected bool mInitDone;

  public bool repositionNow
  {
    set
    {
      if (!value)
        return;
      this.mReposition = true;
      ((Behaviour) this).enabled = true;
    }
  }

  protected virtual void Init()
  {
    this.mInitDone = true;
    this.mPanel = NGUITools.FindInParents<UIPanel>(((Component) this).gameObject);
  }

  protected virtual void Start()
  {
    if (!this.mInitDone)
      this.Init();
    bool animateSmoothly = this.animateSmoothly;
    this.animateSmoothly = false;
    this.Reposition();
    this.animateSmoothly = animateSmoothly;
    ((Behaviour) this).enabled = false;
  }

  protected virtual void Update()
  {
    if (this.mReposition)
      this.Reposition();
    ((Behaviour) this).enabled = false;
  }

  public static int SortByName(Transform a, Transform b)
  {
    return string.Compare(((Object) a).name, ((Object) b).name);
  }

  public static int SortHorizontal(Transform a, Transform b)
  {
    return a.localPosition.x.CompareTo(b.localPosition.x);
  }

  public static int SortVertical(Transform a, Transform b)
  {
    return b.localPosition.y.CompareTo(a.localPosition.y);
  }

  protected virtual void Sort(BetterList<Transform> list)
  {
    list.Sort(new BetterList<Transform>.CompareFunc(UIGrid.SortByName));
  }

  [ContextMenu("Execute")]
  public virtual void Reposition()
  {
    if (Application.isPlaying && !this.mInitDone && NGUITools.GetActive((Behaviour) this))
    {
      this.mReposition = true;
    }
    else
    {
      if (!this.mInitDone)
        this.Init();
      this.mReposition = false;
      Transform transform1 = ((Component) this).transform;
      int num1 = 0;
      int num2 = 0;
      int num3 = 0;
      int num4 = 0;
      if (this.sorting != UIGrid.Sorting.None || this.sorted)
      {
        BetterList<Transform> list = new BetterList<Transform>();
        for (int index = 0; index < transform1.childCount; ++index)
        {
          Transform child = transform1.GetChild(index);
          if (Object.op_Implicit((Object) child) && (!this.hideInactive || NGUITools.GetActive(((Component) child).gameObject)))
            list.Add(child);
        }
        if (this.sorting == UIGrid.Sorting.Alphabetic)
          list.Sort(new BetterList<Transform>.CompareFunc(UIGrid.SortByName));
        else if (this.sorting == UIGrid.Sorting.Horizontal)
          list.Sort(new BetterList<Transform>.CompareFunc(UIGrid.SortHorizontal));
        else if (this.sorting == UIGrid.Sorting.Vertical)
          list.Sort(new BetterList<Transform>.CompareFunc(UIGrid.SortVertical));
        else
          this.Sort(list);
        int i = 0;
        for (int size = list.size; i < size; ++i)
        {
          Transform transform2 = list[i];
          if (NGUITools.GetActive(((Component) transform2).gameObject) || !this.hideInactive)
          {
            float z = transform2.localPosition.z;
            Vector3 pos = this.arrangement != UIGrid.Arrangement.Horizontal ? new Vector3(this.cellWidth * (float) num2, -this.cellHeight * (float) num1, z) : new Vector3(this.cellWidth * (float) num1, -this.cellHeight * (float) num2, z);
            if (this.animateSmoothly && Application.isPlaying)
              SpringPosition.Begin(((Component) transform2).gameObject, pos, 15f).updateScrollView = true;
            else
              transform2.localPosition = pos;
            num3 = Mathf.Max(num3, num1);
            num4 = Mathf.Max(num4, num2);
            if (++num1 >= this.maxPerLine && this.maxPerLine > 0)
            {
              num1 = 0;
              ++num2;
            }
          }
        }
        list.Clear();
      }
      else
      {
        for (int index = 0; index < transform1.childCount; ++index)
        {
          Transform child = transform1.GetChild(index);
          if (NGUITools.GetActive(((Component) child).gameObject) || !this.hideInactive)
          {
            float z = child.localPosition.z;
            Vector3 pos = this.arrangement != UIGrid.Arrangement.Horizontal ? new Vector3(this.cellWidth * (float) num2, -this.cellHeight * (float) num1, z) : new Vector3(this.cellWidth * (float) num1, -this.cellHeight * (float) num2, z);
            if (this.animateSmoothly && Application.isPlaying)
              SpringPosition.Begin(((Component) child).gameObject, pos, 15f).updateScrollView = true;
            else
              child.localPosition = pos;
            num3 = Mathf.Max(num3, num1);
            num4 = Mathf.Max(num4, num2);
            if (++num1 >= this.maxPerLine && this.maxPerLine > 0)
            {
              num1 = 0;
              ++num2;
            }
          }
        }
      }
      if (this.pivot != UIWidget.Pivot.TopLeft)
      {
        Vector2 pivotOffset = NGUIMath.GetPivotOffset(this.pivot);
        float num5;
        float num6;
        if (this.arrangement == UIGrid.Arrangement.Horizontal)
        {
          num5 = Mathf.Lerp(0.0f, (float) num3 * this.cellWidth, pivotOffset.x);
          num6 = Mathf.Lerp((float) -num4 * this.cellHeight, 0.0f, pivotOffset.y);
        }
        else
        {
          num5 = Mathf.Lerp(0.0f, (float) num4 * this.cellWidth, pivotOffset.x);
          num6 = Mathf.Lerp((float) -num3 * this.cellHeight, 0.0f, pivotOffset.y);
        }
        for (int index = 0; index < transform1.childCount; ++index)
        {
          Transform child = transform1.GetChild(index);
          if (NGUITools.GetActive(((Component) child).gameObject) || !this.hideInactive)
          {
            SpringPosition component = ((Component) child).GetComponent<SpringPosition>();
            if (Object.op_Inequality((Object) component, (Object) null))
            {
              component.target.x -= num5;
              component.target.y -= num6;
            }
            else
            {
              Vector3 localPosition = child.localPosition;
              localPosition.x -= num5;
              localPosition.y -= num6;
              child.localPosition = localPosition;
            }
          }
        }
      }
      if (this.keepWithinPanel && Object.op_Inequality((Object) this.mPanel, (Object) null))
        this.mPanel.ConstrainTargetToBounds(transform1, true);
      if (this.onReposition == null)
        return;
      this.onReposition();
    }
  }

  public enum Arrangement
  {
    Horizontal,
    Vertical,
  }

  public enum Sorting
  {
    None,
    Alphabetic,
    Horizontal,
    Vertical,
    Custom,
  }

  public delegate void OnReposition();
}
