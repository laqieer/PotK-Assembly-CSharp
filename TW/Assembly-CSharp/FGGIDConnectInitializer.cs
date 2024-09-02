// Decompiled with JetBrains decompiler
// Type: FGGIDConnectInitializer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class FGGIDConnectInitializer : MonoBehaviour
{
  [SerializeField]
  private UIButton m_fggIdLoadingButton;
  [SerializeField]
  private UIButton m_fggIdConnectedButton;
  [SerializeField]
  private UIButton m_fggIdDisconnectedButton;
  [SerializeField]
  private UniWebViewController m_webViewCtrl;

  private void Start() => this.Initialize();

  public void Initialize() => this.StartCoroutine(this.InitializeFgGIDButtons());

  private void SwitchToFggIdLoadingButton()
  {
    Debug.Log((object) "SwitchToFggIdLoadingButton called");
    if (Object.op_Inequality((Object) this.m_fggIdConnectedButton, (Object) null))
      ((Component) this.m_fggIdConnectedButton).gameObject.SetActive(false);
    if (Object.op_Inequality((Object) this.m_fggIdDisconnectedButton, (Object) null))
      ((Component) this.m_fggIdDisconnectedButton).gameObject.SetActive(false);
    if (!Object.op_Inequality((Object) this.m_fggIdLoadingButton, (Object) null))
      return;
    ((Component) this.m_fggIdLoadingButton).gameObject.SetActive(true);
  }

  private void HideFggIdButtons()
  {
    Debug.Log((object) "HideFggIdButtons called");
    if (Object.op_Inequality((Object) this.m_fggIdConnectedButton, (Object) null))
      ((Component) this.m_fggIdConnectedButton).gameObject.SetActive(false);
    if (Object.op_Inequality((Object) this.m_fggIdDisconnectedButton, (Object) null))
      ((Component) this.m_fggIdDisconnectedButton).gameObject.SetActive(false);
    if (!Object.op_Inequality((Object) this.m_fggIdLoadingButton, (Object) null))
      return;
    ((Component) this.m_fggIdLoadingButton).gameObject.SetActive(false);
  }

  private void SwitchFggIdButtons(bool connected)
  {
    Debug.Log((object) ("SwitchFggIdButtons called with connected: " + (object) connected));
    if (Object.op_Inequality((Object) this.m_fggIdConnectedButton, (Object) null))
      ((Component) this.m_fggIdConnectedButton).gameObject.SetActive(connected);
    if (Object.op_Inequality((Object) this.m_fggIdDisconnectedButton, (Object) null))
      ((Component) this.m_fggIdDisconnectedButton).gameObject.SetActive(!connected);
    if (!Object.op_Inequality((Object) this.m_fggIdLoadingButton, (Object) null))
      return;
    ((Component) this.m_fggIdLoadingButton).gameObject.SetActive(false);
  }

  private void SwitchToFggIdConnectedButton() => this.SwitchFggIdButtons(true);

  private void SwitchToFggIdDisconnectedButton() => this.SwitchFggIdButtons(false);

  private void SwitchFggIdButtonsByAuthStatus(int authStatus)
  {
    Debug.Log((object) ("SwitchFggIdButtonsByAuthStatus called with authStatus: " + (object) authStatus));
    switch (authStatus)
    {
      case 1:
        this.HideFggIdButtons();
        break;
      case 2:
        this.SwitchToFggIdDisconnectedButton();
        break;
      case 3:
        this.SwitchToFggIdConnectedButton();
        break;
      default:
        Debug.LogError((object) ("Invalid auth_status returnded. auth_status: " + (object) authStatus));
        this.HideFggIdButtons();
        break;
    }
  }

  [DebuggerHidden]
  private IEnumerator InitializeFgGIDButtons()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    FGGIDConnectInitializer.\u003CInitializeFgGIDButtons\u003Ec__Iterator1B3 buttonsCIterator1B3 = new FGGIDConnectInitializer.\u003CInitializeFgGIDButtons\u003Ec__Iterator1B3();
    return (IEnumerator) buttonsCIterator1B3;
  }
}
