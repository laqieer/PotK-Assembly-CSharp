// Decompiled with JetBrains decompiler
// Type: CriWare
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E910E095-517B-41AE-AAF8-B85E770EBAF1
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp-firstpass.dll

using System.IO;
using System.Runtime.InteropServices;
using UnityEngine;

#nullable disable
public class CriWare
{
  private const string scriptVersionString = "2.18.03";
  private const int scriptVersionNumber = 35127299;
  public const bool supportsCriFsInstaller = true;
  public const string pluginName = "cri_ware_unity";
  public const CallingConvention pluginCallingConvention = (CallingConvention) 0;
  private static GameObject _managerObject;

  public static string streamingAssetsPath
  {
    get => Application.platform == 11 ? string.Empty : Application.streamingAssetsPath;
  }

  public static string installTargetPath
  {
    get
    {
      return Application.platform == 8 ? Application.temporaryCachePath : Application.persistentDataPath;
    }
  }

  public static bool IsStreamingAssetsPath(string path)
  {
    return !Path.IsPathRooted(path) && path.IndexOf(':') < 0;
  }

  public static GameObject managerObject
  {
    get
    {
      if (Object.op_Equality((Object) CriWare._managerObject, (Object) null))
      {
        CriWare._managerObject = GameObject.Find("/CRIWARE");
        if (Object.op_Equality((Object) CriWare._managerObject, (Object) null))
          CriWare._managerObject = new GameObject("CRIWARE");
      }
      return CriWare._managerObject;
    }
  }

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  public static extern int criWareUnity_SetDecryptionKey(
    ulong key,
    string authentication_file,
    bool enable_atom_decryption,
    bool enable_mana_decryption);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  public static extern int criWareUnity_GetVersionNumber();

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  public static extern void criWareUnity_SetRenderingEventOffsetForMana(int offset);

  public static string GetScriptVersionString() => "2.18.03";

  public static int GetScriptVersionNumber() => 35127299;

  public static int GetBinaryVersionNumber() => CriWare.criWareUnity_GetVersionNumber();

  public static int GetRequiredBinaryVersionNumber() => 35127299;

  public static bool CheckBinaryVersionCompatibility()
  {
    if (CriWare.GetBinaryVersionNumber() == CriWare.GetRequiredBinaryVersionNumber())
      return true;
    Debug.LogError((object) "CRI runtime library is not compatible. Confirm the version number.");
    return false;
  }

  public static uint GetFsMemoryUsage() => CriFsPlugin.criFsUnity_GetAllocatedHeapSize();

  public static uint GetAtomMemoryUsage() => CriAtomPlugin.criAtomUnity_GetAllocatedHeapSize();

  public static uint GetManaMemoryUsage() => CriManaPlugin.criManaUnity_GetAllocatedHeapSize();

  public static CriWare.CpuUsage GetAtomCpuUsage() => CriAtomPlugin.GetCpuUsage();

  public struct CpuUsage
  {
    public float last;
    public float average;
    public float peak;
  }
}
