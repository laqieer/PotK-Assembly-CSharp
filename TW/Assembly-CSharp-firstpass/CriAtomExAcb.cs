// Decompiled with JetBrains decompiler
// Type: CriAtomExAcb
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ECB926DA-6BA5-4E91-81B4-E3750A024FEA
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp-firstpass.dll

using System;
using System.Runtime.InteropServices;

#nullable disable
public class CriAtomExAcb : IDisposable
{
  private IntPtr handle = IntPtr.Zero;

  private CriAtomExAcb(IntPtr handle) => this.handle = handle;

  public IntPtr nativeHandle => this.handle;

  public static CriAtomExAcb LoadAcbFile(CriFsBinder binder, string acbPath, string awbPath)
  {
    IntPtr num = binder == null ? IntPtr.Zero : binder.nativeHandle;
    IntPtr handle = CriAtomExAcb.criAtomExAcb_LoadAcbFile(num, acbPath, num, awbPath, IntPtr.Zero, 0);
    return handle == IntPtr.Zero ? (CriAtomExAcb) null : new CriAtomExAcb(handle);
  }

  public static CriAtomExAcb LoadAcbData(byte[] acbData, CriFsBinder awbBinder, string awbPath)
  {
    IntPtr awb_binder = awbBinder == null ? IntPtr.Zero : awbBinder.nativeHandle;
    IntPtr handle = CriAtomExAcb.criAtomExAcb_LoadAcbData(acbData, acbData.Length, awb_binder, awbPath, IntPtr.Zero, 0);
    return handle == IntPtr.Zero ? (CriAtomExAcb) null : new CriAtomExAcb(handle);
  }

  public void Dispose()
  {
    CriAtomExAcb.criAtomExAcb_Release(this.handle);
    GC.SuppressFinalize((object) this);
  }

  public bool Exists(string cueName) => CriAtomExAcb.criAtomExAcb_ExistsName(this.handle, cueName);

  public bool Exists(int cueId) => CriAtomExAcb.criAtomExAcb_ExistsId(this.handle, cueId);

  public bool GetCueInfo(string cueName, out CriAtomEx.CueInfo info)
  {
    using (CriStructMemory<CriAtomEx.CueInfo> criStructMemory = new CriStructMemory<CriAtomEx.CueInfo>())
    {
      bool cueInfoByName = CriAtomExAcb.criAtomExAcb_GetCueInfoByName(this.handle, cueName, criStructMemory.ptr);
      info = new CriAtomEx.CueInfo(criStructMemory.bytes, 0);
      return cueInfoByName;
    }
  }

  public bool GetCueInfo(int cueId, out CriAtomEx.CueInfo info)
  {
    using (CriStructMemory<CriAtomEx.CueInfo> criStructMemory = new CriStructMemory<CriAtomEx.CueInfo>())
    {
      bool cueInfoById = CriAtomExAcb.criAtomExAcb_GetCueInfoById(this.handle, cueId, criStructMemory.ptr);
      info = new CriAtomEx.CueInfo(criStructMemory.bytes, 0);
      return cueInfoById;
    }
  }

  public bool GetCueInfoByIndex(int index, out CriAtomEx.CueInfo info)
  {
    using (CriStructMemory<CriAtomEx.CueInfo> criStructMemory = new CriStructMemory<CriAtomEx.CueInfo>())
    {
      bool cueInfoByIndex = CriAtomExAcb.criAtomExAcb_GetCueInfoByIndex(this.handle, index, criStructMemory.ptr);
      info = new CriAtomEx.CueInfo(criStructMemory.bytes, 0);
      return cueInfoByIndex;
    }
  }

  public CriAtomEx.CueInfo[] GetCueInfoList()
  {
    int numCues = CriAtomExAcb.criAtomExAcb_GetNumCues(this.handle);
    CriAtomEx.CueInfo[] cueInfoList = new CriAtomEx.CueInfo[numCues];
    for (int index = 0; index < numCues; ++index)
      this.GetCueInfoByIndex(index, out cueInfoList[index]);
    return cueInfoList;
  }

  public bool GetWaveFormInfo(string cueName, out CriAtomEx.WaveformInfo info)
  {
    using (CriStructMemory<CriAtomEx.WaveformInfo> criStructMemory = new CriStructMemory<CriAtomEx.WaveformInfo>())
    {
      bool waveformInfoByName = CriAtomExAcb.criAtomExAcb_GetWaveformInfoByName(this.handle, cueName, criStructMemory.ptr);
      info = new CriAtomEx.WaveformInfo(criStructMemory.bytes, 0);
      return waveformInfoByName;
    }
  }

  public bool GetWaveFormInfo(int cueId, out CriAtomEx.WaveformInfo info)
  {
    using (CriStructMemory<CriAtomEx.WaveformInfo> criStructMemory = new CriStructMemory<CriAtomEx.WaveformInfo>())
    {
      bool waveformInfoById = CriAtomExAcb.criAtomExAcb_GetWaveformInfoById(this.handle, cueId, criStructMemory.ptr);
      info = new CriAtomEx.WaveformInfo(criStructMemory.bytes, 0);
      return waveformInfoById;
    }
  }

  public int GetNumCuePlaying(string name)
  {
    return CriAtomExAcb.criAtomExAcb_GetNumCuePlayingCountByName(this.handle, name);
  }

  public int GetNumCuePlaying(int id)
  {
    return CriAtomExAcb.criAtomExAcb_GetNumCuePlayingCountById(this.handle, id);
  }

  public int GetBlockIndex(string cueName, string blockName)
  {
    return CriAtomExAcb.criAtomExAcb_GetBlockIndexByName(this.handle, cueName, blockName);
  }

  public int GetBlockIndex(int cueId, string blockName)
  {
    return CriAtomExAcb.criAtomExAcb_GetBlockIndexById(this.handle, cueId, blockName);
  }

  public int GetNumUsableAisacControls(string cueName)
  {
    return CriAtomExAcb.criAtomExAcb_GetNumUsableAisacControlsByName(this.handle, cueName);
  }

  public int GetNumUsableAisacControls(int cueId)
  {
    return CriAtomExAcb.criAtomExAcb_GetNumUsableAisacControlsById(this.handle, cueId);
  }

  public bool GetUsableAisacControl(string cueName, int index, out CriAtomEx.AisacControlInfo info)
  {
    using (CriStructMemory<CriAtomEx.AisacControlInfo> criStructMemory = new CriStructMemory<CriAtomEx.AisacControlInfo>())
    {
      bool aisacControlByName = CriAtomExAcb.criAtomExAcb_GetUsableAisacControlByName(this.handle, cueName, (ushort) index, criStructMemory.ptr);
      info = new CriAtomEx.AisacControlInfo(criStructMemory.bytes, 0);
      return aisacControlByName;
    }
  }

  public bool GetUsableAisacControl(int cueId, int index, out CriAtomEx.AisacControlInfo info)
  {
    using (CriStructMemory<CriAtomEx.AisacControlInfo> criStructMemory = new CriStructMemory<CriAtomEx.AisacControlInfo>())
    {
      bool aisacControlById = CriAtomExAcb.criAtomExAcb_GetUsableAisacControlById(this.handle, cueId, (ushort) index, criStructMemory.ptr);
      info = new CriAtomEx.AisacControlInfo(criStructMemory.bytes, 0);
      return aisacControlById;
    }
  }

  public CriAtomEx.AisacControlInfo[] GetUsableAisacControlList(string cueName)
  {
    int usableAisacControls = this.GetNumUsableAisacControls(cueName);
    CriAtomEx.AisacControlInfo[] aisacControlList = new CriAtomEx.AisacControlInfo[usableAisacControls];
    for (int index = 0; index < usableAisacControls; ++index)
      this.GetUsableAisacControl(cueName, index, out aisacControlList[index]);
    return aisacControlList;
  }

  public CriAtomEx.AisacControlInfo[] GetUsableAisacControlList(int cueId)
  {
    int usableAisacControls = this.GetNumUsableAisacControls(cueId);
    CriAtomEx.AisacControlInfo[] aisacControlList = new CriAtomEx.AisacControlInfo[usableAisacControls];
    for (int index = 0; index < usableAisacControls; ++index)
      this.GetUsableAisacControl(cueId, index, out aisacControlList[index]);
    return aisacControlList;
  }

  public void ResetCueTypeState(string cueName)
  {
    CriAtomExAcb.criAtomExAcb_ResetCueTypeStateByName(this.handle, cueName);
  }

  public void ResetCueTypeState(int cueId)
  {
    CriAtomExAcb.criAtomExAcb_ResetCueTypeStateById(this.handle, cueId);
  }

  public void AttachAwbFile(CriFsBinder awb_binder, string awb_path, string awb_name)
  {
    CriAtomExAcb.criAtomExAcb_AttachAwbFile(this.handle, awb_binder == null ? IntPtr.Zero : awb_binder.nativeHandle, awb_path, awb_name, IntPtr.Zero, 0);
  }

  public void DetachAwbFile(string awb_name)
  {
    CriAtomExAcb.criAtomExAcb_DetachAwbFile(this.handle, awb_name);
  }

  ~CriAtomExAcb() => this.Dispose();

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern IntPtr criAtomExAcb_LoadAcbFile(
    IntPtr acb_binder,
    string acb_path,
    IntPtr awb_binder,
    string awb_path,
    IntPtr work,
    int work_size);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern IntPtr criAtomExAcb_LoadAcbData(
    byte[] acb_data,
    int acb_data_size,
    IntPtr awb_binder,
    string awb_path,
    IntPtr work,
    int work_size);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern void criAtomExAcb_Release(IntPtr acb_hn);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern int criAtomExAcb_GetNumCues(IntPtr acb_hn);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern bool criAtomExAcb_ExistsId(IntPtr acb_hn, int id);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern bool criAtomExAcb_ExistsName(IntPtr acb_hn, string name);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern int criAtomExAcb_GetNumUsableAisacControlsById(IntPtr acb_hn, int id);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern int criAtomExAcb_GetNumUsableAisacControlsByName(IntPtr acb_hn, string name);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern bool criAtomExAcb_GetUsableAisacControlById(
    IntPtr acb_hn,
    int id,
    ushort index,
    IntPtr info);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern bool criAtomExAcb_GetUsableAisacControlByName(
    IntPtr acb_hn,
    string name,
    ushort index,
    IntPtr info);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern bool criAtomExAcb_GetWaveformInfoById(
    IntPtr acb_hn,
    int id,
    IntPtr waveform_info);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern bool criAtomExAcb_GetWaveformInfoByName(
    IntPtr acb_hn,
    string name,
    IntPtr waveform_info);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern bool criAtomExAcb_GetCueInfoByName(IntPtr acb_hn, string name, IntPtr info);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern bool criAtomExAcb_GetCueInfoById(IntPtr acb_hn, int id, IntPtr info);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern bool criAtomExAcb_GetCueInfoByIndex(IntPtr acb_hn, int index, IntPtr info);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern int criAtomExAcb_GetNumCuePlayingCountByName(IntPtr acb_hn, string name);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern int criAtomExAcb_GetNumCuePlayingCountById(IntPtr acb_hn, int id);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern int criAtomExAcb_GetBlockIndexById(
    IntPtr acb_hn,
    int id,
    string block_name);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern int criAtomExAcb_GetBlockIndexByName(
    IntPtr acb_hn,
    string name,
    string block_name);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern void criAtomExAcb_ResetCueTypeStateByName(IntPtr acb_hn, string name);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern void criAtomExAcb_ResetCueTypeStateById(IntPtr acb_hn, int id);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern void criAtomExAcb_AttachAwbFile(
    IntPtr acb_hn,
    IntPtr awb_binder,
    string awb_path,
    string awb_name,
    IntPtr work,
    int work_size);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern void criAtomExAcb_DetachAwbFile(IntPtr acb_hn, string awb_name);
}
