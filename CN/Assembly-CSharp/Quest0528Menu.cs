// Decompiled with JetBrains decompiler
// Type: Quest0528Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using Earth;
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
public class Quest0528Menu : BackButtonMenuBase
{
  private static readonly string chipExt = ".png__GUI__battle_mapchip__battle_mapchip_prefab";
  [SerializeField]
  private GameObject map_grid;
  [SerializeField]
  private NGHorizontalScrollParts unitInfoScroll;
  [SerializeField]
  private GameObject[] bottmoDir;
  [SerializeField]
  private UILabel txtWinningCondition;
  [SerializeField]
  private UILabel txtTotalTeamNum;
  [SerializeField]
  private UIButton ibtnBattleStart0028;
  private Quest0528Menu.BottomStatus bottomStatus;
  private GameObject battleMapChipSpritePrefab;
  private GameObject numPrefab;
  private GameObject normalPrefab;
  private GameObject gearKindPrefab;
  private GameObject unitDetailInfoPrefab;
  private GameObject battleSkillIconPrefab;
  private GameObject unitStatusPrefab;
  private GameObject skillDialogPrefab;
  private List<Quest0528Menu.FieldUnitInfo> fieldUnitInfoList = new List<Quest0528Menu.FieldUnitInfo>();
  private int unitInfoScrollPosition;
  private bool isSeEnableInit;
  private EarthExtraQuest extraQuest;

  private void SetScrollSeEnable(bool enable)
  {
    if (enable)
    {
      this.unitInfoScroll.SeEnable = false;
      this.StartCoroutine(this.WaitScrollSe(this.unitInfoScroll));
    }
    else
      this.unitInfoScroll.SeEnable = false;
  }

  [DebuggerHidden]
  private IEnumerator WaitScrollSe(NGHorizontalScrollParts obj)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest0528Menu.\u003CWaitScrollSe\u003Ec__Iterator745()
    {
      obj = obj,
      \u003C\u0024\u003Eobj = obj
    };
  }

  protected override void Update()
  {
    if (this.bottomStatus != Quest0528Menu.BottomStatus.BattleInfo || this.unitInfoScrollPosition == this.unitInfoScroll.selected)
      return;
    int index = this.unitInfoScroll.selected;
    if (this.unitInfoScroll.selected == -1)
      index = 0;
    this.EnableMapChipEffect(index);
    this.unitInfoScrollPosition = this.unitInfoScroll.selected;
  }

  public virtual void IbtnBack()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<NGSceneManager>.GetInstance().clearStack();
    Singleton<NGSceneManager>.GetInstance().destroyCurrentScene();
    Mypage051Scene.ChangeScene(false, false);
  }

  public void onBtnOrganization()
  {
    if (this.IsPushAndSet())
      return;
    int maxNum = -1;
    if (this.extraQuest != null)
      maxNum = this.extraQuest.stage.Players.Length;
    Quest0529Scene.ChangeScene(true, maxNum);
  }

  public void onBtnQuestStart()
  {
    if (this.IsPushAndSet())
      return;
    if (this.extraQuest == null)
      Singleton<EarthDataManager>.GetInstance().BattleInitStory();
    else
      Singleton<EarthDataManager>.GetInstance().BattleInitExtra(this.extraQuest);
  }

  public void onBtnDetai()
  {
    this.bottomStatus = Quest0528Menu.BottomStatus.BattleInfo;
    ((IEnumerable<GameObject>) this.bottmoDir).ToggleOnce((int) this.bottomStatus);
    this.EnableMapChipEffect(this.unitInfoScrollPosition);
    if (this.isSeEnableInit)
      return;
    this.isSeEnableInit = true;
    this.SetScrollSeEnable(true);
  }

  public void onBtnDetailClose()
  {
    this.bottomStatus = Quest0528Menu.BottomStatus.BattleStart;
    ((IEnumerable<GameObject>) this.bottmoDir).ToggleOnce((int) this.bottomStatus);
    this.DisableMapChipEffect();
  }

  public override void onBackButton() => this.IbtnBack();

  private void EnableMapChipEffect(int index)
  {
    this.fieldUnitInfoList.ForEach((Action<Quest0528Menu.FieldUnitInfo>) (x => x.mapchip.StopSelectAnim()));
    this.fieldUnitInfoList[index].mapchip.StartSelectAnim();
  }

  private void DisableMapChipEffect()
  {
    this.fieldUnitInfoList.ForEach((Action<Quest0528Menu.FieldUnitInfo>) (x => x.mapchip.StopSelectAnim()));
  }

  [DebuggerHidden]
  public IEnumerator Init(BattleStage stage)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest0528Menu.\u003CInit\u003Ec__Iterator746()
    {
      stage = stage,
      \u003C\u0024\u003Estage = stage,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator Init(EarthExtraQuest quest)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest0528Menu.\u003CInit\u003Ec__Iterator747()
    {
      quest = quest,
      \u003C\u0024\u003Equest = quest,
      \u003C\u003Ef__this = this
    };
  }

  private Quest0528Menu.FieldUnitInfo getFieldPlayerUnit(
    EarthCharacter[] characters,
    BattleStage stage,
    int mapx,
    int mapy)
  {
    Quest0528Menu.FieldUnitInfo fieldPlayerUnit = (Quest0528Menu.FieldUnitInfo) null;
    BattleStagePlayer player = ((IEnumerable<BattleStagePlayer>) stage.Players).FirstOrDefault<BattleStagePlayer>((Func<BattleStagePlayer, bool>) (x => x.initial_coordinate_x - 1 == mapx && x.initial_coordinate_y - 1 == mapy));
    if (player != null)
    {
      fieldPlayerUnit = new Quest0528Menu.FieldUnitInfo();
      fieldPlayerUnit.deck_position = player.deck_position;
      fieldPlayerUnit.unit = (PlayerUnit) null;
      fieldPlayerUnit.unitType = BL.ForceID.player;
      fieldPlayerUnit.mapchip = (Quest0528MenuMapChipNum) null;
      EarthCharacter earthCharacter = ((IEnumerable<EarthCharacter>) characters).FirstOrDefault<EarthCharacter>((Func<EarthCharacter, bool>) (x => x.battleIndex == player.deck_position));
      if (earthCharacter != null)
        fieldPlayerUnit.unit = earthCharacter.GetPlayerUnit();
    }
    return fieldPlayerUnit;
  }

  private Quest0528Menu.FieldUnitInfo getFieldEnemyUnit(BattleStage stage, int mapx, int mapy)
  {
    Quest0528Menu.FieldUnitInfo fieldEnemyUnit = (Quest0528Menu.FieldUnitInfo) null;
    BattleStageEnemy enemy = ((IEnumerable<BattleStageEnemy>) stage.Enemies).FirstOrDefault<BattleStageEnemy>((Func<BattleStageEnemy, bool>) (x => x.initial_coordinate_x - 1 == mapx && x.initial_coordinate_y - 1 == mapy));
    if (enemy != null && enemy.reinforcement == null)
    {
      fieldEnemyUnit = new Quest0528Menu.FieldUnitInfo();
      fieldEnemyUnit.deck_position = -1;
      fieldEnemyUnit.unitType = BL.ForceID.enemy;
      fieldEnemyUnit.unit = PlayerUnit.FromEnemy(enemy);
    }
    return fieldEnemyUnit;
  }

  private int getFieldPanel(BattleStage stage, int mapx, int mapy)
  {
    int fieldPanel = 1;
    int map_offset_x = stage.map_offset_x + mapx;
    int map_offset_y = stage.map_offset_y + mapy;
    ((IEnumerable<BattleMapLandform>) MasterData.BattleMapLandformList).FirstOrDefault<BattleMapLandform>((Func<BattleMapLandform, bool>) (x => stage.map.ID == x.map.ID));
    BattleMapLandform battleMapLandform = ((IEnumerable<BattleMapLandform>) MasterData.BattleMapLandformList).FirstOrDefault<BattleMapLandform>((Func<BattleMapLandform, bool>) (x => stage.map.ID == x.map.ID && x.coordinate_x == map_offset_x && x.coordinate_y == map_offset_y));
    if (battleMapLandform != null)
      fieldPanel = battleMapLandform.landform.ID;
    return fieldPanel;
  }

  [DebuggerHidden]
  private IEnumerator setupMapChipsWithInfoIndicator(BattleStage stage)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest0528Menu.\u003CsetupMapChipsWithInfoIndicator\u003Ec__Iterator748()
    {
      stage = stage,
      \u003C\u0024\u003Estage = stage,
      \u003C\u003Ef__this = this
    };
  }

  private Quest0528MenuMapChipNum cloneMapChip(
    string name,
    int size,
    GameObject prefab,
    int number,
    BL.ForceID unitType,
    GameObject numPrefab)
  {
    Quest0528MenuMapChipNum quest0528MenuMapChipNum = (Quest0528MenuMapChipNum) null;
    UISprite component = prefab.CloneAndGetComponent<UISprite>(this.map_grid);
    component.spriteName = name + Quest0528Menu.chipExt;
    component.width = size;
    component.height = size;
    if (Object.op_Inequality((Object) numPrefab, (Object) null))
    {
      quest0528MenuMapChipNum = numPrefab.CloneAndGetComponent<Quest0528MenuMapChipNum>(((Component) component).gameObject);
      quest0528MenuMapChipNum.Init(number, size, unitType);
    }
    return quest0528MenuMapChipNum;
  }

  [DebuggerHidden]
  private IEnumerator createBattleUnitInfo(List<Quest0528Menu.FieldUnitInfo> unitInfoList)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest0528Menu.\u003CcreateBattleUnitInfo\u003Ec__Iterator749()
    {
      unitInfoList = unitInfoList,
      \u003C\u0024\u003EunitInfoList = unitInfoList,
      \u003C\u003Ef__this = this
    };
  }

  public class FieldUnitInfo
  {
    public PlayerUnit unit;
    public int deck_position;
    public BL.ForceID unitType;
    public Quest0528MenuMapChipNum mapchip;
  }

  private enum BottomStatus
  {
    BattleStart,
    BattleInfo,
  }
}
