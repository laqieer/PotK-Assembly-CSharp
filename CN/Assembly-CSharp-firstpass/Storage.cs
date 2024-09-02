// Decompiled with JetBrains decompiler
// Type: Storage
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FC6F22C0-326E-48ED-B5EE-59590337E752
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp-firstpass.dll

using System;
using UnityEngine;

#nullable disable
public class Storage
{
  private static long _getStorageFree(string path)
  {
    jvalue[] jvalueArray = new jvalue[1]{ new jvalue() };
    jvalueArray[0].l = AndroidJNI.NewStringUTF(path);
    IntPtr num = AndroidJNI.FindClass("jp/co/gu3/plugins/Storage");
    IntPtr staticMethodId = AndroidJNI.GetStaticMethodID(num, "getStorageFree", "(Ljava/lang/String;)J");
    Debug.Log((object) ("cls_Storage: " + (object) num));
    Debug.Log((object) ("ptr_getStorageFree: " + (object) staticMethodId));
    long storageFree = AndroidJNI.CallStaticLongMethod(num, staticMethodId, jvalueArray);
    Debug.Log((object) ("free: " + (object) storageFree));
    Debug.Log((object) ("Path: " + Application.persistentDataPath));
    return storageFree;
  }

  public static long getStorageFree(string path) => Storage._getStorageFree(path);
}
