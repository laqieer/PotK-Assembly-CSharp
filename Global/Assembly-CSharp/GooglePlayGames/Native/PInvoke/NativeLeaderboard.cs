﻿// Decompiled with JetBrains decompiler
// Type: GooglePlayGames.Native.PInvoke.NativeLeaderboard
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GooglePlayGames.Native.Cwrapper;
using System;
using System.Runtime.InteropServices;

#nullable disable
namespace GooglePlayGames.Native.PInvoke
{
  internal class NativeLeaderboard : BaseReferenceHolder
  {
    internal NativeLeaderboard(IntPtr selfPtr)
      : base(selfPtr)
    {
    }

    protected override void CallDispose(HandleRef selfPointer)
    {
      Leaderboard.Leaderboard_Dispose(selfPointer);
    }

    internal string Title()
    {
      return PInvokeUtilities.OutParamsToString((PInvokeUtilities.OutStringMethod) ((out_string, out_size) => Leaderboard.Leaderboard_Name(this.SelfPtr(), out_string, out_size)));
    }

    internal static NativeLeaderboard FromPointer(IntPtr pointer)
    {
      return pointer.Equals((object) IntPtr.Zero) ? (NativeLeaderboard) null : new NativeLeaderboard(pointer);
    }
  }
}
