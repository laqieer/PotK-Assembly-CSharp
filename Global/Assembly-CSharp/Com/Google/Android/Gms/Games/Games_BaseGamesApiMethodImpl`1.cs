// Decompiled with JetBrains decompiler
// Type: Com.Google.Android.Gms.Games.Games_BaseGamesApiMethodImpl`1
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using Com.Google.Android.Gms.Common.Api;
using Google.Developers;
using System;

#nullable disable
namespace Com.Google.Android.Gms.Games
{
  public class Games_BaseGamesApiMethodImpl<R> : JavaObjWrapper where R : Result
  {
    private const string CLASS_NAME = "com/google/android/gms/games/Games$BaseGamesApiMethodImpl";

    public Games_BaseGamesApiMethodImpl(IntPtr ptr)
      : base(ptr)
    {
    }

    public Games_BaseGamesApiMethodImpl(GoogleApiClient arg_GoogleApiClient_1)
    {
      this.CreateInstance("com/google/android/gms/games/Games$BaseGamesApiMethodImpl", (object) arg_GoogleApiClient_1);
    }
  }
}
