// Decompiled with JetBrains decompiler
// Type: MasterDataTable.GuildApprovalPolicy
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class GuildApprovalPolicy
  {
    public int ID;
    public string name;
    public bool default_manual;

    public static GuildApprovalPolicy Parse(MasterDataReader reader)
    {
      return new GuildApprovalPolicy()
      {
        ID = reader.ReadInt(),
        name = reader.ReadString(true),
        default_manual = reader.ReadBool()
      };
    }
  }
}
