// Decompiled with JetBrains decompiler
// Type: GooglePlayGames.BasicApi.Events.IEvent
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

#nullable disable
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
