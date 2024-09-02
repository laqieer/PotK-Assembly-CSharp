// Decompiled with JetBrains decompiler
// Type: DenaLib.Singleton`1
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
