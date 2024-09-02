// Decompiled with JetBrains decompiler
// Type: FutureUnityExtension
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using System;
using UnityEngine;

#nullable disable
public static class FutureUnityExtension
{
  public static void RunOn<T>(this Future<T> future, MonoBehaviour mono, Action<T> callback = null) where T : class
  {
    if (future.HasResult)
    {
      if (callback == null)
        return;
      callback(future.Result);
    }
    else
    {
      future.SetCallback(callback);
      mono.StartCoroutine(future.Wait());
    }
  }
}
