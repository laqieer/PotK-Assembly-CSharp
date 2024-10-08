﻿// Decompiled with JetBrains decompiler
// Type: MasterDataTable.SelectTicket
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using System;

namespace MasterDataTable
{
  [Serializable]
  public class SelectTicket
  {
    public int ID;
    public string name;
    public int category_SelectTicketCategory;
    public int picID;
    public int packID;
    public string short_name;
    public int priority;

    public static SelectTicket Parse(MasterDataReader reader) => new SelectTicket()
    {
      ID = reader.ReadInt(),
      name = reader.ReadString(true),
      category_SelectTicketCategory = reader.ReadInt(),
      picID = reader.ReadInt(),
      packID = reader.ReadInt(),
      short_name = reader.ReadString(true),
      priority = reader.ReadInt()
    };

    public SelectTicketCategory category => (SelectTicketCategory) this.category_SelectTicketCategory;

    public Future<UnityEngine.Sprite> createLoaderThumb()
    {
      string path = "SelectTicket/" + (this.picID != 0 ? this.picID.ToString() : this.ID.ToString());
      return Singleton<ResourceManager>.GetInstance().Load<UnityEngine.Sprite>(path);
    }
  }
}
