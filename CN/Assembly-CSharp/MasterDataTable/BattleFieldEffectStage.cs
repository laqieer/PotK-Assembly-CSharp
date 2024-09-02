// Decompiled with JetBrains decompiler
// Type: MasterDataTable.BattleFieldEffectStage
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class BattleFieldEffectStage
  {
    public int ID;
    public int stage_BattleStage;
    public int timing_BattleFieldEffectTiming;
    public int field_effect_BattleFieldEffect;

    public static BattleFieldEffectStage Parse(MasterDataReader reader)
    {
      return new BattleFieldEffectStage()
      {
        ID = reader.ReadInt(),
        stage_BattleStage = reader.ReadInt(),
        timing_BattleFieldEffectTiming = reader.ReadInt(),
        field_effect_BattleFieldEffect = reader.ReadInt()
      };
    }

    public BattleStage stage
    {
      get
      {
        BattleStage stage;
        if (!MasterData.BattleStage.TryGetValue(this.stage_BattleStage, out stage))
          Debug.LogError((object) ("Key not Found: MasterData.BattleStage[" + (object) this.stage_BattleStage + "]"));
        return stage;
      }
    }

    public BattleFieldEffectTiming timing
    {
      get => (BattleFieldEffectTiming) this.timing_BattleFieldEffectTiming;
    }

    public BattleFieldEffect field_effect
    {
      get
      {
        BattleFieldEffect fieldEffect;
        if (!MasterData.BattleFieldEffect.TryGetValue(this.field_effect_BattleFieldEffect, out fieldEffect))
          Debug.LogError((object) ("Key not Found: MasterData.BattleFieldEffect[" + (object) this.field_effect_BattleFieldEffect + "]"));
        return fieldEffect;
      }
    }
  }
}
