﻿// Decompiled with JetBrains decompiler
// Type: GooglePlayGames.Native.PInvoke.TurnBasedMatchConfigBuilder
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;
using System.Runtime.InteropServices;

#nullable disable
namespace GooglePlayGames.Native.PInvoke
{
  internal class TurnBasedMatchConfigBuilder : BaseReferenceHolder
  {
    private TurnBasedMatchConfigBuilder(IntPtr selfPointer)
      : base(selfPointer)
    {
    }

    internal TurnBasedMatchConfigBuilder PopulateFromUIResponse(PlayerSelectUIResponse response)
    {
      GooglePlayGames.Native.Cwrapper.TurnBasedMatchConfigBuilder.TurnBasedMatchConfig_Builder_PopulateFromPlayerSelectUIResponse(this.SelfPtr(), response.AsPointer());
      return this;
    }

    internal TurnBasedMatchConfigBuilder SetVariant(uint variant)
    {
      GooglePlayGames.Native.Cwrapper.TurnBasedMatchConfigBuilder.TurnBasedMatchConfig_Builder_SetVariant(this.SelfPtr(), variant);
      return this;
    }

    internal TurnBasedMatchConfigBuilder AddInvitedPlayer(string playerId)
    {
      GooglePlayGames.Native.Cwrapper.TurnBasedMatchConfigBuilder.TurnBasedMatchConfig_Builder_AddPlayerToInvite(this.SelfPtr(), playerId);
      return this;
    }

    internal TurnBasedMatchConfigBuilder SetExclusiveBitMask(ulong bitmask)
    {
      GooglePlayGames.Native.Cwrapper.TurnBasedMatchConfigBuilder.TurnBasedMatchConfig_Builder_SetExclusiveBitMask(this.SelfPtr(), bitmask);
      return this;
    }

    internal TurnBasedMatchConfigBuilder SetMinimumAutomatchingPlayers(uint minimum)
    {
      GooglePlayGames.Native.Cwrapper.TurnBasedMatchConfigBuilder.TurnBasedMatchConfig_Builder_SetMinimumAutomatchingPlayers(this.SelfPtr(), minimum);
      return this;
    }

    internal TurnBasedMatchConfigBuilder SetMaximumAutomatchingPlayers(uint maximum)
    {
      GooglePlayGames.Native.Cwrapper.TurnBasedMatchConfigBuilder.TurnBasedMatchConfig_Builder_SetMaximumAutomatchingPlayers(this.SelfPtr(), maximum);
      return this;
    }

    internal TurnBasedMatchConfig Build()
    {
      return new TurnBasedMatchConfig(GooglePlayGames.Native.Cwrapper.TurnBasedMatchConfigBuilder.TurnBasedMatchConfig_Builder_Create(this.SelfPtr()));
    }

    protected override void CallDispose(HandleRef selfPointer)
    {
      GooglePlayGames.Native.Cwrapper.TurnBasedMatchConfigBuilder.TurnBasedMatchConfig_Builder_Dispose(selfPointer);
    }

    internal static TurnBasedMatchConfigBuilder Create()
    {
      return new TurnBasedMatchConfigBuilder(GooglePlayGames.Native.Cwrapper.TurnBasedMatchConfigBuilder.TurnBasedMatchConfig_Builder_Construct());
    }
  }
}
