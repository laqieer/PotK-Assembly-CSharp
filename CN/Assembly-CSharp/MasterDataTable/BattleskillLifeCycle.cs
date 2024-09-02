// Decompiled with JetBrains decompiler
// Type: MasterDataTable.BattleskillLifeCycle
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
