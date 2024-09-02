// Decompiled with JetBrains decompiler
// Type: MasterDataTable.GachaTicket
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using System;
using UnityEngine;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class GachaTicket
  {
    public int ID;
    public string name;
    public string short_name;
    public int priority;
    private static readonly string GACHATICKET_BASE_PATH = "GachaTicket/{0}/ticket";
    private static readonly string DEFAULT_GACHATICKET_PATH = "GachaTicket/default/ticket";

    public static GachaTicket Parse(MasterDataReader reader)
    {
      return new GachaTicket()
      {
        ID = reader.ReadInt(),
        name = reader.ReadString(true),
        short_name = reader.ReadString(true),
        priority = reader.ReadInt()
      };
    }

    public Future<Sprite> LoadSpriteF()
    {
      return Singleton<ResourceManager>.GetInstance().Load<Sprite>(string.Format(GachaTicket.GACHATICKET_BASE_PATH, (object) this.ID));
    }

    public Future<Sprite> LoadSpriteOrDefault()
    {
      string path = string.Format(GachaTicket.GACHATICKET_BASE_PATH, (object) this.ID);
      return Singleton<ResourceManager>.GetInstance().Contains(path) ? Singleton<ResourceManager>.GetInstance().Load<Sprite>(string.Format(GachaTicket.GACHATICKET_BASE_PATH, (object) this.ID)) : Singleton<ResourceManager>.GetInstance().Load<Sprite>(GachaTicket.DEFAULT_GACHATICKET_PATH);
    }
  }
}
