﻿// Decompiled with JetBrains decompiler
// Type: MasterDataTable.QuestMovieQuest
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class QuestMovieQuest
  {
    public int ID;
    public int quest_type_CommonQuestType;
    public int quest_s_id;
    public int movie_path_QuestMoviePath;

    public static QuestMovieQuest Parse(MasterDataReader reader) => new QuestMovieQuest()
    {
      ID = reader.ReadInt(),
      quest_type_CommonQuestType = reader.ReadInt(),
      quest_s_id = reader.ReadInt(),
      movie_path_QuestMoviePath = reader.ReadInt()
    };

    public CommonQuestType quest_type => (CommonQuestType) this.quest_type_CommonQuestType;

    public QuestMoviePath movie_path
    {
      get
      {
        QuestMoviePath questMoviePath;
        if (!MasterData.QuestMoviePath.TryGetValue(this.movie_path_QuestMoviePath, out questMoviePath))
          Debug.LogError((object) ("Key not Found: MasterData.QuestMoviePath[" + (object) this.movie_path_QuestMoviePath + "]"));
        return questMoviePath;
      }
    }
  }
}
