// Decompiled with JetBrains decompiler
// Type: GooglePlayGames.Native.PInvoke.RealtimeRoomConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GooglePlayGames.Native.Cwrapper;
using System;
using System.Runtime.InteropServices;

#nullable disable
namespace GooglePlayGames.Native.PInvoke
{
  internal class RealtimeRoomConfig : BaseReferenceHolder
  {
    internal RealtimeRoomConfig(IntPtr selfPointer)
      : base(selfPointer)
    {
    }

    protected override void CallDispose(HandleRef selfPointer)
    {
      RealTimeRoomConfig.RealTimeRoomConfig_Dispose(selfPointer);
    }

    internal static RealtimeRoomConfig FromPointer(IntPtr selfPointer)
    {
      return selfPointer.Equals((object) IntPtr.Zero) ? (RealtimeRoomConfig) null : new RealtimeRoomConfig(selfPointer);
    }
  }
}
