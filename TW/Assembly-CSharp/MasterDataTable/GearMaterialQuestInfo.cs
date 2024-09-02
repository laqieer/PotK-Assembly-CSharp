// Decompiled with JetBrains decompiler
// Type: MasterDataTable.GearMaterialQuestInfo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;

#nullable disable
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

    public static GearMaterialQuestInfo Parse(MasterDataReader reader)
    {
      return new GearMaterialQuestInfo()
      {
        ID = reader.ReadInt(),
        gear_id = reader.ReadInt(),
        detail_desc1 = reader.ReadString(true),
        detail_desc2 = reader.ReadString(true),
        detail_desc3 = reader.ReadString(true)
      };
    }
  }
}
