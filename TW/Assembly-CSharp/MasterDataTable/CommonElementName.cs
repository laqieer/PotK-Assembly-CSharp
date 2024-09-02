// Decompiled with JetBrains decompiler
// Type: MasterDataTable.CommonElementName
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class CommonElementName
  {
    public int ID;
    public string name;

    public static CommonElementName Parse(MasterDataReader reader)
    {
      return new CommonElementName()
      {
        ID = reader.ReadInt(),
        name = reader.ReadString(true)
      };
    }
  }
}
