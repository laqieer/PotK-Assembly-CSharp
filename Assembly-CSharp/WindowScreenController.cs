// Decompiled with JetBrains decompiler
// Type: WindowScreenController
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using System.Collections;
using System.Text;
using UnityEngine;

public class WindowScreenController : MonoBehaviour
{
  [SerializeField]
  private int m_initialHeight = 640;
  [SerializeField]
  private int m_initialWidth = 360;
  [SerializeField]
  private int m_minHeight = 320;
  [SerializeField]
  private int m_minWidth = 180;
  private int m_lastWidth;
  private int m_lastHeight;
  private float m_aspectRatio;
  private bool m_isOpened;

  private void Start()
  {
    if (this.IsDuped())
      this.enabled = false;
    else
      this.InitWindowSize();
  }

  private void OnApplicationQuit()
  {
    if (this.m_isOpened)
      return;
    Application.CancelQuit();
    ModalWindow.ShowYesNo(Consts.GetInstance().gamequit_title, Consts.GetInstance().gamequit_text, (System.Action) (() => Application.Quit()), (System.Action) (() => this.m_isOpened = false));
    this.m_isOpened = true;
  }

  private void Update()
  {
    if (Screen.fullScreen)
      return;
    if ((UnityEngine.Object) Camera.main != (UnityEngine.Object) null)
    {
      if ((double) Mathf.Abs(1f / Camera.main.aspect - this.m_aspectRatio) <= 0.0500000007450581)
        return;
      this.AdjustWindowSize();
    }
    else
    {
      if ((double) Mathf.Abs(this.GetAspectRatio() - this.m_aspectRatio) <= 0.0500000007450581)
        return;
      this.AdjustWindowSize();
    }
  }

  private void InitWindowSize()
  {
    this.m_lastWidth = this.m_initialWidth;
    this.m_lastHeight = this.m_initialHeight;
    this.m_aspectRatio = (float) this.m_initialHeight / (float) this.m_initialWidth;
    Screen.SetResolution(this.m_initialWidth, this.m_initialHeight, false);
  }

  private void AdjustWindowSize()
  {
    int width = 0;
    int height = 0;
    bool flag = false;
    if (Screen.height != this.m_lastHeight)
    {
      height = Screen.height;
      if (height < this.m_minHeight)
        height = this.m_minHeight;
      width = Mathf.FloorToInt((float) height / this.m_aspectRatio);
      flag = true;
    }
    else if (Screen.width != this.m_lastWidth)
    {
      width = Screen.width;
      if (width < this.m_minWidth)
        width = this.m_minWidth;
      height = Mathf.FloorToInt((float) width * this.m_aspectRatio);
      flag = true;
    }
    if (!flag || height <= 0 || width <= 0)
      return;
    Screen.SetResolution(width, height, false);
    this.m_lastHeight = height;
    this.m_lastWidth = width;
  }

  public void PrintScreenInfo()
  {
    StringBuilder stringBuilder = new StringBuilder();
    stringBuilder.AppendLine("FullScreen: " + Screen.fullScreen.ToString());
    stringBuilder.AppendLine("Height: " + (object) Screen.height);
    stringBuilder.AppendLine("Width: " + (object) Screen.width);
    stringBuilder.AppendLine("Resolution Height: " + (object) Screen.currentResolution.height);
    stringBuilder.AppendLine("Resolution Width: " + (object) Screen.currentResolution.width);
    stringBuilder.AppendLine("Aspect Ratio: " + (object) Camera.main.aspect);
    Debug.LogError((object) stringBuilder.ToString());
  }

  public void SwitchToFullScreenMode()
  {
    if (Screen.fullScreen)
      return;
    this.StartCoroutine(this.SwitchToFullScreenModeImpl());
  }

  private IEnumerator SwitchToFullScreenModeImpl()
  {
    this.m_lastHeight = Screen.height;
    this.m_lastWidth = Screen.width;
    Screen.fullScreen = true;
    yield return (object) new WaitForEndOfFrame();
    Resolution currentResolution = Screen.currentResolution;
    int width = currentResolution.width;
    currentResolution = Screen.currentResolution;
    int height = currentResolution.height;
    Screen.SetResolution(width, height, true);
  }

  public void SwitchToWindowMode()
  {
    if (!Screen.fullScreen)
      return;
    this.StartCoroutine(this.SwitchToWindowModeImpl());
  }

  private IEnumerator SwitchToWindowModeImpl()
  {
    Screen.fullScreen = false;
    yield return (object) new WaitForEndOfFrame();
    Screen.SetResolution(this.m_lastWidth, this.m_lastHeight, false);
  }

  private bool IsDuped() => UnityEngine.Object.FindObjectsOfType(this.GetType()).Length > 1;

  public float GetAspectRatio() => Screen.width > 0 ? (float) (Screen.height / Screen.width) : 0.0f;
}
