// Decompiled with JetBrains decompiler
// Type: MasterDataTable.BattleskillTimingLogic
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class BattleskillTimingLogic
  {
    public int ID;
    public string name;

    public static BattleskillTimingLogic Parse(MasterDataReader reader)
    {
      return new BattleskillTimingLogic()
      {
        ID = reader.ReadInt(),
        name = reader.ReadString(true)
      };
    }
  }
}
