// Decompiled with JetBrains decompiler
// Type: WindowsMovieController
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using CriMana;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WindowsMovieController : MonoBehaviour
{
  public CriManaMovieControllerForUI movieScreen;
  private RectTransform rect;
  [SerializeField]
  private GameObject windowsMovie;
  [SerializeField]
  private WindowScreenController _myScreenController;
  [SerializeField]
  private GameObject btnExpand;
  [SerializeField]
  private GameObject btnContract;

  private void Start() => this.ActiveExpandButtons(false);

  private void LateUpdate()
  {
    if (!((Object) this.movieScreen != (Object) null) || this.movieScreen.player.status != Player.Status.Playing)
      return;
    this.ResizeMovie();
    this.SetButton();
  }

  public void ShowMovie(string moviePath)
  {
    this.SetMovie(moviePath);
    this.StartCoroutine(this.LoadAndPlayMovie());
  }

  private IEnumerator LoadAndPlayMovie()
  {
    yield return (object) new WaitForEndOfFrame();
    this.PlayMovieInWindowScreen();
  }

  private void SetMovie(string moviePath) => this.movieScreen.moviePath = moviePath;

  public void PlayMovie()
  {
    if ((Object) this.movieScreen == (Object) null)
    {
      Debug.LogError((object) ("m_movie is not configured: " + this.gameObject.name));
    }
    else
    {
      this.movieScreen.GetComponentInParent<Image>().enabled = true;
      this.StartCoroutine(this.PlayMovieImpl());
    }
  }

  private IEnumerator PlayMovieImpl()
  {
    WindowsMovieController windowsMovieController = this;
    if ((Object) windowsMovieController.movieScreen != (Object) null)
    {
      windowsMovieController.movieScreen.Play();
      while (windowsMovieController.movieScreen.player.movieInfo == null)
        yield return (object) new WaitForEndOfFrame();
      while (windowsMovieController.movieScreen.player.status != Player.Status.PlayEnd)
        yield return (object) new WaitForEndOfFrame();
      if (windowsMovieController.movieScreen.isActiveAndEnabled)
        windowsMovieController.StopMovie();
    }
    else
      Debug.LogError((object) ("movieScreen is not configured: " + windowsMovieController.gameObject.name));
  }

  public void ResizeMovie()
  {
    this.rect = this.movieScreen.GetComponent<RectTransform>();
    this.rect.sizeDelta = new Vector2((float) Screen.width, (float) Screen.width / ((float) this.movieScreen.player.movieInfo.width / (float) this.movieScreen.player.movieInfo.height));
  }

  public void PlayMovieInFullScreen()
  {
    this._myScreenController.SwitchToFullScreenMode();
    this.PlayMovie();
    this.StartCoroutine(this.ResizeMovieAfter());
  }

  public void PlayMovieInWindowScreen()
  {
    this._myScreenController.SwitchToWindowMode();
    this.PlayMovie();
    this.StartCoroutine(this.ResizeMovieAfter());
  }

  private IEnumerator ResizeMovieAfter()
  {
    while (this.movieScreen.player.movieInfo == null)
      yield return (object) null;
    this.ResizeMovie();
    this.SetButton();
  }

  public void StopMovie()
  {
    if ((Object) this.movieScreen == (Object) null)
    {
      Debug.LogError((object) ("m_movie is not configured: " + this.gameObject.name));
    }
    else
    {
      this.movieScreen.Stop();
      this._myScreenController.SwitchToWindowMode();
      this.movieScreen.GetComponentInParent<Image>().enabled = false;
      this.ActiveExpandButtons(false);
      this.StartCoroutine(this.DestroyMovie());
    }
  }

  private IEnumerator DestroyMovie()
  {
    while (this.movieScreen.player.status != Player.Status.Stop)
      yield return (object) new WaitForEndOfFrame();
    yield return (object) new WaitForEndOfFrame();
    Object.Destroy((Object) this.windowsMovie);
  }

  private void SetButton()
  {
    this.btnExpand.SetActive(!Screen.fullScreen);
    this.btnContract.SetActive(Screen.fullScreen);
    RectTransform rect = this.rect;
    Vector2 newPos1 = new Vector2((float) ((double) rect.sizeDelta.x / 2.0 - (double) this.btnExpand.GetComponent<RectTransform>().rect.width / 2.0), (float) -((double) rect.sizeDelta.y / 2.0 + (double) this.btnExpand.GetComponent<RectTransform>().rect.height / 2.0));
    Vector2 newPos2 = new Vector2((float) ((double) rect.sizeDelta.x / 2.0 - (double) this.btnContract.GetComponent<RectTransform>().rect.width / 2.0), (float) -((double) rect.sizeDelta.y / 2.0 - (double) this.btnContract.GetComponent<RectTransform>().rect.height / 2.0));
    this.btnExpand.GetComponent<RectTransform>().SetPositionOfPivot(newPos1);
    this.btnContract.GetComponent<RectTransform>().SetPositionOfPivot(newPos2);
  }

  private void ActiveExpandButtons(bool active)
  {
    this.btnExpand.SetActive(active);
    this.btnContract.SetActive(active);
  }

  public void ExpandScreen() => this.PlayMovieInFullScreen();

  public void ContractScreen() => this.PlayMovieInWindowScreen();
}
