// Decompiled with JetBrains decompiler
// Type: MasterDataTable.BattleFieldEffect
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class BattleFieldEffect
  {
    public int ID;
    public int category_BattleFieldEffectCategory;
    public bool cancelable;
    public string animation_controller_name;
    public string prefab_name;
    public string effect_prefab_name1;
    public string effect_prefab_name2;
    public string effect_prefab_name3;
    public bool is_unmask;
    public bool is_view_back;

    public string[] effect_prefab_names => new string[3]
    {
      this.effect_prefab_name1,
      this.effect_prefab_name2,
      this.effect_prefab_name3
    };

    public static BattleFieldEffect Parse(MasterDataReader reader) => new BattleFieldEffect()
    {
      ID = reader.ReadInt(),
      category_BattleFieldEffectCategory = reader.ReadInt(),
      cancelable = reader.ReadBool(),
      animation_controller_name = reader.ReadString(true),
      prefab_name = reader.ReadString(true),
      effect_prefab_name1 = reader.ReadString(true),
      effect_prefab_name2 = reader.ReadString(true),
      effect_prefab_name3 = reader.ReadString(true),
      is_unmask = reader.ReadBool(),
      is_view_back = reader.ReadBool()
    };

    public BattleFieldEffectCategory category => (BattleFieldEffectCategory) this.category_BattleFieldEffectCategory;
  }
}
