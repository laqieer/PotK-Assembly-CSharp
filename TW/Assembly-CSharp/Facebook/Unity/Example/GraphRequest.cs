// Decompiled with JetBrains decompiler
// Type: Facebook.Unity.Example.GraphRequest
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
namespace Facebook.Unity.Example
{
  internal class GraphRequest : MenuBase
  {
    private string apiQuery = string.Empty;

    protected override void GetGui()
    {
      bool enabled = GUI.enabled;
      GUI.enabled = enabled && FB.IsLoggedIn;
      if (this.Button("Basic Request - Me"))
        FB.API("/me", HttpMethod.GET, new FacebookDelegate<IGraphResult>(((MenuBase) this).HandleResult));
      if (this.Button("Take and Upload screenshot"))
        this.StartCoroutine(this.TakeScreenshot());
      this.LabelAndTextField("Request", ref this.apiQuery);
      if (this.Button("Custom Request"))
        FB.API(this.apiQuery, HttpMethod.GET, new FacebookDelegate<IGraphResult>(((MenuBase) this).HandleResult));
      GUI.enabled = enabled;
    }

    [DebuggerHidden]
    private IEnumerator TakeScreenshot()
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new GraphRequest.\u003CTakeScreenshot\u003Ec__Iterator3()
      {
        \u003C\u003Ef__this = this
      };
    }
  }
}
