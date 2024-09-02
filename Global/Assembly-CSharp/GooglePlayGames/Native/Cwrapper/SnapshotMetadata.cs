// Decompiled with JetBrains decompiler
// Type: GooglePlayGames.Native.Cwrapper.SnapshotMetadata
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;
using System.Runtime.InteropServices;
using System.Text;

#nullable disable
namespace GooglePlayGames.Native.Cwrapper
{
  internal static class SnapshotMetadata
  {
    [DllImport("gpg")]
    internal static extern void SnapshotMetadata_Dispose(HandleRef self);

    [DllImport("gpg")]
    internal static extern UIntPtr SnapshotMetadata_CoverImageURL(
      HandleRef self,
      StringBuilder out_arg,
      UIntPtr out_size);

    [DllImport("gpg")]
    internal static extern UIntPtr SnapshotMetadata_Description(
      HandleRef self,
      StringBuilder out_arg,
      UIntPtr out_size);

    [DllImport("gpg")]
    [return: MarshalAs(UnmanagedType.I1)]
    internal static extern bool SnapshotMetadata_IsOpen(HandleRef self);

    [DllImport("gpg")]
    internal static extern UIntPtr SnapshotMetadata_FileName(
      HandleRef self,
      StringBuilder out_arg,
      UIntPtr out_size);

    [DllImport("gpg")]
    [return: MarshalAs(UnmanagedType.I1)]
    internal static extern bool SnapshotMetadata_Valid(HandleRef self);

    [DllImport("gpg")]
    internal static extern long SnapshotMetadata_PlayedTime(HandleRef self);

    [DllImport("gpg")]
    internal static extern long SnapshotMetadata_LastModifiedTime(HandleRef self);
  }
}
