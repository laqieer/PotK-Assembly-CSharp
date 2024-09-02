// Decompiled with JetBrains decompiler
// Type: MasterDataTable.ConstsConsts
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class ConstsConsts
  {
    public int ID;
    public string name;
    public string description;

    public static ConstsConsts Parse(MasterDataReader reader)
    {
      return new ConstsConsts()
      {
        ID = reader.ReadInt(),
        name = reader.ReadString(true),
        description = reader.ReadString(true)
      };
    }
  }
}
