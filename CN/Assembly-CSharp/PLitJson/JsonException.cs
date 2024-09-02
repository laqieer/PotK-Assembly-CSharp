// Decompiled with JetBrains decompiler
// Type: PLitJson.JsonException
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
