// Decompiled with JetBrains decompiler
// Type: MasterDataTable.UnitCharacter
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
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
    public string name;
    public int category_UnitCategory;
    public int gender_UnitGender;
    public int history_number;
    public string dead_message;
    public string height;
    public string weight;
    public string bust;
    public string waist;
    public string hip;
    public string hobby;
    public string birthday;
    public string zodiac_sign;
    public string blood_type;
    public string origin;
    public string favorite;

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
      return Singleton<ResourceManager>.GetInstance().Load<Sprite>(string.Format("AssetBundle/Resources/Characters/{0}/battle_cutin", (object) this.ID));
    }
  }
}
