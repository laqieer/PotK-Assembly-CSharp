// Decompiled with JetBrains decompiler
// Type: Popup02689Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Popup02689Menu : MonoBehaviour
{
  [SerializeField]
  private UILabel txtSubTitle;
  [SerializeField]
  private UILabel txtWin;
  [SerializeField]
  private UILabel txtLose;
  [SerializeField]
  private UILabel txtDraw;
  [SerializeField]
  private UILabel txtClassName;
  [SerializeField]
  private UILabel txtPeriod;
  [SerializeField]
  private UILabel txtRank;
  [SerializeField]
  private UILabel txtPoint;
  [SerializeField]
  private NGxScrollMasonry Scroll;
  [SerializeField]
  private UIWidget afterResult;
  [SerializeField]
  private GameObject effectParent;
  [SerializeField]
  private GameObject dirClassEffectParent;
  [SerializeField]
  private UIWidget Top;
  [SerializeField]
  private UIWidget Bottom;
  private WebAPI.Response.PvpBoot pvpInfo;
  private WebAPI.Response.PvpRankingClose rank_close;
  private WebAPI.Response.PvpSeasonCloseClass_rewards[] rewards;
  private PlayerEmblem[] emblems;
  private bool isEffect;
  private bool isRank;
  private bool isEnd;
  private Versus02610Menu menu;

  [DebuggerHidden]
  public IEnumerator Init(
    WebAPI.Response.PvpBoot pvpInfo,
    WebAPI.Response.PvpSeasonClose season_close,
    Versus02610Menu menu)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Popup02689Menu.\u003CInit\u003Ec__Iterator801()
    {
      menu = menu,
      pvpInfo = pvpInfo,
      season_close = season_close,
      \u003C\u0024\u003Emenu = menu,
      \u003C\u0024\u003EpvpInfo = pvpInfo,
      \u003C\u0024\u003Eseason_close = season_close,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator Init(
    WebAPI.Response.PvpBoot pvpInfo,
    WebAPI.Response.PvpRankingClose rank_close,
    Versus02610Menu menu)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Popup02689Menu.\u003CInit\u003Ec__Iterator802()
    {
      menu = menu,
      pvpInfo = pvpInfo,
      rank_close = rank_close,
      \u003C\u0024\u003Emenu = menu,
      \u003C\u0024\u003EpvpInfo = pvpInfo,
      \u003C\u0024\u003Erank_close = rank_close,
      \u003C\u003Ef__this = this
    };
  }

  public void EffectEndProvide()
  {
    this.isEffect = false;
    this.StartCoroutine(this.EffectEnd());
  }

  public void EffectEndEnable() => this.isEffect = true;

  [DebuggerHidden]
  private IEnumerator EffectEnd()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Popup02689Menu.\u003CEffectEnd\u003Ec__Iterator803()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator StartResultSeason()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Popup02689Menu.\u003CStartResultSeason\u003Ec__Iterator804()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator StartResultRanking()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Popup02689Menu.\u003CStartResultRanking\u003Ec__Iterator805()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator StartScroll()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Popup02689Menu.\u003CStartScroll\u003Ec__Iterator806()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator StartScroll(
    WebAPI.Response.PvpRankingCloseRanking_rewards[] rank_rewards)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Popup02689Menu.\u003CStartScroll\u003Ec__Iterator807()
    {
      rank_rewards = rank_rewards,
      \u003C\u0024\u003Erank_rewards = rank_rewards,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator CreateClassChange()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Popup02689Menu.\u003CCreateClassChange\u003Ec__Iterator808()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator EmblemPopup()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Popup02689Menu.\u003CEmblemPopup\u003Ec__Iterator809()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void SetTop()
  {
    this.SetAnchor(this.Top.topAnchor, this.menu.GetEffectParent, 1f, 0);
    this.SetAnchor(this.Top.bottomAnchor, this.menu.GetEffectParent, 1f, -960);
    this.SetAnchor(this.Top.leftAnchor, this.menu.GetEffectParent, 0.0f, 0);
    this.SetAnchor(this.Top.rightAnchor, this.menu.GetEffectParent, 1f, 0);
    this.Top.ResetAnchors();
    this.Top.UpdateAnchors();
    ((IEnumerable<UIWidget>) ((Component) this.Top).GetComponentsInChildren<UIWidget>()).ForEach<UIWidget>((Action<UIWidget>) (x =>
    {
      x.ResetAnchors();
      x.UpdateAnchors();
    }));
  }

  private void SetBottom()
  {
    this.SetAnchor(this.Bottom.topAnchor, this.menu.GetEffectParent, 0.0f, 960);
    this.SetAnchor(this.Bottom.bottomAnchor, this.menu.GetEffectParent, 0.0f, 0);
    this.SetAnchor(this.Bottom.leftAnchor, this.menu.GetEffectParent, 0.0f, 0);
    this.SetAnchor(this.Bottom.rightAnchor, this.menu.GetEffectParent, 1f, 0);
    this.Bottom.ResetAnchors();
    this.Bottom.UpdateAnchors();
    ((IEnumerable<UIWidget>) ((Component) this.Top).GetComponentsInChildren<UIWidget>()).ForEach<UIWidget>((Action<UIWidget>) (x =>
    {
      x.ResetAnchors();
      x.UpdateAnchors();
    }));
  }

  private void SetScroll()
  {
    UIWidget component = ((Component) this.Scroll).GetComponent<UIWidget>();
    this.SetAnchor(component.topAnchor, this.menu.GetEffectParent, 1f, -287);
    this.SetAnchor(component.bottomAnchor, this.menu.GetEffectParent, 0.0f, (int) sbyte.MaxValue);
    this.SetAnchor(component.leftAnchor, this.menu.GetEffectParent, 0.0f, 5);
    this.SetAnchor(component.rightAnchor, this.menu.GetEffectParent, 1f, -5);
    component.ResetAnchors();
    component.UpdateAnchors();
  }

  private void SetAnchor(UIRect.AnchorPoint ap, Transform parent, float relative, int absolute)
  {
    ap.target = parent;
    ap.relative = relative;
    ap.absolute = absolute;
  }

  public void IbtnTouch()
  {
    if (!this.isEnd)
      return;
    Singleton<NGGameDataManager>.GetInstance().refreshHomeHome = true;
    this.menu.StartSceneUpdate();
    Object.Destroy((Object) ((Component) this).gameObject);
  }
}
