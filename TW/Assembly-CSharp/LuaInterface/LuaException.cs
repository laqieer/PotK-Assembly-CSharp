// Decompiled with JetBrains decompiler
// Type: LuaInterface.LuaException
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
