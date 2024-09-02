// Decompiled with JetBrains decompiler
// Type: Story059ItemData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using Earth;
using MasterDataTable;
using System;
using System.Collections;
using System.Diagnostics;

#nullable disable
public class Story059ItemData
{
  public int _episodeID;
  public Story0593ScrollItem _myStory0593ScrollItem;
  public Story059ItemData.PlayType playType;
  private string moviePath;
  private int storyPlaybackID;

  public Story059ItemData(
    int episodeID,
    Story059ItemData.PlayType type,
    string moviePath = null,
    int storyPlaybackID = 0)
  {
    this._episodeID = episodeID;
    this.playType = type;
    this.moviePath = moviePath;
    this.storyPlaybackID = storyPlaybackID;
  }

  public EarthQuestEpisode episode => MasterData.EarthQuestEpisode[this._episodeID];

  public EarthQuestChapter chaptor => this.episode.chapter;

  public EarthQuestStoryPlayback storyPlayback
  {
    get
    {
      return MasterData.EarthQuestStoryPlayback.ContainsKey(this.storyPlaybackID) ? MasterData.EarthQuestStoryPlayback[this.storyPlaybackID] : (EarthQuestStoryPlayback) null;
    }
  }

  public string title
  {
    get => this.storyPlayback != null ? this.storyPlayback.title : this.episode.episode_name;
  }

  private string GetMoviePath() => "android/" + this.moviePath;

  public void Play()
  {
    if (this.playType != Story059ItemData.PlayType.MOVIE)
    {
      Singleton<EarthDataManager>.GetInstance().displayEpsodeData = this.episode;
      Singleton<EarthDataManager>.GetInstance().isStoryPlayBackMode = true;
    }
    if (this.playType == Story059ItemData.PlayType.MOVIE && !string.IsNullOrEmpty(this.moviePath))
    {
      string absoluteUri = new Uri(Singleton<ResourceManager>.GetInstance().ResolveStreamingAssetsPathForMovie(this.GetMoviePath())).AbsoluteUri;
      Singleton<CommonRoot>.GetInstance().StartCoroutine(this.PlayMovie(absoluteUri));
    }
    else if (this.playType == Story059ItemData.PlayType.STORY_SCRIPT && MasterData.EarthQuestStoryPlayback.ContainsKey(this.storyPlaybackID))
    {
      Story0093Scene.changeScene009_3(true, this.storyPlayback.script_id);
    }
    else
    {
      if (this.playType != Story059ItemData.PlayType.STORY_SCRIPT || !this.episode.script.HasValue)
        return;
      Story0093Scene.changeScene009_3(true, this.episode.script.Value);
    }
  }

  [DebuggerHidden]
  private IEnumerator PlayMovie(string filePath)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Story059ItemData.\u003CPlayMovie\u003Ec__Iterator862()
    {
      filePath = filePath,
      \u003C\u0024\u003EfilePath = filePath,
      \u003C\u003Ef__this = this
    };
  }

  public enum PlayType
  {
    STORY_SCRIPT,
    MOVIE,
  }
}
