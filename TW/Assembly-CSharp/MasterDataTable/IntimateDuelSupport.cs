// Decompiled with JetBrains decompiler
// Type: MasterDataTable.IntimateDuelSupport
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class IntimateDuelSupport
  {
    public int ID;
    public int intimate_value;
    public int hit;
    public int evasion;
    public int critical;
    public int critical_evasion;

    public static IntimateDuelSupport Parse(MasterDataReader reader)
    {
      return new IntimateDuelSupport()
      {
        ID = reader.ReadInt(),
        intimate_value = reader.ReadInt(),
        hit = reader.ReadInt(),
        evasion = reader.ReadInt(),
        critical = reader.ReadInt(),
        critical_evasion = reader.ReadInt()
      };
    }
  }
}
