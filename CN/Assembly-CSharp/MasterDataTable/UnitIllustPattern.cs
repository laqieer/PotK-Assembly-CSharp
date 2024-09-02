// Decompiled with JetBrains decompiler
// Type: MasterDataTable.UnitIllustPattern
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
