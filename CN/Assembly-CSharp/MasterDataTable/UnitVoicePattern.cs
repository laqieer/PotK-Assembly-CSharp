// Decompiled with JetBrains decompiler
// Type: MasterDataTable.UnitVoicePattern
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
