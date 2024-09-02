// Decompiled with JetBrains decompiler
// Type: LoginPage
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using DenaLib;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class LoginPage : UIWindow
{
  public InputField m_UserName;
  public InputField m_Password;
  public Button m_Login;

  private void Start()
  {
    CallbackCenter callbackCenter = DenaLib.Singleton<GameLogic>.Instance.GetCallbackCenter();
    callbackCenter.SetCallback(0, new ObjectCallback(this.OnLoginSuccess));
    callbackCenter.SetCallback(1, new ObjectCallback(this.OnLoginFail));
  }

  public void Login()
  {
    if (Object.op_Inequality((Object) this.m_UserName, (Object) null) && Object.op_Inequality((Object) this.m_Password, (Object) null))
    {
      string username = this.m_UserName.text.Trim();
      string password = this.m_Password.text.Trim();
      if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        return;
      this.EnableInput(false);
      DenaLib.Singleton<GameLogic>.Instance.Login(username, password);
    }
    else
      DenaLib.Singleton<GameLogic>.Instance.GetCallbackCenter().Call(5, (object) "Invalid username or password...");
  }

  private void EnableInput(bool enable)
  {
    if (Object.op_Inequality((Object) this.m_UserName, (Object) null))
      ((Selectable) this.m_UserName).interactable = enable;
    if (Object.op_Inequality((Object) this.m_Password, (Object) null))
      ((Selectable) this.m_Password).interactable = enable;
    if (!Object.op_Inequality((Object) this.m_Login, (Object) null))
      return;
    ((Behaviour) this.m_Login).enabled = enable;
  }

  public void OnLoginSuccess(params object[] param)
  {
    this.EnableInput(true);
    ((Component) this).gameObject.SetActive(false);
  }

  public void OnLoginFail(params object[] param)
  {
    this.EnableInput(false);
    ((Component) this).gameObject.SetActive(true);
  }
}
