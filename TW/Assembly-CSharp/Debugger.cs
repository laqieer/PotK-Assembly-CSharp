// Decompiled with JetBrains decompiler
// Type: Debugger
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public static class Debugger
{
  public static void Log(string str, params object[] args)
  {
    str = string.Format(str, args);
    Debug.Log((object) str);
  }

  public static void LogWarning(string str, params object[] args)
  {
    str = string.Format(str, args);
    Debug.LogWarning((object) str);
  }

  public static void LogError(string str, params object[] args)
  {
    str = string.Format(str, args);
    Debug.LogError((object) str);
  }
}
