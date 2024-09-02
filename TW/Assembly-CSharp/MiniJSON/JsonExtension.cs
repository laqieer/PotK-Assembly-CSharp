// Decompiled with JetBrains decompiler
// Type: MiniJSON.JsonExtension
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UniLinq;

#nullable disable
namespace MiniJSON
{
  public static class JsonExtension
  {
    public static string FormattedSerialize(object obj, bool sortKeys = true, int indentWidth = 4)
    {
      return JsonExtension.Serializer.Serialize(obj, sortKeys, indentWidth);
    }

    private sealed class Serializer
    {
      private StringBuilder builder;
      private bool sortKeys;
      private int indentWidth;
      private int indent;

      private Serializer(bool sortKeys, int indentWidth)
      {
        this.builder = new StringBuilder();
        this.sortKeys = sortKeys;
        this.indentWidth = indentWidth;
        this.indent = 0;
      }

      public static string Serialize(object obj, bool sortKeys, int indentWidth)
      {
        JsonExtension.Serializer serializer = new JsonExtension.Serializer(sortKeys, indentWidth);
        serializer.SerializeValue(obj);
        return serializer.builder.ToString();
      }

      private void DoIndent(int v)
      {
        this.builder.Append('\n');
        this.indent += v;
        this.builder.Append(new string(' ', this.indent * this.indentWidth));
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
          case IList anArray:
            this.SerializeArray(anArray);
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
        this.DoIndent(1);
        List<DictionaryEntry> source = new List<DictionaryEntry>();
        foreach (DictionaryEntry dictionaryEntry in obj)
          source.Add(dictionaryEntry);
        if (this.sortKeys)
          source = source.OrderBy<DictionaryEntry, string>((Func<DictionaryEntry, string>) (p => p.Key.ToString())).ToList<DictionaryEntry>();
        foreach (DictionaryEntry dictionaryEntry in source)
        {
          if (!flag)
          {
            this.builder.Append(',');
            this.DoIndent(0);
          }
          this.SerializeString(dictionaryEntry.Key.ToString());
          this.builder.Append(": ");
          this.SerializeValue(dictionaryEntry.Value);
          flag = false;
        }
        this.DoIndent(-1);
        this.builder.Append('}');
      }

      private void SerializeArray(IList anArray)
      {
        this.builder.Append('[');
        this.DoIndent(1);
        bool flag = true;
        foreach (object an in (IEnumerable) anArray)
        {
          if (!flag)
          {
            this.builder.Append(',');
            this.DoIndent(0);
          }
          this.SerializeValue(an);
          flag = false;
        }
        this.DoIndent(-1);
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
