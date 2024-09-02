// Decompiled with JetBrains decompiler
// Type: GrowthPush
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class GrowthPush
{
  private AndroidJavaObject growthPush;
  private static GrowthPush instance = new GrowthPush();

  private GrowthPush()
  {
    using (AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.growthpush.GrowthPush"))
      this.growthPush = ((AndroidJavaObject) androidJavaClass).CallStatic<AndroidJavaObject>("getInstance", new object[0]);
  }

  public static GrowthPush GetInstance() => GrowthPush.instance;

  public void Initialize(
    string applicationId,
    string credentialId,
    GrowthPush.Environment environment)
  {
    this.Initialize(applicationId, credentialId, environment, true);
  }

  public void Initialize(
    string applicationId,
    string credentialId,
    GrowthPush.Environment environment,
    bool adInfoEnable)
  {
    using (AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.growthpush.model.Environment"))
    {
      AndroidJavaObject androidJavaObject1 = ((AndroidJavaObject) new AndroidJavaClass("com.unity3d.player.UnityPlayer")).GetStatic<AndroidJavaObject>("currentActivity");
      AndroidJavaObject androidJavaObject2 = ((AndroidJavaObject) androidJavaClass).GetStatic<AndroidJavaObject>(environment != GrowthPush.Environment.Production ? "development" : "production");
      this.growthPush.Call("initialize", new object[5]
      {
        (object) androidJavaObject1,
        (object) applicationId,
        (object) credentialId,
        (object) androidJavaObject2,
        (object) adInfoEnable
      });
    }
  }

  public void RequestDeviceToken(string senderId)
  {
    this.growthPush.Call("requestRegistrationId", new object[1]
    {
      (object) senderId
    });
  }

  public void RequestDeviceToken()
  {
  }

  public string GetDeviceToken()
  {
    return this.growthPush.Call<string>("registerGCM", new object[1]
    {
      (object) ((AndroidJavaObject) new AndroidJavaClass("com.unity3d.player.UnityPlayer")).GetStatic<AndroidJavaObject>("currentActivity")
    });
  }

  public void SetDeviceToken(string deviceToken)
  {
  }

  public void ClearBadge()
  {
  }

  public void SetTag(string name) => this.SetTag(name, string.Empty);

  public void SetTag(string name, string value)
  {
    this.growthPush.Call("setTag", new object[2]
    {
      (object) name,
      (object) value
    });
  }

  public void TrackEvent(string name) => this.TrackEvent(name, string.Empty);

  public void TrackEvent(string name, string value)
  {
    this.growthPush.Call("trackEvent", new object[2]
    {
      (object) name,
      (object) value
    });
  }

  public void TrackEvent(string name, string value, string gameObject, string methodName)
  {
    using (AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.growthpush.ShowMessageHandlerWrapper"))
      ((AndroidJavaObject) androidJavaClass).CallStatic("trackEvent", new object[4]
      {
        (object) name,
        (object) value,
        (object) gameObject,
        (object) methodName
      });
  }

  public void RenderMessage(string uuid)
  {
    using (AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.growthpush.ShowMessageHandlerWrapper"))
      ((AndroidJavaObject) androidJavaClass).CallStatic("renderMessage", new object[1]
      {
        (object) uuid
      });
  }

  public void SetDeviceTags() => this.growthPush.Call("setDeviceTags", new object[0]);

  public void SetBaseUrl(string baseUrl)
  {
    this.growthPush.Call<AndroidJavaObject>("getHttpClient", new object[0]).Call("setBaseUrl", new object[1]
    {
      (object) baseUrl
    });
  }

  public enum Environment
  {
    Unknown,
    Development,
    Production,
  }
}
