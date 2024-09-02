// Decompiled with JetBrains decompiler
// Type: Startup00010DownloadContents
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;
using UnityEngine.SceneManagement;

#nullable disable
public class Startup00010DownloadContents : MonoBehaviour
{
  private static Startup00010DownloadContents.ShowParameter showParameter;
  [SerializeField]
  private GameObject miniGameRoot;
  [SerializeField]
  private GameObject[] cameraList;
  public bool complete_ = true;
  public bool error_ = true;
  public bool error_popup_ = true;
  public GameObject btn_GameStart;
  public GameObject button_off;
  public List<GameObject> miniGameObjList;
  public Startup00010MiniGame miniGame;
  public TweenAlpha fade;
  public TweenAlpha fade2;
  public TweenAlpha fade3;
  public int denominator = 100;
  public int numerator;
  public StartupDownLoad startupDL;
  private StartupDownLoad.State state;

  public static void Show(int playingSeconds, Action<int> callback)
  {
    if (Startup00010DownloadContents.showParameter != null)
      return;
    Color org_color = RenderSettings.ambientLight;
    Startup00010DownloadContents.showParameter = new Startup00010DownloadContents.ShowParameter(playingSeconds, (Action<GameObject, int>) ((go, score) =>
    {
      callback(score);
      Startup00010DownloadContents.showParameter = (Startup00010DownloadContents.ShowParameter) null;
      Object.Destroy((Object) go);
      RenderSettings.ambientLight = org_color;
    }));
    RenderSettings.ambientLight = new Color(1f, 1f, 1f, 0.0f);
    SceneManager.LoadScene("startup000_10_localize", (LoadSceneMode) 1);
  }

  private string AddComma(int value)
  {
    char[] array = value.ToString().Reverse<char>().ToArray<char>();
    List<string> self = new List<string>();
    for (; array.Length != 0; array = ((IEnumerable<char>) array).Skip<char>(3).ToArray<char>())
      self.Add(((IEnumerable<char>) array).Take<char>(3).Reverse<char>().ToStringForChars());
    self.Reverse();
    return self.Join(",");
  }

  public void GameStartButtonOn()
  {
    if (Startup00010DownloadContents.showParameter != null)
      Startup00010DownloadContents.showParameter.finishCallback(this.miniGameRoot, this.miniGame.score);
    else
      ((Component) this.fade3).gameObject.SetActive(true);
  }

  [DebuggerHidden]
  private IEnumerator Start()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Startup00010DownloadContents.\u003CStart\u003Ec__Iterator11B()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void Update()
  {
    if (this.state == StartupDownLoad.state)
      return;
    this.state = StartupDownLoad.state;
    switch (this.state)
    {
      case StartupDownLoad.State.Processing:
        this.DLStart();
        break;
      case StartupDownLoad.State.Completed:
        this.DLComplete();
        break;
    }
  }

  private string moviePath() => "android/op_fix_360x640";

  public void GameStart()
  {
    if (Object.op_Inequality((Object) Singleton<NGSoundManager>.GetInstance(), (Object) null))
      Singleton<NGSoundManager>.GetInstance().CheckInitialize(true);
    if (!Persist.tutorial.Data.IsFinishTutorial())
    {
      Persist.tutorial.Data.MiniGameScore = Mathf.Max(this.miniGame.score, Persist.tutorial.Data.MiniGameScore);
      Persist.tutorial.Flush();
    }
    if (DLC.UrlBase == null)
      SceneManager.LoadScene("main");
    else if (ResourceDownloader.Error != null)
      Debug.LogError((object) ResourceDownloader.Error);
    else
      SceneManager.LoadScene("main");
  }

  private void DLStart()
  {
  }

  [DebuggerHidden]
  private IEnumerator Tutorial()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Startup00010DownloadContents.\u003CTutorial\u003Ec__Iterator11C()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void DLComplete()
  {
    ((Component) this.fade2).gameObject.SetActive(true);
    this.btn_GameStart.SetActive(true);
    this.complete_ = true;
    this.button_off.SetActive(false);
    EventTracker.SendEvent(EventTracker.EventType.FINISH_FIRST_DLC);
  }

  private class ShowParameter
  {
    public int PlayingSeconds;
    public Action<GameObject, int> finishCallback;

    public ShowParameter(int seconds, Action<GameObject, int> callback)
    {
      this.PlayingSeconds = seconds;
      this.finishCallback = callback;
    }
  }
}
