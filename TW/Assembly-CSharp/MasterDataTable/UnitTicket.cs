// Decompiled with JetBrains decompiler
// Type: MasterDataTable.UnitTicket
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using System;
using UnityEngine;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class UnitTicket
  {
    public int ID;
    public string name;
    public string short_name;
    public int priority;
    private static readonly string UNITTICKET_BASE_PATH = "UnitTicket/{0}/ticket";
    private static readonly string DEFAULT_UNITTICKET_PATH = "UnitTicket/default/ticket";

    public static UnitTicket Parse(MasterDataReader reader)
    {
      return new UnitTicket()
      {
        ID = reader.ReadInt(),
        name = reader.ReadString(true),
        short_name = reader.ReadString(true),
        priority = reader.ReadInt()
      };
    }

    public Future<Sprite> LoadSpriteF()
    {
      return Singleton<ResourceManager>.GetInstance().Load<Sprite>(string.Format(UnitTicket.UNITTICKET_BASE_PATH, (object) this.ID));
    }
  }
}
