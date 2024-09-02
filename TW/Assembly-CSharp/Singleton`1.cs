// Decompiled with JetBrains decompiler
// Type: Singleton`1
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public abstract class Singleton<T_TYPE> : SingletonBase where T_TYPE : Singleton<T_TYPE>
{
  private static T_TYPE sInstance;

  public static T_TYPE GetInstance()
  {
    if (Object.op_Equality((Object) (object) Singleton<T_TYPE>.sInstance, (Object) null))
      Singleton<T_TYPE>.sInstance = Object.FindObjectOfType(typeof (T_TYPE)) as T_TYPE;
    if (Object.op_Equality((Object) (object) Singleton<T_TYPE>.sInstance, (Object) null))
      Debug.LogError((object) (" ouch sInstance == null !!!!! : " + typeof (T_TYPE).Name));
    return Singleton<T_TYPE>.sInstance;
  }

  public static T_TYPE GetInstanceOrNull()
  {
    if (Object.op_Equality((Object) (object) Singleton<T_TYPE>.sInstance, (Object) null))
      Singleton<T_TYPE>.sInstance = Object.FindObjectOfType(typeof (T_TYPE)) as T_TYPE;
    return Singleton<T_TYPE>.sInstance;
  }

  private void Awake()
  {
    T_TYPE type = Singleton<T_TYPE>.GetInstance();
    if (Object.op_Equality((Object) (object) type, (Object) null))
      type = this as T_TYPE;
    if (Object.op_Inequality((Object) (object) type, (Object) (object) (this as T_TYPE)))
    {
      Object.Destroy((Object) ((Component) this).gameObject);
    }
    else
    {
      Singleton<T_TYPE>.sInstance = type;
      this.Initialize();
      Object.DontDestroyOnLoad((Object) ((Component) this).gameObject);
    }
  }

  protected override void clearInstance() => Singleton<T_TYPE>.sInstance = (T_TYPE) null;
}
