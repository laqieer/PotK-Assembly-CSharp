// Decompiled with JetBrains decompiler
// Type: Facebook.Unity.Mobile.IOS.IOSFacebookLoader
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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
