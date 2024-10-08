﻿// Decompiled with JetBrains decompiler
// Type: MasterDataTable.BeginnerNaviTitle
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UniLinq;
using UnityEngine;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class BeginnerNaviTitle
  {
    public int ID;
    public int category_BeginnerNaviCategory;
    public string title;
    public int priority;

    public BeginnerNaviDetail detail
    {
      get
      {
        return ((IEnumerable<BeginnerNaviDetail>) MasterData.BeginnerNaviDetailList).Single<BeginnerNaviDetail>((Func<BeginnerNaviDetail, bool>) (x => x.title.ID == this.ID));
      }
    }

    public static BeginnerNaviTitle Parse(MasterDataReader reader)
    {
      return new BeginnerNaviTitle()
      {
        ID = reader.ReadInt(),
        category_BeginnerNaviCategory = reader.ReadInt(),
        title = reader.ReadString(true),
        priority = reader.ReadInt()
      };
    }

    public BeginnerNaviCategory category
    {
      get
      {
        BeginnerNaviCategory category;
        if (!MasterData.BeginnerNaviCategory.TryGetValue(this.category_BeginnerNaviCategory, out category))
          Debug.LogError((object) ("Key not Found: MasterData.BeginnerNaviCategory[" + (object) this.category_BeginnerNaviCategory + "]"));
        return category;
      }
    }
  }
}
