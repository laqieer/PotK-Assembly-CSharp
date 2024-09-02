// Decompiled with JetBrains decompiler
// Type: DenaNGImageCache
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

#nullable disable
public class DenaNGImageCache
{
  public static bool HashShrink;

  public static string Md5(string url) => DenaNGImageCache.makePhpMd5(url);

  private static string makePhpMd5(string myString)
  {
    byte[] hash = new MD5CryptoServiceProvider().ComputeHash(Encoding.Default.GetBytes(myString));
    string str = string.Empty;
    foreach (byte num in hash)
      str = num >= (byte) 16 ? str + num.ToString("x") : str + "0" + num.ToString("x");
    return str;
  }

  public static void Cache(string path, byte[] bytes)
  {
    try
    {
      if (File.Exists(path))
        File.Delete(path);
      File.WriteAllBytes(path, bytes);
    }
    catch (Exception ex1)
    {
      try
      {
        File.Delete(path);
      }
      catch (Exception ex2)
      {
        Debug.LogException(ex2);
      }
      Debug.LogException(ex1);
    }
  }

  public static void CacheUpdate(string path)
  {
  }

  public static bool Exist(string path)
  {
    try
    {
      return File.Exists(path);
    }
    catch (Exception ex)
    {
      Debug.LogException(ex);
    }
    return false;
  }

  public static string CreateDir(string fd)
  {
    if (!Directory.Exists(fd))
    {
      try
      {
        Directory.CreateDirectory(fd);
      }
      catch (Exception ex)
      {
        Debug.LogException(ex);
      }
    }
    return fd;
  }

  public static string GetDir(string shortDir)
  {
    return Application.temporaryCachePath + "/" + shortDir + "/";
  }

  public static string GetNgCacheDir() => DenaNGImageCache.GetDir("denang/ngimg");

  public static string GetUri(string path) => new Uri(path).AbsoluteUri;

  [DebuggerHidden]
  public static IEnumerator ShrinkCache(string fulDir, int minCapacity, int maxCapacity)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DenaNGImageCache.\u003CShrinkCache\u003Ec__Iterator1()
    {
      fulDir = fulDir,
      maxCapacity = maxCapacity,
      minCapacity = minCapacity,
      \u003C\u0024\u003EfulDir = fulDir,
      \u003C\u0024\u003EmaxCapacity = maxCapacity,
      \u003C\u0024\u003EminCapacity = minCapacity
    };
  }
}
