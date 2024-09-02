// Decompiled with JetBrains decompiler
// Type: GooglePlayGames.Native.PInvoke.FetchScorePageResponse
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GooglePlayGames.Native.Cwrapper;
using System;
using System.Runtime.InteropServices;

#nullable disable
namespace GooglePlayGames.Native.PInvoke
{
  internal class FetchScorePageResponse : BaseReferenceHolder
  {
    internal FetchScorePageResponse(IntPtr selfPointer)
      : base(selfPointer)
    {
    }

    protected override void CallDispose(HandleRef selfPointer)
    {
      GooglePlayGames.Native.Cwrapper.LeaderboardManager.LeaderboardManager_FetchScorePageResponse_Dispose(this.SelfPtr());
    }

    internal CommonErrorStatus.ResponseStatus GetStatus()
    {
      return GooglePlayGames.Native.Cwrapper.LeaderboardManager.LeaderboardManager_FetchScorePageResponse_GetStatus(this.SelfPtr());
    }

    internal NativeScorePage GetScorePage()
    {
      return NativeScorePage.FromPointer(GooglePlayGames.Native.Cwrapper.LeaderboardManager.LeaderboardManager_FetchScorePageResponse_GetData(this.SelfPtr()));
    }

    internal static FetchScorePageResponse FromPointer(IntPtr pointer)
    {
      return pointer.Equals((object) IntPtr.Zero) ? (FetchScorePageResponse) null : new FetchScorePageResponse(pointer);
    }
  }
}
