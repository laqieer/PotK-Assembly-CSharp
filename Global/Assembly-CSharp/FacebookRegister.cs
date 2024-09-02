// Decompiled with JetBrains decompiler
// Type: FacebookRegister
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using Facebook.Unity;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class FacebookRegister : Singleton<FacebookRegister>
{
  protected override void Initialize()
  {
  }

  protected void Start()
  {
    if (!FB.IsInitialized)
    {
      FB.Init((InitDelegate) (() =>
      {
        FB.ActivateApp();
        this.RegistFacebook();
      }));
    }
    else
    {
      FB.ActivateApp();
      this.RegistFacebook();
    }
  }

  private void RegistFacebook()
  {
    if (FB.IsLoggedIn)
      this.StartCoroutine(this.RegistFacebookAccessToken());
    else
      Object.Destroy((Object) ((Component) this).gameObject);
  }

  [DebuggerHidden]
  private IEnumerator RegistFacebookAccessToken()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new FacebookRegister.\u003CRegistFacebookAccessToken\u003Ec__Iterator882()
    {
      \u003C\u003Ef__this = this
    };
  }
}
