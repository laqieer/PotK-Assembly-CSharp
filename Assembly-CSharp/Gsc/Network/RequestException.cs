﻿// Decompiled with JetBrains decompiler
// Type: Gsc.Network.RequestException
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;
using System.Runtime.Serialization;

namespace Gsc.Network
{
  [Serializable]
  public class RequestException : Exception
  {
    public RequestException()
    {
    }

    public RequestException(string message)
      : base(message)
    {
    }

    public RequestException(string message, Exception inner)
      : base(message, inner)
    {
    }

    protected RequestException(SerializationInfo info, StreamingContext context)
      : base(info, context)
    {
    }
  }
}
