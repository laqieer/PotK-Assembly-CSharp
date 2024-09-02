// Decompiled with JetBrains decompiler
// Type: CriAtomEx3dSource
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FC6F22C0-326E-48ED-B5EE-59590337E752
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp-firstpass.dll

using System;
using System.Runtime.InteropServices;

#nullable disable
public class CriAtomEx3dSource : IDisposable
{
  private IntPtr handle = IntPtr.Zero;

  public CriAtomEx3dSource()
  {
    CriAtomEx3dSource.Config config = new CriAtomEx3dSource.Config();
    this.handle = CriAtomEx3dSource.criAtomEx3dSource_Create(ref config, IntPtr.Zero, 0);
  }

  public void Dispose()
  {
    CriAtomEx3dSource.criAtomEx3dSource_Destroy(this.handle);
    GC.SuppressFinalize((object) this);
  }

  public IntPtr nativeHandle => this.handle;

  public void Update() => CriAtomEx3dSource.criAtomEx3dSource_Update(this.handle);

  public void ResetParameters() => CriAtomEx3dSource.criAtomEx3dSource_ResetParameters(this.handle);

  public void SetPosition(float x, float y, float z)
  {
    CriAtomEx3dSource.CriAtomExVector position;
    position.x = x;
    position.y = y;
    position.z = z;
    CriAtomEx3dSource.criAtomEx3dSource_SetPosition(this.handle, ref position);
  }

  public void SetVelocity(float x, float y, float z)
  {
    CriAtomEx3dSource.CriAtomExVector velocity;
    velocity.x = x;
    velocity.y = y;
    velocity.z = z;
    CriAtomEx3dSource.criAtomEx3dSource_SetVelocity(this.handle, ref velocity);
  }

  public void SetConeOrientation(float x, float y, float z)
  {
    CriAtomEx3dSource.CriAtomExVector cone_orient;
    cone_orient.x = x;
    cone_orient.y = y;
    cone_orient.z = z;
    CriAtomEx3dSource.criAtomEx3dSource_SetConeOrientation(this.handle, ref cone_orient);
  }

  public void SetConeParameter(float insideAngle, float outsideAngle, float outsideVolume)
  {
    CriAtomEx3dSource.criAtomEx3dSource_SetConeParameter(this.handle, insideAngle, outsideAngle, outsideVolume);
  }

  public void SetMinMaxDistance(float minDistance, float maxDistance)
  {
    CriAtomEx3dSource.criAtomEx3dSource_SetMinMaxDistance(this.handle, minDistance, maxDistance);
  }

  public void SetDopplerFactor(float dopplerFactor)
  {
    CriAtomEx3dSource.criAtomEx3dSource_SetDopplerFactor(this.handle, dopplerFactor);
  }

  public void SetVolume(float volume)
  {
    CriAtomEx3dSource.criAtomEx3dSource_SetVolume(this.handle, volume);
  }

  public void SetMaxAngleAisacDelta(float maxDelta)
  {
    CriAtomEx3dSource.criAtomEx3dSource_SetMaxAngleAisacDelta(this.handle, maxDelta);
  }

  ~CriAtomEx3dSource() => this.Dispose();

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern IntPtr criAtomEx3dSource_Create(
    ref CriAtomEx3dSource.Config config,
    IntPtr work,
    int work_size);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern void criAtomEx3dSource_Destroy(IntPtr ex_3d_source);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern void criAtomEx3dSource_Update(IntPtr ex_3d_source);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern void criAtomEx3dSource_ResetParameters(IntPtr ex_3d_source);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern void criAtomEx3dSource_SetPosition(
    IntPtr ex_3d_source,
    ref CriAtomEx3dSource.CriAtomExVector position);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern void criAtomEx3dSource_SetVelocity(
    IntPtr ex_3d_source,
    ref CriAtomEx3dSource.CriAtomExVector velocity);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern void criAtomEx3dSource_SetConeOrientation(
    IntPtr ex_3d_source,
    ref CriAtomEx3dSource.CriAtomExVector cone_orient);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern void criAtomEx3dSource_SetConeParameter(
    IntPtr ex_3d_source,
    float inside_angle,
    float outside_angle,
    float outside_volume);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern void criAtomEx3dSource_SetMinMaxDistance(
    IntPtr ex_3d_source,
    float min_distance,
    float max_distance);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern void criAtomEx3dSource_SetDopplerFactor(
    IntPtr ex_3d_source,
    float doppler_factor);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern void criAtomEx3dSource_SetVolume(IntPtr ex_3d_source, float volume);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern void criAtomEx3dSource_SetMaxAngleAisacDelta(
    IntPtr ex_3d_source,
    float max_delta);

  public struct Config
  {
    public int reserved;
  }

  private struct CriAtomExVector
  {
    public float x;
    public float y;
    public float z;
  }
}
