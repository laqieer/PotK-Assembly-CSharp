﻿// Decompiled with JetBrains decompiler
// Type: GooglePlayGames.BasicApi.Events.IEvent
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

namespace GooglePlayGames.BasicApi.Events
{
  public interface IEvent
  {
    string Id { get; }

    string Name { get; }

    string Description { get; }

    string ImageUrl { get; }

    ulong CurrentCount { get; }

    EventVisibility Visibility { get; }
  }
}
