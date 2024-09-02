// Decompiled with JetBrains decompiler
// Type: LightWrap
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using LuaInterface;
using System;
using UnityEngine;
using UnityEngine.Rendering;

#nullable disable
public class LightWrap
{
  private static System.Type classType = typeof (Light);

  public static void Register(IntPtr L)
  {
    LuaMethod[] regs = new LuaMethod[9]
    {
      new LuaMethod("AddCommandBuffer", new LuaCSFunction(LightWrap.AddCommandBuffer)),
      new LuaMethod("RemoveCommandBuffer", new LuaCSFunction(LightWrap.RemoveCommandBuffer)),
      new LuaMethod("RemoveCommandBuffers", new LuaCSFunction(LightWrap.RemoveCommandBuffers)),
      new LuaMethod("RemoveAllCommandBuffers", new LuaCSFunction(LightWrap.RemoveAllCommandBuffers)),
      new LuaMethod("GetCommandBuffers", new LuaCSFunction(LightWrap.GetCommandBuffers)),
      new LuaMethod("GetLights", new LuaCSFunction(LightWrap.GetLights)),
      new LuaMethod("New", new LuaCSFunction(LightWrap._CreateLight)),
      new LuaMethod("GetClassType", new LuaCSFunction(LightWrap.GetClassType)),
      new LuaMethod("__eq", new LuaCSFunction(LightWrap.Lua_Eq))
    };
    LuaField[] fields = new LuaField[18]
    {
      new LuaField("type", new LuaCSFunction(LightWrap.get_type), new LuaCSFunction(LightWrap.set_type)),
      new LuaField("color", new LuaCSFunction(LightWrap.get_color), new LuaCSFunction(LightWrap.set_color)),
      new LuaField("intensity", new LuaCSFunction(LightWrap.get_intensity), new LuaCSFunction(LightWrap.set_intensity)),
      new LuaField("bounceIntensity", new LuaCSFunction(LightWrap.get_bounceIntensity), new LuaCSFunction(LightWrap.set_bounceIntensity)),
      new LuaField("shadows", new LuaCSFunction(LightWrap.get_shadows), new LuaCSFunction(LightWrap.set_shadows)),
      new LuaField("shadowStrength", new LuaCSFunction(LightWrap.get_shadowStrength), new LuaCSFunction(LightWrap.set_shadowStrength)),
      new LuaField("shadowBias", new LuaCSFunction(LightWrap.get_shadowBias), new LuaCSFunction(LightWrap.set_shadowBias)),
      new LuaField("shadowNormalBias", new LuaCSFunction(LightWrap.get_shadowNormalBias), new LuaCSFunction(LightWrap.set_shadowNormalBias)),
      new LuaField("shadowNearPlane", new LuaCSFunction(LightWrap.get_shadowNearPlane), new LuaCSFunction(LightWrap.set_shadowNearPlane)),
      new LuaField("range", new LuaCSFunction(LightWrap.get_range), new LuaCSFunction(LightWrap.set_range)),
      new LuaField("spotAngle", new LuaCSFunction(LightWrap.get_spotAngle), new LuaCSFunction(LightWrap.set_spotAngle)),
      new LuaField("cookieSize", new LuaCSFunction(LightWrap.get_cookieSize), new LuaCSFunction(LightWrap.set_cookieSize)),
      new LuaField("cookie", new LuaCSFunction(LightWrap.get_cookie), new LuaCSFunction(LightWrap.set_cookie)),
      new LuaField("flare", new LuaCSFunction(LightWrap.get_flare), new LuaCSFunction(LightWrap.set_flare)),
      new LuaField("renderMode", new LuaCSFunction(LightWrap.get_renderMode), new LuaCSFunction(LightWrap.set_renderMode)),
      new LuaField("alreadyLightmapped", new LuaCSFunction(LightWrap.get_alreadyLightmapped), new LuaCSFunction(LightWrap.set_alreadyLightmapped)),
      new LuaField("cullingMask", new LuaCSFunction(LightWrap.get_cullingMask), new LuaCSFunction(LightWrap.set_cullingMask)),
      new LuaField("commandBufferCount", new LuaCSFunction(LightWrap.get_commandBufferCount), (LuaCSFunction) null)
    };
    LuaScriptMgr.RegisterLib(L, "UnityEngine.Light", typeof (Light), regs, fields, typeof (Behaviour));
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int _CreateLight(IntPtr L)
  {
    if (LuaDLL.lua_gettop(L) == 0)
    {
      Light light = new Light();
      LuaScriptMgr.Push(L, (Object) light);
      return 1;
    }
    LuaDLL.luaL_error(L, "invalid arguments to method: Light.New");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetClassType(IntPtr L)
  {
    LuaScriptMgr.Push(L, LightWrap.classType);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_type(IntPtr L)
  {
    Light luaObject = (Light) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name type");
      else
        LuaDLL.luaL_error(L, "attempt to index type on a nil value");
    }
    LuaScriptMgr.Push(L, (Enum) (object) luaObject.type);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_color(IntPtr L)
  {
    Light luaObject = (Light) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name color");
      else
        LuaDLL.luaL_error(L, "attempt to index color on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.color);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_intensity(IntPtr L)
  {
    Light luaObject = (Light) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name intensity");
      else
        LuaDLL.luaL_error(L, "attempt to index intensity on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.intensity);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_bounceIntensity(IntPtr L)
  {
    Light luaObject = (Light) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name bounceIntensity");
      else
        LuaDLL.luaL_error(L, "attempt to index bounceIntensity on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.bounceIntensity);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_shadows(IntPtr L)
  {
    Light luaObject = (Light) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name shadows");
      else
        LuaDLL.luaL_error(L, "attempt to index shadows on a nil value");
    }
    LuaScriptMgr.Push(L, (Enum) (object) luaObject.shadows);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_shadowStrength(IntPtr L)
  {
    Light luaObject = (Light) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name shadowStrength");
      else
        LuaDLL.luaL_error(L, "attempt to index shadowStrength on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.shadowStrength);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_shadowBias(IntPtr L)
  {
    Light luaObject = (Light) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name shadowBias");
      else
        LuaDLL.luaL_error(L, "attempt to index shadowBias on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.shadowBias);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_shadowNormalBias(IntPtr L)
  {
    Light luaObject = (Light) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name shadowNormalBias");
      else
        LuaDLL.luaL_error(L, "attempt to index shadowNormalBias on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.shadowNormalBias);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_shadowNearPlane(IntPtr L)
  {
    Light luaObject = (Light) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name shadowNearPlane");
      else
        LuaDLL.luaL_error(L, "attempt to index shadowNearPlane on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.shadowNearPlane);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_range(IntPtr L)
  {
    Light luaObject = (Light) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name range");
      else
        LuaDLL.luaL_error(L, "attempt to index range on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.range);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_spotAngle(IntPtr L)
  {
    Light luaObject = (Light) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name spotAngle");
      else
        LuaDLL.luaL_error(L, "attempt to index spotAngle on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.spotAngle);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_cookieSize(IntPtr L)
  {
    Light luaObject = (Light) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name cookieSize");
      else
        LuaDLL.luaL_error(L, "attempt to index cookieSize on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.cookieSize);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_cookie(IntPtr L)
  {
    Light luaObject = (Light) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name cookie");
      else
        LuaDLL.luaL_error(L, "attempt to index cookie on a nil value");
    }
    LuaScriptMgr.Push(L, (Object) luaObject.cookie);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_flare(IntPtr L)
  {
    Light luaObject = (Light) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name flare");
      else
        LuaDLL.luaL_error(L, "attempt to index flare on a nil value");
    }
    LuaScriptMgr.Push(L, (Object) luaObject.flare);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_renderMode(IntPtr L)
  {
    Light luaObject = (Light) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name renderMode");
      else
        LuaDLL.luaL_error(L, "attempt to index renderMode on a nil value");
    }
    LuaScriptMgr.Push(L, (Enum) (object) luaObject.renderMode);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_alreadyLightmapped(IntPtr L)
  {
    Light luaObject = (Light) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name alreadyLightmapped");
      else
        LuaDLL.luaL_error(L, "attempt to index alreadyLightmapped on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.alreadyLightmapped);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_cullingMask(IntPtr L)
  {
    Light luaObject = (Light) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name cullingMask");
      else
        LuaDLL.luaL_error(L, "attempt to index cullingMask on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.cullingMask);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_commandBufferCount(IntPtr L)
  {
    Light luaObject = (Light) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name commandBufferCount");
      else
        LuaDLL.luaL_error(L, "attempt to index commandBufferCount on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.commandBufferCount);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_type(IntPtr L)
  {
    Light luaObject = (Light) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name type");
      else
        LuaDLL.luaL_error(L, "attempt to index type on a nil value");
    }
    luaObject.type = (LightType) (int) LuaScriptMgr.GetNetObject(L, 3, typeof (LightType));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_color(IntPtr L)
  {
    Light luaObject = (Light) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name color");
      else
        LuaDLL.luaL_error(L, "attempt to index color on a nil value");
    }
    luaObject.color = LuaScriptMgr.GetColor(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_intensity(IntPtr L)
  {
    Light luaObject = (Light) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name intensity");
      else
        LuaDLL.luaL_error(L, "attempt to index intensity on a nil value");
    }
    luaObject.intensity = (float) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_bounceIntensity(IntPtr L)
  {
    Light luaObject = (Light) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name bounceIntensity");
      else
        LuaDLL.luaL_error(L, "attempt to index bounceIntensity on a nil value");
    }
    luaObject.bounceIntensity = (float) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_shadows(IntPtr L)
  {
    Light luaObject = (Light) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name shadows");
      else
        LuaDLL.luaL_error(L, "attempt to index shadows on a nil value");
    }
    luaObject.shadows = (LightShadows) (int) LuaScriptMgr.GetNetObject(L, 3, typeof (LightShadows));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_shadowStrength(IntPtr L)
  {
    Light luaObject = (Light) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name shadowStrength");
      else
        LuaDLL.luaL_error(L, "attempt to index shadowStrength on a nil value");
    }
    luaObject.shadowStrength = (float) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_shadowBias(IntPtr L)
  {
    Light luaObject = (Light) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name shadowBias");
      else
        LuaDLL.luaL_error(L, "attempt to index shadowBias on a nil value");
    }
    luaObject.shadowBias = (float) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_shadowNormalBias(IntPtr L)
  {
    Light luaObject = (Light) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name shadowNormalBias");
      else
        LuaDLL.luaL_error(L, "attempt to index shadowNormalBias on a nil value");
    }
    luaObject.shadowNormalBias = (float) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_shadowNearPlane(IntPtr L)
  {
    Light luaObject = (Light) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name shadowNearPlane");
      else
        LuaDLL.luaL_error(L, "attempt to index shadowNearPlane on a nil value");
    }
    luaObject.shadowNearPlane = (float) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_range(IntPtr L)
  {
    Light luaObject = (Light) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name range");
      else
        LuaDLL.luaL_error(L, "attempt to index range on a nil value");
    }
    luaObject.range = (float) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_spotAngle(IntPtr L)
  {
    Light luaObject = (Light) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name spotAngle");
      else
        LuaDLL.luaL_error(L, "attempt to index spotAngle on a nil value");
    }
    luaObject.spotAngle = (float) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_cookieSize(IntPtr L)
  {
    Light luaObject = (Light) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name cookieSize");
      else
        LuaDLL.luaL_error(L, "attempt to index cookieSize on a nil value");
    }
    luaObject.cookieSize = (float) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_cookie(IntPtr L)
  {
    Light luaObject = (Light) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name cookie");
      else
        LuaDLL.luaL_error(L, "attempt to index cookie on a nil value");
    }
    luaObject.cookie = (Texture) LuaScriptMgr.GetUnityObject(L, 3, typeof (Texture));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_flare(IntPtr L)
  {
    Light luaObject = (Light) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name flare");
      else
        LuaDLL.luaL_error(L, "attempt to index flare on a nil value");
    }
    luaObject.flare = (Flare) LuaScriptMgr.GetUnityObject(L, 3, typeof (Flare));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_renderMode(IntPtr L)
  {
    Light luaObject = (Light) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name renderMode");
      else
        LuaDLL.luaL_error(L, "attempt to index renderMode on a nil value");
    }
    luaObject.renderMode = (LightRenderMode) (int) LuaScriptMgr.GetNetObject(L, 3, typeof (LightRenderMode));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_alreadyLightmapped(IntPtr L)
  {
    Light luaObject = (Light) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name alreadyLightmapped");
      else
        LuaDLL.luaL_error(L, "attempt to index alreadyLightmapped on a nil value");
    }
    luaObject.alreadyLightmapped = LuaScriptMgr.GetBoolean(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_cullingMask(IntPtr L)
  {
    Light luaObject = (Light) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name cullingMask");
      else
        LuaDLL.luaL_error(L, "attempt to index cullingMask on a nil value");
    }
    luaObject.cullingMask = (int) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int AddCommandBuffer(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 3);
    ((Light) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Light")).AddCommandBuffer((LightEvent) (int) LuaScriptMgr.GetNetObject(L, 2, typeof (LightEvent)), (CommandBuffer) LuaScriptMgr.GetNetObject(L, 3, typeof (CommandBuffer)));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int RemoveCommandBuffer(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 3);
    ((Light) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Light")).RemoveCommandBuffer((LightEvent) (int) LuaScriptMgr.GetNetObject(L, 2, typeof (LightEvent)), (CommandBuffer) LuaScriptMgr.GetNetObject(L, 3, typeof (CommandBuffer)));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int RemoveCommandBuffers(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    ((Light) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Light")).RemoveCommandBuffers((LightEvent) (int) LuaScriptMgr.GetNetObject(L, 2, typeof (LightEvent)));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int RemoveAllCommandBuffers(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    ((Light) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Light")).RemoveAllCommandBuffers();
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetCommandBuffers(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    CommandBuffer[] commandBuffers = ((Light) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Light")).GetCommandBuffers((LightEvent) (int) LuaScriptMgr.GetNetObject(L, 2, typeof (LightEvent)));
    LuaScriptMgr.PushArray(L, (Array) commandBuffers);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetLights(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    Light[] lights = Light.GetLights((LightType) (int) LuaScriptMgr.GetNetObject(L, 1, typeof (LightType)), (int) LuaScriptMgr.GetNumber(L, 2));
    LuaScriptMgr.PushArray(L, (Array) lights);
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
