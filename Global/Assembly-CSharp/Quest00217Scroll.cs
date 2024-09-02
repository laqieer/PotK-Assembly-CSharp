// Decompiled with JetBrains decompiler
// Type: Quest00217Scroll
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using SM;
using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Quest00217Scroll : BannerBase
{
  private const string SeekIndexL = "L";
  private const string SeekIndexM = "M";
  [SerializeField]
  public UISprite Clear;
  [SerializeField]
  public UISprite New;
  [SerializeField]
  private FloatButton Button;
  private CampaignQuest.RankingEventTerm rankingEventTerm;

  public CampaignQuest.RankingEventTerm RankingEventTerm => this.rankingEventTerm;

  [DebuggerHidden]
  public IEnumerator InitScroll(
    PlayerExtraQuestS extra,
    bool isClear,
    bool isNew,
    DateTime serverTime,
    Quest00217Scroll.SeekType seek = Quest00217Scroll.SeekType.NONE)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00217Scroll.\u003CInitScroll\u003Ec__Iterator1AB()
    {
      extra = extra,
      seek = seek,
      serverTime = serverTime,
      isNew = isNew,
      isClear = isClear,
      \u003C\u0024\u003Eextra = extra,
      \u003C\u0024\u003Eseek = seek,
      \u003C\u0024\u003EserverTime = serverTime,
      \u003C\u0024\u003EisNew = isNew,
      \u003C\u0024\u003EisClear = isClear,
      \u003C\u003Ef__this = this
    };
  }

  private string SetSpritePath(int L, int M, bool isIdle, string seek_index)
  {
    bool flag = seek_index == "m" || seek_index == nameof (M);
    int id = !flag ? L : M;
    int tmp = !flag ? 0 : 1;
    BannerBase.Type type = BannerBase.Type.quest;
    return !isIdle ? BannerBase.GetSpritePressedPath(id, type, tmp) : BannerBase.GetSpriteIdlePath(id, type, tmp);
  }

  [DebuggerHidden]
  private IEnumerator SetAndCreate_BannerSprite(string path, UI2DSprite obj)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00217Scroll.\u003CSetAndCreate_BannerSprite\u003Ec__Iterator1AC()
    {
      path = path,
      obj = obj,
      \u003C\u0024\u003Epath = path,
      \u003C\u0024\u003Eobj = obj
    };
  }

  private void SetScrollButtonCondition(
    PlayerExtraQuestS extra,
    DateTime serverTime,
    string seekIndex)
  {
    EventDelegate.Set(this.BtnFormation.onClick, (EventDelegate.Callback) (() => this.changeScene(extra, ((Component) this).gameObject, serverTime, seekIndex)));
    EventDelegate.Set(this.BtnFormation.onOver, (EventDelegate.Callback) (() => this.onOver(((Component) this).gameObject)));
    EventDelegate.Set(this.BtnFormation.onOut, (EventDelegate.Callback) (() => this.onOut(((Component) this).gameObject)));
  }

  public void changeScene(
    PlayerExtraQuestS extra,
    GameObject obj,
    DateTime serverTime,
    string seekIndex)
  {
    this.StartCoroutine(this.QuestTimeCompare(extra, obj, serverTime, seekIndex));
  }

  public void onOver(GameObject obj)
  {
    ((Component) obj.GetComponent<Quest00217Scroll>().IdleSprite).gameObject.SetActive(false);
    ((Component) obj.GetComponent<Quest00217Scroll>().PressSprite).gameObject.SetActive(true);
  }

  public void onOut(GameObject obj)
  {
    ((Component) obj.GetComponent<Quest00217Scroll>().IdleSprite).gameObject.SetActive(true);
    ((Component) obj.GetComponent<Quest00217Scroll>().PressSprite).gameObject.SetActive(false);
  }

  [DebuggerHidden]
  public IEnumerator QuestTimeCompare(
    PlayerExtraQuestS StageData,
    GameObject obj,
    DateTime serverTime,
    string seekIndex)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00217Scroll.\u003CQuestTimeCompare\u003Ec__Iterator1AD()
    {
      serverTime = serverTime,
      StageData = StageData,
      seekIndex = seekIndex,
      \u003C\u0024\u003EserverTime = serverTime,
      \u003C\u0024\u003EStageData = StageData,
      \u003C\u0024\u003EseekIndex = seekIndex
    };
  }

  public enum SeekType
  {
    NONE,
    M,
    L,
  }
}
