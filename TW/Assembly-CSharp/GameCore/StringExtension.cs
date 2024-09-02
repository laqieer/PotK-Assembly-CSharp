// Decompiled with JetBrains decompiler
// Type: GameCore.StringExtension
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UniLinq;

#nullable disable
namespace GameCore
{
  public static class StringExtension
  {
    private static readonly string hankaku = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ!#$%&'()=^|@`{;+:*},<.>/?_";
    private static readonly string zenkaku = "０１２３４５６７８９ａｂｃｄｅｆｇｈｉｊｋｌｍｎｏｐｑｒｓｔｕｖｗｘｙｚＡＢＣＤＥＦＧＨＩＪＫＬＭＮＯＰＱＲＳＴＵＶＷＸＹＺ！＃＄％＆’（）＝＾｜＠｀｛；＋：＊｝，＜．＞／？＿";
    private static readonly Dictionary<char, char> hankakuToZenkakuDic = StringExtension.hankaku.Select<char, char, \u003C\u003E__AnonType1<char, char>>((IEnumerable<char>) StringExtension.zenkaku, (Func<char, char, \u003C\u003E__AnonType1<char, char>>) ((h, z) => new \u003C\u003E__AnonType1<char, char>(h, z))).ToDictionary<\u003C\u003E__AnonType1<char, char>, char, char>((Func<\u003C\u003E__AnonType1<char, char>, char>) (x => x.h), (Func<\u003C\u003E__AnonType1<char, char>, char>) (x => x.z));
    private static readonly Dictionary<char, char> zenkakuToHankakuDic = StringExtension.zenkaku.Select<char, char, \u003C\u003E__AnonType2<char, char>>((IEnumerable<char>) StringExtension.hankaku, (Func<char, char, \u003C\u003E__AnonType2<char, char>>) ((z, h) => new \u003C\u003E__AnonType2<char, char>(z, h))).ToDictionary<\u003C\u003E__AnonType2<char, char>, char, char>((Func<\u003C\u003E__AnonType2<char, char>, char>) (x => x.z), (Func<\u003C\u003E__AnonType2<char, char>, char>) (x => x.h));

    private static string ToHankaku(this char c)
    {
      return (!StringExtension.zenkakuToHankakuDic.ContainsKey(c) ? c : StringExtension.zenkakuToHankakuDic[c]).ToString();
    }

    private static string ToZenkaku(this char c)
    {
      return (!StringExtension.hankakuToZenkakuDic.ContainsKey(c) ? c : StringExtension.hankakuToZenkakuDic[c]).ToString();
    }

    public static string ToConverter(this string text)
    {
      return text == null ? (string) null : text.ToHankaku();
    }

    public static string ToZenkaku(this string text)
    {
      if (text == null)
        return (string) null;
      Regex regex1 = new Regex("\\[[a-z0-9]{6}\\]");
      Regex regex2 = new Regex("\\[\\-\\]");
      MatchCollection matchCollection1 = regex1.Matches(text);
      MatchCollection matchCollection2 = regex2.Matches(text);
      string zenkaku = string.Empty;
      int i1 = 0;
      int i2 = 0;
      for (int index = 0; index < text.Length; ++index)
      {
        if (matchCollection1.Count > i1 && index == matchCollection1[i1].Index + matchCollection1[i1].Length)
          ++i1;
        if (matchCollection2.Count > i2 && index == matchCollection2[i2].Index + matchCollection2[i2].Length)
          ++i2;
        zenkaku = matchCollection1.Count > i1 && matchCollection1[i1].Index <= index && index < matchCollection1[i1].Index + matchCollection1[i1].Length || matchCollection2.Count > i2 && matchCollection2[i2].Index <= index && index < matchCollection2[i2].Index + matchCollection2[i2].Length ? zenkaku + text[index].ToHankaku() : zenkaku + text[index].ToZenkaku();
      }
      return zenkaku;
    }

    public static string ToHankaku(this string text)
    {
      return text == null ? (string) null : text.Select<char, char>((Func<char, char>) (c => StringExtension.zenkakuToHankakuDic.ContainsKey(c) ? StringExtension.zenkakuToHankakuDic[c] : c)).ToStringForChars();
    }

    public static string F(this string format, params object[] args) => string.Format(format, args);

    public static bool isEmptyOrWhitespace(this string text)
    {
      return string.IsNullOrEmpty(text) || Regex.Match(text, "^[\\s|\\r|\\n]*$").Success;
    }
  }
}
