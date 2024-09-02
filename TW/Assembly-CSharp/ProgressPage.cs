// Decompiled with JetBrains decompiler
// Type: ProgressPage
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using DenaLib;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class ProgressPage : MonoBehaviour
{
  private Slider m_Progress;
  public Text m_Percent;

  private void Start()
  {
    GameObject gameObject = GameObject.Find("Canvas/ProgressPanel/Slider");
    if (Object.op_Inequality((Object) gameObject, (Object) null))
      this.m_Progress = gameObject.GetComponent<Slider>();
    CallbackCenter callbackCenter = DenaLib.Singleton<GameLogic>.Instance.GetCallbackCenter();
    callbackCenter.SetCallback(2, new ObjectCallback(this.OnBeginProgress));
    callbackCenter.SetCallback(3, new ObjectCallback(this.OnEndProgress));
    callbackCenter.SetCallback(4, new ObjectCallback(this.SetProgress));
  }

  public void OnBeginProgress(params object[] param)
  {
    ((Component) this).gameObject.SetActive(true);
  }

  public void OnEndProgress(params object[] param)
  {
    ((Component) this).gameObject.SetActive(false);
  }

  public void SetProgress(params object[] param)
  {
    float num = 0.0f;
    if (param != null && param.Length > 0 && param[0] is float)
      num = (float) param[0];
    if (Object.op_Inequality((Object) this.m_Progress, (Object) null))
      this.m_Progress.value = num;
    if (!Object.op_Inequality((Object) this.m_Percent, (Object) null))
      return;
    this.m_Percent.text = string.Format("{0}%", (object) (int) ((double) num * 100.0));
  }
}
