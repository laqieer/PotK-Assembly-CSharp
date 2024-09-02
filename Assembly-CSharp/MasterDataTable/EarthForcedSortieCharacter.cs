// Decompiled with JetBrains decompiler
// Type: MasterDataTable.EarthForcedSortieCharacter
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class EarthForcedSortieCharacter
  {
    public int ID;
    public int episode_EarthQuestEpisode;
    public int character_id;
    public int sortie_position;

    public static EarthForcedSortieCharacter Parse(MasterDataReader reader) => new EarthForcedSortieCharacter()
    {
      ID = reader.ReadInt(),
      episode_EarthQuestEpisode = reader.ReadInt(),
      character_id = reader.ReadInt(),
      sortie_position = reader.ReadInt()
    };

    public EarthQuestEpisode episode
    {
      get
      {
        EarthQuestEpisode earthQuestEpisode;
        if (!MasterData.EarthQuestEpisode.TryGetValue(this.episode_EarthQuestEpisode, out earthQuestEpisode))
          Debug.LogError((object) ("Key not Found: MasterData.EarthQuestEpisode[" + (object) this.episode_EarthQuestEpisode + "]"));
        return earthQuestEpisode;
      }
    }
  }
}
