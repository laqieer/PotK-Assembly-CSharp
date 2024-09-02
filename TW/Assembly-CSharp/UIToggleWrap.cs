// Decompiled with JetBrains decompiler
// Type: UIToggleWrap
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using LuaInterface;
using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class UIToggleWrap
{
  private static System.Type classType = typeof (UIToggle);

  public static void Register(IntPtr L)
  {
    LuaMethod[] regs = new LuaMethod[4]
    {
      new LuaMethod("GetActiveToggle", new LuaCSFunction(UIToggleWrap.GetActiveToggle)),
      new LuaMethod("New", new LuaCSFunction(UIToggleWrap._CreateUIToggle)),
      new LuaMethod("GetClassType", new LuaCSFunction(UIToggleWrap.GetClassType)),
      new LuaMethod("__eq", new LuaCSFunction(UIToggleWrap.Lua_Eq))
    };
    LuaField[] fields = new LuaField[10]
    {
      new LuaField("list", new LuaCSFunction(UIToggleWrap.get_list), new LuaCSFunction(UIToggleWrap.set_list)),
      new LuaField("current", new LuaCSFunction(UIToggleWrap.get_current), new LuaCSFunction(UIToggleWrap.set_current)),
      new LuaField("group", new LuaCSFunction(UIToggleWrap.get_group), new LuaCSFunction(UIToggleWrap.set_group)),
      new LuaField("activeSprite", new LuaCSFunction(UIToggleWrap.get_activeSprite), new LuaCSFunction(UIToggleWrap.set_activeSprite)),
      new LuaField("activeAnimation", new LuaCSFunction(UIToggleWrap.get_activeAnimation), new LuaCSFunction(UIToggleWrap.set_activeAnimation)),
      new LuaField("startsActive", new LuaCSFunction(UIToggleWrap.get_startsActive), new LuaCSFunction(UIToggleWrap.set_startsActive)),
      new LuaField("instantTween", new LuaCSFunction(UIToggleWrap.get_instantTween), new LuaCSFunction(UIToggleWrap.set_instantTween)),
      new LuaField("optionCanBeNone", new LuaCSFunction(UIToggleWrap.get_optionCanBeNone), new LuaCSFunction(UIToggleWrap.set_optionCanBeNone)),
      new LuaField("onChange", new LuaCSFunction(UIToggleWrap.get_onChange), new LuaCSFunction(UIToggleWrap.set_onChange)),
      new LuaField("value", new LuaCSFunction(UIToggleWrap.get_value), new LuaCSFunction(UIToggleWrap.set_value))
    };
    LuaScriptMgr.RegisterLib(L, "UIToggle", typeof (UIToggle), regs, fields, typeof (UIWidgetContainer));
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int _CreateUIToggle(IntPtr L)
  {
    LuaDLL.luaL_error(L, "UIToggle class does not have a constructor function");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetClassType(IntPtr L)
  {
    LuaScriptMgr.Push(L, UIToggleWrap.classType);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_list(IntPtr L)
  {
    LuaScriptMgr.PushObject(L, (object) UIToggle.list);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_current(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Object) UIToggle.current);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_group(IntPtr L)
  {
    UIToggle luaObject = (UIToggle) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name group");
      else
        LuaDLL.luaL_error(L, "attempt to index group on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.group);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_activeSprite(IntPtr L)
  {
    UIToggle luaObject = (UIToggle) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name activeSprite");
      else
        LuaDLL.luaL_error(L, "attempt to index activeSprite on a nil value");
    }
    LuaScriptMgr.Push(L, (Object) luaObject.activeSprite);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_activeAnimation(IntPtr L)
  {
    UIToggle luaObject = (UIToggle) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name activeAnimation");
      else
        LuaDLL.luaL_error(L, "attempt to index activeAnimation on a nil value");
    }
    LuaScriptMgr.Push(L, (Object) luaObject.activeAnimation);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_startsActive(IntPtr L)
  {
    UIToggle luaObject = (UIToggle) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name startsActive");
      else
        LuaDLL.luaL_error(L, "attempt to index startsActive on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.startsActive);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_instantTween(IntPtr L)
  {
    UIToggle luaObject = (UIToggle) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name instantTween");
      else
        LuaDLL.luaL_error(L, "attempt to index instantTween on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.instantTween);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_optionCanBeNone(IntPtr L)
  {
    UIToggle luaObject = (UIToggle) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name optionCanBeNone");
      else
        LuaDLL.luaL_error(L, "attempt to index optionCanBeNone on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.optionCanBeNone);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_onChange(IntPtr L)
  {
    UIToggle luaObject = (UIToggle) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name onChange");
      else
        LuaDLL.luaL_error(L, "attempt to index onChange on a nil value");
    }
    LuaScriptMgr.PushObject(L, (object) luaObject.onChange);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_value(IntPtr L)
  {
    UIToggle luaObject = (UIToggle) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name value");
      else
        LuaDLL.luaL_error(L, "attempt to index value on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.value);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_list(IntPtr L)
  {
    UIToggle.list = (BetterList<UIToggle>) LuaScriptMgr.GetNetObject(L, 3, typeof (BetterList<UIToggle>));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_current(IntPtr L)
  {
    UIToggle.current = (UIToggle) LuaScriptMgr.GetUnityObject(L, 3, typeof (UIToggle));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_group(IntPtr L)
  {
    UIToggle luaObject = (UIToggle) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name group");
      else
        LuaDLL.luaL_error(L, "attempt to index group on a nil value");
    }
    luaObject.group = (int) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_activeSprite(IntPtr L)
  {
    UIToggle luaObject = (UIToggle) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name activeSprite");
      else
        LuaDLL.luaL_error(L, "attempt to index activeSprite on a nil value");
    }
    luaObject.activeSprite = (UIWidget) LuaScriptMgr.GetUnityObject(L, 3, typeof (UIWidget));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_activeAnimation(IntPtr L)
  {
    UIToggle luaObject = (UIToggle) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name activeAnimation");
      else
        LuaDLL.luaL_error(L, "attempt to index activeAnimation on a nil value");
    }
    luaObject.activeAnimation = (Animation) LuaScriptMgr.GetUnityObject(L, 3, typeof (Animation));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_startsActive(IntPtr L)
  {
    UIToggle luaObject = (UIToggle) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name startsActive");
      else
        LuaDLL.luaL_error(L, "attempt to index startsActive on a nil value");
    }
    luaObject.startsActive = LuaScriptMgr.GetBoolean(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_instantTween(IntPtr L)
  {
    UIToggle luaObject = (UIToggle) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name instantTween");
      else
        LuaDLL.luaL_error(L, "attempt to index instantTween on a nil value");
    }
    luaObject.instantTween = LuaScriptMgr.GetBoolean(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_optionCanBeNone(IntPtr L)
  {
    UIToggle luaObject = (UIToggle) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name optionCanBeNone");
      else
        LuaDLL.luaL_error(L, "attempt to index optionCanBeNone on a nil value");
    }
    luaObject.optionCanBeNone = LuaScriptMgr.GetBoolean(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_onChange(IntPtr L)
  {
    UIToggle luaObject = (UIToggle) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name onChange");
      else
        LuaDLL.luaL_error(L, "attempt to index onChange on a nil value");
    }
    luaObject.onChange = (List<EventDelegate>) LuaScriptMgr.GetNetObject(L, 3, typeof (List<EventDelegate>));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_value(IntPtr L)
  {
    UIToggle luaObject = (UIToggle) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name value");
      else
        LuaDLL.luaL_error(L, "attempt to index value on a nil value");
    }
    luaObject.value = LuaScriptMgr.GetBoolean(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetActiveToggle(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    UIToggle activeToggle = UIToggle.GetActiveToggle((int) LuaScriptMgr.GetNumber(L, 1));
    LuaScriptMgr.Push(L, (Object) activeToggle);
    return 1;
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
