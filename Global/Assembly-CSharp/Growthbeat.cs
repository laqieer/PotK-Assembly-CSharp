// Decompiled with JetBrains decompiler
// Type: Growthbeat
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class Growthbeat
{
  private static Growthbeat instance = new Growthbeat();
  private static AndroidJavaObject growthbeat;

  public Growthbeat()
  {
    using (AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.growthbeat.Growthbeat"))
      Growthbeat.growthbeat = ((AndroidJavaObject) androidJavaClass).CallStatic<AndroidJavaObject>("getInstance", new object[0]);
  }

  public static Growthbeat GetInstance() => Growthbeat.instance;

  public void SetLoggerSilent(bool silent)
  {
    if (Growthbeat.growthbeat == null)
      return;
    Growthbeat.growthbeat.Call("setLoggerSilent", new object[1]
    {
      (object) silent
    });
  }

  public void setBaseUrl(string baseUrl)
  {
    using (AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.growthbeat.GrowthbeatCore"))
      ((AndroidJavaObject) androidJavaClass).CallStatic<AndroidJavaObject>("getInstance", new object[0]).Call<AndroidJavaObject>("getHttpClient", new object[0]).Call(nameof (setBaseUrl), new object[1]
      {
        (object) baseUrl
      });
  }
}
