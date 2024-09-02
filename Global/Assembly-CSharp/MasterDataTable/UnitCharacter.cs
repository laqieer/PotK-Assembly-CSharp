// Decompiled with JetBrains decompiler
// Type: MasterDataTable.UnitCharacter
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using I2.Loc;
using System;
using System.Collections.Generic;
using UniLinq;
using UnityEngine;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class UnitCharacter
  {
    public int ID;
    private string _name;
    public int category_UnitCategory;
    public int gender_UnitGender;
    public int history_number;
    private string _dead_message;
    public string height;
    public string weight;
    public string bust;
    public string waist;
    public string hip;
    private string _hobby;
    public string birthday;
    private string _zodiac_sign;
    public string blood_type;
    private string _origin;
    private string _favorite;

    public string name
    {
      get
      {
        if (!LocalizationPreset.Instance.EnableLocalization)
          return this._name;
        string Translation = string.Empty;
        return LocalizationManager.TryGetTermTranslation("unit_UnitCharacter_name_" + (object) this.ID, out Translation) ? Translation : this._name;
      }
      set => this._name = value;
    }

    public string dead_message
    {
      get
      {
        if (!LocalizationPreset.Instance.EnableLocalization)
          return this._dead_message;
        string Translation = string.Empty;
        return LocalizationManager.TryGetTermTranslation("unit_UnitCharacter_dead_message_" + (object) this.ID, out Translation) ? Translation : this._dead_message;
      }
      set => this._dead_message = value;
    }

    public string hobby
    {
      get
      {
        if (!LocalizationPreset.Instance.EnableLocalization)
          return this._hobby;
        string Translation = string.Empty;
        return LocalizationManager.TryGetTermTranslation("unit_UnitCharacter_hobby_" + (object) this.ID, out Translation) ? Translation : this._hobby;
      }
      set => this._hobby = value;
    }

    public string zodiac_sign
    {
      get
      {
        if (!LocalizationPreset.Instance.EnableLocalization)
          return this._zodiac_sign;
        string Translation = string.Empty;
        return LocalizationManager.TryGetTermTranslation("unit_UnitCharacter_zodiac_sign_" + (object) this.ID, out Translation) ? Translation : this._zodiac_sign;
      }
      set => this._zodiac_sign = value;
    }

    public string origin
    {
      get
      {
        if (!LocalizationPreset.Instance.EnableLocalization)
          return this._origin;
        string Translation = string.Empty;
        return LocalizationManager.TryGetTermTranslation("unit_UnitCharacter_origin_" + (object) this.ID, out Translation) ? Translation : this._origin;
      }
      set => this._origin = value;
    }

    public string favorite
    {
      get
      {
        if (!LocalizationPreset.Instance.EnableLocalization)
          return this._favorite;
        string Translation = string.Empty;
        return LocalizationManager.TryGetTermTranslation("unit_UnitCharacter_favorite_" + (object) this.ID, out Translation) ? Translation : this._favorite;
      }
      set => this._favorite = value;
    }

    public static UnitCharacter Parse(MasterDataReader reader)
    {
      return new UnitCharacter()
      {
        ID = reader.ReadInt(),
        name = reader.ReadString(true),
        category_UnitCategory = reader.ReadInt(),
        gender_UnitGender = reader.ReadInt(),
        history_number = reader.ReadInt(),
        dead_message = reader.ReadString(true),
        height = reader.ReadString(true),
        weight = reader.ReadString(true),
        bust = reader.ReadString(true),
        waist = reader.ReadString(true),
        hip = reader.ReadString(true),
        hobby = reader.ReadString(true),
        birthday = reader.ReadString(true),
        zodiac_sign = reader.ReadString(true),
        blood_type = reader.ReadString(true),
        origin = reader.ReadString(true),
        favorite = reader.ReadString(true)
      };
    }

    public UnitCategory category => (UnitCategory) this.category_UnitCategory;

    public UnitGender gender => (UnitGender) this.gender_UnitGender;

    public UnitUnit GetDefaultUnitUnit()
    {
      return ((IEnumerable<UnitUnit>) MasterData.UnitUnitList).FirstOrDefault<UnitUnit>((Func<UnitUnit, bool>) (uu => uu.character.ID == this.ID));
    }

    public UnitVoicePattern voicePattern
    {
      get
      {
        return ((IEnumerable<UnitVoicePattern>) MasterData.UnitVoicePatternList).Where<UnitVoicePattern>((Func<UnitVoicePattern, bool>) (x => x.character_id == this.ID)).FirstOrDefault<UnitVoicePattern>();
      }
    }

    public Future<Sprite> LoadCutin()
    {
      return ResourceManager.Load<Sprite>(string.Format("AssetBundle/Resources/Characters/{0}/battle_cutin", (object) this.ID));
    }
  }
}
