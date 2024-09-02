// Decompiled with JetBrains decompiler
// Type: MonoBehaviourExtension
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using UnityEngine;

#nullable disable
public static class MonoBehaviourExtension
{
  public static CoroutineData<T> StartCoroutine<T>(
    this MonoBehaviour behaviour,
    IEnumerator coroutine)
  {
    return CoroutineData<T>.Start(behaviour, coroutine);
  }

  public static CoroutineData<T> StartCoroutine<T>(
    this MonoBehaviour behaviour,
    MonitorCoroutine<T> coroutine)
  {
    return CoroutineData<T>.Start(behaviour, coroutine);
  }
}
