// Decompiled with JetBrains decompiler
// Type: CriMana.Player
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ECB926DA-6BA5-4E91-81B4-E3750A024FEA
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp-firstpass.dll

using AOT;
using CriMana.Detail;
using System;
using System.IO;
using System.Runtime.InteropServices;
using UnityEngine;

#nullable disable
namespace CriMana
{
  public class Player : IDisposable
  {
    private const int InvalidPlayerId = -1;
    private static Player updatingPlayer;
    private bool disposed;
    private int playerId = -1;
    private Player.Status requiredStatus;
    private Player.Status nativeStatus;
    private bool isNativeStartInvoked;
    private RendererResource rendererResource;
    private MovieInfo _movieInfo = new MovieInfo();
    private FrameInfo _frameInfo = new FrameInfo();
    private bool isMovieInfoAvailable;
    private bool isFrameInfoAvailable;
    private Player.ShaderDispatchCallback _shaderDispatchCallback;
    private bool enableSubtitle;
    private int subtitleBufferSize;
    public Player.CuePointCallback cuePointCallback;

    public Player()
    {
      CriManaPlugin.InitializeLibrary();
      this.playerId = Player.criManaUnityPlayer_Create();
      this.additiveMode = false;
    }

    public bool additiveMode { get; set; }

    public bool isFrameAvailable => this.isFrameInfoAvailable;

    public MovieInfo movieInfo => this.isMovieInfoAvailable ? this._movieInfo : (MovieInfo) null;

    public FrameInfo frameInfo => this.isFrameAvailable ? this._frameInfo : (FrameInfo) null;

    public Player.Status status
    {
      get
      {
        if (this.requiredStatus == Player.Status.Stop && this.nativeStatus != Player.Status.Stop)
          return Player.Status.StopProcessing;
        if (this.nativeStatus != Player.Status.Ready)
          return this.nativeStatus;
        return this.rendererResource != null && this.rendererResource.IsPrepared() ? Player.Status.Ready : Player.Status.Prep;
      }
    }

    public int numberOfEntries
    {
      get => this.playerId != -1 ? Player.criManaUnityPlayer_GetNumberOfEntry(this.playerId) : -1;
    }

    public IntPtr subtitleBuffer { get; private set; }

    public int subtitleSize { get; private set; }

    ~Player() => this.Dispose(false);

    public void Dispose()
    {
      this.Dispose(true);
      GC.SuppressFinalize((object) this);
    }

    public void CreateRendererResource(int width, int height, bool alpha)
    {
      MovieInfo movieInfo = new MovieInfo();
      movieInfo.hasAlpha = alpha;
      movieInfo.width = (uint) width;
      movieInfo.height = (uint) height;
      movieInfo.dispWidth = (uint) width;
      movieInfo.dispHeight = (uint) height;
      movieInfo.codecType = CodecType.SofdecPrime;
      movieInfo.alphaCodecType = CodecType.SofdecPrime;
      Shader userShader = this._shaderDispatchCallback != null ? this._shaderDispatchCallback(this.movieInfo, this.additiveMode) : (Shader) null;
      if (this.rendererResource != null && !this.rendererResource.IsSuitable(this.playerId, movieInfo, this.additiveMode, userShader))
      {
        this.rendererResource.Dispose();
        this.rendererResource = (RendererResource) null;
      }
      if (this.rendererResource != null)
        return;
      this.rendererResource = RendererResourceFactory.DispatchAndCreate(this.playerId, movieInfo, this.additiveMode, userShader);
    }

    public void DisposeRendererResource()
    {
      if (this.rendererResource == null)
        return;
      this.rendererResource.Dispose();
      this.rendererResource = (RendererResource) null;
    }

    public void Prepare()
    {
      this.PrepareNativePlayer();
      this.UpdateNativePlayer();
      this.DisableInfos();
      this.requiredStatus = Player.Status.Ready;
    }

    public void Start()
    {
      if (this.nativeStatus == Player.Status.Stop || this.nativeStatus == Player.Status.PlayEnd)
      {
        this.PrepareNativePlayer();
        this.DisableInfos();
        this.UpdateNativePlayer();
      }
      this.requiredStatus = Player.Status.Playing;
    }

    public void Stop()
    {
      Player.criManaUnityPlayer_Stop(this.playerId);
      this.UpdateNativePlayer();
      this.DisableInfos();
      this.requiredStatus = Player.Status.Stop;
    }

    public void Pause(bool sw) => Player.criManaUnityPlayer_Pause(this.playerId, !sw ? 0 : 1);

    public bool IsPaused() => Player.criManaUnityPlayer_IsPaused(this.playerId);

    public bool SetFile(CriFsBinder binder, string moviePath, Player.SetMode setMode = Player.SetMode.New)
    {
      IntPtr binder1 = binder != null ? binder.nativeHandle : IntPtr.Zero;
      if (binder == null && CriWare.IsStreamingAssetsPath(moviePath))
        moviePath = Path.Combine(CriWare.streamingAssetsPath, moviePath);
      if (setMode != Player.SetMode.New)
        return Player.criManaUnityPlayer_EntryFile(this.playerId, binder1, moviePath, setMode == Player.SetMode.AppendRepeatedly);
      Player.criManaUnityPlayer_SetFile(this.playerId, binder1, moviePath);
      return true;
    }

    public bool SetContentId(CriFsBinder binder, int contentId, Player.SetMode setMode = Player.SetMode.New)
    {
      if (binder == null)
      {
        Debug.LogError((object) "[CRIWARE] CriFsBinder is null");
        return false;
      }
      if (setMode != Player.SetMode.New)
        return Player.criManaUnityPlayer_EntryContentId(this.playerId, binder.nativeHandle, contentId, setMode == Player.SetMode.AppendRepeatedly);
      Player.criManaUnityPlayer_SetContentId(this.playerId, binder.nativeHandle, contentId);
      return true;
    }

    public bool SetFileRange(string filePath, ulong offset, long range, Player.SetMode setMode = Player.SetMode.New)
    {
      if (setMode != Player.SetMode.New)
        return Player.criManaUnityPlayer_EntryFileRange(this.playerId, filePath, offset, range, setMode == Player.SetMode.AppendRepeatedly);
      Player.criManaUnityPlayer_SetFileRange(this.playerId, filePath, offset, range);
      return true;
    }

    public void Loop(bool sw) => Player.criManaUnityPlayer_Loop(this.playerId, !sw ? 0 : 1);

    public void SetSeekPosition(int frameNumber)
    {
      Player.criManaUnityPlayer_SetSeekPosition(this.playerId, frameNumber);
    }

    public void SetSpeed(float speed) => Player.criManaUnityPlayer_SetSpeed(this.playerId, speed);

    public void SetMaxPictureDataSize(uint maxDataSize)
    {
      Player.criManaUnityPlayer_SetMaxPictureDataSize(this.playerId, maxDataSize);
    }

    public void SetBufferingTime(float sec)
    {
      Player.criManaUnityPlayer_SetBufferingTime(this.playerId, sec);
    }

    public void SetMinBufferSize(int min_buffer_size)
    {
      Player.criManaUnityPlayer_SetMinBufferSize(this.playerId, min_buffer_size);
    }

    public void SetAudioTrack(int track)
    {
      Player.criManaUnityPlayer_SetAudioTrack(this.playerId, track);
    }

    public void SetAudioTrack(Player.AudioTrack track)
    {
      if (track == Player.AudioTrack.Off)
      {
        Player.criManaUnityPlayer_SetAudioTrack(this.playerId, -1);
      }
      else
      {
        if (track != Player.AudioTrack.Auto)
          return;
        Player.criManaUnityPlayer_SetAudioTrack(this.playerId, 100);
      }
    }

    public void SetSubAudioTrack(int track)
    {
      Player.criManaUnityPlayer_SetSubAudioTrack(this.playerId, track);
    }

    public void SetSubAudioTrack(Player.AudioTrack track)
    {
      if (track == Player.AudioTrack.Off)
      {
        Player.criManaUnityPlayer_SetSubAudioTrack(this.playerId, -1);
      }
      else
      {
        if (track != Player.AudioTrack.Auto)
          return;
        Player.criManaUnityPlayer_SetSubAudioTrack(this.playerId, 100);
      }
    }

    public void SetVolume(float volume)
    {
      Player.criManaUnityPlayer_SetVolume(this.playerId, volume);
    }

    public void SetSubAudioVolume(float volume)
    {
      Player.criManaUnityPlayer_SetSubAudioVolume(this.playerId, volume);
    }

    public void SetBusSendLevel(string bus_name, float level)
    {
      Player.criManaUnityPlayer_SetBusSendLevelByName(this.playerId, bus_name, level);
    }

    public void SetSubAudioBusSendLevel(string bus_name, float volume)
    {
      Player.criManaUnityPlayer_SetSubAudioBusSendLevelByName(this.playerId, bus_name, volume);
    }

    public void SetSubtitleChannel(int channel)
    {
      this.enableSubtitle = channel != -1;
      if (this.enableSubtitle)
      {
        if (this.isMovieInfoAvailable)
          this.AllocateSubtitleBuffer((int) this.movieInfo.maxSubtitleSize);
      }
      else
        this.DeallocateSubtitleBuffer();
      Player.criManaUnityPlayer_SetSubtitleChannel(this.playerId, channel);
    }

    public void SetShaderDispatchCallback(
      Player.ShaderDispatchCallback shaderDispatchCallback)
    {
      this._shaderDispatchCallback = shaderDispatchCallback;
    }

    public void Update()
    {
      if (this.requiredStatus == Player.Status.Stop)
      {
        if (this.nativeStatus == Player.Status.Stop)
          return;
        this.UpdateNativePlayer();
      }
      else
      {
        switch (this.nativeStatus)
        {
          case Player.Status.Dechead:
            this.UpdateNativePlayer();
            if (this.nativeStatus != Player.Status.WaitPrep)
              break;
            goto case Player.Status.WaitPrep;
          case Player.Status.WaitPrep:
            if (!this.isMovieInfoAvailable)
            {
              Player.criManaUnityPlayer_GetMovieInfo(this.playerId, this._movieInfo);
              this.isMovieInfoAvailable = true;
              if (this.enableSubtitle)
                this.AllocateSubtitleBuffer((int) this.movieInfo.maxSubtitleSize);
              Shader userShader = this._shaderDispatchCallback != null ? this._shaderDispatchCallback(this.movieInfo, this.additiveMode) : (Shader) null;
              if (this.rendererResource != null && !this.rendererResource.IsSuitable(this.playerId, this._movieInfo, this.additiveMode, userShader))
              {
                this.rendererResource.Dispose();
                this.rendererResource = (RendererResource) null;
              }
              if (this.rendererResource == null)
              {
                this.rendererResource = RendererResourceFactory.DispatchAndCreate(this.playerId, this._movieInfo, this.additiveMode, userShader);
                if (this.rendererResource == null)
                {
                  this.Stop();
                  return;
                }
              }
            }
            if (!this.rendererResource.IsPrepared())
            {
              this.rendererResource.ContinuePreparing();
              if (!this.rendererResource.IsPrepared())
                break;
            }
            this.rendererResource.AttachToPlayer(this.playerId);
            if (this.requiredStatus != Player.Status.Ready)
            {
              if (this.requiredStatus == Player.Status.Playing)
              {
                Player.criManaUnityPlayer_Start(this.playerId);
                this.isNativeStartInvoked = true;
                goto case Player.Status.Prep;
              }
              else
                break;
            }
            else
              goto case Player.Status.Prep;
          case Player.Status.Prep:
            this.UpdateNativePlayer();
            if (this.nativeStatus != Player.Status.Ready)
            {
              if (this.nativeStatus != Player.Status.Playing)
                break;
              goto case Player.Status.Playing;
            }
            else
              goto case Player.Status.Ready;
          case Player.Status.Ready:
            if (this.requiredStatus == Player.Status.Playing)
            {
              if (!this.isNativeStartInvoked)
              {
                Player.criManaUnityPlayer_Start(this.playerId);
                this.isNativeStartInvoked = true;
                goto case Player.Status.Playing;
              }
              else
                goto case Player.Status.Playing;
            }
            else
              break;
          case Player.Status.Playing:
            this.UpdateNativePlayer();
            if (this.nativeStatus == Player.Status.Playing)
            {
              this.isFrameInfoAvailable |= this.rendererResource.UpdateFrame(this.playerId, this._frameInfo);
              break;
            }
            if (this.nativeStatus != Player.Status.PlayEnd)
              break;
            break;
          case Player.Status.Error:
            this.UpdateNativePlayer();
            break;
        }
        if (this.nativeStatus != Player.Status.Error)
          return;
        this.DisableInfos();
      }
    }

    public bool UpdateMaterial(Material material)
    {
      return this.rendererResource != null && this.isFrameInfoAvailable && this.rendererResource.UpdateMaterial(material);
    }

    [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
    private static extern IntPtr criWareUnity_GetRenderEventFunc();

    public void IssuePluginEvent()
    {
      if (this.status != Player.Status.Ready && this.status != Player.Status.Playing)
        return;
      GL.IssuePluginEvent(Player.criWareUnity_GetRenderEventFunc(), this.playerId + CriManaPlugin.renderingEventOffset);
    }

    private void Dispose(bool disposing)
    {
      if (this.disposed)
        return;
      if (this.playerId != -1)
      {
        Player.criManaUnityPlayer_Destroy(this.playerId);
        this.playerId = -1;
      }
      this.DisposeRendererResource();
      this.DeallocateSubtitleBuffer();
      CriManaPlugin.FinalizeLibrary();
      this.cuePointCallback = (Player.CuePointCallback) null;
      this.disposed = true;
    }

    private void DisableInfos()
    {
      this.isMovieInfoAvailable = false;
      this.isFrameInfoAvailable = false;
      this.isNativeStartInvoked = false;
      this.subtitleSize = 0;
    }

    private void PrepareNativePlayer()
    {
      if (this.cuePointCallback != null)
        Player.criManaUnityPlayer_SetCuePointCallback(this.playerId, new Player.CuePointCallbackFromNativeDelegate(Player.CuePointCallbackFromNative));
      Player.criManaUnityPlayer_Prepare(this.playerId);
    }

    private void UpdateNativePlayer()
    {
      Player.updatingPlayer = this;
      uint subtitleBufferSize = (uint) this.subtitleBufferSize;
      this.nativeStatus = (Player.Status) Player.criManaUnityPlayer_Update(this.playerId, this.subtitleBuffer, ref subtitleBufferSize);
      this.subtitleSize = (int) subtitleBufferSize;
      Player.updatingPlayer = (Player) null;
    }

    private void AllocateSubtitleBuffer(int size)
    {
      if (this.subtitleBufferSize >= size)
        return;
      this.DeallocateSubtitleBuffer();
      this.subtitleBuffer = Marshal.AllocHGlobal(size);
      this.subtitleBufferSize = size;
      this.subtitleSize = 0;
    }

    private void DeallocateSubtitleBuffer()
    {
      if (!(this.subtitleBuffer != IntPtr.Zero))
        return;
      Marshal.FreeHGlobal(this.subtitleBuffer);
      this.subtitleBuffer = IntPtr.Zero;
      this.subtitleBufferSize = 0;
      this.subtitleSize = 0;
    }

    [MonoPInvokeCallback(typeof (Player.CuePointCallbackFromNativeDelegate))]
    private static void CuePointCallbackFromNative(
      IntPtr ptr1,
      IntPtr ptr2,
      [In] ref EventPoint eventPoint)
    {
      if (Player.updatingPlayer.cuePointCallback == null)
        return;
      Player.updatingPlayer.cuePointCallback(ref eventPoint);
    }

    [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
    private static extern int criManaUnityPlayer_Create();

    [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
    private static extern void criManaUnityPlayer_Destroy(int player_id);

    [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
    private static extern void criManaUnityPlayer_SetFile(
      int player_id,
      IntPtr binder,
      string path);

    [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
    private static extern void criManaUnityPlayer_SetContentId(
      int player_id,
      IntPtr binder,
      int content_id);

    [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
    private static extern void criManaUnityPlayer_SetFileRange(
      int player_id,
      string path,
      ulong offset,
      long range);

    [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
    private static extern bool criManaUnityPlayer_EntryFile(
      int player_id,
      IntPtr binder,
      string path,
      bool repeat);

    [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
    private static extern bool criManaUnityPlayer_EntryContentId(
      int player_id,
      IntPtr binder,
      int content_id,
      bool repeat);

    [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
    private static extern bool criManaUnityPlayer_EntryFileRange(
      int player_id,
      string path,
      ulong offset,
      long range,
      bool repeat);

    [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
    private static extern void criManaUnityPlayer_ClearEntry(int player_id);

    [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
    private static extern int criManaUnityPlayer_GetNumberOfEntry(int player_id);

    [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
    private static extern void criManaUnityPlayer_SetCuePointCallback(
      int player_id,
      Player.CuePointCallbackFromNativeDelegate cbfunc);

    [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
    private static extern void criManaUnityPlayer_GetMovieInfo(int player_id, [Out] MovieInfo movie_info);

    [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
    private static extern int criManaUnityPlayer_Update(
      int player_id,
      IntPtr subtitle_buffer,
      ref uint subtitle_size);

    [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
    private static extern void criManaUnityPlayer_Prepare(int player_id);

    [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
    private static extern void criManaUnityPlayer_Start(int player_id);

    [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
    private static extern void criManaUnityPlayer_Stop(int player_id);

    [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
    private static extern void criManaUnityPlayer_SetSeekPosition(int player_id, int seek_frame_no);

    [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
    private static extern void criManaUnityPlayer_Pause(int player_id, int sw);

    [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
    private static extern bool criManaUnityPlayer_IsPaused(int player_id);

    [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
    private static extern void criManaUnityPlayer_Loop(int player_id, int sw);

    [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
    private static extern long criManaUnityPlayer_GetTime(int player_id);

    [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
    private static extern int criManaUnityPlayer_GetStatus(int player_id);

    [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
    private static extern void criManaUnityPlayer_SetAudioTrack(int player_id, int track);

    [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
    private static extern void criManaUnityPlayer_SetVolume(int player_id, float vol);

    [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
    private static extern void criManaUnityPlayer_SetSubAudioTrack(int player_id, int track);

    [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
    private static extern void criManaUnityPlayer_SetSubAudioVolume(int player_id, float vol);

    [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
    private static extern void criManaUnityPlayer_SetBusSendLevelByName(
      int player_id,
      string bus_name,
      float level);

    [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
    private static extern void criManaUnityPlayer_SetSubAudioBusSendLevelByName(
      int player_id,
      string bus_name,
      float level);

    [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
    private static extern void criManaUnityPlayer_SetSubtitleChannel(int player_id, int channel);

    [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
    private static extern void criManaUnityPlayer_SetSpeed(int player_id, float speed);

    [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
    private static extern void criManaUnityPlayer_SetDeviceSendLevel(
      int player_id,
      int device_id,
      float level);

    [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
    private static extern void criManaUnityPlayer_SetMaxPictureDataSize(
      int player_id,
      uint max_data_size);

    [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
    public static extern void criManaUnityPlayer_SetBufferingTime(int player_id, float sec);

    [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
    public static extern void criManaUnityPlayer_SetMinBufferSize(
      int player_id,
      int min_buffer_size);

    public enum Status
    {
      Stop,
      Dechead,
      WaitPrep,
      Prep,
      Ready,
      Playing,
      PlayEnd,
      Error,
      StopProcessing,
    }

    public enum SetMode
    {
      New,
      Append,
      AppendRepeatedly,
    }

    public enum AudioTrack
    {
      Off,
      Auto,
    }

    public delegate void CuePointCallback(ref EventPoint eventPoint);

    public delegate Shader ShaderDispatchCallback(MovieInfo movieInfo, bool additiveMode);

    private delegate void CuePointCallbackFromNativeDelegate(
      IntPtr ptr1,
      IntPtr ptr2,
      [In] ref EventPoint eventPoint);
  }
}
