// Decompiled with JetBrains decompiler
// Type: MasterDataTable.QuestCommonBackground
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class QuestCommonBackground
  {
    public int ID;
    public string name;
    public string background_name;
    public float offset_x;
    public float offset_y;
    public float scale;

    public static QuestCommonBackground Parse(MasterDataReader reader)
    {
      return new QuestCommonBackground()
      {
        ID = reader.ReadInt(),
        name = reader.ReadString(true),
        background_name = reader.ReadString(true),
        offset_x = reader.ReadFloat(),
        offset_y = reader.ReadFloat(),
        scale = reader.ReadFloat()
      };
    }
  }
}
