// Decompiled with JetBrains decompiler
// Type: Guild0281HuntingButton
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using SM;
using System;
using UnityEngine;

#nullable disable
public class Guild0281HuntingButton : MonoBehaviour
{
  [SerializeField]
  private MypageSlidePanelDragged slidpanel;
  [SerializeField]
  private GameObject open;
  [SerializeField]
  private UILabel openTime;
  [SerializeField]
  private GameObject recieve;
  [SerializeField]
  private UILabel recieveTime;
  [SerializeField]
  private GameObject bonus;

  public void EventClose()
  {
    this.open.SetActive(false);
    this.recieve.SetActive(false);
    this.bonus.SetActive(false);
    this.slidpanel.ChangeState(false);
  }

  public void Initialize(EventInfo eventInfo, DateTime serverTime)
  {
    this.bonus.SetActive(false);
    this.open.SetActive(false);
    this.recieve.SetActive(false);
    if (eventInfo.start_at.CompareTo(serverTime) < 0 && eventInfo.final_at.CompareTo(serverTime) > 0)
    {
      this.slidpanel.ChangeState(true);
      if (eventInfo.end_at.CompareTo(serverTime) < 0)
      {
        TimeSpan self = eventInfo.final_at - serverTime;
        this.recieve.SetActive(true);
        this.recieveTime.SetTextLocalize(self.DisplayString());
      }
      else
      {
        this.openTime.SetTextLocalize((eventInfo.end_at - serverTime).DisplayString());
        this.open.SetActive(true);
        this.bonus.SetActive(eventInfo.is_bonus_term);
      }
    }
    else
      this.EventClose();
  }
}
