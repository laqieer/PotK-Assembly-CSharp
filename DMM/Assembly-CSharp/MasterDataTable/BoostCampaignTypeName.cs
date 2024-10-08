﻿// Decompiled with JetBrains decompiler
// Type: MasterDataTable.BoostCampaignTypeName
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class BoostCampaignTypeName
  {
    public int ID;
    public string img_name;
    public int position_BoostIconPosition;

    public static BoostCampaignTypeName Parse(MasterDataReader reader) => new BoostCampaignTypeName()
    {
      ID = reader.ReadInt(),
      img_name = reader.ReadString(true),
      position_BoostIconPosition = reader.ReadInt()
    };

    public BoostIconPosition position => (BoostIconPosition) this.position_BoostIconPosition;
  }
}
