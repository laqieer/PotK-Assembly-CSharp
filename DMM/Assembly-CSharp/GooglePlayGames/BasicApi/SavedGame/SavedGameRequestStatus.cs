﻿// Decompiled with JetBrains decompiler
// Type: GooglePlayGames.BasicApi.SavedGame.SavedGameRequestStatus
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

namespace GooglePlayGames.BasicApi.SavedGame
{
  public enum SavedGameRequestStatus
  {
    BadInputError = -4, // 0xFFFFFFFC
    AuthenticationError = -3, // 0xFFFFFFFD
    InternalError = -2, // 0xFFFFFFFE
    TimeoutError = -1, // 0xFFFFFFFF
    Success = 1,
  }
}
