// Decompiled with JetBrains decompiler
// Type: CriAtomExAsr
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ECB926DA-6BA5-4E91-81B4-E3750A024FEA
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp-firstpass.dll

using System;
using System.Runtime.InteropServices;

#nullable disable
public class CriAtomExAsr
{
  public static void AttachBusAnalyzer(int interval, int peakHoldTime)
  {
    CriAtomExAsr.BusAnalyzerConfig config;
    config.interval = 50;
    config.peakHoldTime = 1000;
    for (int bus_no = 0; bus_no < 8; ++bus_no)
      CriAtomExAsr.criAtomExAsr_AttachBusAnalyzer(bus_no, ref config);
  }

  public static void DetachBusAnalyzer()
  {
    for (int bus_no = 0; bus_no < 8; ++bus_no)
      CriAtomExAsr.criAtomExAsr_DetachBusAnalyzer(bus_no);
  }

  public static void GetBusAnalyzerInfo(int bus, out CriAtomExAsr.BusAnalyzerInfo info)
  {
    using (CriStructMemory<CriAtomExAsr.BusAnalyzerInfo> criStructMemory = new CriStructMemory<CriAtomExAsr.BusAnalyzerInfo>())
    {
      CriAtomExAsr.criAtomExAsr_GetBusAnalyzerInfo(bus, criStructMemory.ptr);
      info = new CriAtomExAsr.BusAnalyzerInfo(criStructMemory.bytes);
    }
  }

  public static void SetBusVolume(int bus, float volume)
  {
    CriAtomExAsr.criAtomExAsr_SetBusVolume(bus, volume);
  }

  public static void SetBusSendLevel(int bus, int sendTo, float level)
  {
    CriAtomExAsr.criAtomExAsr_SetBusSendLevel(bus, sendTo, level);
  }

  public static void SetBusMatrix(int bus, int inputChannels, int outputChannels, float[] matrix)
  {
    CriAtomExAsr.criAtomExAsr_SetBusMatrix(bus, inputChannels, outputChannels, matrix);
  }

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern void criAtomExAsr_AttachBusAnalyzer(
    int bus_no,
    ref CriAtomExAsr.BusAnalyzerConfig config);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern void criAtomExAsr_DetachBusAnalyzer(int bus_no);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern void criAtomExAsr_GetBusAnalyzerInfo(int bus_no, IntPtr info);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern void criAtomExAsr_SetBusVolume(int bus_no, float volume);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern void criAtomExAsr_SetBusSendLevel(int bus_no, int sendto_no, float level);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern void criAtomExAsr_SetBusMatrix(
    int bus_no,
    int input_channels,
    int output_channels,
    [MarshalAs(UnmanagedType.LPArray)] float[] matrix);

  private struct BusAnalyzerConfig
  {
    public int interval;
    public int peakHoldTime;
  }

  public struct BusAnalyzerInfo
  {
    public int numChannels;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
    public float[] rmsLevels;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
    public float[] peakLevels;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
    public float[] peakHoldLevels;

    public BusAnalyzerInfo(byte[] data)
    {
      if (data != null)
      {
        this.numChannels = BitConverter.ToInt32(data, 0);
        this.rmsLevels = new float[8];
        for (int index = 0; index < 8; ++index)
          this.rmsLevels[index] = BitConverter.ToSingle(data, 4 + index * 4);
        this.peakLevels = new float[8];
        for (int index = 0; index < 8; ++index)
          this.peakLevels[index] = BitConverter.ToSingle(data, 36 + index * 4);
        this.peakHoldLevels = new float[8];
        for (int index = 0; index < 8; ++index)
          this.peakHoldLevels[index] = BitConverter.ToSingle(data, 68 + index * 4);
      }
      else
      {
        this.numChannels = 0;
        this.rmsLevels = new float[8];
        this.peakLevels = new float[8];
        this.peakHoldLevels = new float[8];
      }
    }
  }
}
