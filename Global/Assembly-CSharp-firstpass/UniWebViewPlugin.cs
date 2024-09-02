// Decompiled with JetBrains decompiler
// Type: UniWebViewPlugin
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E910E095-517B-41AE-AAF8-B85E770EBAF1
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp-firstpass.dll

using UnityEngine;

#nullable disable
public class UniWebViewPlugin
{
  private static AndroidJavaClass webView;

  public static void Init(string name, int top, int left, int bottom, int right)
  {
    Debug.Log((object) "Unity Init");
    if (Application.platform != 11)
      return;
    UniWebViewPlugin.webView = new AndroidJavaClass("com.onevcat.uniwebview.AndroidPlugin");
    ((AndroidJavaObject) UniWebViewPlugin.webView).CallStatic("_UniWebViewInit", new object[5]
    {
      (object) name,
      (object) top,
      (object) left,
      (object) bottom,
      (object) right
    });
  }

  public static void ChangeInsets(string name, int top, int left, int bottom, int right)
  {
    if (Application.platform != 11)
      return;
    ((AndroidJavaObject) UniWebViewPlugin.webView).CallStatic("_UniWebViewChangeInsets", new object[5]
    {
      (object) name,
      (object) top,
      (object) left,
      (object) bottom,
      (object) right
    });
  }

  public static void Load(string name, string url)
  {
    if (Application.platform != 11)
      return;
    ((AndroidJavaObject) UniWebViewPlugin.webView).CallStatic("_UniWebViewLoad", new object[2]
    {
      (object) name,
      (object) url
    });
  }

  public static void LoadHTMLString(string name, string htmlString, string baseUrl)
  {
    if (Application.platform != 11)
      return;
    ((AndroidJavaObject) UniWebViewPlugin.webView).CallStatic("_UniWebViewLoadHTMLString", new object[3]
    {
      (object) name,
      (object) htmlString,
      (object) baseUrl
    });
  }

  public static void Reload(string name)
  {
    if (Application.platform != 11)
      return;
    ((AndroidJavaObject) UniWebViewPlugin.webView).CallStatic("_UniWebViewReload", new object[1]
    {
      (object) name
    });
  }

  public static void Stop(string name)
  {
    if (Application.platform != 11)
      return;
    ((AndroidJavaObject) UniWebViewPlugin.webView).CallStatic("_UniWebViewStop", new object[1]
    {
      (object) name
    });
  }

  public static void EvaluatingJavaScript(string name, string javaScript)
  {
    if (Application.platform != 11)
      return;
    Debug.Log((object) ("calling eval js " + javaScript));
    ((AndroidJavaObject) UniWebViewPlugin.webView).CallStatic("_UniWebViewEvaluatingJavaScript", new object[2]
    {
      (object) name,
      (object) javaScript
    });
  }

  public static void AddJavaScript(string name, string javaScript)
  {
    if (Application.platform != 11)
      return;
    Debug.Log((object) ("adding js " + javaScript));
    ((AndroidJavaObject) UniWebViewPlugin.webView).CallStatic("_UniWebViewAddJavaScript", new object[2]
    {
      (object) name,
      (object) javaScript
    });
  }

  public static void Show(string name, bool fade, int direction, float duration)
  {
    if (Application.platform != 11)
      return;
    ((AndroidJavaObject) UniWebViewPlugin.webView).CallStatic("_UniWebViewShow", new object[4]
    {
      (object) name,
      (object) fade,
      (object) direction,
      (object) duration
    });
  }

  public static void Hide(string name, bool fade, int direction, float duration)
  {
    if (Application.platform != 11)
      return;
    ((AndroidJavaObject) UniWebViewPlugin.webView).CallStatic("_UniWebViewHide", new object[4]
    {
      (object) name,
      (object) fade,
      (object) direction,
      (object) duration
    });
  }

  public static void CleanCache(string name)
  {
    if (Application.platform != 11)
      return;
    ((AndroidJavaObject) UniWebViewPlugin.webView).CallStatic("_UniWebViewCleanCache", new object[1]
    {
      (object) name
    });
  }

  public static void CleanCookie(string name, string key)
  {
    if (Application.platform != 11)
      return;
    ((AndroidJavaObject) UniWebViewPlugin.webView).CallStatic("_UniWebViewCleanCookie", new object[2]
    {
      (object) name,
      (object) key
    });
  }

  public static void Destroy(string name)
  {
    if (Application.platform != 11)
      return;
    ((AndroidJavaObject) UniWebViewPlugin.webView).CallStatic("_UniWebViewDestroy", new object[1]
    {
      (object) name
    });
  }

  public static void SetSpinnerShowWhenLoading(string name, bool show)
  {
    if (Application.platform != 11)
      return;
    ((AndroidJavaObject) UniWebViewPlugin.webView).CallStatic("_UniWebViewSetSpinnerShowWhenLoading", new object[2]
    {
      (object) name,
      (object) show
    });
  }

  public static void SetSpinnerText(string name, string text)
  {
    if (Application.platform != 11)
      return;
    ((AndroidJavaObject) UniWebViewPlugin.webView).CallStatic("_UniWebViewSetSpinnerText", new object[2]
    {
      (object) name,
      (object) text
    });
  }

  public static void TransparentBackground(string name, bool transparent)
  {
    if (Application.platform != 11)
      return;
    ((AndroidJavaObject) UniWebViewPlugin.webView).CallStatic("_UniWebViewTransparentBackground", new object[2]
    {
      (object) name,
      (object) transparent
    });
  }

  public static void SetBackgroundColor(string name, float r, float g, float b, float a)
  {
    if (Application.platform != 11)
      return;
    ((AndroidJavaObject) UniWebViewPlugin.webView).CallStatic("_UniWebViewSetBackgroundColor", new object[5]
    {
      (object) name,
      (object) r,
      (object) g,
      (object) b,
      (object) a
    });
  }

  public static bool CanGoBack(string name)
  {
    if (Application.platform != 11)
      return false;
    return ((AndroidJavaObject) UniWebViewPlugin.webView).CallStatic<bool>("_UniWebViewCanGoBack", new object[1]
    {
      (object) name
    });
  }

  public static bool CanGoForward(string name)
  {
    if (Application.platform != 11)
      return false;
    return ((AndroidJavaObject) UniWebViewPlugin.webView).CallStatic<bool>("_UniWebViewCanGoForward", new object[1]
    {
      (object) name
    });
  }

  public static void GoBack(string name)
  {
    if (Application.platform != 11)
      return;
    ((AndroidJavaObject) UniWebViewPlugin.webView).CallStatic("_UniWebViewGoBack", new object[1]
    {
      (object) name
    });
  }

  public static void GoForward(string name)
  {
    if (Application.platform != 11)
      return;
    ((AndroidJavaObject) UniWebViewPlugin.webView).CallStatic("_UniWebViewGoForward", new object[1]
    {
      (object) name
    });
  }

  public static string GetCurrentUrl(string name)
  {
    if (Application.platform != 11)
      return string.Empty;
    return ((AndroidJavaObject) UniWebViewPlugin.webView).CallStatic<string>("_UniWebViewGetCurrentUrl", new object[1]
    {
      (object) name
    });
  }

  public static void SetBackButtonEnable(string name, bool enable)
  {
    if (Application.platform != 11)
      return;
    ((AndroidJavaObject) UniWebViewPlugin.webView).CallStatic("_UniWebViewSetBackButtonEnable", new object[2]
    {
      (object) name,
      (object) enable
    });
  }

  public static void SetBounces(string name, bool enable)
  {
    if (Application.platform != 11)
      return;
    ((AndroidJavaObject) UniWebViewPlugin.webView).CallStatic("_UniWebViewSetBounces", new object[2]
    {
      (object) name,
      (object) enable
    });
  }

  public static void SetZoomEnable(string name, bool enable)
  {
    if (Application.platform != 11)
      return;
    ((AndroidJavaObject) UniWebViewPlugin.webView).CallStatic("_UniWebViewSetZoomEnable", new object[2]
    {
      (object) name,
      (object) enable
    });
  }

  public static void AddUrlScheme(string name, string scheme)
  {
    if (Application.platform != 11)
      return;
    ((AndroidJavaObject) UniWebViewPlugin.webView).CallStatic("_UniWebViewAddUrlScheme", new object[2]
    {
      (object) name,
      (object) scheme
    });
  }

  public static void RemoveUrlScheme(string name, string scheme)
  {
    if (Application.platform != 11)
      return;
    ((AndroidJavaObject) UniWebViewPlugin.webView).CallStatic("_UniWebViewRemoveUrlScheme", new object[2]
    {
      (object) name,
      (object) scheme
    });
  }

  public static void SetUseWideViewPort(string name, bool use)
  {
    if (Application.platform != 11)
      return;
    ((AndroidJavaObject) UniWebViewPlugin.webView).CallStatic("_UniWebViewUseWideViewPort", new object[2]
    {
      (object) name,
      (object) use
    });
  }

  public static void SetUserAgent(string userAgent)
  {
    if (Application.platform != 11)
      return;
    ((AndroidJavaObject) UniWebViewPlugin.webView).CallStatic("_UniWebViewSetUserAgent", new object[1]
    {
      (object) userAgent
    });
  }

  public static string GetUserAgent(string name)
  {
    if (Application.platform != 11)
      return string.Empty;
    return ((AndroidJavaObject) UniWebViewPlugin.webView).CallStatic<string>("_UniWebViewGetUserAgent", new object[1]
    {
      (object) name
    });
  }

  public static float GetAlpha(string name)
  {
    if (Application.platform != 11)
      return 0.0f;
    return ((AndroidJavaObject) UniWebViewPlugin.webView).CallStatic<float>("_UniWebViewGetAlpha", new object[1]
    {
      (object) name
    });
  }

  public static void SetAlpha(string name, float alpha)
  {
    if (Application.platform != 11)
      return;
    ((AndroidJavaObject) UniWebViewPlugin.webView).CallStatic("_UniWebViewSetAlpha", new object[2]
    {
      (object) name,
      (object) alpha
    });
  }

  public static void SetImmersiveModeEnabled(string name, bool enabled)
  {
    if (Application.platform != 11)
      return;
    ((AndroidJavaObject) UniWebViewPlugin.webView).CallStatic("_UniWebViewSetImmersiveModeEnabled", new object[2]
    {
      (object) name,
      (object) enabled
    });
  }

  public static void AddPermissionRequestTrustSite(string name, string url)
  {
    if (Application.platform != 11)
      return;
    ((AndroidJavaObject) UniWebViewPlugin.webView).CallStatic("_UniWebViewAddPermissionRequestTrustSite", new object[2]
    {
      (object) name,
      (object) url
    });
  }

  public static void SetHeaderField(string name, string key, string value)
  {
    if (Application.platform != 11)
      return;
    ((AndroidJavaObject) UniWebViewPlugin.webView).CallStatic("_UniWebViewSetHeaderField", new object[3]
    {
      (object) name,
      (object) key,
      (object) value
    });
  }

  public static void SetVerticalScrollBarShow(string name, bool show)
  {
    if (Application.platform != 11)
      return;
    ((AndroidJavaObject) UniWebViewPlugin.webView).CallStatic("_UniWebViewSetVerticalScrollBarShow", new object[2]
    {
      (object) name,
      (object) show
    });
  }

  public static void SetHorizontalScrollBarShow(string name, bool show)
  {
    if (Application.platform != 11)
      return;
    ((AndroidJavaObject) UniWebViewPlugin.webView).CallStatic("_UniWebViewSetHorizontalScrollBarShow", new object[2]
    {
      (object) name,
      (object) show
    });
  }
}
