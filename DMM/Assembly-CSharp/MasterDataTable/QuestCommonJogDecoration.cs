﻿// Decompiled with JetBrains decompiler
// Type: MasterDataTable.QuestCommonJogDecoration
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class QuestCommonJogDecoration
  {
    public int ID;
    public int banner_id;
    public DateTime? start_at;
    public DateTime? end_at;

    public static QuestCommonJogDecoration Parse(MasterDataReader reader) => new QuestCommonJogDecoration()
    {
      ID = reader.ReadInt(),
      banner_id = reader.ReadInt(),
      start_at = reader.ReadDateTimeOrNull(),
      end_at = reader.ReadDateTimeOrNull()
    };
  }
}
