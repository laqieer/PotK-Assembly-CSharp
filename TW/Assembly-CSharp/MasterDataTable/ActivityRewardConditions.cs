﻿// Decompiled with JetBrains decompiler
// Type: MasterDataTable.ActivityRewardConditions
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class ActivityRewardConditions
  {
    public int ID;
    public int type_id;
    public int data;

    public static ActivityRewardConditions Parse(MasterDataReader reader)
    {
      return new ActivityRewardConditions()
      {
        ID = reader.ReadInt(),
        type_id = reader.ReadInt(),
        data = reader.ReadInt()
      };
    }
  }
}
