// Decompiled with JetBrains decompiler
// Type: DenaLib.PathManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System.IO;
using UnityEngine;

#nullable disable
namespace DenaLib
{
  public class PathManager
  {
    public static string AssetBaseDir = string.Empty;
    public static string UpdateBaseDir = string.Empty;
    public static string HotUpdateDir = "/HotUpdate";
    public static string HotUpdateDataDir = "/HotUpdate/Data";
    public static string HotUpdatePackageDir = "/HotUpdate/Package";
    public static string StreamingDir = "/Streaming";
    public static string BundleExt = ".unity3d";

    public static void Init()
    {
      PathManager.AssetBaseDir = Application.dataPath;
      PathManager.UpdateBaseDir = Application.persistentDataPath;
    }

    public static bool IsReady()
    {
      return Application.platform != 11 || Directory.Exists(PathManager.UpdateBaseDir);
    }

    public static EResLocation GetResourcePath(string resourceName, out string path)
    {
      path = string.Format("{0}{1}/{2}.unity3d", (object) PathManager.UpdateBaseDir, (object) PathManager.HotUpdateDataDir, (object) resourceName);
      if (File.Exists(path))
        return EResLocation.EResHotupdate;
      path = string.Format("{0}{1}/{2}.unity3d", (object) PathManager.UpdateBaseDir, (object) PathManager.StreamingDir, (object) resourceName);
      if (File.Exists(path))
        return EResLocation.EResStreaming;
      path = resourceName;
      return EResLocation.EResLocal;
    }
  }
}
