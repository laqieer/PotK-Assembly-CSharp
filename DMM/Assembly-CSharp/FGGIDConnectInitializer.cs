// Decompiled with JetBrains decompiler
// Type: FGGIDConnectInitializer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using System.Collections;
using UnityEngine;

public class FGGIDConnectInitializer : MonoBehaviour
{
  private UIButton m_fggIdLoadingButton;
  private UIButton m_fggIdConnectedButton;
  private UIButton m_fggIdDisconnectedButton;
  [SerializeField]
  private UniWebViewController m_webViewCtrl;

  private void Start() => this.Initialize();

  public void Initialize()
  {
    GameObject gameObject1 = GameObject.Find("ibtn_fgg_mission_loading");
    GameObject gameObject2 = GameObject.Find("ibtn_fgg_mission_connected");
    GameObject gameObject3 = GameObject.Find("ibtn_fgg_mission_disconnected");
    if ((UnityEngine.Object) gameObject1 != (UnityEngine.Object) null)
      this.m_fggIdLoadingButton = gameObject1.GetComponent<UIButton>();
    if ((UnityEngine.Object) gameObject2 != (UnityEngine.Object) null)
      this.m_fggIdConnectedButton = gameObject2.GetComponent<UIButton>();
    if ((UnityEngine.Object) gameObject3 != (UnityEngine.Object) null)
      this.m_fggIdDisconnectedButton = gameObject3.GetComponent<UIButton>();
    this.HideFggIdButtons();
  }

  private void SwitchToFggIdLoadingButton()
  {
    Debug.Log((object) "SwitchToFggIdLoadingButton called");
    if ((UnityEngine.Object) this.m_fggIdConnectedButton != (UnityEngine.Object) null)
      this.m_fggIdConnectedButton.gameObject.SetActive(false);
    if ((UnityEngine.Object) this.m_fggIdDisconnectedButton != (UnityEngine.Object) null)
      this.m_fggIdDisconnectedButton.gameObject.SetActive(false);
    if (!((UnityEngine.Object) this.m_fggIdLoadingButton != (UnityEngine.Object) null))
      return;
    this.m_fggIdLoadingButton.gameObject.SetActive(true);
  }

  private void HideFggIdButtons()
  {
    Debug.Log((object) "HideFggIdButtons called");
    if ((UnityEngine.Object) this.m_fggIdConnectedButton != (UnityEngine.Object) null)
      this.m_fggIdConnectedButton.gameObject.SetActive(false);
    if ((UnityEngine.Object) this.m_fggIdDisconnectedButton != (UnityEngine.Object) null)
      this.m_fggIdDisconnectedButton.gameObject.SetActive(false);
    if (!((UnityEngine.Object) this.m_fggIdLoadingButton != (UnityEngine.Object) null))
      return;
    this.m_fggIdLoadingButton.gameObject.SetActive(false);
  }

  private void SwitchFggIdButtons(bool connected)
  {
    Debug.Log((object) ("SwitchFggIdButtons called with connected: " + connected.ToString()));
    if ((UnityEngine.Object) this.m_fggIdConnectedButton != (UnityEngine.Object) null)
      this.m_fggIdConnectedButton.gameObject.SetActive(connected);
    if ((UnityEngine.Object) this.m_fggIdDisconnectedButton != (UnityEngine.Object) null)
      this.m_fggIdDisconnectedButton.gameObject.SetActive(!connected);
    if (!((UnityEngine.Object) this.m_fggIdLoadingButton != (UnityEngine.Object) null))
      return;
    this.m_fggIdLoadingButton.gameObject.SetActive(false);
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

  private IEnumerator InitializeFgGIDButtons()
  {
    FGGIDConnectInitializer connectInitializer = this;
    connectInitializer.SwitchToFggIdLoadingButton();
    // ISSUE: reference to a compiler-generated method
    Future<WebAPI.Response.AchievementApiAuth> webApi = WebAPI.AchievementApiAuth(new System.Action<WebAPI.Response.UserError>(connectInitializer.\u003CInitializeFgGIDButtons\u003Eb__12_0));
    IEnumerator e = webApi.Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    string authUrl = webApi.Result.auth_url;
    connectInitializer.m_webViewCtrl.GumiURIPath = authUrl;
    int authStatus = webApi.Result.auth_status;
    URLScheme.fggBtnStatus = authStatus;
    connectInitializer.SwitchFggIdButtonsByAuthStatus(authStatus);
  }
}
