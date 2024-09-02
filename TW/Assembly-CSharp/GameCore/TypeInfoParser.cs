// Decompiled with JetBrains decompiler
// Type: GameCore.TypeInfoParser
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UniLinq;

#nullable disable
namespace GameCore
{
  internal class TypeInfoParser
  {
    private int name_space = -1;
    private List<int> _nested;
    private int name = -1;
    private List<int> _modifiers;
    private List<TypeInfoParser> _type_arguments;
    private AssemblyInfoParser assembly;

    private List<int> nested
    {
      get
      {
        if (this._nested == null)
          this._nested = new List<int>();
        return this._nested;
      }
    }

    private List<int> modifiers
    {
      get
      {
        if (this._modifiers == null)
          this._modifiers = new List<int>();
        return this._modifiers;
      }
    }

    private List<TypeInfoParser> type_arguments
    {
      get
      {
        if (this._type_arguments == null)
          this._type_arguments = new List<TypeInfoParser>();
        return this._type_arguments;
      }
    }

    public static TypeInfo Parse(string type)
    {
      int p = 0;
      char[] type1 = new char[type.Length + 1];
      for (int index = 0; index < type.Length; ++index)
        type1[index] = type[index];
      type1[type.Length] = char.MinValue;
      TypeInfoParser info = TypeInfoParser.Parse(type1, ref p, false);
      return info == null ? (TypeInfo) null : TypeInfoParser.ToTypeInfo(info, type1);
    }

    private static string ToStr(char[] type, int s)
    {
      if (s == -1)
        return (string) null;
      int index = s;
      while (type[index] != char.MinValue)
        ++index;
      return new string(type, s, index - s);
    }

    private static TypeInfo ToTypeInfo(TypeInfoParser info, char[] type)
    {
      TypeInfo typeInfo = new TypeInfo();
      typeInfo.name_space = info.name_space != -1 ? TypeInfoParser.ToStr(type, info.name_space) : string.Empty;
      typeInfo.nested = info._nested != null ? info.nested.Select<int, string>((Func<int, string>) (x => TypeInfoParser.ToStr(type, x))).ToArray<string>() : new string[0];
      typeInfo.name = TypeInfoParser.ToStr(type, info.name);
      typeInfo.modifiers = info._modifiers != null ? info.modifiers.ToArray() : new int[0];
      typeInfo.type_arguments = info._type_arguments != null ? info._type_arguments.Select<TypeInfoParser, TypeInfo>((Func<TypeInfoParser, TypeInfo>) (x => TypeInfoParser.ToTypeInfo(x, type))).ToArray<TypeInfo>() : new TypeInfo[0];
      typeInfo.assembly = info.assembly != null ? AssemblyInfoParser.ToAssemblyInfo(info.assembly, type) : (AssemblyInfo) null;
      TypeInfoCache.Register(typeInfo.AssemblyQualifiedName, typeInfo);
      return typeInfo;
    }

    private static TypeInfoParser Parse(char[] type, ref int p, bool is_recursed)
    {
      int num1 = p;
      bool flag1 = false;
      bool flag2 = false;
      int index1 = -1;
      int num2 = 0;
      while (type[p] == ' ')
      {
        ++num1;
        ++p;
      }
      TypeInfoParser typeInfoParser1 = new TypeInfoParser();
      while (type[p] != char.MinValue)
      {
        char ch = type[p];
        switch (ch)
        {
          case '&':
          case '*':
          case ',':
label_12:
            flag2 = true;
            break;
          case '+':
            type[p] = char.MinValue;
            typeInfoParser1.nested.Add(p + 1);
            if (typeInfoParser1.name == -1)
            {
              if (index1 != -1)
              {
                typeInfoParser1.name_space = num1;
                type[index1] = char.MinValue;
                typeInfoParser1.name = index1 + 1;
                break;
              }
              typeInfoParser1.name_space = type.Length - 1;
              typeInfoParser1.name = num1;
              break;
            }
            break;
          case '.':
            index1 = p;
            break;
          default:
            switch (ch)
            {
              case '[':
              case ']':
                goto label_12;
              case '\\':
                ++p;
                break;
              case '`':
                type[p] = char.MinValue;
                break;
            }
            break;
        }
        if (!flag2)
          ++p;
        else
          break;
      }
      if (typeInfoParser1.name == -1)
      {
        if (index1 != -1)
        {
          typeInfoParser1.name_space = num1;
          type[index1] = char.MinValue;
          typeInfoParser1.name = index1 + 1;
        }
        else
        {
          typeInfoParser1.name_space = type.Length - 1;
          typeInfoParser1.name = num1;
        }
      }
      while (type[p] != char.MinValue)
      {
        char ch = type[p];
        switch (ch)
        {
          case '*':
            typeInfoParser1.modifiers.Add(-1);
            char[] chArray1 = type;
            int num3;
            p = (num3 = p) + 1;
            int index2 = num3;
            chArray1[index2] = char.MinValue;
            break;
          case ',':
            if (!is_recursed)
            {
              char[] chArray2 = type;
              int num4;
              p = (num4 = p) + 1;
              int index3 = num4;
              chArray2[index3] = char.MinValue;
              while (type[p] != char.MinValue && util.isspace(type[p]))
                ++p;
              if (type[p] == char.MinValue)
                return (TypeInfoParser) null;
              typeInfoParser1.assembly = AssemblyInfoParser.Parse(type, p);
              if (typeInfoParser1.assembly == null)
                return (TypeInfoParser) null;
              break;
            }
            goto label_84;
          default:
            switch (ch)
            {
              case '[':
                char[] chArray3 = type;
                int num5;
                p = (num5 = p) + 1;
                int index4 = num5;
                chArray3[index4] = char.MinValue;
                if (type[p] == char.MinValue)
                  return (TypeInfoParser) null;
                if (type[p] == ',' || type[p] == '*' || type[p] == ']')
                {
                  num2 = 1;
                  while (type[p] != char.MinValue && type[p] != ']')
                  {
                    if (type[p] == ',')
                    {
                      ++num2;
                    }
                    else
                    {
                      if (type[p] != '*')
                        return (TypeInfoParser) null;
                      typeInfoParser1.modifiers.Add(-2);
                    }
                    ++p;
                  }
                  char[] chArray4 = type;
                  int num6;
                  p = (num6 = p) + 1;
                  int index5 = num6;
                  if (chArray4[index5] != ']')
                    return (TypeInfoParser) null;
                  typeInfoParser1.modifiers.Add(num2);
                  break;
                }
                if (num2 != 0)
                  return (TypeInfoParser) null;
                while (type[p] != char.MinValue)
                {
                  bool flag3 = false;
                  if (type[p] == '[')
                  {
                    ++p;
                    flag3 = true;
                  }
                  TypeInfoParser typeInfoParser2 = TypeInfoParser.Parse(type, ref p, true);
                  if (typeInfoParser2 == null)
                    return (TypeInfoParser) null;
                  typeInfoParser1.type_arguments.Add(typeInfoParser2);
                  if (flag3 && type[p] != ']')
                  {
                    if (type[p] != ',')
                      return (TypeInfoParser) null;
                    char[] chArray5 = type;
                    int num7;
                    p = (num7 = p) + 1;
                    int index6 = num7;
                    chArray5[index6] = char.MinValue;
                    int p1 = p;
                    while (type[p] != char.MinValue && type[p] != ']')
                      ++p;
                    if (type[p] != ']')
                      return (TypeInfoParser) null;
                    char[] chArray6 = type;
                    int num8;
                    p = (num8 = p) + 1;
                    int index7 = num8;
                    chArray6[index7] = char.MinValue;
                    while (type[p1] != char.MinValue && util.isspace(type[p1]))
                      ++p1;
                    if (type[p1] == char.MinValue)
                      return (TypeInfoParser) null;
                    typeInfoParser2.assembly = AssemblyInfoParser.Parse(type, p1);
                    if (typeInfoParser2.assembly == null)
                      return (TypeInfoParser) null;
                  }
                  else if (flag3 && type[p] == ']')
                  {
                    char[] chArray7 = type;
                    int num9;
                    p = (num9 = p) + 1;
                    int index8 = num9;
                    chArray7[index8] = char.MinValue;
                  }
                  if (type[p] == ']')
                  {
                    char[] chArray8 = type;
                    int num10;
                    p = (num10 = p) + 1;
                    int index9 = num10;
                    chArray8[index9] = char.MinValue;
                    break;
                  }
                  if (type[p] == char.MinValue)
                    return (TypeInfoParser) null;
                  char[] chArray9 = type;
                  int num11;
                  p = (num11 = p) + 1;
                  int index10 = num11;
                  chArray9[index10] = char.MinValue;
                }
                break;
              case ']':
                if (!is_recursed)
                  return (TypeInfoParser) null;
                goto label_84;
              default:
                if (ch != '&')
                  return (TypeInfoParser) null;
                if (flag1)
                  return (TypeInfoParser) null;
                flag1 = true;
                typeInfoParser1.modifiers.Add(0);
                char[] chArray10 = type;
                int num12;
                p = (num12 = p) + 1;
                int index11 = num12;
                chArray10[index11] = char.MinValue;
                break;
            }
            break;
        }
        if (typeInfoParser1.assembly != null)
          break;
      }
label_84:
      return typeInfoParser1.name == -1 ? (TypeInfoParser) null : typeInfoParser1;
    }
  }
}
