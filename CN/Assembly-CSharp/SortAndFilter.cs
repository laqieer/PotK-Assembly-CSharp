// Decompiled with JetBrains decompiler
// Type: SortAndFilter
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System.Collections.Generic;

#nullable disable
public class SortAndFilter : BackButtonMenuBase
{
  protected System.Action sortAction;

  public virtual void Initialize(System.Action SortAction) => this.sortAction = SortAction;

  public void IbtnFilter<Type>(List<Type> list, Type e, SortAndFilterButton button)
  {
    if (list.Contains(e))
      list.Remove(e);
    else
      list.Add(e);
    this.GrayCheck<Type>(list, e, button);
  }

  public void GrayCheck<Type>(List<Type> list, Type e, SortAndFilterButton button)
  {
    if (list.Contains(e))
      button.SpriteColorGray(true);
    else
      button.SpriteColorGray(false);
  }

  public virtual void IbtnOrderBuySort(SortAndFilter.SORT_TYPE_ORDER_BUY sort)
  {
  }

  public virtual void IbtnAllSelect()
  {
  }

  public virtual void IbtnClear()
  {
  }

  public virtual void IbtnDicision()
  {
  }

  public virtual void IbtnClose() => Singleton<PopupManager>.GetInstance().onDismiss();

  public void IbtnNo() => this.IbtnClose();

  public override void onBackButton() => this.IbtnNo();

  public virtual void IbtnOrder()
  {
  }

  public virtual void IbtnOrderDec()
  {
  }

  public virtual void SaveData()
  {
  }

  public enum SORT_TYPE_ORDER_BUY
  {
    ASCENDING,
    DESCENDING,
  }

  public enum SORT_TYPE
  {
    NEW,
    RARE,
    NUMBER,
  }
}
