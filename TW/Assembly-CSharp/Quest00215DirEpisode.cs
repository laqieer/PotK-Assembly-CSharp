// Decompiled with JetBrains decompiler
// Type: Quest00215DirEpisode
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Quest00215DirEpisode : MonoBehaviour
{
  [SerializeField]
  private GameObject DirEpisode;
  [SerializeField]
  private GameObject DirEpisodeBlock;
  [SerializeField]
  private GameObject[] DirEpisodenum;
  [SerializeField]
  private UIButton IbtnEpisode;
  [SerializeField]
  private UILabel TxtEpisodetitle;
  [SerializeField]
  private GameObject SlcClear;
  [SerializeField]
  private GameObject SlcNew;
  [SerializeField]
  private GameObject[] DirEpisodenumBlock;
  [SerializeField]
  private UIButton IbtnEpisodeBlock;

  [DebuggerHidden]
  private IEnumerator openPopup002152()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Quest00215DirEpisode.\u003CopenPopup002152\u003Ec__Iterator1FF popup002152CIterator1Ff = new Quest00215DirEpisode.\u003CopenPopup002152\u003Ec__Iterator1FF();
    return (IEnumerator) popup002152CIterator1Ff;
  }

  public void setData(int id, bool isOpen)
  {
    this.DirEpisode.SetActive(isOpen);
    this.DirEpisodeBlock.SetActive(!isOpen);
    foreach (GameObject gameObject in this.DirEpisodenum)
      gameObject.SetActive(false);
    foreach (GameObject gameObject in this.DirEpisodenumBlock)
      gameObject.SetActive(false);
    if (isOpen)
    {
      this.DirEpisodenum[id].SetActive(true);
      EventDelegate.Set(this.IbtnEpisode.onClick, (EventDelegate.Callback) (() => Singleton<NGSceneManager>.GetInstance().changeScene("quest002_15_a", true)));
    }
    else
    {
      this.DirEpisodenumBlock[id].SetActive(true);
      EventDelegate.Set(this.IbtnEpisodeBlock.onClick, (EventDelegate.Callback) (() =>
      {
        Debug.Log((object) ("onClickDirEpisodenumBlock[" + (object) id + "]"));
        this.StartCoroutine(this.openPopup002152());
      }));
    }
    this.TxtEpisodetitle.SetTextLocalize(Consts.GetInstance().plot_test);
    this.SlcClear.SetActive(false);
  }
}
