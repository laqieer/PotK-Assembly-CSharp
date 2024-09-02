// Decompiled with JetBrains decompiler
// Type: MasterDataTable.QuestCommonBackground
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using System;

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

    public static QuestCommonBackground Parse(MasterDataReader reader) => new QuestCommonBackground()
    {
      ID = reader.ReadInt(),
      name = reader.ReadString(true),
      background_name = reader.ReadString(true),
      offset_x = reader.ReadFloat(),
      offset_y = reader.ReadFloat(),
      scale = reader.ReadFloat()
    };

    public string file_path => string.Format(Consts.GetInstance().BACKGROUND_BASE_PATH, (object) this.background_name);
  }
}
