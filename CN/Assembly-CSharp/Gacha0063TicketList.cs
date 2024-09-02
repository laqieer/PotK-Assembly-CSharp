// Decompiled with JetBrains decompiler
// Type: Gacha0063TicketList
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class Gacha0063TicketList : Gacha0063hindicator
{
  [SerializeField]
  private UIGrid mScrollGrid;
  [SerializeField]
  private NGOverlapScrollView mOverlapScrollView;
  [SerializeField]
  private UIPanel mScrollViewPanel;
  [SerializeField]
  private int topOffest;
  [SerializeField]
  private int bottomOffest;
  private List<GachaModuleGacha> mDispTicketGachaList;
  private Gacha0063Menu menu;
  private GameObject listItem;

  public override void InitGachaModuleGacha(
    Gacha0063Menu gacha0063Menu,
    GachaModule gachaModule,
    DateTime serverTime,
    UIScrollView scrollView)
  {
    Dictionary<int, PlayerGachaTicket> ticketDict = ((IEnumerable<PlayerGachaTicket>) SMManager.Get<Player>().gacha_tickets).ToDictionary<PlayerGachaTicket, int>((Func<PlayerGachaTicket, int>) (x => x.ticket_id));
    Transform transform = ((Component) ((Component) gacha0063Menu).transform.Find("MainPanel")).transform;
    this.menu = gacha0063Menu;
    this.mScrollViewPanel.topAnchor.target = transform;
    this.mScrollViewPanel.topAnchor.absolute = this.topOffest;
    this.mScrollViewPanel.topAnchor.relative = 0.5f;
    this.mScrollViewPanel.bottomAnchor.target = transform;
    this.mScrollViewPanel.bottomAnchor.absolute = this.bottomOffest;
    this.mDispTicketGachaList = ((IEnumerable<GachaModuleGacha>) gachaModule.gacha).Where<GachaModuleGacha>((Func<GachaModuleGacha, bool>) (x => x.payment_id.HasValue && ticketDict.ContainsKey(x.payment_id.Value) && ticketDict[x.payment_id.Value].quantity > 0)).OrderBy<GachaModuleGacha, int>((Func<GachaModuleGacha, int>) (x => ticketDict[x.payment_id.Value].quantity >= x.payment_amount ? 0 : 1)).ThenBy<GachaModuleGacha, int>((Func<GachaModuleGacha, int>) (x => ticketDict[x.payment_id.Value].ticket.priority)).ThenBy<GachaModuleGacha, DateTime>((Func<GachaModuleGacha, DateTime>) (x => x.end_at.HasValue ? x.end_at.Value : serverTime)).ToList<GachaModuleGacha>();
    this.mOverlapScrollView.SetOverlapScrollView(scrollView);
  }

  [DebuggerHidden]
  public override IEnumerator Set(
    GameObject detailPopup,
    GameObject textPrefab,
    GameObject spritePrefab)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Gacha0063TicketList.\u003CSet\u003Ec__Iterator401()
    {
      detailPopup = detailPopup,
      textPrefab = textPrefab,
      spritePrefab = spritePrefab,
      \u003C\u0024\u003EdetailPopup = detailPopup,
      \u003C\u0024\u003EtextPrefab = textPrefab,
      \u003C\u0024\u003EspritePrefab = spritePrefab,
      \u003C\u003Ef__this = this
    };
  }
}
