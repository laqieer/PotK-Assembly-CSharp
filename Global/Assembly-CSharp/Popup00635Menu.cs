// Decompiled with JetBrains decompiler
// Type: Popup00635Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using UniLinq;
using UnityEngine;

#nullable disable
public class Popup00635Menu : BackButtonMenuBase
{
  private System.Action playGachaTicket;
  [SerializeField]
  private UILabel ticketName;
  [SerializeField]
  private UILabel description;
  [SerializeField]
  private UILabel ticketCount;

  public void Init(GachaModuleGacha gachaData, System.Action playGacha)
  {
    int key = gachaData.payment_id.Value;
    GachaTicket gachaTicket = MasterData.GachaTicket[key];
    Dictionary<int, PlayerGachaTicket> dictionary = ((IEnumerable<PlayerGachaTicket>) SMManager.Get<Player>().gacha_tickets).ToDictionary<PlayerGachaTicket, int>((Func<PlayerGachaTicket, int>) (x => x.ticket_id));
    this.ticketName.SetTextLocalize(gachaTicket.name);
    this.description.SetTextLocalize(Consts.Lookup("GACHA_00635TICKET_DESCRIPTION", (IDictionary) new Hashtable()
    {
      {
        (object) "ticketcount",
        (object) gachaData.payment_amount.ToString()
      }
    }));
    this.ticketCount.SetTextLocalize(dictionary[key].quantity);
    this.playGachaTicket = playGacha;
  }

  public void IbtnPlayTicketGacha()
  {
    if (this.IsPushAndSet())
      return;
    this.playGachaTicket();
  }

  public void IbtnBack()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().dismiss();
  }

  public override void onBackButton() => this.IbtnBack();
}
