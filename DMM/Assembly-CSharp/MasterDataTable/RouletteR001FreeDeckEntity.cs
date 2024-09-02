// Decompiled with JetBrains decompiler
// Type: MasterDataTable.RouletteR001FreeDeckEntity
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class RouletteR001FreeDeckEntity
  {
    public int ID;
    public int deck_id;
    public int reward_type_id_CommonRewardType;
    public int reward_id;
    public int? reward_quantity;
    public int _appearance;
    public int action_pattern_id;
    public string reward_title;
    public string reward_message;

    public static RouletteR001FreeDeckEntity Parse(MasterDataReader reader) => new RouletteR001FreeDeckEntity()
    {
      ID = reader.ReadInt(),
      deck_id = reader.ReadInt(),
      reward_type_id_CommonRewardType = reader.ReadInt(),
      reward_id = reader.ReadInt(),
      reward_quantity = reader.ReadIntOrNull(),
      _appearance = reader.ReadInt(),
      action_pattern_id = reader.ReadInt(),
      reward_title = reader.ReadStringOrNull(true),
      reward_message = reader.ReadStringOrNull(true)
    };

    public CommonRewardType reward_type_id => (CommonRewardType) this.reward_type_id_CommonRewardType;
  }
}
