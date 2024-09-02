// Decompiled with JetBrains decompiler
// Type: MasterDataTable.BattleLandformEffect
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class BattleLandformEffect
  {
    public int ID;
    public int group_id;
    public int effect_logic_BattleskillEffectLogic;
    public int landform_effect_phase_BattleLandformEffectPhase;
    public int? use_count;
    public int? use_turn;
    public float arg1_value;
    public float arg2_value;
    public float arg3_value;
    public float arg4_value;
    public float arg5_value;
    public float arg6_value;
    public float arg7_value;
    public float arg8_value;
    public float arg9_value;
    public float arg10_value;

    private string ValueToString(float v) => v.ToString();

    private float ValueToFloat(float v) => v;

    private int ValueToInt(float v) => (int) v;

    private T Get<T>(string key, Func<float, T> f)
    {
      BattleskillEffectLogic effectLogic = this.effect_logic;
      if (key == effectLogic.arg1)
        return f(this.arg1_value);
      if (key == effectLogic.arg2)
        return f(this.arg2_value);
      if (key == effectLogic.arg3)
        return f(this.arg3_value);
      if (key == effectLogic.arg4)
        return f(this.arg4_value);
      if (key == effectLogic.arg5)
        return f(this.arg5_value);
      if (key == effectLogic.arg6)
        return f(this.arg6_value);
      if (key == effectLogic.arg7)
        return f(this.arg7_value);
      if (key == effectLogic.arg8)
        return f(this.arg8_value);
      if (key == effectLogic.arg9)
        return f(this.arg9_value);
      if (key == effectLogic.arg10)
        return f(this.arg10_value);
      throw new Exception(string.Format("key not found: {0} not in {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}", (object) key, (object) this.effect_logic.arg1, (object) this.effect_logic.arg2, (object) this.effect_logic.arg3, (object) this.effect_logic.arg4, (object) this.effect_logic.arg5, (object) this.effect_logic.arg6, (object) this.effect_logic.arg7, (object) this.effect_logic.arg8, (object) this.effect_logic.arg9, (object) this.effect_logic.arg10));
    }

    public bool HasKey(string key)
    {
      BattleskillEffectLogic effectLogic = this.effect_logic;
      return key == effectLogic.arg1 || key == effectLogic.arg2 || key == effectLogic.arg3 || key == effectLogic.arg4 || key == effectLogic.arg5 || key == effectLogic.arg6 || key == effectLogic.arg7 || key == effectLogic.arg8 || key == effectLogic.arg9 || key == effectLogic.arg10;
    }

    public string GetString(string key)
    {
      return this.Get<string>(key, new Func<float, string>(this.ValueToString));
    }

    public float GetFloat(string key)
    {
      return this.Get<float>(key, new Func<float, float>(this.ValueToFloat));
    }

    public int GetInt(string key) => this.Get<int>(key, new Func<float, int>(this.ValueToInt));

    public static BattleLandformEffect Parse(MasterDataReader reader)
    {
      return new BattleLandformEffect()
      {
        ID = reader.ReadInt(),
        group_id = reader.ReadInt(),
        effect_logic_BattleskillEffectLogic = reader.ReadInt(),
        landform_effect_phase_BattleLandformEffectPhase = reader.ReadInt(),
        use_count = reader.ReadIntOrNull(),
        use_turn = reader.ReadIntOrNull(),
        arg1_value = reader.ReadFloat(),
        arg2_value = reader.ReadFloat(),
        arg3_value = reader.ReadFloat(),
        arg4_value = reader.ReadFloat(),
        arg5_value = reader.ReadFloat(),
        arg6_value = reader.ReadFloat(),
        arg7_value = reader.ReadFloat(),
        arg8_value = reader.ReadFloat(),
        arg9_value = reader.ReadFloat(),
        arg10_value = reader.ReadFloat()
      };
    }

    public BattleskillEffectLogic effect_logic
    {
      get
      {
        BattleskillEffectLogic effectLogic;
        if (!MasterData.BattleskillEffectLogic.TryGetValue(this.effect_logic_BattleskillEffectLogic, out effectLogic))
          Debug.LogError((object) ("Key not Found: MasterData.BattleskillEffectLogic[" + (object) this.effect_logic_BattleskillEffectLogic + "]"));
        return effectLogic;
      }
    }

    public BattleLandformEffectPhase landform_effect_phase
    {
      get => (BattleLandformEffectPhase) this.landform_effect_phase_BattleLandformEffectPhase;
    }
  }
}
