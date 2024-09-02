// Decompiled with JetBrains decompiler
// Type: CriAtomExVoicePool
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E910E095-517B-41AE-AAF8-B85E770EBAF1
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp-firstpass.dll

using System;
using System.Runtime.InteropServices;

#nullable disable
public class CriAtomExVoicePool
{
  public const int StandardMemoryAsrVoicePoolId = 0;
  public const int StandardStreamingAsrVoicePoolId = 1;
  public const int StandardMemoryNsrVoicePoolId = 2;
  public const int StandardStreamingNsrVoicePoolId = 3;

  public static CriAtomExVoicePool.UsedVoicesInfo GetNumUsedVoices(
    CriAtomExVoicePool.VoicePoolId voicePoolId)
  {
    CriAtomExVoicePool.UsedVoicesInfo numUsedVoices;
    CriAtomExVoicePool.criAtomUnity_GetNumUsedVoices((int) voicePoolId, out numUsedVoices.numUsedVoices, out numUsedVoices.numPoolVoices);
    return numUsedVoices;
  }

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern void criAtomUnity_GetNumUsedVoices(
    int voice_pool_id,
    out int num_used_voices,
    out int num_pool_voices);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  public static extern void criAtomExVoicePool_Free(IntPtr pool);

  public enum VoicePoolId
  {
    StandardMemory,
    StandardStreaming,
    LowLatencyMemory,
    LowLatencyStreaming,
    HcaMxMemory,
    HcaMxStreaming,
  }

  public struct UsedVoicesInfo
  {
    public int numUsedVoices;
    public int numPoolVoices;
  }
}
