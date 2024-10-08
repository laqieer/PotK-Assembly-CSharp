﻿// Decompiled with JetBrains decompiler
// Type: GooglePlayGames.Android.TokenResult
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using Com.Google.Android.Gms.Common.Api;
using Google.Developers;
using System;

#nullable disable
namespace GooglePlayGames.Android
{
  internal class TokenResult : JavaObjWrapper, Result
  {
    public TokenResult(IntPtr ptr)
      : base(ptr)
    {
    }

    public Status getStatus()
    {
      return new Status(this.InvokeCall<IntPtr>(nameof (getStatus), "()Lcom/google/android/gms/common/api/Status;"));
    }

    public int getStatusCode() => this.InvokeCall<int>(nameof (getStatusCode), "()I");

    public string getAccessToken()
    {
      return this.InvokeCall<string>(nameof (getAccessToken), "()Ljava/lang/String;");
    }

    public string getEmail() => this.InvokeCall<string>(nameof (getEmail), "()Ljava/lang/String;");

    public string getIdToken()
    {
      return this.InvokeCall<string>(nameof (getIdToken), "()Ljava/lang/String;");
    }
  }
}
