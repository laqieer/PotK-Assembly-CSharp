// Decompiled with JetBrains decompiler
// Type: MasterDataTable.QuestWave
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class QuestWave
  {
    public int ID;
    public string victory_description;
    public int wave_count;
    public int first_quest_s_id;

    public static QuestWave Parse(MasterDataReader reader)
    {
      return new QuestWave()
      {
        ID = reader.ReadInt(),
        victory_description = reader.ReadString(true),
        wave_count = reader.ReadInt(),
        first_quest_s_id = reader.ReadInt()
      };
    }
  }
}
