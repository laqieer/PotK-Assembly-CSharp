// Decompiled with JetBrains decompiler
// Type: CriFsPlugin
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ECB926DA-6BA5-4E91-81B4-E3750A024FEA
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp-firstpass.dll

using System.Runtime.InteropServices;
using UnityEngine;

#nullable disable
public static class CriFsPlugin
{
  private static int initializationCount = 0;
  public static int defaultInstallBufferSize = 4194304;
  public static int installBufferSize = CriFsPlugin.defaultInstallBufferSize;

  public static bool isInitialized => CriFsPlugin.initializationCount > 0;

  public static void SetConfigParameters(
    int num_loaders,
    int num_binders,
    int num_installers,
    int argInstallBufferSize,
    int max_path,
    bool minimize_file_descriptor_usage)
  {
    CriFsPlugin.criFsUnity_SetConfigParameters(num_loaders, num_binders, num_installers, max_path, minimize_file_descriptor_usage);
    CriFsPlugin.installBufferSize = argInstallBufferSize;
  }

  public static void SetConfigAdditionalParameters_ANDROID(int device_read_bps)
  {
    CriFsPlugin.criFsUnity_SetConfigAdditionalParameters_ANDROID(device_read_bps);
  }

  public static void SetMemoryFileSystemThreadPriorityExperimentalAndroid(int prio)
  {
    CriFsPlugin.criFsUnity_SetMemoryFileSystemThreadPriority_ANDROID(prio);
  }

  public static void SetDataDecompressionThreadPriorityExperimentalAndroid(int prio)
  {
    CriFsPlugin.criFsUnity_SetDataDecompressionThreadPriority_ANDROID(prio);
  }

  public static void InitializeLibrary()
  {
    ++CriFsPlugin.initializationCount;
    if (CriFsPlugin.initializationCount != 1)
      return;
    if (!CriWareInitializer.IsInitialized())
      Debug.Log((object) "[CRIWARE] CriWareInitializer is not working. Initializes FileSystem by default parameters.");
    CriFsPlugin.criFsUnity_Initialize();
  }

  public static void FinalizeLibrary()
  {
    --CriFsPlugin.initializationCount;
    if (CriFsPlugin.initializationCount < 0)
    {
      Debug.LogError((object) "[CRIWARE] ERROR: FileSystem library is already finalized.");
    }
    else
    {
      if (CriFsPlugin.initializationCount != 0)
        return;
      CriFsServer.DestroyInstance();
      CriFsPlugin.installBufferSize = CriFsPlugin.defaultInstallBufferSize;
      CriFsPlugin.criFsUnity_Finalize();
    }
  }

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern void criFsUnity_SetConfigParameters(
    int num_loaders,
    int num_binders,
    int num_installers,
    int max_path,
    bool minimize_file_descriptor_usage);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern void criFsUnity_Initialize();

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern void criFsUnity_Finalize();

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  public static extern uint criFsUnity_GetAllocatedHeapSize();

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  public static extern uint criFsLoader_GetRetryCount();

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  public static extern int criFs_GetNumBinds(ref int cur, ref int max, ref int limit);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  public static extern int criFs_GetNumUsedLoaders(ref int cur, ref int max, ref int limit);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  public static extern int criFs_GetNumUsedInstallers(ref int cur, ref int max, ref int limit);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern void criFsUnity_SetConfigAdditionalParameters_ANDROID(int device_read_bps);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  public static extern void criFsUnity_SetMemoryFileSystemThreadPriority_ANDROID(int prio);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  public static extern void criFsUnity_SetDataDecompressionThreadPriority_ANDROID(int prio);
}
