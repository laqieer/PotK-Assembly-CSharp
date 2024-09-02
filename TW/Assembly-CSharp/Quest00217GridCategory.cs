// Decompiled with JetBrains decompiler
// Type: Quest00217GridCategory
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UniLinq;
using UnityEngine;

#nullable disable
public class Quest00217GridCategory : MonoBehaviour
{
  [SerializeField]
  private UIGrid grid_;
  [SerializeField]
  private GameObject bgTitle_;
  [SerializeField]
  private UILabel txtTitle_;
  private int id_;
  private List<Quest00217GridCategory.Unit> units_ = new List<Quest00217GridCategory.Unit>();

  public int ID => this.id_;

  public void init(int id, string title, GameObject titleFitter)
  {
    this.id_ = id;
    this.txtTitle_.SetTextLocalize(title);
    if (!Object.op_Inequality((Object) titleFitter, (Object) null) || !Object.op_Inequality((Object) this.bgTitle_, (Object) null))
      return;
    UIRect component = this.bgTitle_.GetComponent<UIRect>();
    if (!Object.op_Inequality((Object) component, (Object) null))
      return;
    component.leftAnchor.target = titleFitter.transform;
    component.rightAnchor.target = titleFitter.transform;
    component.ResetAnchors();
    component.Update();
    component.leftAnchor.target = (Transform) null;
    component.rightAnchor.target = (Transform) null;
  }

  public GameObject[] aItem
  {
    get
    {
      return this.units_.Select<Quest00217GridCategory.Unit, GameObject>((Func<Quest00217GridCategory.Unit, GameObject>) (u => u.item)).ToArray<GameObject>();
    }
  }

  public Bounds[] aBounds
  {
    get
    {
      return this.units_.Select<Quest00217GridCategory.Unit, Bounds>((Func<Quest00217GridCategory.Unit, Bounds>) (u => u.bounds)).ToArray<Bounds>();
    }
  }

  public List<Quest00217GridCategory.Unit> units => this.units_;

  public List<GameObject> items
  {
    get
    {
      return this.units_.Select<Quest00217GridCategory.Unit, GameObject>((Func<Quest00217GridCategory.Unit, GameObject>) (u => u.item)).ToList<GameObject>();
    }
  }

  public List<T> getItems<T>()
  {
    return this.items.Select<GameObject, T>((Func<GameObject, T>) (i => i.GetComponent<T>())).Where<T>((Func<T, bool>) (c => (object) c != null)).ToList<T>();
  }

  public int setItem(GameObject item)
  {
    if (Object.op_Equality((Object) item, (Object) null))
      return -1;
    Transform transform = item.transform;
    transform.parent = ((Component) this.grid_).gameObject.transform;
    transform.localPosition = Vector3.zero;
    transform.localRotation = Quaternion.identity;
    transform.localScale = Vector3.one;
    int count = this.units_.Count;
    this.units_.Add(new Quest00217GridCategory.Unit(item));
    return count;
  }

  public bool deleteItem(int index)
  {
    if (index < 0 || this.units_.Count <= index)
      return false;
    Object.Destroy((Object) this.units_[index].item);
    this.units_.RemoveAt(index);
    this.grid_.Reposition();
    return true;
  }

  public bool deleteItem(GameObject item)
  {
    for (int index = 0; index < this.units_.Count; ++index)
    {
      Quest00217GridCategory.Unit unit = this.units_[index];
      if (Object.op_Equality((Object) unit.item, (Object) item))
      {
        Object.Destroy((Object) unit.item);
        this.units_.RemoveAt(index);
        this.grid_.Reposition();
        return true;
      }
    }
    return false;
  }

  public void deleteItemAll()
  {
    if (this.units_.Count == 0)
      return;
    foreach (Object @object in this.items)
      Object.Destroy(@object);
    this.units_.Clear();
    this.grid_.Reposition();
  }

  public Vector2 calcSimpleWidgetSize()
  {
    return new Vector2(this.grid_.cellWidth, Mathf.Abs(((Component) this.grid_).gameObject.transform.localPosition.y) + this.grid_.cellHeight * (float) this.units_.Count);
  }

  public Vector2 calcWidgetSize()
  {
    Bounds relativeWidgetBounds = NGUIMath.CalculateRelativeWidgetBounds(((Component) this).gameObject.transform);
    return Vector2.op_Implicit(((Bounds) ref relativeWidgetBounds).size);
  }

  public class Unit
  {
    private GameObject item_;
    private bool initialized_;
    private Bounds bounds_;
    private bool inside_;

    public Unit(GameObject item)
    {
      this.item_ = item;
      this.initialized_ = false;
      this.inside_ = item.activeSelf;
    }

    public GameObject item => this.item_;

    public bool initialized => this.initialized_;

    public Bounds bounds
    {
      get
      {
        if (!this.initialized_)
        {
          this.initialized_ = true;
          this.bounds_ = NGUIMath.CalculateRelativeWidgetBounds(this.item_.transform);
        }
        return this.bounds_;
      }
    }

    public bool inside => this.inside_;

    public void setInside(bool flagIn) => this.inside_ = flagIn;
  }
}
