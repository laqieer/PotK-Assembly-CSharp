// Decompiled with JetBrains decompiler
// Type: MasterDataTable.QuestCommonBackground
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
