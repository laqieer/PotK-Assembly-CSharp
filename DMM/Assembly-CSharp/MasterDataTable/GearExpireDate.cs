// Decompiled with JetBrains decompiler
// Type: MasterDataTable.GearExpireDate
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class GearExpireDate
  {
    public int ID;
    public DateTime end_at;

    public static GearExpireDate Parse(MasterDataReader reader) => new GearExpireDate()
    {
      ID = reader.ReadInt(),
      end_at = reader.ReadDateTime()
    };
  }
}
