// Decompiled with JetBrains decompiler
// Type: MypageScene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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
    return (IEnumerator) new MypageScene.\u003ConInitSceneAsync\u003Ec__Iterator7A3()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new MypageScene.\u003ConStartSceneAsync\u003Ec__Iterator7A4()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(bool isCloudAnim, bool isEarthSuspend)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new MypageScene.\u003ConStartSceneAsync\u003Ec__Iterator7A5()
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
    this.menu.StartLoginPopup();
    if (this.is_loginbonus)
      return;
    if (!this.menu.LoginPopupActive())
    {
      this.menu.FinishLoginPopup();
    }
    else
    {
      if (Singleton<NGGameDataManager>.GetInstance().homeStartUp == null)
        return;
      this.menu.LoginBonusPopupStart(((IEnumerable<PlayerLoginBonus>) Singleton<NGGameDataManager>.GetInstance().homeStartUp.player_loginbonuses).Where<PlayerLoginBonus>((Func<PlayerLoginBonus, bool>) (x => x.loginbonus.draw_type == LoginbonusDrawType.popup)).ToList<PlayerLoginBonus>(), (System.Action) (() =>
      {
        LevelRewardSchemaMixin[] achieveLevelRewards = Singleton<NGGameDataManager>.GetInstance().homeStartUp.player_achieve_level_rewards;
        this.menu.LevelUpPopupStart(achieveLevelRewards != null ? new List<LevelRewardSchemaMixin>((IEnumerable<LevelRewardSchemaMixin>) achieveLevelRewards) : new List<LevelRewardSchemaMixin>(), (System.Action) (() => this.menu.DeviceRewardPopupStart((System.Action) (() => this.menu.FinishLoginPopup()))));
      }));
    }
  }

  public override void onEndScene()
  {
    if (Object.op_Inequality((Object) this.menu.sm, (Object) null) && ((Behaviour) this.menu.sm).enabled)
      this.menu.sm.stopVoice();
    this.menu.CirculButton.End();
    this.menu.CharaAnimInit();
    this.menu.StopBannerScroll();
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
    Application.Quit();
  }

  [DebuggerHidden]
  private IEnumerator LoadBackGround()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new MypageScene.\u003CLoadBackGround\u003Ec__Iterator7A6()
    {
      \u003C\u003Ef__this = this
    };
  }
}
