﻿// Decompiled with JetBrains decompiler
// Type: CriAtomExLatencyEstimator
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E910E095-517B-41AE-AAF8-B85E770EBAF1
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp-firstpass.dll

using System.Runtime.InteropServices;

#nullable disable
public static class CriAtomExLatencyEstimator
{
  public static void InitializeModule()
  {
    CriAtomExLatencyEstimator.criAtomLatencyEstimator_Initialize_ANDROID();
  }

  public static void FinalizeModule()
  {
    CriAtomExLatencyEstimator.criAtomLatencyEstimator_Finalize_ANDROID();
  }

  public static CriAtomExLatencyEstimator.EstimatorInfo GetCurrentInfo()
  {
    return CriAtomExLatencyEstimator.criAtomLatencyEstimator_GetCurrentInfo_ANDROID();
  }

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern void criAtomLatencyEstimator_Initialize_ANDROID();

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern void criAtomLatencyEstimator_Finalize_ANDROID();

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern CriAtomExLatencyEstimator.EstimatorInfo criAtomLatencyEstimator_GetCurrentInfo_ANDROID();

  public enum Status
  {
    Stop,
    Processing,
    Done,
    Error,
  }

  public struct EstimatorInfo
  {
    public CriAtomExLatencyEstimator.Status status;
    public uint estimated_latency;
  }
}
