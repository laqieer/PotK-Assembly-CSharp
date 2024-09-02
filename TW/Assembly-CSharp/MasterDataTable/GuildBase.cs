// Decompiled with JetBrains decompiler
// Type: MasterDataTable.GuildBase
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class GuildBase
  {
    public int ID;
    public int base_type_GuildBaseType;
    public int release_level;

    public static GuildBase Parse(MasterDataReader reader)
    {
      return new GuildBase()
      {
        ID = reader.ReadInt(),
        base_type_GuildBaseType = reader.ReadInt(),
        release_level = reader.ReadInt()
      };
    }

    public GuildBaseType base_type => (GuildBaseType) this.base_type_GuildBaseType;
  }
}
