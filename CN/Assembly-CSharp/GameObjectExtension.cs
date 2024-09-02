// Decompiled with JetBrains decompiler
// Type: GameObjectExtension
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public static class GameObjectExtension
{
  public static T CloneAndGetComponent<T>(this GameObject self, GameObject parent = null) where T : Component
  {
    return Object.op_Equality((Object) self, (Object) null) ? (T) null : self.CloneAndGetComponent<T>(!Object.op_Implicit((Object) parent) ? (Transform) null : parent.transform);
  }

  public static T CloneAndGetComponent<T>(this GameObject self, Transform parent) where T : Component
  {
    return Object.op_Equality((Object) self, (Object) null) ? (T) null : self.Clone(parent).GetComponent<T>();
  }

  public static T CloneAndAddComponent<T>(this GameObject self, GameObject parent = null) where T : Component
  {
    return Object.op_Equality((Object) self, (Object) null) ? (T) null : self.CloneAndAddComponent<T>(!Object.op_Implicit((Object) parent) ? (Transform) null : parent.transform);
  }

  public static T CloneAndAddComponent<T>(this GameObject self, Transform parent) where T : Component
  {
    return Object.op_Equality((Object) self, (Object) null) ? (T) null : self.Clone(parent).AddComponent<T>();
  }

  public static GameObject SetParentSafeLocalTransform(this GameObject self, GameObject parent)
  {
    if (Object.op_Equality((Object) self, (Object) null))
      return (GameObject) null;
    Vector3 localScale = self.transform.localScale;
    Vector3 localPosition = self.transform.localPosition;
    Quaternion localRotation = self.transform.localRotation;
    self.layer = parent.layer;
    self.transform.parent = parent.transform;
    self.transform.localScale = localScale;
    self.transform.localPosition = localPosition;
    self.transform.localRotation = localRotation;
    return self;
  }

  public static GameObject SetParent(this GameObject self, GameObject parent)
  {
    if (Object.op_Equality((Object) self, (Object) null))
      return (GameObject) null;
    self.layer = parent.layer;
    self.transform.parent = parent.transform;
    self.transform.localScale = Vector3.one;
    self.transform.localPosition = Vector3.zero;
    self.transform.localRotation = Quaternion.identity;
    return self;
  }

  public static GameObject SetParent(this GameObject self, GameObject parent, float ratio)
  {
    if (Object.op_Equality((Object) self, (Object) null))
      return (GameObject) null;
    self.layer = parent.layer;
    self.transform.parent = parent.transform;
    self.transform.localScale = new Vector3(ratio, ratio, 1f);
    self.transform.localPosition = Vector3.zero;
    self.transform.localRotation = Quaternion.identity;
    return self;
  }

  public static GameObject Clone(this GameObject self, Transform parent = null)
  {
    if (Object.op_Equality((Object) self, (Object) null))
      return (GameObject) null;
    GameObject gameObject = Object.Instantiate<GameObject>(self);
    gameObject.transform.parent = parent ?? gameObject.transform.parent;
    gameObject.transform.localScale = Vector3.one;
    gameObject.transform.localPosition = Vector3.zero;
    gameObject.transform.localRotation = Quaternion.identity;
    return gameObject;
  }

  public static void ToggleOnce(this IEnumerable<GameObject> self, int index)
  {
    self.ForEachIndex<GameObject>((Action<GameObject, int>) ((go, n) => go.SetActive(n == index)));
  }

  public static void ToggleOnceEx(this IEnumerable<GameObject> self, int index)
  {
    self.ForEachIndex<GameObject>((Action<GameObject, int>) ((go, n) =>
    {
      if (!Object.op_Inequality((Object) go, (Object) null))
        return;
      go.SetActive(n == index);
    }));
  }

  public static T GetOrAddComponent<T>(this GameObject self) where T : Component
  {
    if (Object.op_Equality((Object) self, (Object) null))
      return (T) null;
    T component = self.GetComponent<T>();
    return Object.op_Inequality((Object) (object) component, (Object) null) ? component : self.AddComponent<T>();
  }
}
