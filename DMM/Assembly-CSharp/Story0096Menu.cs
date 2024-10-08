﻿// Decompiled with JetBrains decompiler
// Type: Story0096Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using UniLinq;
using UnityEngine;

public class Story0096Menu : BackButtonMenuBase
{
  [SerializeField]
  protected UILabel TxtTitle;
  [SerializeField]
  private UISprite slcCountry;
  [SerializeField]
  private UI2DSprite slcInclusion;
  [SerializeField]
  private NGxScroll ScrollContainer;
  [SerializeField]
  private UI2DSprite DynCharacter;
  [SerializeField]
  private GameObject DirNoStory;
  private int m_id;
  private int m_windowHeight;
  private int m_windowWidth;

  public IEnumerator Init(int id)
  {
    Story0096Menu story0096Menu = this;
    story0096Menu.m_id = id;
    story0096Menu.m_windowHeight = Screen.height;
    story0096Menu.m_windowWidth = Screen.width;
    story0096Menu.TxtTitle.SetTextLocalize(MasterData.UnitUnit[id].name);
    if ((UnityEngine.Object) story0096Menu.slcCountry != (UnityEngine.Object) null)
    {
      story0096Menu.slcCountry.gameObject.SetActive(false);
      if (MasterData.UnitUnit[id].country_attribute.HasValue)
      {
        story0096Menu.slcCountry.gameObject.SetActive(true);
        MasterData.UnitUnit[id].SetCuntrySpriteName(ref story0096Menu.slcCountry);
      }
    }
    IEnumerator e;
    if ((UnityEngine.Object) story0096Menu.slcInclusion != (UnityEngine.Object) null)
    {
      story0096Menu.slcInclusion.gameObject.SetActive(false);
      if (MasterData.UnitUnit[id].inclusion_ip.HasValue)
      {
        story0096Menu.slcInclusion.gameObject.SetActive(true);
        e = MasterData.UnitUnit[id].SetInclusionIP(story0096Menu.slcInclusion);
        while (e.MoveNext())
          yield return e.Current;
        e = (IEnumerator) null;
      }
    }
    e = story0096Menu.SetCharacterLargeImage(id);
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    story0096Menu.ScrollContainer.Clear();
    e = story0096Menu.CreateEpisodes(id);
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    // ISSUE: reference to a compiler-generated method
    story0096Menu.ScrollContainer.GridReposition(new UIGrid.OnReposition(story0096Menu.\u003CInit\u003Eb__9_0));
  }

  public virtual void Foreground()
  {
  }

  public virtual void IbtnEpisode()
  {
  }

  public virtual void IbtnEpisodeBlock()
  {
  }

  public virtual void VScrollBar()
  {
  }

  public override void onBackButton() => this.IbtnBack();

  public virtual void IbtnBack()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<NGSceneManager>.GetInstance().changeScene("story009_5", false, (object) false);
  }

  private IEnumerator SetCharacterLargeImage(int id)
  {
    this.DynCharacter.transform.Clear();
    UnitUnit unit = MasterData.UnitUnit[id];
    Future<GameObject> goFuture = unit.LoadMypage();
    IEnumerator e = goFuture.Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    e = unit.SetLargeSpriteSnap(goFuture.Result.Clone(this.DynCharacter.transform), 5);
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
  }

  public IEnumerator CreateEpisodes(int id)
  {
    Story0096Menu story0096Menu = this;
    Future<GameObject> prefabEpisodeF = Res.Prefabs.story009_6.story0096DirEpisode.Load<GameObject>();
    IEnumerator e = prefabEpisodeF.Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    GameObject result = prefabEpisodeF.Result;
    PlayerCharacterQuestS[] playerCharacterQuestSArray = SMManager.Get<PlayerCharacterQuestS[]>();
    List<PlayerCharacterQuestS> questsList = new List<PlayerCharacterQuestS>();
    List<StoryPlaybackCharacterDetail> playbackList = new List<StoryPlaybackCharacterDetail>();
    List<Story0093Scene.ContinuousData> continuousDataList = new List<Story0093Scene.ContinuousData>();
    ((IEnumerable<PlayerCharacterQuestS>) playerCharacterQuestSArray).OrderBy<PlayerCharacterQuestS, int>((Func<PlayerCharacterQuestS, int>) (x => x.quest_character_s.ID)).ForEach<PlayerCharacterQuestS>((System.Action<PlayerCharacterQuestS>) (qu =>
    {
      if (qu.quest_character_s.unit.ID != id || !qu.is_clear)
        return;
      ((IEnumerable<StoryPlaybackCharacterDetail>) MasterData.StoryPlaybackCharacterDetailList).Where<StoryPlaybackCharacterDetail>((Func<StoryPlaybackCharacterDetail, bool>) (x => x.quest.ID == qu.quest_character_s.ID && x.timing_StoryPlaybackTiming != 2)).OrderBy<StoryPlaybackCharacterDetail, int>((Func<StoryPlaybackCharacterDetail, int>) (x => x.ID)).ForEach<StoryPlaybackCharacterDetail>((System.Action<StoryPlaybackCharacterDetail>) (story =>
      {
        questsList.Add(qu);
        playbackList.Add(story);
        continuousDataList.Add(new Story0093Scene.ContinuousData()
        {
          scriptId_ = story.script_id,
          continuousFlag_ = story.continuous_flag
        });
      }));
    }));
    for (int index = 0; index < questsList.Count; ++index)
    {
      GameObject gameObject = result.Clone();
      story0096Menu.ScrollContainer.Add(gameObject);
      gameObject.GetComponent<Story0096EpisodeParts>().setData(questsList[index], playbackList[index], (NGMenuBase) story0096Menu, continuousDataList);
    }
    story0096Menu.DirNoStory.SetActive(story0096Menu.ScrollContainer.grid.transform.childCount <= 0);
  }

  protected override void Update()
  {
    if (this.m_id == 0)
      return;
    if (this.m_windowHeight != Screen.height || this.m_windowWidth != Screen.width)
    {
      this.StartCoroutine(this.Init(this.m_id));
      this.m_windowHeight = Screen.height;
      this.m_windowWidth = Screen.width;
    }
    base.Update();
  }
}
