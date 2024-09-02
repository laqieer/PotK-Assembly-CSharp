// Decompiled with JetBrains decompiler
// Type: LitJson.JsonException
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;

#nullable disable
namespace LitJson
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
