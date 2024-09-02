// Decompiled with JetBrains decompiler
// Type: Gsc.Core.ImmortalObject
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections;
using UnityEngine;

namespace Gsc.Core
{
  public class ImmortalObject : MonoBehaviour
  {
    private static ImmortalObject _instance;

    public static ImmortalObject Instance
    {
      get
      {
        if ((UnityEngine.Object) ImmortalObject._instance == (UnityEngine.Object) null)
        {
          GameObject gameObject = new GameObject("GSCC.ImmortalObject");
          gameObject.hideFlags = HideFlags.HideAndDontSave;
          UnityEngine.Object.DontDestroyOnLoad((UnityEngine.Object) gameObject);
          ImmortalObject._instance = gameObject.AddComponent<ImmortalObject>();
        }
        return ImmortalObject._instance;
      }
    }

    private void Awake()
    {
      if (!((UnityEngine.Object) ImmortalObject._instance != (UnityEngine.Object) null))
        return;
      UnityEngine.Object.Destroy((UnityEngine.Object) this.gameObject);
    }

    public static void Initialize()
    {
      if (!((UnityEngine.Object) ImmortalObject._instance != (UnityEngine.Object) null))
        return;
      UnityEngine.Object.Destroy((UnityEngine.Object) ImmortalObject._instance.gameObject);
      ImmortalObject._instance = (ImmortalObject) null;
    }

    public void DelayInvoke(Action f, float seconds) => this.StartCoroutine(ImmortalObject._DelayInvoke(f, seconds));

    public void DelayInvoke<T1>(Action<T1> f, T1 arg1, float seconds) => this.StartCoroutine(ImmortalObject._DelayInvoke<T1>(f, arg1, seconds));

    public void DelayInvoke<T1, T2>(Action<T1, T2> f, T1 arg1, T2 arg2, float seconds) => this.StartCoroutine(ImmortalObject._DelayInvoke<T1, T2>(f, arg1, arg2, seconds));

    public void DelayInvoke<T1, T2, T3>(
      Action<T1, T2, T3> f,
      T1 arg1,
      T2 arg2,
      T3 arg3,
      float seconds)
    {
      this.StartCoroutine(ImmortalObject._DelayInvoke<T1, T2, T3>(f, arg1, arg2, arg3, seconds));
    }

    private static IEnumerator _DelayInvoke(Action f, float seconds)
    {
      yield return (object) new WaitForSeconds(seconds);
      f();
    }

    private static IEnumerator _DelayInvoke<T1>(Action<T1> f, T1 arg1, float seconds)
    {
      yield return (object) new WaitForSeconds(seconds);
      f(arg1);
    }

    private static IEnumerator _DelayInvoke<T1, T2>(
      Action<T1, T2> f,
      T1 arg1,
      T2 arg2,
      float seconds)
    {
      yield return (object) new WaitForSeconds(seconds);
      f(arg1, arg2);
    }

    private static IEnumerator _DelayInvoke<T1, T2, T3>(
      Action<T1, T2, T3> f,
      T1 arg1,
      T2 arg2,
      T3 arg3,
      float seconds)
    {
      yield return (object) new WaitForSeconds(seconds);
      f(arg1, arg2, arg3);
    }
  }
}
