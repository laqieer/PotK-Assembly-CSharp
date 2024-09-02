// Decompiled with JetBrains decompiler
// Type: MasterDataTable.UnitFootstepType
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class UnitFootstepType
  {
    public int ID;
    public string name;

    public static UnitFootstepType Parse(MasterDataReader reader)
    {
      return new UnitFootstepType()
      {
        ID = reader.ReadInt(),
        name = reader.ReadString(true)
      };
    }
  }
}
