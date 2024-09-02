// Decompiled with JetBrains decompiler
// Type: Debugger
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
