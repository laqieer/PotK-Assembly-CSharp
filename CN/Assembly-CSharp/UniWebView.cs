// Decompiled with JetBrains decompiler
// Type: UniWebView
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class UniWebView : MonoBehaviour
{
  [SerializeField]
  private UniWebViewEdgeInsets _insets = new UniWebViewEdgeInsets(0, 0, 0, 0);
  public string url;
  public bool loadOnStart;
  public bool autoShowWhenLoadComplete;
  private bool _backButtonEnable = true;
  private bool _bouncesEnable;
  private bool _zoomEnable;
  private string _currentGUID;
  private int _lastScreenHeight;
  private bool _immersiveMode = true;
  private System.Action _showTransitionAction;
  private System.Action _hideTransitionAction;
  public bool toolBarShow;

  public event UniWebView.LoadCompleteDelegate OnLoadComplete;

  public event UniWebView.LoadBeginDelegate OnLoadBegin;

  public event UniWebView.ReceivedMessageDelegate OnReceivedMessage;

  public event UniWebView.EvalJavaScriptFinishedDelegate OnEvalJavaScriptFinished;

  public event UniWebView.WebViewShouldCloseDelegate OnWebViewShouldClose;

  public event UniWebView.ReceivedKeyCodeDelegate OnReceivedKeyCode;

  public event UniWebView.InsetsForScreenOreitationDelegate InsetsForScreenOreitation;

  public UniWebViewEdgeInsets insets
  {
    get => this._insets;
    set
    {
      if (!(this._insets != value))
        return;
      this.ForceUpdateInsetsInternal(value);
    }
  }

  private void ForceUpdateInsetsInternal(UniWebViewEdgeInsets insets)
  {
    this._insets = insets;
    UniWebViewPlugin.ChangeInsets(((Object) ((Component) this).gameObject).name, this.insets.top, this.insets.left, this.insets.bottom, this.insets.right);
  }

  public string currentUrl
  {
    get => UniWebViewPlugin.GetCurrentUrl(((Object) ((Component) this).gameObject).name);
  }

  public bool backButtonEnable
  {
    get => this._backButtonEnable;
    set
    {
      if (this._backButtonEnable == value)
        return;
      this._backButtonEnable = value;
      UniWebViewPlugin.SetBackButtonEnable(((Object) ((Component) this).gameObject).name, this._backButtonEnable);
    }
  }

  public bool bouncesEnable
  {
    get => this._bouncesEnable;
    set
    {
      if (this._bouncesEnable == value)
        return;
      this._bouncesEnable = value;
      UniWebViewPlugin.SetBounces(((Object) ((Component) this).gameObject).name, this._bouncesEnable);
    }
  }

  public bool zoomEnable
  {
    get => this._zoomEnable;
    set
    {
      if (this._zoomEnable == value)
        return;
      this._zoomEnable = value;
      UniWebViewPlugin.SetZoomEnable(((Object) ((Component) this).gameObject).name, this._zoomEnable);
    }
  }

  public string userAgent
  {
    get => UniWebViewPlugin.GetUserAgent(((Object) ((Component) this).gameObject).name);
  }

  public float alpha
  {
    get => UniWebViewPlugin.GetAlpha(((Object) ((Component) this).gameObject).name);
    set
    {
      UniWebViewPlugin.SetAlpha(((Object) ((Component) this).gameObject).name, Mathf.Clamp01(value));
    }
  }

  public bool immersiveMode
  {
    get => this._immersiveMode;
    set
    {
      this._immersiveMode = value;
      UniWebViewPlugin.SetImmersiveModeEnabled(((Object) ((Component) this).gameObject).name, this._immersiveMode);
    }
  }

  public static void SetUserAgent(string value) => UniWebViewPlugin.SetUserAgent(value);

  public static void ResetUserAgent() => UniWebViewPlugin.SetUserAgent((string) null);

  public void Load()
  {
    UniWebViewPlugin.Load(((Object) ((Component) this).gameObject).name, !string.IsNullOrEmpty(this.url) ? this.url.Trim() : "about:blank");
  }

  public void Load(string aUrl)
  {
    this.url = aUrl;
    this.Load();
  }

  public void LoadHTMLString(string htmlString, string baseUrl)
  {
    UniWebViewPlugin.LoadHTMLString(((Object) ((Component) this).gameObject).name, htmlString, baseUrl);
  }

  public void Reload() => UniWebViewPlugin.Reload(((Object) ((Component) this).gameObject).name);

  public void Stop() => UniWebViewPlugin.Stop(((Object) ((Component) this).gameObject).name);

  public void Show(
    bool fade = false,
    UniWebViewTransitionEdge direction = UniWebViewTransitionEdge.None,
    float duration = 0.4f,
    System.Action finishAction = null)
  {
    this._lastScreenHeight = UniWebViewHelper.screenHeight;
    this.ResizeInternal();
    UniWebViewPlugin.Show(((Object) ((Component) this).gameObject).name, fade, (int) direction, duration);
    this._showTransitionAction = finishAction;
    if (!this.toolBarShow)
      return;
    this.ShowToolBar(true);
  }

  public void Hide(
    bool fade = false,
    UniWebViewTransitionEdge direction = UniWebViewTransitionEdge.None,
    float duration = 0.4f,
    System.Action finishAction = null)
  {
    UniWebViewPlugin.Hide(((Object) ((Component) this).gameObject).name, fade, (int) direction, duration);
    this._hideTransitionAction = finishAction;
  }

  public void EvaluatingJavaScript(string javaScript)
  {
    UniWebViewPlugin.EvaluatingJavaScript(((Object) ((Component) this).gameObject).name, javaScript);
  }

  public void AddJavaScript(string javaScript)
  {
    UniWebViewPlugin.AddJavaScript(((Object) ((Component) this).gameObject).name, javaScript);
  }

  public void CleanCache()
  {
    UniWebViewPlugin.CleanCache(((Object) ((Component) this).gameObject).name);
  }

  public void CleanCookie(string key = null)
  {
    UniWebViewPlugin.CleanCookie(((Object) ((Component) this).gameObject).name, key);
  }

  [Obsolete("SetTransparentBackground is deprecated, please use SetBackgroundColor instead.")]
  public void SetTransparentBackground(bool transparent = true)
  {
    UniWebViewPlugin.TransparentBackground(((Object) ((Component) this).gameObject).name, transparent);
  }

  public void SetBackgroundColor(Color color)
  {
    UniWebViewPlugin.SetBackgroundColor(((Object) ((Component) this).gameObject).name, color.r, color.g, color.b, color.a);
  }

  public void ShowToolBar(bool animate)
  {
  }

  public void HideToolBar(bool animate)
  {
  }

  public void SetShowSpinnerWhenLoading(bool show)
  {
    UniWebViewPlugin.SetSpinnerShowWhenLoading(((Object) ((Component) this).gameObject).name, show);
  }

  public void SetSpinnerLabelText(string text)
  {
    UniWebViewPlugin.SetSpinnerText(((Object) ((Component) this).gameObject).name, text);
  }

  public void SetUseWideViewPort(bool use)
  {
    UniWebViewPlugin.SetUseWideViewPort(((Object) ((Component) this).gameObject).name, use);
  }

  public bool CanGoBack()
  {
    return UniWebViewPlugin.CanGoBack(((Object) ((Component) this).gameObject).name);
  }

  public bool CanGoForward()
  {
    return UniWebViewPlugin.CanGoForward(((Object) ((Component) this).gameObject).name);
  }

  public void GoBack() => UniWebViewPlugin.GoBack(((Object) ((Component) this).gameObject).name);

  public void GoForward()
  {
    UniWebViewPlugin.GoForward(((Object) ((Component) this).gameObject).name);
  }

  public void AddPermissionRequestTrustSite(string url)
  {
    UniWebViewPlugin.AddPermissionRequestTrustSite(((Object) ((Component) this).gameObject).name, url);
  }

  public void AddUrlScheme(string scheme)
  {
    UniWebViewPlugin.AddUrlScheme(((Object) ((Component) this).gameObject).name, scheme);
  }

  public void RemoveUrlScheme(string scheme)
  {
    UniWebViewPlugin.RemoveUrlScheme(((Object) ((Component) this).gameObject).name, scheme);
  }

  public void SetHeaderField(string key, string value)
  {
    UniWebViewPlugin.SetHeaderField(((Object) ((Component) this).gameObject).name, key, value);
  }

  public void SetVerticalScrollBarShow(bool show)
  {
    UniWebViewPlugin.SetVerticalScrollBarShow(((Object) ((Component) this).gameObject).name, show);
  }

  public void SetHorizontalScrollBarShow(bool show)
  {
    UniWebViewPlugin.SetHorizontalScrollBarShow(((Object) ((Component) this).gameObject).name, show);
  }

  private bool OrientationChanged()
  {
    int screenHeight = UniWebViewHelper.screenHeight;
    if (this._lastScreenHeight == screenHeight)
      return false;
    this._lastScreenHeight = screenHeight;
    return true;
  }

  private void ResizeInternal()
  {
    int screenHeight = UniWebViewHelper.screenHeight;
    int screenWidth = UniWebViewHelper.screenWidth;
    UniWebViewEdgeInsets insets = this.insets;
    if (this.InsetsForScreenOreitation != null)
      insets = this.InsetsForScreenOreitation(this, screenHeight < screenWidth ? UniWebViewOrientation.LandScape : UniWebViewOrientation.Portrait);
    this.ForceUpdateInsetsInternal(insets);
  }

  private void LoadComplete(string message)
  {
    bool flag1 = string.Equals(message, string.Empty);
    bool flag2 = this.OnLoadComplete != null;
    if (flag1)
    {
      if (flag2)
        this.OnLoadComplete(this, true, (string) null);
      if (!this.autoShowWhenLoadComplete)
        return;
      this.Show();
    }
    else
    {
      Debug.LogWarning((object) ("Web page load failed: " + ((Object) ((Component) this).gameObject).name + "; url: " + this.url + "; error:" + message));
      if (!flag2)
        return;
      this.OnLoadComplete(this, false, message);
    }
  }

  private void LoadBegin(string url)
  {
    if (this.OnLoadBegin == null)
      return;
    this.OnLoadBegin(this, url);
  }

  private void ReceivedMessage(string rawMessage)
  {
    UniWebViewMessage message = new UniWebViewMessage(rawMessage);
    if (this.OnReceivedMessage == null)
      return;
    this.OnReceivedMessage(this, message);
  }

  private void WebViewDone(string message)
  {
    bool flag = true;
    if (this.OnWebViewShouldClose != null)
      flag = this.OnWebViewShouldClose(this);
    if (!flag)
      return;
    this.Hide();
    Object.Destroy((Object) this);
  }

  private void WebViewKeyDown(string message)
  {
    int int32 = Convert.ToInt32(message);
    if (this.OnReceivedKeyCode == null)
      return;
    this.OnReceivedKeyCode(this, int32);
  }

  private void EvalJavaScriptFinished(string result)
  {
    if (this.OnEvalJavaScriptFinished == null)
      return;
    this.OnEvalJavaScriptFinished(this, result);
  }

  private void AnimationFinished(string identifier)
  {
  }

  private void ShowTransitionFinished(string message)
  {
    if (this._showTransitionAction == null)
      return;
    this._showTransitionAction();
    this._showTransitionAction = (System.Action) null;
  }

  private void HideTransitionFinished(string message)
  {
    if (this._hideTransitionAction == null)
      return;
    this._hideTransitionAction();
    this._hideTransitionAction = (System.Action) null;
  }

  [DebuggerHidden]
  private IEnumerator LoadFromJarPackage(string jarFilePath)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new UniWebView.\u003CLoadFromJarPackage\u003Ec__IteratorB1B()
    {
      jarFilePath = jarFilePath,
      \u003C\u0024\u003EjarFilePath = jarFilePath,
      \u003C\u003Ef__this = this
    };
  }

  private void Awake()
  {
    this._currentGUID = Guid.NewGuid().ToString();
    ((Object) ((Component) this).gameObject).name = ((Object) ((Component) this).gameObject).name + this._currentGUID;
    UniWebViewPlugin.Init(((Object) ((Component) this).gameObject).name, this.insets.top, this.insets.left, this.insets.bottom, this.insets.right);
    this._lastScreenHeight = UniWebViewHelper.screenHeight;
  }

  private void Start()
  {
    if (!this.loadOnStart)
      return;
    this.Load();
  }

  private void OnDestroy()
  {
    this.RemoveAllListeners();
    UniWebViewPlugin.Destroy(((Object) ((Component) this).gameObject).name);
    ((Object) ((Component) this).gameObject).name = ((Object) ((Component) this).gameObject).name.Replace(this._currentGUID, string.Empty);
  }

  private void RemoveAllListeners()
  {
    this.OnLoadBegin = (UniWebView.LoadBeginDelegate) null;
    this.OnLoadComplete = (UniWebView.LoadCompleteDelegate) null;
    this.OnReceivedMessage = (UniWebView.ReceivedMessageDelegate) null;
    this.OnReceivedKeyCode = (UniWebView.ReceivedKeyCodeDelegate) null;
    this.OnEvalJavaScriptFinished = (UniWebView.EvalJavaScriptFinishedDelegate) null;
    this.OnWebViewShouldClose = (UniWebView.WebViewShouldCloseDelegate) null;
    this.InsetsForScreenOreitation = (UniWebView.InsetsForScreenOreitationDelegate) null;
  }

  private void Update()
  {
    if (!this.OrientationChanged())
      return;
    this.ResizeInternal();
  }

  public delegate void LoadCompleteDelegate(UniWebView webView, bool success, string errorMessage);

  public delegate void LoadBeginDelegate(UniWebView webView, string loadingUrl);

  public delegate void ReceivedMessageDelegate(UniWebView webView, UniWebViewMessage message);

  public delegate void EvalJavaScriptFinishedDelegate(UniWebView webView, string result);

  public delegate bool WebViewShouldCloseDelegate(UniWebView webView);

  public delegate void ReceivedKeyCodeDelegate(UniWebView webView, int keyCode);

  public delegate UniWebViewEdgeInsets InsetsForScreenOreitationDelegate(
    UniWebView webView,
    UniWebViewOrientation orientation);
}
