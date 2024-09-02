// Decompiled with JetBrains decompiler
// Type: MasterDataTable.PvpMatchingType
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class PvpMatchingType
  {
    public int ID;
    public string room_key;

    public static PvpMatchingType Parse(MasterDataReader reader)
    {
      return new PvpMatchingType()
      {
        ID = reader.ReadInt(),
        room_key = reader.ReadString(true)
      };
    }
  }
}
