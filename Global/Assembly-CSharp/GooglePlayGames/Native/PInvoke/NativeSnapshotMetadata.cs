﻿// Decompiled with JetBrains decompiler
// Type: GooglePlayGames.Native.PInvoke.NativeSnapshotMetadata
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GooglePlayGames.BasicApi.SavedGame;
using GooglePlayGames.Native.Cwrapper;
using System;
using System.Runtime.InteropServices;

#nullable disable
namespace GooglePlayGames.Native.PInvoke
{
  internal class NativeSnapshotMetadata : BaseReferenceHolder, ISavedGameMetadata
  {
    internal NativeSnapshotMetadata(IntPtr selfPointer)
      : base(selfPointer)
    {
    }

    public bool IsOpen => SnapshotMetadata.SnapshotMetadata_IsOpen(this.SelfPtr());

    public string Filename
    {
      get
      {
        return PInvokeUtilities.OutParamsToString((PInvokeUtilities.OutStringMethod) ((out_string, out_size) => SnapshotMetadata.SnapshotMetadata_FileName(this.SelfPtr(), out_string, out_size)));
      }
    }

    public string Description
    {
      get
      {
        return PInvokeUtilities.OutParamsToString((PInvokeUtilities.OutStringMethod) ((out_string, out_size) => SnapshotMetadata.SnapshotMetadata_Description(this.SelfPtr(), out_string, out_size)));
      }
    }

    public string CoverImageURL
    {
      get
      {
        return PInvokeUtilities.OutParamsToString((PInvokeUtilities.OutStringMethod) ((out_string, out_size) => SnapshotMetadata.SnapshotMetadata_CoverImageURL(this.SelfPtr(), out_string, out_size)));
      }
    }

    public TimeSpan TotalTimePlayed
    {
      get
      {
        long num = SnapshotMetadata.SnapshotMetadata_PlayedTime(this.SelfPtr());
        return num < 0L ? TimeSpan.FromMilliseconds(0.0) : TimeSpan.FromMilliseconds((double) num);
      }
    }

    public DateTime LastModifiedTimestamp
    {
      get
      {
        return PInvokeUtilities.FromMillisSinceUnixEpoch(SnapshotMetadata.SnapshotMetadata_LastModifiedTime(this.SelfPtr()));
      }
    }

    public override string ToString()
    {
      if (this.IsDisposed())
        return "[NativeSnapshotMetadata: DELETED]";
      return string.Format("[NativeSnapshotMetadata: IsOpen={0}, Filename={1}, Description={2}, CoverImageUrl={3}, TotalTimePlayed={4}, LastModifiedTimestamp={5}]", (object) this.IsOpen, (object) this.Filename, (object) this.Description, (object) this.CoverImageURL, (object) this.TotalTimePlayed, (object) this.LastModifiedTimestamp);
    }

    protected override void CallDispose(HandleRef selfPointer)
    {
      SnapshotMetadata.SnapshotMetadata_Dispose(this.SelfPtr());
    }
  }
}
