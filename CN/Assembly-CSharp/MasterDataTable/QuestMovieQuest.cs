﻿// Decompiled with JetBrains decompiler
// Type: MasterDataTable.QuestMovieQuest
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class QuestMovieQuest
  {
    public int ID;
    public int quest_type_CommonQuestType;
    public int quest_s_id;
    public int movie_path_QuestMoviePath;

    public static QuestMovieQuest Parse(MasterDataReader reader)
    {
      return new QuestMovieQuest()
      {
        ID = reader.ReadInt(),
        quest_type_CommonQuestType = reader.ReadInt(),
        quest_s_id = reader.ReadInt(),
        movie_path_QuestMoviePath = reader.ReadInt()
      };
    }

    public CommonQuestType quest_type => (CommonQuestType) this.quest_type_CommonQuestType;

    public QuestMoviePath movie_path
    {
      get
      {
        QuestMoviePath moviePath;
        if (!MasterData.QuestMoviePath.TryGetValue(this.movie_path_QuestMoviePath, out moviePath))
          Debug.LogError((object) ("Key not Found: MasterData.QuestMoviePath[" + (object) this.movie_path_QuestMoviePath + "]"));
        return moviePath;
      }
    }
  }
}
