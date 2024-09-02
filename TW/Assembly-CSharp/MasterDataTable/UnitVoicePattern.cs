// Decompiled with JetBrains decompiler
// Type: MasterDataTable.UnitVoicePattern
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class UnitVoicePattern
  {
    public int ID;
    public int character_id;
    public int voice_pattern;
    public string dead_message;
    public string file_name;

    public static UnitVoicePattern Parse(MasterDataReader reader)
    {
      return new UnitVoicePattern()
      {
        ID = reader.ReadInt(),
        character_id = reader.ReadInt(),
        voice_pattern = reader.ReadInt(),
        dead_message = reader.ReadString(true),
        file_name = reader.ReadString(true)
      };
    }
  }
}
