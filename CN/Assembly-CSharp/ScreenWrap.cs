﻿// Decompiled with JetBrains decompiler
// Type: ScreenWrap
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using LuaInterface;
using System;
using UnityEngine;

#nullable disable
public class ScreenWrap
{
  private static System.Type classType = typeof (Screen);

  public static void Register(IntPtr L)
  {
    LuaMethod[] regs = new LuaMethod[3]
    {
      new LuaMethod("SetResolution", new LuaCSFunction(ScreenWrap.SetResolution)),
      new LuaMethod("New", new LuaCSFunction(ScreenWrap._CreateScreen)),
      new LuaMethod("GetClassType", new LuaCSFunction(ScreenWrap.GetClassType))
    };
    LuaField[] fields = new LuaField[12]
    {
      new LuaField("resolutions", new LuaCSFunction(ScreenWrap.get_resolutions), (LuaCSFunction) null),
      new LuaField("currentResolution", new LuaCSFunction(ScreenWrap.get_currentResolution), (LuaCSFunction) null),
      new LuaField("width", new LuaCSFunction(ScreenWrap.get_width), (LuaCSFunction) null),
      new LuaField("height", new LuaCSFunction(ScreenWrap.get_height), (LuaCSFunction) null),
      new LuaField("dpi", new LuaCSFunction(ScreenWrap.get_dpi), (LuaCSFunction) null),
      new LuaField("fullScreen", new LuaCSFunction(ScreenWrap.get_fullScreen), new LuaCSFunction(ScreenWrap.set_fullScreen)),
      new LuaField("autorotateToPortrait", new LuaCSFunction(ScreenWrap.get_autorotateToPortrait), new LuaCSFunction(ScreenWrap.set_autorotateToPortrait)),
      new LuaField("autorotateToPortraitUpsideDown", new LuaCSFunction(ScreenWrap.get_autorotateToPortraitUpsideDown), new LuaCSFunction(ScreenWrap.set_autorotateToPortraitUpsideDown)),
      new LuaField("autorotateToLandscapeLeft", new LuaCSFunction(ScreenWrap.get_autorotateToLandscapeLeft), new LuaCSFunction(ScreenWrap.set_autorotateToLandscapeLeft)),
      new LuaField("autorotateToLandscapeRight", new LuaCSFunction(ScreenWrap.get_autorotateToLandscapeRight), new LuaCSFunction(ScreenWrap.set_autorotateToLandscapeRight)),
      new LuaField("orientation", new LuaCSFunction(ScreenWrap.get_orientation), new LuaCSFunction(ScreenWrap.set_orientation)),
      new LuaField("sleepTimeout", new LuaCSFunction(ScreenWrap.get_sleepTimeout), new LuaCSFunction(ScreenWrap.set_sleepTimeout))
    };
    LuaScriptMgr.RegisterLib(L, "UnityEngine.Screen", typeof (Screen), regs, fields, typeof (object));
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int _CreateScreen(IntPtr L)
  {
    if (LuaDLL.lua_gettop(L) == 0)
    {
      Screen o = new Screen();
      LuaScriptMgr.PushObject(L, (object) o);
      return 1;
    }
    LuaDLL.luaL_error(L, "invalid arguments to method: Screen.New");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetClassType(IntPtr L)
  {
    LuaScriptMgr.Push(L, ScreenWrap.classType);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_resolutions(IntPtr L)
  {
    LuaScriptMgr.PushArray(L, (Array) Screen.resolutions);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_currentResolution(IntPtr L)
  {
    LuaScriptMgr.PushValue(L, (object) Screen.currentResolution);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_width(IntPtr L)
  {
    LuaScriptMgr.Push(L, Screen.width);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_height(IntPtr L)
  {
    LuaScriptMgr.Push(L, Screen.height);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_dpi(IntPtr L)
  {
    LuaScriptMgr.Push(L, Screen.dpi);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_fullScreen(IntPtr L)
  {
    LuaScriptMgr.Push(L, Screen.fullScreen);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_autorotateToPortrait(IntPtr L)
  {
    LuaScriptMgr.Push(L, Screen.autorotateToPortrait);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_autorotateToPortraitUpsideDown(IntPtr L)
  {
    LuaScriptMgr.Push(L, Screen.autorotateToPortraitUpsideDown);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_autorotateToLandscapeLeft(IntPtr L)
  {
    LuaScriptMgr.Push(L, Screen.autorotateToLandscapeLeft);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_autorotateToLandscapeRight(IntPtr L)
  {
    LuaScriptMgr.Push(L, Screen.autorotateToLandscapeRight);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_orientation(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) Screen.orientation);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_sleepTimeout(IntPtr L)
  {
    LuaScriptMgr.Push(L, Screen.sleepTimeout);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_fullScreen(IntPtr L)
  {
    Screen.fullScreen = LuaScriptMgr.GetBoolean(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_autorotateToPortrait(IntPtr L)
  {
    Screen.autorotateToPortrait = LuaScriptMgr.GetBoolean(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_autorotateToPortraitUpsideDown(IntPtr L)
  {
    Screen.autorotateToPortraitUpsideDown = LuaScriptMgr.GetBoolean(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_autorotateToLandscapeLeft(IntPtr L)
  {
    Screen.autorotateToLandscapeLeft = LuaScriptMgr.GetBoolean(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_autorotateToLandscapeRight(IntPtr L)
  {
    Screen.autorotateToLandscapeRight = LuaScriptMgr.GetBoolean(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_orientation(IntPtr L)
  {
    Screen.orientation = (ScreenOrientation) (int) LuaScriptMgr.GetNetObject(L, 3, typeof (ScreenOrientation));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_sleepTimeout(IntPtr L)
  {
    Screen.sleepTimeout = (int) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int SetResolution(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 3:
        Screen.SetResolution((int) LuaScriptMgr.GetNumber(L, 1), (int) LuaScriptMgr.GetNumber(L, 2), LuaScriptMgr.GetBoolean(L, 3));
        return 0;
      case 4:
        Screen.SetResolution((int) LuaScriptMgr.GetNumber(L, 1), (int) LuaScriptMgr.GetNumber(L, 2), LuaScriptMgr.GetBoolean(L, 3), (int) LuaScriptMgr.GetNumber(L, 4));
        return 0;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: Screen.SetResolution");
        return 0;
    }
  }
}
