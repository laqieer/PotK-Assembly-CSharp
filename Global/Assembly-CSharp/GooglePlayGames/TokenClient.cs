﻿// Decompiled with JetBrains decompiler
// Type: GooglePlayGames.TokenClient
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GooglePlayGames.BasicApi;
using System;

#nullable disable
namespace GooglePlayGames
{
  internal interface TokenClient
  {
    string GetEmail();

    void GetEmail(Action<CommonStatusCodes, string> callback);

    string GetAccessToken();

    void GetIdToken(string serverClientId, Action<string> idTokenCallback);

    void SetRationale(string rationale);
  }
}
