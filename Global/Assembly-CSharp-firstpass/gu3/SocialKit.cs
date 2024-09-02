// Decompiled with JetBrains decompiler
// Type: gu3.SocialKit
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E910E095-517B-41AE-AAF8-B85E770EBAF1
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp-firstpass.dll

using System.Runtime.InteropServices;
using UnityEngine;

#nullable disable
namespace gu3
{
  public class SocialKit : MonoBehaviour
  {
    private const string LIBNAME = "UnitySocialKit";

    [DllImport("UnitySocialKit")]
    private static extern void SocialKit_setListener(string gameObjectName);

    [DllImport("UnitySocialKit")]
    private static extern void SocialKit_Share_send(int platform, string message);

    private void Awake()
    {
      AndroidJavaClass androidJavaClass1 = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
      AndroidJavaObject androidJavaObject = ((AndroidJavaObject) androidJavaClass1).GetStatic<AndroidJavaObject>("currentActivity");
      AndroidJavaClass androidJavaClass2 = new AndroidJavaClass("jp.co.gu3.social.SocialKit");
      ((AndroidJavaObject) androidJavaClass2).CallStatic("setCurrentActivity", new object[1]
      {
        (object) androidJavaObject
      });
      ((AndroidJavaObject) androidJavaClass2).Dispose();
      androidJavaObject.Dispose();
      ((AndroidJavaObject) androidJavaClass1).Dispose();
      SocialKit.SocialKit_setListener(((Object) ((Component) this).gameObject).name);
    }

    private void __SocialKit_Share_OnSucceeded(string ptr)
    {
      SocialKit.Share.Listener.OnSucceeded((SocialKit.Platform) int.Parse(ptr));
    }

    private void __SocialKit_Share_NotInstalled(string ptr)
    {
      SocialKit.Share.Listener.NotInstalled((SocialKit.Platform) int.Parse(ptr));
    }

    public enum Platform
    {
      Facebook,
      Twitter,
      Line,
      GoogleX,
      Lobi,
    }

    public static class Share
    {
      public static SocialKit.Share.IShareListener Listener { get; set; }

      public static void Send(SocialKit.Platform platform, string message)
      {
        SocialKit.SocialKit_Share_send((int) platform, message);
      }

      public interface IShareListener
      {
        void OnSucceeded(SocialKit.Platform platform);

        void NotInstalled(SocialKit.Platform platform);
      }
    }
  }
}
