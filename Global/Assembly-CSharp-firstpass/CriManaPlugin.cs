// Decompiled with JetBrains decompiler
// Type: CriManaPlugin
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E910E095-517B-41AE-AAF8-B85E770EBAF1
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp-firstpass.dll

using CriMana.Detail;
using System.Runtime.InteropServices;
using UnityEngine;

#nullable disable
public class CriManaPlugin
{
  private static int initializationCount;
  public static string cuePointFormatDelimiter;
  private static bool enabledMultithreadedRendering;
  public static int renderingEventOffset = 50000;

  public static bool isInitialized => CriManaPlugin.initializationCount > 0;

  public static bool isMultithreadedRenderingEnabled => CriManaPlugin.enabledMultithreadedRendering;

  public static void SetConfigParameters(
    bool graphicsMultiThreaded,
    int num_decoders,
    int max_num_of_entries)
  {
    CriManaPlugin.GraphicsApi graphics_api = CriManaPlugin.GraphicsApi.Unknown;
    CriManaPlugin.enabledMultithreadedRendering = graphicsMultiThreaded;
    CriWare.criWareUnity_SetRenderingEventOffsetForMana(CriManaPlugin.renderingEventOffset);
    CriManaPlugin.criManaUnity_SetConfigParameters((int) graphics_api, CriManaPlugin.enabledMultithreadedRendering, num_decoders, max_num_of_entries);
  }

  public static void SetConfigAdditonalParameters_VITA(
    bool use_h264_playback,
    int width,
    int height)
  {
  }

  public static void InitializeLibrary()
  {
    ++CriManaPlugin.initializationCount;
    if (CriManaPlugin.initializationCount != 1)
      return;
    if (!CriWareInitializer.IsInitialized())
      Debug.Log((object) "[CRIWARE] CriWareInitializer is not working. Initializes Mana by default parameters.");
    CriFsPlugin.InitializeLibrary();
    CriAtomPlugin.InitializeLibrary();
    CriManaPlugin.criManaUnity_Initialize();
    AutoResisterRendererResourceFactories.InvokeAutoRegister();
    CriManaPlugin.cuePointFormatDelimiter = "\t";
  }

  public static void FinalizeLibrary()
  {
    --CriManaPlugin.initializationCount;
    if (CriManaPlugin.initializationCount < 0)
    {
      Debug.LogError((object) "[CRIWARE] ERROR: Mana library is already finalized.");
    }
    else
    {
      if (CriManaPlugin.initializationCount != 0)
        return;
      CriManaPlugin.criManaUnity_Finalize();
      RendererResourceFactory.DisposeAllFactories();
      CriAtomPlugin.FinalizeLibrary();
      CriFsPlugin.FinalizeLibrary();
    }
  }

  public static void SetCuePointFormatDelimiter(string delimiter)
  {
    CriManaPlugin.cuePointFormatDelimiter = delimiter;
  }

  public static void SetDecodeThreadPriorityAndroidExperimental(int prio)
  {
    CriManaPlugin.criManaUnity_SetDecodeThreadPriority_ANDROID(prio);
  }

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern void criManaUnity_SetConfigParameters(
    int graphics_api,
    bool graphics_multi_threaded,
    int num_decoders,
    int num_of_max_entries);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern void criManaUnity_Initialize();

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern void criManaUnity_Finalize();

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  public static extern uint criManaUnity_GetAllocatedHeapSize();

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  public static extern void criManaUnity_SetDecodeThreadPriority_ANDROID(int prio);

  private enum GraphicsApi
  {
    Unknown,
    OpenGLES_2_0,
    OpenGLES_3_0,
    Metal,
  }
}
