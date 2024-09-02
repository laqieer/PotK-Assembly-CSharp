// Decompiled with JetBrains decompiler
// Type: CriWareInitializer
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ECB926DA-6BA5-4E91-81B4-E3750A024FEA
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp-firstpass.dll

using System;
using System.IO;
using UnityEngine;

#nullable disable
[AddComponentMenu("CRIWARE/Library Initializer")]
public class CriWareInitializer : MonoBehaviour
{
  public bool initializesFileSystem = true;
  public CriFsConfig fileSystemConfig = new CriFsConfig();
  public bool initializesAtom = true;
  public CriAtomConfig atomConfig = new CriAtomConfig();
  public bool initializesMana = true;
  public CriManaConfig manaConfig = new CriManaConfig();
  public bool useDecrypter;
  public CriWareDecrypterConfig decrypterConfig = new CriWareDecrypterConfig();
  public bool dontInitializeOnAwake;
  public bool dontDestroyOnLoad;
  private static int initializationCount;

  private void Awake()
  {
    CriWare.CheckBinaryVersionCompatibility();
    if (this.dontInitializeOnAwake)
      return;
    this.Initialize();
  }

  private void OnEnable()
  {
  }

  private void Start()
  {
  }

  private void Update()
  {
  }

  public void Initialize()
  {
    ++CriWareInitializer.initializationCount;
    if (CriWareInitializer.initializationCount != 1)
    {
      Object.Destroy((Object) this);
    }
    else
    {
      if (this.initializesFileSystem)
      {
        CriFsPlugin.SetConfigParameters(this.fileSystemConfig.numberOfLoaders, this.fileSystemConfig.numberOfBinders, this.fileSystemConfig.numberOfInstallers, this.fileSystemConfig.installBufferSize * 1024, this.fileSystemConfig.maxPath, this.fileSystemConfig.minimizeFileDescriptorUsage);
        if (this.fileSystemConfig.androidDeviceReadBitrate == 0)
          this.fileSystemConfig.androidDeviceReadBitrate = 50000000;
        CriFsPlugin.SetConfigAdditionalParameters_ANDROID(this.fileSystemConfig.androidDeviceReadBitrate);
        CriFsPlugin.InitializeLibrary();
        if (this.fileSystemConfig.userAgentString.Length != 0)
          CriFsUtility.SetUserAgentString(this.fileSystemConfig.userAgentString);
      }
      if (this.initializesAtom)
      {
        CriAtomPlugin.SetConfigParameters(Math.Max(this.atomConfig.maxVirtualVoices, CriAtomPlugin.GetRequiredMaxVirtualVoices(this.atomConfig)), this.atomConfig.maxVoiceLimitGroups, this.atomConfig.maxCategories, this.atomConfig.standardVoicePoolConfig.memoryVoices, this.atomConfig.standardVoicePoolConfig.streamingVoices, this.atomConfig.hcaMxVoicePoolConfig.memoryVoices, this.atomConfig.hcaMxVoicePoolConfig.streamingVoices, this.atomConfig.outputSamplingRate, this.atomConfig.asrOutputChannels, this.atomConfig.usesInGamePreview, this.atomConfig.serverFrequency);
        CriAtomPlugin.SetConfigAdditionalParameters_IOS((uint) Math.Max(this.atomConfig.iosBufferingTime, 16), this.atomConfig.iosOverrideIPodMusic);
        if (this.atomConfig.androidBufferingTime == 0)
          this.atomConfig.androidBufferingTime = (int) (4000.0 / (double) this.atomConfig.serverFrequency);
        if (this.atomConfig.androidStartBufferingTime == 0)
          this.atomConfig.androidStartBufferingTime = (int) (3000.0 / (double) this.atomConfig.serverFrequency);
        CriAtomPlugin.SetConfigAdditionalParameters_ANDROID(this.atomConfig.androidLowLatencyStandardVoicePoolConfig.memoryVoices, this.atomConfig.androidLowLatencyStandardVoicePoolConfig.streamingVoices, this.atomConfig.androidBufferingTime, this.atomConfig.androidStartBufferingTime);
        CriAtomPlugin.SetConfigAdditionalParameters_VITA(this.atomConfig.vitaAtrac9VoicePoolConfig.memoryVoices, this.atomConfig.vitaAtrac9VoicePoolConfig.streamingVoices, !this.initializesMana ? 0 : this.manaConfig.numberOfDecoders);
        CriAtomPlugin.SetConfigAdditionalParameters_PS4(this.atomConfig.ps4Atrac9VoicePoolConfig.memoryVoices, this.atomConfig.ps4Atrac9VoicePoolConfig.streamingVoices);
        CriAtomPlugin.InitializeLibrary();
        if (this.atomConfig.useRandomSeedWithTime)
          CriAtomEx.SetRandomSeed((uint) DateTime.Now.Ticks);
        if (this.atomConfig.acfFileName.Length != 0)
        {
          string str = this.atomConfig.acfFileName;
          if (CriWare.IsStreamingAssetsPath(str))
            str = Path.Combine(CriWare.streamingAssetsPath, str);
          CriAtomEx.RegisterAcf((CriFsBinder) null, str);
        }
      }
      if (this.initializesMana)
      {
        CriManaPlugin.SetConfigParameters(this.manaConfig.graphicsMultiThreaded, this.manaConfig.numberOfDecoders, this.manaConfig.numberOfMaxEntries);
        CriManaPlugin.SetConfigAdditonalParameters_VITA(this.manaConfig.vitaH264PlaybackConfig.useH264Playback, this.manaConfig.vitaH264PlaybackConfig.maxWidth, this.manaConfig.vitaH264PlaybackConfig.maxHeight);
        CriManaPlugin.InitializeLibrary();
      }
      if (this.useDecrypter)
      {
        ulong uint64 = this.decrypterConfig.key.Length != 0 ? Convert.ToUInt64(this.decrypterConfig.key) : 0UL;
        string str = this.decrypterConfig.authenticationFile;
        if (CriWare.IsStreamingAssetsPath(str))
          str = Path.Combine(CriWare.streamingAssetsPath, str);
        CriWare.criWareUnity_SetDecryptionKey(uint64, str, this.decrypterConfig.enableAtomDecryption, this.decrypterConfig.enableManaDecryption);
      }
      else
        CriWare.criWareUnity_SetDecryptionKey(0UL, string.Empty, false, false);
      if (!this.dontDestroyOnLoad)
        return;
      Object.DontDestroyOnLoad((Object) ((Component) ((Component) this).transform).gameObject);
      Object.DontDestroyOnLoad((Object) CriWare.managerObject);
    }
  }

  private void OnDestroy()
  {
    --CriWareInitializer.initializationCount;
    if (CriWareInitializer.initializationCount != 0)
      return;
    if (this.initializesMana)
      CriManaPlugin.FinalizeLibrary();
    if (this.initializesAtom)
    {
      while (CriAtomExLatencyEstimator.GetCurrentInfo().status != CriAtomExLatencyEstimator.Status.Stop)
        CriAtomExLatencyEstimator.FinalizeModule();
      CriAtomPlugin.FinalizeLibrary();
    }
    if (!this.initializesFileSystem)
      return;
    CriFsPlugin.FinalizeLibrary();
  }

  public static bool IsInitialized()
  {
    if (CriWareInitializer.initializationCount > 0)
      return true;
    CriWare.CheckBinaryVersionCompatibility();
    return false;
  }
}
