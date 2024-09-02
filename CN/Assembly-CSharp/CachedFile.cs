﻿// Decompiled with JetBrains decompiler
// Type: CachedFile
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System.Collections.Generic;
using System.IO;

#nullable disable
public static class CachedFile
{
  private static HashSet<string> hash = new HashSet<string>();

  public static bool Exists(string path)
  {
    if (CachedFile.hash.Contains(path))
      return true;
    if (!File.Exists(path))
      return false;
    CachedFile.hash.Add(path);
    return true;
  }

  public static void Add(string path) => CachedFile.hash.Add(path);

  public static void Clear() => CachedFile.hash.Clear();
}
