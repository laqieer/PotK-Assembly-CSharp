// Decompiled with JetBrains decompiler
// Type: LuaInterface.LuaException
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using System.Runtime.Serialization;

#nullable disable
namespace LuaInterface
{
  [Serializable]
  public class LuaException : Exception
  {
    public LuaException()
    {
    }

    public LuaException(string message)
      : base(message)
    {
    }

    public LuaException(string message, Exception innerException)
      : base(message, innerException)
    {
    }

    protected LuaException(SerializationInfo info, StreamingContext context)
      : base(info, context)
    {
    }
  }
}
