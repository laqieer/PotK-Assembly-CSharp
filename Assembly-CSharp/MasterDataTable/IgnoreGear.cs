// Decompiled with JetBrains decompiler
// Type: MasterDataTable.IgnoreGear
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class IgnoreGear
  {
    public int ID;
    public int gear_id;

    public static IgnoreGear Parse(MasterDataReader reader) => new IgnoreGear()
    {
      ID = reader.ReadInt(),
      gear_id = reader.ReadInt()
    };
  }
}
