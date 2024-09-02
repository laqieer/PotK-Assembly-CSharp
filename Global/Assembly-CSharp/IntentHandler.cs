// Decompiled with JetBrains decompiler
// Type: IntentHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class IntentHandler
{
  private AndroidJavaObject intentHandler;
  private static IntentHandler instance = new IntentHandler();

  public IntentHandler()
  {
    using (AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.growthbeat.intenthandler.IntentHandlerWrapper"))
      this.intentHandler = ((AndroidJavaObject) androidJavaClass).CallStatic<AndroidJavaObject>("getInstance", new object[0]);
  }

  private void RunBlockOnThread(System.Action runBlock)
  {
    using (AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
    {
      // ISSUE: method pointer
      ((AndroidJavaObject) androidJavaClass).GetStatic<AndroidJavaObject>("currentActivity").Call("runOnUiThread", new object[1]
      {
        (object) new AndroidJavaRunnable((object) runBlock, __methodptr(Invoke))
      });
    }
  }

  public static IntentHandler GetInstance() => IntentHandler.instance;

  public void ClearIntentHandlers()
  {
    this.RunBlockOnThread((System.Action) (() => this.intentHandler.Call("clearIntentHandlers", new object[0])));
  }

  public void AddNoopIntentHandler()
  {
    this.RunBlockOnThread((System.Action) (() => this.intentHandler.Call("addNoopIntentHandler", new object[0])));
  }

  public void AddUrlIntentHandler()
  {
    this.RunBlockOnThread((System.Action) (() => this.intentHandler.Call("addUrlIntentHandler", new object[0])));
  }

  public void AddCustomIntentHandler(string gameObjectName, string methodName)
  {
    this.RunBlockOnThread((System.Action) (() => this.intentHandler.Call("addCustomIntentHandler", new object[2]
    {
      (object) gameObjectName,
      (object) methodName
    })));
  }
}
