// Decompiled with JetBrains decompiler
// Type: Facebook.Unity.Canvas.CanvasJSWrapper
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
namespace Facebook.Unity.Canvas
{
  internal class CanvasJSWrapper : ICanvasJSWrapper
  {
    private const string JSSDKBindingFileName = "JSSDKBindings";

    public string IntegrationMethodJs
    {
      get
      {
        TextAsset textAsset = Resources.Load("JSSDKBindings") as TextAsset;
        return Object.op_Implicit((Object) textAsset) ? textAsset.text : (string) null;
      }
    }

    public string GetSDKVersion() => "v2.5";

    public void ExternalCall(string functionName, params object[] args)
    {
      Application.ExternalCall(functionName, args);
    }

    public void ExternalEval(string script) => Application.ExternalEval(script);

    public void DisableFullScreen()
    {
      if (!Screen.fullScreen)
        return;
      Screen.fullScreen = false;
    }
  }
}
