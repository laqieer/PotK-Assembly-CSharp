// Decompiled with JetBrains decompiler
// Type: GameCore.util
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

#nullable disable
namespace GameCore
{
  internal static class util
  {
    private static char tolower(char c) => c >= 'A' && c <= 'Z' ? (char) ((uint) c + 32U) : c;

    public static int strncasecmp(char[] s1, int a, string s2, int b, int n)
    {
      for (int index = 0; index < n; ++index)
      {
        char ch1 = util.tolower(s1[a++]);
        char ch2 = b != s2.Length ? util.tolower(s2[b++]) : char.MinValue;
        if ((int) ch1 != (int) ch2)
          return (int) ch1 - (int) ch2;
      }
      return 0;
    }

    public static int strncmp(char[] s1, int a, string s2, int b, int n)
    {
      for (int index = 0; index < n; ++index)
      {
        char ch1 = s1[a++];
        char ch2 = b != s2.Length ? s2[b++] : char.MinValue;
        if ((int) ch1 != (int) ch2)
          return (int) ch1 - (int) ch2;
      }
      return 0;
    }

    public static bool isspace(char c) => c != char.MinValue && c <= ' ';

    public static bool isalnum(char c)
    {
      if ('A' <= c && c <= 'Z' || 'a' <= c && c <= 'z')
        return true;
      return '0' <= c && c <= '9';
    }
  }
}
