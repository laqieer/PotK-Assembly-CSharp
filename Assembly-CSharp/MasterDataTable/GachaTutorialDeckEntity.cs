// Decompiled with JetBrains decompiler
// Type: MasterDataTable.GachaTutorialDeckEntity
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class GachaTutorialDeckEntity
  {
    public int ID;
    public int deck_id_GachaTutorialDeck;
    public int reward_type_id_CommonRewardType;
    public int reward_id;
    public int? reward_quantity;
    public int _appearance;
    public bool is_pickup;

    public static GachaTutorialDeckEntity Parse(MasterDataReader reader) => new GachaTutorialDeckEntity()
    {
      ID = reader.ReadInt(),
      deck_id_GachaTutorialDeck = reader.ReadInt(),
      reward_type_id_CommonRewardType = reader.ReadInt(),
      reward_id = reader.ReadInt(),
      reward_quantity = reader.ReadIntOrNull(),
      _appearance = reader.ReadInt(),
      is_pickup = reader.ReadBool()
    };

    public GachaTutorialDeck deck_id
    {
      get
      {
        GachaTutorialDeck gachaTutorialDeck;
        if (!MasterData.GachaTutorialDeck.TryGetValue(this.deck_id_GachaTutorialDeck, out gachaTutorialDeck))
          Debug.LogError((object) ("Key not Found: MasterData.GachaTutorialDeck[" + (object) this.deck_id_GachaTutorialDeck + "]"));
        return gachaTutorialDeck;
      }
    }

    public CommonRewardType reward_type_id => (CommonRewardType) this.reward_type_id_CommonRewardType;
  }
}
