// Decompiled with JetBrains decompiler
// Type: Facebook.Unity.Mobile.Android.AndroidFacebookLoader
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

#nullable disable
namespace Facebook.Unity.Mobile.Android
{
  internal class AndroidFacebookLoader : FB.CompiledFacebookLoader
  {
    protected override FacebookGameObject FBGameObject
    {
      get
      {
        AndroidFacebookGameObject component = ComponentFactory.GetComponent<AndroidFacebookGameObject>();
        if (component.Facebook == null)
          component.Facebook = (IFacebookImplementation) new AndroidFacebook();
        return (FacebookGameObject) component;
      }
    }
  }
}
