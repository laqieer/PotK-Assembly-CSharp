// Decompiled with JetBrains decompiler
// Type: CRISoundManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class CRISoundManager : Singleton<CRISoundManager>
{
  public int maxBGM = 3;
  public int maxSE = 3;
  public int maxVoice = 3;
  private float curAisac;
  public CRISoundManager.SoundVolume volume;
  private int mainBGMChannel;
  private CriAtomSource[] bgmSource;
  private CriAtomSource[] seSources;
  private CriAtomSource[] voiceSources;
  private GameObject audioObject;
  private string bgmCueSheetName = "BgmCueSheet";
  private string seCueSheetName = "SECueSheet";
  private string voiceCueSheetName = "VO_1001";
  private int reserveVoiceAudioChannel = -1;

  protected override void Initialize()
  {
    this.bgmSource = new CriAtomSource[this.maxBGM];
    this.seSources = new CriAtomSource[this.maxSE];
    this.voiceSources = new CriAtomSource[this.maxVoice];
    this.createAudioObject();
  }

  private void createAudioObject()
  {
    CriAtom.AddCueSheet("SECueSheet", "SECueSheet.acb", string.Empty);
    CriAtom.AddCueSheet("VO_1001", "VO_1001.acb", string.Empty);
    CriAtom.AddCueSheet("BgmCueSheet", "BgmCueSheet.acb", string.Empty);
    this.audioObject = new GameObject("AudioObject");
    this.audioObject.transform.position = ((Component) this).transform.position;
    this.audioObject.transform.parent = ((Component) this).transform;
    for (int index = 0; index < this.bgmSource.Length; ++index)
    {
      this.bgmSource[index] = this.audioObject.AddComponent<CriAtomSource>();
      this.bgmSource[index].cueSheet = this.bgmCueSheetName;
    }
    for (int index = 0; index < this.seSources.Length; ++index)
    {
      this.seSources[index] = this.audioObject.AddComponent<CriAtomSource>();
      this.seSources[index].loop = false;
      this.seSources[index].cueSheet = this.seCueSheetName;
    }
    for (int index = 0; index < this.voiceSources.Length; ++index)
    {
      this.voiceSources[index] = this.audioObject.AddComponent<CriAtomSource>();
      this.voiceSources[index].loop = false;
      this.voiceSources[index].cueSheet = this.voiceCueSheetName;
    }
  }

  private void Update()
  {
    if (!this.volume.modified)
      return;
    CriAtomExCategory.Mute("BGM", this.volume.mute);
    CriAtomExCategory.SetVolume("BGM", this.volume.bgmVolume);
    CriAtomExCategory.Mute("SE", this.volume.mute);
    CriAtomExCategory.SetVolume("SE", this.volume.seVolume);
    CriAtomExCategory.Mute("VOICE", this.volume.mute);
    CriAtomExCategory.SetVolume("VOICE", this.volume.voiceVolume);
    NGUITools.soundVolume = !this.volume.mute ? this.volume.seVolume : 0.0f;
    this.volume.modified = false;
  }

  public CriAtomSource getMainBGMAudioSource() => this.bgmSource[this.mainBGMChannel];

  public CriAtomSource getPrevBGMAudioSource()
  {
    int index = this.mainBGMChannel - 1;
    if (index < 0)
      index = this.maxBGM - 1;
    return this.bgmSource[index];
  }

  public CriAtomSource getNextBGMAudioSource()
  {
    return this.bgmSource[(this.mainBGMChannel + 1) % this.maxBGM];
  }

  public void playBGM(string clip, float startTime = 0.1f)
  {
    if (clip == this.bgmSource[this.mainBGMChannel].cueName)
      return;
    CriAtomSource audio = this.bgmSource[this.mainBGMChannel];
    audio.cueName = clip;
    audio.startTime = 0;
    float delay = startTime;
    this.StartCoroutine(this.delayPlay(audio, delay));
  }

  [DebuggerHidden]
  private IEnumerator Fade(CriAtomSource audio, float v0, float v1, float duration, float delay = 0.0f)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new CRISoundManager.\u003CFade\u003Ec__IteratorB4B()
    {
      delay = delay,
      audio = audio,
      duration = duration,
      v0 = v0,
      v1 = v1,
      \u003C\u0024\u003Edelay = delay,
      \u003C\u0024\u003Eaudio = audio,
      \u003C\u0024\u003Eduration = duration,
      \u003C\u0024\u003Ev0 = v0,
      \u003C\u0024\u003Ev1 = v1,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator BgmCrossFade(
    CriAtomSource audio,
    float v0,
    float v1,
    float duration,
    float delay = 0.0f)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new CRISoundManager.\u003CBgmCrossFade\u003Ec__IteratorB4C()
    {
      delay = delay,
      duration = duration,
      audio = audio,
      v0 = v0,
      v1 = v1,
      \u003C\u0024\u003Edelay = delay,
      \u003C\u0024\u003Eduration = duration,
      \u003C\u0024\u003Eaudio = audio,
      \u003C\u0024\u003Ev0 = v0,
      \u003C\u0024\u003Ev1 = v1
    };
  }

  public void corssFadeCurrentBGM(float duration, float startTime)
  {
    CriAtomSource audio = this.bgmSource[this.mainBGMChannel];
    float curAisac = this.curAisac;
    this.curAisac = (double) curAisac != 0.0 ? 0.0f : 1f;
    this.StartCoroutine(this.BgmCrossFade(audio, curAisac, this.curAisac, duration, startTime));
  }

  public void playBGMWithCrossFade(AudioClip clip, float duration, float startTime = 0.1f)
  {
    if (((Object) clip).name == this.bgmSource[this.mainBGMChannel].cueName)
      return;
    float delay = startTime;
    CriAtomSource audio1 = this.bgmSource[this.mainBGMChannel];
    if (this.bgmSource[this.mainBGMChannel].status == CriAtomSource.Status.Playing)
    {
      this.StartCoroutine(this.Fade(audio1, audio1.volume, 0.0f, duration, delay));
      this.mainBGMChannel = (this.mainBGMChannel + 1) % this.maxBGM;
    }
    CriAtomSource audio2 = this.bgmSource[this.mainBGMChannel];
    audio2.volume = 0.0f;
    audio2.cueName = ((Object) clip).name;
    audio2.startTime = 0;
    audio2.Play();
    this.curAisac = 0.0f;
    audio2.SetAisac(0U, this.curAisac);
    this.StartCoroutine(this.Fade(audio2, audio2.volume, this.volume.bgmVolume, duration, delay));
  }

  public void playBGMWithCrossFade(string clip, float duration, float startTime = 0.1f)
  {
    if (clip == this.bgmSource[this.mainBGMChannel].cueName)
      return;
    float delay = startTime;
    CriAtomSource audio1 = this.bgmSource[this.mainBGMChannel];
    if (this.bgmSource[this.mainBGMChannel].status == CriAtomSource.Status.Playing)
    {
      this.StartCoroutine(this.Fade(audio1, audio1.volume, 0.0f, duration, delay));
      this.mainBGMChannel = (this.mainBGMChannel + 1) % this.maxBGM;
    }
    CriAtomSource audio2 = this.bgmSource[this.mainBGMChannel];
    audio2.volume = 0.0f;
    audio2.cueName = clip;
    audio2.startTime = 0;
    this.StartCoroutine(this.delayPlay(audio2, delay));
    this.StartCoroutine(this.Fade(audio2, audio2.volume, this.volume.bgmVolume, duration, delay));
  }

  public void playBGMWithCombineTimeFade(AudioClip clip, float duration, float startTime = 0.1f)
  {
    if (((Object) clip).name == this.bgmSource[this.mainBGMChannel].cueName)
      return;
    float delay = startTime;
    long time = this.bgmSource[this.mainBGMChannel].time;
    Debug.Log((object) (" === CRISoundManager# playBGMWithCombineTimeFade current time = " + time.ToString()));
    Debug.Log((object) (" === CRISoundManager# playBGMWithCombineTimeFade dspStartTime = " + (AudioSettings.dspTime + (double) delay).ToString()));
    CriAtomSource audio1 = this.bgmSource[this.mainBGMChannel];
    if (audio1.status == CriAtomSource.Status.Playing)
    {
      this.StartCoroutine(this.Fade(audio1, audio1.volume, 0.0f, duration, delay));
      this.mainBGMChannel = (this.mainBGMChannel + 1) % this.maxBGM;
    }
    CriAtomSource audio2 = this.bgmSource[this.mainBGMChannel];
    audio2.cueName = ((Object) clip).name;
    audio2.startTime = (int) time;
    audio2.volume = 0.0f;
    audio2.Play();
    this.StartCoroutine(this.Fade(audio2, audio2.volume, this.volume.bgmVolume, duration, delay));
  }

  public void playBGMWithCombineTimeFade(string clip, float duration, float startTime = 0.1f)
  {
    if (clip == this.bgmSource[this.mainBGMChannel].cueName)
      return;
    float delay = startTime;
    long time = this.bgmSource[this.mainBGMChannel].time;
    Debug.Log((object) (" === CRISoundManager# playBGMWithCombineTimeFade(str) current time = " + time.ToString()));
    Debug.Log((object) (" === CRISoundManager# playBGMWithCombineTimeFade(str) dspStartTime = " + (AudioSettings.dspTime + (double) delay).ToString()));
    CriAtomSource audio1 = this.bgmSource[this.mainBGMChannel];
    if (audio1.status == CriAtomSource.Status.Playing)
    {
      this.StartCoroutine(this.Fade(audio1, audio1.volume, 0.0f, duration, delay));
      this.mainBGMChannel = (this.mainBGMChannel + 1) % this.maxBGM;
    }
    CriAtomSource audio2 = this.bgmSource[this.mainBGMChannel];
    audio2.cueName = clip;
    audio2.startTime = (int) time;
    audio2.volume = 0.0f;
    CriAtomEx.FormatInfo info;
    audio2.Play().GetFormatInfo(out info);
    Debug.Log((object) (" === CRISoundManager# playBGMWithCombineTimeFade(str) loopOffset = " + (object) info.loopOffset + " len = " + (object) info.loopLength));
    this.bgmSource[this.mainBGMChannel].SetAisac(0U, 0.0f);
    this.StartCoroutine(this.Fade(audio2, audio2.volume, this.volume.bgmVolume, duration, delay));
  }

  public void stopBGM()
  {
    foreach (CriAtomSource criAtomSource in this.bgmSource)
    {
      if (criAtomSource.status == CriAtomSource.Status.Playing)
      {
        criAtomSource.Stop();
        criAtomSource.cueName = (string) null;
      }
    }
  }

  public void stopBGMWithFadeOut(float duration)
  {
    foreach (CriAtomSource audio in this.bgmSource)
    {
      if (audio.status == CriAtomSource.Status.Playing)
        this.StartCoroutine(this.Fade(audio, audio.volume, 0.0f, duration));
      else
        audio.cueName = (string) null;
    }
  }

  public int playSE(AudioClip clip, bool isLoop = false)
  {
    int num = 0;
    CriAtomSource criAtomSource = (CriAtomSource) null;
    foreach (CriAtomSource seSource in this.seSources)
    {
      if (seSource.status != CriAtomSource.Status.Playing)
      {
        criAtomSource = seSource;
        break;
      }
      ++num;
    }
    if (Object.op_Inequality((Object) criAtomSource, (Object) null))
    {
      criAtomSource.cueName = ((Object) clip).name;
      if (isLoop)
        criAtomSource.loop = true;
      criAtomSource.Play();
    }
    else
      num = -1;
    return num;
  }

  public int playSE(string clip, bool isLoop = false)
  {
    int num = 0;
    CriAtomSource criAtomSource = (CriAtomSource) null;
    foreach (CriAtomSource seSource in this.seSources)
    {
      if (seSource.status != CriAtomSource.Status.Playing)
      {
        criAtomSource = seSource;
        break;
      }
      ++num;
    }
    if (Object.op_Inequality((Object) criAtomSource, (Object) null))
    {
      criAtomSource.cueName = clip;
      if (isLoop)
        criAtomSource.loop = true;
      criAtomSource.Play();
    }
    else
      num = -1;
    return num;
  }

  public int playSE(int clip, bool isLoop = false)
  {
    int num = 0;
    CriAtomSource criAtomSource = (CriAtomSource) null;
    foreach (CriAtomSource seSource in this.seSources)
    {
      if (seSource.status != CriAtomSource.Status.Playing)
      {
        criAtomSource = seSource;
        break;
      }
      ++num;
    }
    if (Object.op_Inequality((Object) criAtomSource, (Object) null))
    {
      if (isLoop)
        criAtomSource.loop = true;
      criAtomSource.Play(clip);
    }
    else
      num = -1;
    return num;
  }

  public void stopSE(int channel = -1)
  {
    if (channel == -1)
    {
      foreach (CriAtomSource seSource in this.seSources)
      {
        if (seSource.status == CriAtomSource.Status.Playing)
          seSource.Stop();
      }
    }
    else
    {
      if (this.seSources[channel].status != CriAtomSource.Status.Playing)
        return;
      this.seSources[channel].Stop();
    }
  }

  public int getVoiceAudioChannel()
  {
    int voiceAudioChannel;
    for (voiceAudioChannel = 0; voiceAudioChannel < this.voiceSources.Length; ++voiceAudioChannel)
    {
      if (voiceAudioChannel != this.reserveVoiceAudioChannel && this.voiceSources[voiceAudioChannel].status != CriAtomSource.Status.Playing)
        goto label_5;
    }
    voiceAudioChannel = -1;
label_5:
    this.reserveVoiceAudioChannel = voiceAudioChannel;
    return voiceAudioChannel;
  }

  public void cleanupReserveAudioChannel(int channel = -1)
  {
    if (channel != -1 && channel != this.reserveVoiceAudioChannel)
      return;
    this.reserveVoiceAudioChannel = -1;
  }

  public int playVoice(AudioClip clip, int channel = -1)
  {
    if (channel == -1)
      channel = this.getVoiceAudioChannel();
    if (channel == this.reserveVoiceAudioChannel)
      this.reserveVoiceAudioChannel = -1;
    if (channel != -1)
    {
      this.voiceSources[channel].cueName = ((Object) clip).name;
      this.voiceSources[channel].Play();
    }
    return channel;
  }

  public int playVoice(string clip, int channel = -1)
  {
    if (channel == -1)
      channel = this.getVoiceAudioChannel();
    if (channel == this.reserveVoiceAudioChannel)
      this.reserveVoiceAudioChannel = -1;
    if (channel != -1)
    {
      this.voiceSources[channel].cueName = clip;
      this.voiceSources[channel].Play();
    }
    return channel;
  }

  public int playVoiceByID(int id, int character_id, int channel = -1)
  {
    if (channel == -1)
      channel = this.getVoiceAudioChannel();
    if (channel == this.reserveVoiceAudioChannel)
      this.reserveVoiceAudioChannel = -1;
    if (channel != -1)
    {
      this.voiceSources[channel].cueSheet = "VO_" + character_id.ToString();
      this.voiceSources[channel].Play(id);
    }
    return channel;
  }

  public void stopVoice(int channel = -1)
  {
    if (channel == -1)
    {
      foreach (CriAtomSource voiceSource in this.voiceSources)
      {
        if (voiceSource.status == CriAtomSource.Status.Playing)
          voiceSource.Stop();
      }
    }
    else
    {
      if (this.voiceSources[channel].status != CriAtomSource.Status.Playing)
        return;
      this.voiceSources[channel].Stop();
    }
  }

  public CriAtomSource getVoiceAudioSource(int channel)
  {
    return channel == -1 || channel >= this.voiceSources.Length ? (CriAtomSource) null : this.voiceSources[channel];
  }

  public CRISoundManager.SoundVolume getVolume() => this.volume;

  [DebuggerHidden]
  private IEnumerator delayPlay(CriAtomSource audio, float delay)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new CRISoundManager.\u003CdelayPlay\u003Ec__IteratorB4D()
    {
      delay = delay,
      audio = audio,
      \u003C\u0024\u003Edelay = delay,
      \u003C\u0024\u003Eaudio = audio
    };
  }

  [Serializable]
  public class SoundVolume
  {
    [SerializeField]
    [Range(0.0f, 1f)]
    private float mBgmVolume = 0.5f;
    [SerializeField]
    [Range(0.0f, 1f)]
    private float mSeVolume = 0.5f;
    [Range(0.0f, 1f)]
    [SerializeField]
    private float mVoiceVolume = 0.5f;
    [SerializeField]
    private bool mMute;
    public bool modified = true;

    public float bgmVolume
    {
      get => this.mBgmVolume;
      set
      {
        this.mBgmVolume = value;
        this.modified = true;
      }
    }

    public float seVolume
    {
      get => this.mSeVolume;
      set
      {
        this.mSeVolume = value;
        this.modified = true;
      }
    }

    public float voiceVolume
    {
      get => this.mVoiceVolume;
      set
      {
        this.mVoiceVolume = value;
        this.modified = true;
      }
    }

    public bool mute
    {
      get => this.mMute;
      set
      {
        this.mMute = value;
        this.modified = true;
      }
    }
  }
}
