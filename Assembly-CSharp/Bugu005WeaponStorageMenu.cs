// Decompiled with JetBrains decompiler
// Type: Bugu005WeaponStorageMenu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using SM;
using System;
using System.Collections.Generic;
using UniLinq;
using UnityEngine;

public class Bugu005WeaponStorageMenu : Bugu005ItemListMenuBase
{
  private bool needClearCache = true;

  public override Persist<Persist.ItemSortAndFilterInfo> GetPersist() => Persist.bugu005WeaponMaterialListSortAndFilter;

  protected override List<PlayerMaterialGear> GetMaterialList() => ((IEnumerable<PlayerMaterialGear>) SMManager.Get<PlayerMaterialGear[]>()).Where<PlayerMaterialGear>((Func<PlayerMaterialGear, bool>) (x => x.isWeaponMaterial())).ToList<PlayerMaterialGear>();

  protected virtual void OnEnable()
  {
    if (!this.scroll.scrollView.isDragging)
      return;
    this.scroll.scrollView.Press(false);
  }

  public void onBackScene()
  {
    if ((UnityEngine.Object) this.SortPopupPrefab != (UnityEngine.Object) null)
      this.SortPopupPrefab.GetComponent<ItemSortAndFilter>().Initialize((Bugu005ItemListMenuBase) this);
    float y = this.scroll.scrollView.verticalScrollBar.value;
    this.Sort(this.SortCategory, this.OrderBuySort, this.isEquipFirst);
    this.scroll.ResolvePosition(new Vector2(0.0f, y));
    this.needClearCache = true;
  }

  public override void onEndScene()
  {
    base.onEndScene();
    Persist.sortOrder.Flush();
    if (!this.needClearCache)
      return;
    ItemIcon.ClearCache();
  }

  public void IbtnWeaponList()
  {
    if (this.IsPushAndSet())
      return;
    Bugu0052Scene.ChangeScene(false);
  }

  public void IbtnSell()
  {
    if (this.IsPushAndSet())
      return;
    this.needClearCache = false;
    Bugu00525Scene.ChangeScene(true, Bugu00525Scene.Mode.WeaponMaterial);
  }

  public void IbtnConversion()
  {
    if (this.IsPushAndSet())
      return;
    this.needClearCache = false;
    Bugu005WeaponMaterialConversionScene.ChangeScene(true, Bugu005WeaponMaterialConversionScene.Mode.WeaponMaterial);
  }
}
