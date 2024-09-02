// Decompiled with JetBrains decompiler
// Type: Mypage051Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using Earth;
using gu3.Device;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Mypage051Scene : NGSceneBase
{
  [SerializeField]
  private Mypage051Menu menu;
  [SerializeField]
  private Mypage051Transition transition;

  public static void ChangeScene(bool stack, bool isCloudAnim)
  {
    Singleton<NGGameDataManager>.GetInstance().IsEarth = true;
    Singleton<NGSceneManager>.GetInstance().changeScene("mypage051", (stack ? 1 : 0) != 0, (object) isCloudAnim);
  }

  public override List<string> createResourceLoadList()
  {
    EarthDataManager instanceOrNull = Singleton<EarthDataManager>.GetInstanceOrNull();
    return Object.op_Equality((Object) instanceOrNull, (Object) null) ? new List<string>() : instanceOrNull.createResourceLoadList();
  }

  [DebuggerHidden]
  public override IEnumerator onInitSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Mypage051Scene.\u003ConInitSceneAsync\u003Ec__Iterator738()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Mypage051Scene.\u003ConStartSceneAsync\u003Ec__Iterator739()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void onStartScene() => this.onStartScene(false);

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(bool isCloudAnim)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Mypage051Scene.\u003ConStartSceneAsync\u003Ec__Iterator73A()
    {
      isCloudAnim = isCloudAnim,
      \u003C\u0024\u003EisCloudAnim = isCloudAnim,
      \u003C\u003Ef__this = this
    };
  }

  public void onStartScene(bool isCloudAnim)
  {
    DeviceManager.SetAutoSleep(true);
    Singleton<CommonRoot>.GetInstance().isLoading = false;
    this.menu.CharaAnimProc();
    if (isCloudAnim)
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

  public override void onEndScene()
  {
    NGSoundManager instance = Singleton<NGSoundManager>.GetInstance();
    if (Object.op_Inequality((Object) instance, (Object) null) && ((Behaviour) instance).enabled)
      instance.stopVoice();
    this.menu.CirculButton.End();
    this.menu.CharaAnimInit();
  }

  [DebuggerHidden]
  private IEnumerator LoadBackGround()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Mypage051Scene.\u003CLoadBackGround\u003Ec__Iterator73B()
    {
      \u003C\u003Ef__this = this
    };
  }
}
