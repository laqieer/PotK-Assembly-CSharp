// Decompiled with JetBrains decompiler
// Type: UISpriteWrap
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using LuaInterface;
using System;
using UnityEngine;

#nullable disable
public class UISpriteWrap
{
  private static System.Type classType = typeof (UISprite);

  public static void Register(IntPtr L)
  {
    LuaMethod[] regs = new LuaMethod[6]
    {
      new LuaMethod("GetAtlasSprite", new LuaCSFunction(UISpriteWrap.GetAtlasSprite)),
      new LuaMethod("MakePixelPerfect", new LuaCSFunction(UISpriteWrap.MakePixelPerfect)),
      new LuaMethod("OnFill", new LuaCSFunction(UISpriteWrap.OnFill)),
      new LuaMethod("New", new LuaCSFunction(UISpriteWrap._CreateUISprite)),
      new LuaMethod("GetClassType", new LuaCSFunction(UISpriteWrap.GetClassType)),
      new LuaMethod("__eq", new LuaCSFunction(UISpriteWrap.Lua_Eq))
    };
    LuaField[] fields = new LuaField[17]
    {
      new LuaField("centerType", new LuaCSFunction(UISpriteWrap.get_centerType), new LuaCSFunction(UISpriteWrap.set_centerType)),
      new LuaField("leftType", new LuaCSFunction(UISpriteWrap.get_leftType), new LuaCSFunction(UISpriteWrap.set_leftType)),
      new LuaField("rightType", new LuaCSFunction(UISpriteWrap.get_rightType), new LuaCSFunction(UISpriteWrap.set_rightType)),
      new LuaField("bottomType", new LuaCSFunction(UISpriteWrap.get_bottomType), new LuaCSFunction(UISpriteWrap.set_bottomType)),
      new LuaField("topType", new LuaCSFunction(UISpriteWrap.get_topType), new LuaCSFunction(UISpriteWrap.set_topType)),
      new LuaField("type", new LuaCSFunction(UISpriteWrap.get_type), new LuaCSFunction(UISpriteWrap.set_type)),
      new LuaField("material", new LuaCSFunction(UISpriteWrap.get_material), (LuaCSFunction) null),
      new LuaField("atlas", new LuaCSFunction(UISpriteWrap.get_atlas), new LuaCSFunction(UISpriteWrap.set_atlas)),
      new LuaField("spriteName", new LuaCSFunction(UISpriteWrap.get_spriteName), new LuaCSFunction(UISpriteWrap.set_spriteName)),
      new LuaField("isValid", new LuaCSFunction(UISpriteWrap.get_isValid), (LuaCSFunction) null),
      new LuaField("fillDirection", new LuaCSFunction(UISpriteWrap.get_fillDirection), new LuaCSFunction(UISpriteWrap.set_fillDirection)),
      new LuaField("fillAmount", new LuaCSFunction(UISpriteWrap.get_fillAmount), new LuaCSFunction(UISpriteWrap.set_fillAmount)),
      new LuaField("invert", new LuaCSFunction(UISpriteWrap.get_invert), new LuaCSFunction(UISpriteWrap.set_invert)),
      new LuaField("border", new LuaCSFunction(UISpriteWrap.get_border), (LuaCSFunction) null),
      new LuaField("minWidth", new LuaCSFunction(UISpriteWrap.get_minWidth), (LuaCSFunction) null),
      new LuaField("minHeight", new LuaCSFunction(UISpriteWrap.get_minHeight), (LuaCSFunction) null),
      new LuaField("drawingDimensions", new LuaCSFunction(UISpriteWrap.get_drawingDimensions), (LuaCSFunction) null)
    };
    LuaScriptMgr.RegisterLib(L, "UISprite", typeof (UISprite), regs, fields, typeof (UIWidget));
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int _CreateUISprite(IntPtr L)
  {
    LuaDLL.luaL_error(L, "UISprite class does not have a constructor function");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetClassType(IntPtr L)
  {
    LuaScriptMgr.Push(L, UISpriteWrap.classType);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_centerType(IntPtr L)
  {
    UISprite luaObject = (UISprite) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name centerType");
      else
        LuaDLL.luaL_error(L, "attempt to index centerType on a nil value");
    }
    LuaScriptMgr.Push(L, (Enum) luaObject.centerType);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_leftType(IntPtr L)
  {
    UISprite luaObject = (UISprite) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name leftType");
      else
        LuaDLL.luaL_error(L, "attempt to index leftType on a nil value");
    }
    LuaScriptMgr.Push(L, (Enum) luaObject.leftType);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_rightType(IntPtr L)
  {
    UISprite luaObject = (UISprite) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name rightType");
      else
        LuaDLL.luaL_error(L, "attempt to index rightType on a nil value");
    }
    LuaScriptMgr.Push(L, (Enum) luaObject.rightType);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_bottomType(IntPtr L)
  {
    UISprite luaObject = (UISprite) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name bottomType");
      else
        LuaDLL.luaL_error(L, "attempt to index bottomType on a nil value");
    }
    LuaScriptMgr.Push(L, (Enum) luaObject.bottomType);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_topType(IntPtr L)
  {
    UISprite luaObject = (UISprite) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name topType");
      else
        LuaDLL.luaL_error(L, "attempt to index topType on a nil value");
    }
    LuaScriptMgr.Push(L, (Enum) luaObject.topType);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_type(IntPtr L)
  {
    UISprite luaObject = (UISprite) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name type");
      else
        LuaDLL.luaL_error(L, "attempt to index type on a nil value");
    }
    LuaScriptMgr.Push(L, (Enum) luaObject.type);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_material(IntPtr L)
  {
    UISprite luaObject = (UISprite) LuaScriptMgr.GetLuaObject(L, 1);
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
  private static int get_atlas(IntPtr L)
  {
    UISprite luaObject = (UISprite) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name atlas");
      else
        LuaDLL.luaL_error(L, "attempt to index atlas on a nil value");
    }
    LuaScriptMgr.Push(L, (Object) luaObject.atlas);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_spriteName(IntPtr L)
  {
    UISprite luaObject = (UISprite) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name spriteName");
      else
        LuaDLL.luaL_error(L, "attempt to index spriteName on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.spriteName);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_isValid(IntPtr L)
  {
    UISprite luaObject = (UISprite) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name isValid");
      else
        LuaDLL.luaL_error(L, "attempt to index isValid on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.isValid);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_fillDirection(IntPtr L)
  {
    UISprite luaObject = (UISprite) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name fillDirection");
      else
        LuaDLL.luaL_error(L, "attempt to index fillDirection on a nil value");
    }
    LuaScriptMgr.Push(L, (Enum) luaObject.fillDirection);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_fillAmount(IntPtr L)
  {
    UISprite luaObject = (UISprite) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name fillAmount");
      else
        LuaDLL.luaL_error(L, "attempt to index fillAmount on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.fillAmount);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_invert(IntPtr L)
  {
    UISprite luaObject = (UISprite) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name invert");
      else
        LuaDLL.luaL_error(L, "attempt to index invert on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.invert);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_border(IntPtr L)
  {
    UISprite luaObject = (UISprite) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name border");
      else
        LuaDLL.luaL_error(L, "attempt to index border on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.border);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_minWidth(IntPtr L)
  {
    UISprite luaObject = (UISprite) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name minWidth");
      else
        LuaDLL.luaL_error(L, "attempt to index minWidth on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.minWidth);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_minHeight(IntPtr L)
  {
    UISprite luaObject = (UISprite) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name minHeight");
      else
        LuaDLL.luaL_error(L, "attempt to index minHeight on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.minHeight);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_drawingDimensions(IntPtr L)
  {
    UISprite luaObject = (UISprite) LuaScriptMgr.GetLuaObject(L, 1);
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
  private static int set_centerType(IntPtr L)
  {
    UISprite luaObject = (UISprite) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name centerType");
      else
        LuaDLL.luaL_error(L, "attempt to index centerType on a nil value");
    }
    luaObject.centerType = (UISprite.AdvancedType) LuaScriptMgr.GetNetObject(L, 3, typeof (UISprite.AdvancedType));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_leftType(IntPtr L)
  {
    UISprite luaObject = (UISprite) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name leftType");
      else
        LuaDLL.luaL_error(L, "attempt to index leftType on a nil value");
    }
    luaObject.leftType = (UISprite.AdvancedType) LuaScriptMgr.GetNetObject(L, 3, typeof (UISprite.AdvancedType));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_rightType(IntPtr L)
  {
    UISprite luaObject = (UISprite) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name rightType");
      else
        LuaDLL.luaL_error(L, "attempt to index rightType on a nil value");
    }
    luaObject.rightType = (UISprite.AdvancedType) LuaScriptMgr.GetNetObject(L, 3, typeof (UISprite.AdvancedType));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_bottomType(IntPtr L)
  {
    UISprite luaObject = (UISprite) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name bottomType");
      else
        LuaDLL.luaL_error(L, "attempt to index bottomType on a nil value");
    }
    luaObject.bottomType = (UISprite.AdvancedType) LuaScriptMgr.GetNetObject(L, 3, typeof (UISprite.AdvancedType));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_topType(IntPtr L)
  {
    UISprite luaObject = (UISprite) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name topType");
      else
        LuaDLL.luaL_error(L, "attempt to index topType on a nil value");
    }
    luaObject.topType = (UISprite.AdvancedType) LuaScriptMgr.GetNetObject(L, 3, typeof (UISprite.AdvancedType));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_type(IntPtr L)
  {
    UISprite luaObject = (UISprite) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name type");
      else
        LuaDLL.luaL_error(L, "attempt to index type on a nil value");
    }
    luaObject.type = (UISprite.Type) LuaScriptMgr.GetNetObject(L, 3, typeof (UISprite.Type));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_atlas(IntPtr L)
  {
    UISprite luaObject = (UISprite) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name atlas");
      else
        LuaDLL.luaL_error(L, "attempt to index atlas on a nil value");
    }
    luaObject.atlas = (UIAtlas) LuaScriptMgr.GetUnityObject(L, 3, typeof (UIAtlas));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_spriteName(IntPtr L)
  {
    UISprite luaObject = (UISprite) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name spriteName");
      else
        LuaDLL.luaL_error(L, "attempt to index spriteName on a nil value");
    }
    luaObject.spriteName = LuaScriptMgr.GetString(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_fillDirection(IntPtr L)
  {
    UISprite luaObject = (UISprite) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name fillDirection");
      else
        LuaDLL.luaL_error(L, "attempt to index fillDirection on a nil value");
    }
    luaObject.fillDirection = (UISprite.FillDirection) LuaScriptMgr.GetNetObject(L, 3, typeof (UISprite.FillDirection));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_fillAmount(IntPtr L)
  {
    UISprite luaObject = (UISprite) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name fillAmount");
      else
        LuaDLL.luaL_error(L, "attempt to index fillAmount on a nil value");
    }
    luaObject.fillAmount = (float) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_invert(IntPtr L)
  {
    UISprite luaObject = (UISprite) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name invert");
      else
        LuaDLL.luaL_error(L, "attempt to index invert on a nil value");
    }
    luaObject.invert = LuaScriptMgr.GetBoolean(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetAtlasSprite(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    UISpriteData atlasSprite = ((UISprite) LuaScriptMgr.GetUnityObjectSelf(L, 1, "UISprite")).GetAtlasSprite();
    LuaScriptMgr.PushObject(L, (object) atlasSprite);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int MakePixelPerfect(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    ((UISprite) LuaScriptMgr.GetUnityObjectSelf(L, 1, "UISprite")).MakePixelPerfect();
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int OnFill(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 4);
    ((UISprite) LuaScriptMgr.GetUnityObjectSelf(L, 1, "UISprite")).OnFill((BetterList<Vector3>) LuaScriptMgr.GetNetObject(L, 2, typeof (BetterList<Vector3>)), (BetterList<Vector2>) LuaScriptMgr.GetNetObject(L, 3, typeof (BetterList<Vector2>)), (BetterList<Color32>) LuaScriptMgr.GetNetObject(L, 4, typeof (BetterList<Color32>)));
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
