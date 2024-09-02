// Decompiled with JetBrains decompiler
// Type: HTTP.JsonSerializer
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FC6F22C0-326E-48ED-B5EE-59590337E752
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp-firstpass.dll

using System;
using System.Collections;
using System.Globalization;
using System.Reflection;
using System.Text;

#nullable disable
namespace HTTP
{
  public class JsonSerializer
  {
    public const int TOKEN_NONE = 0;
    public const int TOKEN_CURLY_OPEN = 1;
    public const int TOKEN_CURLY_CLOSE = 2;
    public const int TOKEN_SQUARED_OPEN = 3;
    public const int TOKEN_SQUARED_CLOSE = 4;
    public const int TOKEN_COLON = 5;
    public const int TOKEN_COMMA = 6;
    public const int TOKEN_STRING = 7;
    public const int TOKEN_NUMBER = 8;
    public const int TOKEN_TRUE = 9;
    public const int TOKEN_FALSE = 10;
    public const int TOKEN_NULL = 11;

    public static object Decode(byte[] json)
    {
      return JsonSerializer.Decode(Encoding.ASCII.GetString(json));
    }

    public static object Decode(string json)
    {
      bool success = true;
      return JsonSerializer.Decode(json, ref success);
    }

    public static void Decode(object instance, string json)
    {
      object obj = JsonSerializer.Decode(json);
      JsonSerializer.PopulateObject(instance.GetType(), obj, instance);
    }

    public static object Decode(string json, ref bool success)
    {
      success = true;
      if (json == null)
        return (object) null;
      char[] charArray = json.ToCharArray();
      int index = 0;
      return JsonSerializer.ParseValue(charArray, ref index, ref success);
    }

    public static string Encode(object json)
    {
      StringBuilder builder = new StringBuilder();
      return JsonSerializer.SerializeValue(json, builder) ? builder.ToString() : (string) null;
    }

    public static T Decode<T>(byte[] json) where T : class, new()
    {
      return JsonSerializer.Decode<T>(Encoding.ASCII.GetString(json));
    }

    public static T Decode<T>(string json) where T : class, new()
    {
      bool success = true;
      return JsonSerializer.PopulateObject(typeof (T), JsonSerializer.Decode(json, ref success)) as T;
    }

    private static object PopulateObject(Type T, object obj)
    {
      return JsonSerializer.PopulateObject(T, obj, (object) null);
    }

    private static object PopulateObject(Type T, object obj, object instance)
    {
      if (obj == null)
        return (object) null;
      if (T.IsAssignableFrom(obj.GetType()))
      {
        instance = obj;
      }
      else
      {
        switch (obj)
        {
          case Hashtable _:
            Hashtable hashtable = (Hashtable) obj;
            if (instance == null)
              instance = Activator.CreateInstance(T);
            foreach (FieldInfo field in T.GetFields())
            {
              if (hashtable.ContainsKey((object) field.Name))
                field.SetValue(instance, JsonSerializer.PopulateObject(field.FieldType, hashtable[(object) field.Name]));
            }
            break;
          case IEnumerable _:
            if (instance == null)
              instance = Activator.CreateInstance(T);
            if (instance is IList list)
            {
              Type T1 = typeof (object);
              Type type = instance.GetType();
              if (type.IsGenericType)
              {
                Type[] genericArguments = type.GetGenericArguments();
                if (genericArguments.Length != 1)
                  return (object) null;
                T1 = genericArguments[0];
              }
              IEnumerator enumerator = ((IEnumerable) obj).GetEnumerator();
              try
              {
                while (enumerator.MoveNext())
                {
                  object current = enumerator.Current;
                  list.Add(JsonSerializer.PopulateObject(T1, current));
                }
                break;
              }
              finally
              {
                if (enumerator is IDisposable disposable)
                  disposable.Dispose();
              }
            }
            else
              break;
        }
      }
      return instance;
    }

    protected static Hashtable ParseObject(char[] json, ref int index, ref bool success)
    {
      Hashtable hashtable = new Hashtable();
      JsonSerializer.NextToken(json, ref index);
      bool flag = false;
      while (!flag)
      {
        switch (JsonSerializer.LookAhead(json, index))
        {
          case 0:
            success = false;
            return (Hashtable) null;
          case 2:
            JsonSerializer.NextToken(json, ref index);
            return hashtable;
          case 6:
            JsonSerializer.NextToken(json, ref index);
            continue;
          default:
            string key = JsonSerializer.ParseString(json, ref index, ref success);
            if (!success)
            {
              success = false;
              return (Hashtable) null;
            }
            if (JsonSerializer.NextToken(json, ref index) != 5)
            {
              success = false;
              return (Hashtable) null;
            }
            object obj = JsonSerializer.ParseValue(json, ref index, ref success);
            if (!success)
            {
              success = false;
              return (Hashtable) null;
            }
            hashtable[(object) key] = obj;
            continue;
        }
      }
      return hashtable;
    }

    protected static ArrayList ParseArray(char[] json, ref int index, ref bool success)
    {
      ArrayList array = new ArrayList();
      JsonSerializer.NextToken(json, ref index);
      bool flag = false;
      while (!flag)
      {
        switch (JsonSerializer.LookAhead(json, index))
        {
          case 0:
            success = false;
            return (ArrayList) null;
          case 4:
            JsonSerializer.NextToken(json, ref index);
            goto label_9;
          case 6:
            JsonSerializer.NextToken(json, ref index);
            continue;
          default:
            object obj = JsonSerializer.ParseValue(json, ref index, ref success);
            if (!success)
              return (ArrayList) null;
            array.Add(obj);
            continue;
        }
      }
label_9:
      return array;
    }

    protected static object ParseValue(char[] json, ref int index, ref bool success)
    {
      switch (JsonSerializer.LookAhead(json, index))
      {
        case 1:
          return (object) JsonSerializer.ParseObject(json, ref index, ref success);
        case 3:
          return (object) JsonSerializer.ParseArray(json, ref index, ref success);
        case 7:
          return (object) JsonSerializer.ParseString(json, ref index, ref success);
        case 8:
          return JsonSerializer.ParseNumber(json, ref index, ref success);
        case 9:
          JsonSerializer.NextToken(json, ref index);
          return (object) true;
        case 10:
          JsonSerializer.NextToken(json, ref index);
          return (object) false;
        case 11:
          JsonSerializer.NextToken(json, ref index);
          return (object) null;
        default:
          success = false;
          return (object) null;
      }
    }

    protected static string ParseString(char[] json, ref int index, ref bool success)
    {
      StringBuilder stringBuilder = new StringBuilder();
      JsonSerializer.EatWhitespace(json, ref index);
      char[] chArray1 = json;
      int num1;
      index = (num1 = index) + 1;
      int index1 = num1;
      char ch1 = chArray1[index1];
      bool flag = false;
      while (!flag && index != json.Length)
      {
        char[] chArray2 = json;
        int num2;
        index = (num2 = index) + 1;
        int index2 = num2;
        char ch2 = chArray2[index2];
        switch (ch2)
        {
          case '"':
            flag = true;
            goto label_19;
          case '\\':
            if (index != json.Length)
            {
              char[] chArray3 = json;
              int num3;
              index = (num3 = index) + 1;
              int index3 = num3;
              switch (chArray3[index3])
              {
                case '"':
                  stringBuilder.Append('"');
                  continue;
                case '/':
                  stringBuilder.Append('/');
                  continue;
                case '\\':
                  stringBuilder.Append('\\');
                  continue;
                case 'b':
                  stringBuilder.Append('\b');
                  continue;
                case 'f':
                  stringBuilder.Append('\f');
                  continue;
                case 'n':
                  stringBuilder.Append('\n');
                  continue;
                case 'r':
                  stringBuilder.Append('\r');
                  continue;
                case 't':
                  stringBuilder.Append('\t');
                  continue;
                case 'u':
                  if (json.Length - index >= 4)
                  {
                    uint result;
                    if (!(success = uint.TryParse(new string(json, index, 4), NumberStyles.HexNumber, (IFormatProvider) CultureInfo.InvariantCulture, out result)))
                      return string.Empty;
                    stringBuilder.Append(char.ConvertFromUtf32((int) result));
                    index += 4;
                    continue;
                  }
                  goto label_19;
                default:
                  continue;
              }
            }
            else
              goto label_19;
          default:
            stringBuilder.Append(ch2);
            continue;
        }
      }
label_19:
      if (flag)
        return stringBuilder.ToString();
      success = false;
      return (string) null;
    }

    protected static object ParseNumber(char[] json, ref int index, ref bool success)
    {
      JsonSerializer.EatWhitespace(json, ref index);
      int lastIndexOfNumber = JsonSerializer.GetLastIndexOfNumber(json, index);
      int length = lastIndexOfNumber - index + 1;
      string s = new string(json, index, length);
      index = lastIndexOfNumber + 1;
      float result1;
      long result2;
      return s.Contains(".") ? (float.TryParse(s, NumberStyles.Any, (IFormatProvider) CultureInfo.InvariantCulture, out result1) ? (object) result1 : (object) s) : (long.TryParse(s, NumberStyles.Any, (IFormatProvider) CultureInfo.InvariantCulture, out result2) ? (object) result2 : (object) s);
    }

    protected static int GetLastIndexOfNumber(char[] json, int index)
    {
      int index1 = index;
      while (index1 < json.Length && "0123456789+-.eE".IndexOf(json[index1]) != -1)
        ++index1;
      return index1 - 1;
    }

    protected static void EatWhitespace(char[] json, ref int index)
    {
      while (index < json.Length && " \t\n\r".IndexOf(json[index]) != -1)
        ++index;
    }

    protected static int LookAhead(char[] json, int index)
    {
      int index1 = index;
      return JsonSerializer.NextToken(json, ref index1);
    }

    protected static int NextToken(char[] json, ref int index)
    {
      JsonSerializer.EatWhitespace(json, ref index);
      if (index == json.Length)
        return 0;
      char ch1 = json[index];
      ++index;
      char ch2 = ch1;
      switch (ch2)
      {
        case '"':
          return 7;
        case ',':
          return 6;
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
          return 8;
        case ':':
          return 5;
        default:
          switch (ch2)
          {
            case '[':
              return 3;
            case ']':
              return 4;
            default:
              switch (ch2)
              {
                case '{':
                  return 1;
                case '}':
                  return 2;
                default:
                  --index;
                  int num = json.Length - index;
                  if (num >= 5 && json[index] == 'f' && json[index + 1] == 'a' && json[index + 2] == 'l' && json[index + 3] == 's' && json[index + 4] == 'e')
                  {
                    index += 5;
                    return 10;
                  }
                  if (num >= 4 && json[index] == 't' && json[index + 1] == 'r' && json[index + 2] == 'u' && json[index + 3] == 'e')
                  {
                    index += 4;
                    return 9;
                  }
                  if (num < 4 || json[index] != 'n' || json[index + 1] != 'u' || json[index + 2] != 'l' || json[index + 3] != 'l')
                    return 0;
                  index += 4;
                  return 11;
              }
          }
      }
    }

    protected static bool SerializeValue(object value, StringBuilder builder)
    {
      bool flag1 = true;
      switch (value)
      {
        case string _:
          flag1 = JsonSerializer.SerializeString((string) value, builder);
          break;
        case Hashtable _:
          flag1 = JsonSerializer.SerializeObject((Hashtable) value, builder);
          break;
        case IEnumerable _:
          flag1 = JsonSerializer.SerializeArray((IEnumerable) value, builder);
          break;
        case float _:
          flag1 = JsonSerializer.SerializeNumber(Convert.ToSingle(value), builder);
          break;
        case int _:
        case long _:
        case uint _:
          flag1 = JsonSerializer.SerializeNumber(Convert.ToInt64(value), builder);
          break;
        case double _:
          flag1 = JsonSerializer.SerializeNumber(Convert.ToDouble(value), builder);
          break;
        case bool flag2 when flag2:
          builder.Append("true");
          break;
        case bool flag3 when !flag3:
          builder.Append("false");
          break;
        case null:
          builder.Append("null");
          break;
        case DateTime dateTime:
          builder.Append(dateTime.ToString("o"));
          break;
        default:
          Hashtable anObject = new Hashtable();
          foreach (FieldInfo field in value.GetType().GetFields())
          {
            if (!field.IsNotSerialized)
              anObject[(object) field.Name] = field.GetValue(value);
          }
          foreach (PropertyInfo property in value.GetType().GetProperties())
            anObject[(object) property.Name] = property.GetValue(value, (object[]) null);
          JsonSerializer.SerializeObject(anObject, builder);
          break;
      }
      return flag1;
    }

    protected static bool SerializeObject(Hashtable anObject, StringBuilder builder)
    {
      builder.Append("{");
      IDictionaryEnumerator enumerator = anObject.GetEnumerator();
      bool flag = true;
      while (enumerator.MoveNext())
      {
        string aString = enumerator.Key.ToString();
        object obj = enumerator.Value;
        if (!flag)
          builder.Append(", ");
        JsonSerializer.SerializeString(aString, builder);
        builder.Append(":");
        if (!JsonSerializer.SerializeValue(obj, builder))
          return false;
        flag = false;
      }
      builder.Append("}");
      return true;
    }

    protected static bool SerializeArray(IEnumerable anArray, StringBuilder builder)
    {
      builder.Append("[");
      bool flag = true;
      foreach (object an in anArray)
      {
        if (!flag)
          builder.Append(", ");
        if (!JsonSerializer.SerializeValue(an, builder))
          return false;
        flag = false;
      }
      builder.Append("]");
      return true;
    }

    protected static bool SerializeString(string aString, StringBuilder builder)
    {
      builder.Append("\"");
      foreach (char ch in aString.ToCharArray())
      {
        switch (ch)
        {
          case '\b':
            builder.Append("\\b");
            break;
          case '\t':
            builder.Append("\\t");
            break;
          case '\n':
            builder.Append("\\n");
            break;
          case '\f':
            builder.Append("\\f");
            break;
          case '\r':
            builder.Append("\\r");
            break;
          case '"':
            builder.Append("\\\"");
            break;
          case '\\':
            builder.Append("\\\\");
            break;
          default:
            int int32 = Convert.ToInt32(ch);
            if (int32 >= 32 && int32 <= 126)
            {
              builder.Append(ch);
              break;
            }
            builder.Append("\\u" + Convert.ToString(int32, 16).PadLeft(4, '0'));
            break;
        }
      }
      builder.Append("\"");
      return true;
    }

    protected static bool SerializeNumber(int number, StringBuilder builder)
    {
      builder.Append(Convert.ToString(number, (IFormatProvider) CultureInfo.InvariantCulture));
      return true;
    }

    protected static bool SerializeNumber(float number, StringBuilder builder)
    {
      builder.Append(Convert.ToString(number, (IFormatProvider) CultureInfo.InvariantCulture));
      return true;
    }

    protected static bool SerializeNumber(long number, StringBuilder builder)
    {
      builder.Append(Convert.ToString(number, (IFormatProvider) CultureInfo.InvariantCulture));
      return true;
    }

    protected static bool SerializeNumber(double number, StringBuilder builder)
    {
      builder.Append(Convert.ToString(number, (IFormatProvider) CultureInfo.InvariantCulture));
      return true;
    }

    protected static bool IsNumeric(object o)
    {
      return o != null && float.TryParse(o.ToString(), out float _);
    }
  }
}
