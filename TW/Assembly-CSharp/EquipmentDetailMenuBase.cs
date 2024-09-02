// Decompiled with JetBrains decompiler
// Type: EquipmentDetailMenuBase
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using SM;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class EquipmentDetailMenuBase : BackButtonMenuBase
{
  protected List<IncrementalInfo> GetIncrementalParams(GearGear gear)
  {
    List<IncrementalInfo> collection = new List<IncrementalInfo>();
    List<IncrementalInfo> incrementalParams = new List<IncrementalInfo>();
    IncrementalInfo incrementalInfo1 = new IncrementalInfo(Consts.GetInstance().UNIT_00443_LUCK, gear.lucky_incremental);
    if (gear.lucky_incremental > 0)
      collection.Add(incrementalInfo1);
    else if (gear.lucky_incremental < 0)
      incrementalParams.Add(incrementalInfo1);
    IncrementalInfo incrementalInfo2 = new IncrementalInfo(Consts.GetInstance().UNIT_00443_DEXTERITY, gear.dexterity_incremental);
    if (gear.dexterity_incremental > 0)
      collection.Add(incrementalInfo2);
    else if (gear.dexterity_incremental < 0)
      incrementalParams.Add(incrementalInfo2);
    IncrementalInfo incrementalInfo3 = new IncrementalInfo(Consts.GetInstance().UNIT_00443_AGILITY, gear.agility_incremental);
    if (gear.agility_incremental > 0)
      collection.Add(incrementalInfo3);
    else if (gear.agility_incremental < 0)
      incrementalParams.Add(incrementalInfo3);
    IncrementalInfo incrementalInfo4 = new IncrementalInfo(Consts.GetInstance().UNIT_00443_MIND, gear.mind_incremental);
    if (gear.mind_incremental > 0)
      collection.Add(incrementalInfo4);
    else if (gear.mind_incremental < 0)
      incrementalParams.Add(incrementalInfo4);
    IncrementalInfo incrementalInfo5 = new IncrementalInfo(Consts.GetInstance().UNIT_00443_INTELLIGENCE, gear.intelligence_incremental);
    if (gear.intelligence_incremental > 0)
      collection.Add(incrementalInfo5);
    else if (gear.intelligence_incremental < 0)
      incrementalParams.Add(incrementalInfo5);
    IncrementalInfo incrementalInfo6 = new IncrementalInfo(Consts.GetInstance().UNIT_00443_VITALITY, gear.vitality_incremental);
    if (gear.vitality_incremental > 0)
      collection.Add(incrementalInfo6);
    else if (gear.vitality_incremental < 0)
      incrementalParams.Add(incrementalInfo6);
    IncrementalInfo incrementalInfo7 = new IncrementalInfo(Consts.GetInstance().UNIT_00443_STRENGTH, gear.strength_incremental);
    if (gear.strength_incremental > 0)
      collection.Add(incrementalInfo7);
    else if (gear.strength_incremental < 0)
      incrementalParams.Add(incrementalInfo7);
    IncrementalInfo incrementalInfo8 = new IncrementalInfo(Consts.GetInstance().UNIT_00443_HP, gear.hp_incremental);
    if (gear.hp_incremental > 0)
      collection.Add(incrementalInfo8);
    else if (gear.hp_incremental < 0)
      incrementalParams.Add(incrementalInfo8);
    incrementalParams.AddRange((IEnumerable<IncrementalInfo>) collection);
    return incrementalParams;
  }

  protected List<IncrementalInfo> GetIncrementalParams(PlayerItem gear)
  {
    List<IncrementalInfo> collection = new List<IncrementalInfo>();
    List<IncrementalInfo> incrementalParams = new List<IncrementalInfo>();
    IncrementalInfo incrementalInfo1 = new IncrementalInfo(Consts.GetInstance().UNIT_00443_LUCK, gear.lucky_incremental);
    if (gear.lucky_incremental > 0)
      collection.Add(incrementalInfo1);
    else if (gear.lucky_incremental < 0)
      incrementalParams.Add(incrementalInfo1);
    IncrementalInfo incrementalInfo2 = new IncrementalInfo(Consts.GetInstance().UNIT_00443_DEXTERITY, gear.dexterity_incremental);
    if (gear.dexterity_incremental > 0)
      collection.Add(incrementalInfo2);
    else if (gear.dexterity_incremental < 0)
      incrementalParams.Add(incrementalInfo2);
    IncrementalInfo incrementalInfo3 = new IncrementalInfo(Consts.GetInstance().UNIT_00443_AGILITY, gear.agility_incremental);
    if (gear.agility_incremental > 0)
      collection.Add(incrementalInfo3);
    else if (gear.agility_incremental < 0)
      incrementalParams.Add(incrementalInfo3);
    IncrementalInfo incrementalInfo4 = new IncrementalInfo(Consts.GetInstance().UNIT_00443_MIND, gear.mind_incremental);
    if (gear.mind_incremental > 0)
      collection.Add(incrementalInfo4);
    else if (gear.mind_incremental < 0)
      incrementalParams.Add(incrementalInfo4);
    IncrementalInfo incrementalInfo5 = new IncrementalInfo(Consts.GetInstance().UNIT_00443_INTELLIGENCE, gear.intelligence_incremental);
    if (gear.intelligence_incremental > 0)
      collection.Add(incrementalInfo5);
    else if (gear.intelligence_incremental < 0)
      incrementalParams.Add(incrementalInfo5);
    IncrementalInfo incrementalInfo6 = new IncrementalInfo(Consts.GetInstance().UNIT_00443_VITALITY, gear.vitality_incremental);
    if (gear.vitality_incremental > 0)
      collection.Add(incrementalInfo6);
    else if (gear.vitality_incremental < 0)
      incrementalParams.Add(incrementalInfo6);
    IncrementalInfo incrementalInfo7 = new IncrementalInfo(Consts.GetInstance().UNIT_00443_STRENGTH, gear.strength_incremental);
    if (gear.strength_incremental > 0)
      collection.Add(incrementalInfo7);
    else if (gear.strength_incremental < 0)
      incrementalParams.Add(incrementalInfo7);
    IncrementalInfo incrementalInfo8 = new IncrementalInfo(Consts.GetInstance().UNIT_00443_HP, gear.hp_incremental);
    if (gear.hp_incremental > 0)
      collection.Add(incrementalInfo8);
    else if (gear.hp_incremental < 0)
      incrementalParams.Add(incrementalInfo8);
    incrementalParams.AddRange((IEnumerable<IncrementalInfo>) collection);
    return incrementalParams;
  }

  [DebuggerHidden]
  protected IEnumerator SetIncrementalParameter(ItemInfo gear, GameObject target)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new EquipmentDetailMenuBase.\u003CSetIncrementalParameter\u003Ec__Iterator314()
    {
      gear = gear,
      target = target,
      \u003C\u0024\u003Egear = gear,
      \u003C\u0024\u003Etarget = target,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  protected IEnumerator SetIncrementalParameter(GearGear gear, GameObject target)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new EquipmentDetailMenuBase.\u003CSetIncrementalParameter\u003Ec__Iterator315()
    {
      gear = gear,
      target = target,
      \u003C\u0024\u003Egear = gear,
      \u003C\u0024\u003Etarget = target,
      \u003C\u003Ef__this = this
    };
  }

  public override void onBackButton()
  {
  }
}
