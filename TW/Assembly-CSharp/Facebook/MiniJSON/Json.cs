// Decompiled with JetBrains decompiler
// Type: Facebook.MiniJSON.Json
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

#nullable disable
namespace Facebook.MiniJSON
{
  public static class Json
  {
    private static NumberFormatInfo numberFormat = new CultureInfo("en-US").NumberFormat;

    public static object Deserialize(string json)
    {
      return json == null ? (object) null : Json.Parser.Parse(json);
    }

    public static string Serialize(object obj) => Json.Serializer.Serialize(obj);

    private sealed class Parser : IDisposable
    {
      private const string WhiteSpace = " \t\n\r";
      private const string WordBreak = " \t\n\r{}[],:\"";
      private StringReader json;

      private Parser(string jsonString) => this.json = new StringReader(jsonString);

      private char PeekChar => Convert.ToChar(this.json.Peek());

      private char NextChar => Convert.ToChar(this.json.Read());

      private string NextWord
      {
        get
        {
          StringBuilder stringBuilder = new StringBuilder();
          while (" \t\n\r{}[],:\"".IndexOf(this.PeekChar) == -1)
          {
            stringBuilder.Append(this.NextChar);
            if (this.json.Peek() == -1)
              break;
          }
          return stringBuilder.ToString();
        }
      }

      private Json.Parser.TOKEN NextToken
      {
        get
        {
          this.EatWhitespace();
          if (this.json.Peek() == -1)
            return Json.Parser.TOKEN.NONE;
          char peekChar = this.PeekChar;
          switch (peekChar)
          {
            case '"':
              return Json.Parser.TOKEN.STRING;
            case ',':
              this.json.Read();
              return Json.Parser.TOKEN.COMMA;
            case '-':
            case '0':
            case '1':
            case '2':
            case '3':
            case '4':
            case '5':
            case '6':
            case '7':
            case '8':
            case '9':
              return Json.Parser.TOKEN.NUMBER;
            case ':':
              return Json.Parser.TOKEN.COLON;
            default:
              switch (peekChar)
              {
                case '[':
                  return Json.Parser.TOKEN.SQUARED_OPEN;
                case ']':
                  this.json.Read();
                  return Json.Parser.TOKEN.SQUARED_CLOSE;
                default:
                  switch (peekChar)
                  {
                    case '{':
                      return Json.Parser.TOKEN.CURLY_OPEN;
                    case '}':
                      this.json.Read();
                      return Json.Parser.TOKEN.CURLY_CLOSE;
                    default:
                      string nextWord = this.NextWord;
                      if (nextWord != null)
                      {
                        if (Json.Parser.\u003C\u003Ef__switch\u0024map0 == null)
                          Json.Parser.\u003C\u003Ef__switch\u0024map0 = new Dictionary<string, int>(3)
                          {
                            {
                              "false",
                              0
                            },
                            {
                              "true",
                              1
                            },
                            {
                              "null",
                              2
                            }
                          };
                        int num;
                        if (Json.Parser.\u003C\u003Ef__switch\u0024map0.TryGetValue(nextWord, out num))
                        {
                          switch (num)
                          {
                            case 0:
                              return Json.Parser.TOKEN.FALSE;
                            case 1:
                              return Json.Parser.TOKEN.TRUE;
                            case 2:
                              return Json.Parser.TOKEN.NULL;
                          }
                        }
                      }
                      return Json.Parser.TOKEN.NONE;
                  }
              }
          }
        }
      }

      public static object Parse(string jsonString)
      {
        using (Json.Parser parser = new Json.Parser(jsonString))
          return parser.ParseValue();
      }

      public void Dispose()
      {
        this.json.Dispose();
        this.json = (StringReader) null;
      }

      private Dictionary<string, object> ParseObject()
      {
        Dictionary<string, object> dictionary = new Dictionary<string, object>();
        this.json.Read();
        while (true)
        {
          Json.Parser.TOKEN nextToken;
          do
          {
            nextToken = this.NextToken;
            switch (nextToken)
            {
              case Json.Parser.TOKEN.NONE:
                goto label_3;
              case Json.Parser.TOKEN.CURLY_CLOSE:
                goto label_4;
              default:
                continue;
            }
          }
          while (nextToken == Json.Parser.TOKEN.COMMA);
          string key = this.ParseString();
          if (key != null)
          {
            if (this.NextToken == Json.Parser.TOKEN.COLON)
            {
              this.json.Read();
              dictionary[key] = this.ParseValue();
            }
            else
              goto label_8;
          }
          else
            goto label_6;
        }
label_3:
        return (Dictionary<string, object>) null;
label_4:
        return dictionary;
label_6:
        return (Dictionary<string, object>) null;
label_8:
        return (Dictionary<string, object>) null;
      }

      private List<object> ParseArray()
      {
        List<object> array = new List<object>();
        this.json.Read();
        bool flag = true;
        while (flag)
        {
          Json.Parser.TOKEN nextToken = this.NextToken;
          Json.Parser.TOKEN token = nextToken;
          switch (token)
          {
            case Json.Parser.TOKEN.SQUARED_CLOSE:
              flag = false;
              continue;
            case Json.Parser.TOKEN.COMMA:
              continue;
            default:
              if (token == Json.Parser.TOKEN.NONE)
                return (List<object>) null;
              object byToken = this.ParseByToken(nextToken);
              array.Add(byToken);
              continue;
          }
        }
        return array;
      }

      private object ParseValue() => this.ParseByToken(this.NextToken);

      private object ParseByToken(Json.Parser.TOKEN token)
      {
        switch (token)
        {
          case Json.Parser.TOKEN.CURLY_OPEN:
            return (object) this.ParseObject();
          case Json.Parser.TOKEN.SQUARED_OPEN:
            return (object) this.ParseArray();
          case Json.Parser.TOKEN.STRING:
            return (object) this.ParseString();
          case Json.Parser.TOKEN.NUMBER:
            return this.ParseNumber();
          case Json.Parser.TOKEN.TRUE:
            return (object) true;
          case Json.Parser.TOKEN.FALSE:
            return (object) false;
          case Json.Parser.TOKEN.NULL:
            return (object) null;
          default:
            return (object) null;
        }
      }

      private string ParseString()
      {
        StringBuilder stringBuilder1 = new StringBuilder();
        this.json.Read();
        bool flag = true;
        while (flag)
        {
          if (this.json.Peek() == -1)
            break;
          char nextChar1 = this.NextChar;
          switch (nextChar1)
          {
            case '"':
              flag = false;
              continue;
            case '\\':
              if (this.json.Peek() == -1)
              {
                flag = false;
                continue;
              }
              char nextChar2 = this.NextChar;
              char ch = nextChar2;
              switch (ch)
              {
                case 'n':
                  stringBuilder1.Append('\n');
                  continue;
                case 'r':
                  stringBuilder1.Append('\r');
                  continue;
                case 't':
                  stringBuilder1.Append('\t');
                  continue;
                case 'u':
                  StringBuilder stringBuilder2 = new StringBuilder();
                  for (int index = 0; index < 4; ++index)
                    stringBuilder2.Append(this.NextChar);
                  stringBuilder1.Append((char) Convert.ToInt32(stringBuilder2.ToString(), 16));
                  continue;
                default:
                  if (ch != '"' && ch != '/' && ch != '\\')
                  {
                    switch (ch)
                    {
                      case 'b':
                        stringBuilder1.Append('\b');
                        continue;
                      case 'f':
                        stringBuilder1.Append('\f');
                        continue;
                      default:
                        continue;
                    }
                  }
                  else
                  {
                    stringBuilder1.Append(nextChar2);
                    continue;
                  }
              }
            default:
              stringBuilder1.Append(nextChar1);
              continue;
          }
        }
        return stringBuilder1.ToString();
      }

      private object ParseNumber()
      {
        string nextWord = this.NextWord;
        return nextWord.IndexOf('.') == -1 ? (object) long.Parse(nextWord, (IFormatProvider) Json.numberFormat) : (object) double.Parse(nextWord, (IFormatProvider) Json.numberFormat);
      }

      private void EatWhitespace()
      {
        while (" \t\n\r".IndexOf(this.PeekChar) != -1)
        {
          this.json.Read();
          if (this.json.Peek() == -1)
            break;
        }
      }

      private enum TOKEN
      {
        NONE,
        CURLY_OPEN,
        CURLY_CLOSE,
        SQUARED_OPEN,
        SQUARED_CLOSE,
        COLON,
        COMMA,
        STRING,
        NUMBER,
        TRUE,
        FALSE,
        NULL,
      }
    }

    private sealed class Serializer
    {
      private StringBuilder builder;

      private Serializer() => this.builder = new StringBuilder();

      public static string Serialize(object obj)
      {
        Json.Serializer serializer = new Json.Serializer();
        serializer.SerializeValue(obj);
        return serializer.builder.ToString();
      }

      private void SerializeValue(object value)
      {
        switch (value)
        {
          case null:
            this.builder.Append("null");
            break;
          case string str:
            this.SerializeString(str);
            break;
          case bool _:
            this.builder.Append(value.ToString().ToLower());
            break;
          case IList array:
            this.SerializeArray(array);
            break;
          case IDictionary dictionary:
            this.SerializeObject(dictionary);
            break;
          case char _:
            this.SerializeString(value.ToString());
            break;
          default:
            this.SerializeOther(value);
            break;
        }
      }

      private void SerializeObject(IDictionary obj)
      {
        bool flag = true;
        this.builder.Append('{');
        foreach (object key in (IEnumerable) obj.Keys)
        {
          if (!flag)
            this.builder.Append(',');
          this.SerializeString(key.ToString());
          this.builder.Append(':');
          this.SerializeValue(obj[key]);
          flag = false;
        }
        this.builder.Append('}');
      }

      private void SerializeArray(IList array)
      {
        this.builder.Append('[');
        bool flag = true;
        foreach (object obj in (IEnumerable) array)
        {
          if (!flag)
            this.builder.Append(',');
          this.SerializeValue(obj);
          flag = false;
        }
        this.builder.Append(']');
      }

      private void SerializeString(string str)
      {
        this.builder.Append('"');
        foreach (char ch1 in str.ToCharArray())
        {
          char ch2 = ch1;
          switch (ch2)
          {
            case '\b':
              this.builder.Append("\\b");
              break;
            case '\t':
              this.builder.Append("\\t");
              break;
            case '\n':
              this.builder.Append("\\n");
              break;
            case '\f':
              this.builder.Append("\\f");
              break;
            case '\r':
              this.builder.Append("\\r");
              break;
            default:
              switch (ch2)
              {
                case '"':
                  this.builder.Append("\\\"");
                  continue;
                case '\\':
                  this.builder.Append("\\\\");
                  continue;
                default:
                  int int32 = Convert.ToInt32(ch1);
                  if (int32 >= 32 && int32 <= 126)
                  {
                    this.builder.Append(ch1);
                    continue;
                  }
                  this.builder.Append("\\u" + Convert.ToString(int32, 16).PadLeft(4, '0'));
                  continue;
              }
          }
        }
        this.builder.Append('"');
      }

      private void SerializeOther(object value)
      {
        switch (value)
        {
          case float _:
          case int _:
          case uint _:
          case long _:
          case double _:
          case sbyte _:
          case byte _:
          case short _:
          case ushort _:
          case ulong _:
          case Decimal _:
            this.builder.Append(value.ToString());
            break;
          default:
            this.SerializeString(value.ToString());
            break;
        }
      }
    }
  }
}
