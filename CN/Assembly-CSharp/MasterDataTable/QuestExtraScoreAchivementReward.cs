﻿// Decompiled with JetBrains decompiler
// Type: MasterDataTable.QuestExtraScoreAchivementReward
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class QuestExtraScoreAchivementReward
  {
    public int ID;
    public string display_text;
    public string image_name;
    public int alignement;

    public static QuestExtraScoreAchivementReward Parse(MasterDataReader reader)
    {
      return new QuestExtraScoreAchivementReward()
      {
        ID = reader.ReadInt(),
        display_text = reader.ReadString(true),
        image_name = reader.ReadString(true),
        alignement = reader.ReadInt()
      };
    }
  }
}
