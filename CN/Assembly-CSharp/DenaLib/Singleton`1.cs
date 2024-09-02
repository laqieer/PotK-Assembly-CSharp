// Decompiled with JetBrains decompiler
// Type: DenaLib.Singleton`1
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
namespace DenaLib
{
  public class Singleton<T> where T : class, new()
  {
    private static T m_Instance;

    public static T Instance
    {
      get
      {
        if ((object) Singleton<T>.m_Instance == null)
          Singleton<T>.m_Instance = new T();
        if ((object) Singleton<T>.m_Instance == null)
          Debug.LogError((object) (" ouch sInstance == null !!!!! : " + typeof (T).Name));
        return Singleton<T>.m_Instance;
      }
    }

    public static void DestroyInstance() => Singleton<T>.m_Instance = (T) null;
  }
}
