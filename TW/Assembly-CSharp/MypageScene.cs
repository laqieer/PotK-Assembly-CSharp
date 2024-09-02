// Decompiled with JetBrains decompiler
// Type: MypageScene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using Bode;
using gu3.Device;
using MasterDataTable;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class MypageScene : NGSceneBase
{
  private BGChange bg_change;
  private bool is_loginbonus;
  public MypageMenu menu;
  [SerializeField]
  private MypageTransition transition;

  public static void ChangeScene(bool stack, bool isCloudAnim = false, bool isEarthSuspend = false)
  {
    Singleton<NGGameDataManager>.GetInstance().IsEarth = false;
    Singleton<NGSceneManager>.GetInstance().changeScene("mypage", (stack ? 1 : 0) != 0, (object) isCloudAnim, (object) isEarthSuspend);
  }

  [DebuggerHidden]
  public override IEnumerator onInitSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new MypageScene.\u003ConInitSceneAsync\u003Ec__Iterator9E1()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new MypageScene.\u003ConStartSceneAsync\u003Ec__Iterator9E2()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(bool isCloudAnim, bool isEarthSuspend)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new MypageScene.\u003ConStartSceneAsync\u003Ec__Iterator9E3()
    {
      isEarthSuspend = isEarthSuspend,
      isCloudAnim = isCloudAnim,
      \u003C\u0024\u003EisEarthSuspend = isEarthSuspend,
      \u003C\u0024\u003EisCloudAnim = isCloudAnim,
      \u003C\u003Ef__this = this
    };
  }

  public void onStartScene() => this.onStartScene(false, false);

  public void onStartScene(bool isCloudAnm, bool isEarthSuspend)
  {
    DeviceManager.SetAutoSleep(true);
    if (this.is_loginbonus)
      return;
    if (Persist.eventStoryPlay.Data.PlayEventScript(this.sceneName, ServerTime.NowAppTime(), 0))
    {
      MypageMenu.LeaderID = 0;
      this.menu.ResetTweenDelay();
    }
    else if (!this.menu.LoginPopupActive())
    {
      Singleton<CommonRoot>.GetInstance().isLoading = false;
      this.menu.CharaAnimProc();
      if (isCloudAnm)
      {
        this.menu.SetJogDialActive(false);
        this.menu.PlayTween(MypageMenu.START_TWEENGROUP_TOP);
        Singleton<CommonRoot>.GetInstance().StartCloudAnimEnd((System.Action) (() =>
        {
          this.menu.SetJogDialActive(true);
          this.menu.PlayTween(MypageMenu.START_TWEEN_GROUP_JOGDIAL);
        }));
      }
      else
        this.menu.PlayTween(MypageMenu.START_TWEENGROUP);
    }
    else
    {
      bool flag = false;
      if (Singleton<NGGameDataManager>.GetInstance().loginBonuses != null)
      {
        List<PlayerLoginBonus> list = Singleton<NGGameDataManager>.GetInstance().loginBonuses.Where<PlayerLoginBonus>((Func<PlayerLoginBonus, bool>) (x => x.loginbonus.draw_type == LoginbonusDrawType.popup)).ToList<PlayerLoginBonus>();
        if (Singleton<NGGameDataManager>.GetInstance().loginBonuses.Count > 0)
        {
          EventTracker.TrackEvent("LOGIN", "GAME_LOGIN", 1);
          this.menu.LoginPopupStart(list[0], list.Count<PlayerLoginBonus>());
          return;
        }
      }
      if (!flag)
      {
        LevelRewardSchemaMixin[] playerLevelRewards = Singleton<NGGameDataManager>.GetInstance().playerLevelRewards;
        if (playerLevelRewards != null && playerLevelRewards.Length > 0)
        {
          flag = true;
          this.menu.LevelUpPopupInit(playerLevelRewards);
          this.menu.LevelUpPopupStart(playerLevelRewards);
        }
      }
      if (flag)
        return;
      Singleton<CommonRoot>.GetInstance().isLoading = false;
      this.menu.CharaAnimProc();
      if (isCloudAnm)
      {
        this.menu.SetJogDialActive(false);
        this.menu.PlayTween(MypageMenu.START_TWEENGROUP_TOP);
        Singleton<CommonRoot>.GetInstance().StartCloudAnimEnd((System.Action) (() =>
        {
          this.menu.SetJogDialActive(true);
          this.menu.PlayTween(MypageMenu.START_TWEEN_GROUP_JOGDIAL);
        }));
      }
      else
        this.menu.PlayTween(MypageMenu.START_TWEENGROUP);
    }
  }

  public override void onEndScene()
  {
    if (Object.op_Inequality((Object) this.menu.sm, (Object) null) && ((Behaviour) this.menu.sm).enabled)
      this.menu.sm.stopVoice();
    this.menu.CirculButton.End();
    this.menu.CharaAnimInit();
    this.menu.StopMissionClearInfo();
    this.menu.StopBannerScroll();
    this.menu.HidePanelMission();
  }

  public void onClearSavedata()
  {
    Persist.auth.Delete();
    Persist.battleEnvironment.Delete();
    Persist.pvpSuspend.Delete();
    Persist.notification.Delete();
    Persist.sortOrder.Delete();
    Persist.tutorial.Delete();
    Persist.volume.Delete();
    Persist.earthData.Delete();
    Persist.missionHistory.Delete();
    SDK.instance.Quit();
  }

  [DebuggerHidden]
  private IEnumerator LoadBackGround()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new MypageScene.\u003CLoadBackGround\u003Ec__Iterator9E4()
    {
      \u003C\u003Ef__this = this
    };
  }

  public bool isAnimePlaying
  {
    get => Object.op_Inequality((Object) this.menu, (Object) null) && this.menu.isAnimePlaying;
  }
}
