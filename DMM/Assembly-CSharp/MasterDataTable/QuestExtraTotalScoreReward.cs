﻿// Decompiled with JetBrains decompiler
// Type: MasterDataTable.QuestExtraTotalScoreReward
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class QuestExtraTotalScoreReward
  {
    public int ID;
    public string display_text;
    public string image_name;

    public static QuestExtraTotalScoreReward Parse(MasterDataReader reader) => new QuestExtraTotalScoreReward()
    {
      ID = reader.ReadInt(),
      display_text = reader.ReadString(true),
      image_name = reader.ReadString(true)
    };
  }
}
