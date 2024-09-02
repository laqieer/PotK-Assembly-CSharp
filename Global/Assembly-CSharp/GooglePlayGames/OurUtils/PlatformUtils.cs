// Decompiled with JetBrains decompiler
// Type: GooglePlayGames.OurUtils.PlatformUtils
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
namespace GooglePlayGames.OurUtils
{
  public static class PlatformUtils
  {
    public static bool Supported
    {
      get
      {
        AndroidJavaObject androidJavaObject1 = ((AndroidJavaObject) new AndroidJavaClass("com.unity3d.player.UnityPlayer")).GetStatic<AndroidJavaObject>("currentActivity").Call<AndroidJavaObject>("getPackageManager", new object[0]);
        AndroidJavaObject androidJavaObject2;
        try
        {
          androidJavaObject2 = androidJavaObject1.Call<AndroidJavaObject>("getLaunchIntentForPackage", new object[1]
          {
            (object) "com.google.android.play.games"
          });
        }
        catch (Exception ex)
        {
          return false;
        }
        return androidJavaObject2 != null;
      }
    }
  }
}
