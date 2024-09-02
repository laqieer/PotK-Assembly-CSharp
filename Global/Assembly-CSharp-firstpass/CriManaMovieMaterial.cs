// Decompiled with JetBrains decompiler
// Type: CriManaMovieMaterial
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E910E095-517B-41AE-AAF8-B85E770EBAF1
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp-firstpass.dll

using CriMana;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
[AddComponentMenu("CRIWARE/CriManaMovieMaterial")]
public class CriManaMovieMaterial : MonoBehaviour
{
  public string moviePath;
  public bool playOnStart;
  public bool loop;
  public bool additiveMode;
  [SerializeField]
  private Material _material;
  private bool materialOwn = true;
  private int pauseCallCount;
  private int onApplicationPauseCallCount;
  private bool unpauseOnApplicationUnpause;

  public bool isMaterialAvailable { get; private set; }

  public Player player { get; private set; }

  public Material material
  {
    get => this._material;
    set
    {
      if (!Object.op_Inequality((Object) value, (Object) this._material))
        return;
      if (this.materialOwn)
        Object.Destroy((Object) this._material);
      this._material = value;
      this.isMaterialAvailable = false;
    }
  }

  public void Play() => this.player.Start();

  public void Stop() => this.player.Stop();

  public void Pause(bool sw) => this.player.Pause(sw);

  protected virtual void OnMaterialAvailableChanged()
  {
  }

  protected virtual void OnMaterialUpdated()
  {
  }

  protected virtual void Awake()
  {
    this.player = new Player();
    this.isMaterialAvailable = false;
  }

  protected virtual void OnEnable()
  {
  }

  protected virtual void OnDisable()
  {
  }

  protected virtual void OnDestroy()
  {
    this.player.Dispose();
    this.player = (Player) null;
    this.material = (Material) null;
  }

  protected virtual void Start()
  {
    if (Object.op_Equality((Object) this._material, (Object) null))
      this.CreateMaterial();
    if (!string.IsNullOrEmpty(this.moviePath))
      this.player.SetFile((CriFsBinder) null, this.moviePath);
    this.player.Loop(this.loop);
    this.player.additiveMode = this.additiveMode;
    if (this.playOnStart)
      this.player.Start();
    if (!CriManaPlugin.isMultithreadedRenderingEnabled)
      return;
    this.StartCoroutine(this.CallPluginAtEndOfFrames());
  }

  protected virtual void Update()
  {
    this.player.Update();
    bool flag;
    if (this.player.isFrameAvailable)
    {
      flag = this.player.UpdateMaterial(this.material);
      if (flag)
        this.OnMaterialUpdated();
    }
    else
      flag = false;
    if (this.isMaterialAvailable == flag)
      return;
    this.isMaterialAvailable = flag;
    this.OnMaterialAvailableChanged();
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
      this.unpauseOnApplicationUnpause = !this.player.IsPaused();
      if (!this.unpauseOnApplicationUnpause)
        return;
      this.player.Pause(true);
    }
    else
    {
      if (this.unpauseOnApplicationUnpause)
        this.player.Pause(false);
      this.unpauseOnApplicationUnpause = false;
    }
  }

  protected virtual void OnDrawGizmos()
  {
    Gizmos.color = this.player == null || this.player.status != Player.Status.Playing ? new Color(1f, 1f, 1f, 0.5f) : new Color(1f, 1f, 1f, 0.8f);
    Gizmos.DrawIcon(((Component) this).transform.position, "CriWare/film.png");
    Gizmos.DrawLine(((Component) this).transform.position, new Vector3(0.0f, 0.0f, 0.0f));
  }

  private void CreateMaterial()
  {
    this._material = new Material(Shader.Find("VertexLit"));
    ((Object) this._material).name = "CriMana-MovieMaterial";
    this.materialOwn = true;
  }

  [DebuggerHidden]
  private IEnumerator CallPluginAtEndOfFrames()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new CriManaMovieMaterial.\u003CCallPluginAtEndOfFrames\u003Ec__Iterator1()
    {
      \u003C\u003Ef__this = this
    };
  }
}
