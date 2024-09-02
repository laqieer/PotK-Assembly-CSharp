// Decompiled with JetBrains decompiler
// Type: MovieLibraryPlayer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using MasterDataTable;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class MovieLibraryPlayer : MonoBehaviour
{
  [SerializeField]
  private GameObject MainPanel;

  public void AttachOpMovie()
  {
    string empty = string.Empty;
    string path = "android/op_fix_360x640";
    this.StartCoroutine(this.Play(new Uri(Singleton<ResourceManager>.GetInstance().ResolveStreamingAssetsPathForMovie(path)).AbsoluteUri));
  }

  public void AttachTutorialMovie1()
  {
    string empty = string.Empty;
    string path = "android/shortmovie_1_360x640";
    this.StartCoroutine(this.Play(new Uri(Singleton<ResourceManager>.GetInstance().ResolveStreamingAssetsPathForMovie(path)).AbsoluteUri));
  }

  public void AttachTutorialMovie2()
  {
    string empty = string.Empty;
    string path = "android/shortmovie_3_360x640";
    this.StartCoroutine(this.Play(new Uri(Singleton<ResourceManager>.GetInstance().ResolveStreamingAssetsPathForMovie(path)).AbsoluteUri));
  }

  public void AttachStoryQuestMovie(int id)
  {
    this.StartCoroutine(this.Play(new Uri(Singleton<ResourceManager>.GetInstance().ResolveStreamingAssetsPathForMovie(this.GetQuestMoviePaht(id))).AbsoluteUri));
  }

  private string GetQuestMoviePaht(int id)
  {
    QuestMovieQuest questMovieQuest = ((IEnumerable<QuestMovieQuest>) MasterData.QuestMovieQuestList).Where<QuestMovieQuest>((Func<QuestMovieQuest, bool>) (x => x.quest_s_id == id)).FirstOrDefault<QuestMovieQuest>();
    string empty = string.Empty;
    return questMovieQuest == null ? string.Empty : questMovieQuest.movie_path.android_path;
  }

  private void Hide()
  {
    Singleton<CommonRoot>.GetInstance().isActiveHeader = false;
    Singleton<CommonRoot>.GetInstance().isActiveFooter = false;
    Singleton<CommonRoot>.GetInstance().setDisableFooterColor(true);
    ((Component) Singleton<CommonRoot>.GetInstance().getBackgroundComponent<Transform>()).gameObject.SetActive(false);
    this.MainPanel.SetActive(false);
  }

  private void Show()
  {
    Singleton<CommonRoot>.GetInstance().isActiveHeader = true;
    Singleton<CommonRoot>.GetInstance().isActiveFooter = true;
    Singleton<CommonRoot>.GetInstance().setDisableFooterColor(false);
    ((Component) Singleton<CommonRoot>.GetInstance().getBackgroundComponent<Transform>()).gameObject.SetActive(true);
    this.MainPanel.SetActive(true);
  }

  [DebuggerHidden]
  private IEnumerator Play(string filePath)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new MovieLibraryPlayer.\u003CPlay\u003Ec__Iterator53A()
    {
      filePath = filePath,
      \u003C\u0024\u003EfilePath = filePath,
      \u003C\u003Ef__this = this
    };
  }
}
