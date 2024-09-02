// Decompiled with JetBrains decompiler
// Type: Facebook.Unity.IFacebookResultHandler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

#nullable disable
namespace Facebook.Unity
{
  internal interface IFacebookResultHandler
  {
    void OnInitComplete(ResultContainer resultContainer);

    void OnLoginComplete(ResultContainer resultContainer);

    void OnLogoutComplete(ResultContainer resultContainer);

    void OnGetAppLinkComplete(ResultContainer resultContainer);

    void OnGroupCreateComplete(ResultContainer resultContainer);

    void OnGroupJoinComplete(ResultContainer resultContainer);

    void OnAppRequestsComplete(ResultContainer resultContainer);

    void OnShareLinkComplete(ResultContainer resultContainer);
  }
}
