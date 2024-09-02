// Decompiled with JetBrains decompiler
// Type: Debug
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

public static class Debug
{
  public static readonly bool isDebugBuild;

  public static void Log(object o)
  {
  }

  public static void LogFormat(UnityEngine.Object context, string format, params object[] args)
  {
  }

  public static void LogFormat(string format, params object[] args)
  {
  }

  public static void LogWarning(params object[] o)
  {
  }

  public static void LogWarningFormat(string format, params object[] args)
  {
  }

  public static void LogWarningFormat(UnityEngine.Object context, string format, params object[] args)
  {
  }

  public static void DrawLine(params object[] o)
  {
  }

  public static void LogError(object o) => UnityEngine.Debug.LogError(o);

  public static void LogError(object o, UnityEngine.Object context) => UnityEngine.Debug.LogError(o, context);

  public static void LogErrorFormat(string format, params object[] args) => UnityEngine.Debug.LogErrorFormat(format, args);

  public static void LogErrorFormat(UnityEngine.Object context, string format, params object[] args) => UnityEngine.Debug.LogErrorFormat(context, format, args);

  public static void LogException(Exception ex) => UnityEngine.Debug.LogException(ex);

  public static void LogException(Exception ex, UnityEngine.Object context) => UnityEngine.Debug.LogException(ex, context);
}
