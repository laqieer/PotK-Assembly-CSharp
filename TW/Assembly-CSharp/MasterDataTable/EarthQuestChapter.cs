// Decompiled with JetBrains decompiler
// Type: MasterDataTable.EarthQuestChapter
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class EarthQuestChapter
  {
    public int ID;
    public string chapter;
    public string chapter_name;

    public static EarthQuestChapter Parse(MasterDataReader reader)
    {
      return new EarthQuestChapter()
      {
        ID = reader.ReadInt(),
        chapter = reader.ReadString(true),
        chapter_name = reader.ReadString(true)
      };
    }
  }
}
