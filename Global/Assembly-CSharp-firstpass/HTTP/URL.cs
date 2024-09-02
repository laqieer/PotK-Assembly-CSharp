// Decompiled with JetBrains decompiler
// Type: HTTP.URL
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E910E095-517B-41AE-AAF8-B85E770EBAF1
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp-firstpass.dll

using System.Collections.Generic;
using System.Text;
using UnityEngine;

#nullable disable
namespace HTTP
{
  public class URL
  {
    private static string safeChars = "-_.~abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

    public static string Encode(string value)
    {
      StringBuilder stringBuilder = new StringBuilder();
      foreach (char ch in value)
      {
        if (URL.safeChars.IndexOf(ch) != -1)
          stringBuilder.Append(ch);
        else
          stringBuilder.Append('%'.ToString() + string.Format("{0:X2}", (object) (int) ch));
      }
      return stringBuilder.ToString();
    }

    public static string Decode(string s) => WWW.UnEscapeURL(s);

    public static Dictionary<string, string> KeyValue(string queryString)
    {
      Dictionary<string, string> dictionary = new Dictionary<string, string>();
      if (queryString.Length == 0)
        return dictionary;
      string str1 = queryString;
      char[] chArray1 = new char[1]{ '&' };
      foreach (string str2 in str1.Split(chArray1))
      {
        char[] chArray2 = new char[1]{ '=' };
        string[] strArray = str2.Split(chArray2);
        if (strArray.Length >= 2)
          dictionary[URL.Decode(strArray[0])] = URL.Decode(strArray[1]);
      }
      return dictionary;
    }
  }
}
