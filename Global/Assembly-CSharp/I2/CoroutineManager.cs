// Decompiled with JetBrains decompiler
// Type: I2.CoroutineManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System.Collections;
using UnityEngine;

#nullable disable
namespace I2
{
  public class CoroutineManager : MonoBehaviour
  {
    private static CoroutineManager mInstance;

    public static Coroutine Start(IEnumerator coroutine)
    {
      if (Object.op_Equality((Object) CoroutineManager.mInstance, (Object) null))
      {
        GameObject gameObject = new GameObject("_Coroutiner");
        ((Object) gameObject).hideFlags = (HideFlags) (((Object) gameObject).hideFlags | 61);
        CoroutineManager.mInstance = gameObject.AddComponent<CoroutineManager>();
        if (Application.isPlaying)
          Object.DontDestroyOnLoad((Object) gameObject);
      }
      return CoroutineManager.mInstance.StartCoroutine(coroutine);
    }
  }
}
