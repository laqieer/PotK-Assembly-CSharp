// Decompiled with JetBrains decompiler
// Type: CriAtomEx
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E910E095-517B-41AE-AAF8-B85E770EBAF1
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp-firstpass.dll

using System;
using System.Runtime.InteropServices;

#nullable disable
public static class CriAtomEx
{
  public static void RegisterAcf(CriFsBinder binder, string acfPath)
  {
    CriAtomEx.criAtomEx_RegisterAcfFile(binder == null ? IntPtr.Zero : binder.nativeHandle, acfPath, IntPtr.Zero, 0);
  }

  public static void RegisterAcf(byte[] acfData)
  {
    CriAtomEx.criAtomEx_RegisterAcfData(acfData, acfData.Length, IntPtr.Zero, 0);
  }

  public static void UnregisterAcf() => CriAtomEx.criAtomEx_UnregisterAcf();

  public static void AttachDspBusSetting(string settingName)
  {
    CriAtomEx.criAtomEx_AttachDspBusSetting(settingName, IntPtr.Zero, 0);
  }

  public static void DetachDspBusSetting() => CriAtomEx.criAtomEx_DetachDspBusSetting();

  public static void ApplyDspBusSnapshot(string snapshot_name, int time_ms)
  {
    CriAtomEx.criAtomEx_ApplyDspBusSnapshot(snapshot_name, time_ms);
  }

  public static int GetNumGameVariables() => CriAtomEx.criAtomEx_GetNumGameVariables();

  public static bool GetGameVariableInfo(ushort index, out CriAtomEx.GameVariableInfo info)
  {
    using (CriStructMemory<CriAtomEx.GameVariableInfo> criStructMemory = new CriStructMemory<CriAtomEx.GameVariableInfo>())
    {
      bool gameVariableInfo = CriAtomEx.criAtomEx_GetGameVariableInfo(index, criStructMemory.ptr);
      info = new CriAtomEx.GameVariableInfo(criStructMemory.bytes, 0);
      return gameVariableInfo;
    }
  }

  public static float GetGameVariable(uint game_variable_id)
  {
    return CriAtomEx.criAtomEx_GetGameVariableById(game_variable_id);
  }

  public static float GetGameVariable(string game_variable_name)
  {
    return CriAtomEx.criAtomEx_GetGameVariableByName(game_variable_name);
  }

  public static void SetGameVariable(uint game_variable_id, float game_variable_value)
  {
    CriAtomEx.criAtomEx_SetGameVariableById(game_variable_id, game_variable_value);
  }

  public static void SetGameVariable(string game_variable_name, float game_variable_value)
  {
    CriAtomEx.criAtomEx_SetGameVariableByName(game_variable_name, game_variable_value);
  }

  public static void SetRandomSeed(uint seed) => CriAtomEx.criAtomEx_SetRandomSeed(seed);

  public static void ResetPerformanceMonitor() => CriAtomEx.criAtom_ResetPerformanceMonitor();

  public static void GetPerformanceInfo(out CriAtomEx.PerformanceInfo info)
  {
    using (CriStructMemory<CriAtomEx.PerformanceInfo> criStructMemory = new CriStructMemory<CriAtomEx.PerformanceInfo>())
    {
      CriAtomEx.criAtom_GetPerformanceInfo(criStructMemory.ptr);
      info = new CriAtomEx.PerformanceInfo(criStructMemory.bytes, 0);
    }
  }

  public static void SetOutputVolume_VITA(float volume)
  {
  }

  public static bool IsBgmPortAcquired_VITA() => true;

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern bool criAtomEx_RegisterAcfFile(
    IntPtr binder,
    string path,
    IntPtr work,
    int workSize);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern bool criAtomEx_RegisterAcfData(
    byte[] acfData,
    int acfDataSize,
    IntPtr work,
    int workSize);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern void criAtomEx_UnregisterAcf();

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern void criAtomEx_AttachDspBusSetting(
    string settingName,
    IntPtr work,
    int workSize);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern void criAtomEx_DetachDspBusSetting();

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern void criAtomEx_ApplyDspBusSnapshot(string snapshot_name, int time_ms);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern int criAtomEx_GetNumGameVariables();

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern bool criAtomEx_GetGameVariableInfo(ushort index, IntPtr game_variable_info);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern float criAtomEx_GetGameVariableById(uint game_variable_id);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern float criAtomEx_GetGameVariableByName(string game_variable_name);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern void criAtomEx_SetGameVariableById(
    uint game_variable_id,
    float game_variable_value);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern void criAtomEx_SetGameVariableByName(
    string game_variable_name,
    float game_variable_value);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern void criAtomEx_SetRandomSeed(uint seed);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern void criAtom_ResetPerformanceMonitor();

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern void criAtom_GetPerformanceInfo(IntPtr info);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  public static extern void criAtom_EnableSlLatencyCheck_ANDROID(bool sw);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  public static extern int criAtom_GetSlBufferConsumptionLatency_ANDROID();

  public enum SoundRendererType
  {
    Default = 0,
    Hw1 = 1,
    Native = 1,
    Asr = 2,
    Hw2 = 9,
  }

  public enum VoiceAllocationMethod
  {
    Once,
    Retry,
  }

  public enum BiquadFilterType
  {
    Off,
    LowPass,
    HighPass,
    Notch,
    LowShelf,
    HighShelf,
    Peaking,
  }

  public enum ResumeMode
  {
    AllPlayback,
    PausedPlayback,
    PreparedPlayback,
  }

  public enum PanType
  {
    Pan3d,
    Pos3d,
    Auto,
  }

  public enum VoiceControlMethod
  {
    PreferLast,
    PreferFirst,
  }

  public enum Parameter
  {
    Volume = 0,
    Pitch = 1,
    Pan3dAngle = 2,
    Pan3dDistance = 3,
    Pan3dVolume = 4,
    BusSendLevel0 = 9,
    BusSendLevel1 = 10, // 0x0000000A
    BusSendLevel2 = 11, // 0x0000000B
    BusSendLevel3 = 12, // 0x0000000C
    BusSendLevel4 = 13, // 0x0000000D
    BusSendLevel5 = 14, // 0x0000000E
    BusSendLevel6 = 15, // 0x0000000F
    BusSendLevel7 = 16, // 0x00000010
    BandPassFilterCofLow = 17, // 0x00000011
    BandPassFilterCofHigh = 18, // 0x00000012
    BiquadFilterType = 19, // 0x00000013
    BiquadFilterFreq = 20, // 0x00000014
    BiquadFIlterQ = 21, // 0x00000015
    BiquadFilterGain = 22, // 0x00000016
    EnvelopeAttackTime = 23, // 0x00000017
    EnvelopeHoldTime = 24, // 0x00000018
    EnvelopeDecayTime = 25, // 0x00000019
    EnvelopeReleaseTime = 26, // 0x0000001A
    EnvelopeSustainLevel = 27, // 0x0000001B
    StartTime = 28, // 0x0000001C
    Priority = 31, // 0x0000001F
  }

  public enum Speaker
  {
    FrontLeft,
    FrontRight,
    FrontCenter,
    LowFrequency,
    SurroundLeft,
    SurroundRight,
    SurroundBackLeft,
    SurroundBackRight,
  }

  public enum Format : uint
  {
    ADX = 1,
    HCA = 3,
    HCA_MX = 4,
  }

  public struct FormatInfo
  {
    public CriAtomEx.Format format;
    public int samplingRate;
    public long numSamples;
    public long loopOffset;
    public long loopLength;
    public int numChannels;
    public uint reserved;
  }

  public struct AisacControlInfo
  {
    [MarshalAs(UnmanagedType.LPStr)]
    public readonly string name;
    public uint id;

    public AisacControlInfo(byte[] data, int startIndex)
    {
      if (IntPtr.Size == 4)
      {
        this.name = Marshal.PtrToStringAnsi(new IntPtr(BitConverter.ToInt32(data, startIndex)));
        this.id = BitConverter.ToUInt32(data, startIndex + 4);
      }
      else
      {
        this.name = Marshal.PtrToStringAnsi(new IntPtr(BitConverter.ToInt64(data, startIndex)));
        this.id = BitConverter.ToUInt32(data, startIndex + 8);
      }
    }
  }

  public struct CuePos3dInfo
  {
    public float coneInsideAngle;
    public float coneOutsideAngle;
    public float minDistance;
    public float maxDistance;
    public float dopplerFactor;
    public ushort distanceAisacControl;
    public ushort listenerBaseAngleAisacControl;
    public ushort sourceBaseAngleAisacControl;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
    public ushort[] reserved;

    public CuePos3dInfo(byte[] data, int startIndex)
    {
      this.coneInsideAngle = BitConverter.ToSingle(data, startIndex);
      this.coneOutsideAngle = BitConverter.ToSingle(data, startIndex + 4);
      this.minDistance = BitConverter.ToSingle(data, startIndex + 8);
      this.maxDistance = BitConverter.ToSingle(data, startIndex + 12);
      this.dopplerFactor = BitConverter.ToSingle(data, startIndex + 16);
      this.distanceAisacControl = BitConverter.ToUInt16(data, startIndex + 20);
      this.listenerBaseAngleAisacControl = BitConverter.ToUInt16(data, startIndex + 22);
      this.sourceBaseAngleAisacControl = BitConverter.ToUInt16(data, startIndex + 24);
      this.reserved = new ushort[1];
      for (int index = 0; index < 1; ++index)
        this.reserved[index] = BitConverter.ToUInt16(data, startIndex + 26 + 2 * index);
    }
  }

  public struct GameVariableInfo
  {
    [MarshalAs(UnmanagedType.LPStr)]
    public readonly string name;
    public uint id;
    public float gameValue;

    public GameVariableInfo(byte[] data, int startIndex)
    {
      if (IntPtr.Size == 4)
      {
        this.name = Marshal.PtrToStringAnsi(new IntPtr(BitConverter.ToInt32(data, startIndex)));
        this.id = BitConverter.ToUInt32(data, startIndex + 4);
        this.gameValue = BitConverter.ToSingle(data, startIndex + 8);
      }
      else
      {
        this.name = Marshal.PtrToStringAnsi(new IntPtr(BitConverter.ToInt64(data, startIndex)));
        this.id = BitConverter.ToUInt32(data, startIndex + 8);
        this.gameValue = BitConverter.ToSingle(data, startIndex + 12);
      }
    }

    public GameVariableInfo(string name, uint id, float gameValue)
    {
      this.name = name;
      this.id = id;
      this.gameValue = gameValue;
    }
  }

  public enum CueType
  {
    Polyphonic,
    Sequential,
    Shuffle,
    Random,
    RandomNoRepeat,
    Switch,
    ComboSequential,
  }

  public struct CueInfo
  {
    public int id;
    public CriAtomEx.CueType type;
    [MarshalAs(UnmanagedType.LPStr)]
    public readonly string name;
    [MarshalAs(UnmanagedType.LPStr)]
    public readonly string userData;
    public long length;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
    public ushort[] categories;
    public short numLimits;
    public ushort numBlocks;
    public byte priority;
    public byte headerVisibility;
    public byte ignore_player_parameter;
    public byte probability;
    public CriAtomEx.CuePos3dInfo pos3dInfo;
    public CriAtomEx.GameVariableInfo gameVariableInfo;

    public CueInfo(byte[] data, int startIndex)
    {
      if (IntPtr.Size == 4)
      {
        this.id = BitConverter.ToInt32(data, startIndex);
        this.type = (CriAtomEx.CueType) BitConverter.ToInt32(data, startIndex + 4);
        this.name = Marshal.PtrToStringAnsi(new IntPtr(BitConverter.ToInt32(data, startIndex + 8)));
        this.userData = Marshal.PtrToStringAnsi(new IntPtr(BitConverter.ToInt32(data, startIndex + 12)));
        this.length = BitConverter.ToInt64(data, startIndex + 16);
        this.categories = new ushort[16];
        for (int index = 0; index < 16; ++index)
          this.categories[index] = BitConverter.ToUInt16(data, startIndex + 24 + 2 * index);
        this.numLimits = BitConverter.ToInt16(data, startIndex + 56);
        this.numBlocks = BitConverter.ToUInt16(data, startIndex + 58);
        this.priority = data[startIndex + 60];
        this.headerVisibility = data[startIndex + 61];
        this.ignore_player_parameter = data[startIndex + 62];
        this.probability = data[startIndex + 63];
        this.pos3dInfo = new CriAtomEx.CuePos3dInfo(data, startIndex + 64);
        this.gameVariableInfo = new CriAtomEx.GameVariableInfo(data, startIndex + 92);
      }
      else
      {
        this.id = BitConverter.ToInt32(data, startIndex);
        this.type = (CriAtomEx.CueType) BitConverter.ToInt32(data, startIndex + 4);
        this.name = Marshal.PtrToStringAnsi(new IntPtr(BitConverter.ToInt64(data, startIndex + 8)));
        this.userData = Marshal.PtrToStringAnsi(new IntPtr(BitConverter.ToInt64(data, startIndex + 16)));
        this.length = BitConverter.ToInt64(data, startIndex + 24);
        this.categories = new ushort[16];
        for (int index = 0; index < 16; ++index)
          this.categories[index] = BitConverter.ToUInt16(data, startIndex + 32 + 2 * index);
        this.numLimits = BitConverter.ToInt16(data, startIndex + 64);
        this.numBlocks = BitConverter.ToUInt16(data, startIndex + 66);
        this.priority = data[startIndex + 68];
        this.headerVisibility = data[startIndex + 69];
        this.ignore_player_parameter = data[startIndex + 70];
        this.probability = data[startIndex + 71];
        this.pos3dInfo = new CriAtomEx.CuePos3dInfo(data, startIndex + 72);
        this.gameVariableInfo = new CriAtomEx.GameVariableInfo(data, startIndex + 104);
      }
    }
  }

  public struct WaveformInfo
  {
    public int waveId;
    public uint format;
    public int samplingRate;
    public int numChannels;
    public long numSamples;
    public bool streamingFlag;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
    public uint[] reserved;

    public WaveformInfo(byte[] data, int startIndex)
    {
      this.waveId = BitConverter.ToInt32(data, startIndex);
      this.format = BitConverter.ToUInt32(data, startIndex + 4);
      this.samplingRate = BitConverter.ToInt32(data, startIndex + 8);
      this.numChannels = BitConverter.ToInt32(data, startIndex + 12);
      this.numSamples = BitConverter.ToInt64(data, startIndex + 16);
      this.streamingFlag = BitConverter.ToInt32(data, startIndex + 24) != 0;
      this.reserved = new uint[1];
      for (int index = 0; index < 1; ++index)
        this.reserved[index] = BitConverter.ToUInt32(data, startIndex + 28 + 4 * index);
    }
  }

  public struct PerformanceInfo
  {
    public uint serverProcessCount;
    public uint lastServerTime;
    public uint maxServerTime;
    public uint averageServerTime;
    public uint lastServerInterval;
    public uint maxServerInterval;
    public uint averageServerInterval;

    public PerformanceInfo(byte[] data, int startIndex)
    {
      this.serverProcessCount = BitConverter.ToUInt32(data, startIndex);
      this.lastServerTime = BitConverter.ToUInt32(data, startIndex + 4);
      this.maxServerTime = BitConverter.ToUInt32(data, startIndex + 8);
      this.averageServerTime = BitConverter.ToUInt32(data, startIndex + 12);
      this.lastServerInterval = BitConverter.ToUInt32(data, startIndex + 16);
      this.maxServerInterval = BitConverter.ToUInt32(data, startIndex + 20);
      this.averageServerInterval = BitConverter.ToUInt32(data, startIndex + 24);
    }
  }
}
