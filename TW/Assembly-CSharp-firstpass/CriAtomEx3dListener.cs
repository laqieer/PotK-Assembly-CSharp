// Decompiled with JetBrains decompiler
// Type: CriAtomEx3dListener
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ECB926DA-6BA5-4E91-81B4-E3750A024FEA
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp-firstpass.dll

using System;
using System.Runtime.InteropServices;

#nullable disable
public class CriAtomEx3dListener : IDisposable
{
  private IntPtr handle = IntPtr.Zero;

  public CriAtomEx3dListener()
  {
    CriAtomEx3dListener.Config config = new CriAtomEx3dListener.Config();
    this.handle = CriAtomEx3dListener.criAtomEx3dListener_Create(ref config, IntPtr.Zero, 0);
  }

  public void Dispose()
  {
    CriAtomEx3dListener.criAtomEx3dListener_Destroy(this.handle);
    GC.SuppressFinalize((object) this);
  }

  public IntPtr nativeHandle => this.handle;

  public void Update() => CriAtomEx3dListener.criAtomEx3dListener_Update(this.handle);

  public void ResetParameters()
  {
    CriAtomEx3dListener.criAtomEx3dListener_ResetParameters(this.handle);
  }

  public void SetPosition(float x, float y, float z)
  {
    CriAtomEx3dListener.CriAtomExVector position;
    position.x = x;
    position.y = y;
    position.z = z;
    CriAtomEx3dListener.criAtomEx3dListener_SetPosition(this.handle, ref position);
  }

  public void SetVelocity(float x, float y, float z)
  {
    CriAtomEx3dListener.CriAtomExVector velocity;
    velocity.x = x;
    velocity.y = y;
    velocity.z = z;
    CriAtomEx3dListener.criAtomEx3dListener_SetVelocity(this.handle, ref velocity);
  }

  public void SetOrientation(float fx, float fy, float fz, float ux, float uy, float uz)
  {
    CriAtomEx3dListener.CriAtomExVector front;
    front.x = fx;
    front.y = fy;
    front.z = fz;
    CriAtomEx3dListener.CriAtomExVector top;
    top.x = ux;
    top.y = uy;
    top.z = uz;
    CriAtomEx3dListener.criAtomEx3dListener_SetOrientation(this.handle, ref front, ref top);
  }

  public void SetDistanceFactor(float distanceFactor)
  {
    CriAtomEx3dListener.criAtomEx3dListener_SetDistanceFactor(this.handle, distanceFactor);
  }

  public void SetFocusPoint(float x, float y, float z)
  {
    CriAtomEx3dListener.CriAtomExVector focus_point;
    focus_point.x = x;
    focus_point.y = y;
    focus_point.z = z;
    CriAtomEx3dListener.criAtomEx3dListener_SetFocusPoint(this.handle, ref focus_point);
  }

  public void SetDistanceFocusLevel(float distanceFocusLevel)
  {
    CriAtomEx3dListener.criAtomEx3dListener_SetDistanceFocusLevel(this.handle, distanceFocusLevel);
  }

  public void SetDirectionFocusLevel(float directionFocusLevel)
  {
    CriAtomEx3dListener.criAtomEx3dListener_SetDirectionFocusLevel(this.handle, directionFocusLevel);
  }

  ~CriAtomEx3dListener() => this.Dispose();

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern IntPtr criAtomEx3dListener_Create(
    ref CriAtomEx3dListener.Config config,
    IntPtr work,
    int work_size);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern void criAtomEx3dListener_Destroy(IntPtr ex_3d_listener);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern void criAtomEx3dListener_Update(IntPtr ex_3d_listener);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern void criAtomEx3dListener_ResetParameters(IntPtr ex_3d_listener);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern void criAtomEx3dListener_SetPosition(
    IntPtr ex_3d_listener,
    ref CriAtomEx3dListener.CriAtomExVector position);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern void criAtomEx3dListener_SetVelocity(
    IntPtr ex_3d_listener,
    ref CriAtomEx3dListener.CriAtomExVector velocity);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern void criAtomEx3dListener_SetOrientation(
    IntPtr ex_3d_listener,
    ref CriAtomEx3dListener.CriAtomExVector front,
    ref CriAtomEx3dListener.CriAtomExVector top);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern void criAtomEx3dListener_SetDistanceFactor(
    IntPtr ex_3d_listener,
    float distance_factor);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern void criAtomEx3dListener_SetFocusPoint(
    IntPtr ex_3d_listener,
    ref CriAtomEx3dListener.CriAtomExVector focus_point);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern void criAtomEx3dListener_SetDistanceFocusLevel(
    IntPtr ex_3d_listener,
    float distance_focus_level);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern void criAtomEx3dListener_SetDirectionFocusLevel(
    IntPtr ex_3d_listener,
    float direction_focus_level);

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
