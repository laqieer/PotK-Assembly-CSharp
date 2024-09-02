// Decompiled with JetBrains decompiler
// Type: BattleUI05NowRankingPopup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using System.Collections;
using UnityEngine;

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
    Consts instance = Consts.GetInstance();
    if ((UnityEngine.Object) this.Txt_totalPoint != (UnityEngine.Object) null)
      this.Txt_totalPoint.gameObject.SetActive(true);
    if ((UnityEngine.Object) this.Txt_nowRank != (UnityEngine.Object) null)
      this.Txt_nowRank.gameObject.SetActive(true);
    if ((UnityEngine.Object) this.Txt_upRank != (UnityEngine.Object) null)
      this.Txt_upRank.gameObject.SetActive(false);
    if ((UnityEngine.Object) this.RankUp != (UnityEngine.Object) null)
      this.RankUp.SetActive(false);
    if ((UnityEngine.Object) this.Txt_totalPoint != (UnityEngine.Object) null)
      this.Txt_totalPoint.SetTextLocalize(Consts.Format(instance.RESULT_RANKING_MENU_POINT, (IDictionary) new Hashtable()
      {
        {
          (object) "point",
          (object) totalPoint
        }
      }));
    if ((UnityEngine.Object) this.Txt_nowRank != (UnityEngine.Object) null)
      this.Txt_nowRank.SetTextLocalize(Consts.Format(instance.RESULT_RANKING_MENU_RANK, (IDictionary) new Hashtable()
      {
        {
          (object) "rank",
          (object) nowRank
        }
      }));
    if ((UnityEngine.Object) this.Txt_upRank != (UnityEngine.Object) null)
      this.Txt_upRank.SetTextLocalize(Consts.Format(instance.RESULT_RANKING_MENU_RANKUP, (IDictionary) new Hashtable()
      {
        {
          (object) "rank",
          (object) num
        }
      }));
    this.isInit = true;
    Singleton<NGSoundManager>.GetInstance().PlaySe("SE_1012", delay: 0.6f);
    Singleton<NGSoundManager>.GetInstance().PlaySe("SE_1012", delay: 0.8f);
  }

  public void DispRankUp(bool disp)
  {
    if (!this.isInit || (UnityEngine.Object) this.RankUp == (UnityEngine.Object) null)
      return;
    this.RankUp.SetActive(disp);
    this.Txt_upRank.gameObject.SetActive(disp);
    if (!disp)
      return;
    Singleton<NGSoundManager>.GetInstance().PlaySe("SE_1500");
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
