﻿// Decompiled with JetBrains decompiler
// Type: MasterDataTable.BattleReinforcementLogic
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

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

    public static BattleReinforcementLogic Parse(MasterDataReader reader) => new BattleReinforcementLogic()
    {
      ID = reader.ReadInt(),
      name = reader.ReadString(true),
      arg1 = reader.ReadString(true),
      arg2 = reader.ReadString(true)
    };
  }
}
