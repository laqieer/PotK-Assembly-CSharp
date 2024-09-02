// Decompiled with JetBrains decompiler
// Type: UIAtlasWrap
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using LuaInterface;
using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class UIAtlasWrap
{
  private static System.Type classType = typeof (UIAtlas);

  public static void Register(IntPtr L)
  {
    LuaMethod[] regs = new LuaMethod[8]
    {
      new LuaMethod("GetSprite", new LuaCSFunction(UIAtlasWrap.GetSprite)),
      new LuaMethod("SortAlphabetically", new LuaCSFunction(UIAtlasWrap.SortAlphabetically)),
      new LuaMethod("GetListOfSprites", new LuaCSFunction(UIAtlasWrap.GetListOfSprites)),
      new LuaMethod("CheckIfRelated", new LuaCSFunction(UIAtlasWrap.CheckIfRelated)),
      new LuaMethod("MarkAsChanged", new LuaCSFunction(UIAtlasWrap.MarkAsChanged)),
      new LuaMethod("New", new LuaCSFunction(UIAtlasWrap._CreateUIAtlas)),
      new LuaMethod("GetClassType", new LuaCSFunction(UIAtlasWrap.GetClassType)),
      new LuaMethod("__eq", new LuaCSFunction(UIAtlasWrap.Lua_Eq))
    };
    LuaField[] fields = new LuaField[6]
    {
      new LuaField("spriteMaterial", new LuaCSFunction(UIAtlasWrap.get_spriteMaterial), new LuaCSFunction(UIAtlasWrap.set_spriteMaterial)),
      new LuaField("premultipliedAlpha", new LuaCSFunction(UIAtlasWrap.get_premultipliedAlpha), (LuaCSFunction) null),
      new LuaField("spriteList", new LuaCSFunction(UIAtlasWrap.get_spriteList), new LuaCSFunction(UIAtlasWrap.set_spriteList)),
      new LuaField("texture", new LuaCSFunction(UIAtlasWrap.get_texture), (LuaCSFunction) null),
      new LuaField("pixelSize", new LuaCSFunction(UIAtlasWrap.get_pixelSize), new LuaCSFunction(UIAtlasWrap.set_pixelSize)),
      new LuaField("replacement", new LuaCSFunction(UIAtlasWrap.get_replacement), new LuaCSFunction(UIAtlasWrap.set_replacement))
    };
    LuaScriptMgr.RegisterLib(L, "UIAtlas", typeof (UIAtlas), regs, fields, typeof (MonoBehaviour));
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int _CreateUIAtlas(IntPtr L)
  {
    LuaDLL.luaL_error(L, "UIAtlas class does not have a constructor function");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetClassType(IntPtr L)
  {
    LuaScriptMgr.Push(L, UIAtlasWrap.classType);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_spriteMaterial(IntPtr L)
  {
    UIAtlas luaObject = (UIAtlas) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name spriteMaterial");
      else
        LuaDLL.luaL_error(L, "attempt to index spriteMaterial on a nil value");
    }
    LuaScriptMgr.Push(L, (Object) luaObject.spriteMaterial);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_premultipliedAlpha(IntPtr L)
  {
    UIAtlas luaObject = (UIAtlas) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name premultipliedAlpha");
      else
        LuaDLL.luaL_error(L, "attempt to index premultipliedAlpha on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.premultipliedAlpha);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_spriteList(IntPtr L)
  {
    UIAtlas luaObject = (UIAtlas) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name spriteList");
      else
        LuaDLL.luaL_error(L, "attempt to index spriteList on a nil value");
    }
    LuaScriptMgr.PushObject(L, (object) luaObject.spriteList);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_texture(IntPtr L)
  {
    UIAtlas luaObject = (UIAtlas) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name texture");
      else
        LuaDLL.luaL_error(L, "attempt to index texture on a nil value");
    }
    LuaScriptMgr.Push(L, (Object) luaObject.texture);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_pixelSize(IntPtr L)
  {
    UIAtlas luaObject = (UIAtlas) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name pixelSize");
      else
        LuaDLL.luaL_error(L, "attempt to index pixelSize on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.pixelSize);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_replacement(IntPtr L)
  {
    UIAtlas luaObject = (UIAtlas) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name replacement");
      else
        LuaDLL.luaL_error(L, "attempt to index replacement on a nil value");
    }
    LuaScriptMgr.Push(L, (Object) luaObject.replacement);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_spriteMaterial(IntPtr L)
  {
    UIAtlas luaObject = (UIAtlas) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name spriteMaterial");
      else
        LuaDLL.luaL_error(L, "attempt to index spriteMaterial on a nil value");
    }
    luaObject.spriteMaterial = (Material) LuaScriptMgr.GetUnityObject(L, 3, typeof (Material));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_spriteList(IntPtr L)
  {
    UIAtlas luaObject = (UIAtlas) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name spriteList");
      else
        LuaDLL.luaL_error(L, "attempt to index spriteList on a nil value");
    }
    luaObject.spriteList = (List<UISpriteData>) LuaScriptMgr.GetNetObject(L, 3, typeof (List<UISpriteData>));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_pixelSize(IntPtr L)
  {
    UIAtlas luaObject = (UIAtlas) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name pixelSize");
      else
        LuaDLL.luaL_error(L, "attempt to index pixelSize on a nil value");
    }
    luaObject.pixelSize = (float) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_replacement(IntPtr L)
  {
    UIAtlas luaObject = (UIAtlas) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name replacement");
      else
        LuaDLL.luaL_error(L, "attempt to index replacement on a nil value");
    }
    luaObject.replacement = (UIAtlas) LuaScriptMgr.GetUnityObject(L, 3, typeof (UIAtlas));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetSprite(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    UISpriteData sprite = ((UIAtlas) LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIAtlas")).GetSprite(LuaScriptMgr.GetLuaString(L, 2));
    LuaScriptMgr.PushObject(L, (object) sprite);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int SortAlphabetically(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    ((UIAtlas) LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIAtlas")).SortAlphabetically();
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetListOfSprites(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 1:
        BetterList<string> listOfSprites1 = ((UIAtlas) LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIAtlas")).GetListOfSprites();
        LuaScriptMgr.PushObject(L, (object) listOfSprites1);
        return 1;
      case 2:
        BetterList<string> listOfSprites2 = ((UIAtlas) LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIAtlas")).GetListOfSprites(LuaScriptMgr.GetLuaString(L, 2));
        LuaScriptMgr.PushObject(L, (object) listOfSprites2);
        return 1;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: UIAtlas.GetListOfSprites");
        return 0;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int CheckIfRelated(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    bool b = UIAtlas.CheckIfRelated((UIAtlas) LuaScriptMgr.GetUnityObject(L, 1, typeof (UIAtlas)), (UIAtlas) LuaScriptMgr.GetUnityObject(L, 2, typeof (UIAtlas)));
    LuaScriptMgr.Push(L, b);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int MarkAsChanged(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    ((UIAtlas) LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIAtlas")).MarkAsChanged();
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
