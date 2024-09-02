// Decompiled with JetBrains decompiler
// Type: BannerSetting
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using SM;
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
  [SerializeField]
  private GameObject BannerEffectSprite;
  [SerializeField]
  private UIUnityMaskRenderer effectRenderer;
  [SerializeField]
  private Animator animator;
  private DateTime serverTime;
  private EventDelegate del;
  private bool DestroyFlag;
  private bool notJump;

  public bool DestroyButton => this.DestroyFlag;

  private bool isUseWebImage(Banner banner)
  {
    return (banner.transition.scene_name == "quest002_20" || banner.transition.scene_name == "quest002_19" ? 1 : (banner.transition.scene_name == "quest002_26" ? 1 : 0)) == 0;
  }

  [DebuggerHidden]
  public IEnumerator Init(Banner banner, BannersProc parent, DateTime serverTime)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BannerSetting.\u003CInit\u003Ec__Iterator907()
    {
      serverTime = serverTime,
      banner = banner,
      parent = parent,
      \u003C\u0024\u003EserverTime = serverTime,
      \u003C\u0024\u003Ebanner = banner,
      \u003C\u0024\u003Eparent = parent,
      \u003C\u003Ef__this = this
    };
  }

  public static bool judgeTime(Banner banner, DateTime now)
  {
    return !banner.end_at.HasValue || now < banner.end_at.Value;
  }

  public void onOver()
  {
  }

  public void onOut()
  {
  }

  [DebuggerHidden]
  private IEnumerator onBannerEventConnection(BannerSetting.BannerType type, Banner banner)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BannerSetting.\u003ConBannerEventConnection\u003Ec__Iterator908()
    {
      banner = banner,
      type = type,
      \u003C\u0024\u003Ebanner = banner,
      \u003C\u0024\u003Etype = type
    };
  }

  private void onBannerEvent(BannerSetting.BannerType type, Banner banner)
  {
    this.StopAnime();
    this.StartCoroutine(this.onBannerEventConnection(type, banner));
  }

  public static bool IsExistSpritePath(Banner banner)
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
  private IEnumerator LoadAndSetImage(Banner banner)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BannerSetting.\u003CLoadAndSetImage\u003Ec__Iterator909()
    {
      banner = banner,
      \u003C\u0024\u003Ebanner = banner,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator SetTransition(Banner banner, BannersProc parent)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BannerSetting.\u003CSetTransition\u003Ec__Iterator90A()
    {
      banner = banner,
      parent = parent,
      \u003C\u0024\u003Ebanner = banner,
      \u003C\u0024\u003Eparent = parent,
      \u003C\u003Ef__this = this
    };
  }

  public void setEmphasisEffectVisibility(bool isVisible)
  {
    if (!Object.op_Inequality((Object) this.BannerEffectSprite, (Object) null))
      return;
    this.BannerEffectSprite.gameObject.SetActive(isVisible);
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

  public void StartAnime()
  {
    if (!Object.op_Inequality((Object) this.animator, (Object) null) || !((Component) this.animator).gameObject.activeInHierarchy)
      return;
    this.animator.SetBool("isPlay", true);
  }

  public void StopAnime()
  {
    if (!Object.op_Inequality((Object) this.animator, (Object) null) || !((Component) this.animator).gameObject.activeInHierarchy)
      return;
    this.animator.SetBool("isPlay", false);
  }

  private enum BannerType
  {
    BANNER_TYPE_L,
    BANNER_TYPE_M,
    BANNER_TYPE_OTHER,
    BANNER_TYPE_RANKING_EVENT,
  }
}
