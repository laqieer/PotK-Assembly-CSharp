﻿// Decompiled with JetBrains decompiler
// Type: GooglePlayGames.Native.PInvoke.ParticipantResults
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GooglePlayGames.Native.Cwrapper;
using System;
using System.Runtime.InteropServices;

#nullable disable
namespace GooglePlayGames.Native.PInvoke
{
  internal class ParticipantResults : BaseReferenceHolder
  {
    internal ParticipantResults(IntPtr selfPointer)
      : base(selfPointer)
    {
    }

    internal bool HasResultsForParticipant(string participantId)
    {
      return GooglePlayGames.Native.Cwrapper.ParticipantResults.ParticipantResults_HasResultsForParticipant(this.SelfPtr(), participantId);
    }

    internal uint PlacingForParticipant(string participantId)
    {
      return GooglePlayGames.Native.Cwrapper.ParticipantResults.ParticipantResults_PlaceForParticipant(this.SelfPtr(), participantId);
    }

    internal Types.MatchResult ResultsForParticipant(string participantId)
    {
      return GooglePlayGames.Native.Cwrapper.ParticipantResults.ParticipantResults_MatchResultForParticipant(this.SelfPtr(), participantId);
    }

    internal ParticipantResults WithResult(
      string participantId,
      uint placing,
      Types.MatchResult result)
    {
      return new ParticipantResults(GooglePlayGames.Native.Cwrapper.ParticipantResults.ParticipantResults_WithResult(this.SelfPtr(), participantId, placing, result));
    }

    protected override void CallDispose(HandleRef selfPointer)
    {
      GooglePlayGames.Native.Cwrapper.ParticipantResults.ParticipantResults_Dispose(selfPointer);
    }
  }
}
