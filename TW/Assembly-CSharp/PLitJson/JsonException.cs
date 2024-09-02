// Decompiled with JetBrains decompiler
// Type: PLitJson.JsonException
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;

#nullable disable
namespace PLitJson
{
  public class JsonException : ApplicationException
  {
    public JsonException()
    {
    }

    internal JsonException(ParserToken token)
      : base(string.Format("Invalid token '{0}' in input string", (object) token))
    {
    }

    internal JsonException(ParserToken token, Exception inner_exception)
      : base(string.Format("Invalid token '{0}' in input string", (object) token), inner_exception)
    {
    }

    internal JsonException(int c)
      : base(string.Format("Invalid character '{0}' in input string", (object) (char) c))
    {
    }

    internal JsonException(int c, Exception inner_exception)
      : base(string.Format("Invalid character '{0}' in input string", (object) (char) c), inner_exception)
    {
    }

    public JsonException(string message)
      : base(message)
    {
    }

    public JsonException(string message, Exception inner_exception)
      : base(message, inner_exception)
    {
    }
  }
}
