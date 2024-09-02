// Decompiled with JetBrains decompiler
// Type: MonoBehaviourExtension
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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
