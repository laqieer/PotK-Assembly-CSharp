// Decompiled with JetBrains decompiler
// Type: Story0592Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using Earth;
using GameCore;
using MasterDataTable;
using System;
using System.Collections;
using System.Collections.Generic;
using UniLinq;
using UnityEngine;

public class Story0592Menu : BackButtonMenuBase
{
  [SerializeField]
  private UIGrid mGrid;
  [SerializeField]
  private UIScrollView mScrollView;
  private GameObject mScrollParts;

  public IEnumerator InitSceneAsync()
  {
    Future<GameObject> scrollPartsF = Res.Prefabs.story059_2.story0592scroll.Load<GameObject>();
    IEnumerator e = scrollPartsF.Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    this.mScrollParts = scrollPartsF.Result;
  }

  public IEnumerator StartSceneAsync()
  {
    IEnumerable<Story059ItemData> first = ((IEnumerable<EarthQuestPologue>) MasterData.EarthQuestPologueList).Where<EarthQuestPologue>((Func<EarthQuestPologue, bool>) (x => x.type == "movie")).Select<EarthQuestPologue, Story059ItemData>((Func<EarthQuestPologue, Story059ItemData>) (x => new Story059ItemData(x.episode.ID, Story059ItemData.PlayType.MOVIE, x.arg1)));
    EarthQuestProgress quesetProgress = Singleton<EarthDataManager>.GetInstance().questProgress;
    IEnumerable<Story059ItemData> story059ItemDatas = ((IEnumerable<EarthQuestEpisode>) MasterData.EarthQuestEpisodeList).Where<EarthQuestEpisode>((Func<EarthQuestEpisode, bool>) (x => x.script.HasValue)).Where<EarthQuestEpisode>((Func<EarthQuestEpisode, bool>) (x => quesetProgress.isCleared && x.stage_index <= quesetProgress.currentEpisode.stage_index || x.stage_index < quesetProgress.currentEpisode.stage_index)).Select<EarthQuestEpisode, Story059ItemData>((Func<EarthQuestEpisode, Story059ItemData>) (x => new Story059ItemData(x.ID, Story059ItemData.PlayType.STORY_SCRIPT)));
    IEnumerable<Story059ItemData> second1 = ((IEnumerable<EarthQuestStoryPlayback>) MasterData.EarthQuestStoryPlaybackList).Where<EarthQuestStoryPlayback>((Func<EarthQuestStoryPlayback, bool>) (x => quesetProgress.isCleared && x.episode.stage_index <= quesetProgress.currentEpisode.stage_index || x.episode.stage_index < quesetProgress.currentEpisode.stage_index)).Select<EarthQuestStoryPlayback, Story059ItemData>((Func<EarthQuestStoryPlayback, Story059ItemData>) (x => new Story059ItemData(x.episode.ID, Story059ItemData.PlayType.STORY_SCRIPT, storyPlaybackID: x.ID)));
    IEnumerable<Story059ItemData> second2 = story059ItemDatas;
    foreach (IGrouping<EarthQuestChapter, Story059ItemData> grouping in first.Concat<Story059ItemData>(second2).Concat<Story059ItemData>(second1).GroupBy<Story059ItemData, EarthQuestChapter>((Func<Story059ItemData, EarthQuestChapter>) (x => x.chaptor)))
      this.mScrollParts.CloneAndGetComponent<Story0592ScrollItem>(this.mGrid.gameObject).Init(grouping.Key, (IEnumerable<Story059ItemData>) grouping);
    this.mGrid.onReposition = (UIGrid.OnReposition) (() =>
    {
      this.mScrollView.ResetPosition();
      this.mGrid.onReposition = (UIGrid.OnReposition) null;
    });
    this.mGrid.Reposition();
    yield break;
  }

  public override void onBackButton()
  {
    if (this.IsPushAndSet())
      return;
    this.backScene();
  }
}
