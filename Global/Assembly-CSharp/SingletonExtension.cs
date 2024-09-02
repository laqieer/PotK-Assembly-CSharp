// Decompiled with JetBrains decompiler
// Type: SingletonExtension
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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
