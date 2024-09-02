// Decompiled with JetBrains decompiler
// Type: MasterDataTable.PvpMatchingType
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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
