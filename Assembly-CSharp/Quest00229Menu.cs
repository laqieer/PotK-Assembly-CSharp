// Decompiled with JetBrains decompiler
// Type: Quest00229Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using UniLinq;
using UnityEngine;

public class Quest00229Menu : BackButtonMenuBase
{
  private const int iconWidth = 604;
  private const int iconHeight = 180;
  private const int iconColumnValue = 1;
  private const int iconRowValue = 12;
  private const int iconScreenValue = 8;
  private const int iconMaxValue = 12;
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
  private const int HIDE_ANCHOR = 0;
  private const int SHOW_ANCHOR = 207;

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
    this.scrool_start_y = this.scroll.scrollView.transform.localPosition.y;
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
    float num2 = this.scroll.scrollView.transform.localPosition.y - this.scrool_start_y;
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
          int? nullable = this.allRankingInfos.FirstIndexOrNull<RankingInfo>((Func<RankingInfo, bool>) (v => (UnityEngine.Object) v.scroll != (UnityEngine.Object) null && (UnityEngine.Object) v.scroll.gameObject == (UnityEngine.Object) unit));
          int info_index = nullable.HasValue ? nullable.Value + 12 : this.allRankingInfos.Count;
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
          int? nullable = this.allRankingInfos.FirstIndexOrNull<RankingInfo>((Func<RankingInfo, bool>) (v => (UnityEngine.Object) v.scroll != (UnityEngine.Object) null && (UnityEngine.Object) v.scroll.gameObject == (UnityEngine.Object) unit));
          int info_index = nullable.HasValue ? nullable.Value - num7 : -1;
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
    scroll.gameObject.SetActive(false);
    this.allRankingInfos.Where<RankingInfo>((Func<RankingInfo, bool>) (a => (UnityEngine.Object) a.scroll == (UnityEngine.Object) scroll)).ForEach<RankingInfo>((System.Action<RankingInfo>) (b => b.scroll = (Quest00229MenuParts) null));
  }

  private IEnumerator CreateScroll(int info_index, int unit_index)
  {
    Quest00229MenuParts scroll = this.allScroll[unit_index];
    this.allRankingInfos.Where<RankingInfo>((Func<RankingInfo, bool>) (a => (UnityEngine.Object) a.scroll == (UnityEngine.Object) scroll)).ForEach<RankingInfo>((System.Action<RankingInfo>) (b => b.scroll = (Quest00229MenuParts) null));
    this.allRankingInfos[info_index].scroll = scroll;
    scroll.Init(this.allRankingInfos[info_index].player);
    IEnumerable<Transform> children = scroll.transform.GetChildren();
    if (children != null)
    {
      foreach (Transform transform in children)
      {
        if (transform.name == "TextParts")
          UnityEngine.Object.Destroy((UnityEngine.Object) transform.gameObject);
      }
    }
    if ((UnityEngine.Object) this.allRankingInfos[info_index].TextObject == (UnityEngine.Object) null)
    {
      GameObject textGo = this.TextObject.Clone(scroll.transform);
      IEnumerator e = textGo.GetComponent<Quest00229MenuTextParts>().Init(this.allRankingInfos[info_index].player, this.IconObject);
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      textGo.name = "TextParts";
      this.allRankingInfos[info_index].TextObject = textGo;
      textGo = (GameObject) null;
    }
    else
      this.allRankingInfos[info_index].TextObject.SetParent(scroll.transform.gameObject);
    scroll.gameObject.SetActive(true);
  }

  public IEnumerator Init(
    WebAPI.Response.QuestRankingExtra questRankingExtra)
  {
    Future<GameObject> prefabF = Res.Prefabs.quest002_29.vscroll_810_12.Load<GameObject>();
    IEnumerator e = prefabF.Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    this.ScrollObject = prefabF.Result;
    Future<GameObject> prefabTextF = Res.Prefabs.quest002_29.vscroll_810_12_text.Load<GameObject>();
    e = prefabTextF.Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    this.TextObject = prefabTextF.Result;
    Future<GameObject> prefabIconF = Res.Prefabs.UnitIcon.normal.Load<GameObject>();
    e = prefabIconF.Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    this.IconObject = prefabIconF.Result;
    this.Initialize();
    this.InitializePresentInfo(questRankingExtra.ranking);
    e = this.CreateRanking(questRankingExtra.ranking, questRankingExtra.my_ranking);
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    this.scroll.ResolvePosition();
    this.InitializeEnd();
  }

  private IEnumerator CreateRanking(
    QuestScoreRankingPlayer[] RankingData,
    QuestScoreRankingPlayer MyRanking)
  {
    this.allScroll.Clear();
    if (this.allRankingInfos.Count > 0)
    {
      for (int index = 0; index < Mathf.Min(12, this.allRankingInfos.Count); ++index)
        this.allScroll.Add(this.ScrollObject.Clone().GetComponent<Quest00229MenuParts>());
      this.scroll.Reset();
      for (int index = 0; index < Mathf.Min(12, this.allScroll.Count); ++index)
        this.scroll.AddColumn1(this.allScroll[index].gameObject, 604, 180);
      this.scroll.CreateScrollPointHeight(180, this.allRankingInfos.Count);
      this.scroll.ResolvePosition();
      for (int index = 0; index < Mathf.Min(12, this.allRankingInfos.Count); ++index)
        this.ResetScroll(index);
      IEnumerator e;
      for (int i = 0; i < Mathf.Min(12, this.allRankingInfos.Count); ++i)
      {
        e = this.CreateScroll(i, i);
        while (e.MoveNext())
          yield return e.Current;
        e = (IEnumerator) null;
      }
      QuestScoreRankingPlayer rankingData = ((IEnumerable<QuestScoreRankingPlayer>) RankingData).FirstOrDefault<QuestScoreRankingPlayer>((Func<QuestScoreRankingPlayer, bool>) (x => x.player_id == MyRanking.player_id));
      if (rankingData == null)
      {
        e = this.InitBottomParts(MyRanking);
        while (e.MoveNext())
          yield return e.Current;
        e = (IEnumerator) null;
      }
      else
      {
        e = this.InitBottomParts(rankingData);
        while (e.MoveNext())
          yield return e.Current;
        e = (IEnumerator) null;
      }
    }
    this.scroll.ResolvePosition();
  }

  private IEnumerator InitBottomParts(QuestScoreRankingPlayer rankingData)
  {
    Quest00229MenuParts component = this.BottomParts.GetComponent<Quest00229MenuParts>();
    component.Init(rankingData);
    Quest00229MenuTextParts quest00229MenuTextParts = component.GetTextDir().GetComponentInChildren<Quest00229MenuTextParts>();
    if ((UnityEngine.Object) quest00229MenuTextParts == (UnityEngine.Object) null)
      quest00229MenuTextParts = this.TextObject.Clone(component.GetTextDir().transform).GetComponent<Quest00229MenuTextParts>();
    IEnumerator e = quest00229MenuTextParts.Init(rankingData, this.IconObject);
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
  }

  private void DispBottomParts(bool canDisp)
  {
    this.BottomParts.SetActive(canDisp);
    this.BottomDeco.SetActive(canDisp);
    UIWidget component = this.scroll.GetComponent<UIWidget>();
    if ((UnityEngine.Object) component == (UnityEngine.Object) null)
      Debug.LogError((object) "DispBottomParts ScrollContainerにUIWidgetがありません");
    else if (canDisp)
      component.bottomAnchor.absolute = 207;
    else
      component.bottomAnchor.absolute = 0;
  }
}
