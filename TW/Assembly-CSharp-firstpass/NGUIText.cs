// Decompiled with JetBrains decompiler
// Type: NGUIText
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ECB926DA-6BA5-4E91-81B4-E3750A024FEA
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp-firstpass.dll

using System.Collections.Generic;
using System.Text;
using UnityEngine;

#nullable disable
public static class NGUIText
{
  public static UIFont bitmapFont;
  public static Font dynamicFont;
  public static NGUIText.GlyphInfo glyph;
  public static int fontSize;
  public static float fontScale;
  public static float pixelDensity;
  public static FontStyle fontStyle;
  public static NGUIText.Alignment alignment;
  public static Color tint;
  public static int rectWidth;
  public static int rectHeight;
  public static int maxLines;
  public static bool gradient;
  public static Color gradientBottom;
  public static Color gradientTop;
  public static bool encoding;
  public static float spacingX;
  public static float spacingY;
  public static bool premultiply;
  public static NGUIText.SymbolStyle symbolStyle;
  public static int finalSize;
  public static float finalSpacingX;
  public static float finalLineHeight;
  public static float baseline;
  public static bool useSymbols;
  private static Color mInvisible;
  private static BetterList<Color> mColors;
  private static CharacterInfo mTempChar;
  private static BetterList<float> mSizes;
  private static Color32 s_c0;
  private static Color32 s_c1;
  private static float[] mBoldOffset;
  public static string firstInterdictionTextJP = ",)]｝、〕〉》」』】〙〗〟’”｠»ゝゞーァィゥェォッャュョヮヵヶぁぃぅぇぉっゃゅょゎゕゖㇰㇱㇲㇳㇴㇵㇶㇷㇸㇹㇷ゚ㇺㇻㇼㇽㇾㇿ々〻‐゠–〜～・:;/。.｡､";
  public static string lastInterdictionTextJP = "([｛〔〈《「『【〝‘“";
  public static string firstInterdictionTextEN = ",)]｝、〕〉》」』】〙〗〟’”｠»ゝゞーァィゥェォッャュョヮヵヶぁぃぅぇぉっゃゅょゎゕゖㇰㇱㇲㇳㇴㇵㇶㇷㇸㇹㇷ゚ㇺㇻㇼㇽㇾㇿ々〻‐゠–〜～・:;/。.｡､";
  public static string lastInterdictionTextEN = "([｛〔〈《「『【〝‘“";

  static NGUIText()
  {
    NGUIText.glyph = new NGUIText.GlyphInfo();
    NGUIText.fontSize = 16;
    NGUIText.fontScale = 1f;
    NGUIText.pixelDensity = 1f;
    NGUIText.fontStyle = (FontStyle) 0;
    NGUIText.alignment = NGUIText.Alignment.Left;
    NGUIText.tint = Color.white;
    NGUIText.rectWidth = 1000000;
    NGUIText.rectHeight = 1000000;
    NGUIText.maxLines = 0;
    NGUIText.gradient = false;
    NGUIText.gradientBottom = Color.white;
    NGUIText.gradientTop = Color.white;
    NGUIText.encoding = false;
    NGUIText.spacingX = 0.0f;
    NGUIText.spacingY = 0.0f;
    NGUIText.premultiply = false;
    NGUIText.finalSize = 0;
    NGUIText.finalSpacingX = 0.0f;
    NGUIText.finalLineHeight = 0.0f;
    NGUIText.baseline = 0.0f;
    NGUIText.useSymbols = false;
    NGUIText.mInvisible = new Color(0.0f, 0.0f, 0.0f, 0.0f);
    NGUIText.mColors = new BetterList<Color>();
    NGUIText.mSizes = new BetterList<float>();
    NGUIText.mBoldOffset = new float[8]
    {
      -0.5f,
      0.0f,
      0.5f,
      0.0f,
      0.0f,
      -0.5f,
      0.0f,
      0.5f
    };
  }

  public static void Update() => NGUIText.Update(true);

  public static void Update(bool request)
  {
    NGUIText.finalSize = Mathf.RoundToInt((float) NGUIText.fontSize / NGUIText.pixelDensity);
    NGUIText.finalSpacingX = NGUIText.spacingX * NGUIText.fontScale;
    NGUIText.finalLineHeight = ((float) NGUIText.fontSize + NGUIText.spacingY) * NGUIText.fontScale;
    NGUIText.useSymbols = Object.op_Inequality((Object) NGUIText.bitmapFont, (Object) null) && NGUIText.bitmapFont.hasSymbols && NGUIText.encoding && NGUIText.symbolStyle != NGUIText.SymbolStyle.None;
    if (!Object.op_Inequality((Object) NGUIText.dynamicFont, (Object) null) || !request)
      return;
    NGUIText.dynamicFont.RequestCharactersInTexture(")_-", NGUIText.finalSize, NGUIText.fontStyle);
    if (!NGUIText.dynamicFont.GetCharacterInfo(')', ref NGUIText.mTempChar, NGUIText.finalSize, NGUIText.fontStyle))
    {
      NGUIText.dynamicFont.RequestCharactersInTexture("A", NGUIText.finalSize, NGUIText.fontStyle);
      if (!NGUIText.dynamicFont.GetCharacterInfo('A', ref NGUIText.mTempChar, NGUIText.finalSize, NGUIText.fontStyle))
      {
        NGUIText.baseline = 0.0f;
        return;
      }
    }
    float yMax = ((Rect) ref NGUIText.mTempChar.vert).yMax;
    float yMin = ((Rect) ref NGUIText.mTempChar.vert).yMin;
    NGUIText.baseline = Mathf.Round(yMax + (float) (((double) NGUIText.finalSize - (double) yMax + (double) yMin) * 0.5));
  }

  public static void Prepare(string text)
  {
    if (!Object.op_Inequality((Object) NGUIText.dynamicFont, (Object) null))
      return;
    NGUIText.dynamicFont.RequestCharactersInTexture(text, NGUIText.finalSize, NGUIText.fontStyle);
  }

  public static BMSymbol GetSymbol(string text, int index, int textLength)
  {
    return Object.op_Inequality((Object) NGUIText.bitmapFont, (Object) null) ? NGUIText.bitmapFont.MatchSymbol(text, index, textLength) : (BMSymbol) null;
  }

  public static float GetGlyphWidth(int ch, int prev)
  {
    if (Object.op_Inequality((Object) NGUIText.bitmapFont, (Object) null))
    {
      BMGlyph glyph = NGUIText.bitmapFont.bmFont.GetGlyph(ch);
      if (glyph != null)
        return NGUIText.fontScale * (prev == 0 ? (float) glyph.advance : (float) (glyph.advance + glyph.GetKerning(prev)));
    }
    else if (Object.op_Inequality((Object) NGUIText.dynamicFont, (Object) null) && NGUIText.dynamicFont.GetCharacterInfo((char) ch, ref NGUIText.mTempChar, NGUIText.finalSize, NGUIText.fontStyle))
      return Mathf.Round(NGUIText.mTempChar.width * NGUIText.fontScale * NGUIText.pixelDensity);
    return 0.0f;
  }

  public static NGUIText.GlyphInfo GetGlyph(int ch, int prev)
  {
    if (Object.op_Inequality((Object) NGUIText.bitmapFont, (Object) null))
    {
      BMGlyph glyph1 = NGUIText.bitmapFont.bmFont.GetGlyph(ch);
      if (glyph1 != null)
      {
        int kerning = prev == 0 ? 0 : glyph1.GetKerning(prev);
        NGUIText.glyph.v0.x = prev == 0 ? (float) glyph1.offsetX : (float) (glyph1.offsetX + kerning);
        NGUIText.glyph.v1.y = (float) -glyph1.offsetY;
        NGUIText.glyph.v1.x = NGUIText.glyph.v0.x + (float) glyph1.width;
        NGUIText.glyph.v0.y = NGUIText.glyph.v1.y - (float) glyph1.height;
        NGUIText.glyph.u0.x = (float) glyph1.x;
        NGUIText.glyph.u0.y = (float) (glyph1.y + glyph1.height);
        NGUIText.glyph.u1.x = (float) (glyph1.x + glyph1.width);
        NGUIText.glyph.u1.y = (float) glyph1.y;
        NGUIText.glyph.advance = (float) (glyph1.advance + kerning);
        NGUIText.glyph.channel = glyph1.channel;
        NGUIText.glyph.rotatedUVs = false;
        if ((double) NGUIText.fontScale != 1.0)
        {
          NGUIText.GlyphInfo glyph2 = NGUIText.glyph;
          glyph2.v0 = Vector2.op_Multiply(glyph2.v0, NGUIText.fontScale);
          NGUIText.GlyphInfo glyph3 = NGUIText.glyph;
          glyph3.v1 = Vector2.op_Multiply(glyph3.v1, NGUIText.fontScale);
          NGUIText.glyph.advance *= NGUIText.fontScale;
        }
        return NGUIText.glyph;
      }
    }
    else if (Object.op_Inequality((Object) NGUIText.dynamicFont, (Object) null) && NGUIText.dynamicFont.GetCharacterInfo((char) ch, ref NGUIText.mTempChar, NGUIText.finalSize, NGUIText.fontStyle))
    {
      NGUIText.glyph.v0.x = ((Rect) ref NGUIText.mTempChar.vert).xMin;
      NGUIText.glyph.v1.x = NGUIText.glyph.v0.x + ((Rect) ref NGUIText.mTempChar.vert).width;
      NGUIText.glyph.v0.y = ((Rect) ref NGUIText.mTempChar.vert).yMax - NGUIText.baseline;
      NGUIText.glyph.v1.y = NGUIText.glyph.v0.y - ((Rect) ref NGUIText.mTempChar.vert).height;
      NGUIText.glyph.u0.x = ((Rect) ref NGUIText.mTempChar.uv).xMin;
      NGUIText.glyph.u0.y = ((Rect) ref NGUIText.mTempChar.uv).yMin;
      NGUIText.glyph.u1.x = ((Rect) ref NGUIText.mTempChar.uv).xMax;
      NGUIText.glyph.u1.y = ((Rect) ref NGUIText.mTempChar.uv).yMax;
      NGUIText.glyph.advance = NGUIText.mTempChar.width;
      NGUIText.glyph.channel = 0;
      NGUIText.glyph.rotatedUVs = NGUIText.mTempChar.flipped;
      float num = NGUIText.fontScale * NGUIText.pixelDensity;
      if ((double) num != 1.0)
      {
        NGUIText.GlyphInfo glyph4 = NGUIText.glyph;
        glyph4.v0 = Vector2.op_Multiply(glyph4.v0, num);
        NGUIText.GlyphInfo glyph5 = NGUIText.glyph;
        glyph5.v1 = Vector2.op_Multiply(glyph5.v1, num);
        NGUIText.glyph.advance *= num;
      }
      NGUIText.glyph.advance = Mathf.Round(NGUIText.glyph.advance);
      return NGUIText.glyph;
    }
    return (NGUIText.GlyphInfo) null;
  }

  public static Color ParseColor(string text, int offset)
  {
    int num1 = NGUIMath.HexToDecimal(text[offset]) << 4 | NGUIMath.HexToDecimal(text[offset + 1]);
    int num2 = NGUIMath.HexToDecimal(text[offset + 2]) << 4 | NGUIMath.HexToDecimal(text[offset + 3]);
    int num3 = NGUIMath.HexToDecimal(text[offset + 4]) << 4 | NGUIMath.HexToDecimal(text[offset + 5]);
    float num4 = 0.003921569f;
    return new Color(num4 * (float) num1, num4 * (float) num2, num4 * (float) num3);
  }

  public static string EncodeColor(Color c)
  {
    return NGUIMath.DecimalToHex(16777215 & NGUIMath.ColorToInt(c) >> 8);
  }

  public static bool ParseSymbol(string text, ref int index)
  {
    int sub = 1;
    bool bold = false;
    bool italic = false;
    bool underline = false;
    bool strike = false;
    return NGUIText.ParseSymbol(text, ref index, (BetterList<Color>) null, false, ref sub, ref bold, ref italic, ref underline, ref strike);
  }

  public static bool ParseSymbol(
    string text,
    ref int index,
    BetterList<Color> colors,
    bool premultiply,
    ref int sub,
    ref bool bold,
    ref bool italic,
    ref bool underline,
    ref bool strike)
  {
    int length = text.Length;
    if (index + 3 > length || text[index] != '[')
      return false;
    int num1;
    if (text[index + 2] == ']')
    {
      if (text[index + 1] == '-')
      {
        if (colors != null && colors.size > 1)
          colors.RemoveAt(colors.size - 1);
        index += 3;
        return true;
      }
      string key = text.Substring(index, 3);
      if (key != null)
      {
        // ISSUE: reference to a compiler-generated field
        if (NGUIText.\u003C\u003Ef__switch\u0024mapD == null)
        {
          // ISSUE: reference to a compiler-generated field
          NGUIText.\u003C\u003Ef__switch\u0024mapD = new Dictionary<string, int>(4)
          {
            {
              "[b]",
              0
            },
            {
              "[i]",
              1
            },
            {
              "[u]",
              2
            },
            {
              "[s]",
              3
            }
          };
        }
        // ISSUE: reference to a compiler-generated field
        if (NGUIText.\u003C\u003Ef__switch\u0024mapD.TryGetValue(key, out num1))
        {
          switch (num1)
          {
            case 0:
              bold = true;
              index += 3;
              return true;
            case 1:
              italic = true;
              index += 3;
              return true;
            case 2:
              underline = true;
              index += 3;
              return true;
            case 3:
              strike = true;
              index += 3;
              return true;
          }
        }
      }
    }
    if (index + 4 > length)
      return false;
    if (text[index + 3] == ']')
    {
      string key = text.Substring(index, 4);
      if (key != null)
      {
        // ISSUE: reference to a compiler-generated field
        if (NGUIText.\u003C\u003Ef__switch\u0024mapE == null)
        {
          // ISSUE: reference to a compiler-generated field
          NGUIText.\u003C\u003Ef__switch\u0024mapE = new Dictionary<string, int>(4)
          {
            {
              "[/b]",
              0
            },
            {
              "[/i]",
              1
            },
            {
              "[/u]",
              2
            },
            {
              "[/s]",
              3
            }
          };
        }
        // ISSUE: reference to a compiler-generated field
        if (NGUIText.\u003C\u003Ef__switch\u0024mapE.TryGetValue(key, out num1))
        {
          switch (num1)
          {
            case 0:
              bold = false;
              index += 4;
              return true;
            case 1:
              italic = false;
              index += 4;
              return true;
            case 2:
              underline = false;
              index += 4;
              return true;
            case 3:
              strike = false;
              index += 4;
              return true;
          }
        }
      }
    }
    if (index + 5 > length)
      return false;
    if (text[index + 4] == ']')
    {
      string key = text.Substring(index, 5);
      if (key != null)
      {
        // ISSUE: reference to a compiler-generated field
        if (NGUIText.\u003C\u003Ef__switch\u0024mapF == null)
        {
          // ISSUE: reference to a compiler-generated field
          NGUIText.\u003C\u003Ef__switch\u0024mapF = new Dictionary<string, int>(2)
          {
            {
              "[sub]",
              0
            },
            {
              "[sup]",
              1
            }
          };
        }
        // ISSUE: reference to a compiler-generated field
        if (NGUIText.\u003C\u003Ef__switch\u0024mapF.TryGetValue(key, out num1))
        {
          if (num1 != 0)
          {
            if (num1 == 1)
            {
              sub = 2;
              index += 5;
              return true;
            }
          }
          else
          {
            sub = 1;
            index += 5;
            return true;
          }
        }
      }
    }
    if (index + 6 > length)
      return false;
    if (text[index + 5] == ']')
    {
      string key = text.Substring(index, 6);
      if (key != null)
      {
        // ISSUE: reference to a compiler-generated field
        if (NGUIText.\u003C\u003Ef__switch\u0024map10 == null)
        {
          // ISSUE: reference to a compiler-generated field
          NGUIText.\u003C\u003Ef__switch\u0024map10 = new Dictionary<string, int>(3)
          {
            {
              "[/sub]",
              0
            },
            {
              "[/sup]",
              1
            },
            {
              "[/url]",
              2
            }
          };
        }
        // ISSUE: reference to a compiler-generated field
        if (NGUIText.\u003C\u003Ef__switch\u0024map10.TryGetValue(key, out num1))
        {
          switch (num1)
          {
            case 0:
              sub = 0;
              index += 6;
              return true;
            case 1:
              sub = 0;
              index += 6;
              return true;
            case 2:
              index += 6;
              return true;
          }
        }
      }
    }
    if (text[index + 1] == 'u' && text[index + 2] == 'r' && text[index + 3] == 'l' && text[index + 4] == '=')
    {
      int num2 = text.IndexOf(']', index + 4);
      if (num2 != -1)
      {
        index = num2 + 1;
        return true;
      }
    }
    if (index + 8 > length || text[index + 7] != ']')
      return false;
    Color c = NGUIText.ParseColor(text, index + 1);
    if (NGUIText.EncodeColor(c) != text.Substring(index + 1, 6).ToUpper())
      return false;
    if (colors != null)
    {
      c.a = colors[colors.size - 1].a;
      if (premultiply && (double) c.a != 1.0)
        c = Color.Lerp(NGUIText.mInvisible, c, c.a);
      colors.Add(c);
    }
    index += 8;
    return true;
  }

  public static string StripSymbols(string text)
  {
    if (text != null)
    {
      int num = 0;
      int length = text.Length;
      while (num < length)
      {
        if (text[num] == '[')
        {
          int sub = 0;
          bool bold = false;
          bool italic = false;
          bool underline = false;
          bool strike = false;
          int index = num;
          if (NGUIText.ParseSymbol(text, ref index, (BetterList<Color>) null, false, ref sub, ref bold, ref italic, ref underline, ref strike))
          {
            text = text.Remove(num, index - num);
            length = text.Length;
            continue;
          }
        }
        ++num;
      }
    }
    return text;
  }

  public static void Align(BetterList<Vector3> verts, int indexOffset, float printedWidth)
  {
    switch (NGUIText.alignment)
    {
      case NGUIText.Alignment.Center:
        float num1 = (float) (((double) NGUIText.rectWidth - (double) printedWidth) * 0.5);
        if ((double) num1 < 0.0)
          break;
        int num2 = Mathf.RoundToInt((float) NGUIText.rectWidth - printedWidth);
        int num3 = Mathf.RoundToInt((float) NGUIText.rectWidth);
        bool flag1 = (num2 & 1) == 1;
        bool flag2 = (num3 & 1) == 1;
        if (flag1 && !flag2 || !flag1 && flag2)
          num1 += 0.5f * NGUIText.fontScale;
        for (int index = indexOffset; index < verts.size; ++index)
          verts.buffer[index].x += num1;
        break;
      case NGUIText.Alignment.Right:
        float num4 = (float) NGUIText.rectWidth - printedWidth;
        if ((double) num4 < 0.0)
          break;
        for (int index = indexOffset; index < verts.size; ++index)
          verts.buffer[index].x += num4;
        break;
      case NGUIText.Alignment.Justified:
        if ((double) printedWidth < (double) NGUIText.rectWidth * 0.64999997615814209 || ((double) NGUIText.rectWidth - (double) printedWidth) * 0.5 < 1.0)
          break;
        int num5 = (verts.size - indexOffset) / 4;
        if (num5 < 1)
          break;
        float num6 = 1f / (float) (num5 - 1);
        float num7 = (float) NGUIText.rectWidth / printedWidth;
        int index1 = indexOffset + 4;
        int num8 = 1;
        while (index1 < verts.size)
        {
          float x1 = verts.buffer[index1].x;
          float x2 = verts.buffer[index1 + 2].x;
          float num9 = x2 - x1;
          float num10 = x1 * num7;
          float num11 = num10 + num9;
          float num12 = x2 * num7;
          float num13 = num12 - num9;
          float num14 = (float) num8 * num6;
          float num15 = Mathf.Lerp(num10, num13, num14);
          float num16 = Mathf.Lerp(num11, num12, num14);
          float num17 = Mathf.Round(num15);
          float num18 = Mathf.Round(num16);
          Vector3[] buffer1 = verts.buffer;
          int index2 = index1;
          int num19 = index2 + 1;
          buffer1[index2].x = num17;
          Vector3[] buffer2 = verts.buffer;
          int index3 = num19;
          int num20 = index3 + 1;
          buffer2[index3].x = num17;
          Vector3[] buffer3 = verts.buffer;
          int index4 = num20;
          int num21 = index4 + 1;
          buffer3[index4].x = num18;
          Vector3[] buffer4 = verts.buffer;
          int index5 = num21;
          index1 = index5 + 1;
          buffer4[index5].x = num18;
          ++num8;
        }
        break;
    }
  }

  public static int GetClosestCharacter(BetterList<Vector3> verts, Vector2 pos)
  {
    float num1 = float.MaxValue;
    float num2 = float.MaxValue;
    int closestCharacter = 0;
    for (int i = 0; i < verts.size; ++i)
    {
      float num3 = Mathf.Abs(pos.y - verts[i].y);
      if ((double) num3 <= (double) num2)
      {
        float num4 = Mathf.Abs(pos.x - verts[i].x);
        if ((double) num3 < (double) num2)
        {
          num2 = num3;
          num1 = num4;
          closestCharacter = i;
        }
        else if ((double) num4 < (double) num1)
        {
          num1 = num4;
          closestCharacter = i;
        }
      }
    }
    return closestCharacter;
  }

  public static void EndLine(ref StringBuilder s)
  {
    int index = s.Length - 1;
    if (index > 0 && s[index] == ' ')
      s[index] = '\n';
    else
      s.Append('\n');
  }

  private static void ReplaceSpaceWithNewline(ref StringBuilder s)
  {
    int index = s.Length - 1;
    if (index <= 0 || s[index] != ' ')
      return;
    s[index] = '\n';
  }

  public static Vector2 CalculatePrintedSize(string text)
  {
    Vector2 zero = Vector2.zero;
    if (!string.IsNullOrEmpty(text))
    {
      if (NGUIText.encoding)
        text = NGUIText.StripSymbols(text);
      NGUIText.Prepare(text);
      float num1 = 0.0f;
      float num2 = 0.0f;
      float num3 = 0.0f;
      int length = text.Length;
      int prev = 0;
      for (int index = 0; index < length; ++index)
      {
        int ch = (int) text[index];
        if (ch == 10)
        {
          if ((double) num1 > (double) num3)
            num3 = num1;
          num1 = 0.0f;
          num2 += NGUIText.finalLineHeight;
        }
        else if (ch >= 32)
        {
          BMSymbol symbol = !NGUIText.useSymbols ? (BMSymbol) null : NGUIText.GetSymbol(text, index, length);
          if (symbol == null)
          {
            float glyphWidth = NGUIText.GetGlyphWidth(ch, prev);
            if ((double) glyphWidth != 0.0)
            {
              float num4 = glyphWidth + NGUIText.finalSpacingX;
              if (Mathf.RoundToInt(num1 + num4) > NGUIText.rectWidth)
              {
                if ((double) num1 > (double) num3)
                  num3 = num1 - NGUIText.finalSpacingX;
                num1 = num4;
                num2 += NGUIText.finalLineHeight;
              }
              else
                num1 += num4;
              prev = ch;
            }
          }
          else
          {
            float num5 = NGUIText.finalSpacingX + (float) symbol.advance * NGUIText.fontScale;
            if (Mathf.RoundToInt(num1 + num5) > NGUIText.rectWidth)
            {
              if ((double) num1 > (double) num3)
                num3 = num1 - NGUIText.finalSpacingX;
              num1 = num5;
              num2 += NGUIText.finalLineHeight;
            }
            else
              num1 += num5;
            index += symbol.sequence.Length - 1;
            prev = 0;
          }
        }
      }
      zero.x = (double) num1 <= (double) num3 ? num3 : num1 - NGUIText.finalSpacingX;
      zero.y = num2 + NGUIText.finalLineHeight;
    }
    return zero;
  }

  public static int CalculateOffsetToFit(string text)
  {
    if (string.IsNullOrEmpty(text) || NGUIText.rectWidth < 1)
      return 0;
    NGUIText.Prepare(text);
    int length1 = text.Length;
    int prev = 0;
    int index1 = 0;
    for (int length2 = text.Length; index1 < length2; ++index1)
    {
      BMSymbol symbol = !NGUIText.useSymbols ? (BMSymbol) null : NGUIText.GetSymbol(text, index1, length1);
      if (symbol == null)
      {
        int ch = (int) text[index1];
        float glyphWidth = NGUIText.GetGlyphWidth(ch, prev);
        if ((double) glyphWidth != 0.0)
          NGUIText.mSizes.Add(NGUIText.finalSpacingX + glyphWidth);
        prev = ch;
      }
      else
      {
        NGUIText.mSizes.Add(NGUIText.finalSpacingX + (float) symbol.advance * NGUIText.fontScale);
        int num = 0;
        for (int index2 = symbol.sequence.Length - 1; num < index2; ++num)
          NGUIText.mSizes.Add(0.0f);
        index1 += symbol.sequence.Length - 1;
        prev = 0;
      }
    }
    float rectWidth = (float) NGUIText.rectWidth;
    int size = NGUIText.mSizes.size;
    while (size > 0 && (double) rectWidth > 0.0)
      rectWidth -= NGUIText.mSizes[--size];
    NGUIText.mSizes.Clear();
    if ((double) rectWidth < 0.0)
      ++size;
    return size;
  }

  public static string GetEndOfLineThatFits(string text)
  {
    int length = text.Length;
    int offsetToFit = NGUIText.CalculateOffsetToFit(text);
    return text.Substring(offsetToFit, length - offsetToFit);
  }

  public static bool WrapText(string text, out string finalText)
  {
    return NGUIText.WrapText(text, out finalText, false);
  }

  public static bool WrapText(string text, out string finalText, bool keepCharCount)
  {
    if (NGUIText.rectWidth < 1 || NGUIText.rectHeight < 1 || (double) NGUIText.finalLineHeight < 1.0)
    {
      finalText = string.Empty;
      return false;
    }
    float num1 = NGUIText.maxLines <= 0 ? (float) NGUIText.rectHeight : Mathf.Min((float) NGUIText.rectHeight, NGUIText.finalLineHeight * (float) NGUIText.maxLines);
    int num2 = Mathf.FloorToInt(Mathf.Min(NGUIText.maxLines <= 0 ? 1000000f : (float) NGUIText.maxLines, num1 / NGUIText.finalLineHeight) + 0.01f);
    if (num2 == 0)
    {
      finalText = string.Empty;
      return false;
    }
    if (string.IsNullOrEmpty(text))
      text = " ";
    NGUIText.Prepare(text);
    StringBuilder s = new StringBuilder();
    int length1 = text.Length;
    float num3 = (float) NGUIText.rectWidth;
    int startIndex = 0;
    int index = 0;
    int num4 = 1;
    int prev = 0;
    bool flag1 = true;
    bool flag2 = true;
    bool flag3 = false;
    for (; index < length1; ++index)
    {
      char ch = text[index];
      if (ch > '\u2FFF')
        flag3 = true;
      if (ch == '\n')
      {
        if (num4 != num2)
        {
          num3 = (float) NGUIText.rectWidth;
          if (startIndex < index)
            s.Append(text.Substring(startIndex, index - startIndex + 1));
          else
            s.Append(ch);
          flag1 = true;
          ++num4;
          startIndex = index + 1;
          prev = 0;
        }
        else
          break;
      }
      else if (NGUIText.encoding && NGUIText.ParseSymbol(text, ref index))
      {
        --index;
      }
      else
      {
        BMSymbol symbol = !NGUIText.useSymbols ? (BMSymbol) null : NGUIText.GetSymbol(text, index, length1);
        float num5;
        if (symbol == null)
        {
          float glyphWidth = NGUIText.GetGlyphWidth((int) ch, prev);
          if ((double) glyphWidth != 0.0)
            num5 = NGUIText.finalSpacingX + glyphWidth;
          else
            continue;
        }
        else
          num5 = NGUIText.finalSpacingX + (float) symbol.advance * NGUIText.fontScale;
        num3 -= num5;
        if (ch == ' ' && !flag3)
        {
          if (prev == 32)
          {
            s.Append(' ');
            startIndex = index + 1;
          }
          else if (prev != 32 && startIndex < index)
          {
            int length2 = index - startIndex + 1;
            if (num4 == num2 && (double) num3 <= 0.0 && index < length1 && text[index] <= ' ')
              --length2;
            s.Append(text.Substring(startIndex, length2));
            flag1 = false;
            startIndex = index + 1;
          }
        }
        if (Mathf.RoundToInt(num3) < 0)
        {
          if (flag1 || num4 == num2)
          {
            if (ch != ' ' && !flag3)
            {
              flag2 = false;
              break;
            }
            s.Append(text.Substring(startIndex, Mathf.Max(0, index - startIndex)));
            if (num4++ == num2)
            {
              startIndex = index;
              break;
            }
            if (keepCharCount)
              NGUIText.ReplaceSpaceWithNewline(ref s);
            else
              NGUIText.EndLine(ref s);
            flag1 = true;
            if (ch == ' ')
            {
              startIndex = index + 1;
              num3 = (float) NGUIText.rectWidth;
            }
            else
            {
              startIndex = index;
              num3 = (float) NGUIText.rectWidth - num5;
            }
            prev = 0;
          }
          else
          {
            flag1 = true;
            num3 = (float) NGUIText.rectWidth;
            index = startIndex - 1;
            prev = 0;
            if (num4++ != num2)
            {
              if (keepCharCount)
              {
                NGUIText.ReplaceSpaceWithNewline(ref s);
                continue;
              }
              NGUIText.EndLine(ref s);
              continue;
            }
            break;
          }
        }
        else
          prev = (int) ch;
        if (symbol != null)
        {
          index += symbol.length - 1;
          prev = 0;
        }
      }
    }
    if (startIndex < index)
      s.Append(text.Substring(startIndex, index - startIndex));
    finalText = s.ToString();
    if (!flag2)
      return false;
    return index == length1 || num4 <= Mathf.Min(NGUIText.maxLines, num2);
  }

  public static void Print(
    string text,
    BetterList<Vector3> verts,
    BetterList<Vector2> uvs,
    BetterList<Color32> cols)
  {
    if (string.IsNullOrEmpty(text))
      return;
    int size1 = verts.size;
    NGUIText.Prepare(text);
    NGUIText.mColors.Add(Color.white);
    int prev = 0;
    float num1 = 0.0f;
    float num2 = 0.0f;
    float num3 = 0.0f;
    float finalSize = (float) NGUIText.finalSize;
    Color color1 = Color.op_Multiply(NGUIText.tint, NGUIText.gradientBottom);
    Color color2 = Color.op_Multiply(NGUIText.tint, NGUIText.gradientTop);
    Color32 color32_1 = Color32.op_Implicit(NGUIText.tint);
    int length = text.Length;
    Rect rect = new Rect();
    float num4 = 0.0f;
    float num5 = 0.0f;
    float num6 = finalSize * NGUIText.pixelDensity;
    bool flag = false;
    int sub = 0;
    bool bold = false;
    bool italic = false;
    bool underline = false;
    bool strike = false;
    float num7 = 0.0f;
    if (Object.op_Inequality((Object) NGUIText.bitmapFont, (Object) null))
    {
      rect = NGUIText.bitmapFont.uvRect;
      num4 = ((Rect) ref rect).width / (float) NGUIText.bitmapFont.texWidth;
      num5 = ((Rect) ref rect).height / (float) NGUIText.bitmapFont.texHeight;
    }
    for (int index1 = 0; index1 < length; ++index1)
    {
      int ch = (int) text[index1];
      float num8 = num1;
      if (ch == 10)
      {
        if ((double) num1 > (double) num3)
          num3 = num1;
        if (NGUIText.alignment != NGUIText.Alignment.Left)
        {
          NGUIText.Align(verts, size1, num1 - NGUIText.finalSpacingX);
          size1 = verts.size;
        }
        num1 = 0.0f;
        num2 += NGUIText.finalLineHeight;
        prev = 0;
      }
      else if (ch < 32)
        prev = ch;
      else if (NGUIText.encoding && NGUIText.ParseSymbol(text, ref index1, NGUIText.mColors, NGUIText.premultiply, ref sub, ref bold, ref italic, ref underline, ref strike))
      {
        Color color3 = Color.op_Multiply(NGUIText.tint, NGUIText.mColors[NGUIText.mColors.size - 1]);
        color32_1 = Color32.op_Implicit(color3);
        if (NGUIText.gradient)
        {
          color1 = Color.op_Multiply(NGUIText.gradientBottom, color3);
          color2 = Color.op_Multiply(NGUIText.gradientTop, color3);
        }
        --index1;
      }
      else
      {
        BMSymbol symbol = !NGUIText.useSymbols ? (BMSymbol) null : NGUIText.GetSymbol(text, index1, length);
        if (symbol != null)
        {
          float num9 = num1 + (float) symbol.offsetX * NGUIText.fontScale;
          float num10 = num9 + (float) symbol.width * NGUIText.fontScale;
          float num11 = (float) -((double) num2 + (double) symbol.offsetY * (double) NGUIText.fontScale);
          float num12 = num11 - (float) symbol.height * NGUIText.fontScale;
          if (Mathf.RoundToInt(num1 + (float) symbol.advance * NGUIText.fontScale) > NGUIText.rectWidth)
          {
            if ((double) num1 == 0.0)
              return;
            if (NGUIText.alignment != NGUIText.Alignment.Left && size1 < verts.size)
            {
              NGUIText.Align(verts, size1, num1 - NGUIText.finalSpacingX);
              size1 = verts.size;
            }
            num9 -= num1;
            num10 -= num1;
            num12 -= NGUIText.finalLineHeight;
            num11 -= NGUIText.finalLineHeight;
            num1 = 0.0f;
            num2 += NGUIText.finalLineHeight;
            num7 = 0.0f;
          }
          verts.Add(new Vector3(num9, num12));
          verts.Add(new Vector3(num9, num11));
          verts.Add(new Vector3(num10, num11));
          verts.Add(new Vector3(num10, num12));
          num1 += NGUIText.finalSpacingX + (float) symbol.advance * NGUIText.fontScale;
          index1 += symbol.length - 1;
          prev = 0;
          if (uvs != null)
          {
            Rect uvRect = symbol.uvRect;
            float xMin = ((Rect) ref uvRect).xMin;
            float yMin = ((Rect) ref uvRect).yMin;
            float xMax = ((Rect) ref uvRect).xMax;
            float yMax = ((Rect) ref uvRect).yMax;
            uvs.Add(new Vector2(xMin, yMin));
            uvs.Add(new Vector2(xMin, yMax));
            uvs.Add(new Vector2(xMax, yMax));
            uvs.Add(new Vector2(xMax, yMin));
          }
          if (cols != null)
          {
            if (NGUIText.symbolStyle == NGUIText.SymbolStyle.Colored)
            {
              for (int index2 = 0; index2 < 4; ++index2)
                cols.Add(color32_1);
            }
            else
            {
              Color32 color32_2 = Color32.op_Implicit(Color.white);
              color32_2.a = color32_1.a;
              for (int index3 = 0; index3 < 4; ++index3)
                cols.Add(color32_2);
            }
          }
        }
        else
        {
          NGUIText.GlyphInfo glyph1 = NGUIText.GetGlyph(ch, prev);
          if (glyph1 != null)
          {
            prev = ch;
            if (sub != 0)
            {
              glyph1.v0.x *= 0.75f;
              glyph1.v0.y *= 0.75f;
              glyph1.v1.x *= 0.75f;
              glyph1.v1.y *= 0.75f;
              if (sub == 1)
              {
                glyph1.v0.y -= (float) ((double) NGUIText.fontScale * (double) NGUIText.fontSize * 0.40000000596046448);
                glyph1.v1.y -= (float) ((double) NGUIText.fontScale * (double) NGUIText.fontSize * 0.40000000596046448);
              }
              else
              {
                glyph1.v0.y += (float) ((double) NGUIText.fontScale * (double) NGUIText.fontSize * 0.05000000074505806);
                glyph1.v1.y += (float) ((double) NGUIText.fontScale * (double) NGUIText.fontSize * 0.05000000074505806);
              }
            }
            float y1 = glyph1.v0.y;
            float y2 = glyph1.v1.y;
            float num13 = glyph1.v0.x + num1;
            float num14 = glyph1.v0.y - num2;
            float num15 = glyph1.v1.x + num1;
            float num16 = glyph1.v1.y - num2;
            float advance = glyph1.advance;
            if ((double) NGUIText.finalSpacingX < 0.0)
              advance += NGUIText.finalSpacingX;
            if (Mathf.RoundToInt(num1 + advance) > NGUIText.rectWidth)
            {
              if ((double) num1 == 0.0)
                return;
              if (NGUIText.alignment != NGUIText.Alignment.Left && size1 < verts.size)
              {
                NGUIText.Align(verts, size1, num1 - NGUIText.finalSpacingX);
                size1 = verts.size;
              }
              num13 -= num1;
              num15 -= num1;
              num14 -= NGUIText.finalLineHeight;
              num16 -= NGUIText.finalLineHeight;
              num1 = 0.0f;
              num2 += NGUIText.finalLineHeight;
              num8 = 0.0f;
            }
            if (ch == 32)
            {
              if (underline)
                ch = 95;
              else if (strike)
                ch = 45;
            }
            num1 += sub != 0 ? (float) (((double) NGUIText.finalSpacingX + (double) glyph1.advance) * 0.75) : NGUIText.finalSpacingX + glyph1.advance;
            if (ch != 32)
            {
              if (uvs != null)
              {
                if (Object.op_Inequality((Object) NGUIText.bitmapFont, (Object) null))
                {
                  glyph1.u0.x = ((Rect) ref rect).xMin + num4 * glyph1.u0.x;
                  glyph1.u1.x = ((Rect) ref rect).xMin + num4 * glyph1.u1.x;
                  glyph1.u0.y = ((Rect) ref rect).yMax - num5 * glyph1.u0.y;
                  glyph1.u1.y = ((Rect) ref rect).yMax - num5 * glyph1.u1.y;
                }
                int num17 = 0;
                for (int index4 = !bold ? 1 : 4; num17 < index4; ++num17)
                {
                  if (glyph1.rotatedUVs)
                  {
                    uvs.Add(glyph1.u0);
                    uvs.Add(new Vector2(glyph1.u1.x, glyph1.u0.y));
                    uvs.Add(glyph1.u1);
                    uvs.Add(new Vector2(glyph1.u0.x, glyph1.u1.y));
                  }
                  else
                  {
                    uvs.Add(glyph1.u0);
                    uvs.Add(new Vector2(glyph1.u0.x, glyph1.u1.y));
                    uvs.Add(glyph1.u1);
                    uvs.Add(new Vector2(glyph1.u1.x, glyph1.u0.y));
                  }
                }
              }
              if (cols != null)
              {
                if (glyph1.channel == 0 || glyph1.channel == 15)
                {
                  if (NGUIText.gradient)
                  {
                    float num18 = num6 + y1 / NGUIText.fontScale;
                    float num19 = num6 + y2 / NGUIText.fontScale;
                    float num20 = num18 / num6;
                    float num21 = num19 / num6;
                    NGUIText.s_c0 = Color32.op_Implicit(Color.Lerp(color1, color2, num20));
                    NGUIText.s_c1 = Color32.op_Implicit(Color.Lerp(color1, color2, num21));
                    int num22 = 0;
                    for (int index5 = !bold ? 1 : 4; num22 < index5; ++num22)
                    {
                      cols.Add(NGUIText.s_c0);
                      cols.Add(NGUIText.s_c1);
                      cols.Add(NGUIText.s_c1);
                      cols.Add(NGUIText.s_c0);
                    }
                  }
                  else
                  {
                    int num23 = 0;
                    for (int index6 = !bold ? 4 : 16; num23 < index6; ++num23)
                      cols.Add(color32_1);
                  }
                }
                else
                {
                  Color color4 = Color.op_Multiply(Color32.op_Implicit(color32_1), 0.49f);
                  switch (glyph1.channel)
                  {
                    case 1:
                      color4.b += 0.51f;
                      break;
                    case 2:
                      color4.g += 0.51f;
                      break;
                    case 4:
                      color4.r += 0.51f;
                      break;
                    case 8:
                      color4.a += 0.51f;
                      break;
                  }
                  Color32 color32_3 = Color32.op_Implicit(color4);
                  int num24 = 0;
                  for (int index7 = !bold ? 4 : 16; num24 < index7; ++num24)
                    cols.Add(color32_3);
                }
              }
              if (!bold)
              {
                if (!italic)
                {
                  verts.Add(new Vector3(num13, num14));
                  verts.Add(new Vector3(num13, num16));
                  verts.Add(new Vector3(num15, num16));
                  verts.Add(new Vector3(num15, num14));
                }
                else
                {
                  float num25 = (float) ((double) NGUIText.fontSize * 0.10000000149011612 * (((double) num16 - (double) num14) / (double) NGUIText.fontSize));
                  verts.Add(new Vector3(num13 - num25, num14));
                  verts.Add(new Vector3(num13 + num25, num16));
                  verts.Add(new Vector3(num15 + num25, num16));
                  verts.Add(new Vector3(num15 - num25, num14));
                }
              }
              else
              {
                for (int index8 = 0; index8 < 4; ++index8)
                {
                  float num26 = NGUIText.mBoldOffset[index8 * 2];
                  float num27 = NGUIText.mBoldOffset[index8 * 2 + 1];
                  float num28 = num26 + (!italic ? 0.0f : (float) ((double) NGUIText.fontSize * 0.10000000149011612 * (((double) num16 - (double) num14) / (double) NGUIText.fontSize)));
                  verts.Add(new Vector3(num13 - num28, num14 + num27));
                  verts.Add(new Vector3(num13 + num28, num16 + num27));
                  verts.Add(new Vector3(num15 + num28, num16 + num27));
                  verts.Add(new Vector3(num15 - num28, num14 + num27));
                }
              }
              if (underline || strike)
              {
                NGUIText.GlyphInfo glyph2 = NGUIText.GetGlyph(!strike ? 95 : 45, prev);
                if (glyph2 != null)
                {
                  if (uvs != null)
                  {
                    if (Object.op_Inequality((Object) NGUIText.bitmapFont, (Object) null))
                    {
                      glyph2.u0.x = ((Rect) ref rect).xMin + num4 * glyph2.u0.x;
                      glyph2.u1.x = ((Rect) ref rect).xMin + num4 * glyph2.u1.x;
                      glyph2.u0.y = ((Rect) ref rect).yMax - num5 * glyph2.u0.y;
                      glyph2.u1.y = ((Rect) ref rect).yMax - num5 * glyph2.u1.y;
                    }
                    float num29 = (float) (((double) glyph2.u0.x + (double) glyph2.u1.x) * 0.5);
                    float num30 = (float) (((double) glyph2.u0.y + (double) glyph2.u1.y) * 0.5);
                    uvs.Add(new Vector2(num29, num30));
                    uvs.Add(new Vector2(num29, num30));
                    uvs.Add(new Vector2(num29, num30));
                    uvs.Add(new Vector2(num29, num30));
                  }
                  float num31;
                  float num32;
                  if (flag && strike)
                  {
                    num31 = (float) ((-(double) num2 + (double) glyph2.v0.y) * 0.75);
                    num32 = (float) ((-(double) num2 + (double) glyph2.v1.y) * 0.75);
                  }
                  else
                  {
                    num31 = -num2 + glyph2.v0.y;
                    num32 = -num2 + glyph2.v1.y;
                  }
                  verts.Add(new Vector3(num8, num31));
                  verts.Add(new Vector3(num8, num32));
                  verts.Add(new Vector3(num1, num32));
                  verts.Add(new Vector3(num1, num31));
                  Color color5 = Color32.op_Implicit(color32_1);
                  if (strike)
                  {
                    color5.r *= 0.5f;
                    color5.g *= 0.5f;
                    color5.b *= 0.5f;
                  }
                  color5.a *= 0.75f;
                  Color32 color32_4 = Color32.op_Implicit(color5);
                  cols.Add(color32_4);
                  cols.Add(color32_1);
                  cols.Add(color32_1);
                  cols.Add(color32_4);
                }
              }
            }
          }
        }
      }
    }
    if (NGUIText.alignment != NGUIText.Alignment.Left && size1 < verts.size)
    {
      NGUIText.Align(verts, size1, num1 - NGUIText.finalSpacingX);
      int size2 = verts.size;
    }
    NGUIText.mColors.Clear();
  }

  public static void PrintCharacterPositions(
    string text,
    BetterList<Vector3> verts,
    BetterList<int> indices)
  {
    if (string.IsNullOrEmpty(text))
      text = " ";
    NGUIText.Prepare(text);
    float num1 = 0.0f;
    float num2 = 0.0f;
    float num3 = 0.0f;
    float num4 = (float) ((double) NGUIText.fontSize * (double) NGUIText.fontScale * 0.5);
    int length = text.Length;
    int size = verts.size;
    int prev = 0;
    for (int index = 0; index < length; ++index)
    {
      int ch = (int) text[index];
      verts.Add(new Vector3(num1, -num2 - num4));
      indices.Add(index);
      if (ch == 10)
      {
        if ((double) num1 > (double) num3)
          num3 = num1;
        if (NGUIText.alignment != NGUIText.Alignment.Left)
        {
          NGUIText.Align(verts, size, num1 - NGUIText.finalSpacingX);
          size = verts.size;
        }
        num1 = 0.0f;
        num2 += NGUIText.finalLineHeight;
        prev = 0;
      }
      else if (ch < 32)
        prev = 0;
      else if (NGUIText.encoding && NGUIText.ParseSymbol(text, ref index))
      {
        --index;
      }
      else
      {
        BMSymbol symbol = !NGUIText.useSymbols ? (BMSymbol) null : NGUIText.GetSymbol(text, index, length);
        if (symbol == null)
        {
          float glyphWidth = NGUIText.GetGlyphWidth(ch, prev);
          if ((double) glyphWidth != 0.0)
          {
            float num5 = glyphWidth + NGUIText.finalSpacingX;
            if (Mathf.RoundToInt(num1 + num5) > NGUIText.rectWidth)
            {
              if ((double) num1 == 0.0)
                return;
              if (NGUIText.alignment != NGUIText.Alignment.Left && size < verts.size)
              {
                NGUIText.Align(verts, size, num1 - NGUIText.finalSpacingX);
                size = verts.size;
              }
              num1 = num5;
              num2 += NGUIText.finalLineHeight;
            }
            else
              num1 += num5;
            verts.Add(new Vector3(num1, -num2 - num4));
            indices.Add(index + 1);
            prev = ch;
          }
        }
        else
        {
          float num6 = (float) symbol.advance * NGUIText.fontScale + NGUIText.finalSpacingX;
          if (Mathf.RoundToInt(num1 + num6) > NGUIText.rectWidth)
          {
            if ((double) num1 == 0.0)
              return;
            if (NGUIText.alignment != NGUIText.Alignment.Left && size < verts.size)
            {
              NGUIText.Align(verts, size, num1 - NGUIText.finalSpacingX);
              size = verts.size;
            }
            num1 = num6;
            num2 += NGUIText.finalLineHeight;
          }
          else
            num1 += num6;
          verts.Add(new Vector3(num1, -num2 - num4));
          indices.Add(index + 1);
          index += symbol.sequence.Length - 1;
          prev = 0;
        }
      }
    }
    if (NGUIText.alignment == NGUIText.Alignment.Left || size >= verts.size)
      return;
    NGUIText.Align(verts, size, num1 - NGUIText.finalSpacingX);
  }

  public static void PrintCaretAndSelection(
    string text,
    int start,
    int end,
    BetterList<Vector3> caret,
    BetterList<Vector3> highlight)
  {
    if (string.IsNullOrEmpty(text))
      text = " ";
    NGUIText.Prepare(text);
    int num1 = end;
    if (start > end)
    {
      end = start;
      start = num1;
    }
    float num2 = 0.0f;
    float num3 = 0.0f;
    float num4 = 0.0f;
    float num5 = (float) NGUIText.fontSize * NGUIText.fontScale;
    int size1 = caret == null ? 0 : caret.size;
    int size2 = highlight == null ? 0 : highlight.size;
    int length = text.Length;
    int index = 0;
    int prev = 0;
    bool flag1 = false;
    bool flag2 = false;
    Vector2 zero1 = Vector2.zero;
    Vector2 zero2 = Vector2.zero;
    for (; index < length; ++index)
    {
      if (caret != null && !flag2 && num1 <= index)
      {
        flag2 = true;
        caret.Add(new Vector3(num2 - 1f, -num3 - num5));
        caret.Add(new Vector3(num2 - 1f, -num3));
        caret.Add(new Vector3(num2 + 1f, -num3));
        caret.Add(new Vector3(num2 + 1f, -num3 - num5));
      }
      int ch = (int) text[index];
      if (ch == 10)
      {
        if ((double) num2 > (double) num4)
          num4 = num2;
        if (caret != null && flag2)
        {
          if (NGUIText.alignment != NGUIText.Alignment.Left)
            NGUIText.Align(caret, size1, num2 - NGUIText.finalSpacingX);
          caret = (BetterList<Vector3>) null;
        }
        if (highlight != null)
        {
          if (flag1)
          {
            flag1 = false;
            highlight.Add(Vector2.op_Implicit(zero2));
            highlight.Add(Vector2.op_Implicit(zero1));
          }
          else if (start <= index && end > index)
          {
            highlight.Add(new Vector3(num2, -num3 - num5));
            highlight.Add(new Vector3(num2, -num3));
            highlight.Add(new Vector3(num2 + 2f, -num3));
            highlight.Add(new Vector3(num2 + 2f, -num3 - num5));
          }
          if (NGUIText.alignment != NGUIText.Alignment.Left && size2 < highlight.size)
          {
            NGUIText.Align(highlight, size2, num2 - NGUIText.finalSpacingX);
            size2 = highlight.size;
          }
        }
        num2 = 0.0f;
        num3 += NGUIText.finalLineHeight;
        prev = 0;
      }
      else if (ch < 32)
        prev = 0;
      else if (NGUIText.encoding && NGUIText.ParseSymbol(text, ref index))
      {
        --index;
      }
      else
      {
        BMSymbol symbol = !NGUIText.useSymbols ? (BMSymbol) null : NGUIText.GetSymbol(text, index, length);
        float num6 = symbol == null ? NGUIText.GetGlyphWidth(ch, prev) : (float) symbol.advance * NGUIText.fontScale;
        if ((double) num6 != 0.0)
        {
          float num7 = num2;
          float num8 = num2 + num6;
          float num9 = -num3 - num5;
          float num10 = -num3;
          if (Mathf.RoundToInt(num8 + NGUIText.finalSpacingX) > NGUIText.rectWidth)
          {
            if ((double) num2 == 0.0)
              return;
            if ((double) num2 > (double) num4)
              num4 = num2;
            if (caret != null && flag2)
            {
              if (NGUIText.alignment != NGUIText.Alignment.Left)
                NGUIText.Align(caret, size1, num2 - NGUIText.finalSpacingX);
              caret = (BetterList<Vector3>) null;
            }
            if (highlight != null)
            {
              if (flag1)
              {
                flag1 = false;
                highlight.Add(Vector2.op_Implicit(zero2));
                highlight.Add(Vector2.op_Implicit(zero1));
              }
              else if (start <= index && end > index)
              {
                highlight.Add(new Vector3(num2, -num3 - num5));
                highlight.Add(new Vector3(num2, -num3));
                highlight.Add(new Vector3(num2 + 2f, -num3));
                highlight.Add(new Vector3(num2 + 2f, -num3 - num5));
              }
              if (NGUIText.alignment != NGUIText.Alignment.Left && size2 < highlight.size)
              {
                Debug.Log((object) "Aligning");
                NGUIText.Align(highlight, size2, num2 - NGUIText.finalSpacingX);
                size2 = highlight.size;
              }
            }
            num7 -= num2;
            num8 -= num2;
            num9 -= NGUIText.finalLineHeight;
            num10 -= NGUIText.finalLineHeight;
            num2 = 0.0f;
            num3 += NGUIText.finalLineHeight;
          }
          num2 += num6 + NGUIText.finalSpacingX;
          if (highlight != null)
          {
            if (start > index || end <= index)
            {
              if (flag1)
              {
                flag1 = false;
                highlight.Add(Vector2.op_Implicit(zero2));
                highlight.Add(Vector2.op_Implicit(zero1));
              }
            }
            else if (!flag1)
            {
              flag1 = true;
              highlight.Add(new Vector3(num7, num9));
              highlight.Add(new Vector3(num7, num10));
            }
          }
          // ISSUE: explicit constructor call
          ((Vector2) ref zero1).\u002Ector(num8, num9);
          // ISSUE: explicit constructor call
          ((Vector2) ref zero2).\u002Ector(num8, num10);
          prev = ch;
        }
      }
    }
    if (caret != null)
    {
      if (!flag2)
      {
        caret.Add(new Vector3(num2 - 1f, -num3 - num5));
        caret.Add(new Vector3(num2 - 1f, -num3));
        caret.Add(new Vector3(num2 + 1f, -num3));
        caret.Add(new Vector3(num2 + 1f, -num3 - num5));
      }
      if (NGUIText.alignment != NGUIText.Alignment.Left)
        NGUIText.Align(caret, size1, num2 - NGUIText.finalSpacingX);
    }
    if (highlight == null)
      return;
    if (flag1)
    {
      highlight.Add(Vector2.op_Implicit(zero2));
      highlight.Add(Vector2.op_Implicit(zero1));
    }
    else if (start < index && end == index)
    {
      highlight.Add(new Vector3(num2, -num3 - num5));
      highlight.Add(new Vector3(num2, -num3));
      highlight.Add(new Vector3(num2 + 2f, -num3));
      highlight.Add(new Vector3(num2 + 2f, -num3 - num5));
    }
    if (NGUIText.alignment == NGUIText.Alignment.Left || size2 >= highlight.size)
      return;
    NGUIText.Align(highlight, size2, num2 - NGUIText.finalSpacingX);
  }

  public static string GetStandardizationTextJP(string text)
  {
    StringBuilder sb = new StringBuilder();
    if (string.IsNullOrEmpty(text))
      return string.Empty;
    NGUIText.Prepare(text);
    int prev = 0;
    float num1 = 0.0f;
    float num2 = 0.0f;
    int length = text.Length;
    BetterList<float> xs = new BetterList<float>();
    float num3 = 0.0f;
    int sub = 0;
    int appendLineCount = 0;
    bool bold = false;
    bool italic = false;
    bool underline = false;
    bool strike = false;
    float num4 = 0.0f;
    if (Object.op_Inequality((Object) NGUIText.bitmapFont, (Object) null))
    {
      Rect uvRect = NGUIText.bitmapFont.uvRect;
      num3 = ((Rect) ref uvRect).width / (float) NGUIText.bitmapFont.texWidth;
    }
    int firstIndex = 0;
    for (int index = 0; index < length; ++index)
    {
      int ch = (int) text[index];
      num4 = num1;
      if (ch == 10)
      {
        if ((double) num1 > (double) num2)
          num2 = num1;
        num1 = 0.0f;
        firstIndex = index + 1;
        prev = 0;
        sb.Append((char) ch);
      }
      else if (ch < 32)
      {
        prev = ch;
        sb.Append((char) ch);
      }
      else
      {
        int startIndex = index;
        if (NGUIText.encoding && NGUIText.ParseSymbol(text, ref index, (BetterList<Color>) null, NGUIText.premultiply, ref sub, ref bold, ref italic, ref underline, ref strike))
        {
          sb.Append(text.Substring(startIndex, index - startIndex));
          --index;
        }
        else
        {
          BMSymbol symbol = !NGUIText.useSymbols ? (BMSymbol) null : NGUIText.GetSymbol(text, index, length);
          float num5;
          if (symbol != null)
          {
            float num6 = num1 + (float) symbol.offsetX * NGUIText.fontScale;
            float num7 = num6 + (float) symbol.width * NGUIText.fontScale;
            if (Mathf.RoundToInt(num1 + (float) symbol.advance * NGUIText.fontScale) > NGUIText.rectWidth)
            {
              sb.Append('\n');
              ++appendLineCount;
              if ((double) num1 == 0.0)
                return sb.ToString();
              num5 = num6 - num1;
              num7 -= num1;
              num1 = 0.0f;
              firstIndex = index + 1;
              num4 = 0.0f;
            }
            xs.Add(num7);
            num1 += NGUIText.finalSpacingX + (float) symbol.advance * NGUIText.fontScale;
            index += symbol.length - 1;
            prev = 0;
          }
          else
          {
            NGUIText.GlyphInfo glyph = NGUIText.GetGlyph(ch, prev);
            if (glyph != null)
            {
              prev = ch;
              if (sub != 0)
              {
                glyph.v0.x *= 0.75f;
                glyph.v1.x *= 0.75f;
              }
              float num8 = glyph.v0.x + num1;
              float num9 = glyph.v1.x + num1;
              float advance = glyph.advance;
              float num10 = sub != 0 ? (float) (((double) NGUIText.finalSpacingX + (double) glyph.advance) * 0.75) : NGUIText.finalSpacingX + glyph.advance;
              if ((double) NGUIText.finalSpacingX < 0.0)
                advance += NGUIText.finalSpacingX;
              if (Mathf.RoundToInt(num1 + advance) > NGUIText.rectWidth)
              {
                if ((double) num1 == 0.0)
                  return sb.ToString();
                if (NGUIText.CheckProhibitedCharacter(text, index, ref firstIndex, ref xs, ref sb, ref appendLineCount))
                {
                  num1 = xs[xs.size - 1];
                  num5 = glyph.v0.x + num1;
                  num9 = glyph.v1.x + num1;
                }
                else
                {
                  num5 = num8 - num1;
                  num9 -= num1;
                  num1 = 0.0f;
                  num4 = 0.0f;
                  firstIndex = index + 1;
                  sb.Append('\n');
                  ++appendLineCount;
                }
              }
              xs.Add(num9);
              if (ch == 32)
              {
                if (underline)
                  ch = 95;
                else if (strike)
                  ch = 45;
              }
              sb.Append((char) ch);
              num1 += num10;
            }
          }
        }
      }
    }
    return sb.ToString();
  }

  public static string GetStandardizationTextEN(string text)
  {
    List<NGUIText.WordInfo> wordInfos = NGUIText.CreateWordInfos(text);
    NGUIText.CalcWordInfos(wordInfos);
    return NGUIText.WriteWordInfos(wordInfos);
  }

  private static bool CheckProhibitedCharacter(
    string text,
    int index,
    ref int firstIndex,
    ref BetterList<float> xs,
    ref StringBuilder sb,
    ref int appendLineCount)
  {
    int num1 = index;
    while (NGUIText.SearchEndLineProhibitionCharacter(text, ref index) || NGUIText.SearchProhibitionCharacter(text, ref index))
    {
      --index;
      if (index <= firstIndex)
        break;
    }
    if (num1 == index || index <= firstIndex)
      return false;
    firstIndex = index + 1;
    sb.Insert(index + appendLineCount, '\n');
    ++appendLineCount;
    int num2 = num1 - index;
    float num3 = xs[xs.size - 1 - num2];
    for (int index1 = xs.size - num2; index1 < xs.size; ++index1)
    {
      BetterList<float> betterList;
      int i;
      (betterList = xs)[i = index1] = betterList[i] - num3;
    }
    return true;
  }

  private static bool SearchProhibitionCharacter(string text, ref int index)
  {
    return NGUIText.SearchCharacters(text, ref index, NGUIText.firstInterdictionTextJP);
  }

  private static bool SearchEndLineProhibitionCharacter(string text, ref int index)
  {
    --index;
    bool flag = NGUIText.SearchCharacters(text, ref index, NGUIText.lastInterdictionTextJP);
    ++index;
    return flag;
  }

  private static bool SearchCharacters(string text, ref int index, string interdictionText)
  {
    if (text[index] == ']')
      index = NGUIText.SkipSymbol(text, index);
    foreach (int num in interdictionText)
    {
      if (num == (int) text[index])
        return true;
    }
    return false;
  }

  private static int SkipSymbol(string text, int index)
  {
    bool flag = true;
    while (flag)
    {
      if (text[index] == ']')
      {
        for (int index1 = 1; index1 < 8; ++index1)
        {
          int index2 = index - index1;
          if (NGUIText.ParseSymbol(text, ref index2))
          {
            index -= index1;
            --index;
            break;
          }
          if (index1 == 7)
            flag = false;
        }
      }
      else
        flag = false;
    }
    return index;
  }

  private static int GetVertsIndex(string text, int index)
  {
    int num = 0;
    for (int index1 = 0; index1 < index; ++index1)
    {
      if (NGUIText.ParseSymbol(text, ref index1))
        --index1;
      else
        ++num;
    }
    return num * 4;
  }

  private static List<NGUIText.WordInfo> CreateWordInfos(string text)
  {
    List<NGUIText.WordInfo> wordInfos = new List<NGUIText.WordInfo>();
    string str1 = text;
    char[] chArray1 = new char[1]{ ' ' };
    foreach (string str2 in str1.Split(chArray1))
    {
      char[] chArray2 = new char[1]{ '\n' };
      string[] strArray = str2.Split(chArray2);
      for (int index = 0; index < strArray.Length; ++index)
        wordInfos.Add(new NGUIText.WordInfo(strArray[index], index != strArray.Length - 1));
    }
    return wordInfos;
  }

  private static void CalcWordInfos(List<NGUIText.WordInfo> wordInfos)
  {
    float num1 = (float) NGUIText.rectWidth;
    float glyphWidth = NGUIText.GetGlyphWidth(32, 0);
    int num2 = 0;
    for (int index = 0; index < wordInfos.Count; ++index)
    {
      float num3 = num1 - wordInfos[index].width;
      if ((double) num3 >= 0.0)
      {
        num1 = num3 - glyphWidth;
        if (wordInfos[index].indention)
        {
          num1 = (float) NGUIText.rectWidth;
          num2 = index + 1;
        }
      }
      else
      {
        num1 = (float) NGUIText.rectWidth;
        if (index == num2)
        {
          wordInfos[index].indention = true;
          num2 = index + 1;
        }
        else
        {
          int num4 = index;
          while (wordInfos[index].first || wordInfos[index - 1].last)
          {
            --index;
            if (index <= num2)
            {
              index = num4;
              break;
            }
          }
          --index;
          wordInfos[index].indention = true;
          num2 = index + 1;
        }
      }
    }
  }

  private static string WriteWordInfos(List<NGUIText.WordInfo> wordInfos)
  {
    StringBuilder stringBuilder = new StringBuilder();
    for (int index = 0; index < wordInfos.Count; ++index)
    {
      NGUIText.WordInfo wordInfo = wordInfos[index];
      stringBuilder.Append(wordInfo.word);
      if (index != wordInfos.Count - 1)
        stringBuilder.Append(!wordInfo.indention ? ' ' : '\n');
    }
    return stringBuilder.ToString();
  }

  public enum Alignment
  {
    Automatic,
    Left,
    Center,
    Right,
    Justified,
  }

  public enum SymbolStyle
  {
    None,
    Normal,
    Colored,
  }

  public class GlyphInfo
  {
    public Vector2 v0;
    public Vector2 v1;
    public Vector2 u0;
    public Vector2 u1;
    public float advance;
    public int channel;
    public bool rotatedUVs;
  }

  private class WordInfo
  {
    public WordInfo(string word, bool indention)
    {
      this.word = word;
      string word1 = this.DeleteSymbol(word);
      this.first = this.IsFirst(word1);
      this.last = this.IsLast(word1);
      this.width = this.SetWidth(word1);
      this.indention = indention;
    }

    public string word { private set; get; }

    public bool first { private set; get; }

    public bool last { private set; get; }

    public float width { private set; get; }

    public bool indention { set; get; }

    private bool IsFirst(string word)
    {
      foreach (char ch in NGUIText.firstInterdictionTextEN)
      {
        if (word.IndexOf(ch) != -1)
          return true;
      }
      return false;
    }

    private bool IsLast(string word)
    {
      foreach (char ch in NGUIText.lastInterdictionTextEN)
      {
        if (word.IndexOf(ch) != -1)
          return true;
      }
      return false;
    }

    private float SetWidth(string word)
    {
      float num = 0.0f;
      foreach (char ch in word)
        num += NGUIText.GetGlyphWidth((int) ch, -1);
      return num;
    }

    private string DeleteSymbol(string word)
    {
      for (int index1 = 0; index1 < word.Length; ++index1)
      {
        if (word[index1] == '[')
        {
          int index2 = index1;
          if (NGUIText.ParseSymbol(word, ref index2))
          {
            int count = index2 - index1;
            word = word.Remove(index1, count);
            --index1;
          }
        }
      }
      return word;
    }
  }
}
