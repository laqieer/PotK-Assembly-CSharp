// Decompiled with JetBrains decompiler
// Type: Quest00240723Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class Quest00240723Menu : BackButtonMenuBase
{
  private const int STORY_BTN_TWEEN_START = 41;
  private const int STORY_BTN_TWEEN_END = 42;
  [SerializeField]
  protected UILabel TxtTitle;
  [SerializeField]
  private UISprite SlcBeginerSupport;
  public List<GameObject> StoryM;
  private int originID;
  private int tweenFinishCount;
  private float minStartDelay;
  private GameObject StoryButtons;
  private PlayerStoryQuestS[] StoryData;
  private Quest00240723Menu.StoryCondition thisCondition;
  [SerializeField]
  private GameObject StoryButtonParent;
  [SerializeField]
  private GameObject ibtnHardSwitch;
  [HideInInspector]
  public int passLdata;
  [HideInInspector]
  public bool restart;
  [HideInInspector]
  public bool from2_5;

  [DebuggerHidden]
  public IEnumerator Init(PlayerStoryQuestS[] StoryData, int ChoiceLnum, bool reStart = false)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00240723Menu.\u003CInit\u003Ec__Iterator2A0()
    {
      StoryData = StoryData,
      reStart = reStart,
      ChoiceLnum = ChoiceLnum,
      \u003C\u0024\u003EStoryData = StoryData,
      \u003C\u0024\u003EreStart = reStart,
      \u003C\u0024\u003EChoiceLnum = ChoiceLnum,
      \u003C\u003Ef__this = this
    };
  }

  public static bool IsBeginnerSupport() => SMManager.Get<Player>().level <= 20;

  private Future<GameObject> GetPassStoryBtnObj(int id)
  {
    string path = string.Format("Prefabs/quest002_4/story_btns/{0}/Story_btn", (object) id);
    return Singleton<ResourceManager>.GetInstance().Contains(path) ? Singleton<ResourceManager>.GetInstance().Load<GameObject>(path) : Res.Prefabs.quest002_4.story_btns._1.Story_btn.Load<GameObject>();
  }

  private void InitStoryChoiceButton(
    GameObject btnContainer,
    int index,
    bool isStart,
    PlayerStoryQuestS[] StoryDataM)
  {
    Quest0024StoryButton componentInChildren = ((Component) btnContainer.transform).GetComponentInChildren<Quest0024StoryButton>();
    componentInChildren.Lock();
    if (StoryDataM.Length > index)
    {
      int bonusCategory = StoryDataM[index].bonus_category;
      componentInChildren.SetBonus(bonusCategory);
    }
    if (!isStart)
      return;
    TweenPosition component1 = ((Component) componentInChildren).GetComponent<TweenPosition>();
    TweenAlpha component2 = ((Component) componentInChildren).GetComponent<TweenAlpha>();
    float num = (float) (0.5 + (double) index * 0.10000000149011612);
    component1.delay = num;
    component2.delay = num;
    component1.onFinished.Clear();
    EventDelegate.Set(component1.onFinished, new EventDelegate(new EventDelegate.Callback(componentInChildren.playButtonReverseTween))
    {
      oneShot = true
    });
    ((Behaviour) componentInChildren.ibtnStory).enabled = false;
  }

  [DebuggerHidden]
  private IEnumerator StoryChoiceButtonSetting(
    PlayerStoryQuestS[] StoryData,
    PlayerStoryQuestS[] StoryDataM)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00240723Menu.\u003CStoryChoiceButtonSetting\u003Ec__Iterator2A1()
    {
      StoryDataM = StoryDataM,
      StoryData = StoryData,
      \u003C\u0024\u003EStoryDataM = StoryDataM,
      \u003C\u0024\u003EStoryData = StoryData,
      \u003C\u003Ef__this = this
    };
  }

  private void MissionAchievementRate(PlayerStoryQuestS quest, Quest0024StoryButton button)
  {
    int num = 0;
    int nowCount = 0;
    PlayerMissionHistory[] array1 = ((IEnumerable<PlayerMissionHistory>) SMManager.Get<PlayerMissionHistory[]>()).Where<PlayerMissionHistory>((Func<PlayerMissionHistory, bool>) (x => x.story_category == 1)).ToArray<PlayerMissionHistory>();
    QuestStoryMission[] array2 = ((IEnumerable<QuestStoryMission>) MasterData.QuestStoryMissionList).Where<QuestStoryMission>((Func<QuestStoryMission, bool>) (x => x.quest_s.quest_m_QuestStoryM == quest.quest_story_s.quest_m_QuestStoryM)).ToArray<QuestStoryMission>();
    foreach (QuestStoryMission questStoryMission in array2)
      nowCount += !((IEnumerable<PlayerMissionHistory>) array1).Select<PlayerMissionHistory, int>((Func<PlayerMissionHistory, int>) (x => x.mission_id)).Contains<int>(questStoryMission.ID) ? 0 : 1;
    int allCount = num + array2.Length;
    button.MissionAchevement(nowCount, allCount);
  }

  public void XLButton() => this.XLChangeScene();

  public void ChangeScene(int passMdata)
  {
    Debug.Log((object) ("M:" + (object) this.passLdata + "\nL:" + (object) passMdata));
    Quest0022Scene.ChangeScene0022(false, this.passLdata, passMdata);
  }

  public void XLChangeScene()
  {
    Debug.Log((object) ("\nXL:" + (object) this.passLdata));
    Singleton<CommonRoot>.GetInstance().getBackgroundComponent<QuestBG>().CloudAnim(true);
    if (this.thisCondition == Quest00240723Menu.StoryCondition.HARD)
      this.passLdata = this.originID;
    Quest0025Scene.changeScene0025(false, this.passLdata, this.thisCondition == Quest00240723Menu.StoryCondition.HARD);
  }

  public void ClickHardSwitch()
  {
    bool flag = this.thisCondition == Quest00240723Menu.StoryCondition.NORMAL;
    this.ibtnHardSwitch.GetComponent<Quest0024KillModeButton>().ClickToKillMode(flag);
    ((Component) this).GetComponent<BGChange>().BlackHangingBackGround(flag);
    this.SwitchQuestStory(flag);
    this.thisCondition = !flag ? Quest00240723Menu.StoryCondition.NORMAL : Quest00240723Menu.StoryCondition.HARD;
    this.StoryChoiceButtonTween(41);
  }

  private bool SetActiveHardSwitch(
    PlayerStoryQuestS[] StoryData,
    PlayerStoryQuestS[] StoryDataNow,
    int ChoiceLnum)
  {
    this.originID = 0;
    bool flag1 = StoryDataNow[0].quest_story_s.quest_l.quest_mode == CommonQuestMode.kill_mode;
    bool flag2 = ((IEnumerable<PlayerStoryQuestS>) StoryData).Where<PlayerStoryQuestS>((Func<PlayerStoryQuestS, bool>) (x => x.quest_story_s.quest_l.quest_mode == CommonQuestMode.kill_mode)).Any<PlayerStoryQuestS>((Func<PlayerStoryQuestS, bool>) (x => x.quest_story_s.quest_l.origin_id.Value == ChoiceLnum));
    if (!flag1)
      this.thisCondition = Quest00240723Menu.StoryCondition.NORMAL;
    else if (flag1)
    {
      this.thisCondition = Quest00240723Menu.StoryCondition.HARD;
      this.originID = StoryDataNow[0].quest_story_s.quest_l.origin_id.Value;
    }
    return flag1 || flag2;
  }

  private void SwitchQuestStory(bool toHard)
  {
    if (Object.op_Equality((Object) this.StoryButtons, (Object) null))
      return;
    UITweener uiTweener = ((IEnumerable<UITweener>) this.StoryButtons.GetComponents<UITweener>()).Where<UITweener>((Func<UITweener, bool>) (x => x.tweenGroup == 41)).First<UITweener>();
    if (toHard)
    {
      int passHard = ((IEnumerable<PlayerStoryQuestS>) this.StoryData).Where<PlayerStoryQuestS>((Func<PlayerStoryQuestS, bool>) (x => x.quest_story_s.quest_l.origin_id.HasValue && x.quest_story_s.quest_l.origin_id.Value == this.passLdata)).Select<PlayerStoryQuestS, int>((Func<PlayerStoryQuestS, int>) (x => x.quest_story_s.quest_l_QuestStoryL)).First<int>();
      EventDelegate.Set(uiTweener.onFinished, (EventDelegate.Callback) (() => this.StartCoroutine(this.SwitchModeInitialze(this.StoryData, passHard, true, true))));
    }
    else
    {
      int passNormal = ((IEnumerable<PlayerStoryQuestS>) this.StoryData).Where<PlayerStoryQuestS>((Func<PlayerStoryQuestS, bool>) (x => x.quest_story_s.quest_l.ID == this.passLdata)).Select<PlayerStoryQuestS, int>((Func<PlayerStoryQuestS, int>) (x => x.quest_story_s.quest_l.origin_id.Value)).First<int>();
      EventDelegate.Set(uiTweener.onFinished, (EventDelegate.Callback) (() => this.StartCoroutine(this.SwitchModeInitialze(this.StoryData, passNormal, false, true))));
    }
  }

  [DebuggerHidden]
  private IEnumerator SwitchModeInitialze(
    PlayerStoryQuestS[] StoryData,
    int passdata,
    bool toHard,
    bool reStart)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00240723Menu.\u003CSwitchModeInitialze\u003Ec__Iterator2A2()
    {
      StoryData = StoryData,
      passdata = passdata,
      reStart = reStart,
      \u003C\u0024\u003EStoryData = StoryData,
      \u003C\u0024\u003Epassdata = passdata,
      \u003C\u0024\u003EreStart = reStart,
      \u003C\u003Ef__this = this
    };
  }

  public void StoryChoiceButtonTween(int tweengroup)
  {
    if (Object.op_Equality((Object) this.StoryButtons, (Object) null))
      return;
    ((IEnumerable<UITweener>) this.StoryButtons.GetComponents<UITweener>()).ForEach<UITweener>((Action<UITweener>) (x =>
    {
      if (x.tweenGroup != tweengroup)
        return;
      x.ResetToBeginning();
      x.PlayForward();
    }));
  }

  public virtual void IbtnBack() => Debug.Log((object) "click default event IbtnBack");

  public virtual void IbtnStory01() => Debug.Log((object) "click default event IbtnStory01");

  public virtual void IbtnStory02() => Debug.Log((object) "click default event IbtnStory02");

  public virtual void IbtnStory03() => Debug.Log((object) "click default event IbtnStory03");

  public virtual void IbtnStory04() => Debug.Log((object) "click default event IbtnStory04");

  public virtual void IbtnStory05() => Debug.Log((object) "click default event IbtnStory05");

  public override void onBackButton()
  {
    if (Singleton<NGSceneManager>.GetInstance().backScene())
      return;
    MypageScene.ChangeScene(false);
  }

  public enum StoryCondition
  {
    NORMAL,
    HARD,
  }
}
