// Decompiled with JetBrains decompiler
// Type: BattleUI05NowRankingPopup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using System.Collections;
using UnityEngine;

#nullable disable
public class BattleUI05NowRankingPopup : MonoBehaviour
{
  [SerializeField]
  private UILabel Txt_totalPoint;
  [SerializeField]
  private UILabel Txt_nowRank;
  [SerializeField]
  private UILabel Txt_upRank;
  [SerializeField]
  private GameObject RankUp;
  private bool isInit;
  private bool onFinish;
  private System.Action closeCallBack;

  public void Init(int totalPoint, int nowRank, int beforeRank)
  {
    this.onFinish = false;
    int num = beforeRank - nowRank;
    ((Component) this.Txt_totalPoint).gameObject.SetActive(true);
    ((Component) this.Txt_nowRank).gameObject.SetActive(true);
    ((Component) this.Txt_upRank).gameObject.SetActive(false);
    this.RankUp.SetActive(false);
    this.Txt_totalPoint.SetTextLocalize(Consts.Lookup("RESULT_RANKING_MENU_POINT", (IDictionary) new Hashtable()
    {
      {
        (object) "point",
        (object) totalPoint
      }
    }));
    this.Txt_nowRank.SetTextLocalize(nowRank.ToString());
    this.Txt_upRank.SetTextLocalize(Consts.Lookup("RESULT_RANKING_MENU_RANKUP", (IDictionary) new Hashtable()
    {
      {
        (object) "rank",
        (object) num
      }
    }));
    this.isInit = true;
  }

  public void DispRankUp(bool disp)
  {
    if (!this.isInit)
      return;
    this.RankUp.SetActive(disp);
    ((Component) this.Txt_upRank).gameObject.SetActive(disp);
  }

  public void SetCloseCallBack(System.Action callback) => this.closeCallBack = callback;

  public void waitFinish() => this.onFinish = true;

  public void OnPress()
  {
    if (this.closeCallBack == null || !this.onFinish)
      return;
    this.closeCallBack();
  }
}
