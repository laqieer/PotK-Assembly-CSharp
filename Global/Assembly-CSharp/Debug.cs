// Decompiled with JetBrains decompiler
// Type: Debug
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
public static class Debug
{
  public static readonly bool isDebugBuild;

  public static void Log(object o)
  {
  }

  public static void LogWarning(params object[] o)
  {
  }

  public static void DrawLine(params object[] o)
  {
  }

  public static void LogError(object o) => Debug.LogError(o);

  public static void LogError(object o, Object context) => Debug.LogError(o, context);

  public static void LogException(Exception ex) => Debug.LogException(ex);

  public static void LogException(Exception ex, Object context) => Debug.LogException(ex, context);
}
