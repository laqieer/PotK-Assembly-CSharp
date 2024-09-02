// Decompiled with JetBrains decompiler
// Type: BMUtility
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

#nullable disable
public class BMUtility
{
  public static void Swap<T>(ref T a, ref T b)
  {
    T obj = a;
    a = b;
    b = obj;
  }

  public static string InterpretPath(string origPath, BuildPlatform platform)
  {
    foreach (Match match in Regex.Matches(origPath, "\\$\\((\\w+)\\)"))
    {
      string varString = match.Groups[1].Value;
      origPath = origPath.Replace("$(" + varString + ")", BMUtility.EnvVarToString(varString, platform));
    }
    return origPath;
  }

  private static string EnvVarToString(string varString, BuildPlatform platform)
  {
    string key = varString;
    if (key != null)
    {
      // ISSUE: reference to a compiler-generated field
      if (BMUtility.\u003C\u003Ef__switch\u0024map0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        BMUtility.\u003C\u003Ef__switch\u0024map0 = new Dictionary<string, int>(5)
        {
          {
            "DataPath",
            0
          },
          {
            "PersistentDataPath",
            1
          },
          {
            "StreamingAssetsPath",
            2
          },
          {
            "Platform",
            3
          },
          {
            "Version",
            4
          }
        };
      }
      int num;
      // ISSUE: reference to a compiler-generated field
      if (BMUtility.\u003C\u003Ef__switch\u0024map0.TryGetValue(key, out num))
      {
        switch (num)
        {
          case 0:
            return Application.dataPath;
          case 1:
            return Application.persistentDataPath;
          case 2:
            return Application.streamingAssetsPath;
          case 3:
            return platform.ToString().ToLower();
          case 4:
            return Application.version;
        }
      }
    }
    Debug.LogWarning((object) ("Cannot resolve enviroment var " + varString));
    return string.Empty;
  }
}
