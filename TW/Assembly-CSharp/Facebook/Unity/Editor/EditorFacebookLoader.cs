// Decompiled with JetBrains decompiler
// Type: Facebook.Unity.Editor.EditorFacebookLoader
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

#nullable disable
namespace Facebook.Unity.Editor
{
  internal class EditorFacebookLoader : FB.CompiledFacebookLoader
  {
    protected override FacebookGameObject FBGameObject
    {
      get
      {
        EditorFacebookGameObject component = ComponentFactory.GetComponent<EditorFacebookGameObject>();
        component.Facebook = (IFacebookImplementation) new EditorFacebook();
        return (FacebookGameObject) component;
      }
    }
  }
}
