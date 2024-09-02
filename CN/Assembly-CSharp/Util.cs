// Decompiled with JetBrains decompiler
// Type: Util
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using System.IO;
using UnityEngine;

#nullable disable
public class Util
{
  public static string LuaPath(string name)
  {
    if (name.ToLower().EndsWith(".lua"))
    {
      int length = name.LastIndexOf('.');
      name = name.Substring(0, length);
    }
    name = name.Replace('.', '/');
    return "uLua/" + name + ".lua";
  }

  public static void Log(string str) => Debug.Log((object) str);

  public static void LogWarning(string str) => Debug.LogWarning((object) str);

  public static void LogError(string str) => Debug.LogError((object) str);

  public static void ClearMemory()
  {
    GC.Collect();
    Resources.UnloadUnusedAssets();
    LuaScriptMgr instance = LuaScriptMgr.Instance;
    if (instance == null || instance.lua == null)
      return;
    instance.LuaGC();
  }

  private static int CheckRuntimeFile()
  {
    if (!Application.isEditor)
      return 0;
    string path = AppConst.uLuaPath + "/Source/LuaWrap/";
    return !Directory.Exists(path) || Directory.GetFiles(path).Length == 0 ? -2 : 0;
  }

  public static bool CheckEnvironment() => true;
}
