// Decompiled with JetBrains decompiler
// Type: SingletonExtension
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
