// Decompiled with JetBrains decompiler
// Type: Bugu0058Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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
  private PlayerItem gearEntryBase;
  private List<PlayerItem> gearEntryMaterial = new List<PlayerItem>();
  private List<PlayerItem> AutoSelectList = new List<PlayerItem>();
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
    Bugu0052Scene.changeScenePakuPakuBase(true, true);
  }

  public void IbtnMaterialSelect()
  {
    if (this.IsPushAndSet())
      return;
    Bugu0052Scene.changeScenePakuPakuMaterial(false, true, this.gearEntryMaterial, this.gearEntryBase);
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
    return (IEnumerator) new Bugu0058Menu.\u003CPakuPakuAPIEvent\u003Ec__Iterator346()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator PakuPakuAPI()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu0058Menu.\u003CPakuPakuAPI\u003Ec__Iterator347()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void CreateAutoSelectList()
  {
    this.AutoSelectList = (List<PlayerItem>) null;
    this.AutoSelectList = new List<PlayerItem>();
    List<Bugu0058Menu.PlayerItemSort> playerItemSortList = new List<Bugu0058Menu.PlayerItemSort>();
    Bugu0058Menu.GetAutoSelectList(playerItemSortList, this.gearEntryBase.gear_buildup_param.agility_add, GearKindEnum.sword);
    Bugu0058Menu.GetAutoSelectList(playerItemSortList, this.gearEntryBase.gear_buildup_param.strength_add, GearKindEnum.axe);
    Bugu0058Menu.GetAutoSelectList(playerItemSortList, this.gearEntryBase.gear_buildup_param.vitality_add, GearKindEnum.spear);
    Bugu0058Menu.GetAutoSelectList(playerItemSortList, this.gearEntryBase.gear_buildup_param.dexterity_add, GearKindEnum.bow);
    Bugu0058Menu.GetAutoSelectList(playerItemSortList, this.gearEntryBase.gear_buildup_param.intelligence_add, GearKindEnum.gun);
    Bugu0058Menu.GetAutoSelectList(playerItemSortList, this.gearEntryBase.gear_buildup_param.mind_add, GearKindEnum.staff);
    Bugu0058Menu.GetAutoSelectList(playerItemSortList, this.gearEntryBase.gear_buildup_param.hp_add, GearKindEnum.shield);
    List<Bugu0058Menu.PlayerItemSort> list = playerItemSortList.Where<Bugu0058Menu.PlayerItemSort>((Func<Bugu0058Menu.PlayerItemSort, bool>) (x => x.item.id != this.gearEntryBase.id)).Where<Bugu0058Menu.PlayerItemSort>((Func<Bugu0058Menu.PlayerItemSort, bool>) (x => !x.item.broken)).Where<Bugu0058Menu.PlayerItemSort>((Func<Bugu0058Menu.PlayerItemSort, bool>) (x => !x.item.favorite)).Where<Bugu0058Menu.PlayerItemSort>((Func<Bugu0058Menu.PlayerItemSort, bool>) (x => !x.item.ForBattle)).ToList<Bugu0058Menu.PlayerItemSort>();
    int num = 0;
    foreach (Bugu0058Menu.PlayerItemSort playerItemSort in list.OrderBy<Bugu0058Menu.PlayerItemSort, int>((Func<Bugu0058Menu.PlayerItemSort, int>) (x => x.index)).ToList<Bugu0058Menu.PlayerItemSort>())
    {
      if (num < 5)
      {
        this.AutoSelectList.Add(playerItemSort.item);
        if (!this.CheckZeny(Bugu0058Menu.CalcSpendZeny(this.AutoSelectList)))
        {
          this.AutoSelectList.Remove(playerItemSort.item);
          break;
        }
        ++num;
      }
      else
        break;
    }
    ((Behaviour) this.autoSelectButton).enabled = false;
    if (this.AutoSelectList.Count == 0)
      ((Component) this.autoSelectButton).GetComponent<Collider>().enabled = false;
    else
      ((Component) this.autoSelectButton).GetComponent<Collider>().enabled = true;
    ((Behaviour) this.autoSelectButton).enabled = true;
  }

  private void IbtnAutoSelect()
  {
    this.InitSpendZeny();
    this.gearEntryMaterial = (List<PlayerItem>) null;
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
  public IEnumerator onInitMenuAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Bugu0058Menu.\u003ConInitMenuAsync\u003Ec__Iterator348 asyncCIterator348 = new Bugu0058Menu.\u003ConInitMenuAsync\u003Ec__Iterator348();
    return (IEnumerator) asyncCIterator348;
  }

  [DebuggerHidden]
  public IEnumerator SetMenuAsync(PlayerItem gearData, List<PlayerItem> gearMaterialData)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu0058Menu.\u003CSetMenuAsync\u003Ec__Iterator349()
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
  private IEnumerator SetGearImg(PlayerItem gearData)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu0058Menu.\u003CSetGearImg\u003Ec__Iterator34A()
    {
      gearData = gearData,
      \u003C\u0024\u003EgearData = gearData,
      \u003C\u003Ef__this = this
    };
  }

  private void InitGearHeader() => this.gearHeader.Init();

  private void SetGearHeader(PlayerItem gearData) => this.gearHeader.Set(gearData);

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

  private void SetGearStatusUpParam(PlayerItem gearBaseData, List<PlayerItem> gearMaterialData)
  {
    this.gearHP.SetCalcStatus(gearBaseData.gear.hp_buildup_limit, gearBaseData.gear.hp_incremental, gearBaseData.gear_buildup_param.hp_add, gearMaterialData, GearKindEnum.shield);
    this.gearSTR.SetCalcStatus(gearBaseData.gear.strength_buildup_limit, gearBaseData.gear.strength_incremental, gearBaseData.gear_buildup_param.strength_add, gearMaterialData, GearKindEnum.axe);
    this.gearMGC.SetCalcStatus(gearBaseData.gear.intelligence_buildup_limit, gearBaseData.gear.intelligence_incremental, gearBaseData.gear_buildup_param.intelligence_add, gearMaterialData, GearKindEnum.gun);
    this.gearDEF.SetCalcStatus(gearBaseData.gear.vitality_buildup_limit, gearBaseData.gear.vitality_incremental, gearBaseData.gear_buildup_param.vitality_add, gearMaterialData, GearKindEnum.spear);
    this.gearMND.SetCalcStatus(gearBaseData.gear.mind_buildup_limit, gearBaseData.gear.mind_incremental, gearBaseData.gear_buildup_param.mind_add, gearMaterialData, GearKindEnum.staff);
    this.gearSPD.SetCalcStatus(gearBaseData.gear.agility_buildup_limit, gearBaseData.gear.agility_incremental, gearBaseData.gear_buildup_param.agility_add, gearMaterialData, GearKindEnum.sword);
    this.gearTEC.SetCalcStatus(gearBaseData.gear.dexterity_buildup_limit, gearBaseData.gear.dexterity_incremental, gearBaseData.gear_buildup_param.dexterity_add, gearMaterialData, GearKindEnum.bow);
    this.gearLUC.SetCalcStatus(gearBaseData.gear.lucky_buildup_limit, gearBaseData.gear.lucky_incremental, gearBaseData.gear_buildup_param.lucky_add, gearMaterialData, GearKindEnum.accessories);
  }

  private void InitGearMaterialList()
  {
    this.gearMaterialList.ForEach((Action<GearAddMaterial>) (x => x.Init()));
  }

  [DebuggerHidden]
  private IEnumerator SetGearMaterialList(PlayerItem gearData, List<PlayerItem> gearMaterialData)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu0058Menu.\u003CSetGearMaterialList\u003Ec__Iterator34B()
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
    ((Behaviour) this.upgradeButton).enabled = false;
    ((Component) this.upgradeButton).GetComponent<Collider>().enabled = false;
    ((Behaviour) this.upgradeButton).enabled = true;
  }

  private void SetGearRank(PlayerItem gear)
  {
    ((Component) this.gearRank).gameObject.SetActive(true);
    this.gearRank.sprite2D = this.gearRankList[gear.gear_level - 1];
  }

  private void SetCalcSpendZeny(PlayerItem gearData, List<PlayerItem> gearMaterialData)
  {
    int num = Bugu0058Menu.CalcSpendZeny(gearMaterialData);
    if (!this.CheckZeny(num))
      return;
    this.SetSpendZeny(num);
    ((Behaviour) this.upgradeButton).enabled = false;
    ((Component) this.upgradeButton).GetComponent<Collider>().enabled = true;
    ((Behaviour) this.upgradeButton).enabled = true;
  }

  private void SetSpendZeny(int spendZeny) => this.lblSpendZeny.SetTextLocalize(spendZeny);

  private bool CheckZeny(int useZeny) => useZeny != 0 && SMManager.Get<Player>().CheckZeny(useZeny);

  public static int CalcSpendZeny(List<PlayerItem> gearMaterialData)
  {
    int num = 0;
    foreach (PlayerItem playerItem in gearMaterialData)
    {
      GearKindEnum kind = playerItem.gear.kind.Enum;
      int rank = playerItem.gear_level;
      num += ((IEnumerable<GearBuildup>) MasterData.GearBuildupList).Where<GearBuildup>((Func<GearBuildup, bool>) (x => x.kind.Enum == kind && x.rank == rank)).First<GearBuildup>().amount;
    }
    return num;
  }

  [Serializable]
  public class PlayerItemSort
  {
    public int index;
    public PlayerItem item;
  }
}
