// Decompiled with JetBrains decompiler
// Type: FutureUnityExtension
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
