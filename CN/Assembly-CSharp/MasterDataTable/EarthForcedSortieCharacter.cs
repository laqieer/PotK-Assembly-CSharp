﻿// Decompiled with JetBrains decompiler
// Type: MasterDataTable.EarthForcedSortieCharacter
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class EarthForcedSortieCharacter
  {
    public int ID;
    public int episode_EarthQuestEpisode;
    public int character_id;
    public int sortie_position;

    public static EarthForcedSortieCharacter Parse(MasterDataReader reader)
    {
      return new EarthForcedSortieCharacter()
      {
        ID = reader.ReadInt(),
        episode_EarthQuestEpisode = reader.ReadInt(),
        character_id = reader.ReadInt(),
        sortie_position = reader.ReadInt()
      };
    }

    public EarthQuestEpisode episode
    {
      get
      {
        EarthQuestEpisode episode;
        if (!MasterData.EarthQuestEpisode.TryGetValue(this.episode_EarthQuestEpisode, out episode))
          Debug.LogError((object) ("Key not Found: MasterData.EarthQuestEpisode[" + (object) this.episode_EarthQuestEpisode + "]"));
        return episode;
      }
    }
  }
}
