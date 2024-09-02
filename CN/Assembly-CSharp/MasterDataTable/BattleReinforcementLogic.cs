// Decompiled with JetBrains decompiler
// Type: MasterDataTable.BattleReinforcementLogic
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class BattleReinforcementLogic
  {
    public int ID;
    public string name;
    public string arg1;
    public string arg2;

    public BattleReinforcementLogicEnum Enum => (BattleReinforcementLogicEnum) this.ID;

    public static BattleReinforcementLogic Parse(MasterDataReader reader)
    {
      return new BattleReinforcementLogic()
      {
        ID = reader.ReadInt(),
        name = reader.ReadString(true),
        arg1 = reader.ReadString(true),
        arg2 = reader.ReadString(true)
      };
    }
  }
}
