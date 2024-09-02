// Decompiled with JetBrains decompiler
// Type: MasterDataTable.QuestStoryClearMessage
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class QuestStoryClearMessage
  {
    public int ID;
    public bool is_firsttime;
    public int quest_s_id;
    public string title;
    public string message;

    public static QuestStoryClearMessage Parse(MasterDataReader reader)
    {
      return new QuestStoryClearMessage()
      {
        ID = reader.ReadInt(),
        is_firsttime = reader.ReadBool(),
        quest_s_id = reader.ReadInt(),
        title = reader.ReadString(true),
        message = reader.ReadString(true)
      };
    }
  }
}
