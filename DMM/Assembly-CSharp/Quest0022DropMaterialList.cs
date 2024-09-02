// Decompiled with JetBrains decompiler
// Type: Quest0022DropMaterialList
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using System;
using System.Collections;
using System.Collections.Generic;
using UniLinq;
using UnityEngine;

public class Quest0022DropMaterialList : Quest0022MissionDescriptions
{
  public List<UI2DSprite> thum_list_;

  public void Init()
  {
  }

  public IEnumerator Init(int quest_s_id, CommonQuestType quest_type)
  {
    Future<GameObject> fprefab = (Future<GameObject>) null;
    this.ClearThum();
    foreach (QuestCommonDrop questCommonDrop in ((IEnumerable<QuestCommonDrop>) MasterData.QuestCommonDropList).Where<QuestCommonDrop>((Func<QuestCommonDrop, bool>) (x => x.quest_type == quest_type)).Where<QuestCommonDrop>((Func<QuestCommonDrop, bool>) (x => x.quest_s_id == quest_s_id)).OrderBy<QuestCommonDrop, int>((Func<QuestCommonDrop, int>) (x => x.priority)).ToList<QuestCommonDrop>())
    {
      QuestCommonDrop obj = questCommonDrop;
      UnitIcon unitIcon;
      IEnumerator e;
      switch (obj.entity_type)
      {
        case MasterDataTable.CommonRewardType.unit:
        case MasterDataTable.CommonRewardType.material_unit:
          fprefab = Res.Prefabs.UnitIcon.normal.Load<GameObject>();
          e = fprefab.Wait();
          while (e.MoveNext())
            yield return e.Current;
          e = (IEnumerator) null;
          GameObject result1 = fprefab.Result;
          unitIcon = this.SetThum(obj.priority, result1).GetComponent<UnitIcon>();
          e = unitIcon.SetUnit(MasterData.UnitUnit[obj.entity_id], MasterData.UnitUnit[obj.entity_id].GetElement(), false);
          while (e.MoveNext())
            yield return e.Current;
          e = (IEnumerator) null;
          unitIcon.setLevelText("1");
          unitIcon.ShowBottomInfo(UnitSortAndFilter.SORT_TYPES.Level);
          break;
        case MasterDataTable.CommonRewardType.supply:
        case MasterDataTable.CommonRewardType.gear:
        case MasterDataTable.CommonRewardType.material_gear:
        case MasterDataTable.CommonRewardType.gear_body:
          fprefab = Res.Prefabs.ItemIcon.prefab.Load<GameObject>();
          e = fprefab.Wait();
          while (e.MoveNext())
            yield return e.Current;
          e = (IEnumerator) null;
          GameObject result2 = fprefab.Result;
          e = this.SetThum(obj.priority, result2).GetComponent<ItemIcon>().InitByQuestDrop(obj);
          while (e.MoveNext())
            yield return e.Current;
          e = (IEnumerator) null;
          break;
      }
      unitIcon = (UnitIcon) null;
      obj = (QuestCommonDrop) null;
    }
  }

  public void ClearThum() => this.thum_list_.ForEach((System.Action<UI2DSprite>) (x => x.transform.GetChildren().ForEach<Transform>((System.Action<Transform>) (y => UnityEngine.Object.Destroy((UnityEngine.Object) y.gameObject)))));

  public GameObject SetThum(int id, GameObject prefab) => prefab.Clone(this.thum_list_[id - 1].transform);
}
