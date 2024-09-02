﻿// Decompiled with JetBrains decompiler
// Type: MasterDataTable.GuildSetting
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class GuildSetting
  {
    public int ID;
    public string key;
    public string value_type;
    public string value;

    public static GuildSetting Parse(MasterDataReader reader)
    {
      return new GuildSetting()
      {
        ID = reader.ReadInt(),
        key = reader.ReadString(true),
        value_type = reader.ReadString(true),
        value = reader.ReadString(true)
      };
    }

    public int? GetIntValue()
    {
      int result1 = 0;
      float result2 = 0.0f;
      if (this.value_type == "integer")
      {
        if (float.TryParse(this.value, out result2))
          return new int?(Mathf.FloorToInt(result2));
        if (int.TryParse(this.value, out result1))
          return new int?(result1);
      }
      return new int?();
    }

    public string GetStringValue() => this.value;
  }
}
