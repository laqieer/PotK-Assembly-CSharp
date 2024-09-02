// Decompiled with JetBrains decompiler
// Type: Facebook.Unity.Constants
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;
using System.Globalization;
using UnityEngine;

#nullable disable
namespace Facebook.Unity
{
  internal static class Constants
  {
    public const string CallbackIdKey = "callback_id";
    public const string AccessTokenKey = "access_token";
    public const string UrlKey = "url";
    public const string RefKey = "ref";
    public const string ExtrasKey = "extras";
    public const string TargetUrlKey = "target_url";
    public const string CancelledKey = "cancelled";
    public const string ErrorKey = "error";
    public const string OnPayCompleteMethodName = "OnPayComplete";
    public const string OnShareCompleteMethodName = "OnShareLinkComplete";
    public const string OnAppRequestsCompleteMethodName = "OnAppRequestsComplete";
    public const string OnGroupCreateCompleteMethodName = "OnGroupCreateComplete";
    public const string OnGroupJoinCompleteMethodName = "OnJoinGroupComplete";
    public const string GraphApiVersion = "v2.5";
    public const string GraphUrlFormat = "https://graph.{0}/{1}/";
    public const string UserLikesPermission = "user_likes";
    public const string EmailPermission = "email";
    public const string PublishActionsPermission = "publish_actions";
    public const string PublishPagesPermission = "publish_pages";
    private static FacebookUnityPlatform? currentPlatform;

    public static Uri GraphUrl
    {
      get
      {
        return new Uri(string.Format((IFormatProvider) CultureInfo.InvariantCulture, "https://graph.{0}/{1}/", new object[2]
        {
          (object) FB.FacebookDomain,
          (object) FB.GraphApiVersion
        }));
      }
    }

    public static string GraphApiUserAgent
    {
      get
      {
        return string.Format((IFormatProvider) CultureInfo.InvariantCulture, "{0} {1}", new object[2]
        {
          (object) FB.FacebookImpl.SDKUserAgent,
          (object) Constants.UnitySDKUserAgent
        });
      }
    }

    public static bool IsMobile
    {
      get
      {
        return Constants.CurrentPlatform == FacebookUnityPlatform.Android || Constants.CurrentPlatform == FacebookUnityPlatform.IOS;
      }
    }

    public static bool IsEditor => false;

    public static bool IsWeb
    {
      get
      {
        return Constants.CurrentPlatform == FacebookUnityPlatform.WebGL || Constants.CurrentPlatform == FacebookUnityPlatform.WebPlayer;
      }
    }

    public static string UnitySDKUserAgentSuffixLegacy
    {
      get
      {
        return string.Format((IFormatProvider) CultureInfo.InvariantCulture, "Unity.{0}", new object[1]
        {
          (object) FacebookSdkVersion.Build
        });
      }
    }

    public static string UnitySDKUserAgent
    {
      get => Utilities.GetUserAgent("FBUnitySDK", FacebookSdkVersion.Build);
    }

    public static bool DebugMode => Debug.isDebugBuild;

    public static FacebookUnityPlatform CurrentPlatform
    {
      get
      {
        if (!Constants.currentPlatform.HasValue)
          Constants.currentPlatform = new FacebookUnityPlatform?(Constants.GetCurrentPlatform());
        return Constants.currentPlatform.Value;
      }
      set => Constants.currentPlatform = new FacebookUnityPlatform?(value);
    }

    private static FacebookUnityPlatform GetCurrentPlatform()
    {
      RuntimePlatform platform = Application.platform;
      switch (platform - 3)
      {
        case 0:
        case 2:
          return FacebookUnityPlatform.WebPlayer;
        case 5:
          return FacebookUnityPlatform.IOS;
        default:
          if (platform == 11)
            return FacebookUnityPlatform.Android;
          return platform == 17 ? FacebookUnityPlatform.WebGL : FacebookUnityPlatform.Unknown;
      }
    }
  }
}
