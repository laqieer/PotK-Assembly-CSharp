// Decompiled with JetBrains decompiler
// Type: Facebook.Unity.AsyncRequestString
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
namespace Facebook.Unity
{
  internal class AsyncRequestString : MonoBehaviour
  {
    private string url;
    private HttpMethod method;
    private IDictionary<string, string> formData;
    private WWWForm query;
    private FacebookDelegate<IGraphResult> callback;

    internal static void Post(
      string url,
      Dictionary<string, string> formData = null,
      FacebookDelegate<IGraphResult> callback = null)
    {
      AsyncRequestString.Request(url, HttpMethod.POST, (IDictionary<string, string>) formData, callback);
    }

    internal static void Get(
      string url,
      Dictionary<string, string> formData = null,
      FacebookDelegate<IGraphResult> callback = null)
    {
      AsyncRequestString.Request(url, HttpMethod.GET, (IDictionary<string, string>) formData, callback);
    }

    internal static void Request(
      string url,
      HttpMethod method,
      WWWForm query = null,
      FacebookDelegate<IGraphResult> callback = null)
    {
      ComponentFactory.AddComponent<AsyncRequestString>().SetUrl(url).SetMethod(method).SetQuery(query).SetCallback(callback);
    }

    internal static void Request(
      string url,
      HttpMethod method,
      IDictionary<string, string> formData = null,
      FacebookDelegate<IGraphResult> callback = null)
    {
      ComponentFactory.AddComponent<AsyncRequestString>().SetUrl(url).SetMethod(method).SetFormData(formData).SetCallback(callback);
    }

    [DebuggerHidden]
    internal IEnumerator Start()
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new AsyncRequestString.\u003CStart\u003Ec__Iterator5()
      {
        \u003C\u003Ef__this = this
      };
    }

    internal AsyncRequestString SetUrl(string url)
    {
      this.url = url;
      return this;
    }

    internal AsyncRequestString SetMethod(HttpMethod method)
    {
      this.method = method;
      return this;
    }

    internal AsyncRequestString SetFormData(IDictionary<string, string> formData)
    {
      this.formData = formData;
      return this;
    }

    internal AsyncRequestString SetQuery(WWWForm query)
    {
      this.query = query;
      return this;
    }

    internal AsyncRequestString SetCallback(FacebookDelegate<IGraphResult> callback)
    {
      this.callback = callback;
      return this;
    }
  }
}
