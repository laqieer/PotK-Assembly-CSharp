// Decompiled with JetBrains decompiler
// Type: MasterDataTable.BeginnerNaviTitle
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using I2.Loc;
using System;
using System.Collections.Generic;
using UniLinq;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class BeginnerNaviTitle
  {
    public int ID;
    public int category_BeginnerNaviCategory;
    private string _title;
    public int priority;

    public BeginnerNaviDetail detail
    {
      get
      {
        return ((IEnumerable<BeginnerNaviDetail>) MasterData.BeginnerNaviDetailList).Single<BeginnerNaviDetail>((Func<BeginnerNaviDetail, bool>) (x => x.title.ID == this.ID));
      }
    }

    public string title
    {
      get
      {
        if (!LocalizationPreset.Instance.EnableLocalization)
          return this._title;
        string Translation = string.Empty;
        return LocalizationManager.TryGetTermTranslation("beginnernavi_BeginnerNaviTitle_title_" + (object) this.ID, out Translation) ? Translation : this._title;
      }
      set => this._title = value;
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
