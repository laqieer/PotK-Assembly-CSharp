// Decompiled with JetBrains decompiler
// Type: CriFsInstaller
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ECB926DA-6BA5-4E91-81B4-E3750A024FEA
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp-firstpass.dll

using System;
using System.Runtime.InteropServices;

#nullable disable
public class CriFsInstaller : IDisposable
{
  private byte[] installBuffer;
  private GCHandle installBufferGch;
  private IntPtr handle;

  public CriFsInstaller()
  {
    CriFsPlugin.InitializeLibrary();
    this.handle = IntPtr.Zero;
    CriFsInstaller.criFsInstaller_Create(out this.handle, CriFsInstaller.CopyPolicy.Always);
    if (this.handle == IntPtr.Zero)
    {
      CriFsPlugin.FinalizeLibrary();
      throw new Exception("criFsInstaller_Create() failed.");
    }
  }

  public void Dispose()
  {
    if (this.handle == IntPtr.Zero)
      return;
    CriFsInstaller.criFsInstaller_Destroy(this.handle);
    this.handle = IntPtr.Zero;
    if (this.installBuffer != null)
    {
      this.installBufferGch.Free();
      this.installBuffer = (byte[]) null;
    }
    CriFsPlugin.FinalizeLibrary();
    GC.SuppressFinalize((object) this);
  }

  public void Copy(CriFsBinder binder, string srcPath, string dstPath, int installBufferSize)
  {
    string src_path = srcPath;
    if (src_path.StartsWith("http:") || src_path.StartsWith("https:"))
      src_path = "net2:" + src_path;
    if (installBufferSize > 0)
    {
      this.installBuffer = new byte[installBufferSize];
      this.installBufferGch = GCHandle.Alloc((object) this.installBuffer, GCHandleType.Pinned);
      CriFsInstaller.criFsInstaller_Copy(this.handle, binder == null ? IntPtr.Zero : binder.nativeHandle, src_path, dstPath, this.installBufferGch.AddrOfPinnedObject(), (long) this.installBuffer.Length);
    }
    else
      CriFsInstaller.criFsInstaller_Copy(this.handle, binder == null ? IntPtr.Zero : binder.nativeHandle, src_path, dstPath, IntPtr.Zero, 0L);
  }

  public void Stop() => CriFsInstaller.criFsInstaller_Stop(this.handle);

  public CriFsInstaller.Status GetStatus()
  {
    CriFsInstaller.Status status;
    CriFsInstaller.criFsInstaller_GetStatus(this.handle, out status);
    return status;
  }

  public float GetProgress()
  {
    float progress;
    CriFsInstaller.criFsInstaller_GetProgress(this.handle, out progress);
    return progress;
  }

  public static void ExecuteMain() => CriFsInstaller.criFsInstaller_ExecuteMain();

  ~CriFsInstaller() => this.Dispose();

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern void criFsInstaller_ExecuteMain();

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern int criFsInstaller_Create(
    out IntPtr installer,
    CriFsInstaller.CopyPolicy option);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern int criFsInstaller_Destroy(IntPtr installer);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern int criFsInstaller_Copy(
    IntPtr installer,
    IntPtr binder,
    string src_path,
    string dst_path,
    IntPtr buffer,
    long buffer_size);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern int criFsInstaller_Stop(IntPtr installer);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern int criFsInstaller_GetStatus(
    IntPtr installer,
    out CriFsInstaller.Status status);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern int criFsInstaller_GetProgress(IntPtr installer, out float progress);

  public enum Status
  {
    Stop,
    Busy,
    Complete,
    Error,
  }

  private enum CopyPolicy
  {
    Always,
  }
}
