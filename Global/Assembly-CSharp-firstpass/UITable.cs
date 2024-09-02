// Decompiled with JetBrains decompiler
// Type: UITable
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E910E095-517B-41AE-AAF8-B85E770EBAF1
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp-firstpass.dll

using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
[AddComponentMenu("NGUI/Interaction/Table")]
public class UITable : UIWidgetContainer
{
  public int columns;
  public UITable.Direction direction;
  public UITable.Sorting sorting;
  public bool hideInactive = true;
  public bool keepWithinPanel;
  public Vector2 padding = Vector2.zero;
  public UITable.OnReposition onReposition;
  protected UIPanel mPanel;
  protected bool mInitDone;
  protected bool mReposition;
  protected List<Transform> mChildren = new List<Transform>();
  [SerializeField]
  [HideInInspector]
  private bool sorted;

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

  public List<Transform> children
  {
    get
    {
      if (this.mChildren.Count == 0)
      {
        Transform transform = ((Component) this).transform;
        this.mChildren.Clear();
        for (int index = 0; index < transform.childCount; ++index)
        {
          Transform child = transform.GetChild(index);
          if (Object.op_Implicit((Object) child) && Object.op_Implicit((Object) ((Component) child).gameObject) && (!this.hideInactive || NGUITools.GetActive(((Component) child).gameObject)))
            this.mChildren.Add(child);
        }
        if (this.sorting != UITable.Sorting.None || this.sorted)
        {
          if (this.sorting == UITable.Sorting.Alphabetic)
            this.mChildren.Sort(new Comparison<Transform>(UIGrid.SortByName));
          else if (this.sorting == UITable.Sorting.Horizontal)
            this.mChildren.Sort(new Comparison<Transform>(UIGrid.SortHorizontal));
          else if (this.sorting == UITable.Sorting.Vertical)
            this.mChildren.Sort(new Comparison<Transform>(UIGrid.SortVertical));
          else
            this.Sort(this.mChildren);
        }
      }
      return this.mChildren;
    }
  }

  protected virtual void Sort(List<Transform> list)
  {
    list.Sort(new Comparison<Transform>(UIGrid.SortByName));
  }

  protected void RepositionVariableSize(List<Transform> children)
  {
    float num1 = 0.0f;
    float num2 = 0.0f;
    int length1 = this.columns <= 0 ? 1 : children.Count / this.columns + 1;
    int length2 = this.columns <= 0 ? children.Count : this.columns;
    Bounds[,] boundsArray1 = new Bounds[length1, length2];
    Bounds[] boundsArray2 = new Bounds[length2];
    Bounds[] boundsArray3 = new Bounds[length1];
    int index1 = 0;
    int index2 = 0;
    int index3 = 0;
    for (int count = children.Count; index3 < count; ++index3)
    {
      Transform child = children[index3];
      Bounds relativeWidgetBounds = NGUIMath.CalculateRelativeWidgetBounds(child, !this.hideInactive);
      Vector3 localScale = child.localScale;
      ((Bounds) ref relativeWidgetBounds).min = Vector3.Scale(((Bounds) ref relativeWidgetBounds).min, localScale);
      ((Bounds) ref relativeWidgetBounds).max = Vector3.Scale(((Bounds) ref relativeWidgetBounds).max, localScale);
      boundsArray1[index2, index1] = relativeWidgetBounds;
      ((Bounds) ref boundsArray2[index1]).Encapsulate(relativeWidgetBounds);
      ((Bounds) ref boundsArray3[index2]).Encapsulate(relativeWidgetBounds);
      if (++index1 >= this.columns && this.columns > 0)
      {
        index1 = 0;
        ++index2;
      }
    }
    int index4 = 0;
    int index5 = 0;
    int index6 = 0;
    for (int count = children.Count; index6 < count; ++index6)
    {
      Transform child = children[index6];
      Bounds bounds1 = boundsArray1[index5, index4];
      Bounds bounds2 = boundsArray2[index4];
      Bounds bounds3 = boundsArray3[index5];
      Vector3 localPosition = child.localPosition;
      localPosition.x = num1 + ((Bounds) ref bounds1).extents.x - ((Bounds) ref bounds1).center.x;
      localPosition.x += ((Bounds) ref bounds1).min.x - ((Bounds) ref bounds2).min.x + this.padding.x;
      if (this.direction == UITable.Direction.Down)
      {
        localPosition.y = -num2 - ((Bounds) ref bounds1).extents.y - ((Bounds) ref bounds1).center.y;
        localPosition.y += (float) (((double) ((Bounds) ref bounds1).max.y - (double) ((Bounds) ref bounds1).min.y - (double) ((Bounds) ref bounds3).max.y + (double) ((Bounds) ref bounds3).min.y) * 0.5) - this.padding.y;
      }
      else
      {
        localPosition.y = num2 + (((Bounds) ref bounds1).extents.y - ((Bounds) ref bounds1).center.y);
        localPosition.y -= (float) (((double) ((Bounds) ref bounds1).max.y - (double) ((Bounds) ref bounds1).min.y - (double) ((Bounds) ref bounds3).max.y + (double) ((Bounds) ref bounds3).min.y) * 0.5) - this.padding.y;
      }
      num1 += (float) ((double) ((Bounds) ref bounds2).max.x - (double) ((Bounds) ref bounds2).min.x + (double) this.padding.x * 2.0);
      child.localPosition = localPosition;
      if (++index4 >= this.columns && this.columns > 0)
      {
        index4 = 0;
        ++index5;
        num1 = 0.0f;
        num2 += ((Bounds) ref bounds3).size.y + this.padding.y * 2f;
      }
    }
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
      Transform transform = ((Component) this).transform;
      this.mChildren.Clear();
      List<Transform> children = this.children;
      if (children.Count > 0)
        this.RepositionVariableSize(children);
      if (this.keepWithinPanel && Object.op_Inequality((Object) this.mPanel, (Object) null))
      {
        this.mPanel.ConstrainTargetToBounds(transform, true);
        UIScrollView component = ((Component) this.mPanel).GetComponent<UIScrollView>();
        if (Object.op_Inequality((Object) component, (Object) null))
          component.UpdateScrollbars(true);
      }
      if (this.onReposition == null)
        return;
      this.onReposition();
    }
  }

  protected virtual void Start()
  {
    this.Init();
    this.Reposition();
    ((Behaviour) this).enabled = false;
  }

  protected virtual void Init()
  {
    this.mInitDone = true;
    this.mPanel = NGUITools.FindInParents<UIPanel>(((Component) this).gameObject);
  }

  protected virtual void LateUpdate()
  {
    if (this.mReposition)
      this.Reposition();
    ((Behaviour) this).enabled = false;
  }

  public enum Direction
  {
    Down,
    Up,
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
