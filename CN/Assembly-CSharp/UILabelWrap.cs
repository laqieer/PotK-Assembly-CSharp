// Decompiled with JetBrains decompiler
// Type: UILabelWrap
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using LuaInterface;
using System;
using UnityEngine;

#nullable disable
public class UILabelWrap
{
  private static System.Type classType = typeof (UILabel);

  public static void Register(IntPtr L)
  {
    LuaMethod[] regs = new LuaMethod[25]
    {
      new LuaMethod("GetSides", new LuaCSFunction(UILabelWrap.GetSides)),
      new LuaMethod("MarkAsChanged", new LuaCSFunction(UILabelWrap.MarkAsChanged)),
      new LuaMethod("MakePixelPerfect", new LuaCSFunction(UILabelWrap.MakePixelPerfect)),
      new LuaMethod("AssumeNaturalSize", new LuaCSFunction(UILabelWrap.AssumeNaturalSize)),
      new LuaMethod("GetCharacterIndexAtPosition", new LuaCSFunction(UILabelWrap.GetCharacterIndexAtPosition)),
      new LuaMethod("GetWordAtPosition", new LuaCSFunction(UILabelWrap.GetWordAtPosition)),
      new LuaMethod("GetWordAtCharacterIndex", new LuaCSFunction(UILabelWrap.GetWordAtCharacterIndex)),
      new LuaMethod("GetUrlAtPosition", new LuaCSFunction(UILabelWrap.GetUrlAtPosition)),
      new LuaMethod("GetUrlAtCharacterIndex", new LuaCSFunction(UILabelWrap.GetUrlAtCharacterIndex)),
      new LuaMethod("GetCharacterIndex", new LuaCSFunction(UILabelWrap.GetCharacterIndex)),
      new LuaMethod("PrintOverlay", new LuaCSFunction(UILabelWrap.PrintOverlay)),
      new LuaMethod("OnFill", new LuaCSFunction(UILabelWrap.OnFill)),
      new LuaMethod("CalculateOffsetToFit", new LuaCSFunction(UILabelWrap.CalculateOffsetToFit)),
      new LuaMethod("SetCurrentProgress", new LuaCSFunction(UILabelWrap.SetCurrentProgress)),
      new LuaMethod("SetCurrentPercent", new LuaCSFunction(UILabelWrap.SetCurrentPercent)),
      new LuaMethod("SetCurrentSelection", new LuaCSFunction(UILabelWrap.SetCurrentSelection)),
      new LuaMethod("Wrap", new LuaCSFunction(UILabelWrap.Wrap)),
      new LuaMethod("UpdateNGUIText", new LuaCSFunction(UILabelWrap.UpdateNGUIText)),
      new LuaMethod("GetStandardizationTextJP", new LuaCSFunction(UILabelWrap.GetStandardizationTextJP)),
      new LuaMethod("GetStandardizationTextEN", new LuaCSFunction(UILabelWrap.GetStandardizationTextEN)),
      new LuaMethod("SetProhibitionJP", new LuaCSFunction(UILabelWrap.SetProhibitionJP)),
      new LuaMethod("SetProhibitionEN", new LuaCSFunction(UILabelWrap.SetProhibitionEN)),
      new LuaMethod("New", new LuaCSFunction(UILabelWrap._CreateUILabel)),
      new LuaMethod("GetClassType", new LuaCSFunction(UILabelWrap.GetClassType)),
      new LuaMethod("__eq", new LuaCSFunction(UILabelWrap.Lua_Eq))
    };
    LuaField[] fields = new LuaField[31]
    {
      new LuaField("keepCrispWhenShrunk", new LuaCSFunction(UILabelWrap.get_keepCrispWhenShrunk), new LuaCSFunction(UILabelWrap.set_keepCrispWhenShrunk)),
      new LuaField("isAnchoredHorizontally", new LuaCSFunction(UILabelWrap.get_isAnchoredHorizontally), (LuaCSFunction) null),
      new LuaField("isAnchoredVertically", new LuaCSFunction(UILabelWrap.get_isAnchoredVertically), (LuaCSFunction) null),
      new LuaField("material", new LuaCSFunction(UILabelWrap.get_material), new LuaCSFunction(UILabelWrap.set_material)),
      new LuaField("bitmapFont", new LuaCSFunction(UILabelWrap.get_bitmapFont), new LuaCSFunction(UILabelWrap.set_bitmapFont)),
      new LuaField("trueTypeFont", new LuaCSFunction(UILabelWrap.get_trueTypeFont), new LuaCSFunction(UILabelWrap.set_trueTypeFont)),
      new LuaField("ambigiousFont", new LuaCSFunction(UILabelWrap.get_ambigiousFont), new LuaCSFunction(UILabelWrap.set_ambigiousFont)),
      new LuaField("text", new LuaCSFunction(UILabelWrap.get_text), new LuaCSFunction(UILabelWrap.set_text)),
      new LuaField("defaultFontSize", new LuaCSFunction(UILabelWrap.get_defaultFontSize), (LuaCSFunction) null),
      new LuaField("fontSize", new LuaCSFunction(UILabelWrap.get_fontSize), new LuaCSFunction(UILabelWrap.set_fontSize)),
      new LuaField("fontStyle", new LuaCSFunction(UILabelWrap.get_fontStyle), new LuaCSFunction(UILabelWrap.set_fontStyle)),
      new LuaField("alignment", new LuaCSFunction(UILabelWrap.get_alignment), new LuaCSFunction(UILabelWrap.set_alignment)),
      new LuaField("applyGradient", new LuaCSFunction(UILabelWrap.get_applyGradient), new LuaCSFunction(UILabelWrap.set_applyGradient)),
      new LuaField("gradientTop", new LuaCSFunction(UILabelWrap.get_gradientTop), new LuaCSFunction(UILabelWrap.set_gradientTop)),
      new LuaField("gradientBottom", new LuaCSFunction(UILabelWrap.get_gradientBottom), new LuaCSFunction(UILabelWrap.set_gradientBottom)),
      new LuaField("spacingX", new LuaCSFunction(UILabelWrap.get_spacingX), new LuaCSFunction(UILabelWrap.set_spacingX)),
      new LuaField("spacingY", new LuaCSFunction(UILabelWrap.get_spacingY), new LuaCSFunction(UILabelWrap.set_spacingY)),
      new LuaField("supportEncoding", new LuaCSFunction(UILabelWrap.get_supportEncoding), new LuaCSFunction(UILabelWrap.set_supportEncoding)),
      new LuaField("symbolStyle", new LuaCSFunction(UILabelWrap.get_symbolStyle), new LuaCSFunction(UILabelWrap.set_symbolStyle)),
      new LuaField("overflowMethod", new LuaCSFunction(UILabelWrap.get_overflowMethod), new LuaCSFunction(UILabelWrap.set_overflowMethod)),
      new LuaField("multiLine", new LuaCSFunction(UILabelWrap.get_multiLine), new LuaCSFunction(UILabelWrap.set_multiLine)),
      new LuaField("localCorners", new LuaCSFunction(UILabelWrap.get_localCorners), (LuaCSFunction) null),
      new LuaField("worldCorners", new LuaCSFunction(UILabelWrap.get_worldCorners), (LuaCSFunction) null),
      new LuaField("drawingDimensions", new LuaCSFunction(UILabelWrap.get_drawingDimensions), (LuaCSFunction) null),
      new LuaField("maxLineCount", new LuaCSFunction(UILabelWrap.get_maxLineCount), new LuaCSFunction(UILabelWrap.set_maxLineCount)),
      new LuaField("effectStyle", new LuaCSFunction(UILabelWrap.get_effectStyle), new LuaCSFunction(UILabelWrap.set_effectStyle)),
      new LuaField("effectColor", new LuaCSFunction(UILabelWrap.get_effectColor), new LuaCSFunction(UILabelWrap.set_effectColor)),
      new LuaField("effectDistance", new LuaCSFunction(UILabelWrap.get_effectDistance), new LuaCSFunction(UILabelWrap.set_effectDistance)),
      new LuaField("processedText", new LuaCSFunction(UILabelWrap.get_processedText), (LuaCSFunction) null),
      new LuaField("printedSize", new LuaCSFunction(UILabelWrap.get_printedSize), (LuaCSFunction) null),
      new LuaField("localSize", new LuaCSFunction(UILabelWrap.get_localSize), (LuaCSFunction) null)
    };
    LuaScriptMgr.RegisterLib(L, "UILabel", typeof (UILabel), regs, fields, typeof (UIWidget));
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int _CreateUILabel(IntPtr L)
  {
    LuaDLL.luaL_error(L, "UILabel class does not have a constructor function");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetClassType(IntPtr L)
  {
    LuaScriptMgr.Push(L, UILabelWrap.classType);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_keepCrispWhenShrunk(IntPtr L)
  {
    UILabel luaObject = (UILabel) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name keepCrispWhenShrunk");
      else
        LuaDLL.luaL_error(L, "attempt to index keepCrispWhenShrunk on a nil value");
    }
    LuaScriptMgr.Push(L, (Enum) luaObject.keepCrispWhenShrunk);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_isAnchoredHorizontally(IntPtr L)
  {
    UILabel luaObject = (UILabel) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name isAnchoredHorizontally");
      else
        LuaDLL.luaL_error(L, "attempt to index isAnchoredHorizontally on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.isAnchoredHorizontally);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_isAnchoredVertically(IntPtr L)
  {
    UILabel luaObject = (UILabel) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name isAnchoredVertically");
      else
        LuaDLL.luaL_error(L, "attempt to index isAnchoredVertically on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.isAnchoredVertically);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_material(IntPtr L)
  {
    UILabel luaObject = (UILabel) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name material");
      else
        LuaDLL.luaL_error(L, "attempt to index material on a nil value");
    }
    LuaScriptMgr.Push(L, (Object) luaObject.material);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_bitmapFont(IntPtr L)
  {
    UILabel luaObject = (UILabel) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name bitmapFont");
      else
        LuaDLL.luaL_error(L, "attempt to index bitmapFont on a nil value");
    }
    LuaScriptMgr.Push(L, (Object) luaObject.bitmapFont);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_trueTypeFont(IntPtr L)
  {
    UILabel luaObject = (UILabel) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name trueTypeFont");
      else
        LuaDLL.luaL_error(L, "attempt to index trueTypeFont on a nil value");
    }
    LuaScriptMgr.Push(L, (Object) luaObject.trueTypeFont);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_ambigiousFont(IntPtr L)
  {
    UILabel luaObject = (UILabel) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name ambigiousFont");
      else
        LuaDLL.luaL_error(L, "attempt to index ambigiousFont on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.ambigiousFont);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_text(IntPtr L)
  {
    UILabel luaObject = (UILabel) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name text");
      else
        LuaDLL.luaL_error(L, "attempt to index text on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.text);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_defaultFontSize(IntPtr L)
  {
    UILabel luaObject = (UILabel) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name defaultFontSize");
      else
        LuaDLL.luaL_error(L, "attempt to index defaultFontSize on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.defaultFontSize);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_fontSize(IntPtr L)
  {
    UILabel luaObject = (UILabel) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name fontSize");
      else
        LuaDLL.luaL_error(L, "attempt to index fontSize on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.fontSize);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_fontStyle(IntPtr L)
  {
    UILabel luaObject = (UILabel) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name fontStyle");
      else
        LuaDLL.luaL_error(L, "attempt to index fontStyle on a nil value");
    }
    LuaScriptMgr.Push(L, (Enum) (object) luaObject.fontStyle);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_alignment(IntPtr L)
  {
    UILabel luaObject = (UILabel) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name alignment");
      else
        LuaDLL.luaL_error(L, "attempt to index alignment on a nil value");
    }
    LuaScriptMgr.Push(L, (Enum) luaObject.alignment);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_applyGradient(IntPtr L)
  {
    UILabel luaObject = (UILabel) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name applyGradient");
      else
        LuaDLL.luaL_error(L, "attempt to index applyGradient on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.applyGradient);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_gradientTop(IntPtr L)
  {
    UILabel luaObject = (UILabel) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name gradientTop");
      else
        LuaDLL.luaL_error(L, "attempt to index gradientTop on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.gradientTop);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_gradientBottom(IntPtr L)
  {
    UILabel luaObject = (UILabel) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name gradientBottom");
      else
        LuaDLL.luaL_error(L, "attempt to index gradientBottom on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.gradientBottom);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_spacingX(IntPtr L)
  {
    UILabel luaObject = (UILabel) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name spacingX");
      else
        LuaDLL.luaL_error(L, "attempt to index spacingX on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.spacingX);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_spacingY(IntPtr L)
  {
    UILabel luaObject = (UILabel) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name spacingY");
      else
        LuaDLL.luaL_error(L, "attempt to index spacingY on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.spacingY);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_supportEncoding(IntPtr L)
  {
    UILabel luaObject = (UILabel) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name supportEncoding");
      else
        LuaDLL.luaL_error(L, "attempt to index supportEncoding on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.supportEncoding);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_symbolStyle(IntPtr L)
  {
    UILabel luaObject = (UILabel) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name symbolStyle");
      else
        LuaDLL.luaL_error(L, "attempt to index symbolStyle on a nil value");
    }
    LuaScriptMgr.Push(L, (Enum) luaObject.symbolStyle);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_overflowMethod(IntPtr L)
  {
    UILabel luaObject = (UILabel) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name overflowMethod");
      else
        LuaDLL.luaL_error(L, "attempt to index overflowMethod on a nil value");
    }
    LuaScriptMgr.Push(L, (Enum) luaObject.overflowMethod);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_multiLine(IntPtr L)
  {
    UILabel luaObject = (UILabel) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name multiLine");
      else
        LuaDLL.luaL_error(L, "attempt to index multiLine on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.multiLine);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_localCorners(IntPtr L)
  {
    UILabel luaObject = (UILabel) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name localCorners");
      else
        LuaDLL.luaL_error(L, "attempt to index localCorners on a nil value");
    }
    LuaScriptMgr.PushArray(L, (Array) luaObject.localCorners);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_worldCorners(IntPtr L)
  {
    UILabel luaObject = (UILabel) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name worldCorners");
      else
        LuaDLL.luaL_error(L, "attempt to index worldCorners on a nil value");
    }
    LuaScriptMgr.PushArray(L, (Array) luaObject.worldCorners);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_drawingDimensions(IntPtr L)
  {
    UILabel luaObject = (UILabel) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name drawingDimensions");
      else
        LuaDLL.luaL_error(L, "attempt to index drawingDimensions on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.drawingDimensions);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_maxLineCount(IntPtr L)
  {
    UILabel luaObject = (UILabel) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name maxLineCount");
      else
        LuaDLL.luaL_error(L, "attempt to index maxLineCount on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.maxLineCount);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_effectStyle(IntPtr L)
  {
    UILabel luaObject = (UILabel) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name effectStyle");
      else
        LuaDLL.luaL_error(L, "attempt to index effectStyle on a nil value");
    }
    LuaScriptMgr.Push(L, (Enum) luaObject.effectStyle);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_effectColor(IntPtr L)
  {
    UILabel luaObject = (UILabel) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name effectColor");
      else
        LuaDLL.luaL_error(L, "attempt to index effectColor on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.effectColor);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_effectDistance(IntPtr L)
  {
    UILabel luaObject = (UILabel) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name effectDistance");
      else
        LuaDLL.luaL_error(L, "attempt to index effectDistance on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.effectDistance);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_processedText(IntPtr L)
  {
    UILabel luaObject = (UILabel) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name processedText");
      else
        LuaDLL.luaL_error(L, "attempt to index processedText on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.processedText);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_printedSize(IntPtr L)
  {
    UILabel luaObject = (UILabel) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name printedSize");
      else
        LuaDLL.luaL_error(L, "attempt to index printedSize on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.printedSize);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_localSize(IntPtr L)
  {
    UILabel luaObject = (UILabel) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name localSize");
      else
        LuaDLL.luaL_error(L, "attempt to index localSize on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.localSize);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_keepCrispWhenShrunk(IntPtr L)
  {
    UILabel luaObject = (UILabel) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name keepCrispWhenShrunk");
      else
        LuaDLL.luaL_error(L, "attempt to index keepCrispWhenShrunk on a nil value");
    }
    luaObject.keepCrispWhenShrunk = (UILabel.Crispness) LuaScriptMgr.GetNetObject(L, 3, typeof (UILabel.Crispness));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_material(IntPtr L)
  {
    UILabel luaObject = (UILabel) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name material");
      else
        LuaDLL.luaL_error(L, "attempt to index material on a nil value");
    }
    luaObject.material = (Material) LuaScriptMgr.GetUnityObject(L, 3, typeof (Material));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_bitmapFont(IntPtr L)
  {
    UILabel luaObject = (UILabel) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name bitmapFont");
      else
        LuaDLL.luaL_error(L, "attempt to index bitmapFont on a nil value");
    }
    luaObject.bitmapFont = (UIFont) LuaScriptMgr.GetUnityObject(L, 3, typeof (UIFont));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_trueTypeFont(IntPtr L)
  {
    UILabel luaObject = (UILabel) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name trueTypeFont");
      else
        LuaDLL.luaL_error(L, "attempt to index trueTypeFont on a nil value");
    }
    luaObject.trueTypeFont = (Font) LuaScriptMgr.GetUnityObject(L, 3, typeof (Font));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_ambigiousFont(IntPtr L)
  {
    UILabel luaObject = (UILabel) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name ambigiousFont");
      else
        LuaDLL.luaL_error(L, "attempt to index ambigiousFont on a nil value");
    }
    luaObject.ambigiousFont = LuaScriptMgr.GetUnityObject(L, 3, typeof (Object));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_text(IntPtr L)
  {
    UILabel luaObject = (UILabel) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name text");
      else
        LuaDLL.luaL_error(L, "attempt to index text on a nil value");
    }
    luaObject.text = LuaScriptMgr.GetString(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_fontSize(IntPtr L)
  {
    UILabel luaObject = (UILabel) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name fontSize");
      else
        LuaDLL.luaL_error(L, "attempt to index fontSize on a nil value");
    }
    luaObject.fontSize = (int) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_fontStyle(IntPtr L)
  {
    UILabel luaObject = (UILabel) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name fontStyle");
      else
        LuaDLL.luaL_error(L, "attempt to index fontStyle on a nil value");
    }
    luaObject.fontStyle = (FontStyle) (int) LuaScriptMgr.GetNetObject(L, 3, typeof (FontStyle));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_alignment(IntPtr L)
  {
    UILabel luaObject = (UILabel) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name alignment");
      else
        LuaDLL.luaL_error(L, "attempt to index alignment on a nil value");
    }
    luaObject.alignment = (NGUIText.Alignment) LuaScriptMgr.GetNetObject(L, 3, typeof (NGUIText.Alignment));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_applyGradient(IntPtr L)
  {
    UILabel luaObject = (UILabel) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name applyGradient");
      else
        LuaDLL.luaL_error(L, "attempt to index applyGradient on a nil value");
    }
    luaObject.applyGradient = LuaScriptMgr.GetBoolean(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_gradientTop(IntPtr L)
  {
    UILabel luaObject = (UILabel) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name gradientTop");
      else
        LuaDLL.luaL_error(L, "attempt to index gradientTop on a nil value");
    }
    luaObject.gradientTop = LuaScriptMgr.GetColor(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_gradientBottom(IntPtr L)
  {
    UILabel luaObject = (UILabel) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name gradientBottom");
      else
        LuaDLL.luaL_error(L, "attempt to index gradientBottom on a nil value");
    }
    luaObject.gradientBottom = LuaScriptMgr.GetColor(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_spacingX(IntPtr L)
  {
    UILabel luaObject = (UILabel) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name spacingX");
      else
        LuaDLL.luaL_error(L, "attempt to index spacingX on a nil value");
    }
    luaObject.spacingX = (int) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_spacingY(IntPtr L)
  {
    UILabel luaObject = (UILabel) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name spacingY");
      else
        LuaDLL.luaL_error(L, "attempt to index spacingY on a nil value");
    }
    luaObject.spacingY = (int) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_supportEncoding(IntPtr L)
  {
    UILabel luaObject = (UILabel) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name supportEncoding");
      else
        LuaDLL.luaL_error(L, "attempt to index supportEncoding on a nil value");
    }
    luaObject.supportEncoding = LuaScriptMgr.GetBoolean(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_symbolStyle(IntPtr L)
  {
    UILabel luaObject = (UILabel) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name symbolStyle");
      else
        LuaDLL.luaL_error(L, "attempt to index symbolStyle on a nil value");
    }
    luaObject.symbolStyle = (NGUIText.SymbolStyle) LuaScriptMgr.GetNetObject(L, 3, typeof (NGUIText.SymbolStyle));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_overflowMethod(IntPtr L)
  {
    UILabel luaObject = (UILabel) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name overflowMethod");
      else
        LuaDLL.luaL_error(L, "attempt to index overflowMethod on a nil value");
    }
    luaObject.overflowMethod = (UILabel.Overflow) LuaScriptMgr.GetNetObject(L, 3, typeof (UILabel.Overflow));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_multiLine(IntPtr L)
  {
    UILabel luaObject = (UILabel) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name multiLine");
      else
        LuaDLL.luaL_error(L, "attempt to index multiLine on a nil value");
    }
    luaObject.multiLine = LuaScriptMgr.GetBoolean(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_maxLineCount(IntPtr L)
  {
    UILabel luaObject = (UILabel) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name maxLineCount");
      else
        LuaDLL.luaL_error(L, "attempt to index maxLineCount on a nil value");
    }
    luaObject.maxLineCount = (int) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_effectStyle(IntPtr L)
  {
    UILabel luaObject = (UILabel) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name effectStyle");
      else
        LuaDLL.luaL_error(L, "attempt to index effectStyle on a nil value");
    }
    luaObject.effectStyle = (UILabel.Effect) LuaScriptMgr.GetNetObject(L, 3, typeof (UILabel.Effect));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_effectColor(IntPtr L)
  {
    UILabel luaObject = (UILabel) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name effectColor");
      else
        LuaDLL.luaL_error(L, "attempt to index effectColor on a nil value");
    }
    luaObject.effectColor = LuaScriptMgr.GetColor(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_effectDistance(IntPtr L)
  {
    UILabel luaObject = (UILabel) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name effectDistance");
      else
        LuaDLL.luaL_error(L, "attempt to index effectDistance on a nil value");
    }
    luaObject.effectDistance = LuaScriptMgr.GetVector2(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetSides(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    Vector3[] sides = ((UILabel) LuaScriptMgr.GetUnityObjectSelf(L, 1, "UILabel")).GetSides((Transform) LuaScriptMgr.GetUnityObject(L, 2, typeof (Transform)));
    LuaScriptMgr.PushArray(L, (Array) sides);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int MarkAsChanged(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    ((UILabel) LuaScriptMgr.GetUnityObjectSelf(L, 1, "UILabel")).MarkAsChanged();
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int MakePixelPerfect(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    ((UILabel) LuaScriptMgr.GetUnityObjectSelf(L, 1, "UILabel")).MakePixelPerfect();
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int AssumeNaturalSize(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    ((UILabel) LuaScriptMgr.GetUnityObjectSelf(L, 1, "UILabel")).AssumeNaturalSize();
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetCharacterIndexAtPosition(IntPtr L)
  {
    int num = LuaDLL.lua_gettop(L);
    if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof (UILabel), typeof (LuaTable)))
    {
      int characterIndexAtPosition = ((UILabel) LuaScriptMgr.GetUnityObjectSelf(L, 1, "UILabel")).GetCharacterIndexAtPosition(LuaScriptMgr.GetVector2(L, 2));
      LuaScriptMgr.Push(L, characterIndexAtPosition);
      return 1;
    }
    if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof (UILabel), typeof (LuaTable)))
    {
      int characterIndexAtPosition = ((UILabel) LuaScriptMgr.GetUnityObjectSelf(L, 1, "UILabel")).GetCharacterIndexAtPosition(LuaScriptMgr.GetVector3(L, 2));
      LuaScriptMgr.Push(L, characterIndexAtPosition);
      return 1;
    }
    LuaDLL.luaL_error(L, "invalid arguments to method: UILabel.GetCharacterIndexAtPosition");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetWordAtPosition(IntPtr L)
  {
    int num = LuaDLL.lua_gettop(L);
    if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof (UILabel), typeof (LuaTable)))
    {
      string wordAtPosition = ((UILabel) LuaScriptMgr.GetUnityObjectSelf(L, 1, "UILabel")).GetWordAtPosition(LuaScriptMgr.GetVector2(L, 2));
      LuaScriptMgr.Push(L, wordAtPosition);
      return 1;
    }
    if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof (UILabel), typeof (LuaTable)))
    {
      string wordAtPosition = ((UILabel) LuaScriptMgr.GetUnityObjectSelf(L, 1, "UILabel")).GetWordAtPosition(LuaScriptMgr.GetVector3(L, 2));
      LuaScriptMgr.Push(L, wordAtPosition);
      return 1;
    }
    LuaDLL.luaL_error(L, "invalid arguments to method: UILabel.GetWordAtPosition");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetWordAtCharacterIndex(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    string atCharacterIndex = ((UILabel) LuaScriptMgr.GetUnityObjectSelf(L, 1, "UILabel")).GetWordAtCharacterIndex((int) LuaScriptMgr.GetNumber(L, 2));
    LuaScriptMgr.Push(L, atCharacterIndex);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetUrlAtPosition(IntPtr L)
  {
    int num = LuaDLL.lua_gettop(L);
    if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof (UILabel), typeof (LuaTable)))
    {
      string urlAtPosition = ((UILabel) LuaScriptMgr.GetUnityObjectSelf(L, 1, "UILabel")).GetUrlAtPosition(LuaScriptMgr.GetVector2(L, 2));
      LuaScriptMgr.Push(L, urlAtPosition);
      return 1;
    }
    if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof (UILabel), typeof (LuaTable)))
    {
      string urlAtPosition = ((UILabel) LuaScriptMgr.GetUnityObjectSelf(L, 1, "UILabel")).GetUrlAtPosition(LuaScriptMgr.GetVector3(L, 2));
      LuaScriptMgr.Push(L, urlAtPosition);
      return 1;
    }
    LuaDLL.luaL_error(L, "invalid arguments to method: UILabel.GetUrlAtPosition");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetUrlAtCharacterIndex(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    string atCharacterIndex = ((UILabel) LuaScriptMgr.GetUnityObjectSelf(L, 1, "UILabel")).GetUrlAtCharacterIndex((int) LuaScriptMgr.GetNumber(L, 2));
    LuaScriptMgr.Push(L, atCharacterIndex);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetCharacterIndex(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 3);
    int characterIndex = ((UILabel) LuaScriptMgr.GetUnityObjectSelf(L, 1, "UILabel")).GetCharacterIndex((int) LuaScriptMgr.GetNumber(L, 2), (KeyCode) (int) LuaScriptMgr.GetNetObject(L, 3, typeof (KeyCode)));
    LuaScriptMgr.Push(L, characterIndex);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int PrintOverlay(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 7);
    ((UILabel) LuaScriptMgr.GetUnityObjectSelf(L, 1, "UILabel")).PrintOverlay((int) LuaScriptMgr.GetNumber(L, 2), (int) LuaScriptMgr.GetNumber(L, 3), (UIGeometry) LuaScriptMgr.GetNetObject(L, 4, typeof (UIGeometry)), (UIGeometry) LuaScriptMgr.GetNetObject(L, 5, typeof (UIGeometry)), LuaScriptMgr.GetColor(L, 6), LuaScriptMgr.GetColor(L, 7));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int OnFill(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 4);
    ((UILabel) LuaScriptMgr.GetUnityObjectSelf(L, 1, "UILabel")).OnFill((BetterList<Vector3>) LuaScriptMgr.GetNetObject(L, 2, typeof (BetterList<Vector3>)), (BetterList<Vector2>) LuaScriptMgr.GetNetObject(L, 3, typeof (BetterList<Vector2>)), (BetterList<Color32>) LuaScriptMgr.GetNetObject(L, 4, typeof (BetterList<Color32>)));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int CalculateOffsetToFit(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    int offsetToFit = ((UILabel) LuaScriptMgr.GetUnityObjectSelf(L, 1, "UILabel")).CalculateOffsetToFit(LuaScriptMgr.GetLuaString(L, 2));
    LuaScriptMgr.Push(L, offsetToFit);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int SetCurrentProgress(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    ((UILabel) LuaScriptMgr.GetUnityObjectSelf(L, 1, "UILabel")).SetCurrentProgress();
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int SetCurrentPercent(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    ((UILabel) LuaScriptMgr.GetUnityObjectSelf(L, 1, "UILabel")).SetCurrentPercent();
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int SetCurrentSelection(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    ((UILabel) LuaScriptMgr.GetUnityObjectSelf(L, 1, "UILabel")).SetCurrentSelection();
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int Wrap(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 3:
        UILabel unityObjectSelf1 = (UILabel) LuaScriptMgr.GetUnityObjectSelf(L, 1, "UILabel");
        string luaString1 = LuaScriptMgr.GetLuaString(L, 2);
        string final1 = (string) null;
        bool b1 = unityObjectSelf1.Wrap(luaString1, out final1);
        LuaScriptMgr.Push(L, b1);
        LuaScriptMgr.Push(L, final1);
        return 2;
      case 4:
        UILabel unityObjectSelf2 = (UILabel) LuaScriptMgr.GetUnityObjectSelf(L, 1, "UILabel");
        string luaString2 = LuaScriptMgr.GetLuaString(L, 2);
        string final2 = (string) null;
        int number = (int) LuaScriptMgr.GetNumber(L, 4);
        bool b2 = unityObjectSelf2.Wrap(luaString2, out final2, number);
        LuaScriptMgr.Push(L, b2);
        LuaScriptMgr.Push(L, final2);
        return 2;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: UILabel.Wrap");
        return 0;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int UpdateNGUIText(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    ((UILabel) LuaScriptMgr.GetUnityObjectSelf(L, 1, "UILabel")).UpdateNGUIText();
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetStandardizationTextJP(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    string standardizationTextJp = ((UILabel) LuaScriptMgr.GetUnityObjectSelf(L, 1, "UILabel")).GetStandardizationTextJP(LuaScriptMgr.GetLuaString(L, 2));
    LuaScriptMgr.Push(L, standardizationTextJp);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetStandardizationTextEN(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    string standardizationTextEn = ((UILabel) LuaScriptMgr.GetUnityObjectSelf(L, 1, "UILabel")).GetStandardizationTextEN(LuaScriptMgr.GetLuaString(L, 2));
    LuaScriptMgr.Push(L, standardizationTextEn);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int SetProhibitionJP(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    UILabel.SetProhibitionJP(LuaScriptMgr.GetLuaString(L, 1), LuaScriptMgr.GetLuaString(L, 2));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int SetProhibitionEN(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    UILabel.SetProhibitionEN(LuaScriptMgr.GetLuaString(L, 1), LuaScriptMgr.GetLuaString(L, 2));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int Lua_Eq(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    bool b = Object.op_Equality(LuaScriptMgr.GetLuaObject(L, 1) as Object, LuaScriptMgr.GetLuaObject(L, 2) as Object);
    LuaScriptMgr.Push(L, b);
    return 1;
  }
}
