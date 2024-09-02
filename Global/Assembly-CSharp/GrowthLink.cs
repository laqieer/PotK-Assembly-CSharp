// Decompiled with JetBrains decompiler
// Type: GrowthLink
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class GrowthLink
{
  private static AndroidJavaObject growthLink;
  private static GrowthLink instance = new GrowthLink();

  private GrowthLink()
  {
    using (AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.growthbeat.link.GrowthLink"))
      GrowthLink.growthLink = ((AndroidJavaObject) androidJavaClass).CallStatic<AndroidJavaObject>("getInstance", new object[0]);
  }

  public static GrowthLink GetInstance() => GrowthLink.instance;

  public void Initialize(string applicationId, string credentialId)
  {
    if (GrowthLink.growthLink == null)
      return;
    AndroidJavaObject androidJavaObject = ((AndroidJavaObject) new AndroidJavaClass("com.unity3d.player.UnityPlayer")).GetStatic<AndroidJavaObject>("currentActivity");
    GrowthLink.growthLink.Call("initialize", new object[3]
    {
      (object) androidJavaObject,
      (object) applicationId,
      (object) credentialId
    });
  }
}
