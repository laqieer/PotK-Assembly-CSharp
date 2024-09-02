// Decompiled with JetBrains decompiler
// Type: Bugu005MaterialListMenu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using SM;
using System;
using System.Collections.Generic;
using UniLinq;
using UnityEngine;

#nullable disable
public class Bugu005MaterialListMenu : Bugu005ItemListMenuBase
{
  [SerializeField]
  private UIScrollView ScrollView;

  public override Persist<Persist.ItemSortAndFilterInfo> GetPersist()
  {
    return Persist.bugu005MaterialListSortAndFilter;
  }

  protected override List<PlayerMaterialGear> GetMaterialList()
  {
    return ((IEnumerable<PlayerMaterialGear>) SMManager.Get<PlayerMaterialGear[]>()).Where<PlayerMaterialGear>((Func<PlayerMaterialGear, bool>) (x => !x.isWeapon() && !x.isSupply())).ToList<PlayerMaterialGear>();
  }
}
