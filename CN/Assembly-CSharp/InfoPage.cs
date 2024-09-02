// Decompiled with JetBrains decompiler
// Type: InfoPage
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using DenaLib;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class InfoPage : MonoBehaviour
{
  private const float mc_FadeOutTime = 3f;
  public Text m_Info;
  public Text m_Log;
  private bool m_Show;
  private float m_PassTime;

  private void Start()
  {
    CallbackCenter callbackCenter = DenaLib.Singleton<GameLogic>.Instance.GetCallbackCenter();
    callbackCenter.SetCallback(5, new ObjectCallback(this.ShowInfoMsg));
    callbackCenter.SetCallback(6, new ObjectCallback(this.HideInfoMsg));
    Debuger.LogCb = new Debuger.LogCallback(this.ScreenLog);
  }

  private void Update()
  {
    if (!this.m_Show || !Object.op_Inequality((Object) this.m_Info, (Object) null))
      return;
    this.m_PassTime += Time.deltaTime;
    if ((double) this.m_PassTime > 3.0)
    {
      this.HideInfoMsg();
    }
    else
    {
      Color color = ((Graphic) this.m_Info).color;
      color.a = this.m_PassTime / 3f;
      ((Graphic) this.m_Info).color = color;
    }
  }

  public void ShowInfoMsg(params object[] param)
  {
    if (param == null || param.Length <= 0 || !(param[0] is string))
      return;
    if (Object.op_Inequality((Object) this.m_Info, (Object) null))
      this.m_Info.text = (string) param[0];
    ((Component) this.m_Info).gameObject.SetActive(true);
    Color color = ((Graphic) this.m_Info).color;
    color.a = 1f;
    ((Graphic) this.m_Info).color = color;
    this.m_PassTime = 0.0f;
    this.m_Show = true;
  }

  public void HideInfoMsg(params object[] param)
  {
    ((Component) this.m_Info).gameObject.SetActive(false);
    this.m_Show = false;
  }

  private void ScreenLog(string message, Color color)
  {
    this.m_Log.text += message;
    ((Graphic) this.m_Log).color = color;
  }
}
