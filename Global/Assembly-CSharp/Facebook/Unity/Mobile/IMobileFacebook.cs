// Decompiled with JetBrains decompiler
// Type: Facebook.Unity.Mobile.IMobileFacebook
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;

#nullable disable
namespace Facebook.Unity.Mobile
{
  internal interface IMobileFacebook : IFacebook
  {
    ShareDialogMode ShareDialogMode { get; set; }

    void AppInvite(
      Uri appLinkUrl,
      Uri previewImageUrl,
      FacebookDelegate<IAppInviteResult> callback);

    void FetchDeferredAppLink(FacebookDelegate<IAppLinkResult> callback);

    void RefreshCurrentAccessToken(
      FacebookDelegate<IAccessTokenRefreshResult> callback);
  }
}
