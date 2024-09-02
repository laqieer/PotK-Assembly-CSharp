// Decompiled with JetBrains decompiler
// Type: MasterDataTable.QuestWave
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class QuestWave
  {
    public int ID;
    public string victory_description;
    public int wave_count;
    public int first_quest_s_id;

    public static QuestWave Parse(MasterDataReader reader) => new QuestWave()
    {
      ID = reader.ReadInt(),
      victory_description = reader.ReadString(true),
      wave_count = reader.ReadInt(),
      first_quest_s_id = reader.ReadInt()
    };
  }
}
