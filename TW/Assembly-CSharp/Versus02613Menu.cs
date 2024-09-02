// Decompiled with JetBrains decompiler
// Type: Versus02613Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Versus02613Menu : BackButtonMenuBase
{
  [SerializeField]
  protected UILabel txt_RecordTitleString;
  [SerializeField]
  protected UILabel txt_RecordString01;
  [SerializeField]
  protected UILabel txt_RecordString02;
  [SerializeField]
  protected UILabel txt_RecordString03;
  [SerializeField]
  protected UILabel txt_RecordString04;
  [SerializeField]
  protected UILabel txt_RecordString05;
  [SerializeField]
  protected UILabel txt_RecordString06;
  [SerializeField]
  protected UILabel txt_RecordString07;
  [SerializeField]
  protected UILabel txt_RecordString08;
  [SerializeField]
  protected UILabel txt_RecordString09;
  [SerializeField]
  protected UILabel txt_RecordString10;
  [SerializeField]
  protected UILabel txt_RecordString11;
  [SerializeField]
  protected UILabel txt_RandomRecordNum01;
  [SerializeField]
  protected UILabel txt_RandomRecordNum02;
  [SerializeField]
  protected UILabel txt_RandomRecordNum03;
  [SerializeField]
  protected UILabel txt_RandomRecordNum04;
  [SerializeField]
  protected UILabel txt_RandomRecordNum05;
  [SerializeField]
  protected UILabel txt_RandomRecordNum06;
  [SerializeField]
  protected UILabel txt_RandomRecordNum07;
  [SerializeField]
  protected UILabel txt_RandomRecordNum08;
  [SerializeField]
  protected UILabel txt_RandomRecordNum09;
  [SerializeField]
  protected UILabel txt_RandomRecordNum10;
  [SerializeField]
  protected UILabel txt_RandomRecordNum11;
  [SerializeField]
  protected UILabel txt_SeasonTitleString;
  [SerializeField]
  protected UILabel txt_SeasonString01;
  [SerializeField]
  protected UILabel txt_SeasonString02;
  [SerializeField]
  protected UILabel txt_SeasonString03;
  [SerializeField]
  protected UILabel txt_SeasonString04;
  [SerializeField]
  protected UILabel txt_SeasonRecordNum01;
  [SerializeField]
  protected UILabel txt_SeasonRecordNum02;
  [SerializeField]
  protected UILabel txt_SeasonRecordNum03;
  [SerializeField]
  protected UILabel txt_SeasonRecordNum04;
  [SerializeField]
  protected GameObject dir_Ranking;
  [SerializeField]
  protected UILabel txt_RankingNum01;
  [SerializeField]
  protected UILabel txt_RankingNum02;
  [SerializeField]
  protected UILabel txt_RankingNum03;
  [SerializeField]
  protected UILabel txt_RankingNum04;
  [SerializeField]
  protected UILabel txt_RankingNum05;
  [SerializeField]
  protected UILabel txt_RankingNum06;
  [SerializeField]
  protected UILabel txt_RankingNum07;
  [SerializeField]
  protected UILabel txt_RankingString01;
  [SerializeField]
  protected UILabel txt_RankingString02;
  [SerializeField]
  protected UILabel txt_RankingString03;
  [SerializeField]
  protected UILabel txt_RankingString04;
  [SerializeField]
  protected UILabel txt_RankingString05;
  [SerializeField]
  protected UILabel txt_RankingString06;
  [SerializeField]
  protected UILabel txt_RankingString07;
  [SerializeField]
  private UIScrollView scroll;
  [SerializeField]
  private UIGrid grid;

  [DebuggerHidden]
  public IEnumerator Initialize(PvPClassRecord info)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Versus02613Menu.\u003CInitialize\u003Ec__Iterator685()
    {
      info = info,
      \u003C\u0024\u003Einfo = info,
      \u003C\u003Ef__this = this
    };
  }

  public void IbtnBack()
  {
    if (this.IsPushAndSet())
      return;
    this.backScene();
  }

  public override void onBackButton() => this.IbtnBack();
}
