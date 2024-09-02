// Decompiled with JetBrains decompiler
// Type: MasterDataTable.HelpHelp
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using I2.Loc;
using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class HelpHelp
  {
    public int ID;
    public int priority;
    public int category_HelpCategory;
    private string _subcategory_name;
    public string title;
    private string _description;
    public string image_name;

    public string subcategory_name
    {
      get
      {
        if (!LocalizationPreset.Instance.EnableLocalization)
          return this._subcategory_name;
        string Translation = string.Empty;
        return LocalizationManager.TryGetTermTranslation("help_HelpHelp_subcategory_name_" + (object) this.ID, out Translation) ? Translation : this._subcategory_name;
      }
      set => this._subcategory_name = value;
    }

    public string description
    {
      get
      {
        if (!LocalizationPreset.Instance.EnableLocalization)
          return this._description;
        string Translation = string.Empty;
        return LocalizationManager.TryGetTermTranslation("help_HelpHelp_description_" + (object) this.ID, out Translation) ? Translation : this._description;
      }
      set => this._description = value;
    }

    public static HelpHelp Parse(MasterDataReader reader)
    {
      return new HelpHelp()
      {
        ID = reader.ReadInt(),
        priority = reader.ReadInt(),
        category_HelpCategory = reader.ReadInt(),
        subcategory_name = reader.ReadString(true),
        title = reader.ReadString(true),
        description = reader.ReadString(true),
        image_name = reader.ReadString(true)
      };
    }

    public HelpCategory category
    {
      get
      {
        HelpCategory category;
        if (!MasterData.HelpCategory.TryGetValue(this.category_HelpCategory, out category))
          Debug.LogError((object) ("Key not Found: MasterData.HelpCategory[" + (object) this.category_HelpCategory + "]"));
        return category;
      }
    }
  }
}
