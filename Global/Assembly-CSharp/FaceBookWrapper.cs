// Decompiled with JetBrains decompiler
// Type: FaceBookWrapper
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using Facebook.Unity;
using System;
using System.Collections.Generic;

#nullable disable
public static class FaceBookWrapper
{
  private static bool init;
  private static bool init_complete;
  private static string lintStr = string.Empty;
  private static string linkNameStr = string.Empty;
  private static string linkCaptionStr = string.Empty;
  private static string linkDescriptionStr = string.Empty;

  public static void TutorialComplete()
  {
    if (!FaceBookWrapper.init_complete)
      return;
    FB.LogAppEvent("fb_mobile_tutorial_completion");
  }

  public static void Purchase(float purchase, string currency, string productID)
  {
    if (!FaceBookWrapper.init_complete)
      return;
    FB.LogPurchase(purchase, currency);
  }

  public static void Feed(
    string link,
    string linkName,
    string linkCaption,
    string linkDescription)
  {
    if (!FaceBookWrapper.init_complete)
      return;
    FaceBookWrapper.lintStr = link;
    FaceBookWrapper.linkNameStr = linkName;
    FaceBookWrapper.linkCaptionStr = linkCaption;
    FaceBookWrapper.linkDescriptionStr = linkDescription;
    if (FB.IsLoggedIn)
      FB.FeedShare(string.Empty, new Uri(FaceBookWrapper.lintStr), FaceBookWrapper.linkNameStr, FaceBookWrapper.linkCaptionStr, FaceBookWrapper.linkDescriptionStr, mediaSource: string.Empty, callback: new FacebookDelegate<IShareResult>(FaceBookWrapper.OnActionShared));
    else
      FB.LogInWithReadPermissions((IEnumerable<string>) new List<string>()
      {
        "public_profile",
        "email",
        "user_friends"
      }, new FacebookDelegate<ILoginResult>(FaceBookWrapper.OnLoguinWithFeed));
  }

  public static void OnLoguinWithFeed(ILoginResult result)
  {
    if (result.Error != null)
      Debug.LogError((object) ("OnActionShared: Error: " + result.Error));
    if (result == null || result.Error != null)
      return;
    FB.FeedShare(string.Empty, new Uri(FaceBookWrapper.lintStr), FaceBookWrapper.linkNameStr, FaceBookWrapper.linkCaptionStr, FaceBookWrapper.linkDescriptionStr, mediaSource: string.Empty, callback: new FacebookDelegate<IShareResult>(FaceBookWrapper.OnActionShared));
  }

  public static void OnActionShared(IShareResult result)
  {
    if (result.Error != null)
      Debug.LogError((object) ("OnActionShared: Error: " + result.Error));
    if (result == null || result.Error != null)
      return;
    if (result.Cancelled)
    {
      Debug.LogWarning((object) "Request cancelled");
    }
    else
    {
      if (string.IsNullOrEmpty(result.PostId))
        return;
      Debug.LogWarning((object) "Request Send");
    }
  }

  public static void setup()
  {
    if (FaceBookWrapper.init)
      return;
    FaceBookWrapper.init = true;
    if (!FB.IsInitialized)
      FB.Init((InitDelegate) (() =>
      {
        FaceBookWrapper.init_complete = true;
        FB.ActivateApp();
      }));
    else
      FB.ActivateApp();
  }
}
