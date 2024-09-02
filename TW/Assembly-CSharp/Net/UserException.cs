// Decompiled with JetBrains decompiler
// Type: Net.UserException
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using System;

#nullable disable
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
    {
      this.Arguments = arguments;
    }
  }
}
