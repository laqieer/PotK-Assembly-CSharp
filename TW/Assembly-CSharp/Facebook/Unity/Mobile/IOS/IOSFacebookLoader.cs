// Decompiled with JetBrains decompiler
// Type: Facebook.Unity.Mobile.IOS.IOSFacebookLoader
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

#nullable disable
namespace Facebook.Unity.Mobile.IOS
{
  internal class IOSFacebookLoader : FB.CompiledFacebookLoader
  {
    protected override FacebookGameObject FBGameObject
    {
      get
      {
        IOSFacebookGameObject component = ComponentFactory.GetComponent<IOSFacebookGameObject>();
        if (component.Facebook == null)
          component.Facebook = (IFacebookImplementation) new IOSFacebook();
        return (FacebookGameObject) component;
      }
    }
  }
}
