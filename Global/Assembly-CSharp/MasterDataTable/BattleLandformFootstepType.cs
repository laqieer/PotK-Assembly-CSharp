// Decompiled with JetBrains decompiler
// Type: MasterDataTable.BattleLandformFootstepType
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class BattleLandformFootstepType
  {
    public int ID;
    public string name;

    public static BattleLandformFootstepType Parse(MasterDataReader reader)
    {
      return new BattleLandformFootstepType()
      {
        ID = reader.ReadInt(),
        name = reader.ReadString(true)
      };
    }
  }
}
