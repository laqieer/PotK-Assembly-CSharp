// Decompiled with JetBrains decompiler
// Type: MasterDataTable.CallGaugeRate
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class CallGaugeRate
  {
    public int ID;
    public string key;
    public float value;

    public static CallGaugeRate Parse(MasterDataReader reader) => new CallGaugeRate()
    {
      ID = reader.ReadInt(),
      key = reader.ReadString(true),
      value = reader.ReadFloat()
    };
  }
}
