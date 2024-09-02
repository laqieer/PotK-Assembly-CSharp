// Decompiled with JetBrains decompiler
// Type: CriAtomSource
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ECB926DA-6BA5-4E91-81B4-E3750A024FEA
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp-firstpass.dll

using UnityEngine;

#nullable disable
[AddComponentMenu("CRIWARE/CRI Atom Source")]
public class CriAtomSource : MonoBehaviour
{
  private CriAtomEx3dSource source;
  private Vector3 lastPosition;
  private bool hasValidPosition;
  [SerializeField]
  private bool _playOnStart;
  [SerializeField]
  private string _cueName = string.Empty;
  [SerializeField]
  private string _cueSheet = string.Empty;
  [SerializeField]
  private bool _use3dPositioning = true;
  [SerializeField]
  private bool _loop;
  [SerializeField]
  private float _volume = 1f;
  [SerializeField]
  private float _pitch;
  [SerializeField]
  private bool _androidUseLowLatencyVoicePool;
  [SerializeField]
  private bool need_to_player_update_all = true;

  public CriAtomExPlayer player { private set; get; }

  public bool playOnStart
  {
    get => this._playOnStart;
    set => this._playOnStart = value;
  }

  public string cueName
  {
    get => this._cueName;
    set => this._cueName = value;
  }

  public string cueSheet
  {
    get => this._cueSheet;
    set => this._cueSheet = value;
  }

  public bool use3dPositioning
  {
    set
    {
      this._use3dPositioning = value;
      if (this.player == null)
        return;
      this.player.Set3dSource(!this.use3dPositioning ? (CriAtomEx3dSource) null : this.source);
      this.SetNeedToPlayerUpdateAll();
    }
    get => this._use3dPositioning;
  }

  public bool loop
  {
    set => this._loop = value;
    get => this._loop;
  }

  public float volume
  {
    set
    {
      this._volume = value;
      if (this.player == null)
        return;
      this.player.SetVolume(this._volume);
      this.SetNeedToPlayerUpdateAll();
    }
    get => this._volume;
  }

  public float pitch
  {
    set
    {
      this._pitch = value;
      if (this.player == null)
        return;
      this.player.SetPitch(this._pitch);
      this.SetNeedToPlayerUpdateAll();
    }
    get => this._pitch;
  }

  public float pan3dAngle
  {
    set
    {
      this.player.SetPan3dAngle(value);
      this.SetNeedToPlayerUpdateAll();
    }
    get => this.player.GetParameterFloat32(CriAtomEx.Parameter.Pan3dAngle);
  }

  public float pan3dDistance
  {
    set
    {
      this.player.SetPan3dInteriorDistance(value);
      this.SetNeedToPlayerUpdateAll();
    }
    get => this.player.GetParameterFloat32(CriAtomEx.Parameter.Pan3dDistance);
  }

  public int startTime
  {
    set
    {
      this.player.SetStartTime((long) value);
      this.SetNeedToPlayerUpdateAll();
    }
    get => this.player.GetParameterSint32(CriAtomEx.Parameter.StartTime);
  }

  public long time => this.player != null ? this.player.GetTime() : 0L;

  public CriAtomSource.Status status
  {
    get
    {
      return this.player != null ? (CriAtomSource.Status) this.player.GetStatus() : CriAtomSource.Status.Error;
    }
  }

  public bool androidUseLowLatencyVoicePool
  {
    get => this._androidUseLowLatencyVoicePool;
    set => this._androidUseLowLatencyVoicePool = value;
  }

  protected void SetNeedToPlayerUpdateAll() => this.need_to_player_update_all = true;

  protected virtual void InternalInitialize()
  {
    CriAtomPlugin.InitializeLibrary();
    this.player = new CriAtomExPlayer();
    this.source = new CriAtomEx3dSource();
  }

  protected virtual void InternalFinalize()
  {
    this.player.Dispose();
    this.player = (CriAtomExPlayer) null;
    this.source.Dispose();
    this.source = (CriAtomEx3dSource) null;
    CriAtomPlugin.FinalizeLibrary();
  }

  private void Awake() => this.InternalInitialize();

  private void OnEnable()
  {
    this.hasValidPosition = false;
    this.SetInitialParameters();
    this.SetNeedToPlayerUpdateAll();
  }

  private void OnDestroy() => this.InternalFinalize();

  protected bool SetInitialSourcePosition()
  {
    Vector3 position = ((Component) this).transform.position;
    this.lastPosition = position;
    if (this.source == null)
      return false;
    this.source.SetPosition(position.x, position.y, position.z);
    this.source.Update();
    return true;
  }

  protected virtual void SetInitialParameters()
  {
    this.use3dPositioning = this.use3dPositioning;
    this.player.Set3dListener(CriAtomListener.sharedNativeListener);
    if (!this.SetInitialSourcePosition())
      Debug.LogError((object) "[ADX2][SetInitialParameters] source is null.", (Object) this);
    this.player.SetVolume(this._volume);
    this.player.SetPitch(this._pitch);
  }

  private void Start()
  {
    if (!this.playOnStart)
      return;
    this.Play();
  }

  private void LateUpdate()
  {
    Vector3 position = ((Component) this).transform.position;
    Vector3 vector3 = Vector3.op_Division(Vector3.op_Subtraction(position, this.lastPosition), Time.deltaTime);
    this.lastPosition = position;
    this.source.SetPosition(position.x, position.y, position.z);
    if (this.hasValidPosition)
      this.source.SetVelocity(vector3.x, vector3.y, vector3.z);
    this.source.Update();
    this.hasValidPosition = true;
    if (!this.need_to_player_update_all)
      return;
    this.player.UpdateAll();
    this.need_to_player_update_all = false;
  }

  public void OnDrawGizmos()
  {
    if (Application.isPlaying && this.status == CriAtomSource.Status.Playing)
      Gizmos.DrawIcon(((Component) this).transform.position, "Criware/VoiceOn.png");
    else
      Gizmos.DrawIcon(((Component) this).transform.position, "Criware/VoiceOff.png");
  }

  public CriAtomExPlayback Play() => this.Play(this.cueName);

  public CriAtomExPlayback Play(string cueName)
  {
    CriAtomExAcb acb = (CriAtomExAcb) null;
    if (!string.IsNullOrEmpty(this.cueSheet))
      acb = CriAtom.GetAcb(this.cueSheet);
    this.player.SetCue(acb, cueName);
    if (this.androidUseLowLatencyVoicePool)
      this.player.SetSoundRendererType(CriAtomEx.SoundRendererType.Native);
    else
      this.player.SetSoundRendererType(CriAtomEx.SoundRendererType.Asr);
    if (!this.hasValidPosition)
    {
      this.SetInitialSourcePosition();
      this.hasValidPosition = true;
    }
    if (this.status == CriAtomSource.Status.Stop)
      this.player.Loop(this._loop);
    return this.player.Start();
  }

  public CriAtomExPlayback Play(int cueId)
  {
    CriAtomExAcb acb = (CriAtomExAcb) null;
    if (!string.IsNullOrEmpty(this.cueSheet))
      acb = CriAtom.GetAcb(this.cueSheet);
    this.player.SetCue(acb, cueId);
    if (this.androidUseLowLatencyVoicePool)
      this.player.SetSoundRendererType(CriAtomEx.SoundRendererType.Native);
    else
      this.player.SetSoundRendererType(CriAtomEx.SoundRendererType.Asr);
    if (!this.hasValidPosition)
    {
      this.SetInitialSourcePosition();
      this.hasValidPosition = true;
    }
    if (this.status == CriAtomSource.Status.Stop)
      this.player.Loop(this._loop);
    return this.player.Start();
  }

  public void Stop() => this.player.Stop();

  public void Pause(bool sw)
  {
    if (!sw)
      this.player.Resume(CriAtomEx.ResumeMode.PausedPlayback);
    else
      this.player.Pause();
  }

  public bool IsPaused() => this.player.IsPaused();

  public void SetBusSendLevel(int busId, float level)
  {
    if (this.player == null)
      return;
    this.player.SetBusSendLevel(busId, level);
    this.SetNeedToPlayerUpdateAll();
  }

  public void SetBusSendLevelOffset(int busId, float levelOffset)
  {
    if (this.player == null)
      return;
    this.player.SetBusSendLevelOffset(busId, levelOffset);
    this.SetNeedToPlayerUpdateAll();
  }

  public void SetDeviceSendLevel(int deviceId, float level)
  {
  }

  public void SetAisac(string controlName, float value)
  {
    if (this.player == null)
      return;
    this.player.SetAisac(controlName, value);
    this.SetNeedToPlayerUpdateAll();
  }

  public void SetAisac(uint controlId, float value)
  {
    if (this.player == null)
      return;
    this.player.SetAisac(controlId, value);
    this.SetNeedToPlayerUpdateAll();
  }

  public void AttachToAnalyzer(CriAtomExPlayerOutputAnalyzer analyzer)
  {
    if (this.player == null)
      return;
    analyzer.AttachExPlayer(this.player);
  }

  public void DetachFromAnalyzer(CriAtomExPlayerOutputAnalyzer analyzer)
  {
    analyzer.DetachExPlayer();
  }

  public enum Status
  {
    Stop,
    Prep,
    Playing,
    PlayEnd,
    Error,
  }
}
