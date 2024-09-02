// Decompiled with JetBrains decompiler
// Type: OPMoviePlayScene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using CriMana;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OPMoviePlayScene : MonoBehaviour
{
  [SerializeField]
  private string iosMoviePath;
  [SerializeField]
  private string androidMoviePath;
  [SerializeField]
  private string windowsMoviePath;
  public bool isFinish;

  private string moviePath() => this.windowsMoviePath;

  private void Start() => this.StartCoroutine(this.PlayMovie());

  private IEnumerator PlayMovie()
  {
    OPMoviePlayScene opMoviePlayScene = this;
    Singleton<NGSoundManager>.GetInstance().StopAll();
    string moviepath = opMoviePlayScene.moviePath();
    if (moviepath == "")
    {
      yield return (object) new WaitForEndOfFrame();
      Debug.LogError((object) "Movie path is empty");
      opMoviePlayScene.isFinish = true;
    }
    else
    {
      IEnumerator e = OnDemandDownload.waitLoadMovieResource((IEnumerable<string>) Singleton<ResourceManager>.GetInstance().PathsFromMovie(moviepath), false);
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      string str = Singleton<ResourceManager>.GetInstance().ResolveStreamingAssetsPathForMovie(moviepath);
      Debug.Log((object) ("play : " + new Uri(str).AbsoluteUri + " GameObj name : " + opMoviePlayScene.gameObject.name));
      StatusBarHelper.SetVisibilityForIPhoneX(false);
      WindowsMovieController wmc = (UnityEngine.Object.Instantiate(Resources.Load("Prefabs/WindowsMovie")) as GameObject).GetComponent<WindowsMovieController>();
      wmc.ShowMovie(str);
      yield return (object) new WaitForEndOfFrame();
      while (wmc.movieScreen.player.status != Player.Status.Stop)
        yield return (object) new WaitForEndOfFrame();
      StatusBarHelper.SetVisibilityForIPhoneX(true);
      opMoviePlayScene.isFinish = true;
    }
  }
}
