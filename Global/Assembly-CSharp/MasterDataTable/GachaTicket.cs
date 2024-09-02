// Decompiled with JetBrains decompiler
// Type: MasterDataTable.GachaTicket
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using I2.Loc;
using System;
using UnityEngine;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class GachaTicket
  {
    public int ID;
    private string _name;
    public string short_name;
    public int priority;
    private static readonly string GACHATICKET_BASE_PATH = "GachaTicket/{0}/ticket";
    private static readonly string DEFAULT_GACHATICKET_PATH = "GachaTicket/default/ticket";

    public string name
    {
      get
      {
        if (!LocalizationPreset.Instance.EnableLocalization)
          return this._name;
        string Translation = string.Empty;
        return LocalizationManager.TryGetTermTranslation("ticket_GachaTicket_name_" + (object) this.ID, out Translation) ? Translation : this._name;
      }
      set => this._name = value;
    }

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
      return ResourceManager.Load<Sprite>(string.Format(GachaTicket.GACHATICKET_BASE_PATH, (object) this.ID));
    }

    public Future<Sprite> LoadSpriteOrDefault()
    {
      string path = string.Format(GachaTicket.GACHATICKET_BASE_PATH, (object) this.ID);
      return Singleton<ResourceManager>.GetInstance().Contains(path) ? ResourceManager.Load<Sprite>(string.Format(GachaTicket.GACHATICKET_BASE_PATH, (object) this.ID)) : ResourceManager.Load<Sprite>(GachaTicket.DEFAULT_GACHATICKET_PATH);
    }
  }
}
