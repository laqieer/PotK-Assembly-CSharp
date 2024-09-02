// Decompiled with JetBrains decompiler
// Type: MasterDataTable.BoostCampaignTypeName
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class BoostCampaignTypeName
  {
    public int ID;
    public string img_name;
    public int position_BoostIconPosition;

    public static BoostCampaignTypeName Parse(MasterDataReader reader)
    {
      return new BoostCampaignTypeName()
      {
        ID = reader.ReadInt(),
        img_name = reader.ReadString(true),
        position_BoostIconPosition = reader.ReadInt()
      };
    }

    public BoostIconPosition position => (BoostIconPosition) this.position_BoostIconPosition;
  }
}
