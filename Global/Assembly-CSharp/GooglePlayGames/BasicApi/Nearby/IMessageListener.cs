// Decompiled with JetBrains decompiler
// Type: GooglePlayGames.BasicApi.Nearby.IMessageListener
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

#nullable disable
namespace GooglePlayGames.BasicApi.Nearby
{
  public interface IMessageListener
  {
    void OnMessageReceived(string remoteEndpointId, byte[] data, bool isReliableMessage);

    void OnRemoteEndpointDisconnected(string remoteEndpointId);
  }
}
