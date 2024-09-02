// Decompiled with JetBrains decompiler
// Type: Facebook.Unity.IFacebookCallbackHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

#nullable disable
namespace Facebook.Unity
{
  internal interface IFacebookCallbackHandler
  {
    void OnInitComplete(string message);

    void OnLoginComplete(string message);

    void OnLogoutComplete(string message);

    void OnGetAppLinkComplete(string message);

    void OnGroupCreateComplete(string message);

    void OnGroupJoinComplete(string message);

    void OnAppRequestsComplete(string message);

    void OnShareLinkComplete(string message);
  }
}
