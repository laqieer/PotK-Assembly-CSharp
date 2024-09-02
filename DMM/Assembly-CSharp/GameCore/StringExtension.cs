// Decompiled with JetBrains decompiler
// Type: GameCore.StringExtension
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UniLinq;

namespace GameCore
{
  public static class StringExtension
  {
    private static readonly string hankaku = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ!#$%&'()=^|@`{;+:*},<.>/?_";
    private static readonly string zenkaku = "０１２３４５６７８９ａｂｃｄｅｆｇｈｉｊｋｌｍｎｏｐｑｒｓｔｕｖｗｘｙｚＡＢＣＤＥＦＧＨＩＪＫＬＭＮＯＰＱＲＳＴＵＶＷＸＹＺ！＃＄％＆’（）＝＾｜＠｀｛；＋：＊｝，＜．＞／？＿";
    private static readonly Dictionary<char, char> hankakuToZenkakuDic = StringExtension.hankaku.Select((IEnumerable<char>) StringExtension.zenkaku, (h, z) => new
    {
      h = h,
      z = z
    }).ToDictionary(x => x.h, x => x.z);
    private static readonly Dictionary<char, char> zenkakuToHankakuDic = StringExtension.zenkaku.Select((IEnumerable<char>) StringExtension.hankaku, (z, h) => new
    {
      z = z,
      h = h
    }).ToDictionary(x => x.z, x => x.h);

    private static string ToHankaku(this char c) => (StringExtension.zenkakuToHankakuDic.ContainsKey(c) ? StringExtension.zenkakuToHankakuDic[c] : c).ToString();

    private static string ToZenkaku(this char c) => (StringExtension.hankakuToZenkakuDic.ContainsKey(c) ? StringExtension.hankakuToZenkakuDic[c] : c).ToString();

    public static string ToConverter(this string text) => text == null ? (string) null : text.ToHankaku();

    public static string ToZenkaku(this string text)
    {
      if (text == null)
        return (string) null;
      Regex regex1 = new Regex("\\[[a-z0-9]{6}\\]");
      Regex regex2 = new Regex("\\[\\-\\]");
      string input = text;
      MatchCollection matchCollection1 = regex1.Matches(input);
      MatchCollection matchCollection2 = regex2.Matches(text);
      string str = "";
      int i1 = 0;
      int i2 = 0;
      for (int index = 0; index < text.Length; ++index)
      {
        if (matchCollection1.Count > i1 && index == matchCollection1[i1].Index + matchCollection1[i1].Length)
          ++i1;
        if (matchCollection2.Count > i2 && index == matchCollection2[i2].Index + matchCollection2[i2].Length)
          ++i2;
        str = matchCollection1.Count > i1 && matchCollection1[i1].Index <= index && index < matchCollection1[i1].Index + matchCollection1[i1].Length || matchCollection2.Count > i2 && matchCollection2[i2].Index <= index && index < matchCollection2[i2].Index + matchCollection2[i2].Length ? str + text[index].ToHankaku() : str + text[index].ToZenkaku();
      }
      return str;
    }

    public static string ToHankaku(this string text) => text == null ? (string) null : text.Select<char, char>((Func<char, char>) (c => !StringExtension.zenkakuToHankakuDic.ContainsKey(c) ? c : StringExtension.zenkakuToHankakuDic[c])).ToStringForChars();

    public static string F(this string format, params object[] args) => string.Format(format, args);

    public static bool isEmptyOrWhitespace(this string text) => string.IsNullOrEmpty(text) || Regex.Match(text, "^[\\s|\\r|\\n]*$").Success;
  }
}
