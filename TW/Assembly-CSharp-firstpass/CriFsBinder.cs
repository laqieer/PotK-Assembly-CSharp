// Decompiled with JetBrains decompiler
// Type: CriFsBinder
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ECB926DA-6BA5-4E91-81B4-E3750A024FEA
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp-firstpass.dll

using System;
using System.Runtime.InteropServices;

#nullable disable
public class CriFsBinder : IDisposable
{
  private IntPtr handle;

  public CriFsBinder()
  {
    CriFsPlugin.InitializeLibrary();
    this.handle = IntPtr.Zero;
    int num = (int) CriFsBinder.criFsBinder_Create(out this.handle);
    if (this.handle == IntPtr.Zero)
    {
      CriFsPlugin.FinalizeLibrary();
      throw new Exception("criFsBinder_Create() failed.");
    }
  }

  public void Dispose()
  {
    if (this.handle == IntPtr.Zero)
      return;
    int num = (int) CriFsBinder.criFsBinder_Destroy(this.handle);
    this.handle = IntPtr.Zero;
    CriFsPlugin.FinalizeLibrary();
    GC.SuppressFinalize((object) this);
  }

  public uint BindCpk(CriFsBinder srcBinder, string path)
  {
    uint bindId;
    int num = (int) CriFsBinder.criFsBinder_BindCpk(this.handle, srcBinder == null ? IntPtr.Zero : srcBinder.nativeHandle, path, IntPtr.Zero, 0, out bindId);
    return bindId;
  }

  public uint BindDirectory(CriFsBinder srcBinder, string path)
  {
    uint bindId;
    int num = (int) CriFsBinder.criFsBinder_BindDirectory(this.handle, srcBinder == null ? IntPtr.Zero : srcBinder.nativeHandle, path, IntPtr.Zero, 0, out bindId);
    return bindId;
  }

  public uint BindFile(CriFsBinder srcBinder, string path)
  {
    uint bindId;
    int num = (int) CriFsBinder.criFsBinder_BindFile(this.handle, srcBinder == null ? IntPtr.Zero : srcBinder.nativeHandle, path, IntPtr.Zero, 0, out bindId);
    return bindId;
  }

  public static void Unbind(uint bindId) => CriFsBinder.criFsBinder_Unbind(bindId);

  public static CriFsBinder.Status GetStatus(uint bindId)
  {
    CriFsBinder.Status status;
    CriFsBinder.criFsBinder_GetStatus(bindId, out status);
    return status;
  }

  public long GetFileSize(string path)
  {
    long size;
    return CriFsBinder.criFsBinder_GetFileSize(this.handle, path, out size) != 0 ? -1L : size;
  }

  public long GetFileSize(int id)
  {
    long size;
    return CriFsBinder.criFsBinder_GetFileSizeById(this.handle, id, out size) != 0 ? -1L : size;
  }

  public static void SetPriority(uint bindId, int priority)
  {
    CriFsBinder.criFsBinder_SetPriority(bindId, priority);
  }

  public IntPtr nativeHandle => this.handle;

  ~CriFsBinder() => this.Dispose();

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern uint criFsBinder_Create(out IntPtr binder);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern uint criFsBinder_Destroy(IntPtr binder);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern uint criFsBinder_BindCpk(
    IntPtr binder,
    IntPtr srcBinder,
    string path,
    IntPtr work,
    int worksize,
    out uint bindId);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern uint criFsBinder_BindDirectory(
    IntPtr binder,
    IntPtr srcBinder,
    string path,
    IntPtr work,
    int worksize,
    out uint bindId);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern uint criFsBinder_BindFile(
    IntPtr binder,
    IntPtr srcBinder,
    string path,
    IntPtr work,
    int worksize,
    out uint bindId);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern int criFsBinder_Unbind(uint bindId);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern int criFsBinder_GetStatus(uint bindId, out CriFsBinder.Status status);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern int criFsBinder_GetFileSize(IntPtr binder, string path, out long size);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern int criFsBinder_GetFileSizeById(IntPtr binder, int id, out long size);

  [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
  private static extern int criFsBinder_SetPriority(uint bindId, int priority);

  public enum Status
  {
    None,
    Analyze,
    Complete,
    Unbind,
    Removed,
    Invalid,
    Error,
  }
}
