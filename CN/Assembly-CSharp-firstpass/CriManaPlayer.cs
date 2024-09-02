// Decompiled with JetBrains decompiler
// Type: CriManaPlayer
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FC6F22C0-326E-48ED-B5EE-59590337E752
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp-firstpass.dll

using AOT;
using CriMana;
using CriManaPlayerDetail;
using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using UnityEngine;

#nullable disable
[AddComponentMenu("CRIWARE/CRI Mana Player")]
public class CriManaPlayer : MonoBehaviour
{
  public const CriManaPlayer.ShaderType RequiredShaderType = CriManaPlayer.ShaderType.Yuv2Rgb;
  private const int InvalidPlayerId = -1;
  private static CriManaPlayer updatingPlayer;
  private System.Action setFileDelegate;
  private int playerId = -1;
  private TextureHolder texture_holder;
  private bool setupOnceFlag;
  private bool prepareRequire;
  private bool playRequire;
  private bool stopRequire;
  private bool gotFirstFrame;
  private bool gotMovieInfo;
  private bool seekRequired;
  private int seekFrameNumber;
  private int pauseCallCount;
  private int onApplicationPauseCallCount;
  private bool unpauseOnApplicationUnpause;
  private Material originalMaterial;
  private Material createdMaterial;
  [SerializeField]
  private Material _movieMaterial;
  private Shader movieShader;
  private CriFsBinder _binder;
  private Func<bool, bool, Shader> _shaderDispatchFunction = new Func<bool, bool, Shader>(CriManaPlayer.DefaultShaderDispatchFunction);
  private CriManaPlayer.CuePointCbFunc cuePointUserCbFunc;
  [SerializeField]
  private uint _texNumber = 2;
  [SerializeField]
  private string _moviePath = string.Empty;
  [SerializeField]
  private bool _playOnStart;
  [SerializeField]
  private bool _loop;
  [SerializeField]
  private float _volume = 1f;
  [SerializeField]
  private float _subAudioVolume = 1f;
  [SerializeField]
  private float _speed = 1f;
  [SerializeField]
  private bool _additiveMode;
  [SerializeField]
  private bool _flipTopBottom = true;
  [SerializeField]
  private bool _flipLeftRight = true;
  private CriManaPlayer.MovieInfo _movieInfo = new CriManaPlayer.MovieInfo();
  private CriManaPlayer.FrameInfo _frameInfo = new CriManaPlayer.FrameInfo();

  public static Shader DefaultShaderDispatchFunction(bool alpha, bool additive)
  {
    Shader shader = !alpha ? Shader.Find(!additive ? "CriMana/Yuv2Rgb" : "CriMana/Yuv2RgbAdditive") : Shader.Find(!additive ? "CriMana/Yuva2Rgba" : "CriMana/Yuva2RgbaAdditive");
    if (Object.op_Equality((Object) shader, (Object) null))
    {
      Debug.LogError((object) "Can't find CriMana Sharder. Probably, the link from a material to shader has broken. Please reimport 'CRIWARE SDK for Unity'.");
      shader = Shader.Find("Diffuse");
    }
    return shader;
  }

  public Func<bool, bool, Shader> shaderDispatchFunction
  {
    set => this._shaderDispatchFunction = value;
    get => this._shaderDispatchFunction;
  }

  [Obsolete("This property is obsolete; use shaderDispatchFunction instead", false)]
  public Func<bool, bool, Shader> shaderDispachFunction
  {
    set => this.shaderDispatchFunction = value;
    get => this.shaderDispatchFunction;
  }

  public uint texNumber
  {
    set
    {
      if (CriManaPlugin.isMultithreadedRenderingEnabled)
        this._texNumber = 1U;
      else
        this._texNumber = value;
    }
    get => CriManaPlugin.isMultithreadedRenderingEnabled ? 1U : this._texNumber;
  }

  public CriFsBinder binder
  {
    private set => this._binder = value;
    get => this._binder;
  }

  public string moviePath
  {
    set => this._moviePath = value;
    get => this._moviePath;
  }

  public bool playOnStart
  {
    set => this._playOnStart = value;
    get => this._playOnStart;
  }

  public bool loop
  {
    set
    {
      this._loop = value;
      if (this.playerId == -1)
        return;
      CriManaPlayer.criManaUnityPlayer_Loop_APIv1(this.playerId, !this._loop ? 0 : 1);
    }
    get => this._loop;
  }

  public float volume
  {
    set
    {
      this._volume = value;
      if (this.playerId == -1)
        return;
      CriManaPlayer.criManaUnityPlayer_SetVolume_APIv1(this.playerId, this._volume);
    }
    get => this._volume;
  }

  public float subAudioVolume
  {
    set
    {
      this._subAudioVolume = value;
      if (this.playerId == -1)
        return;
      CriManaPlayer.criManaUnityPlayer_SetSubAudioVolume_APIv1(this.playerId, this._subAudioVolume);
    }
    get => this._subAudioVolume;
  }

  public float speed
  {
    set
    {
      if ((double) value < 0.0)
        return;
      this._speed = value;
      if (this.playerId == -1)
        return;
      CriManaPlayer.criManaUnityPlayer_SetSpeed_APIv1(this.playerId, this._speed);
    }
    get => this._speed;
  }

  public Material movieMaterial
  {
    set => this._movieMaterial = value;
    get => this._movieMaterial;
  }

  public bool flipTopBottom
  {
    set
    {
      this._flipTopBottom = value;
      this.SetTextureConfigIfTextureHolderIsNotNull();
    }
    get => this._flipTopBottom;
  }

  public bool flipLeftRight
  {
    set
    {
      this._flipLeftRight = value;
      this.SetTextureConfigIfTextureHolderIsNotNull();
    }
    get => this._flipLeftRight;
  }

  public bool additiveMode
  {
    set => this._additiveMode = value;
    get => this._additiveMode;
  }

  public CriManaPlayer.MovieInfo movieInfo => this._movieInfo;

  public CriManaPlayer.FrameInfo frameInfo
  {
    private set => this._frameInfo = value;
    get => this._frameInfo;
  }

  public uint width => this.movieInfo.disp_width;

  public uint height => this.movieInfo.disp_height;

  public CriManaPlayer.Status status
  {
    get
    {
      if (this.playerId == -1)
        return CriManaPlayer.Status.Stop;
      CriManaPlayer.Status statusApIv1 = (CriManaPlayer.Status) CriManaPlayer.criManaUnityPlayer_GetStatus_APIv1(this.playerId);
      return statusApIv1 == CriManaPlayer.Status.Ready && this.texture_holder == null ? CriManaPlayer.Status.Prep : statusApIv1;
    }
  }

  public int numberOfEntries
  {
    get
    {
      return this.playerId != -1 ? CriManaPlayer.criManaUnityPlayer_GetNumberOfEntry_APIv1(this.playerId) : -1;
    }
  }

  public bool frameUpdated { private set; get; }

  public bool SetFile(CriFsBinder argBinder, string argMoviePath, CriManaPlayer.SetMode setMode = CriManaPlayer.SetMode.New)
  {
    IntPtr binderPtr = argBinder != null ? argBinder.nativeHandle : IntPtr.Zero;
    string trueMoviePath = argBinder == null ? (!CriWare.IsStreamingAssetsPath(argMoviePath) ? argMoviePath : Path.Combine(CriWare.streamingAssetsPath, argMoviePath)) : argMoviePath;
    int num;
    switch (setMode)
    {
      case CriManaPlayer.SetMode.New:
        CriManaPlayer.criManaUnityPlayer_ClearEntry_APIv1(this.playerId);
        this.binder = argBinder;
        this.moviePath = argMoviePath;
        this.setFileDelegate = (System.Action) (() => CriManaPlayer.criManaUnityPlayer_SetFile_APIv1(this.playerId, binderPtr, trueMoviePath));
        return true;
      case CriManaPlayer.SetMode.AppendRepeatedly:
        num = 1;
        break;
      default:
        num = 0;
        break;
    }
    bool repeat = num != 0;
    return CriManaPlayer.criManaUnityPlayer_EntryFile_APIv1(this.playerId, binderPtr, trueMoviePath, repeat);
  }

  public bool SetContentId(CriFsBinder argBinder, int contentId, CriManaPlayer.SetMode setMode = CriManaPlayer.SetMode.New)
  {
    if (argBinder == null)
      Debug.LogError((object) "[CRIWARE] CriFsBinder is null");
    int num;
    switch (setMode)
    {
      case CriManaPlayer.SetMode.New:
        CriManaPlayer.criManaUnityPlayer_ClearEntry_APIv1(this.playerId);
        this.binder = argBinder;
        this.moviePath = string.Empty;
        this.setFileDelegate = (System.Action) (() => CriManaPlayer.criManaUnityPlayer_SetContentId_APIv1(this.playerId, this.binder.nativeHandle, contentId));
        return true;
      case CriManaPlayer.SetMode.AppendRepeatedly:
        num = 1;
        break;
      default:
        num = 0;
        break;
    }
    bool repeat = num != 0;
    return CriManaPlayer.criManaUnityPlayer_EntryContentId_APIv1(this.playerId, argBinder.nativeHandle, contentId, repeat);
  }

  public bool SetFileRange(
    string filePath,
    ulong offset,
    long range,
    CriManaPlayer.SetMode setMode = CriManaPlayer.SetMode.New)
  {
    int num;
    switch (setMode)
    {
      case CriManaPlayer.SetMode.New:
        CriManaPlayer.criManaUnityPlayer_ClearEntry_APIv1(this.playerId);
        this.binder = (CriFsBinder) null;
        this.moviePath = filePath;
        this.setFileDelegate = (System.Action) (() => CriManaPlayer.criManaUnityPlayer_SetFileRange_APIv1(this.playerId, filePath, offset, range));
        return true;
      case CriManaPlayer.SetMode.AppendRepeatedly:
        num = 1;
        break;
      default:
        num = 0;
        break;
    }
    bool repeat = num != 0;
    return CriManaPlayer.criManaUnityPlayer_EntryFileRange_APIv1(this.playerId, filePath, offset, range, repeat);
  }

  public void Prepare()
  {
    this.SetupCallOnce();
    this.prepareRequire = true;
    this.UpdatePlayer();
  }

  public void Play()
  {
    this.SetupCallOnce();
    this.gotFirstFrame = false;
    this.playRequire = true;
    this.UpdatePlayer();
  }

  public void Stop()
  {
    if (Object.op_Inequality((Object) this.originalMaterial, (Object) null) && Object.op_Inequality((Object) ((Component) this).GetComponent<Renderer>(), (Object) null))
      ((Component) this).GetComponent<Renderer>().material = this.originalMaterial;
    CriManaPlayer.criManaUnityPlayer_Stop_APIv1(this.playerId);
    this.prepareRequire = false;
    this.playRequire = false;
    this.gotFirstFrame = false;
    this.stopRequire = true;
  }

  public void Pause(bool sw)
  {
    if (this.playerId == -1)
      return;
    CriManaPlayer.criManaUnityPlayer_Pause_APIv1(this.playerId, !sw ? 0 : 1);
  }

  public bool IsPaused() => CriManaPlayer.criManaUnityPlayer_IsPaused_APIv1(this.playerId);

  public long GetTime()
  {
    return this.playerId != -1 ? CriManaPlayer.criManaUnityPlayer_GetTime_APIv1(this.playerId) : 0L;
  }

  public uint GetTotalFrames() => this.playerId != -1 ? this.movieInfo.total_frames : 0U;

  public uint GetFramerate() => this.playerId != -1 ? this.movieInfo.framerate_n : 0U;

  public CriManaPlayer.Status GetStatus() => this.status;

  public void SetCuePointCallback(CriManaPlayer.CuePointCbFunc func)
  {
    this.cuePointUserCbFunc = func;
    CriManaPlayer.criManaUnityPlayer_SetCuePointCallback_APIv1(this.playerId, new CriManaPlayer.CuePointCallbackFromNativeDelegate(CriManaPlayer.CuePointCallbackFromNative));
  }

  public void SetSeekPosition(int argSeekFrameNumber)
  {
    this.seekFrameNumber = argSeekFrameNumber;
    this.seekRequired = true;
  }

  public void SetDeviceSendLevel(int deviceId, float level)
  {
  }

  public void SetAudioTrack(int track)
  {
    if (this.playerId == -1)
      return;
    CriManaPlayer.criManaUnityPlayer_SetAudioTrack_APIv1(this.playerId, track);
  }

  public void SetAudioTrack(CriManaPlayer.AudioTrack track)
  {
    if (this.playerId == -1)
      return;
    if (track == CriManaPlayer.AudioTrack.Off)
    {
      CriManaPlayer.criManaUnityPlayer_SetAudioTrack_APIv1(this.playerId, -1);
    }
    else
    {
      if (track != CriManaPlayer.AudioTrack.Auto)
        return;
      CriManaPlayer.criManaUnityPlayer_SetAudioTrack_APIv1(this.playerId, 100);
    }
  }

  public void SetSubAudioTrack(int track)
  {
    if (this.playerId == -1)
      return;
    CriManaPlayer.criManaUnityPlayer_SetSubAudioTrack_APIv1(this.playerId, track);
  }

  public void SetSubAudioTrack(CriManaPlayer.AudioTrack track)
  {
    if (this.playerId == -1)
      return;
    if (track == CriManaPlayer.AudioTrack.Off)
    {
      CriManaPlayer.criManaUnityPlayer_SetSubAudioTrack_APIv1(this.playerId, -1);
    }
    else
    {
      if (track != CriManaPlayer.AudioTrack.Auto)
        return;
      CriManaPlayer.criManaUnityPlayer_SetSubAudioTrack_APIv1(this.playerId, 100);
    }
  }

  public void SetBufferingTime(float sec)
  {
    CriManaPlayer.criManaUnityPlayer_SetBufferingTime_APIv1(this.playerId, sec);
  }

  public void SetMinBufferSize(int min_buffer_size)
  {
    CriManaPlayer.criManaUnityPlayer_SetMinBufferSize_APIv1(this.playerId, min_buffer_size);
  }

  public void CreateTexture(int argWidth, int argHeight, bool alphaMode, bool coroutineMode)
  {
    if (this.texture_holder != null && !this.texture_holder.IsAvailable(argWidth, argHeight, this.texNumber, alphaMode))
      this.DestroyTexture();
    if (this.texture_holder != null)
      return;
    IEnumerator textureByCoroutine = this.CreateTextureByCoroutine(TextureHolder.Create(argWidth, argHeight, this.texNumber, alphaMode));
    if (coroutineMode)
    {
      this.StartCoroutine(textureByCoroutine);
    }
    else
    {
      do
        ;
      while (textureByCoroutine.MoveNext());
    }
  }

  public void DestroyTexture()
  {
    if (this.texture_holder == null)
      return;
    this.texture_holder.DestroyTexture();
    this.texture_holder = (TextureHolder) null;
  }

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern IntPtr criWareUnity_GetRenderEventFunc_APIv1();

  private void Awake()
  {
    CriManaPlugin.InitializeLibrary();
    this.playerId = CriManaPlayer.criManaUnityPlayer_Create_APIv1();
    this.frameUpdated = false;
  }

  private void OnEnable()
  {
  }

  private void Start()
  {
    this.SetupCallOnce();
    if (this.playOnStart)
      this.Play();
    if (!CriManaPlugin.isMultithreadedRenderingEnabled)
      return;
    this.StartCoroutine(this.CallPluginAtEndOfFrames());
  }

  [DebuggerHidden]
  private IEnumerator CallPluginAtEndOfFrames()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new CriManaPlayer.\u003CCallPluginAtEndOfFrames\u003Ec__Iterator2()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void OnDisable() => this.Stop();

  private void OnDestroy()
  {
    this.movieMaterial = (Material) null;
    this.originalMaterial = (Material) null;
    if (Object.op_Inequality((Object) this.createdMaterial, (Object) null))
      Object.DestroyImmediate((Object) this.createdMaterial);
    this.createdMaterial = (Material) null;
    this.DestroyTexture();
    if (this.playerId != -1)
    {
      CriManaPlayer.criManaUnityPlayer_Destroy_APIv1(this.playerId);
      this.playerId = -1;
    }
    this.cuePointUserCbFunc = (CriManaPlayer.CuePointCbFunc) null;
    CriManaPlugin.FinalizeLibrary();
  }

  private bool CheckPauseCount(ref int currentCount, bool pause)
  {
    currentCount = !pause ? currentCount - 1 : currentCount + 1;
    if (pause && currentCount > 1)
      return false;
    if (pause || currentCount == 0)
      return true;
    currentCount = currentCount <= 0 ? 0 : currentCount;
    return false;
  }

  private void OnApplicationPause(bool appPause)
  {
    if (!this.CheckPauseCount(ref this.onApplicationPauseCallCount, appPause))
      return;
    this.ProcessApplicationPause(appPause);
  }

  private void ProcessApplicationPause(bool appPause)
  {
    if (!this.CheckPauseCount(ref this.pauseCallCount, appPause))
      return;
    if (appPause)
    {
      this.unpauseOnApplicationUnpause = !this.IsPaused();
      if (!this.unpauseOnApplicationUnpause)
        return;
      this.Pause(true);
    }
    else
    {
      if (this.unpauseOnApplicationUnpause)
        this.Pause(false);
      this.unpauseOnApplicationUnpause = false;
    }
  }

  public void Update() => this.UpdatePlayer();

  public void OnDrawGizmos()
  {
    Gizmos.color = this.status != CriManaPlayer.Status.Playing ? new Color(1f, 1f, 1f, 0.5f) : new Color(1f, 1f, 1f, 0.8f);
    Gizmos.DrawIcon(((Component) this).transform.position, "CriWare/film.png");
    Gizmos.DrawLine(((Component) this).transform.position, new Vector3(0.0f, 0.0f, 0.0f));
  }

  private void SetupCallOnce()
  {
    if (this.setupOnceFlag)
      return;
    if (Object.op_Equality((Object) this.movieMaterial, (Object) null))
    {
      if (Object.op_Inequality((Object) ((Component) this).GetComponent<Renderer>(), (Object) null))
        this.originalMaterial = ((Component) this).GetComponent<Renderer>().sharedMaterial;
      Shader shader = Shader.Find("CriMana/ForwardRgb");
      if (Object.op_Equality((Object) shader, (Object) null))
      {
        Debug.LogError((object) "Can't find CriMana Sharder. Probably, the link from a material to shader has broken. Please reimport 'CRIWARE SDK for Unity'.");
        shader = Shader.Find("Diffuse");
      }
      this.createdMaterial = new Material(shader);
      this.movieMaterial = this.createdMaterial;
    }
    if (this.setFileDelegate == null)
      this.setFileDelegate = (System.Action) (() =>
      {
        string path = !CriWare.IsStreamingAssetsPath(this.moviePath) ? this.moviePath : Path.Combine(CriWare.streamingAssetsPath, this.moviePath);
        CriManaPlayer.criManaUnityPlayer_SetFile_APIv1(this.playerId, IntPtr.Zero, path);
      });
    this.frameUpdated = false;
    this.loop = this._loop;
    this.volume = this._volume;
    this.subAudioVolume = this._subAudioVolume;
    this.playRequire = this._playOnStart;
    this.setupOnceFlag = true;
  }

  [DebuggerHidden]
  private IEnumerator CreateTextureByCoroutine(TextureHolder texture_holder)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new CriManaPlayer.\u003CCreateTextureByCoroutine\u003Ec__Iterator3()
    {
      texture_holder = texture_holder,
      \u003C\u0024\u003Etexture_holder = texture_holder,
      \u003C\u003Ef__this = this
    };
  }

  private void GetMovieInfoAndCreateTextureIfNotYet()
  {
    if (this.gotMovieInfo)
      return;
    CriManaPlayer.criManaUnityPlayer_GetMovieInfo_APIv1(this.playerId, this._movieInfo);
    this.movieShader = this.shaderDispatchFunction(this.movieInfo.has_alpha == 1U, this.additiveMode);
    this.CreateTexture((int) this.movieInfo.disp_width, (int) this.movieInfo.disp_height, this.movieInfo.has_alpha == 1U, true);
    this.gotMovieInfo = true;
  }

  private void UpdatePlayer()
  {
    this.frameUpdated = false;
    if (this.playerId == -1)
      return;
    CriManaPlayer.updatingPlayer = this;
    CriManaPlayer.criManaUnityPlayer_Update_APIv1(this.playerId);
    switch (CriManaPlayer.criManaUnityPlayer_GetStatus_APIv1(this.playerId))
    {
      case 0:
        if (this.playRequire || this.prepareRequire)
        {
          this.setFileDelegate();
          if (this.seekRequired)
            CriManaPlayer.criManaUnityPlayer_SetSeekPosition_APIv1(this.playerId, this.seekFrameNumber);
          CriManaPlayer.criManaUnityPlayer_Prepare_APIv1(this.playerId);
          CriManaPlayer.criManaUnityPlayer_Update_APIv1(this.playerId);
          this.seekRequired = false;
          this.stopRequire = false;
          this.gotMovieInfo = false;
          this.frameUpdated = false;
          this.gotFirstFrame = false;
          this.prepareRequire = false;
          break;
        }
        break;
      case 3:
        if (!this.stopRequire)
        {
          this.GetMovieInfoAndCreateTextureIfNotYet();
          break;
        }
        break;
      case 4:
        if (!this.stopRequire)
        {
          this.GetMovieInfoAndCreateTextureIfNotYet();
          if (this.texture_holder != null && this.playRequire)
          {
            CriManaPlayer.criManaUnityPlayer_Start_APIv1(this.playerId);
            CriManaPlayer.criManaUnityPlayer_Update_APIv1(this.playerId);
            this.playRequire = false;
            this.UpdateFrame();
            break;
          }
          break;
        }
        break;
      case 5:
        if (!this.stopRequire)
        {
          this.UpdateFrame();
          break;
        }
        break;
      case 6:
        if (this.numberOfEntries > 0)
        {
          CriManaPlayer.criManaUnityPlayer_ClearEntry_APIv1(this.playerId);
          goto case 0;
        }
        else
          goto case 0;
    }
    CriManaPlayer.updatingPlayer = (CriManaPlayer) null;
  }

  private void UpdateFrame()
  {
    if (this.gotFirstFrame)
    {
      this.frameUpdated = this.texture_holder.UpdateTexture(this.movieMaterial, this.playerId, this._frameInfo);
    }
    else
    {
      Shader shader = this.movieMaterial.shader;
      this.movieMaterial.shader = this.movieShader;
      this.frameUpdated = this.texture_holder.UpdateTexture(this.movieMaterial, this.playerId, this._frameInfo);
      if (this.frameUpdated)
      {
        if (Object.op_Inequality((Object) this.originalMaterial, (Object) null) && Object.op_Inequality((Object) ((Component) this).GetComponent<Renderer>(), (Object) null))
          ((Component) this).GetComponent<Renderer>().material = this.movieMaterial;
        this.SetTextureConfigIfTextureHolderIsNotNull();
        this.movieShader = (Shader) null;
        this.gotFirstFrame = true;
      }
      else
        this.movieMaterial.shader = shader;
    }
  }

  private void SetTextureConfigIfTextureHolderIsNotNull()
  {
    if (this.texture_holder == null)
      return;
    this.texture_holder.SetTextureConfig(this.movieMaterial, (int) this.movieInfo.disp_width, (int) this.movieInfo.disp_height, this.flipTopBottom, this.flipLeftRight);
  }

  [MonoPInvokeCallback(typeof (CriManaPlayer.CuePointCallbackFromNativeDelegate))]
  private static void CuePointCallbackFromNative(
    IntPtr ptr1,
    IntPtr ptr2,
    [In] ref EventPoint eventPoint)
  {
    if (CriManaPlayer.updatingPlayer.cuePointUserCbFunc == null)
      return;
    string stringUni1 = !(eventPoint.cueName == IntPtr.Zero) ? Marshal.PtrToStringUni(eventPoint.cueName, (int) eventPoint.cueNameSize) : (string) null;
    string stringUni2 = !(eventPoint.paramString == IntPtr.Zero) ? Marshal.PtrToStringUni(eventPoint.paramString, (int) eventPoint.paramStringSize) : (string) null;
    string eventParamsString = string.Format("{1,20:D20}{0}{2,10:D10}{0}{3,10:D10}{0}{4}{0}{5}", (object) CriManaPlugin.cuePointFormatDelimiter, (object) eventPoint.time, (object) eventPoint.tunit, (object) eventPoint.type, (object) stringUni1, (object) stringUni2);
    CriManaPlayer.updatingPlayer.cuePointUserCbFunc(eventParamsString);
  }

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern int criManaUnityPlayer_Create_APIv1();

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern void criManaUnityPlayer_Destroy_APIv1(int player_id);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern void criManaUnityPlayer_SetFile_APIv1(
    int player_id,
    IntPtr binder,
    string path);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern void criManaUnityPlayer_SetContentId_APIv1(
    int player_id,
    IntPtr binder,
    int content_id);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern void criManaUnityPlayer_SetFileRange_APIv1(
    int player_id,
    string path,
    ulong offset,
    long range);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern bool criManaUnityPlayer_EntryFile_APIv1(
    int player_id,
    IntPtr binder,
    string path,
    bool repeat);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern bool criManaUnityPlayer_EntryContentId_APIv1(
    int player_id,
    IntPtr binder,
    int content_id,
    bool repeat);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern bool criManaUnityPlayer_EntryFileRange_APIv1(
    int player_id,
    string path,
    ulong offset,
    long range,
    bool repeat);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern void criManaUnityPlayer_ClearEntry_APIv1(int player_id);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern int criManaUnityPlayer_GetNumberOfEntry_APIv1(int player_id);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern void criManaUnityPlayer_SetCuePointCallback_APIv1(
    int player_id,
    CriManaPlayer.CuePointCallbackFromNativeDelegate cbfunc);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern void criManaUnityPlayer_GetMovieInfo_APIv1(
    int player_id,
    [Out] CriManaPlayer.MovieInfo movie_info);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern int criManaUnityPlayer_Update_APIv1(int player_id);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern void criManaUnityPlayer_Prepare_APIv1(int player_id);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern void criManaUnityPlayer_Start_APIv1(int player_id);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern void criManaUnityPlayer_Stop_APIv1(int player_id);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern void criManaUnityPlayer_SetSeekPosition_APIv1(
    int player_id,
    int seek_frame_no);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern void criManaUnityPlayer_Pause_APIv1(int player_id, int sw);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern bool criManaUnityPlayer_IsPaused_APIv1(int player_id);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern void criManaUnityPlayer_Loop_APIv1(int player_id, int sw);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern long criManaUnityPlayer_GetTime_APIv1(int player_id);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern int criManaUnityPlayer_GetStatus_APIv1(int player_id);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern void criManaUnityPlayer_SetAudioTrack_APIv1(int player_id, int track);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern void criManaUnityPlayer_SetVolume_APIv1(int player_id, float vol);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern void criManaUnityPlayer_SetSubAudioTrack_APIv1(int player_id, int track);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern void criManaUnityPlayer_SetSubAudioVolume_APIv1(int player_id, float vol);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern void criManaUnityPlayer_SetSpeed_APIv1(int player_id, float speed);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern void criManaUnityPlayer_SetDeviceSendLevel_APIv1(
    int player_id,
    int device_id,
    float level);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  public static extern bool criManaUnityPlayer_UpdateTexture_APIv1(
    int player_id,
    IntPtr texbuf,
    [Out] CriManaPlayer.FrameInfo frame_info);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  public static extern bool criManaUnityPlayer_UpdateTextureYuvByPtr_APIv1(
    int player_id,
    IntPtr texid_y,
    IntPtr texid_u,
    IntPtr texid_v,
    [Out] CriManaPlayer.FrameInfo frame_info);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  public static extern bool criManaUnityPlayer_UpdateTextureYuvaByPtr_APIv1(
    int player_id,
    IntPtr texid_y,
    IntPtr texid_u,
    IntPtr texid_v,
    IntPtr texid_a,
    [Out] CriManaPlayer.FrameInfo frame_info);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  public static extern void criManaUnityPlayer_SetBufferingTime_APIv1(int player_id, float sec);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  public static extern void criManaUnityPlayer_SetMinBufferSize_APIv1(
    int player_id,
    int min_buffer_size);

  public enum ShaderType
  {
    Yuv2Rgb,
    ForwardRgb,
  }

  public enum AlphaType
  {
    CompoOpaq,
    CompoAlphaFull,
    CompoAlpha3Step,
    CompoAlpha32Bit,
  }

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

  public struct AudioInfo
  {
    public uint sampling_rate;
    public uint num_channels;
    public uint total_samples;
  }

  [StructLayout(LayoutKind.Sequential)]
  public class MovieInfo
  {
    public uint is_playable;
    public uint has_alpha;
    public uint width;
    public uint height;
    public uint disp_width;
    public uint disp_height;
    public uint framerate_n;
    public uint framerate_d;
    public uint total_frames;
    public uint _codecType;
    public uint _alphaCodecType;
    public uint num_audio_streams;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
    public CriManaPlayer.AudioInfo[] audio_prm;
    public uint num_subtitle_channels;
    public uint max_subtitle_size;
  }

  [StructLayout(LayoutKind.Sequential)]
  public class FrameInfo
  {
    public int frame_no;
    public int frame_no_per_file;
    public uint width;
    public uint height;
    public uint disp_width;
    public uint disp_height;
    public uint framerate_n;
    public uint framerate_d;
    public ulong time;
    public ulong tunit;
    public uint cnt_concatenated_movie;
    private CriManaPlayer.AlphaType alpha_type;
    public uint cnt_skipped_frames;
  }

  public delegate void CuePointCbFunc(string eventParamsString);

  private delegate void CuePointCallbackFromNativeDelegate(
    IntPtr ptr1,
    IntPtr ptr2,
    [In] ref EventPoint eventPoint);
}
