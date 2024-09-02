// Decompiled with JetBrains decompiler
// Type: DenaLib.Debuger
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
namespace DenaLib
{
  public class Debuger
  {
    public static bool EnableLog = true;
    public static bool LogState;
    public static Debuger.LogCallback LogCb;

    public static void Log(string message, Color color)
    {
      if (!Debuger.EnableLog || Debuger.LogCb == null)
        return;
      Debuger.LogCb(message + "\r\n", color);
    }

    public static void Log(object message) => Debuger.Log(message, (Object) null);

    public static void Log(object message, Object context)
    {
      if (!Debuger.EnableLog)
        ;
    }

    public static void LogError(object message) => Debuger.LogError(message, (Object) null);

    public static void LogError(object message, Object context)
    {
      if (!Debuger.EnableLog)
        return;
      Debug.LogError(message, context);
    }

    public static void LogWarning(object message) => Debuger.LogWarning(message, (Object) null);

    public static void LogWarning(object message, Object context)
    {
      if (!Debuger.EnableLog)
        return;
      Debug.LogWarning(message, context);
    }

    public static void BeginLog()
    {
      Debuger.LogState = Debuger.EnableLog;
      Debuger.EnableLog = true;
    }

    public static void EndLog() => Debuger.EnableLog = Debuger.LogState;

    public delegate void LogCallback(string message, Color color);
  }
}
