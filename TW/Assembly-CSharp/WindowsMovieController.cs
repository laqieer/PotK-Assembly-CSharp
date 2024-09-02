// Decompiled with JetBrains decompiler
// Type: WindowsMovieController
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using CriMana;
using System.Collections;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
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
    if (!Object.op_Inequality((Object) this.movieScreen, (Object) null) || this.movieScreen.player.status != Player.Status.Playing)
      return;
    this.ResizeMovie();
    this.SetButton();
  }

  public void ShowMovie(string moviePath)
  {
    this.SetMovie(moviePath);
    this.StartCoroutine(this.LoadAndPlayMovie());
  }

  [DebuggerHidden]
  private IEnumerator LoadAndPlayMovie()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WindowsMovieController.\u003CLoadAndPlayMovie\u003Ec__IteratorC11()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void SetMovie(string moviePath) => this.movieScreen.moviePath = moviePath;

  public void PlayMovie()
  {
    if (Object.op_Equality((Object) this.movieScreen, (Object) null))
    {
      Debug.LogError((object) ("m_movie is not configured: " + ((Object) ((Component) this).gameObject).name));
    }
    else
    {
      ((Behaviour) ((Component) this.movieScreen).GetComponentInParent<Image>()).enabled = true;
      this.StartCoroutine(this.PlayMovieImpl());
    }
  }

  [DebuggerHidden]
  private IEnumerator PlayMovieImpl()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WindowsMovieController.\u003CPlayMovieImpl\u003Ec__IteratorC12()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void ResizeMovie()
  {
    this.rect = ((Component) this.movieScreen).GetComponent<RectTransform>();
    float num = (float) this.movieScreen.player.movieInfo.width / (float) this.movieScreen.player.movieInfo.height;
    Vector2 vector2;
    // ISSUE: explicit constructor call
    ((Vector2) ref vector2).\u002Ector((float) Screen.width, (float) Screen.width / num);
    this.rect.sizeDelta = vector2;
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

  [DebuggerHidden]
  private IEnumerator ResizeMovieAfter()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WindowsMovieController.\u003CResizeMovieAfter\u003Ec__IteratorC13()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void StopMovie()
  {
    if (Object.op_Equality((Object) this.movieScreen, (Object) null))
    {
      Debug.LogError((object) ("m_movie is not configured: " + ((Object) ((Component) this).gameObject).name));
    }
    else
    {
      this.movieScreen.Stop();
      this._myScreenController.SwitchToWindowMode();
      ((Behaviour) ((Component) this.movieScreen).GetComponentInParent<Image>()).enabled = false;
      this.ActiveExpandButtons(false);
      this.StartCoroutine(this.DestroyMovie());
    }
  }

  [DebuggerHidden]
  private IEnumerator DestroyMovie()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WindowsMovieController.\u003CDestroyMovie\u003Ec__IteratorC14()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void SetButton()
  {
    this.btnExpand.SetActive(!Screen.fullScreen);
    this.btnContract.SetActive(Screen.fullScreen);
    RectTransform rect1 = this.rect;
    Vector2 newPos1;
    ref Vector2 local1 = ref newPos1;
    double num1 = (double) rect1.sizeDelta.x / 2.0;
    Rect rect2 = this.btnExpand.GetComponent<RectTransform>().rect;
    double num2 = (double) ((Rect) ref rect2).width / 2.0;
    double num3 = num1 - num2;
    double num4 = (double) rect1.sizeDelta.y / 2.0;
    Rect rect3 = this.btnExpand.GetComponent<RectTransform>().rect;
    double num5 = (double) ((Rect) ref rect3).height / 2.0;
    double num6 = -(num4 + num5);
    // ISSUE: explicit constructor call
    ((Vector2) ref local1).\u002Ector((float) num3, (float) num6);
    Vector2 newPos2;
    ref Vector2 local2 = ref newPos2;
    double num7 = (double) rect1.sizeDelta.x / 2.0;
    Rect rect4 = this.btnContract.GetComponent<RectTransform>().rect;
    double num8 = (double) ((Rect) ref rect4).width / 2.0;
    double num9 = num7 - num8;
    double num10 = (double) rect1.sizeDelta.y / 2.0;
    Rect rect5 = this.btnContract.GetComponent<RectTransform>().rect;
    double num11 = (double) ((Rect) ref rect5).height / 2.0;
    double num12 = -(num10 - num11);
    // ISSUE: explicit constructor call
    ((Vector2) ref local2).\u002Ector((float) num9, (float) num12);
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
