﻿// Decompiled with JetBrains decompiler
// Type: MasterDataTable.BattleAIScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class BattleAIScript
  {
    public int ID;
    public string file_name;

    public static BattleAIScript Parse(MasterDataReader reader) => new BattleAIScript()
    {
      ID = reader.ReadInt(),
      file_name = reader.ReadString(true)
    };
  }
}
