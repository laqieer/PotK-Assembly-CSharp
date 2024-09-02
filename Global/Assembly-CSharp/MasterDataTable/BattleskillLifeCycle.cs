// Decompiled with JetBrains decompiler
// Type: MasterDataTable.BattleskillLifeCycle
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class BattleskillLifeCycle
  {
    public int ID;
    public string name;
    public int logic_priority;

    public static BattleskillLifeCycle Parse(MasterDataReader reader)
    {
      return new BattleskillLifeCycle()
      {
        ID = reader.ReadInt(),
        name = reader.ReadString(true),
        logic_priority = reader.ReadInt()
      };
    }
  }
}
