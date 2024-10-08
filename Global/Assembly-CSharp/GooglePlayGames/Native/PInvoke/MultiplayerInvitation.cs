﻿// Decompiled with JetBrains decompiler
// Type: GooglePlayGames.Native.PInvoke.MultiplayerInvitation
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GooglePlayGames.BasicApi.Multiplayer;
using GooglePlayGames.Native.Cwrapper;
using GooglePlayGames.OurUtils;
using System;
using System.Runtime.InteropServices;

#nullable disable
namespace GooglePlayGames.Native.PInvoke
{
  internal class MultiplayerInvitation : BaseReferenceHolder
  {
    internal MultiplayerInvitation(IntPtr selfPointer)
      : base(selfPointer)
    {
    }

    internal MultiplayerParticipant Inviter()
    {
      MultiplayerParticipant multiplayerParticipant = new MultiplayerParticipant(GooglePlayGames.Native.Cwrapper.MultiplayerInvitation.MultiplayerInvitation_InvitingParticipant(this.SelfPtr()));
      if (multiplayerParticipant.Valid())
        return multiplayerParticipant;
      multiplayerParticipant.Dispose();
      return (MultiplayerParticipant) null;
    }

    internal uint Variant() => GooglePlayGames.Native.Cwrapper.MultiplayerInvitation.MultiplayerInvitation_Variant(this.SelfPtr());

    internal Types.MultiplayerInvitationType Type()
    {
      return GooglePlayGames.Native.Cwrapper.MultiplayerInvitation.MultiplayerInvitation_Type(this.SelfPtr());
    }

    internal string Id()
    {
      return PInvokeUtilities.OutParamsToString((PInvokeUtilities.OutStringMethod) ((out_string, size) => GooglePlayGames.Native.Cwrapper.MultiplayerInvitation.MultiplayerInvitation_Id(this.SelfPtr(), out_string, size)));
    }

    protected override void CallDispose(HandleRef selfPointer)
    {
      GooglePlayGames.Native.Cwrapper.MultiplayerInvitation.MultiplayerInvitation_Dispose(selfPointer);
    }

    internal uint AutomatchingSlots()
    {
      return GooglePlayGames.Native.Cwrapper.MultiplayerInvitation.MultiplayerInvitation_AutomatchingSlotsAvailable(this.SelfPtr());
    }

    internal uint ParticipantCount()
    {
      return GooglePlayGames.Native.Cwrapper.MultiplayerInvitation.MultiplayerInvitation_Participants_Length(this.SelfPtr()).ToUInt32();
    }

    private static Invitation.InvType ToInvType(Types.MultiplayerInvitationType invitationType)
    {
      switch (invitationType)
      {
        case Types.MultiplayerInvitationType.TURN_BASED:
          return Invitation.InvType.TurnBased;
        case Types.MultiplayerInvitationType.REAL_TIME:
          return Invitation.InvType.RealTime;
        default:
          Logger.d("Found unknown invitation type: " + (object) invitationType);
          return Invitation.InvType.Unknown;
      }
    }

    internal Invitation AsInvitation()
    {
      Invitation.InvType invType = MultiplayerInvitation.ToInvType(this.Type());
      string invId = this.Id();
      int variant = (int) this.Variant();
      Participant inviter;
      using (MultiplayerParticipant multiplayerParticipant = this.Inviter())
        inviter = multiplayerParticipant?.AsParticipant();
      return new Invitation(invType, invId, inviter, variant);
    }

    internal static MultiplayerInvitation FromPointer(IntPtr selfPointer)
    {
      return PInvokeUtilities.IsNull(selfPointer) ? (MultiplayerInvitation) null : new MultiplayerInvitation(selfPointer);
    }
  }
}
