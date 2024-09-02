// Decompiled with JetBrains decompiler
// Type: UIProgressBarWrap
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using LuaInterface;
using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class UIProgressBarWrap
{
  private static System.Type classType = typeof (UIProgressBar);

  public static void Register(IntPtr L)
  {
    LuaMethod[] regs = new LuaMethod[4]
    {
      new LuaMethod("ForceUpdate", new LuaCSFunction(UIProgressBarWrap.ForceUpdate)),
      new LuaMethod("New", new LuaCSFunction(UIProgressBarWrap._CreateUIProgressBar)),
      new LuaMethod("GetClassType", new LuaCSFunction(UIProgressBarWrap.GetClassType)),
      new LuaMethod("__eq", new LuaCSFunction(UIProgressBarWrap.Lua_Eq))
    };
    LuaField[] fields = new LuaField[12]
    {
      new LuaField("current", new LuaCSFunction(UIProgressBarWrap.get_current), new LuaCSFunction(UIProgressBarWrap.set_current)),
      new LuaField("onDragFinished", new LuaCSFunction(UIProgressBarWrap.get_onDragFinished), new LuaCSFunction(UIProgressBarWrap.set_onDragFinished)),
      new LuaField("thumb", new LuaCSFunction(UIProgressBarWrap.get_thumb), new LuaCSFunction(UIProgressBarWrap.set_thumb)),
      new LuaField("numberOfSteps", new LuaCSFunction(UIProgressBarWrap.get_numberOfSteps), new LuaCSFunction(UIProgressBarWrap.set_numberOfSteps)),
      new LuaField("onChange", new LuaCSFunction(UIProgressBarWrap.get_onChange), new LuaCSFunction(UIProgressBarWrap.set_onChange)),
      new LuaField("cachedTransform", new LuaCSFunction(UIProgressBarWrap.get_cachedTransform), (LuaCSFunction) null),
      new LuaField("cachedCamera", new LuaCSFunction(UIProgressBarWrap.get_cachedCamera), (LuaCSFunction) null),
      new LuaField("foregroundWidget", new LuaCSFunction(UIProgressBarWrap.get_foregroundWidget), new LuaCSFunction(UIProgressBarWrap.set_foregroundWidget)),
      new LuaField("backgroundWidget", new LuaCSFunction(UIProgressBarWrap.get_backgroundWidget), new LuaCSFunction(UIProgressBarWrap.set_backgroundWidget)),
      new LuaField("fillDirection", new LuaCSFunction(UIProgressBarWrap.get_fillDirection), new LuaCSFunction(UIProgressBarWrap.set_fillDirection)),
      new LuaField("value", new LuaCSFunction(UIProgressBarWrap.get_value), new LuaCSFunction(UIProgressBarWrap.set_value)),
      new LuaField("alpha", new LuaCSFunction(UIProgressBarWrap.get_alpha), new LuaCSFunction(UIProgressBarWrap.set_alpha))
    };
    LuaScriptMgr.RegisterLib(L, "UIProgressBar", typeof (UIProgressBar), regs, fields, typeof (UIWidgetContainer));
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int _CreateUIProgressBar(IntPtr L)
  {
    LuaDLL.luaL_error(L, "UIProgressBar class does not have a constructor function");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetClassType(IntPtr L)
  {
    LuaScriptMgr.Push(L, UIProgressBarWrap.classType);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_current(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Object) UIProgressBar.current);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_onDragFinished(IntPtr L)
  {
    UIProgressBar luaObject = (UIProgressBar) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name onDragFinished");
      else
        LuaDLL.luaL_error(L, "attempt to index onDragFinished on a nil value");
    }
    LuaScriptMgr.Push(L, (Delegate) luaObject.onDragFinished);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_thumb(IntPtr L)
  {
    UIProgressBar luaObject = (UIProgressBar) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name thumb");
      else
        LuaDLL.luaL_error(L, "attempt to index thumb on a nil value");
    }
    LuaScriptMgr.Push(L, (Object) luaObject.thumb);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_numberOfSteps(IntPtr L)
  {
    UIProgressBar luaObject = (UIProgressBar) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name numberOfSteps");
      else
        LuaDLL.luaL_error(L, "attempt to index numberOfSteps on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.numberOfSteps);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_onChange(IntPtr L)
  {
    UIProgressBar luaObject = (UIProgressBar) LuaScriptMgr.GetLuaObject(L, 1);
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
  private static int get_cachedTransform(IntPtr L)
  {
    UIProgressBar luaObject = (UIProgressBar) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name cachedTransform");
      else
        LuaDLL.luaL_error(L, "attempt to index cachedTransform on a nil value");
    }
    LuaScriptMgr.Push(L, (Object) luaObject.cachedTransform);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_cachedCamera(IntPtr L)
  {
    UIProgressBar luaObject = (UIProgressBar) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name cachedCamera");
      else
        LuaDLL.luaL_error(L, "attempt to index cachedCamera on a nil value");
    }
    LuaScriptMgr.Push(L, (Object) luaObject.cachedCamera);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_foregroundWidget(IntPtr L)
  {
    UIProgressBar luaObject = (UIProgressBar) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name foregroundWidget");
      else
        LuaDLL.luaL_error(L, "attempt to index foregroundWidget on a nil value");
    }
    LuaScriptMgr.Push(L, (Object) luaObject.foregroundWidget);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_backgroundWidget(IntPtr L)
  {
    UIProgressBar luaObject = (UIProgressBar) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name backgroundWidget");
      else
        LuaDLL.luaL_error(L, "attempt to index backgroundWidget on a nil value");
    }
    LuaScriptMgr.Push(L, (Object) luaObject.backgroundWidget);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_fillDirection(IntPtr L)
  {
    UIProgressBar luaObject = (UIProgressBar) LuaScriptMgr.GetLuaObject(L, 1);
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
  private static int get_value(IntPtr L)
  {
    UIProgressBar luaObject = (UIProgressBar) LuaScriptMgr.GetLuaObject(L, 1);
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
  private static int get_alpha(IntPtr L)
  {
    UIProgressBar luaObject = (UIProgressBar) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name alpha");
      else
        LuaDLL.luaL_error(L, "attempt to index alpha on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.alpha);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_current(IntPtr L)
  {
    UIProgressBar.current = (UIProgressBar) LuaScriptMgr.GetUnityObject(L, 3, typeof (UIProgressBar));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_onDragFinished(IntPtr L)
  {
    UIProgressBar luaObject = (UIProgressBar) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name onDragFinished");
      else
        LuaDLL.luaL_error(L, "attempt to index onDragFinished on a nil value");
    }
    if (LuaDLL.lua_type(L, 3) != LuaTypes.LUA_TFUNCTION)
    {
      luaObject.onDragFinished = (UIProgressBar.OnDragFinished) LuaScriptMgr.GetNetObject(L, 3, typeof (UIProgressBar.OnDragFinished));
    }
    else
    {
      LuaFunction func = LuaScriptMgr.ToLuaFunction(L, 3);
      luaObject.onDragFinished = (UIProgressBar.OnDragFinished) (() => func.Call());
    }
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_thumb(IntPtr L)
  {
    UIProgressBar luaObject = (UIProgressBar) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name thumb");
      else
        LuaDLL.luaL_error(L, "attempt to index thumb on a nil value");
    }
    luaObject.thumb = (Transform) LuaScriptMgr.GetUnityObject(L, 3, typeof (Transform));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_numberOfSteps(IntPtr L)
  {
    UIProgressBar luaObject = (UIProgressBar) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name numberOfSteps");
      else
        LuaDLL.luaL_error(L, "attempt to index numberOfSteps on a nil value");
    }
    luaObject.numberOfSteps = (int) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_onChange(IntPtr L)
  {
    UIProgressBar luaObject = (UIProgressBar) LuaScriptMgr.GetLuaObject(L, 1);
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
  private static int set_foregroundWidget(IntPtr L)
  {
    UIProgressBar luaObject = (UIProgressBar) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name foregroundWidget");
      else
        LuaDLL.luaL_error(L, "attempt to index foregroundWidget on a nil value");
    }
    luaObject.foregroundWidget = (UIWidget) LuaScriptMgr.GetUnityObject(L, 3, typeof (UIWidget));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_backgroundWidget(IntPtr L)
  {
    UIProgressBar luaObject = (UIProgressBar) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name backgroundWidget");
      else
        LuaDLL.luaL_error(L, "attempt to index backgroundWidget on a nil value");
    }
    luaObject.backgroundWidget = (UIWidget) LuaScriptMgr.GetUnityObject(L, 3, typeof (UIWidget));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_fillDirection(IntPtr L)
  {
    UIProgressBar luaObject = (UIProgressBar) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name fillDirection");
      else
        LuaDLL.luaL_error(L, "attempt to index fillDirection on a nil value");
    }
    luaObject.fillDirection = (UIProgressBar.FillDirection) LuaScriptMgr.GetNetObject(L, 3, typeof (UIProgressBar.FillDirection));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_value(IntPtr L)
  {
    UIProgressBar luaObject = (UIProgressBar) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name value");
      else
        LuaDLL.luaL_error(L, "attempt to index value on a nil value");
    }
    luaObject.value = (float) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_alpha(IntPtr L)
  {
    UIProgressBar luaObject = (UIProgressBar) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name alpha");
      else
        LuaDLL.luaL_error(L, "attempt to index alpha on a nil value");
    }
    luaObject.alpha = (float) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int ForceUpdate(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    ((UIProgressBar) LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIProgressBar")).ForceUpdate();
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
