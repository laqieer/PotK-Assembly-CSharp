// Decompiled with JetBrains decompiler
// Type: Facebook.Unity.Canvas.CanvasFacebookLoader
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

#nullable disable
namespace Facebook.Unity.Canvas
{
  internal class CanvasFacebookLoader : FB.CompiledFacebookLoader
  {
    protected override FacebookGameObject FBGameObject
    {
      get
      {
        CanvasFacebookGameObject component = ComponentFactory.GetComponent<CanvasFacebookGameObject>();
        if (component.Facebook == null)
          component.Facebook = (IFacebookImplementation) new CanvasFacebook();
        return (FacebookGameObject) component;
      }
    }
  }
}
