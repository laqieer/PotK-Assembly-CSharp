// Decompiled with JetBrains decompiler
// Type: GooglePlayGames.BasicApi.Multiplayer.RealTimeMultiplayerListener
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

#nullable disable
namespace GooglePlayGames.BasicApi.Multiplayer
{
  public interface RealTimeMultiplayerListener
  {
    void OnRoomSetupProgress(float percent);

    void OnRoomConnected(bool success);

    void OnLeftRoom();

    void OnParticipantLeft(Participant participant);

    void OnPeersConnected(string[] participantIds);

    void OnPeersDisconnected(string[] participantIds);

    void OnRealTimeMessageReceived(bool isReliable, string senderId, byte[] data);
  }
}
