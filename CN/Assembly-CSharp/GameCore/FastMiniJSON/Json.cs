﻿// Decompiled with JetBrains decompiler
// Type: GameCore.FastMiniJSON.Json
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.IO;

#nullable disable
namespace GameCore.FastMiniJSON
{
  public static class Json
  {
    private const string WHITE_SPACE = " \t\n\r";
    private const string WORD_BREAK = " \t\n\r{}[],:\"";
    private static readonly bool[] WHITE_SPACE_TABLE = new bool[128]
    {
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      true,
      true,
      false,
      false,
      true,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      true,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false
    };
    private static readonly bool[] WORD_BREAK_TABLE = new bool[128]
    {
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      true,
      true,
      false,
      false,
      true,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      true,
      false,
      true,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      true,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      true,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      true,
      false,
      true,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      false,
      true,
      false,
      true,
      false,
      false
    };
    private static readonly int[] HEX_TO_INT_TABLE = new int[128]
    {
      0,
      0,
      0,
      0,
      0,
      0,
      0,
      0,
      0,
      0,
      0,
      0,
      0,
      0,
      0,
      0,
      0,
      0,
      0,
      0,
      0,
      0,
      0,
      0,
      0,
      0,
      0,
      0,
      0,
      0,
      0,
      0,
      0,
      0,
      0,
      0,
      0,
      0,
      0,
      0,
      0,
      0,
      0,
      0,
      0,
      0,
      0,
      0,
      0,
      1,
      2,
      3,
      4,
      5,
      6,
      7,
      8,
      9,
      0,
      0,
      0,
      0,
      0,
      0,
      0,
      10,
      11,
      12,
      13,
      14,
      15,
      0,
      0,
      0,
      0,
      0,
      0,
      0,
      0,
      0,
      0,
      0,
      0,
      0,
      0,
      0,
      0,
      0,
      0,
      0,
      0,
      0,
      0,
      0,
      0,
      0,
      0,
      10,
      11,
      12,
      13,
      14,
      15,
      0,
      0,
      0,
      0,
      0,
      0,
      0,
      0,
      0,
      0,
      0,
      0,
      0,
      0,
      0,
      0,
      0,
      0,
      0,
      0,
      0,
      0,
      0,
      0,
      0
    };

    public static object Deserialize(string json)
    {
      return json == null ? (object) null : Json.Parser.Parse(json);
    }

    public static object Deserialize(byte[] bytes)
    {
      if (bytes == null)
        return (object) null;
      using (MemoryStream memoryStream = new MemoryStream(bytes))
      {
        using (StreamReader stream = new StreamReader((Stream) memoryStream))
          return Json.StreamParser.Parse(stream);
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

    private sealed class Parser : IDisposable
    {
      private char[] buffer;
      private int bufferSize;
      private string json;
      private int current;
      private int length;

      private Parser(string json)
      {
        this.json = json;
        this.length = json.Length;
        this.buffer = new char[1024];
        this.bufferSize = 0;
      }

      private void AppendToBuffer(char c)
      {
        if (this.bufferSize == this.buffer.Length)
          Array.Resize<char>(ref this.buffer, this.bufferSize * 2);
        this.buffer[this.bufferSize++] = c;
      }

      private string ToStringFromBuffer()
      {
        return string.Intern(new string(this.buffer, 0, this.bufferSize));
      }

      private void ClearBuffer() => this.bufferSize = 0;

      public static object Parse(string json)
      {
        using (Json.Parser parser = new Json.Parser(json))
          return parser.ParseValue();
      }

      public void Dispose()
      {
      }

      private Dictionary<string, object> ParseObject()
      {
        Dictionary<string, object> dictionary = new Dictionary<string, object>();
        ++this.current;
        while (true)
        {
          Json.TOKEN nextToken;
          do
          {
            nextToken = this.NextToken;
            switch (nextToken)
            {
              case Json.TOKEN.NONE:
                goto label_3;
              case Json.TOKEN.CURLY_CLOSE:
                goto label_4;
              default:
                continue;
            }
          }
          while (nextToken == Json.TOKEN.COMMA);
          string key = this.ParseString();
          if (key != null)
          {
            if (this.NextToken == Json.TOKEN.COLON)
            {
              ++this.current;
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
        ++this.current;
        bool flag = true;
        while (flag)
        {
          Json.TOKEN nextToken = this.NextToken;
          Json.TOKEN token = nextToken;
          switch (token)
          {
            case Json.TOKEN.SQUARED_CLOSE:
              flag = false;
              continue;
            case Json.TOKEN.COMMA:
              continue;
            default:
              if (token == Json.TOKEN.NONE)
                return (List<object>) null;
              object byToken = this.ParseByToken(nextToken);
              array.Add(byToken);
              continue;
          }
        }
        return array;
      }

      private object ParseValue() => this.ParseByToken(this.NextToken);

      private object ParseByToken(Json.TOKEN token)
      {
        switch (token)
        {
          case Json.TOKEN.CURLY_OPEN:
            return (object) this.ParseObject();
          case Json.TOKEN.SQUARED_OPEN:
            return (object) this.ParseArray();
          case Json.TOKEN.STRING:
            return (object) this.ParseString();
          case Json.TOKEN.NUMBER:
            return this.ParseNumber();
          case Json.TOKEN.TRUE:
            return (object) true;
          case Json.TOKEN.FALSE:
            return (object) false;
          case Json.TOKEN.NULL:
            return (object) null;
          default:
            return (object) null;
        }
      }

      private string ParseString()
      {
        this.ClearBuffer();
        ++this.current;
        bool flag = true;
        while (flag)
        {
          if (this.EOF)
            break;
          char nextChar1 = this.NextChar;
          switch (nextChar1)
          {
            case '"':
              flag = false;
              continue;
            case '\\':
              if (this.EOF)
              {
                flag = false;
                continue;
              }
              char nextChar2 = this.NextChar;
              char ch = nextChar2;
              switch (ch)
              {
                case 'n':
                  this.AppendToBuffer('\n');
                  continue;
                case 'r':
                  this.AppendToBuffer('\r');
                  continue;
                case 't':
                  this.AppendToBuffer('\t');
                  continue;
                case 'u':
                  this.AppendToBuffer((char) (Json.HEX_TO_INT_TABLE[(int) this.json[this.current]] << 12 | Json.HEX_TO_INT_TABLE[(int) this.json[this.current + 1]] << 8 | Json.HEX_TO_INT_TABLE[(int) this.json[this.current + 2]] << 4 | Json.HEX_TO_INT_TABLE[(int) this.json[this.current + 3]]));
                  this.current += 4;
                  continue;
                default:
                  if (ch != '"' && ch != '/' && ch != '\\')
                  {
                    switch (ch)
                    {
                      case 'b':
                        this.AppendToBuffer('\b');
                        continue;
                      case 'f':
                        this.AppendToBuffer('\f');
                        continue;
                      default:
                        continue;
                    }
                  }
                  else
                  {
                    this.AppendToBuffer(nextChar2);
                    continue;
                  }
              }
            default:
              this.AppendToBuffer(nextChar1);
              continue;
          }
        }
        return this.ToStringFromBuffer();
      }

      private object ParseNumber()
      {
        int startIndex;
        int length;
        this.NextWord(out startIndex, out length);
        if (this.json.IndexOf('.', startIndex, length) == -1)
        {
          int num1 = startIndex + length;
          int num2 = this.json[startIndex] != '-' ? 1 : -1;
          long num3 = 0;
          for (int index = startIndex; index < num1; ++index)
            num3 = num3 * 10L + (long) Json.HEX_TO_INT_TABLE[(int) this.json[index]];
          return (object) (num3 * (long) num2);
        }
        double result;
        double.TryParse(this.json.Substring(startIndex, length), out result);
        return (object) result;
      }

      private bool EOF => this.current == this.length;

      private void EatWhitespace()
      {
        while (!this.EOF && Json.WHITE_SPACE_TABLE[(int) this.PeekChar])
          ++this.current;
      }

      private char PeekChar => this.json[this.current];

      private char NextChar => this.json[this.current++];

      private void NextWord(out int startIndex, out int length)
      {
        int current = this.current;
        while (!this.EOF && !Json.WORD_BREAK_TABLE[(int) this.PeekChar])
          ++this.current;
        startIndex = current;
        length = this.current - current;
      }

      private Json.TOKEN NextToken
      {
        get
        {
          this.EatWhitespace();
          if (this.EOF)
            return Json.TOKEN.NONE;
          char peekChar = this.PeekChar;
          switch (peekChar)
          {
            case '"':
              return Json.TOKEN.STRING;
            case ',':
              ++this.current;
              return Json.TOKEN.COMMA;
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
              return Json.TOKEN.NUMBER;
            case ':':
              return Json.TOKEN.COLON;
            default:
              switch (peekChar)
              {
                case '[':
                  return Json.TOKEN.SQUARED_OPEN;
                case ']':
                  ++this.current;
                  return Json.TOKEN.SQUARED_CLOSE;
                default:
                  switch (peekChar)
                  {
                    case '{':
                      return Json.TOKEN.CURLY_OPEN;
                    case '}':
                      ++this.current;
                      return Json.TOKEN.CURLY_CLOSE;
                    default:
                      int startIndex;
                      this.NextWord(out startIndex, out int _);
                      switch (this.json[startIndex])
                      {
                        case 'f':
                          return Json.TOKEN.FALSE;
                        case 'n':
                          return Json.TOKEN.NULL;
                        case 't':
                          return Json.TOKEN.TRUE;
                        default:
                          return Json.TOKEN.NONE;
                      }
                  }
              }
          }
        }
      }
    }

    private sealed class StreamParser : IDisposable
    {
      private char[] buffer;
      private int bufferSize;
      private StreamReader stream;
      private char[] streamBuffer = new char[1];
      private char[] wordBuffer = new char[512];

      private StreamParser(StreamReader stream)
      {
        this.stream = stream;
        this.buffer = new char[1024];
        this.bufferSize = 0;
        if (this.EOF)
          return;
        this.stream.Read(this.streamBuffer, 0, 1);
      }

      private void AppendToBuffer(char c)
      {
        if (this.bufferSize == this.buffer.Length)
          Array.Resize<char>(ref this.buffer, this.bufferSize * 2);
        this.buffer[this.bufferSize++] = c;
      }

      private string ToStringFromBuffer()
      {
        return string.Intern(new string(this.buffer, 0, this.bufferSize));
      }

      private void ClearBuffer() => this.bufferSize = 0;

      public static object Parse(StreamReader stream)
      {
        using (Json.StreamParser streamParser = new Json.StreamParser(stream))
          return streamParser.ParseValue();
      }

      public void Dispose()
      {
      }

      private Dictionary<string, object> ParseObject()
      {
        Dictionary<string, object> dictionary = new Dictionary<string, object>();
        this.Read();
        while (true)
        {
          Json.TOKEN nextToken;
          do
          {
            nextToken = this.NextToken;
            switch (nextToken)
            {
              case Json.TOKEN.NONE:
                goto label_3;
              case Json.TOKEN.CURLY_CLOSE:
                goto label_4;
              default:
                continue;
            }
          }
          while (nextToken == Json.TOKEN.COMMA);
          string key = this.ParseString();
          if (key != null)
          {
            if (this.NextToken == Json.TOKEN.COLON)
            {
              this.Read();
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
        this.Read();
        bool flag = true;
        while (flag)
        {
          Json.TOKEN nextToken = this.NextToken;
          Json.TOKEN token = nextToken;
          switch (token)
          {
            case Json.TOKEN.SQUARED_CLOSE:
              flag = false;
              continue;
            case Json.TOKEN.COMMA:
              continue;
            default:
              if (token == Json.TOKEN.NONE)
                return (List<object>) null;
              object byToken = this.ParseByToken(nextToken);
              array.Add(byToken);
              continue;
          }
        }
        return array;
      }

      private object ParseValue() => this.ParseByToken(this.NextToken);

      private object ParseByToken(Json.TOKEN token)
      {
        switch (token)
        {
          case Json.TOKEN.CURLY_OPEN:
            return (object) this.ParseObject();
          case Json.TOKEN.SQUARED_OPEN:
            return (object) this.ParseArray();
          case Json.TOKEN.STRING:
            return (object) this.ParseString();
          case Json.TOKEN.NUMBER:
            return this.ParseNumber();
          case Json.TOKEN.TRUE:
            return (object) true;
          case Json.TOKEN.FALSE:
            return (object) false;
          case Json.TOKEN.NULL:
            return (object) null;
          default:
            return (object) null;
        }
      }

      private string ParseString()
      {
        this.ClearBuffer();
        this.Read();
        bool flag = true;
        while (flag)
        {
          if (this.EOF)
            break;
          char nextChar1 = this.NextChar;
          switch (nextChar1)
          {
            case '"':
              flag = false;
              continue;
            case '\\':
              if (this.EOF)
              {
                flag = false;
                continue;
              }
              char nextChar2 = this.NextChar;
              char ch = nextChar2;
              switch (ch)
              {
                case 'n':
                  this.AppendToBuffer('\n');
                  continue;
                case 'r':
                  this.AppendToBuffer('\r');
                  continue;
                case 't':
                  this.AppendToBuffer('\t');
                  continue;
                case 'u':
                  this.stream.Read(this.streamBuffer, 0, 1);
                  int num1 = Json.HEX_TO_INT_TABLE[(int) this.streamBuffer[0]];
                  this.stream.Read(this.streamBuffer, 0, 1);
                  int num2 = Json.HEX_TO_INT_TABLE[(int) this.streamBuffer[0]];
                  this.stream.Read(this.streamBuffer, 0, 1);
                  int num3 = Json.HEX_TO_INT_TABLE[(int) this.streamBuffer[0]];
                  this.stream.Read(this.streamBuffer, 0, 1);
                  int num4 = Json.HEX_TO_INT_TABLE[(int) this.streamBuffer[0]];
                  this.AppendToBuffer((char) (num1 << 12 | num2 << 8 | num3 << 4 | num4));
                  continue;
                default:
                  if (ch != '"' && ch != '/' && ch != '\\')
                  {
                    switch (ch)
                    {
                      case 'b':
                        this.AppendToBuffer('\b');
                        continue;
                      case 'f':
                        this.AppendToBuffer('\f');
                        continue;
                      default:
                        continue;
                    }
                  }
                  else
                  {
                    this.AppendToBuffer(nextChar2);
                    continue;
                  }
              }
            default:
              this.AppendToBuffer(nextChar1);
              continue;
          }
        }
        return this.ToStringFromBuffer();
      }

      private object ParseNumber()
      {
        int count = 0;
        this.NextWord(out count);
        if (Array.IndexOf<char>(this.wordBuffer, '.', 0, count) == -1)
        {
          int num1 = this.wordBuffer[0] != '-' ? 1 : -1;
          long num2 = 0;
          for (int index = 0; index < count; ++index)
            num2 = num2 * 10L + (long) Json.HEX_TO_INT_TABLE[(int) this.wordBuffer[index]];
          return (object) (num2 * (long) num1);
        }
        double result;
        double.TryParse(new string(this.wordBuffer), out result);
        return (object) result;
      }

      private bool EOF => this.stream.EndOfStream;

      private void EatWhitespace()
      {
        while (!this.EOF && Json.WHITE_SPACE_TABLE[(int) this.PeekChar])
          this.stream.Read(this.streamBuffer, 0, 1);
      }

      private char PeekChar => this.streamBuffer[0];

      private char NextChar
      {
        get
        {
          char nextChar = this.streamBuffer[0];
          if (!this.EOF)
            this.stream.Read(this.streamBuffer, 0, 1);
          return nextChar;
        }
      }

      private void NextWord(out int count)
      {
        count = 0;
        while (!this.EOF && !Json.WORD_BREAK_TABLE[(int) this.PeekChar])
        {
          char[] wordBuffer = this.wordBuffer;
          int num;
          count = (num = count) + 1;
          int index = num;
          int nextChar = (int) this.NextChar;
          wordBuffer[index] = (char) nextChar;
        }
      }

      private Json.TOKEN NextToken
      {
        get
        {
          this.EatWhitespace();
          char peekChar = this.PeekChar;
          switch (peekChar)
          {
            case '"':
              return Json.TOKEN.STRING;
            case ',':
              this.Read();
              return Json.TOKEN.COMMA;
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
              return Json.TOKEN.NUMBER;
            case ':':
              return Json.TOKEN.COLON;
            default:
              switch (peekChar)
              {
                case '[':
                  return Json.TOKEN.SQUARED_OPEN;
                case ']':
                  this.Read();
                  return Json.TOKEN.SQUARED_CLOSE;
                default:
                  switch (peekChar)
                  {
                    case '{':
                      return Json.TOKEN.CURLY_OPEN;
                    case '}':
                      this.Read();
                      return Json.TOKEN.CURLY_CLOSE;
                    default:
                      int count = 0;
                      this.NextWord(out count);
                      switch (this.wordBuffer[0])
                      {
                        case 'f':
                          return Json.TOKEN.FALSE;
                        case 'n':
                          return Json.TOKEN.NULL;
                        case 't':
                          return Json.TOKEN.TRUE;
                        default:
                          return Json.TOKEN.NONE;
                      }
                  }
              }
          }
        }
      }

      public void Read()
      {
        if (this.EOF)
          return;
        this.stream.Read(this.streamBuffer, 0, 1);
      }
    }
  }
}
