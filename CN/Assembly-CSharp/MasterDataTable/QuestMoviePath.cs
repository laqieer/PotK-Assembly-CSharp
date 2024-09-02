// Decompiled with JetBrains decompiler
// Type: MasterDataTable.QuestMoviePath
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class QuestMoviePath
  {
    public int ID;
    public string ios_path;
    public string android_path;
    public string title;

    public static QuestMoviePath Parse(MasterDataReader reader)
    {
      return new QuestMoviePath()
      {
        ID = reader.ReadInt(),
        ios_path = reader.ReadString(true),
        android_path = reader.ReadString(true),
        title = reader.ReadString(true)
      };
    }
  }
}
