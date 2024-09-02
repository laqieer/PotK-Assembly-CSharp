// Decompiled with JetBrains decompiler
// Type: CriAtomConfig
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FC6F22C0-326E-48ED-B5EE-59590337E752
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp-firstpass.dll

using System;

#nullable disable
[Serializable]
public class CriAtomConfig
{
  public string acfFileName = string.Empty;
  public int maxVirtualVoices = 32;
  public int maxVoiceLimitGroups = 32;
  public int maxCategories = 32;
  public CriAtomConfig.StandardVoicePoolConfig standardVoicePoolConfig = new CriAtomConfig.StandardVoicePoolConfig();
  public CriAtomConfig.HcaMxVoicePoolConfig hcaMxVoicePoolConfig = new CriAtomConfig.HcaMxVoicePoolConfig();
  public int outputSamplingRate;
  public bool usesInGamePreview;
  public float serverFrequency = 60f;
  public int asrOutputChannels;
  public bool useRandomSeedWithTime;
  public int iosBufferingTime = 50;
  public bool iosOverrideIPodMusic;
  public int androidBufferingTime = 133;
  public int androidStartBufferingTime = 100;
  public CriAtomConfig.AndroidLowLatencyStandardVoicePoolConfig androidLowLatencyStandardVoicePoolConfig = new CriAtomConfig.AndroidLowLatencyStandardVoicePoolConfig();
  public CriAtomConfig.VitaAtrac9VoicePoolConfig vitaAtrac9VoicePoolConfig = new CriAtomConfig.VitaAtrac9VoicePoolConfig();
  public CriAtomConfig.Ps4Atrac9VoicePoolConfig ps4Atrac9VoicePoolConfig = new CriAtomConfig.Ps4Atrac9VoicePoolConfig();

  [Serializable]
  public class StandardVoicePoolConfig
  {
    public int memoryVoices = 16;
    public int streamingVoices = 8;
  }

  [Serializable]
  public class HcaMxVoicePoolConfig
  {
    public int memoryVoices;
    public int streamingVoices;
  }

  [Serializable]
  public class AndroidLowLatencyStandardVoicePoolConfig
  {
    public int memoryVoices;
    public int streamingVoices;
  }

  [Serializable]
  public class VitaAtrac9VoicePoolConfig
  {
    public int memoryVoices;
    public int streamingVoices;
  }

  [Serializable]
  public class Ps4Atrac9VoicePoolConfig
  {
    public int memoryVoices;
    public int streamingVoices;
  }
}
