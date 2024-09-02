// Decompiled with JetBrains decompiler
// Type: Quest00217Grid
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Quest00217Grid : MonoBehaviour
{
  [SerializeField]
  private int margin_;
  [SerializeField]
  private int bottomSpace_;
  [SerializeField]
  private UIWidget mainWidget_;
  [SerializeField]
  private bool signalCulling_;
  private bool culling_;
  private float maxHeight_ = -1f;
  private UIScrollView scrollView_;
  private UIPanel cullingFrame_;
  private Vector2 lastScrollPosition_;
  private GameObject categoryTitleFitter_;
  private GameObject prefabCategory_;
  private bool modified_;
  private List<Quest00217GridCategory> categories_ = new List<Quest00217GridCategory>();
  private Quest00217Grid.EventFunction eventAfterReposition_;

  [DebuggerHidden]
  public IEnumerator initOnce(UIScrollView scrollView, GameObject categoryTitleFitter)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00217Grid.\u003CinitOnce\u003Ec__Iterator209()
    {
      scrollView = scrollView,
      categoryTitleFitter = categoryTitleFitter,
      \u003C\u0024\u003EscrollView = scrollView,
      \u003C\u0024\u003EcategoryTitleFitter = categoryTitleFitter,
      \u003C\u003Ef__this = this
    };
  }

  public Quest00217GridCategory createCategory(int id, string title)
  {
    Quest00217GridCategory component = this.categories_.Find((Predicate<Quest00217GridCategory>) (c => c.ID == id));
    if (Object.op_Equality((Object) component, (Object) null))
    {
      component = NGUITools.AddChild(((Component) this).gameObject, this.prefabCategory_).GetComponent<Quest00217GridCategory>();
      this.categories_.Add(component);
      this.modified_ = true;
    }
    component.init(id, title, this.categoryTitleFitter_);
    return component;
  }

  public void deleteCategory(int id)
  {
    this.deleteCategory(this.categories_.Find((Predicate<Quest00217GridCategory>) (c => c.ID == id)));
  }

  public void deleteCategory(Quest00217GridCategory gc)
  {
    if (!Object.op_Inequality((Object) gc, (Object) null))
      return;
    this.categories_.Remove(gc);
    Object.Destroy((Object) ((Component) gc).gameObject);
    this.modified_ = true;
  }

  public void deleteCategoryAll()
  {
    foreach (Component category in this.categories_)
      Object.Destroy((Object) category.gameObject);
    this.categories_.Clear();
  }

  public int setItem(int id, GameObject item)
  {
    Quest00217GridCategory category = this.categories_.Find((Predicate<Quest00217GridCategory>) (c => c.ID == id));
    if (Object.op_Equality((Object) category, (Object) null))
      category = this.createCategory(id, string.Format("Category:{0}", (object) id));
    if (!Object.op_Inequality((Object) category, (Object) null))
      return -1;
    this.modified_ = true;
    return category.setItem(item);
  }

  public void deleteItem(int id, int index)
  {
    Quest00217GridCategory quest00217GridCategory = this.categories_.Find((Predicate<Quest00217GridCategory>) (c => c.ID == id));
    if (!Object.op_Inequality((Object) quest00217GridCategory, (Object) null))
      return;
    this.modified_ |= quest00217GridCategory.deleteItem(index);
  }

  public void deleteItem(GameObject item)
  {
    foreach (Quest00217GridCategory category in this.categories_)
    {
      if (category.deleteItem(item))
      {
        this.modified_ = true;
        break;
      }
    }
  }

  public Quest00217GridCategory[] getCategories() => this.categories_.ToArray();

  public GameObject[] getItems()
  {
    List<GameObject> lst = new List<GameObject>();
    this.categories_.ForEach((Action<Quest00217GridCategory>) (c => lst.AddRange((IEnumerable<GameObject>) c.items)));
    return lst.ToArray();
  }

  public T[] getItems<T>()
  {
    List<T> lst = new List<T>();
    this.categories_.ForEach((Action<Quest00217GridCategory>) (c => lst.AddRange((IEnumerable<T>) c.getItems<T>())));
    return lst.ToArray();
  }

  public void resetPositionQuick()
  {
    float num = 0.0f;
    foreach (Quest00217GridCategory category in this.categories_)
    {
      ((Component) category).gameObject.transform.localPosition = new Vector3(0.0f, num);
      Vector2 vector2 = category.calcSimpleWidgetSize();
      num -= vector2.y + (float) this.margin_;
    }
  }

  public void resetPosition(Quest00217Grid.EventFunction eventAfter = null)
  {
    this.modified_ = true;
    if (eventAfter == null)
      return;
    this.eventAfterReposition_ += eventAfter;
  }

  private void Update()
  {
    if (this.modified_)
    {
      this.modified_ = false;
      this.culling_ = false;
      this.StartCoroutine(this.coReposition());
    }
    if (!this.culling_)
      return;
    Vector2 vector2_1 = Vector2.op_Implicit(((Component) this.scrollView_).gameObject.transform.localPosition);
    if (!Vector2.op_Inequality(this.lastScrollPosition_, vector2_1))
      return;
    if ((double) this.maxHeight_ <= 0.0)
    {
      foreach (Quest00217GridCategory category in this.categories_)
      {
        foreach (Quest00217GridCategory.Unit unit in category.units)
        {
          Bounds bounds = unit.bounds;
          if ((double) this.maxHeight_ < (double) ((Bounds) ref bounds).size.y)
            this.maxHeight_ = ((Bounds) ref bounds).size.y;
        }
      }
    }
    this.lastScrollPosition_ = vector2_1;
    GameObject gameObject = ((Component) this.scrollView_).gameObject;
    Vector4 finalClipRegion = this.cullingFrame_.finalClipRegion;
    Rect rect;
    // ISSUE: explicit constructor call
    ((Rect) ref rect).\u002Ector(finalClipRegion.x, finalClipRegion.y - this.maxHeight_, finalClipRegion.z, finalClipRegion.w + this.maxHeight_ * 2f);
    foreach (Quest00217GridCategory category in this.categories_)
    {
      Vector3 vector3 = ((Component) category).gameObject.transform.localPosition;
      for (Transform parent = ((Component) category).gameObject.transform.parent; Object.op_Inequality((Object) parent, (Object) null) && Object.op_Inequality((Object) ((Component) parent).gameObject, (Object) gameObject); parent = parent.parent)
        vector3 = Vector3.op_Addition(vector3, parent.localPosition);
      foreach (Quest00217GridCategory.Unit unit in category.units)
      {
        Vector2 vector2_2 = Vector2.op_Implicit(Vector3.op_Addition(unit.item.transform.localPosition, vector3));
        Bounds bounds = unit.bounds;
        bool flagIn = ((Rect) ref rect).Overlaps(new Rect(vector2_2.x, vector2_2.y + ((Bounds) ref bounds).size.y, ((Bounds) ref bounds).size.x, ((Bounds) ref bounds).size.y));
        if (unit.inside != flagIn)
        {
          unit.setInside(flagIn);
          Quest00217Scroll component = unit.item.GetComponent<Quest00217Scroll>();
          if (Object.op_Inequality((Object) component, (Object) null))
          {
            if (flagIn)
              component.onInside();
            else
              component.onOutside();
          }
          else
            unit.item.SetActive(flagIn);
        }
      }
    }
  }

  [DebuggerHidden]
  private IEnumerator coReposition()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00217Grid.\u003CcoReposition\u003Ec__Iterator20A()
    {
      \u003C\u003Ef__this = this
    };
  }

  public delegate void EventFunction();
}
