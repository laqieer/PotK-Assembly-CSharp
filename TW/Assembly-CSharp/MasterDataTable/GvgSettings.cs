// Decompiled with JetBrains decompiler
// Type: MasterDataTable.GvgSettings
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class GvgSettings
  {
    public int ID;
    public string key;
    public float value;

    public static GvgSettings Parse(MasterDataReader reader)
    {
      return new GvgSettings()
      {
        ID = reader.ReadInt(),
        key = reader.ReadString(true),
        value = reader.ReadFloat()
      };
    }
  }
}
