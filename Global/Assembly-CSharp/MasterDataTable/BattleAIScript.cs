// Decompiled with JetBrains decompiler
// Type: MasterDataTable.BattleAIScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class BattleAIScript
  {
    public int ID;
    public string file_name;

    public static BattleAIScript Parse(MasterDataReader reader)
    {
      return new BattleAIScript()
      {
        ID = reader.ReadInt(),
        file_name = reader.ReadString(true)
      };
    }
  }
}
