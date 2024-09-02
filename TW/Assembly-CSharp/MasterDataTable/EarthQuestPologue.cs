// Decompiled with JetBrains decompiler
// Type: MasterDataTable.EarthQuestPologue
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class EarthQuestPologue
  {
    public int ID;
    public int number;
    public string type;
    public string arg1;
    public int episode_EarthQuestEpisode;

    public static EarthQuestPologue Parse(MasterDataReader reader)
    {
      return new EarthQuestPologue()
      {
        ID = reader.ReadInt(),
        number = reader.ReadInt(),
        type = reader.ReadString(true),
        arg1 = reader.ReadString(true),
        episode_EarthQuestEpisode = reader.ReadInt()
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
