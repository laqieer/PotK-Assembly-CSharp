// Decompiled with JetBrains decompiler
// Type: Popup002261Menu
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
public class Popup002261Menu : MonoBehaviour
{
  [SerializeField]
  private UILabel txtTotalPoint;
  [SerializeField]
  private UILabel txtRanking;
  [SerializeField]
  private NGxScrollMasonry Scroll;
  [SerializeField]
  private UIWidget afterResult;
  [SerializeField]
  private GameObject effectParent;
  [SerializeField]
  private UIWidget Top;
  [SerializeField]
  private UIWidget Bottom;
  private QuestScoreCampaignProgress campaignProgress;
  private PlayerQuestScoreProgress playerInfo;
  private WebAPI.Response.QuestscoreRewardRewards[] m_rewards;
  private PlayerEmblem[] emblems;
  private bool isEffect;
  private Quest00226Menu menu;
  private System.Action closeAct;

  [DebuggerHidden]
  public IEnumerator Init(
    QuestScoreCampaignProgress scoreCampaignProgress,
    WebAPI.Response.QuestscoreRewardRewards[] rewards,
    Quest00226Menu menu,
    System.Action act)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Popup002261Menu.\u003CInit\u003Ec__Iterator7B4()
    {
      act = act,
      menu = menu,
      scoreCampaignProgress = scoreCampaignProgress,
      rewards = rewards,
      \u003C\u0024\u003Eact = act,
      \u003C\u0024\u003Emenu = menu,
      \u003C\u0024\u003EscoreCampaignProgress = scoreCampaignProgress,
      \u003C\u0024\u003Erewards = rewards,
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
    return (IEnumerator) new Popup002261Menu.\u003CEffectEnd\u003Ec__Iterator7B5()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator StartResult()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Popup002261Menu.\u003CStartResult\u003Ec__Iterator7B6()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void DisplayResult()
  {
    this.txtTotalPoint.SetTextLocalize(this.playerInfo.score_total);
    this.txtRanking.SetTextLocalize(this.playerInfo.rank);
  }

  [DebuggerHidden]
  private IEnumerator StartScroll()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Popup002261Menu.\u003CStartScroll\u003Ec__Iterator7B7()
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
    if (this.closeAct == null)
      return;
    this.closeAct();
  }
}
