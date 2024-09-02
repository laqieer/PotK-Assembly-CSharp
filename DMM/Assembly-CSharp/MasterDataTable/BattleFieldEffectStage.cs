// Decompiled with JetBrains decompiler
// Type: MasterDataTable.BattleFieldEffectStage
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class BattleFieldEffectStage
  {
    public int ID;
    public int stage_BattleStage;
    public int timing_BattleFieldEffectTiming;
    public int field_effect_BattleFieldEffect;

    public static BattleFieldEffectStage Parse(MasterDataReader reader) => new BattleFieldEffectStage()
    {
      ID = reader.ReadInt(),
      stage_BattleStage = reader.ReadInt(),
      timing_BattleFieldEffectTiming = reader.ReadInt(),
      field_effect_BattleFieldEffect = reader.ReadInt()
    };

    public BattleStage stage
    {
      get
      {
        BattleStage battleStage;
        if (!MasterData.BattleStage.TryGetValue(this.stage_BattleStage, out battleStage))
          Debug.LogError((object) ("Key not Found: MasterData.BattleStage[" + (object) this.stage_BattleStage + "]"));
        return battleStage;
      }
    }

    public BattleFieldEffectTiming timing => (BattleFieldEffectTiming) this.timing_BattleFieldEffectTiming;

    public BattleFieldEffect field_effect
    {
      get
      {
        BattleFieldEffect battleFieldEffect;
        if (!MasterData.BattleFieldEffect.TryGetValue(this.field_effect_BattleFieldEffect, out battleFieldEffect))
          Debug.LogError((object) ("Key not Found: MasterData.BattleFieldEffect[" + (object) this.field_effect_BattleFieldEffect + "]"));
        return battleFieldEffect;
      }
    }
  }
}
