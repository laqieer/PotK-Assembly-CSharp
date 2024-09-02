// Decompiled with JetBrains decompiler
// Type: MasterDataTable.BattleskillEffectLogic
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class BattleskillEffectLogic
  {
    public int ID;
    public string name;
    public string arg1;
    public string arg2;
    public string arg3;
    public string arg4;
    public string arg5;
    public string arg6;
    public string arg7;
    public string arg8;
    public string arg9;
    public string arg10;
    public int effect_tag1_BattleskillEffectTag;
    public int effect_tag2_BattleskillEffectTag;
    public int effect_tag3_BattleskillEffectTag;
    public int effect_tag4_BattleskillEffectTag;
    public int effect_tag5_BattleskillEffectTag;

    public bool HasTag(BattleskillEffectTag tag)
    {
      return tag == this.effect_tag1 || tag == this.effect_tag2 || tag == this.effect_tag3 || tag == this.effect_tag4 || tag == this.effect_tag5;
    }

    public BattleskillEffectLogicEnum Enum => (BattleskillEffectLogicEnum) this.ID;

    public static BattleskillEffectLogic Parse(MasterDataReader reader)
    {
      return new BattleskillEffectLogic()
      {
        ID = reader.ReadInt(),
        name = reader.ReadString(true),
        arg1 = reader.ReadString(true),
        arg2 = reader.ReadString(true),
        arg3 = reader.ReadString(true),
        arg4 = reader.ReadString(true),
        arg5 = reader.ReadString(true),
        arg6 = reader.ReadString(true),
        arg7 = reader.ReadString(true),
        arg8 = reader.ReadString(true),
        arg9 = reader.ReadString(true),
        arg10 = reader.ReadString(true),
        effect_tag1_BattleskillEffectTag = reader.ReadInt(),
        effect_tag2_BattleskillEffectTag = reader.ReadInt(),
        effect_tag3_BattleskillEffectTag = reader.ReadInt(),
        effect_tag4_BattleskillEffectTag = reader.ReadInt(),
        effect_tag5_BattleskillEffectTag = reader.ReadInt()
      };
    }

    public BattleskillEffectTag effect_tag1
    {
      get => (BattleskillEffectTag) this.effect_tag1_BattleskillEffectTag;
    }

    public BattleskillEffectTag effect_tag2
    {
      get => (BattleskillEffectTag) this.effect_tag2_BattleskillEffectTag;
    }

    public BattleskillEffectTag effect_tag3
    {
      get => (BattleskillEffectTag) this.effect_tag3_BattleskillEffectTag;
    }

    public BattleskillEffectTag effect_tag4
    {
      get => (BattleskillEffectTag) this.effect_tag4_BattleskillEffectTag;
    }

    public BattleskillEffectTag effect_tag5
    {
      get => (BattleskillEffectTag) this.effect_tag5_BattleskillEffectTag;
    }
  }
}
