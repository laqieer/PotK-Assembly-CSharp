﻿// Decompiled with JetBrains decompiler
// Type: Quest0022Hscroll
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using MasterDataTable;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Quest0022Hscroll : QuestHScrollButton
{
  private int missionNum;
  private int missionClearNum;
  private CommonQuestType questType;

  public int MissionNum
  {
    get => this.missionNum;
    set => this.missionNum = value;
  }

  public int MissionClearNum
  {
    get => this.missionClearNum;
    set => this.missionClearNum = value;
  }

  public bool CanPlay => this.canPlay;

  public float defaultPosition() => ((Component) this).transform.localPosition.x;

  public float spaceValue() => this.SpaceValue;

  public int id() => this.ID;

  public CommonQuestType QuestType
  {
    get => this.questType;
    set => this.questType = value;
  }

  public int stageNumber() => this.StageNumber;

  [DebuggerHidden]
  public IEnumerator Init(
    QuestConverterData StageData,
    float gridWidth,
    int center,
    System.Action act,
    bool eventquest)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest0022Hscroll.\u003CInit\u003Ec__Iterator1D3()
    {
      StageData = StageData,
      eventquest = eventquest,
      gridWidth = gridWidth,
      center = center,
      act = act,
      \u003C\u0024\u003EStageData = StageData,
      \u003C\u0024\u003Eeventquest = eventquest,
      \u003C\u0024\u003EgridWidth = gridWidth,
      \u003C\u0024\u003Ecenter = center,
      \u003C\u0024\u003Eact = act,
      \u003C\u003Ef__this = this
    };
  }

  private string SetStageNumSpritePath(int? folderid, int num, bool Event)
  {
    int num1 = !folderid.HasValue ? 0 : folderid.Value;
    string empty = string.Empty;
    string str1 = !Event ? "Prefabs/Quest/Story/DifficultImage/" : "Prefabs/Quest/Extra/DifficultImage/";
    string path = str1 + string.Format("{0}/{1}a", (object) num1, (object) num);
    string str2;
    if (!Singleton<ResourceManager>.GetInstance().Contains(path))
    {
      Debug.LogError((object) ("NotFoundResourcesPath : " + path));
      str2 = str1 + "0/1a";
    }
    else
      str2 = path;
    return str2;
  }

  [DebuggerHidden]
  public IEnumerator PopupJudge(QuestConverterData StageData, System.Action act, bool Event)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest0022Hscroll.\u003CPopupJudge\u003Ec__Iterator1D4()
    {
      Event = Event,
      StageData = StageData,
      act = act,
      \u003C\u0024\u003EEvent = Event,
      \u003C\u0024\u003EStageData = StageData,
      \u003C\u0024\u003Eact = act,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator noAP_Popup()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Quest0022Hscroll.\u003CnoAP_Popup\u003Ec__Iterator1D5 popupCIterator1D5 = new Quest0022Hscroll.\u003CnoAP_Popup\u003Ec__Iterator1D5();
    return (IEnumerator) popupCIterator1D5;
  }

  [DebuggerHidden]
  private IEnumerator maxAPshortage_Popoup()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Quest0022Hscroll.\u003CmaxAPshortage_Popoup\u003Ec__Iterator1D6 popoupCIterator1D6 = new Quest0022Hscroll.\u003CmaxAPshortage_Popoup\u003Ec__Iterator1D6();
    return (IEnumerator) popoupCIterator1D6;
  }

  [DebuggerHidden]
  public IEnumerator QuestTimeCompare(QuestConverterData StageData, System.Action act)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest0022Hscroll.\u003CQuestTimeCompare\u003Ec__Iterator1D7()
    {
      StageData = StageData,
      act = act,
      \u003C\u0024\u003EStageData = StageData,
      \u003C\u0024\u003Eact = act,
      \u003C\u003Ef__this = this
    };
  }
}
