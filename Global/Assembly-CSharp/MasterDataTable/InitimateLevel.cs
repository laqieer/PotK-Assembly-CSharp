// Decompiled with JetBrains decompiler
// Type: MasterDataTable.InitimateLevel
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class InitimateLevel
  {
    public int ID;
    public int level;
    public int from_exp;
    public int to_exp;

    public static InitimateLevel Parse(MasterDataReader reader)
    {
      return new InitimateLevel()
      {
        ID = reader.ReadInt(),
        level = reader.ReadInt(),
        from_exp = reader.ReadInt(),
        to_exp = reader.ReadInt()
      };
    }
  }
}
