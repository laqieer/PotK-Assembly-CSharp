// Decompiled with JetBrains decompiler
// Type: MasterDataTable.EarthQuestPologue
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

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

    public static EarthQuestPologue Parse(MasterDataReader reader) => new EarthQuestPologue()
    {
      ID = reader.ReadInt(),
      number = reader.ReadInt(),
      type = reader.ReadString(true),
      arg1 = reader.ReadString(true),
      episode_EarthQuestEpisode = reader.ReadInt()
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
