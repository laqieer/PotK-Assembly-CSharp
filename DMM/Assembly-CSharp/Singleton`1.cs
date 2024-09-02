// Decompiled with JetBrains decompiler
// Type: Singleton`1
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public abstract class Singleton<T_TYPE> : SingletonBase where T_TYPE : Singleton<T_TYPE>
{
  private static T_TYPE sInstance;

  public static T_TYPE GetInstance()
  {
    if ((Object) Singleton<T_TYPE>.sInstance == (Object) null)
      Singleton<T_TYPE>.sInstance = Object.FindObjectOfType(typeof (T_TYPE)) as T_TYPE;
    return Singleton<T_TYPE>.sInstance;
  }

  public static T_TYPE GetInstanceOrNull()
  {
    if ((Object) Singleton<T_TYPE>.sInstance == (Object) null)
      Singleton<T_TYPE>.sInstance = Object.FindObjectOfType(typeof (T_TYPE)) as T_TYPE;
    return Singleton<T_TYPE>.sInstance;
  }

  private void Awake()
  {
    T_TYPE type = Singleton<T_TYPE>.GetInstance();
    if ((Object) type == (Object) null)
      type = this as T_TYPE;
    if ((Object) type != (Object) (this as T_TYPE))
    {
      Object.Destroy((Object) this.gameObject);
    }
    else
    {
      Singleton<T_TYPE>.sInstance = type;
      this.Initialize();
      Object.DontDestroyOnLoad((Object) this.gameObject);
    }
  }

  protected override void clearInstance() => Singleton<T_TYPE>.sInstance = default (T_TYPE);
}
