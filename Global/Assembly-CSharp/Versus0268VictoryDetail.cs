// Decompiled with JetBrains decompiler
// Type: Versus0268VictoryDetail
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using MasterDataTable;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Versus0268VictoryDetail : MonoBehaviour
{
  [SerializeField]
  private UILabel TxtDraw;
  [SerializeField]
  private UILabel TxtLose;
  [SerializeField]
  private UILabel TxtWin;
  [SerializeField]
  private UILabel TxtRankPoint;
  [SerializeField]
  private UILabel TxtRank;
  [SerializeField]
  private UILabel TxtClass;
  [SerializeField]
  private UILabel TxtZeny;
  [SerializeField]
  private UISprite slcRankGaugeBlue;
  [SerializeField]
  private UISprite slcRankGaugeGreen;
  [SerializeField]
  private UISprite slcRankGaugeYellow;
  [SerializeField]
  private UISprite slcRankGaugeRed;
  [SerializeField]
  private GameObject slcRankGaugeNowParent;
  [SerializeField]
  private UISprite slcRankGaugeNow;
  [SerializeField]
  private UISprite slcClassCondition;
  [SerializeField]
  private Transform dirClassConditionParent;
  [SerializeField]
  private GameObject NextGaugeAnimation;
  private bool arrowAnim;
  private bool nextAnim;
  private float waitTime;

  public float WaitTime => this.waitTime;

  [DebuggerHidden]
  public IEnumerator SetDefault(
    WebAPI.Response.PvpPlayerFinish finish,
    Versus0268Menu.PvpParam param)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Versus0268VictoryDetail.\u003CSetDefault\u003Ec__Iterator5B2()
    {
      finish = finish,
      param = param,
      \u003C\u0024\u003Efinish = finish,
      \u003C\u0024\u003Eparam = param,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator SetConditionSprite(PvpClassKind c, int nowWin)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Versus0268VictoryDetail.\u003CSetConditionSprite\u003Ec__Iterator5B3()
    {
      c = c,
      nowWin = nowWin,
      \u003C\u0024\u003Ec = c,
      \u003C\u0024\u003EnowWin = nowWin,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator SetConditionEffect(PvpClassKind.Condition condition)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Versus0268VictoryDetail.\u003CSetConditionEffect\u003Ec__Iterator5B4()
    {
      condition = condition,
      \u003C\u0024\u003Econdition = condition,
      \u003C\u003Ef__this = this
    };
  }

  private void SetRankGauge(PvpClassKind c)
  {
    int width = this.slcRankGaugeRed.width;
    int num = 10;
    this.slcRankGaugeBlue.width = (c.stay_point - 1) * width / num + 1;
    this.slcRankGaugeGreen.width = (c.up_point - 1) * width / num + 1;
    this.slcRankGaugeYellow.width = (c.title_point - 1) * width / num + 1;
    ((Component) this.slcRankGaugeBlue).gameObject.SetActive(c.stay_point > 0);
    ((Component) this.slcRankGaugeGreen).gameObject.SetActive(c.up_point - c.stay_point > 0);
    ((Component) this.slcRankGaugeYellow).gameObject.SetActive(c.title_point - c.up_point > 0);
    ((Component) this.slcRankGaugeRed).gameObject.SetActive(true);
  }

  private void SetArrow(int win)
  {
    int num = 10;
    int width = this.slcRankGaugeRed.width;
    win = !this.arrowAnim ? win : win - 1;
    this.slcRankGaugeNowParent.transform.localPosition = new Vector3(((Component) this.slcRankGaugeRed).transform.localPosition.x + (float) (Mathf.Clamp(win, 0, num) * width / num), this.slcRankGaugeNowParent.transform.localPosition.y);
  }

  public void StartAnimationArrow()
  {
    if (!this.arrowAnim)
      return;
    this.StartCoroutine(this.StartAnim());
  }

  [DebuggerHidden]
  private IEnumerator StartAnim()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Versus0268VictoryDetail.\u003CStartAnim\u003Ec__Iterator5B5()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void NextAnimation()
  {
    if (!this.nextAnim)
      return;
    this.NextGaugeAnimation.SetActive(true);
    Singleton<NGSoundManager>.GetInstance().playSE("SE_0553");
  }
}
