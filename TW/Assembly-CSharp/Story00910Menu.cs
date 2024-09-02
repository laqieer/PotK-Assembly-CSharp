// Decompiled with JetBrains decompiler
// Type: Story00910Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using MasterDataTable;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class Story00910Menu : BackButtonMenuBase
{
  private WebAPI.Response.QuestProgressHarmony questProgressHarmony;
  private GameObject combiPrefab;
  private GameObject trioPrefab;
  private GameObject unitIconPrefab;
  [SerializeField]
  private NGxScroll ngxScroll;

  protected virtual void Foreground()
  {
  }

  protected virtual void VScrollBar()
  {
  }

  public override void onBackButton() => this.IbtnBack();

  public void IbtnBack()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<NGSceneManager>.GetInstance().changeScene("story009_0");
  }

  [DebuggerHidden]
  private IEnumerator API()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Story00910Menu.\u003CAPI\u003Ec__Iterator54E()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator UsePrefab()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Story00910Menu.\u003CUsePrefab\u003Ec__Iterator54F()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator CreateList()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Story00910Menu.\u003CCreateList\u003Ec__Iterator550()
    {
      \u003C\u003Ef__this = this
    };
  }

  private bool isOpenQuest(
    QuestHarmonyReleaseCondition[] releaseCondirions,
    PlayerHarmonyQuestS playerQuestS)
  {
    return ((IEnumerable<QuestHarmonyReleaseCondition>) releaseCondirions).Where<QuestHarmonyReleaseCondition>((Func<QuestHarmonyReleaseCondition, bool>) (x => x.quest_s_QuestHarmonyS == playerQuestS.quest_harmony_s.ID)).FirstOrDefault<QuestHarmonyReleaseCondition>().required_intimacy_level <= this.GetCharacterIntimate(playerQuestS.quest_harmony_s.unit_UnitUnit, playerQuestS.quest_harmony_s.target_unit_UnitUnit);
  }

  private int GetCharacterIntimate(int mainUnitId, int targetUnitId)
  {
    UnitUnit mainUnit = MasterData.UnitUnit[mainUnitId];
    UnitUnit targetUnit = MasterData.UnitUnit[targetUnitId];
    PlayerCharacterIntimate characterIntimate = ((IEnumerable<PlayerCharacterIntimate>) SMManager.Get<PlayerCharacterIntimate[]>()).FirstOrDefault<PlayerCharacterIntimate>((Func<PlayerCharacterIntimate, bool>) (x =>
    {
      if (x._character == mainUnit.character_UnitCharacter && x._target_character == targetUnit.character_UnitCharacter)
        return true;
      return x._character == targetUnit.character_UnitCharacter && x._target_character == mainUnit.character_UnitCharacter;
    }));
    return characterIntimate != null ? characterIntimate.level : 0;
  }

  private void DeleteList() => this.ngxScroll.Clear();

  [DebuggerHidden]
  public IEnumerator InitScene()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Story00910Menu.\u003CInitScene\u003Ec__Iterator551()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void EndScene() => this.DeleteList();

  private void SelectHarmony(int unitId, int targetUnitId)
  {
    Singleton<NGSceneManager>.GetInstance().destroyLoadedScenes();
    Singleton<NGSceneManager>.GetInstance().changeScene("story009_11", true, (object) unitId, (object) targetUnitId);
  }

  private void SelectHarmonyTrio(int unitId, int[] targetUnitIds, int questSId)
  {
    if (this.IsPushAndSet())
      return;
    Singleton<NGSceneManager>.GetInstance().destroyLoadedScenes();
    Singleton<NGSceneManager>.GetInstance().changeScene("story009_12", true, (object) unitId, (object) targetUnitIds[0], (object) targetUnitIds[1], (object) questSId);
  }
}
