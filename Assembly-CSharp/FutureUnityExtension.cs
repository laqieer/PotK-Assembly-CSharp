// Decompiled with JetBrains decompiler
// Type: FutureUnityExtension
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using UnityEngine;

public static class FutureUnityExtension
{
  public static void RunOn<T>(this Future<T> future, MonoBehaviour mono, System.Action<T> callback = null) where T : class
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
