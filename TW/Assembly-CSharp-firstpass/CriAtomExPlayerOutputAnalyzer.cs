// Decompiled with JetBrains decompiler
// Type: CriAtomExPlayerOutputAnalyzer
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ECB926DA-6BA5-4E91-81B4-E3750A024FEA
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp-firstpass.dll

using System;
using System.Runtime.InteropServices;
using UnityEngine;

#nullable disable
public class CriAtomExPlayerOutputAnalyzer : IDisposable
{
  private IntPtr handle = IntPtr.Zero;
  private CriAtomExPlayer player;
  private int numBands = 8;

  public CriAtomExPlayerOutputAnalyzer(
    CriAtomExPlayerOutputAnalyzer.Type[] types,
    CriAtomExPlayerOutputAnalyzer.Config[] configs = null)
  {
    this.handle = CriAtomExPlayerOutputAnalyzer.criAtomExPlayerOutputAnalyzer_Create(types.Length, types, configs);
    if (this.handle == IntPtr.Zero)
      throw new Exception("criAtomExPlayerOutputAnalyzer_Create() failed.");
    if (configs == null)
      return;
    this.numBands = configs[0].num_spectrum_analyzer_bands;
  }

  public IntPtr nativeHandle => this.handle;

  public void Dispose()
  {
    if (this.handle == IntPtr.Zero)
      return;
    this.DetachExPlayer();
    CriAtomExPlayerOutputAnalyzer.criAtomExPlayerOutputAnalyzer_Destroy(this.handle);
    GC.SuppressFinalize((object) this);
  }

  public bool AttachExPlayer(CriAtomExPlayer player)
  {
    if (player == null || this.handle == IntPtr.Zero)
      return false;
    this.DetachExPlayer();
    if (player.GetStatus() != CriAtomExPlayer.Status.Stop)
      return false;
    CriAtomExPlayerOutputAnalyzer.criAtomExPlayerOutputAnalyzer_AttachExPlayer(this.handle, player.nativeHandle);
    this.player = player;
    return true;
  }

  public void DetachExPlayer()
  {
    if (this.player == null || this.handle == IntPtr.Zero)
      return;
    if (this.player.GetStatus() != CriAtomExPlayer.Status.Stop)
    {
      Debug.LogWarning((object) "[CRIWARE] Warning: CriAtomExPlayer is forced to stop for detaching CriAtomExPlayerOutputAnalyzer.");
      this.player.StopWithoutReleaseTime();
    }
    CriAtomExPlayerOutputAnalyzer.criAtomExPlayerOutputAnalyzer_DetachExPlayer(this.handle, this.player.nativeHandle);
    this.player = (CriAtomExPlayer) null;
  }

  public float GetRms(int channel)
  {
    return this.player == null || this.handle == IntPtr.Zero || this.player.GetStatus() != CriAtomExPlayer.Status.Playing && this.player.GetStatus() != CriAtomExPlayer.Status.Prep ? 0.0f : CriAtomExPlayerOutputAnalyzer.criAtomExPlayerOutputAnalyzer_GetRms(this.handle, channel);
  }

  public void GetSpectrumLevels(ref float[] levels)
  {
    if (this.player == null || this.handle == IntPtr.Zero)
      return;
    if (levels == null || levels.Length < this.numBands)
      levels = new float[this.numBands];
    Marshal.Copy(CriAtomExPlayerOutputAnalyzer.criAtomExPlayerOutputAnalyzer_GetSpectrumLevels(this.handle), levels, 0, this.numBands);
  }

  ~CriAtomExPlayerOutputAnalyzer() => this.Dispose();

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern IntPtr criAtomExPlayerOutputAnalyzer_Create(
    int numTypes,
    CriAtomExPlayerOutputAnalyzer.Type[] types,
    CriAtomExPlayerOutputAnalyzer.Config[] configs);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern IntPtr criAtomExPlayerOutputAnalyzer_Destroy(IntPtr analyzer);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern void criAtomExPlayerOutputAnalyzer_AttachExPlayer(
    IntPtr analyzer,
    IntPtr player);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern void criAtomExPlayerOutputAnalyzer_DetachExPlayer(
    IntPtr analyzer,
    IntPtr player);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern float criAtomExPlayerOutputAnalyzer_GetRms(IntPtr analyzer, int channel);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern IntPtr criAtomExPlayerOutputAnalyzer_GetSpectrumLevels(IntPtr analyzer);

  public enum Type
  {
    LevelMeter,
    SpectrumAnalyzer,
  }

  public struct Config
  {
    public int num_spectrum_analyzer_bands;

    public Config(int num_spectrum_analyzer_bands = 8)
    {
      this.num_spectrum_analyzer_bands = num_spectrum_analyzer_bands;
    }
  }
}
