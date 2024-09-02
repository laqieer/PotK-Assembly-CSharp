// Decompiled with JetBrains decompiler
// Type: Facebook.Unity.FacebookGameObject
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
namespace Facebook.Unity
{
  internal abstract class FacebookGameObject : MonoBehaviour, IFacebookCallbackHandler
  {
    public IFacebookImplementation Facebook { get; set; }

    public bool Initialized { get; private set; }

    public void Awake()
    {
      Object.DontDestroyOnLoad((Object) this);
      AccessToken.CurrentAccessToken = (AccessToken) null;
      this.OnAwake();
    }

    public void OnInitComplete(string message)
    {
      this.Facebook.OnInitComplete(message);
      this.Initialized = true;
    }

    public void OnLoginComplete(string message) => this.Facebook.OnLoginComplete(message);

    public void OnLogoutComplete(string message) => this.Facebook.OnLogoutComplete(message);

    public void OnGetAppLinkComplete(string message) => this.Facebook.OnGetAppLinkComplete(message);

    public void OnGroupCreateComplete(string message)
    {
      this.Facebook.OnGroupCreateComplete(message);
    }

    public void OnGroupJoinComplete(string message) => this.Facebook.OnGroupJoinComplete(message);

    public void OnAppRequestsComplete(string message)
    {
      this.Facebook.OnAppRequestsComplete(message);
    }

    public void OnShareLinkComplete(string message) => this.Facebook.OnShareLinkComplete(message);

    protected virtual void OnAwake()
    {
    }
  }
}
