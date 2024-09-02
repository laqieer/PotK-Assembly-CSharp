// Decompiled with JetBrains decompiler
// Type: UniWebViewController
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
[RequireComponent(typeof (UniWebView))]
public class UniWebViewController : MonoBehaviour
{
  [SerializeField]
  private GameObject[] m_followerObjects;
  [SerializeField]
  private TopScene m_topSceneObject;
  private UniWebView m_uniWebView;
  private string m_url;
  private bool m_visible;
  private bool m_isOperatingCallbackMessage;

  public string GumiURIPath
  {
    get => this.m_url;
    set => this.m_url = ServerSelector.ApiUrl + "/" + value;
  }

  public string URL
  {
    get => this.m_url;
    set => this.m_url = value;
  }

  public void Navigate()
  {
    this.m_uniWebView = ((Component) this).GetComponent<UniWebView>();
    if (Object.op_Equality((Object) this.m_uniWebView, (Object) null))
    {
      Debug.LogError((object) "Can't initialize UniWebView!");
    }
    else
    {
      this.m_uniWebView.OnReceivedMessage += new UniWebView.ReceivedMessageDelegate(this.OnReceivedMessage);
      this.m_uniWebView.OnWebViewShouldClose += new UniWebView.WebViewShouldCloseDelegate(this.OnWebViewShouldClose);
      this.m_uniWebView.insets = new UniWebViewEdgeInsets(0, 0, (int) ((double) UniWebViewHelper.screenHeight * 0.10000000149011612), 0);
      string str = "gauth " + WebQueue.AuthToken;
      if (Debug.isDebugBuild)
        Debug.Log((object) ("Open webview and Navigate to: " + this.m_url + " with Authorization: " + str));
      this.m_uniWebView.SetHeaderField("Authorization", str);
      this.m_uniWebView.Load(this.m_url);
      this.m_uniWebView.Show();
      this.m_visible = true;
      foreach (GameObject followerObject in this.m_followerObjects)
        followerObject.SetActive(true);
    }
  }

  private void OnReceivedMessage(UniWebView webView, UniWebViewMessage message)
  {
    Debug.Log((object) ("Received message from Webview: " + message.rawMessage));
    string uriString = message.rawMessage.Substring("uniwebview://".Length);
    Debug.Log((object) ("messageBody: " + uriString));
    if (uriString.Contains("http//"))
    {
      Debug.Log((object) "replace http// -> http://");
      uriString = uriString.Replace("http//", "http://");
    }
    if (uriString.Contains("https//"))
    {
      Debug.Log((object) "replace https// -> https://");
      uriString = uriString.Replace("https//", "https://");
    }
    Debug.Log((object) ("messageBody: " + uriString));
    Uri result;
    if (Uri.TryCreate(uriString, UriKind.RelativeOrAbsolute, out result))
    {
      if (this.m_isOperatingCallbackMessage)
        return;
      this.m_isOperatingCallbackMessage = true;
      Debug.Log((object) ("Launch browser: " + result.AbsoluteUri));
      Application.OpenURL(uriString);
    }
    else
      Debug.Log((object) ("This is not valid as URL: " + uriString));
  }

  public void Hide()
  {
    if (Object.op_Inequality((Object) this.m_uniWebView, (Object) null))
      this.m_uniWebView.Hide();
    foreach (GameObject followerObject in this.m_followerObjects)
      followerObject.SetActive(false);
    this.m_visible = false;
  }

  private bool OnWebViewShouldClose(UniWebView webView)
  {
    if (Object.op_Inequality((Object) this.m_topSceneObject, (Object) null))
      this.m_topSceneObject.CloseWebView();
    return false;
  }

  private void OnApplicationPause(bool pauseStatus)
  {
    if (!Object.op_Inequality((Object) this.m_uniWebView, (Object) null) || !this.m_visible)
      return;
    if (pauseStatus)
    {
      Debug.Log((object) "WebView detected app going background. Hide WebView.");
      this.m_uniWebView.Hide();
    }
    else
    {
      Debug.Log((object) "WebView detected app coming foreground. Show WebView.");
      this.m_uniWebView.Show();
      this.m_isOperatingCallbackMessage = false;
    }
  }
}
