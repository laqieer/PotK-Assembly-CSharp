// Decompiled with JetBrains decompiler
// Type: JsonFormatter
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Text;

#nullable disable
public class JsonFormatter
{
  private const string Space = " ";
  private const int DefaultIndent = 0;
  private const string Indent = "    ";
  private static readonly string NewLine = "\n";
  private static bool inDoubleString = false;
  private static bool inSingleString = false;
  private static bool inVariableAssignment = false;
  private static char prevChar = char.MinValue;
  private static Stack<JsonFormatter.JsonContextType> context = new Stack<JsonFormatter.JsonContextType>();

  private static void BuildIndents(int indents, StringBuilder output)
  {
    for (indents = indents; indents > 0; --indents)
      output.Append("    ");
  }

  private static bool InString() => JsonFormatter.inDoubleString || JsonFormatter.inSingleString;

  public static string PrettyPrint(string input)
  {
    JsonFormatter.inDoubleString = false;
    JsonFormatter.inSingleString = false;
    JsonFormatter.inVariableAssignment = false;
    JsonFormatter.prevChar = char.MinValue;
    JsonFormatter.context.Clear();
    StringBuilder output = new StringBuilder(input.Length * 2);
    for (int index = 0; index < input.Length; ++index)
    {
      char ch1 = input[index];
      char ch2 = ch1;
      switch (ch2)
      {
        case ':':
          if (!JsonFormatter.InString())
          {
            JsonFormatter.inVariableAssignment = true;
            output.Append(" ");
            output.Append(ch1);
            output.Append(" ");
            break;
          }
          output.Append(ch1);
          break;
        case '=':
          output.Append(ch1);
          break;
        default:
          switch (ch2)
          {
            case ' ':
              if (JsonFormatter.InString())
              {
                output.Append(ch1);
                break;
              }
              break;
            case '"':
              if (!JsonFormatter.inSingleString && JsonFormatter.prevChar != '\\')
                JsonFormatter.inDoubleString = !JsonFormatter.inDoubleString;
              output.Append(ch1);
              break;
            default:
              switch (ch2)
              {
                case '[':
label_6:
                  if (!JsonFormatter.InString())
                  {
                    if (JsonFormatter.inVariableAssignment || JsonFormatter.context.Count > 0 && JsonFormatter.context.Peek() != JsonFormatter.JsonContextType.Array)
                    {
                      output.Append(JsonFormatter.NewLine);
                      JsonFormatter.BuildIndents(JsonFormatter.context.Count, output);
                    }
                    output.Append(ch1);
                    JsonFormatter.context.Push(JsonFormatter.JsonContextType.Object);
                    output.Append(JsonFormatter.NewLine);
                    JsonFormatter.BuildIndents(JsonFormatter.context.Count, output);
                    break;
                  }
                  output.Append(ch1);
                  break;
                case ']':
label_11:
                  if (!JsonFormatter.InString())
                  {
                    output.Append(JsonFormatter.NewLine);
                    int num = (int) JsonFormatter.context.Pop();
                    JsonFormatter.BuildIndents(JsonFormatter.context.Count, output);
                    output.Append(ch1);
                    break;
                  }
                  output.Append(ch1);
                  break;
                default:
                  switch (ch2)
                  {
                    case '{':
                      goto label_6;
                    case '}':
                      goto label_11;
                    default:
                      switch (ch2)
                      {
                        case '\'':
                          if (!JsonFormatter.inDoubleString && JsonFormatter.prevChar != '\\')
                            JsonFormatter.inSingleString = !JsonFormatter.inSingleString;
                          output.Append(ch1);
                          break;
                        case ',':
                          output.Append(ch1);
                          if (!JsonFormatter.InString())
                          {
                            JsonFormatter.BuildIndents(JsonFormatter.context.Count, output);
                            output.Append(JsonFormatter.NewLine);
                            JsonFormatter.BuildIndents(JsonFormatter.context.Count, output);
                            JsonFormatter.inVariableAssignment = false;
                            break;
                          }
                          break;
                        default:
                          output.Append(ch1);
                          break;
                      }
                      break;
                  }
              }
              break;
          }
          break;
      }
      JsonFormatter.prevChar = ch1;
    }
    return output.ToString();
  }

  private enum JsonContextType
  {
    Object,
    Array,
  }
}
