// Decompiled with JetBrains decompiler
// Type: WindowScreenController
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using System.Text;
using UnityEngine;

#nullable disable
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
  }

  private void OnApplicationQuit()
  {
  }

  private void Update()
  {
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
    int num1 = 0;
    int num2 = 0;
    bool flag = false;
    if (Screen.height != this.m_lastHeight)
    {
      num2 = Screen.height;
      if (num2 < this.m_minHeight)
        num2 = this.m_minHeight;
      num1 = Mathf.FloorToInt((float) num2 / this.m_aspectRatio);
      flag = true;
    }
    else if (Screen.width != this.m_lastWidth)
    {
      num1 = Screen.width;
      if (num1 < this.m_minWidth)
        num1 = this.m_minWidth;
      num2 = Mathf.FloorToInt((float) num1 * this.m_aspectRatio);
      flag = true;
    }
    if (!flag || num2 <= 0 || num1 <= 0)
      return;
    Screen.SetResolution(num1, num2, false);
    this.m_lastHeight = num2;
    this.m_lastWidth = num1;
  }

  public void PrintScreenInfo()
  {
    StringBuilder stringBuilder1 = new StringBuilder();
    stringBuilder1.AppendLine("FullScreen: " + (object) Screen.fullScreen);
    stringBuilder1.AppendLine("Height: " + (object) Screen.height);
    stringBuilder1.AppendLine("Width: " + (object) Screen.width);
    StringBuilder stringBuilder2 = stringBuilder1;
    Resolution currentResolution1 = Screen.currentResolution;
    string str1 = "Resolution Height: " + (object) ((Resolution) ref currentResolution1).height;
    stringBuilder2.AppendLine(str1);
    StringBuilder stringBuilder3 = stringBuilder1;
    Resolution currentResolution2 = Screen.currentResolution;
    string str2 = "Resolution Width: " + (object) ((Resolution) ref currentResolution2).width;
    stringBuilder3.AppendLine(str2);
    stringBuilder1.AppendLine("Aspect Ratio: " + (object) Camera.main.aspect);
    Debug.LogError((object) stringBuilder1.ToString());
  }

  public void SwitchToFullScreenMode()
  {
    if (Screen.fullScreen)
      return;
    this.StartCoroutine(this.SwitchToFullScreenModeImpl());
  }

  [DebuggerHidden]
  private IEnumerator SwitchToFullScreenModeImpl()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WindowScreenController.\u003CSwitchToFullScreenModeImpl\u003Ec__IteratorC0F()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void SwitchToWindowMode()
  {
    if (!Screen.fullScreen)
      return;
    this.StartCoroutine(this.SwitchToWindowModeImpl());
  }

  [DebuggerHidden]
  private IEnumerator SwitchToWindowModeImpl()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new WindowScreenController.\u003CSwitchToWindowModeImpl\u003Ec__IteratorC10()
    {
      \u003C\u003Ef__this = this
    };
  }

  private bool IsDuped() => Object.FindObjectsOfType(((object) this).GetType()).Length > 1;

  public float GetAspectRatio() => Screen.width > 0 ? (float) (Screen.height / Screen.width) : 0.0f;
}
