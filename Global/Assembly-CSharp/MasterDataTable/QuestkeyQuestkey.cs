// Decompiled with JetBrains decompiler
// Type: MasterDataTable.QuestkeyQuestkey
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using I2.Loc;
using System;
using UnityEngine;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class QuestkeyQuestkey
  {
    public int ID;
    private string _name;
    private string _description;

    public string name
    {
      get
      {
        if (!LocalizationPreset.Instance.EnableLocalization)
          return this._name;
        string Translation = string.Empty;
        return LocalizationManager.TryGetTermTranslation("questkey_QuestkeyQuestkey_name_" + (object) this.ID, out Translation) ? Translation : this._name;
      }
      set => this._name = value;
    }

    public string description
    {
      get
      {
        if (!LocalizationPreset.Instance.EnableLocalization)
          return this._description;
        string Translation = string.Empty;
        return LocalizationManager.TryGetTermTranslation("questkey_QuestkeyQuestkey_description_" + (object) this.ID, out Translation) ? Translation : this._description;
      }
      set => this._description = value;
    }

    public static QuestkeyQuestkey Parse(MasterDataReader reader)
    {
      return new QuestkeyQuestkey()
      {
        ID = reader.ReadInt(),
        name = reader.ReadString(true),
        description = reader.ReadString(true)
      };
    }

    public Future<Sprite> LoadSpriteThumbnail()
    {
      return ResourceManager.Load<Sprite>(string.Format("AssetBundle/Resources/Questkey/{0}/key_thum", (object) this.ID));
    }

    public Future<Sprite> LoadSpriteBasic()
    {
      return ResourceManager.Load<Sprite>(string.Format("AssetBundle/Resources/Questkey/{0}/key_basic", (object) this.ID));
    }
  }
}
