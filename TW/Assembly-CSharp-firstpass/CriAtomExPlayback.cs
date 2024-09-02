// Decompiled with JetBrains decompiler
// Type: CriAtomExPlayback
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ECB926DA-6BA5-4E91-81B4-E3750A024FEA
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp-firstpass.dll

using System.Runtime.InteropServices;

#nullable disable
public struct CriAtomExPlayback
{
  public CriAtomExPlayback(uint id) => this.id = id;

  public void Stop(bool ignoresReleaseTime)
  {
    if (!ignoresReleaseTime)
      CriAtomExPlayback.criAtomExPlayback_Stop(this.id);
    else
      CriAtomExPlayback.criAtomExPlayback_StopWithoutReleaseTime(this.id);
  }

  public void Pause() => CriAtomExPlayback.criAtomExPlayback_Pause(this.id, true);

  public void Resume(CriAtomEx.ResumeMode mode)
  {
    CriAtomExPlayback.criAtomExPlayback_Resume(this.id, mode);
  }

  public bool IsPaused() => CriAtomExPlayback.criAtomExPlayback_IsPaused(this.id);

  public bool GetFormatInfo(out CriAtomEx.FormatInfo info)
  {
    return CriAtomExPlayback.criAtomExPlayback_GetFormatInfo(this.id, out info);
  }

  public CriAtomExPlayback.Status GetStatus()
  {
    return CriAtomExPlayback.criAtomExPlayback_GetStatus(this.id);
  }

  public long GetTime() => CriAtomExPlayback.criAtomExPlayback_GetTime(this.id);

  public long GetTimeSyncedWithAudio()
  {
    return CriAtomExPlayback.criAtomExPlayback_GetTimeSyncedWithAudio(this.id);
  }

  public bool GetNumPlayedSamples(out long numSamples, out int samplingRate)
  {
    return CriAtomExPlayback.criAtomExPlayback_GetNumPlayedSamples(this.id, out numSamples, out samplingRate);
  }

  public long GetSequencePosition()
  {
    return CriAtomExPlayback.criAtomExPlayback_GetSequencePosition(this.id);
  }

  public int GetCurrentBlockIndex()
  {
    return CriAtomExPlayback.criAtomExPlayback_GetCurrentBlockIndex(this.id);
  }

  public void SetNextBlockIndex(int index)
  {
    CriAtomExPlayback.criAtomExPlayback_SetNextBlockIndex(this.id, index);
  }

  public uint id { get; private set; }

  public CriAtomExPlayback.Status status => this.GetStatus();

  public long time => this.GetTime();

  public long timeSyncedWithAudio => this.GetTimeSyncedWithAudio();

  public void Stop() => CriAtomExPlayback.criAtomExPlayback_Stop(this.id);

  public void StopWithoutReleaseTime()
  {
    CriAtomExPlayback.criAtomExPlayback_StopWithoutReleaseTime(this.id);
  }

  public void Pause(bool sw) => CriAtomExPlayback.criAtomExPlayback_Pause(this.id, sw);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern void criAtomExPlayback_Stop(uint id);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern void criAtomExPlayback_StopWithoutReleaseTime(uint id);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern void criAtomExPlayback_Pause(uint id, bool sw);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern void criAtomExPlayback_Resume(uint id, CriAtomEx.ResumeMode mode);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern bool criAtomExPlayback_IsPaused(uint id);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern CriAtomExPlayback.Status criAtomExPlayback_GetStatus(uint id);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern bool criAtomExPlayback_GetFormatInfo(uint id, out CriAtomEx.FormatInfo info);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern long criAtomExPlayback_GetTime(uint id);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern long criAtomExPlayback_GetTimeSyncedWithAudio(uint id);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern bool criAtomExPlayback_GetNumPlayedSamples(
    uint id,
    out long num_samples,
    out int sampling_rate);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern long criAtomExPlayback_GetSequencePosition(uint id);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern void criAtomExPlayback_SetNextBlockIndex(uint id, int index);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern int criAtomExPlayback_GetCurrentBlockIndex(uint id);

  public enum Status
  {
    Prep = 1,
    Playing = 2,
    Removed = 3,
  }
}
