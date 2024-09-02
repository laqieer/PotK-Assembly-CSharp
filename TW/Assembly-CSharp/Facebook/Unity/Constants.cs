// Decompiled with JetBrains decompiler
// Type: Facebook.Unity.Constants
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
    public const string OnJoinGroupCompleteMethodName = "OnJoinGroupComplete";
    public const string GraphUrl = "https://graph.facebook.com";
    public const string UserLikesPermission = "user_likes";
    public const string EmailPermission = "email";
    public const string PublishActionsPermission = "publish_actions";
    public const string PublishPagesPermission = "publish_pages";

    public static bool IsMobile => true;

    public static bool IsEditor => false;

    public static bool IsWeb => false;
  }
}
