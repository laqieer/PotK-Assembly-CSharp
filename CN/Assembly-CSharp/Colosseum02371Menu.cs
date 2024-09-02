// Decompiled with JetBrains decompiler
// Type: Colosseum02371Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Colosseum02371Menu : BackButtonMenuBase
{
  private const int HIDE_ANCHOR = 0;
  private const int SHOW_ANCHOR = 207;
  public NGxScroll ScrollContainer;
  public UIButton RankingBtn;
  public UIButton FriendRankibBtn;
  private GameObject ScrollObject;
  private GameObject TextObject;
  private GameObject IconObject;
  private RankingPlayer MyRanking;
  private RankingPlayer[] TotalRankingArray;
  private RankingPlayer[] FriendRankingArray;
  private List<Colosseum02371MenuParts> TotalRankingList = new List<Colosseum02371MenuParts>();
  private List<Colosseum02371MenuParts> FriendRankingList = new List<Colosseum02371MenuParts>();
  [SerializeField]
  private GameObject BottomParts;
  [SerializeField]
  private GameObject BottomDeco;
  private ColosseumUtility.Info info;

  public virtual void Foreground()
  {
  }

  public virtual void VScrollBar()
  {
  }

  public override void onBackButton() => this.IbtnBack();

  [DebuggerHidden]
  private IEnumerator DisplayRanking(
    RankingPlayer[] RankingData,
    List<Colosseum02371MenuParts> cacheList,
    RankingPlayer MyRanking)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Colosseum02371Menu.\u003CDisplayRanking\u003Ec__Iterator5E1()
    {
      RankingData = RankingData,
      MyRanking = MyRanking,
      \u003C\u0024\u003ERankingData = RankingData,
      \u003C\u0024\u003EMyRanking = MyRanking,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator Initialize(
    RankingPlayer[] TotalRanking,
    RankingPlayer[] FriendRanking,
    RankingPlayer MyRanking,
    ColosseumUtility.Info colosseumInfo)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Colosseum02371Menu.\u003CInitialize\u003Ec__Iterator5E2()
    {
      colosseumInfo = colosseumInfo,
      MyRanking = MyRanking,
      TotalRanking = TotalRanking,
      FriendRanking = FriendRanking,
      \u003C\u0024\u003EcolosseumInfo = colosseumInfo,
      \u003C\u0024\u003EMyRanking = MyRanking,
      \u003C\u0024\u003ETotalRanking = TotalRanking,
      \u003C\u0024\u003EFriendRanking = FriendRanking,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator InitBottomParts(RankingPlayer rankingData)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Colosseum02371Menu.\u003CInitBottomParts\u003Ec__Iterator5E3()
    {
      rankingData = rankingData,
      \u003C\u0024\u003ErankingData = rankingData,
      \u003C\u003Ef__this = this
    };
  }

  private void DispBottomParts(bool canDisp)
  {
    this.BottomParts.SetActive(canDisp);
    this.BottomDeco.SetActive(canDisp);
    UIWidget component = ((Component) this.ScrollContainer).GetComponent<UIWidget>();
    if (Object.op_Equality((Object) component, (Object) null))
      Debug.LogError((object) "DispBottomParts ScrollContainer里没有UIWidget");
    else if (canDisp)
      component.bottomAnchor.absolute = 207;
    else
      component.bottomAnchor.absolute = 0;
  }

  [DebuggerHidden]
  private IEnumerator DisplayTotalRanking()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Colosseum02371Menu.\u003CDisplayTotalRanking\u003Ec__Iterator5E4()
    {
      \u003C\u003Ef__this = this
    };
  }

  public virtual void IbtnRanking()
  {
    this.RankingBtn.isEnabled = false;
    this.FriendRankibBtn.isEnabled = true;
    this.StartCoroutine(this.DisplayTotalRanking());
  }

  [DebuggerHidden]
  private IEnumerator DisplayFriendRanking()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Colosseum02371Menu.\u003CDisplayFriendRanking\u003Ec__Iterator5E5()
    {
      \u003C\u003Ef__this = this
    };
  }

  public virtual void IbtnRankingFriend()
  {
    this.RankingBtn.isEnabled = true;
    this.FriendRankibBtn.isEnabled = false;
    this.StartCoroutine(this.DisplayFriendRanking());
  }

  public virtual void IbtnBack()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<NGSceneManager>.GetInstance().destroyCurrentScene();
    Colosseum0234Scene.ChangeScene(this.info);
  }
}
