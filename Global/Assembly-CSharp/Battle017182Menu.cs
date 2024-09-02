// Decompiled with JetBrains decompiler
// Type: Battle017182Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class Battle017182Menu : BattleBackButtonMenuBase
{
  [SerializeField]
  private UILabel victory_conditions_txt;
  [SerializeField]
  private UILabel player_nb_unit_txt;
  [SerializeField]
  private UILabel enemy_nb_unit_txt;
  [SerializeField]
  private UILabel passed_turn_txt;
  [SerializeField]
  private GameObject map_grid;
  private bool isPush;
  private static string chipExt = ".png__GUI__battle_mapchip__battle_mapchip_prefab";

  [DebuggerHidden]
  protected override IEnumerator Start_Battle()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Battle017182Menu.\u003CStart_Battle\u003Ec__Iterator6F9()
    {
      \u003C\u003Ef__this = this
    };
  }

  private int countActiveUnits(List<BL.Unit> units)
  {
    int num = 0;
    foreach (BL.Unit unit in units)
    {
      if (unit.isEnable && !unit.isDead)
        ++num;
    }
    return num;
  }

  public void IbtnClose() => this.onBackButton();

  public override void onBackButton()
  {
    if (this.isPush)
      return;
    this.isPush = true;
    this.battleManager.popupDismiss();
  }

  public void IbtnRetreat()
  {
    if (this.isPush)
      return;
    this.isPush = true;
    this.StartCoroutine(this.RetreatPop());
  }

  [DebuggerHidden]
  private IEnumerator RetreatPop()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Battle017182Menu.\u003CRetreatPop\u003Ec__Iterator6FA()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator setupMapChips()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Battle017182Menu.\u003CsetupMapChips\u003Ec__Iterator6FB()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void choiceMapChip(
    int r,
    int c,
    GameObject prefab,
    int cellSize,
    List<PvpStageFormation> pvpFormation)
  {
    BL.UnitPosition fieldUnit = this.env.core.getFieldUnit(r, c);
    BL.Panel fieldPanel = this.env.core.getFieldPanel(r, c);
    UISprite targetMap = this.cloneMapChip(fieldUnit == null ? "slc_mapchip_" + (object) fieldPanel.landform.ID : (this.env.core.getForceID(fieldUnit.unit) != BL.ForceID.player ? "slc_mapchip_51" : "slc_mapchip_50"), cellSize, prefab);
    PvpStageFormation pvpStageFormation = pvpFormation.FirstOrDefault<PvpStageFormation>((Func<PvpStageFormation, bool>) (x => x.formation_x - 1 == c && x.formation_y - 1 == r));
    if (pvpFormation.Count <= 0 || pvpStageFormation == null)
      return;
    this.clonePvPFormation(targetMap, prefab, pvpStageFormation.player_order == this.battleManager.order);
  }

  private UISprite cloneMapChip(string name, int size, GameObject prefab)
  {
    UISprite component = prefab.CloneAndGetComponent<UISprite>(this.map_grid);
    component.spriteName = name + Battle017182Menu.chipExt;
    component.width = size;
    component.height = size;
    return component;
  }

  private void clonePvPFormation(UISprite targetMap, GameObject prefab, bool isMe)
  {
    UISprite component = prefab.CloneAndGetComponent<UISprite>(((Component) targetMap).transform);
    component.spriteName = this.GetFormationSpriteName(!isMe ? 1 : 0) + Battle017182Menu.chipExt;
    component.depth = targetMap.depth + 1;
    ((Component) component).transform.Clear();
    component.width = targetMap.width;
    component.height = targetMap.height;
  }

  private string GetFormationSpriteName(int order)
  {
    string formationSpriteName = string.Empty;
    switch (order)
    {
      case 0:
        formationSpriteName = "slc_mapchip_ownarea";
        break;
      case 1:
        formationSpriteName = "slc_mapchip_enemyarea";
        break;
    }
    return formationSpriteName;
  }
}
