﻿// Decompiled with JetBrains decompiler
// Type: CoinLimitScrollContainer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using MasterDataTable;
using SM;
using System;
using System.Collections;
using UnityEngine;

public class CoinLimitScrollContainer : MonoBehaviour
{
  [SerializeField]
  public UIGrid grid;
  [SerializeField]
  public UIScrollView scrollView;
  [SerializeField]
  public UIScrollBar scrollBar;
  [SerializeField]
  public GameObject CoinLimitListPrefab;

  public IEnumerator Init()
  {
    CoinLimitScrollContainer limitScrollContainer = this;
    limitScrollContainer.Clear();
    PlayerCommonTicket[] playerCommonTicketArray = SMManager.Get<PlayerCommonTicket[]>();
    for (int index = 0; index < playerCommonTicketArray.Length; ++index)
    {
      PlayerCommonTicket ticket = playerCommonTicketArray[index];
      if (ticket.quantity > 0 && MasterData.CommonTicket.ContainsKey(ticket.ticket_id) && (MasterData.CommonTicketEndAt.ContainsKey(ticket.ticket_id) && MasterData.CommonTicket[ticket.ticket_id].type == CommonTicketType.sub_coin))
      {
        DateTime endAt = MasterData.CommonTicketEndAt[ticket.ticket_id].end_at;
        DateTime dateTime1 = ServerTime.NowAppTime();
        DateTime dateTime2 = dateTime1.AddDays(2.0);
        if (endAt < dateTime2 && endAt > dateTime1)
        {
          TimeSpan remainingdays = endAt - dateTime1;
          IEnumerator e = limitScrollContainer.CoinLimitListPrefab.Clone(limitScrollContainer.grid.transform).GetComponent<CoinLimitList>().Init(ticket, remainingdays);
          while (e.MoveNext())
            yield return e.Current;
          e = (IEnumerator) null;
        }
      }
    }
    playerCommonTicketArray = (PlayerCommonTicket[]) null;
    // ISSUE: reference to a compiler-generated method
    limitScrollContainer.grid.onReposition = new UIGrid.OnReposition(limitScrollContainer.\u003CInit\u003Eb__4_0);
    limitScrollContainer.grid.Reposition();
  }

  public void Clear()
  {
    foreach (Component component in this.grid.transform)
      UnityEngine.Object.Destroy((UnityEngine.Object) component.gameObject);
    this.grid.transform.Clear();
  }
}
