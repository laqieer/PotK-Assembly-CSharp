// Decompiled with JetBrains decompiler
// Type: MasterDataTable.UnitMaterialQuestInfo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class UnitMaterialQuestInfo
  {
    public int ID;
    public int unit_id;
    public string short_desc;
    public string long_desc;

    public static UnitMaterialQuestInfo Parse(MasterDataReader reader) => new UnitMaterialQuestInfo()
    {
      ID = reader.ReadInt(),
      unit_id = reader.ReadInt(),
      short_desc = reader.ReadString(true),
      long_desc = reader.ReadString(true)
    };
  }
}
