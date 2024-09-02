// Decompiled with JetBrains decompiler
// Type: MasterDataTable.UnitIllustPattern
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class UnitIllustPattern
  {
    public int ID;
    public float illust_x;
    public float illust_y;
    public float illust_scale;

    public static UnitIllustPattern Parse(MasterDataReader reader)
    {
      return new UnitIllustPattern()
      {
        ID = reader.ReadInt(),
        illust_x = reader.ReadFloat(),
        illust_y = reader.ReadFloat(),
        illust_scale = reader.ReadFloat()
      };
    }
  }
}
