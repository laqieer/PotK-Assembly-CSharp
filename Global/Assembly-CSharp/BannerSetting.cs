// Decompiled with JetBrains decompiler
// Type: BannerSetting
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class BannerSetting : BannerBase
{
  public int ID;
  [SerializeField]
  public int priority;
  [SerializeField]
  private float delay = 3f;
  [SerializeField]
  private GameObject togo;
  [SerializeField]
  private FloatButton Button;
  private DateTime serverTime;
  private EventDelegate del;
  private bool DestroyFlag;
  private bool notJump;

  public bool DestroyButton => this.DestroyFlag;

  private bool isUseWebImage(SM.Banner banner)
  {
    return (banner.transition.scene_name == "quest002_20" || banner.transition.scene_name == "quest002_19" ? 1 : (banner.transition.scene_name == "quest002_26" ? 1 : 0)) == 0;
  }

  [DebuggerHidden]
  public IEnumerator Init(SM.Banner banner, DateTime serverTime)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BannerSetting.\u003CInit\u003Ec__Iterator79C()
    {
      serverTime = serverTime,
      banner = banner,
      \u003C\u0024\u003EserverTime = serverTime,
      \u003C\u0024\u003Ebanner = banner,
      \u003C\u003Ef__this = this
    };
  }

  public static bool judgeTime(SM.Banner banner, DateTime now)
  {
    return !banner.end_at.HasValue || now < banner.end_at.Value;
  }

  public void onOver()
  {
    ((Component) this.IdleSprite).gameObject.SetActive(false);
    ((Component) this.PressSprite).gameObject.SetActive(true);
  }

  public void onOut()
  {
    ((Component) this.IdleSprite).gameObject.SetActive(true);
    ((Component) this.PressSprite).gameObject.SetActive(false);
  }

  [DebuggerHidden]
  private IEnumerator onBannerEventConnection(BannerSetting.BannerType type, SM.Banner banner)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BannerSetting.\u003ConBannerEventConnection\u003Ec__Iterator79D()
    {
      banner = banner,
      type = type,
      \u003C\u0024\u003Ebanner = banner,
      \u003C\u0024\u003Etype = type
    };
  }

  private void onBannerEvent(BannerSetting.BannerType type, SM.Banner banner)
  {
    this.StartCoroutine(this.onBannerEventConnection(type, banner));
  }

  public static bool IsExistSpritePath(SM.Banner banner)
  {
    BannerBase.GetSpriteIdlePath(banner.id, BannerBase.Type.mypage);
    string spriteIdlePath;
    if (banner.transition.scene_name == "quest002_20")
    {
      spriteIdlePath = BannerBase.GetSpriteIdlePath(MasterData.QuestExtraS[banner.transition.arg1].quest_m_QuestExtraM, BannerBase.Type.quest, 1);
    }
    else
    {
      if (!(banner.transition.scene_name == "quest002_19") && !(banner.transition.scene_name == "quest002_26"))
        return !string.IsNullOrEmpty(banner.url);
      spriteIdlePath = BannerBase.GetSpriteIdlePath(MasterData.QuestExtraS[banner.transition.arg1].quest_l_QuestExtraL, BannerBase.Type.quest);
    }
    return Singleton<ResourceManager>.GetInstance().Contains(spriteIdlePath);
  }

  [DebuggerHidden]
  private IEnumerator LoadAndSetImage(SM.Banner banner)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BannerSetting.\u003CLoadAndSetImage\u003Ec__Iterator79E()
    {
      banner = banner,
      \u003C\u0024\u003Ebanner = banner,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator SetTransition(SM.Banner banner)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BannerSetting.\u003CSetTransition\u003Ec__Iterator79F()
    {
      banner = banner,
      \u003C\u0024\u003Ebanner = banner,
      \u003C\u003Ef__this = this
    };
  }

  public void StartTween()
  {
    TweenAlpha component = ((Component) this).GetComponent<TweenAlpha>();
    component.delay = 0.0f;
    EventDelegate.Set(component.onFinished, new EventDelegate((EventDelegate.Callback) (() => this.EndTween()))
    {
      oneShot = true
    });
    component.PlayForward();
  }

  public void EndTween()
  {
    TweenAlpha component = ((Component) this).GetComponent<TweenAlpha>();
    component.delay = this.delay;
    EventDelegate.Set(component.onFinished, new EventDelegate((EventDelegate.Callback) (() => this.Next()))
    {
      oneShot = true
    });
    component.PlayReverse();
  }

  public void Next()
  {
    ((Component) ((Component) this).transform.parent).GetComponent<BannersProc>().LoopBannerNext();
  }

  private enum BannerType
  {
    BANNER_TYPE_L,
    BANNER_TYPE_M,
    BANNER_TYPE_OTHER,
    BANNER_TYPE_RANKING_EVENT,
  }
}
