// Decompiled with JetBrains decompiler
// Type: Battle01StatusScrollParts
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
[RequireComponent(typeof (NGHorizontalScrollParts))]
public class Battle01StatusScrollParts : BattleMonoBehaviour
{
  private GameObject unitScrollContainer;
  private NGHorizontalScrollParts scrollParts;
  private BL.BattleModified<BL.CurrentUnit> modified;
  private BL.ForceID forceId;
  private BattleAIController _aiController;
  private int firstSelected = -1;

  private BattleAIController aiController
  {
    get
    {
      if (Object.op_Equality((Object) this._aiController, (Object) null))
        this._aiController = this.battleManager.getController<BattleAIController>();
      return this._aiController;
    }
  }

  [DebuggerHidden]
  public override IEnumerator onInitAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Battle01StatusScrollParts.\u003ConInitAsync\u003Ec__Iterator92B()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  protected override IEnumerator Start_Battle()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Battle01StatusScrollParts.\u003CStart_Battle\u003Ec__Iterator92C()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator doSetItemPosition(int idx)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Battle01StatusScrollParts.\u003CdoSetItemPosition\u003Ec__Iterator92D()
    {
      idx = idx,
      \u003C\u0024\u003Eidx = idx,
      \u003C\u003Ef__this = this
    };
  }

  public void initParts(BL.ForceID forceId, int idx = 0)
  {
    this.forceId = forceId;
    List<BL.Unit> unitList;
    switch (forceId)
    {
      case BL.ForceID.player:
        unitList = this.env.core.playerUnits.value;
        break;
      case BL.ForceID.neutral:
        unitList = this.env.core.neutralUnits.value;
        break;
      case BL.ForceID.enemy:
        unitList = this.env.core.enemyUnits.value;
        break;
      default:
        return;
    }
    if (unitList.Count == 0 || idx >= unitList.Count)
      return;
    this.scrollParts.destroyParts();
    foreach (BL.Unit unit in unitList)
    {
      if (unit.isEnable)
        this.scrollParts.instantiateParts(this.unitScrollContainer).GetComponent<Battle01UIPlayerStatus>().setUnit(unit);
    }
    this.scrollParts.resetScrollView();
    this.StartCoroutine(this.doSetItemPosition(idx));
  }

  private int unitsIndexOf(BL.Unit unit, ref BL.ForceID forceId)
  {
    if (forceId == BL.ForceID.none)
      forceId = this.env.core.getForceID(unit);
    BL.ClassValue<List<BL.Unit>> classValue = this.env.core.forceUnits(forceId);
    if (classValue == null)
      return -1;
    int num = 0;
    for (int index = 0; index < classValue.value.Count; ++index)
    {
      if (classValue.value[index].isEnable)
      {
        if (classValue.value[index] == unit)
          return num;
        ++num;
      }
    }
    return -1;
  }

  public void initCurrent(int idx, BL.ForceID fid)
  {
    if (idx == -1)
      this.forceId = fid;
    else
      this.initParts(fid, idx);
  }

  public void onItemChanged(int select)
  {
    if (Object.op_Equality((Object) this.battleManager, (Object) null) || Object.op_Inequality((Object) this.aiController, (Object) null) && this.aiController.isAction)
      return;
    GameObject gameObject = this.scrollParts.getItem(select);
    if (!Object.op_Inequality((Object) gameObject, (Object) null))
      return;
    BL.Unit unit = gameObject.GetComponent<Battle01UIPlayerStatus>().getUnit();
    if (this.env.core.unitCurrent.unit == unit)
      return;
    this.battleManager.getManager<BattleTimeManager>().setCurrentUnit(unit);
  }

  protected override void LateUpdate_Battle()
  {
    if (!this.modified.isChangedOnce())
      return;
    BL.ForceID forceId = BL.ForceID.none;
    int idx = this.unitsIndexOf(this.modified.value.unit, ref forceId);
    if (forceId != this.forceId || idx == this.scrollParts.selected)
      return;
    this.scrollParts.setItemPosition(idx);
  }

  public void resetScrollPosition(BL.Unit unit)
  {
    BL.ForceID forceId = BL.ForceID.none;
    int idx = this.unitsIndexOf(unit, ref forceId);
    if (this.forceId != forceId || !Object.op_Inequality((Object) this.scrollParts, (Object) null))
      return;
    this.scrollParts.setItemPositionQuick(idx);
  }
}
