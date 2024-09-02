// Decompiled with JetBrains decompiler
// Type: MasterDataTable.EarthQuestChapter
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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
