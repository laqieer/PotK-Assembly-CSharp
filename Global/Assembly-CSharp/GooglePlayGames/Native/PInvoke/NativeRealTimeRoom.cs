﻿// Decompiled with JetBrains decompiler
// Type: GooglePlayGames.Native.PInvoke.NativeRealTimeRoom
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GooglePlayGames.Native.Cwrapper;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

#nullable disable
namespace GooglePlayGames.Native.PInvoke
{
  internal class NativeRealTimeRoom : BaseReferenceHolder
  {
    internal NativeRealTimeRoom(IntPtr selfPointer)
      : base(selfPointer)
    {
    }

    internal string Id()
    {
      return PInvokeUtilities.OutParamsToString((PInvokeUtilities.OutStringMethod) ((out_string, size) => RealTimeRoom.RealTimeRoom_Id(this.SelfPtr(), out_string, size)));
    }

    internal IEnumerable<MultiplayerParticipant> Participants()
    {
      return PInvokeUtilities.ToEnumerable<MultiplayerParticipant>(RealTimeRoom.RealTimeRoom_Participants_Length(this.SelfPtr()), (Func<UIntPtr, MultiplayerParticipant>) (index => new MultiplayerParticipant(RealTimeRoom.RealTimeRoom_Participants_GetElement(this.SelfPtr(), index))));
    }

    internal uint ParticipantCount()
    {
      return RealTimeRoom.RealTimeRoom_Participants_Length(this.SelfPtr()).ToUInt32();
    }

    internal Types.RealTimeRoomStatus Status() => RealTimeRoom.RealTimeRoom_Status(this.SelfPtr());

    protected override void CallDispose(HandleRef selfPointer)
    {
      RealTimeRoom.RealTimeRoom_Dispose(selfPointer);
    }

    internal static NativeRealTimeRoom FromPointer(IntPtr selfPointer)
    {
      return selfPointer.Equals((object) IntPtr.Zero) ? (NativeRealTimeRoom) null : new NativeRealTimeRoom(selfPointer);
    }
  }
}
