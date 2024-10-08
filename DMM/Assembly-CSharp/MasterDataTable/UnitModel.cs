﻿// Decompiled with JetBrains decompiler
// Type: MasterDataTable.UnitModel
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class UnitModel
  {
    public int ID;
    public int unit_id_UnitUnit;
    public int job_metamor_id;
    public int? resource_reference_unit_id;
    public string attach_node;
    public int? attach_effect_id;
    public string field_normal_face_material_name;
    public string job_change_voice;
    public int? initial_gear_GearGear;
    public int? voice_pattern_UnitVoicePattern;
    public int? cutin_pattern;
    public int? cutin_frame_UnitCutinInfo;

    public static UnitModel Parse(MasterDataReader reader) => new UnitModel()
    {
      ID = reader.ReadInt(),
      unit_id_UnitUnit = reader.ReadInt(),
      job_metamor_id = reader.ReadInt(),
      resource_reference_unit_id = reader.ReadIntOrNull(),
      attach_node = reader.ReadStringOrNull(true),
      attach_effect_id = reader.ReadIntOrNull(),
      field_normal_face_material_name = reader.ReadString(true),
      job_change_voice = reader.ReadStringOrNull(true),
      initial_gear_GearGear = reader.ReadIntOrNull(),
      voice_pattern_UnitVoicePattern = reader.ReadIntOrNull(),
      cutin_pattern = reader.ReadIntOrNull(),
      cutin_frame_UnitCutinInfo = reader.ReadIntOrNull()
    };

    public UnitUnit unit_id
    {
      get
      {
        UnitUnit unitUnit;
        if (!MasterData.UnitUnit.TryGetValue(this.unit_id_UnitUnit, out unitUnit))
          Debug.LogError((object) ("Key not Found: MasterData.UnitUnit[" + (object) this.unit_id_UnitUnit + "]"));
        return unitUnit;
      }
    }

    public GearGear initial_gear
    {
      get
      {
        if (!this.initial_gear_GearGear.HasValue)
          return (GearGear) null;
        GearGear gearGear;
        if (!MasterData.GearGear.TryGetValue(this.initial_gear_GearGear.Value, out gearGear))
          Debug.LogError((object) ("Key not Found: MasterData.GearGear[" + (object) this.initial_gear_GearGear.Value + "]"));
        return gearGear;
      }
    }

    public UnitVoicePattern voice_pattern
    {
      get
      {
        if (!this.voice_pattern_UnitVoicePattern.HasValue)
          return (UnitVoicePattern) null;
        UnitVoicePattern unitVoicePattern;
        if (!MasterData.UnitVoicePattern.TryGetValue(this.voice_pattern_UnitVoicePattern.Value, out unitVoicePattern))
          Debug.LogError((object) ("Key not Found: MasterData.UnitVoicePattern[" + (object) this.voice_pattern_UnitVoicePattern.Value + "]"));
        return unitVoicePattern;
      }
    }

    public UnitCutinInfo cutin_frame
    {
      get
      {
        if (!this.cutin_frame_UnitCutinInfo.HasValue)
          return (UnitCutinInfo) null;
        UnitCutinInfo unitCutinInfo;
        if (!MasterData.UnitCutinInfo.TryGetValue(this.cutin_frame_UnitCutinInfo.Value, out unitCutinInfo))
          Debug.LogError((object) ("Key not Found: MasterData.UnitCutinInfo[" + (object) this.cutin_frame_UnitCutinInfo.Value + "]"));
        return unitCutinInfo;
      }
    }
  }
}
