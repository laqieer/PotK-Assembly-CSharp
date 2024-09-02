// Decompiled with JetBrains decompiler
// Type: Facebook.Unity.ComponentFactory
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
namespace Facebook.Unity
{
  internal class ComponentFactory
  {
    public const string GameObjectName = "UnityFacebookSDKPlugin";
    private static GameObject facebookGameObject;

    private static GameObject FacebookGameObject
    {
      get
      {
        if (Object.op_Equality((Object) ComponentFactory.facebookGameObject, (Object) null))
          ComponentFactory.facebookGameObject = new GameObject("UnityFacebookSDKPlugin");
        return ComponentFactory.facebookGameObject;
      }
    }

    public static T GetComponent<T>(ComponentFactory.IfNotExist ifNotExist = ComponentFactory.IfNotExist.AddNew) where T : MonoBehaviour
    {
      GameObject facebookGameObject = ComponentFactory.FacebookGameObject;
      T component = facebookGameObject.GetComponent<T>();
      if (Object.op_Equality((Object) (object) component, (Object) null) && ifNotExist == ComponentFactory.IfNotExist.AddNew)
        component = facebookGameObject.AddComponent<T>();
      return component;
    }

    public static T AddComponent<T>() where T : MonoBehaviour
    {
      return ComponentFactory.FacebookGameObject.AddComponent<T>();
    }

    internal enum IfNotExist
    {
      AddNew,
      ReturnNull,
    }
  }
}
