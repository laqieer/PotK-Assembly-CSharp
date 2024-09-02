// Decompiled with JetBrains decompiler
// Type: Quest00229Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class Quest00229Menu : BackButtonMenuBase
{
  private const int iconWidth = 604;
  private const int iconHeight = 180;
  private const int iconColumnValue = 1;
  private const int iconRowValue = 12;
  private const int iconScreenValue = 8;
  private const int iconMaxValue = 12;
  private const int HIDE_ANCHOR = 0;
  private const int SHOW_ANCHOR = 207;
  private QuestScoreRankingPlayer[] ranking;
  private List<Quest00229MenuParts> allScroll = new List<Quest00229MenuParts>();
  private List<RankingInfo> allRankingInfos = new List<RankingInfo>();
  private bool isInitialize;
  private float scrool_start_y;
  [SerializeField]
  private NGxScroll2 scroll;
  [SerializeField]
  private GameObject DynPlayerRank;
  [SerializeField]
  private GameObject BottomDeco;
  [SerializeField]
  private GameObject BottomParts;
  private GameObject ScrollObject;
  private GameObject TextObject;
  private GameObject IconObject;

  public virtual void Foreground()
  {
  }

  public override void onBackButton() => this.IbtnBack();

  public virtual void IbtnBack()
  {
    if (this.IsPushAndSet())
      return;
    this.backScene();
  }

  public virtual void VScrollBar()
  {
  }

  public void Initialize()
  {
    this.isInitialize = false;
    this.scroll.Clear();
  }

  private void InitializeEnd()
  {
    this.scrool_start_y = ((Component) this.scroll.scrollView).transform.localPosition.y;
    this.isInitialize = true;
  }

  protected override void Update()
  {
    base.Update();
    this.ScrollUpdate();
  }

  protected void ScrollUpdate()
  {
    if (!this.isInitialize || this.allRankingInfos.Count <= 8)
      return;
    int num1 = 360;
    float num2 = ((Component) this.scroll.scrollView).transform.localPosition.y - this.scrool_start_y;
    float num3 = (float) (Mathf.Max(0, this.allRankingInfos.Count - 8 - 1) / 1 * 180);
    float num4 = 2160f;
    if ((double) num2 < 0.0)
      num2 = 0.0f;
    if ((double) num2 > (double) num3)
      num2 = num3;
    bool flag;
    do
    {
      flag = false;
      int num5 = 0;
      foreach (GameObject gameObject in this.scroll)
      {
        GameObject unit = gameObject;
        float num6 = unit.transform.localPosition.y + num2;
        if ((double) num6 > (double) num1)
        {
          int? nullable = this.allRankingInfos.FirstIndexOrNull<RankingInfo>((Func<RankingInfo, bool>) (v => Object.op_Inequality((Object) v.scroll, (Object) null) && Object.op_Equality((Object) ((Component) v.scroll).gameObject, (Object) unit)));
          int info_index = !nullable.HasValue ? this.allRankingInfos.Count : nullable.Value + 12;
          if (nullable.HasValue && info_index < this.allRankingInfos.Count)
          {
            unit.transform.localPosition = new Vector3(unit.transform.localPosition.x, unit.transform.localPosition.y - num4, 0.0f);
            if (info_index >= this.allRankingInfos.Count)
            {
              unit.SetActive(false);
            }
            else
            {
              this.ResetScroll(num5);
              this.StartCoroutine(this.CreateScroll(info_index, num5));
            }
            flag = true;
          }
        }
        else if ((double) num6 < -((double) num4 - (double) num1))
        {
          int num7 = 12;
          if (!unit.activeSelf)
          {
            unit.SetActive(true);
            num7 = 0;
          }
          int? nullable = this.allRankingInfos.FirstIndexOrNull<RankingInfo>((Func<RankingInfo, bool>) (v => Object.op_Inequality((Object) v.scroll, (Object) null) && Object.op_Equality((Object) ((Component) v.scroll).gameObject, (Object) unit)));
          int info_index = !nullable.HasValue ? -1 : nullable.Value - num7;
          if (nullable.HasValue && info_index >= 0)
          {
            unit.transform.localPosition = new Vector3(unit.transform.localPosition.x, unit.transform.localPosition.y + num4, 0.0f);
            this.ResetScroll(num5);
            this.StartCoroutine(this.CreateScroll(info_index, num5));
            flag = true;
          }
        }
        ++num5;
      }
    }
    while (flag);
  }

  private void InitializePresentInfo(QuestScoreRankingPlayer[] players)
  {
    this.allRankingInfos.Clear();
    foreach (QuestScoreRankingPlayer player in players)
      this.allRankingInfos.Add(new RankingInfo()
      {
        player = player
      });
  }

  private void ResetScroll(int index)
  {
    Quest00229MenuParts scroll = this.allScroll[index];
    ((Component) scroll).gameObject.SetActive(false);
    this.allRankingInfos.Where<RankingInfo>((Func<RankingInfo, bool>) (a => Object.op_Equality((Object) a.scroll, (Object) scroll))).ForEach<RankingInfo>((Action<RankingInfo>) (b => b.scroll = (Quest00229MenuParts) null));
  }

  [DebuggerHidden]
  private IEnumerator CreateScroll(int info_index, int unit_index)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00229Menu.\u003CCreateScroll\u003Ec__Iterator213()
    {
      unit_index = unit_index,
      info_index = info_index,
      \u003C\u0024\u003Eunit_index = unit_index,
      \u003C\u0024\u003Einfo_index = info_index,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator Init(
    WebAPI.Response.QuestRankingExtra questRankingExtra)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00229Menu.\u003CInit\u003Ec__Iterator214()
    {
      questRankingExtra = questRankingExtra,
      \u003C\u0024\u003EquestRankingExtra = questRankingExtra,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator CreateRanking(
    QuestScoreRankingPlayer[] RankingData,
    QuestScoreRankingPlayer MyRanking)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00229Menu.\u003CCreateRanking\u003Ec__Iterator215()
    {
      RankingData = RankingData,
      MyRanking = MyRanking,
      \u003C\u0024\u003ERankingData = RankingData,
      \u003C\u0024\u003EMyRanking = MyRanking,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator InitBottomParts(QuestScoreRankingPlayer rankingData)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00229Menu.\u003CInitBottomParts\u003Ec__Iterator216()
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
    UIWidget component = ((Component) this.scroll).GetComponent<UIWidget>();
    if (Object.op_Equality((Object) component, (Object) null))
      Debug.LogError((object) "DispBottomParts ScrollContainerにUIWidgetがありません");
    else if (canDisp)
      component.bottomAnchor.absolute = 207;
    else
      component.bottomAnchor.absolute = 0;
  }
}
