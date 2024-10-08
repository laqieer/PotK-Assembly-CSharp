﻿// Decompiled with JetBrains decompiler
// Type: MonoBehaviourExtension
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System.Collections;
using UnityEngine;

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
