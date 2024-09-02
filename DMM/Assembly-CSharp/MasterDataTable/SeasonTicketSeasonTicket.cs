// Decompiled with JetBrains decompiler
// Type: MasterDataTable.SeasonTicketSeasonTicket
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using System;

namespace MasterDataTable
{
  [Serializable]
  public class SeasonTicketSeasonTicket
  {
    public int ID;
    public string name;
    public int max_quantity;
    public string description;
    public int increase_match;

    public static SeasonTicketSeasonTicket Parse(MasterDataReader reader) => new SeasonTicketSeasonTicket()
    {
      ID = reader.ReadInt(),
      name = reader.ReadString(true),
      max_quantity = reader.ReadInt(),
      description = reader.ReadString(true),
      increase_match = reader.ReadInt()
    };

    public Future<UnityEngine.Sprite> LoadThumneilF() => Singleton<ResourceManager>.GetInstance().Load<UnityEngine.Sprite>("SeasonTicket/thum");

    public Future<UnityEngine.Sprite> LoadLargeF() => Singleton<ResourceManager>.GetInstance().Load<UnityEngine.Sprite>("SeasonTicket/large");
  }
}
