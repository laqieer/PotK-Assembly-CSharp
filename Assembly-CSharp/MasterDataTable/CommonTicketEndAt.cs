﻿// Decompiled with JetBrains decompiler
// Type: MasterDataTable.CommonTicketEndAt
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class CommonTicketEndAt
  {
    public int ID;
    public DateTime end_at;

    public static CommonTicketEndAt Parse(MasterDataReader reader) => new CommonTicketEndAt()
    {
      ID = reader.ReadInt(),
      end_at = reader.ReadDateTime()
    };
  }
}
