﻿// Decompiled with JetBrains decompiler
// Type: Facebook.Unity.Mobile.Android.FBJavaClass
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
namespace Facebook.Unity.Mobile.Android
{
  internal class FBJavaClass : IAndroidJavaClass
  {
    private const string FacebookJavaClassName = "com.facebook.unity.FB";
    private AndroidJavaClass facebookJavaClass = new AndroidJavaClass("com.facebook.unity.FB");

    public T CallStatic<T>(string methodName)
    {
      return ((AndroidJavaObject) this.facebookJavaClass).CallStatic<T>(methodName, new object[0]);
    }

    public void CallStatic(string methodName, params object[] args)
    {
      ((AndroidJavaObject) this.facebookJavaClass).CallStatic(methodName, args);
    }
  }
}
