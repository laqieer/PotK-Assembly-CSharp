// Decompiled with JetBrains decompiler
// Type: QuestMoviePlayer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using MasterDataTable;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class QuestMoviePlayer : MonoBehaviour
{
  private string androidMoviePath;
  private System.Action action;
  [SerializeField]
  private GameObject MainPanel;

  public bool isPlayMovie(int s_id) => this.checkSid(s_id);

  public void Attach(int s_id, System.Action act)
  {
    this.action = act;
    this.StartCoroutine(this.Play());
  }

  public void Attach(string fileName, bool enabledSkip, System.Action act)
  {
    this.action = act;
    this.androidMoviePath = string.Format("android/{0}", (object) fileName);
    this.StartCoroutine(this.Play(enabledSkip));
  }

  private bool checkSid(int id)
  {
    QuestMovieQuest questMovieQuest = ((IEnumerable<QuestMovieQuest>) MasterData.QuestMovieQuestList).Where<QuestMovieQuest>((Func<QuestMovieQuest, bool>) (x => x.quest_s_id == id)).FirstOrDefault<QuestMovieQuest>();
    if (questMovieQuest == null)
      return false;
    this.androidMoviePath = questMovieQuest.movie_path.android_path;
    return true;
  }

  private void ChangeScene(bool activeFlag)
  {
    if (this.action == null)
      return;
    Singleton<CommonRoot>.GetInstance().isLoading = activeFlag;
    this.action();
  }

  private string moviePath() => this.androidMoviePath;

  [DebuggerHidden]
  public IEnumerator Play(bool enabledSkip = true)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new QuestMoviePlayer.\u003CPlay\u003Ec__Iterator23B()
    {
      enabledSkip = enabledSkip,
      \u003C\u0024\u003EenabledSkip = enabledSkip,
      \u003C\u003Ef__this = this
    };
  }

  public void HideMainPanel()
  {
    Singleton<CommonRoot>.GetInstance().isActiveHeader = false;
    Singleton<CommonRoot>.GetInstance().isActiveFooter = false;
    Singleton<CommonRoot>.GetInstance().setDisableFooterColor(false);
    if (Object.op_Inequality((Object) Singleton<CommonRoot>.GetInstance().getBackgroundComponent<Transform>(), (Object) null))
      ((Component) Singleton<CommonRoot>.GetInstance().getBackgroundComponent<Transform>()).gameObject.SetActive(false);
    this.MainPanel.SetActive(false);
    ((Component) this).gameObject.SetActive(true);
  }

  public void ShowMainPanel() => this.MainPanel.SetActive(true);
}
