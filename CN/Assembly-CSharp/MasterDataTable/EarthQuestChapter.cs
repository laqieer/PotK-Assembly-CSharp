// Decompiled with JetBrains decompiler
// Type: MasterDataTable.EarthQuestChapter
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
