// Decompiled with JetBrains decompiler
// Type: MasterDataTable.BattleskillEffect
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class BattleskillEffect
  {
    public int ID;
    public int skill_BattleskillSkill;
    public int effect_logic_BattleskillEffectLogic;
    public bool is_targer_enemy;
    public int? use_count;
    public int? use_turn;
    public string arg1_value;
    public string arg2_value;
    public string arg3_value;
    public string arg4_value;
    public string arg5_value;
    public string arg6_value;
    public string arg7_value;
    public string arg8_value;
    public string arg9_value;
    public string arg10_value;

    private string ValueToString(string v) => v;

    private double ValueToDouble(string v)
    {
      double result = 0.0;
      return double.TryParse(v, out result) ? result : result;
    }

    private float ValueToFloat(string v) => (float) this.ValueToDouble(v);

    private int ValueToInt(string v) => (int) this.ValueToDouble(v);

    private T Get<T>(string key, Func<string, T> f)
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
      return this.Get<string>(key, new Func<string, string>(this.ValueToString));
    }

    public float GetFloat(string key)
    {
      return this.Get<float>(key, new Func<string, float>(this.ValueToFloat));
    }

    public int GetInt(string key) => this.Get<int>(key, new Func<string, int>(this.ValueToInt));

    public bool isEnableGameMode(BattleskillInvokeGameModeEnum gameMode)
    {
      if (!this.HasKey("invoke_gamemode"))
        return true;
      int num = this.GetInt("invoke_gamemode");
      return num == 0 || ((BattleskillInvokeGameModeEnum) num & gameMode) == gameMode;
    }

    public static BattleskillEffect Parse(MasterDataReader reader)
    {
      return new BattleskillEffect()
      {
        ID = reader.ReadInt(),
        skill_BattleskillSkill = reader.ReadInt(),
        effect_logic_BattleskillEffectLogic = reader.ReadInt(),
        is_targer_enemy = reader.ReadBool(),
        use_count = reader.ReadIntOrNull(),
        use_turn = reader.ReadIntOrNull(),
        arg1_value = reader.ReadString(true),
        arg2_value = reader.ReadString(true),
        arg3_value = reader.ReadString(true),
        arg4_value = reader.ReadString(true),
        arg5_value = reader.ReadString(true),
        arg6_value = reader.ReadString(true),
        arg7_value = reader.ReadString(true),
        arg8_value = reader.ReadString(true),
        arg9_value = reader.ReadString(true),
        arg10_value = reader.ReadString(true)
      };
    }

    public BattleskillSkill skill
    {
      get
      {
        BattleskillSkill skill;
        if (!MasterData.BattleskillSkill.TryGetValue(this.skill_BattleskillSkill, out skill))
          Debug.LogError((object) ("Key not Found: MasterData.BattleskillSkill[" + (object) this.skill_BattleskillSkill + "]"));
        return skill;
      }
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
  }
}
