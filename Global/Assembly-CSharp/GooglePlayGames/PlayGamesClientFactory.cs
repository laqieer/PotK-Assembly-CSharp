// Decompiled with JetBrains decompiler
// Type: GooglePlayGames.PlayGamesClientFactory
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GooglePlayGames.Android;
using GooglePlayGames.BasicApi;
using GooglePlayGames.Native;
using GooglePlayGames.OurUtils;
using UnityEngine;

#nullable disable
namespace GooglePlayGames
{
  internal class PlayGamesClientFactory
  {
    internal static IPlayGamesClient GetPlatformPlayGamesClient(PlayGamesClientConfiguration config)
    {
      if (Application.isEditor)
      {
        Logger.d("Creating IPlayGamesClient in editor, using DummyClient.");
        return (IPlayGamesClient) new DummyClient();
      }
      Logger.d("Creating Android IPlayGamesClient Client");
      return (IPlayGamesClient) new NativeClient(config, (IClientImpl) new AndroidClient());
    }
  }
}
