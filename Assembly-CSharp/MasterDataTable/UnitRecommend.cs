// Decompiled with JetBrains decompiler
// Type: MasterDataTable.UnitRecommend
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MasterDataTable
{
  [Serializable]
  public class UnitRecommend
  {
    public int ID;
    public int? unit_type_UnitType;
    public int? overkillers_UnitUnit;
    public int? job_UnitJob;
    public int? gear_GearGear;
    public string story_quest_s_ids_;
    public string extra_quest_s_ids_;
    public string sea_quest_s_ids_;
    private QuestStoryS[] story_quests_;
    private QuestExtraS[] extra_quests_;
    private QuestSeaS[] sea_quests_;

    public static UnitRecommend Parse(MasterDataReader reader) => new UnitRecommend()
    {
      ID = reader.ReadInt(),
      unit_type_UnitType = reader.ReadIntOrNull(),
      overkillers_UnitUnit = reader.ReadIntOrNull(),
      job_UnitJob = reader.ReadIntOrNull(),
      gear_GearGear = reader.ReadIntOrNull(),
      story_quest_s_ids_ = reader.ReadStringOrNull(true),
      extra_quest_s_ids_ = reader.ReadStringOrNull(true),
      sea_quest_s_ids_ = reader.ReadStringOrNull(true)
    };

    public UnitType unit_type
    {
      get
      {
        if (!this.unit_type_UnitType.HasValue)
          return (UnitType) null;
        UnitType unitType;
        if (!MasterData.UnitType.TryGetValue(this.unit_type_UnitType.Value, out unitType))
          Debug.LogError((object) ("Key not Found: MasterData.UnitType[" + (object) this.unit_type_UnitType.Value + "]"));
        return unitType;
      }
    }

    public UnitUnit overkillers
    {
      get
      {
        if (!this.overkillers_UnitUnit.HasValue)
          return (UnitUnit) null;
        UnitUnit unitUnit;
        if (!MasterData.UnitUnit.TryGetValue(this.overkillers_UnitUnit.Value, out unitUnit))
          Debug.LogError((object) ("Key not Found: MasterData.UnitUnit[" + (object) this.overkillers_UnitUnit.Value + "]"));
        return unitUnit;
      }
    }

    public UnitJob job
    {
      get
      {
        if (!this.job_UnitJob.HasValue)
          return (UnitJob) null;
        UnitJob unitJob;
        if (!MasterData.UnitJob.TryGetValue(this.job_UnitJob.Value, out unitJob))
          Debug.LogError((object) ("Key not Found: MasterData.UnitJob[" + (object) this.job_UnitJob.Value + "]"));
        return unitJob;
      }
    }

    public GearGear gear
    {
      get
      {
        if (!this.gear_GearGear.HasValue)
          return (GearGear) null;
        GearGear gearGear;
        if (!MasterData.GearGear.TryGetValue(this.gear_GearGear.Value, out gearGear))
          Debug.LogError((object) ("Key not Found: MasterData.GearGear[" + (object) this.gear_GearGear.Value + "]"));
        return gearGear;
      }
    }

    public int same_character_id => this.ID;

    public QuestStoryS[] story_quests
    {
      get
      {
        if (this.story_quests_ != null)
          return this.story_quests_;
        this.story_quests_ = this.convertStringToMasters<QuestStoryS>(this.story_quest_s_ids_, MasterData.QuestStoryS, (System.Action) (() => Debug.LogError((object) string.Format("Failed to Convert!! UnitRecommend[ID={0}].story_quest_s_ids_({1}) -> QuestStoryS[]", (object) this.ID, (object) this.story_quest_s_ids_))));
        return this.story_quests_;
      }
    }

    public QuestExtraS[] extra_quests
    {
      get
      {
        if (this.extra_quests_ != null)
          return this.extra_quests_;
        this.extra_quests_ = this.convertStringToMasters<QuestExtraS>(this.extra_quest_s_ids_, MasterData.QuestExtraS, (System.Action) (() => Debug.LogError((object) string.Format("Failed to Convert!! UnitRecommend[ID={0}].extra_quest_s_ids_({1}) -> QuestExtraS[]", (object) this.ID, (object) this.extra_quest_s_ids_))));
        return this.extra_quests_;
      }
    }

    public QuestSeaS[] sea_quests
    {
      get
      {
        if (this.sea_quests_ != null)
          return this.sea_quests_;
        this.sea_quests_ = this.convertStringToMasters<QuestSeaS>(this.sea_quest_s_ids_, MasterData.QuestSeaS, (System.Action) (() => Debug.LogError((object) string.Format("Failed to Convert!! UnitRecommend[ID={0}].sea_quest_s_ids_({1}) -> QuestSeaS[]", (object) this.ID, (object) this.sea_quest_s_ids_))));
        return this.sea_quests_;
      }
    }

    private T[] convertStringToMasters<T>(string v, AssocList<int, T> master, System.Action actErr) where T : class
    {
      T[] objArray;
      if (string.IsNullOrEmpty(v))
      {
        objArray = new T[0];
      }
      else
      {
        string error;
        int[] intsAndSort = this.stringToIntsAndSort(v, out error);
        if (string.IsNullOrEmpty(error))
        {
          objArray = new T[intsAndSort.Length];
          for (int index = 0; index < intsAndSort.Length; ++index)
          {
            if (!master.TryGetValue(intsAndSort[index], out objArray[index]))
            {
              objArray = (T[]) null;
              break;
            }
          }
        }
        else
          objArray = (T[]) null;
        if (objArray == null)
          actErr();
      }
      return objArray;
    }

    private int[] stringToIntsAndSort(string v, out string error)
    {
      string str = string.Empty;
      string[] strArray = v.Split(',');
      int[] numArray = new int[strArray.Length];
      for (int index = 0; index < strArray.Length; ++index)
      {
        if (!int.TryParse(strArray[index].Trim(), out numArray[index]))
          str = str + "," + strArray[index];
      }
      if (!string.IsNullOrEmpty(str))
      {
        numArray = (int[]) null;
        error = "int.Parse Failed!:" + str.Substring(1);
      }
      else
        error = string.Empty;
      return ((IEnumerable<int>) numArray).OrderBy<int, int>((Func<int, int>) (i => i)).ToArray<int>();
    }
  }
}
