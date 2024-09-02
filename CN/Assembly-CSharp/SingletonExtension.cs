// Decompiled with JetBrains decompiler
// Type: SingletonExtension
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public static class SingletonExtension
{
  public static void SingletonDestory(this GameObject self)
  {
    foreach (SingletonBase componentsInChild in self.GetComponentsInChildren<SingletonBase>(true))
      componentsInChild.forceDestroy();
    Object.Destroy((Object) self);
  }
}
