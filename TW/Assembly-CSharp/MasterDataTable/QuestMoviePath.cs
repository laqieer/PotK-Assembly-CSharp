// Decompiled with JetBrains decompiler
// Type: MasterDataTable.QuestMoviePath
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
    public string windows_path;

    public static QuestMoviePath Parse(MasterDataReader reader)
    {
      return new QuestMoviePath()
      {
        ID = reader.ReadInt(),
        ios_path = reader.ReadString(true),
        android_path = reader.ReadString(true),
        title = reader.ReadString(true),
        windows_path = reader.ReadString(true)
      };
    }
  }
}
