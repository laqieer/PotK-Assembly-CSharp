// Decompiled with JetBrains decompiler
// Type: QuestStartAnim
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using Earth;
using MasterDataTable;
using UnityEngine;

#nullable disable
public class QuestStartAnim : MonoBehaviour
{
  [SerializeField]
  private Animator animator;
  [SerializeField]
  private UILabel chapterLabel;
  [SerializeField]
  private UILabel chapterTitleLabel;
  [SerializeField]
  private UILabel storyLabel;
  [SerializeField]
  private UILabel sotryTitleLabel;

  public void StartAnim(string label)
  {
    EarthDataManager instanceOrNull = Singleton<EarthDataManager>.GetInstanceOrNull();
    if (Object.op_Inequality((Object) instanceOrNull, (Object) null))
    {
      if (instanceOrNull.isStoryPlayBackMode)
      {
        EarthQuestEpisode displayEpsodeData = instanceOrNull.displayEpsodeData;
        this.chapterLabel.SetTextLocalize(displayEpsodeData.chapter.chapter);
        this.chapterTitleLabel.SetTextLocalize(displayEpsodeData.chapter.chapter_name);
        this.storyLabel.SetTextLocalize(displayEpsodeData.episode);
        this.sotryTitleLabel.SetTextLocalize(displayEpsodeData.episode_name);
      }
      else
      {
        EarthQuestProgress questProgress = instanceOrNull.questProgress;
        this.chapterLabel.SetTextLocalize(questProgress.currentEpisode.chapter.chapter);
        this.chapterTitleLabel.SetTextLocalize(questProgress.currentEpisode.chapter.chapter_name);
        this.storyLabel.SetTextLocalize(questProgress.currentEpisode.episode);
        this.sotryTitleLabel.SetTextLocalize(questProgress.currentEpisode.episode_name);
      }
    }
    this.animator.SetInteger(label, 1);
  }

  public void Finish()
  {
    Singleton<CommonRoot>.GetInstance().isActiveBlackBGPanel = false;
    Singleton<PopupManager>.GetInstance().onDismiss();
  }
}
