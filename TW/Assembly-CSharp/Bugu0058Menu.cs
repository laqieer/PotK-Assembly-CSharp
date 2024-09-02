// Decompiled with JetBrains decompiler
// Type: Bugu0058Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class Bugu0058Menu : BackButtonMenuBase
{
  private const int MAX_SELECT = 5;
  [SerializeField]
  private GearNameTypeRarity gearHeader;
  [SerializeField]
  private UI2DSprite gearRank;
  [SerializeField]
  private Sprite[] gearRankList;
  [SerializeField]
  private UI2DSprite gearImg;
  [SerializeField]
  private GearStatusUpParam gearHP;
  [SerializeField]
  private GearStatusUpParam gearSTR;
  [SerializeField]
  private GearStatusUpParam gearMGC;
  [SerializeField]
  private GearStatusUpParam gearDEF;
  [SerializeField]
  private GearStatusUpParam gearMND;
  [SerializeField]
  private GearStatusUpParam gearSPD;
  [SerializeField]
  private GearStatusUpParam gearTEC;
  [SerializeField]
  private GearStatusUpParam gearLUC;
  [SerializeField]
  private List<GearAddMaterial> gearMaterialList = new List<GearAddMaterial>();
  [SerializeField]
  private UILabel lblSpendZeny;
  [SerializeField]
  private UIButton upgradeButton;
  [SerializeField]
  private UIButton autoSelectButton;
  [SerializeField]
  private bool resetFlag;
  private GameCore.ItemInfo gearEntryBase;
  private List<GameCore.ItemInfo> gearEntryMaterial = new List<GameCore.ItemInfo>();
  private List<GameCore.ItemInfo> AutoSelectList = new List<GameCore.ItemInfo>();
  private List<PlayerItem> UpdatePlayerItem;

  public void IbtnBack()
  {
    if (this.IsPushAndSet())
      return;
    this.backScene();
  }

  public override void onBackButton() => this.IbtnBack();

  public void IbtnChageBugu()
  {
    if (this.IsPushAndSet())
      return;
    Bugu00522Scene.ChangeScene(true);
  }

  public void IbtnMaterialSelect()
  {
    if (this.IsPushAndSet())
      return;
    Bugu00523Scene.ChangeScene(false, this.gearEntryMaterial, this.gearEntryBase);
  }

  public void IbtnPakuPaku()
  {
    if (this.IsPushAndSet())
      return;
    this.StartCoroutine(this.PakuPakuAPIEvent());
  }

  [DebuggerHidden]
  public IEnumerator PakuPakuAPIEvent()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu0058Menu.\u003CPakuPakuAPIEvent\u003Ec__Iterator3E3()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator PakuPakuAPI()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu0058Menu.\u003CPakuPakuAPI\u003Ec__Iterator3E4()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void CreateAutoSelectList()
  {
    this.AutoSelectList = (List<GameCore.ItemInfo>) null;
    this.AutoSelectList = new List<GameCore.ItemInfo>();
    List<Bugu0058Menu.PlayerItemSort> playerItemSortList = new List<Bugu0058Menu.PlayerItemSort>();
    Bugu0058Menu.GetAutoSelectList(playerItemSortList, this.gearEntryBase.gearBuildupParam.agility_add, GearKindEnum.sword);
    Bugu0058Menu.GetAutoSelectList(playerItemSortList, this.gearEntryBase.gearBuildupParam.strength_add, GearKindEnum.axe);
    Bugu0058Menu.GetAutoSelectList(playerItemSortList, this.gearEntryBase.gearBuildupParam.vitality_add, GearKindEnum.spear);
    Bugu0058Menu.GetAutoSelectList(playerItemSortList, this.gearEntryBase.gearBuildupParam.dexterity_add, GearKindEnum.bow);
    Bugu0058Menu.GetAutoSelectList(playerItemSortList, this.gearEntryBase.gearBuildupParam.intelligence_add, GearKindEnum.gun);
    Bugu0058Menu.GetAutoSelectList(playerItemSortList, this.gearEntryBase.gearBuildupParam.mind_add, GearKindEnum.staff);
    Bugu0058Menu.GetAutoSelectList(playerItemSortList, this.gearEntryBase.gearBuildupParam.hp_add, GearKindEnum.shield);
    List<Bugu0058Menu.PlayerItemSort> list = playerItemSortList.Where<Bugu0058Menu.PlayerItemSort>((Func<Bugu0058Menu.PlayerItemSort, bool>) (x => x.item.id != this.gearEntryBase.itemID)).Where<Bugu0058Menu.PlayerItemSort>((Func<Bugu0058Menu.PlayerItemSort, bool>) (x => !x.item.broken)).Where<Bugu0058Menu.PlayerItemSort>((Func<Bugu0058Menu.PlayerItemSort, bool>) (x => !x.item.favorite)).Where<Bugu0058Menu.PlayerItemSort>((Func<Bugu0058Menu.PlayerItemSort, bool>) (x => !x.item.ForBattle)).ToList<Bugu0058Menu.PlayerItemSort>();
    int num = 0;
    foreach (Bugu0058Menu.PlayerItemSort playerItemSort in list.OrderBy<Bugu0058Menu.PlayerItemSort, int>((Func<Bugu0058Menu.PlayerItemSort, int>) (x => x.index)).ToList<Bugu0058Menu.PlayerItemSort>())
    {
      if (num < 5)
      {
        GameCore.ItemInfo itemInfo = new GameCore.ItemInfo(playerItemSort.item);
        this.AutoSelectList.Add(itemInfo);
        if (!this.CheckZeny(CalcItemCost.GetBuildupCost(this.AutoSelectList)))
        {
          this.AutoSelectList.Remove(itemInfo);
          break;
        }
        ++num;
      }
      else
        break;
    }
    if (this.AutoSelectList.Count == 0)
      this.autoSelectButton.isEnabled = false;
    else
      this.autoSelectButton.isEnabled = true;
  }

  private void IbtnAutoSelect()
  {
    this.InitSpendZeny();
    this.gearEntryMaterial = (List<GameCore.ItemInfo>) null;
    this.gearEntryMaterial = this.AutoSelectList;
    this.StartCoroutine(this.SetMenuAsync(this.gearEntryBase, this.gearEntryMaterial));
  }

  public static void GetAutoSelectList(
    List<Bugu0058Menu.PlayerItemSort> addList,
    int baseParam,
    GearKindEnum gearEnum,
    bool rarityLimit = true)
  {
    int? nullable = ((IEnumerable<GearBuildupLogic>) MasterData.GearBuildupLogicList).FirstIndexOrNull<GearBuildupLogic>((Func<GearBuildupLogic, bool>) (x => x.base_param == baseParam));
    if (!nullable.HasValue)
      return;
    GearBuildupLogic gearBuildupLogic = MasterData.GearBuildupLogicList[nullable.Value];
    int rbl = 0;
    for (int gear_level = 1; gear_level <= gearBuildupLogic.MaterialRankCount(); ++gear_level)
    {
      if (0 < gearBuildupLogic.MaterialRank(gear_level))
      {
        rbl = gear_level;
        break;
      }
    }
    List<PlayerItem> list1 = ((IEnumerable<PlayerItem>) SMManager.Get<PlayerItem[]>()).Where<PlayerItem>((Func<PlayerItem, bool>) (x => x.gear != null)).Where<PlayerItem>((Func<PlayerItem, bool>) (x => x.gear.kind.isEquip)).ToList<PlayerItem>();
    if (rarityLimit)
      list1 = list1.Where<PlayerItem>((Func<PlayerItem, bool>) (x => x.gear.rarity.index < 3)).OrderBy<PlayerItem, int>((Func<PlayerItem, int>) (x => x.gear.rarity.index)).ToList<PlayerItem>();
    List<PlayerItem> list2 = list1.Where<PlayerItem>((Func<PlayerItem, bool>) (x => x.gear.kind.Enum == gearEnum)).Where<PlayerItem>((Func<PlayerItem, bool>) (x => x.gear_level >= rbl)).ToList<PlayerItem>();
    for (int index = 0; index < list2.Count; ++index)
      addList.Add(new Bugu0058Menu.PlayerItemSort()
      {
        index = index,
        item = list2[index]
      });
  }

  [DebuggerHidden]
  public IEnumerator SetMenuAsync(GameCore.ItemInfo gearData, List<GameCore.ItemInfo> gearMaterialData)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu0058Menu.\u003CSetMenuAsync\u003Ec__Iterator3E5()
    {
      gearData = gearData,
      gearMaterialData = gearMaterialData,
      \u003C\u0024\u003EgearData = gearData,
      \u003C\u0024\u003EgearMaterialData = gearMaterialData,
      \u003C\u003Ef__this = this
    };
  }

  private void Init()
  {
    this.InitGearHeader();
    this.InitGearStatusUpParam();
    this.InitGearRank();
    this.InitSpendZeny();
    this.InitGearMaterialList();
  }

  [DebuggerHidden]
  private IEnumerator SetGearImg(GameCore.ItemInfo gearData)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu0058Menu.\u003CSetGearImg\u003Ec__Iterator3E6()
    {
      gearData = gearData,
      \u003C\u0024\u003EgearData = gearData,
      \u003C\u003Ef__this = this
    };
  }

  private void InitGearHeader() => this.gearHeader.Init();

  private void SetGearHeader(GameCore.ItemInfo gearData) => this.gearHeader.Set(gearData);

  private void InitGearStatusUpParam()
  {
    this.gearHP.Init();
    this.gearSTR.Init();
    this.gearMGC.Init();
    this.gearDEF.Init();
    this.gearMND.Init();
    this.gearSPD.Init();
    this.gearTEC.Init();
    this.gearLUC.Init();
  }

  private void SetGearStatusUpParam(GameCore.ItemInfo gearBaseData, List<GameCore.ItemInfo> gearMaterialData)
  {
    this.gearHP.SetCalcStatus(gearBaseData.gear.hp_buildup_limit, gearBaseData.gear.hp_incremental, gearBaseData.gearBuildupParam.hp_add, gearMaterialData, GearKindEnum.shield);
    this.gearSTR.SetCalcStatus(gearBaseData.gear.strength_buildup_limit, gearBaseData.gear.strength_incremental, gearBaseData.gearBuildupParam.strength_add, gearMaterialData, GearKindEnum.axe);
    this.gearMGC.SetCalcStatus(gearBaseData.gear.intelligence_buildup_limit, gearBaseData.gear.intelligence_incremental, gearBaseData.gearBuildupParam.intelligence_add, gearMaterialData, GearKindEnum.gun);
    this.gearDEF.SetCalcStatus(gearBaseData.gear.vitality_buildup_limit, gearBaseData.gear.vitality_incremental, gearBaseData.gearBuildupParam.vitality_add, gearMaterialData, GearKindEnum.spear);
    this.gearMND.SetCalcStatus(gearBaseData.gear.mind_buildup_limit, gearBaseData.gear.mind_incremental, gearBaseData.gearBuildupParam.mind_add, gearMaterialData, GearKindEnum.staff);
    this.gearSPD.SetCalcStatus(gearBaseData.gear.agility_buildup_limit, gearBaseData.gear.agility_incremental, gearBaseData.gearBuildupParam.agility_add, gearMaterialData, GearKindEnum.sword);
    this.gearTEC.SetCalcStatus(gearBaseData.gear.dexterity_buildup_limit, gearBaseData.gear.dexterity_incremental, gearBaseData.gearBuildupParam.dexterity_add, gearMaterialData, GearKindEnum.bow);
    this.gearLUC.SetCalcStatus(gearBaseData.gear.lucky_buildup_limit, gearBaseData.gear.lucky_incremental, gearBaseData.gearBuildupParam.lucky_add, gearMaterialData, GearKindEnum.accessories);
  }

  private void InitGearMaterialList()
  {
    this.gearMaterialList.ForEach((Action<GearAddMaterial>) (x => x.Init()));
  }

  [DebuggerHidden]
  private IEnumerator SetGearMaterialList(GameCore.ItemInfo gearData, List<GameCore.ItemInfo> gearMaterialData)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu0058Menu.\u003CSetGearMaterialList\u003Ec__Iterator3E7()
    {
      gearData = gearData,
      gearMaterialData = gearMaterialData,
      \u003C\u0024\u003EgearData = gearData,
      \u003C\u0024\u003EgearMaterialData = gearMaterialData,
      \u003C\u003Ef__this = this
    };
  }

  private void InitGearRank() => ((Component) this.gearRank).gameObject.SetActive(false);

  private void InitSpendZeny()
  {
    this.SetSpendZeny(0);
    this.upgradeButton.isEnabled = false;
  }

  private void SetGearRank(GameCore.ItemInfo gear)
  {
    ((Component) this.gearRank).gameObject.SetActive(true);
    this.gearRank.sprite2D = this.gearRankList[gear.gearLevel - 1];
  }

  private void SetCalcSpendZeny(GameCore.ItemInfo gearData, List<GameCore.ItemInfo> gearMaterialData)
  {
    int buildupCost = CalcItemCost.GetBuildupCost(gearMaterialData);
    if (!this.CheckZeny(buildupCost))
      return;
    this.SetSpendZeny(buildupCost);
    this.upgradeButton.isEnabled = true;
  }

  private void SetSpendZeny(int spendZeny) => this.lblSpendZeny.SetTextLocalize(spendZeny);

  private bool CheckZeny(int useZeny) => useZeny != 0 && SMManager.Get<Player>().CheckZeny(useZeny);

  [Serializable]
  public class PlayerItemSort
  {
    public int index;
    public PlayerItem item;
  }
}
