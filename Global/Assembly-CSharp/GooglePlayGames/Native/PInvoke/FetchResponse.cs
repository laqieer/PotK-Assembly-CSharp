// Decompiled with JetBrains decompiler
// Type: GooglePlayGames.Native.PInvoke.FetchResponse
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GooglePlayGames.Native.Cwrapper;
using System;
using System.Runtime.InteropServices;

#nullable disable
namespace GooglePlayGames.Native.PInvoke
{
  internal class FetchResponse : BaseReferenceHolder
  {
    internal FetchResponse(IntPtr selfPointer)
      : base(selfPointer)
    {
    }

    protected override void CallDispose(HandleRef selfPointer)
    {
      GooglePlayGames.Native.Cwrapper.LeaderboardManager.LeaderboardManager_FetchResponse_Dispose(this.SelfPtr());
    }

    internal NativeLeaderboard Leaderboard()
    {
      return NativeLeaderboard.FromPointer(GooglePlayGames.Native.Cwrapper.LeaderboardManager.LeaderboardManager_FetchResponse_GetData(this.SelfPtr()));
    }

    internal CommonErrorStatus.ResponseStatus GetStatus()
    {
      return GooglePlayGames.Native.Cwrapper.LeaderboardManager.LeaderboardManager_FetchResponse_GetStatus(this.SelfPtr());
    }

    internal static FetchResponse FromPointer(IntPtr pointer)
    {
      return pointer.Equals((object) IntPtr.Zero) ? (FetchResponse) null : new FetchResponse(pointer);
    }
  }
}
