// Decompiled with JetBrains decompiler
// Type: Versus02614Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Versus02614Menu : BackButtonMenuBase
{
  [SerializeField]
  private UILabel txtTitle;
  [SerializeField]
  private UILabel txtTerm;
  [SerializeField]
  private UIButton btnNext;
  [SerializeField]
  private UIButton btnPrevious;
  [SerializeField]
  private NGxScroll scrollContainer_long;
  [SerializeField]
  private NGxScroll scrollContainer_short;
  [SerializeField]
  private GameObject objMyRankParent;
  [SerializeField]
  private GameObject lineDecoBottom;
  private GameObject scrollPrefab;
  private GameObject scrollText;
  private GameObject unitIcon;
  private NGxScroll scrollContainer;
  private int nowIndex;
  private RankingGroup[] ranking_data;

  [DebuggerHidden]
  public IEnumerator InitOne()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Versus02614Menu.\u003CInitOne\u003Ec__Iterator63F()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator LoadPreafbFuture()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Versus02614Menu.\u003CLoadPreafbFuture\u003Ec__Iterator640()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator Init(WebAPI.Response.PvpBoot pvpInfo, RankingGroup[] ranking_data)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Versus02614Menu.\u003CInit\u003Ec__Iterator641()
    {
      ranking_data = ranking_data,
      \u003C\u0024\u003Eranking_data = ranking_data,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator CreateDisplay()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Versus02614Menu.\u003CCreateDisplay\u003Ec__Iterator642()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator CreateScroll(PvPRankingPlayer data)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Versus02614Menu.\u003CCreateScroll\u003Ec__Iterator643()
    {
      data = data,
      \u003C\u0024\u003Edata = data,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator SetScrollData(Versus02614ScrollParts part, PvPRankingPlayer data)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Versus02614Menu.\u003CSetScrollData\u003Ec__Iterator644()
    {
      part = part,
      data = data,
      \u003C\u0024\u003Epart = part,
      \u003C\u0024\u003Edata = data,
      \u003C\u003Ef__this = this
    };
  }

  public void IbtnNext()
  {
    if (this.IsPush)
      return;
    Singleton<CommonRoot>.GetInstance().loadingMode = 1;
    Singleton<CommonRoot>.GetInstance().isLoading = true;
    --this.nowIndex;
    this.StartCoroutine(this.CreateDisplay());
  }

  public void IbtnPrevious()
  {
    if (this.IsPush)
      return;
    Singleton<CommonRoot>.GetInstance().loadingMode = 1;
    Singleton<CommonRoot>.GetInstance().isLoading = true;
    ++this.nowIndex;
    this.StartCoroutine(this.CreateDisplay());
  }

  public void IbtnReward()
  {
    if (this.IsPushAndSet())
      return;
    Versus02615Scene.ChangeScene(true, this.txtTerm.text, this.ranking_data[this.nowIndex]);
  }

  public void IbtnBack()
  {
    if (this.IsPushAndSet())
      return;
    this.backScene();
  }

  public override void onBackButton() => this.IbtnBack();
}
