﻿// Decompiled with JetBrains decompiler
// Type: Net.UserException
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using System;

namespace Net
{
  public class UserException : Exception
  {
    public AssocList<string, object> Arguments;

    public UserException()
    {
    }

    public UserException(AssocList<string, object> arguments)
      : base((string) arguments["message"])
      => this.Arguments = arguments;
  }
}
