// Decompiled with JetBrains decompiler
// Type: MasterDataTable.GearMaterialQuestInfo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class GearMaterialQuestInfo
  {
    public int ID;
    public int gear_id;
    public string detail_desc1;
    public string detail_desc2;
    public string detail_desc3;

    public static GearMaterialQuestInfo Parse(MasterDataReader reader) => new GearMaterialQuestInfo()
    {
      ID = reader.ReadInt(),
      gear_id = reader.ReadInt(),
      detail_desc1 = reader.ReadString(true),
      detail_desc2 = reader.ReadString(true),
      detail_desc3 = reader.ReadString(true)
    };
  }
}
