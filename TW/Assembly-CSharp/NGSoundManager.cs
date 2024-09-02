// Decompiled with JetBrains decompiler
// Type: NGSoundManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using UnityEngine;

#nullable disable
public class NGSoundManager : Singleton<NGSoundManager>
{
  [SerializeField]
  private int maxBGM = 3;
  [SerializeField]
  private int maxSE = 10;
  [SerializeField]
  private int maxVoice = 3;
  [SerializeField]
  private int maxStreamBgm = 10;
  [SerializeField]
  private int maxStreamVoice = 10;
  [SerializeField]
  private float[] busLevel = new float[8];
  private readonly string beforeBgmName = "OpBgmCueSheet";
  private readonly string beforeSeName = "OpCueSheet";
  private readonly string afterBgmName = "BgmCueSheet";
  private readonly string afterSeName = "SECueSheet";
  private readonly string bgmCueSheetName = "BgmCueSheet";
  private readonly string seCueSheetName = "SECueSheet";
  private List<string> bgmCueSheetNameList = new List<string>();
  private List<string> voiceCueSheetName = new List<string>();
  private CriAtomExAcb bgmAcb;
  private CriAtomExAcb seAcb;
  private readonly float[] defaultBusLevel = new float[8]
  {
    1f,
    0.0f,
    0.0f,
    0.0f,
    0.0f,
    0.0f,
    0.0f,
    0.0f
  };
  private NGSoundManager.InitializeState initializeState;
  private bool isInitialize;
  private NGSoundManager.BgmPlayer[] bgmPlayer;
  private CriAtomExPlayer[] sePlayer;
  private CriAtomExPlayer[] voicePlayer;
  private GameObject audioObject;
  public NGSoundManager.SoundVolume volume;

  private string platform => "android";

  protected override void Initialize()
  {
  }

  protected override void Finlaize()
  {
    if (!this.isInitialize)
      return;
    ((IEnumerable<NGSoundManager.BgmPlayer>) this.bgmPlayer).ForEach<NGSoundManager.BgmPlayer>((Action<NGSoundManager.BgmPlayer>) (v => v.player.Dispose()));
    ((IEnumerable<CriAtomExPlayer>) this.sePlayer).ForEach<CriAtomExPlayer>((Action<CriAtomExPlayer>) (v => v.Dispose()));
    ((IEnumerable<CriAtomExPlayer>) this.voicePlayer).ForEach<CriAtomExPlayer>((Action<CriAtomExPlayer>) (v => v.Dispose()));
    this.isInitialize = false;
  }

  private void OnDestroy() => this.Finlaize();

  public void CheckInitialize(bool forcingCompleted = false)
  {
    if (!this.isInitialize)
    {
      this.getVolume().bgmVolume = Persist.volume.Data.Bgm;
      this.getVolume().seVolume = Persist.volume.Data.Se;
      this.getVolume().voiceVolume = Persist.volume.Data.Voice;
      this.audioObject = new GameObject("AudioObject");
      this.audioObject.transform.position = ((Component) this).transform.position;
      this.audioObject.transform.parent = ((Component) this).transform;
      this.bgmPlayer = new NGSoundManager.BgmPlayer[this.maxBGM];
      for (int index = 0; index < this.bgmPlayer.Length; ++index)
      {
        this.bgmPlayer[index] = new NGSoundManager.BgmPlayer();
        this.bgmPlayer[index].player.AttachFader();
      }
      this.sePlayer = new CriAtomExPlayer[this.maxSE];
      for (int index = 0; index < this.sePlayer.Length; ++index)
      {
        this.sePlayer[index] = new CriAtomExPlayer();
        this.sePlayer[index].AttachFader();
        this.sePlayer[index].SetFadeInTime(0);
      }
      this.voicePlayer = new CriAtomExPlayer[this.maxVoice];
      for (int index = 0; index < this.voicePlayer.Length; ++index)
      {
        this.voicePlayer[index] = new CriAtomExPlayer();
        this.voicePlayer[index].AttachFader();
        this.voicePlayer[index].SetFadeInTime(0);
      }
      this.isInitialize = true;
    }
    if (this.initializeState == NGSoundManager.InitializeState.DLC_AFTER)
      return;
    if (!forcingCompleted)
    {
      if (this.initializeState == NGSoundManager.InitializeState.DLC_BEFORE)
      {
        if (!ResourceDownloader.Completed)
          return;
        if (ResourceDownloader.Error != null)
          return;
      }
    }
    try
    {
      if (ResourceDownloader.Completed && ResourceDownloader.Error == null || forcingCompleted)
      {
        this.StopBgm(time: 0.0f);
        this.StopSe(time: 0.0f);
        this.StopVoice(time: 0.0f);
        this.bgmAcb = (CriAtomExAcb) null;
        this.seAcb = (CriAtomExAcb) null;
        CriAtom.RemoveCueSheet(this.bgmCueSheetName);
        CriAtom.RemoveCueSheet(this.seCueSheetName);
        CriAtomEx.UnregisterAcf();
        CriAtomEx.RegisterAcf((CriFsBinder) null, Singleton<ResourceManager>.GetInstance().ResolveStreamingAssetsPath("dlc/punk_music"));
        this.DetachDspBusSetting();
        CriAtom.AddCueSheet("AA", Singleton<ResourceManager>.GetInstance().ResolveStreamingAssetsPath(this.platform + "/" + this.afterBgmName + "_acb"), Singleton<ResourceManager>.GetInstance().ResolveStreamingAssetsPath(this.platform + "/" + this.afterBgmName + "_awb"));
        CriAtom.AddCueSheet("BB", Singleton<ResourceManager>.GetInstance().ResolveStreamingAssetsPath(this.platform + "/" + this.afterSeName + "_acb"), (string) null);
        this.bgmAcb = CriAtom.GetAcb("AA");
        this.seAcb = CriAtom.GetAcb("BB");
        this.initializeState = NGSoundManager.InitializeState.DLC_AFTER;
      }
      else
      {
        CriAtomEx.UnregisterAcf();
        CriAtomEx.RegisterAcf((CriFsBinder) null, Path.Combine(CriWare.streamingAssetsPath, "punk_music.acf"));
        CriAtom.AddCueSheet(this.bgmCueSheetName, this.beforeBgmName + ".acb", this.beforeBgmName + ".awb");
        CriAtom.AddCueSheet(this.seCueSheetName, this.beforeSeName + ".acb", (string) null);
        this.bgmAcb = CriAtom.GetAcb(this.bgmCueSheetName);
        this.seAcb = CriAtom.GetAcb(this.seCueSheetName);
        this.initializeState = NGSoundManager.InitializeState.DLC_BEFORE;
      }
    }
    catch (Exception ex)
    {
      Debug.LogException(ex);
    }
  }

  private void Update()
  {
    if (!this.isInitialize || !this.volume.modified)
      return;
    ((IEnumerable<NGSoundManager.BgmPlayer>) this.bgmPlayer).ForEach<NGSoundManager.BgmPlayer>((Action<NGSoundManager.BgmPlayer>) (v =>
    {
      v.player.SetVolume(!this.volume.mute ? this.volume.bgmVolume : 0.0f);
      v.player.UpdateAll();
    }));
    ((IEnumerable<CriAtomExPlayer>) this.sePlayer).ForEach<CriAtomExPlayer>((Action<CriAtomExPlayer>) (v =>
    {
      v.SetVolume(!this.volume.mute ? this.volume.seVolume : 0.0f);
      v.UpdateAll();
    }));
    ((IEnumerable<CriAtomExPlayer>) this.voicePlayer).ForEach<CriAtomExPlayer>((Action<CriAtomExPlayer>) (v =>
    {
      v.SetVolume(!this.volume.mute ? this.volume.voiceVolume : 0.0f);
      v.UpdateAll();
    }));
    NGUITools.soundVolume = !this.volume.mute ? this.volume.seVolume : 0.0f;
    this.volume.modified = false;
  }

  public int PlayBgm(string clip, int channel = 0, float delay = 0.0f, float fadeInTime = 0.5f, float fadeOutTime = 0.5f)
  {
    this.CheckInitialize();
    if (this.initializeState == NGSoundManager.InitializeState.DLC_BEFORE && !this.bgmAcb.Exists(clip))
      return -1;
    if (channel == -1)
    {
      int? nullable = ((IEnumerable<NGSoundManager.BgmPlayer>) this.bgmPlayer).FirstIndexOrNull<NGSoundManager.BgmPlayer>((Func<NGSoundManager.BgmPlayer, bool>) (v => v.player.GetStatus() == CriAtomExPlayer.Status.Stop || v.player.GetStatus() == CriAtomExPlayer.Status.PlayEnd));
      if (!nullable.HasValue)
        return -1;
      channel = nullable.Value;
    }
    NGSoundManager.BgmPlayer bgmPlayer = this.bgmPlayer[channel];
    if (bgmPlayer.nowName == clip)
      return -1;
    bgmPlayer.nowName = clip;
    bgmPlayer.aisac = 0.0f;
    bgmPlayer.player.SetFadeInTime((int) ((double) fadeInTime * 1000.0));
    bgmPlayer.player.SetFadeOutTime((int) ((double) fadeOutTime * 1000.0));
    bgmPlayer.player.SetCue(this.bgmAcb, clip);
    bgmPlayer.player.SetAisac(0U, bgmPlayer.aisac);
    bgmPlayer.player.UpdateAll();
    bgmPlayer.player.Start();
    if ((double) delay > 0.0)
    {
      bgmPlayer.player.Pause();
      this.StartCoroutine(this.delayPlay(bgmPlayer.player, delay));
    }
    return channel;
  }

  public int PlayBgmFile(
    string file,
    string clip,
    int channel = 0,
    float delay = 0.0f,
    float fadeInTime = 0.5f,
    float fadeOutTime = 0.5f)
  {
    if (file == string.Empty || file == this.afterBgmName)
      return this.PlayBgm(clip, channel, delay, fadeInTime, fadeOutTime);
    this.CheckInitialize();
    if (!this.checkSoundData(this.bgmCueSheetNameList, this.maxStreamBgm, file))
      return -1;
    if (channel == -1)
    {
      int? nullable = ((IEnumerable<NGSoundManager.BgmPlayer>) this.bgmPlayer).FirstIndexOrNull<NGSoundManager.BgmPlayer>((Func<NGSoundManager.BgmPlayer, bool>) (v => v.player.GetStatus() == CriAtomExPlayer.Status.Stop || v.player.GetStatus() == CriAtomExPlayer.Status.PlayEnd));
      if (!nullable.HasValue)
        return -1;
      channel = nullable.Value;
    }
    NGSoundManager.BgmPlayer bgmPlayer = this.bgmPlayer[channel];
    if (bgmPlayer.nowName == clip)
      return -1;
    bgmPlayer.nowName = clip;
    bgmPlayer.aisac = 0.0f;
    bgmPlayer.player.SetFadeInTime((int) ((double) fadeInTime * 1000.0));
    bgmPlayer.player.SetFadeOutTime((int) ((double) fadeOutTime * 1000.0));
    CriAtomExAcb acb = CriAtom.GetAcb(file);
    bgmPlayer.player.SetCue(acb, clip);
    bgmPlayer.player.SetAisac(0U, bgmPlayer.aisac);
    bgmPlayer.player.UpdateAll();
    bgmPlayer.player.Start();
    if ((double) delay > 0.0)
    {
      bgmPlayer.player.Pause();
      this.StartCoroutine(this.delayPlay(bgmPlayer.player, delay));
    }
    return channel;
  }

  [DebuggerHidden]
  private IEnumerator Fade(
    CriAtomExPlayer player,
    float v0,
    float v1,
    float duration,
    float delay = 0.0f)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGSoundManager.\u003CFade\u003Ec__IteratorB5E()
    {
      delay = delay,
      duration = duration,
      player = player,
      v0 = v0,
      v1 = v1,
      \u003C\u0024\u003Edelay = delay,
      \u003C\u0024\u003Eduration = duration,
      \u003C\u0024\u003Eplayer = player,
      \u003C\u0024\u003Ev0 = v0,
      \u003C\u0024\u003Ev1 = v1
    };
  }

  public void StopBgm(int channel = -1, float time = 0.5f)
  {
    if (!this.isInitialize)
      return;
    if (channel < 0)
    {
      ((IEnumerable<NGSoundManager.BgmPlayer>) this.bgmPlayer).ForEach<NGSoundManager.BgmPlayer>((Action<NGSoundManager.BgmPlayer>) (v => v.Stop(time)));
    }
    else
    {
      if (channel >= this.bgmPlayer.Length)
        return;
      this.bgmPlayer[channel].Stop(time);
    }
  }

  public void PauseBgm(int channel = -1)
  {
    if (!this.isInitialize)
      return;
    if (channel == -1)
    {
      for (int index = 0; index < this.bgmPlayer.Length; ++index)
        this.bgmPlayer[index].player.Pause();
    }
    else
    {
      if (channel >= this.bgmPlayer.Length)
        return;
      this.bgmPlayer[channel].player.Pause();
    }
  }

  public void ResumeBgm(int channel = -1)
  {
    if (!this.isInitialize)
      return;
    if (channel == -1)
    {
      for (int index = 0; index < this.bgmPlayer.Length; ++index)
      {
        CriAtomExPlayer player = this.bgmPlayer[index].player;
        player.Pause(false);
        if ((double) this.getVolume().bgmVolume > 0.0)
          this.StartCoroutine(this.Fade(player, 0.0f, this.getVolume().bgmVolume, 0.5f));
      }
    }
    else
    {
      if (channel >= this.bgmPlayer.Length)
        return;
      CriAtomExPlayer player = this.bgmPlayer[channel].player;
      player.Pause(false);
      if ((double) this.getVolume().bgmVolume <= 0.0)
        return;
      this.StartCoroutine(this.Fade(player, 0.0f, this.getVolume().bgmVolume, 0.5f));
    }
  }

  public bool IsBgmPlaying(int channel)
  {
    if (!this.isInitialize || channel < 0 || channel >= this.bgmPlayer.Length)
      return false;
    CriAtomExPlayer player = this.bgmPlayer[channel].player;
    return player.GetStatus() == CriAtomExPlayer.Status.Prep || player.GetStatus() == CriAtomExPlayer.Status.Playing;
  }

  public string GetBgmName(int channel = 0)
  {
    return !this.isInitialize || channel < 0 || channel >= this.bgmPlayer.Length ? string.Empty : this.bgmPlayer[channel].nowName;
  }

  public int PlaySe(string clip, bool isLoop = false, float delay = 0.0f, int channel = -1)
  {
    this.CheckInitialize();
    return this.initializeState == NGSoundManager.InitializeState.DLC_BEFORE && !this.seAcb.Exists(clip) ? -1 : this.PlaySe(isLoop, delay, channel, true, (Action<CriAtomExPlayer>) (player => player.SetCue(this.seAcb, clip)));
  }

  public int PlaySe(int clip, bool isLoop = false, float delay = 0.0f, int channel = -1)
  {
    this.CheckInitialize();
    return this.initializeState == NGSoundManager.InitializeState.DLC_BEFORE && !this.seAcb.Exists(clip) ? -1 : this.PlaySe(isLoop, delay, channel, true, (Action<CriAtomExPlayer>) (player => player.SetCue(this.seAcb, clip)));
  }

  private bool CheckNonEffect(int clip)
  {
    CriAtomEx.CueInfo info = new CriAtomEx.CueInfo();
    return this.seAcb.GetCueInfo(clip, out info) && this.CheckNonEffect(info);
  }

  private bool CheckNonEffect(string clip)
  {
    CriAtomEx.CueInfo info = new CriAtomEx.CueInfo();
    return this.seAcb.GetCueInfo(clip, out info) && this.CheckNonEffect(info);
  }

  private bool CheckNonEffect(CriAtomEx.CueInfo cueInfo)
  {
    return !((IEnumerable<ushort>) cueInfo.categories).FirstIndexOrNull<ushort>((Func<ushort, bool>) (x => x == (ushort) 7)).HasValue;
  }

  private int PlaySe(
    bool isLoop,
    float delay,
    int channel,
    bool busEffect,
    Action<CriAtomExPlayer> action)
  {
    channel = Mathf.Clamp(channel, -1, this.maxSE - 1);
    if (channel == -1)
    {
      int? nullable = ((IEnumerable<CriAtomExPlayer>) this.sePlayer).FirstIndexOrNull<CriAtomExPlayer>((Func<CriAtomExPlayer, bool>) (v => v.GetStatus() == CriAtomExPlayer.Status.Stop || v.GetStatus() == CriAtomExPlayer.Status.PlayEnd));
      if (!nullable.HasValue)
        return -1;
      channel = nullable.Value;
    }
    CriAtomExPlayer player = this.sePlayer[channel];
    player.StopWithoutReleaseTime();
    this.SetBusSendLevel(busEffect, player);
    player.Loop(isLoop);
    action(player);
    if ((double) delay <= 0.0)
    {
      player.Start();
    }
    else
    {
      player.Prepare();
      this.StartCoroutine(this.delayPlay(player, delay));
    }
    return channel;
  }

  public void StopSe(int channel = -1, float time = 0.5f)
  {
    if (!this.isInitialize)
      return;
    this.stop(this.sePlayer, channel, time);
  }

  public void PauseSe(int channel = -1)
  {
    if (!this.isInitialize)
      return;
    if (channel == -1)
    {
      for (int channel1 = 0; channel1 < this.sePlayer.Length; ++channel1)
        this.pause(this.sePlayer, channel1);
    }
    else
    {
      if (channel >= this.sePlayer.Length)
        return;
      this.pause(this.sePlayer, channel);
    }
  }

  public void ResumeSe(int channel = -1)
  {
    if (!this.isInitialize)
      return;
    if (channel == -1)
    {
      for (int channel1 = 0; channel1 < this.sePlayer.Length; ++channel1)
        this.resume(this.sePlayer, channel1);
    }
    else
    {
      if (channel >= this.sePlayer.Length)
        return;
      this.resume(this.sePlayer, channel);
    }
  }

  public bool IsSePlaying(int channel)
  {
    if (!this.isInitialize || channel < 0 || channel >= this.sePlayer.Length)
      return false;
    CriAtomExPlayer criAtomExPlayer = this.sePlayer[channel];
    return criAtomExPlayer.GetStatus() == CriAtomExPlayer.Status.Prep || criAtomExPlayer.GetStatus() == CriAtomExPlayer.Status.Playing;
  }

  public int PlayVoice(UnitUnit unit, string name, int channel = -1, float delay = 0.0f)
  {
    return this.PlayVoice(unit.unitVoicePattern.file_name, name, channel, delay);
  }

  public int PlayVoice(UnitUnit unit, int id, int channel = -1, float delay = 0.0f)
  {
    return this.PlayVoice(unit.unitVoicePattern.file_name, id, channel, delay);
  }

  public int PlayVoice(string fileName, string name, int channel = -1, float delay = 0.0f)
  {
    return this.PlayVoice(fileName, delay, channel, true, (Action<CriAtomExPlayer, CriAtomExAcb>) ((player, acb) => player.SetCue(acb, name)));
  }

  public int PlayVoice(string fileName, int id, int channel = -1, float delay = 0.0f)
  {
    return this.PlayVoice(fileName, delay, channel, true, (Action<CriAtomExPlayer, CriAtomExAcb>) ((player, acb) => player.SetCue(acb, id)));
  }

  private int PlayVoice(
    string id,
    float delay,
    int channel,
    bool busEffect,
    Action<CriAtomExPlayer, CriAtomExAcb> action)
  {
    if (!this.isInitialize || !this.checkSoundData(this.voiceCueSheetName, this.maxStreamVoice, id))
      return -1;
    channel = Mathf.Clamp(channel, -1, this.maxVoice - 1);
    if (channel == -1)
    {
      int? nullable = ((IEnumerable<CriAtomExPlayer>) this.voicePlayer).FirstIndexOrNull<CriAtomExPlayer>((Func<CriAtomExPlayer, bool>) (v => v.GetStatus() == CriAtomExPlayer.Status.Stop || v.GetStatus() == CriAtomExPlayer.Status.PlayEnd));
      if (!nullable.HasValue)
        return -1;
      channel = nullable.Value;
    }
    CriAtomExPlayer player = this.voicePlayer[channel];
    CriAtomExAcb acb = CriAtom.GetAcb(id);
    if (acb == null)
      return -1;
    player.StopWithoutReleaseTime();
    this.SetBusSendLevel(busEffect, player);
    player.Loop(false);
    action(player, acb);
    if ((double) delay <= 0.0)
    {
      player.Start();
    }
    else
    {
      player.Prepare();
      this.StartCoroutine(this.delayPlay(player, delay));
    }
    return channel;
  }

  public void StopVoice(int channel = -1, float time = 0.5f)
  {
    if (!this.isInitialize)
      return;
    this.stop(this.voicePlayer, channel, time);
  }

  public bool IsVoicePlaying(int channel)
  {
    if (!this.isInitialize || channel < 0 || channel >= this.voicePlayer.Length)
      return false;
    CriAtomExPlayer criAtomExPlayer = this.voicePlayer[channel];
    return criAtomExPlayer.GetStatus() == CriAtomExPlayer.Status.Prep || criAtomExPlayer.GetStatus() == CriAtomExPlayer.Status.Playing;
  }

  public bool IsVoiceStopAll()
  {
    if (!this.isInitialize)
      return true;
    foreach (CriAtomExPlayer criAtomExPlayer in this.voicePlayer)
    {
      if (criAtomExPlayer.GetStatus() == CriAtomExPlayer.Status.Prep || criAtomExPlayer.GetStatus() == CriAtomExPlayer.Status.Playing)
        return false;
    }
    return true;
  }

  public bool LoadVoiceData(string fileName)
  {
    return this.checkSoundData(this.voiceCueSheetName, this.maxStreamVoice, fileName);
  }

  public void StopAll(float time = 0.5f)
  {
    this.StopBgm(time: time);
    this.StopSe(time: time);
    this.StopVoice(time: time);
  }

  [DebuggerHidden]
  private IEnumerator delayPlay(CriAtomExPlayer player, float delay)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGSoundManager.\u003CdelayPlay\u003Ec__IteratorB5F()
    {
      delay = delay,
      player = player,
      \u003C\u0024\u003Edelay = delay,
      \u003C\u0024\u003Eplayer = player
    };
  }

  private void OnApplicationPause(bool enable)
  {
    if (!this.isInitialize)
      return;
    this.PauseSources(this.bgmPlayer, enable);
    this.PauseSources(this.sePlayer, enable);
    this.PauseSources(this.voicePlayer, enable);
  }

  private void PauseSources(CriAtomExPlayer[] sources, bool enable)
  {
    ((IEnumerable<CriAtomExPlayer>) sources).ForEach<CriAtomExPlayer>((Action<CriAtomExPlayer>) (v => v.Pause(enable)));
  }

  private void PauseSources(NGSoundManager.BgmPlayer[] sources, bool enable)
  {
    ((IEnumerable<NGSoundManager.BgmPlayer>) sources).ForEach<NGSoundManager.BgmPlayer>((Action<NGSoundManager.BgmPlayer>) (v => v.player.Pause(enable)));
  }

  public NGSoundManager.SoundVolume getVolume() => this.volume;

  private void stop(CriAtomExPlayer[] playerList, int channel, float time)
  {
    if (channel < 0)
    {
      ((IEnumerable<CriAtomExPlayer>) playerList).ForEach<CriAtomExPlayer>((Action<CriAtomExPlayer>) (v =>
      {
        v.SetFadeOutTime((int) ((double) time * 1000.0));
        v.Stop((double) time == 0.0);
      }));
    }
    else
    {
      if (channel >= playerList.Length)
        return;
      playerList[channel].SetFadeOutTime((int) ((double) time * 1000.0));
      playerList[channel].Stop((double) time == 0.0);
    }
  }

  private void pause(CriAtomExPlayer[] playerList, int channel) => playerList[channel].Pause();

  [DebuggerHidden]
  private IEnumerator pauseCorutine(CriAtomExPlayer player)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGSoundManager.\u003CpauseCorutine\u003Ec__IteratorB60()
    {
      player = player,
      \u003C\u0024\u003Eplayer = player
    };
  }

  private void resume(CriAtomExPlayer[] playerList, int channel)
  {
    float v1 = 0.0f;
    if (playerList == this.sePlayer)
      v1 = this.getVolume().seVolume;
    else if (playerList == this.voicePlayer)
      v1 = this.getVolume().voiceVolume;
    CriAtomExPlayer player = playerList[channel];
    player.Pause(false);
    this.StartCoroutine(this.Fade(player, 0.0f, v1, 0.5f));
  }

  private bool IsFile(string s)
  {
    return !string.IsNullOrEmpty(s) && new FileInfo(Path.Combine(CriWare.streamingAssetsPath, s)).Exists;
  }

  public bool LoadedCueSheet(string cue_name) => CriAtom.GetCueSheet(cue_name) != null;

  private bool checkSoundData(List<string> fileList, int maxValue, string file)
  {
    if (fileList.FirstIndexOrNull<string>((Func<string, bool>) (v => v == file)).HasValue)
    {
      fileList.Remove(file);
      fileList.Add(file);
      return true;
    }
    string name = file;
    if (!Singleton<ResourceManager>.GetInstance().Contains(this.platform + "/" + name + "_acb") || !Singleton<ResourceManager>.GetInstance().Contains(this.platform + "/" + name + "_acb"))
      return false;
    string str1 = Singleton<ResourceManager>.GetInstance().ResolveStreamingAssetsPath(this.platform + "/" + name + "_acb");
    string str2 = Singleton<ResourceManager>.GetInstance().ResolveStreamingAssetsPath(this.platform + "/" + name + "_awb");
    if (!this.IsFile(str1) || !this.IsFile(str2))
      return false;
    if (fileList.Count >= maxValue)
    {
      CriAtom.RemoveCueSheet(fileList[0]);
      fileList.RemoveAt(0);
    }
    fileList.Add(file);
    CriAtom.AddCueSheet(name, str1, str2);
    return true;
  }

  public void SetVolumeBgm(float volume)
  {
    ((IEnumerable<NGSoundManager.BgmPlayer>) this.bgmPlayer).ForEach<NGSoundManager.BgmPlayer>((Action<NGSoundManager.BgmPlayer>) (v =>
    {
      v.player.SetVolume(volume);
      v.player.UpdateAll();
    }));
  }

  public void SetVolumeSe(float volume)
  {
    ((IEnumerable<CriAtomExPlayer>) this.sePlayer).ForEach<CriAtomExPlayer>((Action<CriAtomExPlayer>) (v =>
    {
      v.SetVolume(volume);
      v.UpdateAll();
    }));
  }

  public void SetVolumeVoice(float volume)
  {
    ((IEnumerable<CriAtomExPlayer>) this.voicePlayer).ForEach<CriAtomExPlayer>((Action<CriAtomExPlayer>) (v =>
    {
      v.SetVolume(volume);
      v.UpdateAll();
    }));
  }

  public CriAtomSource playBGM(string clip, float startTime = 0.1f)
  {
    this.PlayBgm(clip);
    return (CriAtomSource) null;
  }

  public void playBGM(AudioClip clip, float startTime = 0.1f) => this.PlayBgm(((Object) clip).name);

  [DebuggerHidden]
  private IEnumerator BgmCrossFade(
    CriAtomSource audio,
    float v0,
    float v1,
    float duration,
    float delay = 0.0f)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    NGSoundManager.\u003CBgmCrossFade\u003Ec__IteratorB61 fadeCIteratorB61 = new NGSoundManager.\u003CBgmCrossFade\u003Ec__IteratorB61();
    return (IEnumerator) fadeCIteratorB61;
  }

  [DebuggerHidden]
  private IEnumerator BgmCrossFade(NGSoundManager.BgmPlayer player, float aisac, float duration)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new NGSoundManager.\u003CBgmCrossFade\u003Ec__IteratorB62()
    {
      player = player,
      aisac = aisac,
      duration = duration,
      \u003C\u0024\u003Eplayer = player,
      \u003C\u0024\u003Eaisac = aisac,
      \u003C\u0024\u003Eduration = duration
    };
  }

  public void corssFadeCurrentBGM(float duration, float aisac)
  {
    this.StartCoroutine(this.BgmCrossFade(this.bgmPlayer[0], aisac, duration));
  }

  public void playBGMWithCrossFade(AudioClip clip, float duration, float startTime = 0.1f)
  {
    this.playBGMWithCrossFade(((Object) clip).name, duration, startTime);
  }

  public void playBGMWithCrossFade(string clip, float duration, float startTime = 0.1f)
  {
    this.PlayBgm(clip, fadeInTime: duration, fadeOutTime: duration);
  }

  public void playBGMWithCombineTimeFade(AudioClip clip, float duration, float startTime = 0.1f)
  {
    this.playBGMWithCombineTimeFade(((Object) clip).name, duration, startTime);
  }

  public void playBGMWithCombineTimeFade(string clip, float duration, float startTime = 0.1f)
  {
  }

  public void stopBGM() => this.StopBgm();

  public void stopBGMWithFadeOut(float duration) => this.StopBgm(time: duration);

  public CriAtomSource getNextBGMAudioSource() => (CriAtomSource) null;

  public void pauseBGM(int channel = -1) => this.PauseBgm(channel);

  public void resumeBGM(int channel = -1) => this.ResumeBgm(channel);

  public int playSE(AudioClip clip, bool isLoop = false, float delay = 0.0f)
  {
    return this.PlaySe(((Object) clip).name, isLoop, delay);
  }

  public int playSE(string clip, bool isLoop = false, float delay = 0.0f, int seChannel = -1)
  {
    return this.PlaySe(clip, isLoop, delay, seChannel);
  }

  public int playSE(int clip, bool isLoop = false) => this.PlaySe(clip, isLoop);

  public void stopSE(int channel = -1) => this.StopSe();

  public void fadeOutSE(int channel = -1, float duration = 1f) => this.StopSe(channel, duration);

  public void pauseSE(int channel = -1) => this.PauseSe(channel);

  public void resumeSE(int channel = -1) => this.ResumeSe(channel);

  public int playVoice(AudioClip clip, int channel = -1) => 0;

  public int playVoice(string clip, int channel = -1) => 0;

  public int playVoiceByID(string fileName, int id, float delay = 0.0f, int channel = -1)
  {
    return this.PlayVoice(fileName, id, channel, delay);
  }

  public int playVoiceByStringID(string fileName, string cuename, int channel = -1, float delay = 0.0f)
  {
    return this.PlayVoice(fileName, cuename, channel, delay);
  }

  public void stopVoice(int channel = -1) => this.StopVoice(channel);

  public CriAtomSource getVoiceAudioSource(int channel) => (CriAtomSource) null;

  public void OpeningStart() => this.CheckInitialize();

  public void OpeningEnd() => this.CheckInitialize();

  public void checkIfDLCEnd() => this.CheckInitialize();

  public CriAtomSource getMainBGMAudioSource() => (CriAtomSource) null;

  public void AttachDspBusSetting(string settingName, float[] _busLevel)
  {
    CriAtomEx.DetachDspBusSetting();
    CriAtomEx.AttachDspBusSetting(settingName);
    this.busLevel = _busLevel;
  }

  public void DetachDspBusSetting()
  {
    CriAtomEx.DetachDspBusSetting();
    CriAtomEx.AttachDspBusSetting("default");
    this.busLevel = this.defaultBusLevel;
  }

  private void SetBusSendLevel(bool flag, CriAtomExPlayer player)
  {
    for (int busId = 0; busId < 8; ++busId)
    {
      if ((double) this.busLevel[busId] > 0.0)
      {
        player.SetBusSendLevel(busId, 0.0f);
        player.SetBusSendLevelOffset(busId, this.busLevel[busId]);
      }
    }
  }

  public bool ExistsCueID(string name, int id)
  {
    CriAtomCueSheet cueSheet = CriAtom.GetCueSheet(name);
    return cueSheet != null && cueSheet.acb.Exists(id);
  }

  private enum InitializeState
  {
    NONE,
    DLC_BEFORE,
    DLC_AFTER,
  }

  private class BgmPlayer
  {
    public CriAtomExPlayer player = new CriAtomExPlayer();
    public string nowName = string.Empty;
    public float aisac;

    public void Stop(float time)
    {
      this.player.SetFadeOutTime((int) ((double) time * 1000.0));
      this.player.Stop((double) time == 0.0);
      this.nowName = string.Empty;
      this.aisac = 0.0f;
    }
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
    [SerializeField]
    [Range(0.0f, 1f)]
    private float mVoiceVolume = 0.8f;
    [SerializeField]
    private bool mMute;
    public bool modified;

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
