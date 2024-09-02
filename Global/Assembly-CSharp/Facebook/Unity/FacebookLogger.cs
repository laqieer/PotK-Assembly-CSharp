// Decompiled with JetBrains decompiler
// Type: Facebook.Unity.FacebookLogger
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
namespace Facebook.Unity
{
  internal static class FacebookLogger
  {
    private const string UnityAndroidTag = "Facebook.Unity.FBDebug";

    static FacebookLogger()
    {
      FacebookLogger.Instance = (IFacebookLogger) new FacebookLogger.CustomLogger();
    }

    internal static IFacebookLogger Instance { private get; set; }

    public static void Log(string msg) => FacebookLogger.Instance.Log(msg);

    public static void Log(string format, params string[] args)
    {
      FacebookLogger.Log(string.Format(format, (object[]) args));
    }

    public static void Info(string msg) => FacebookLogger.Instance.Info(msg);

    public static void Info(string format, params string[] args)
    {
      FacebookLogger.Info(string.Format(format, (object[]) args));
    }

    public static void Warn(string msg) => FacebookLogger.Instance.Warn(msg);

    public static void Warn(string format, params string[] args)
    {
      FacebookLogger.Warn(string.Format(format, (object[]) args));
    }

    public static void Error(string msg) => FacebookLogger.Instance.Error(msg);

    public static void Error(string format, params string[] args)
    {
      FacebookLogger.Error(string.Format(format, (object[]) args));
    }

    private class CustomLogger : IFacebookLogger
    {
      private IFacebookLogger logger;

      public CustomLogger() => this.logger = (IFacebookLogger) new FacebookLogger.AndroidLogger();

      public void Log(string msg)
      {
        if (!Debug.isDebugBuild)
          return;
        Debug.Log((object) msg);
        this.logger.Log(msg);
      }

      public void Info(string msg)
      {
        Debug.Log((object) msg);
        this.logger.Info(msg);
      }

      public void Warn(string msg)
      {
        Debug.LogWarning((object) msg);
        this.logger.Warn(msg);
      }

      public void Error(string msg)
      {
        Debug.LogError((object) msg);
        this.logger.Error(msg);
      }
    }

    private class AndroidLogger : IFacebookLogger
    {
      public void Log(string msg)
      {
        using (AndroidJavaClass androidJavaClass = new AndroidJavaClass("android.util.Log"))
          ((AndroidJavaObject) androidJavaClass).CallStatic<int>("v", new object[2]
          {
            (object) "Facebook.Unity.FBDebug",
            (object) msg
          });
      }

      public void Info(string msg)
      {
        using (AndroidJavaClass androidJavaClass = new AndroidJavaClass("android.util.Log"))
          ((AndroidJavaObject) androidJavaClass).CallStatic<int>("i", new object[2]
          {
            (object) "Facebook.Unity.FBDebug",
            (object) msg
          });
      }

      public void Warn(string msg)
      {
        using (AndroidJavaClass androidJavaClass = new AndroidJavaClass("android.util.Log"))
          ((AndroidJavaObject) androidJavaClass).CallStatic<int>("w", new object[2]
          {
            (object) "Facebook.Unity.FBDebug",
            (object) msg
          });
      }

      public void Error(string msg)
      {
        using (AndroidJavaClass androidJavaClass = new AndroidJavaClass("android.util.Log"))
          ((AndroidJavaObject) androidJavaClass).CallStatic<int>("e", new object[2]
          {
            (object) "Facebook.Unity.FBDebug",
            (object) msg
          });
      }
    }
  }
}
