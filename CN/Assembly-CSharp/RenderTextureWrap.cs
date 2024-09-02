// Decompiled with JetBrains decompiler
// Type: RenderTextureWrap
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using LuaInterface;
using System;
using UnityEngine;

#nullable disable
public class RenderTextureWrap
{
  private static System.Type classType = typeof (RenderTexture);

  public static void Register(IntPtr L)
  {
    LuaMethod[] regs = new LuaMethod[13]
    {
      new LuaMethod("GetTemporary", new LuaCSFunction(RenderTextureWrap.GetTemporary)),
      new LuaMethod("ReleaseTemporary", new LuaCSFunction(RenderTextureWrap.ReleaseTemporary)),
      new LuaMethod("Create", new LuaCSFunction(RenderTextureWrap.Create)),
      new LuaMethod("Release", new LuaCSFunction(RenderTextureWrap.Release)),
      new LuaMethod("IsCreated", new LuaCSFunction(RenderTextureWrap.IsCreated)),
      new LuaMethod("DiscardContents", new LuaCSFunction(RenderTextureWrap.DiscardContents)),
      new LuaMethod("MarkRestoreExpected", new LuaCSFunction(RenderTextureWrap.MarkRestoreExpected)),
      new LuaMethod("SetGlobalShaderProperty", new LuaCSFunction(RenderTextureWrap.SetGlobalShaderProperty)),
      new LuaMethod("GetTexelOffset", new LuaCSFunction(RenderTextureWrap.GetTexelOffset)),
      new LuaMethod("SupportsStencil", new LuaCSFunction(RenderTextureWrap.SupportsStencil)),
      new LuaMethod("New", new LuaCSFunction(RenderTextureWrap._CreateRenderTexture)),
      new LuaMethod("GetClassType", new LuaCSFunction(RenderTextureWrap.GetClassType)),
      new LuaMethod("__eq", new LuaCSFunction(RenderTextureWrap.Lua_Eq))
    };
    LuaField[] fields = new LuaField[16]
    {
      new LuaField("width", new LuaCSFunction(RenderTextureWrap.get_width), new LuaCSFunction(RenderTextureWrap.set_width)),
      new LuaField("height", new LuaCSFunction(RenderTextureWrap.get_height), new LuaCSFunction(RenderTextureWrap.set_height)),
      new LuaField("depth", new LuaCSFunction(RenderTextureWrap.get_depth), new LuaCSFunction(RenderTextureWrap.set_depth)),
      new LuaField("isPowerOfTwo", new LuaCSFunction(RenderTextureWrap.get_isPowerOfTwo), new LuaCSFunction(RenderTextureWrap.set_isPowerOfTwo)),
      new LuaField("sRGB", new LuaCSFunction(RenderTextureWrap.get_sRGB), (LuaCSFunction) null),
      new LuaField("format", new LuaCSFunction(RenderTextureWrap.get_format), new LuaCSFunction(RenderTextureWrap.set_format)),
      new LuaField("useMipMap", new LuaCSFunction(RenderTextureWrap.get_useMipMap), new LuaCSFunction(RenderTextureWrap.set_useMipMap)),
      new LuaField("generateMips", new LuaCSFunction(RenderTextureWrap.get_generateMips), new LuaCSFunction(RenderTextureWrap.set_generateMips)),
      new LuaField("isCubemap", new LuaCSFunction(RenderTextureWrap.get_isCubemap), new LuaCSFunction(RenderTextureWrap.set_isCubemap)),
      new LuaField("isVolume", new LuaCSFunction(RenderTextureWrap.get_isVolume), new LuaCSFunction(RenderTextureWrap.set_isVolume)),
      new LuaField("volumeDepth", new LuaCSFunction(RenderTextureWrap.get_volumeDepth), new LuaCSFunction(RenderTextureWrap.set_volumeDepth)),
      new LuaField("antiAliasing", new LuaCSFunction(RenderTextureWrap.get_antiAliasing), new LuaCSFunction(RenderTextureWrap.set_antiAliasing)),
      new LuaField("enableRandomWrite", new LuaCSFunction(RenderTextureWrap.get_enableRandomWrite), new LuaCSFunction(RenderTextureWrap.set_enableRandomWrite)),
      new LuaField("colorBuffer", new LuaCSFunction(RenderTextureWrap.get_colorBuffer), (LuaCSFunction) null),
      new LuaField("depthBuffer", new LuaCSFunction(RenderTextureWrap.get_depthBuffer), (LuaCSFunction) null),
      new LuaField("active", new LuaCSFunction(RenderTextureWrap.get_active), new LuaCSFunction(RenderTextureWrap.set_active))
    };
    LuaScriptMgr.RegisterLib(L, "UnityEngine.RenderTexture", typeof (RenderTexture), regs, fields, typeof (Texture));
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int _CreateRenderTexture(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 3:
        RenderTexture renderTexture1 = new RenderTexture((int) LuaScriptMgr.GetNumber(L, 1), (int) LuaScriptMgr.GetNumber(L, 2), (int) LuaScriptMgr.GetNumber(L, 3));
        LuaScriptMgr.Push(L, (Object) renderTexture1);
        return 1;
      case 4:
        RenderTexture renderTexture2 = new RenderTexture((int) LuaScriptMgr.GetNumber(L, 1), (int) LuaScriptMgr.GetNumber(L, 2), (int) LuaScriptMgr.GetNumber(L, 3), (RenderTextureFormat) (int) LuaScriptMgr.GetNetObject(L, 4, typeof (RenderTextureFormat)));
        LuaScriptMgr.Push(L, (Object) renderTexture2);
        return 1;
      case 5:
        RenderTexture renderTexture3 = new RenderTexture((int) LuaScriptMgr.GetNumber(L, 1), (int) LuaScriptMgr.GetNumber(L, 2), (int) LuaScriptMgr.GetNumber(L, 3), (RenderTextureFormat) (int) LuaScriptMgr.GetNetObject(L, 4, typeof (RenderTextureFormat)), (RenderTextureReadWrite) (int) LuaScriptMgr.GetNetObject(L, 5, typeof (RenderTextureReadWrite)));
        LuaScriptMgr.Push(L, (Object) renderTexture3);
        return 1;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: RenderTexture.New");
        return 0;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetClassType(IntPtr L)
  {
    LuaScriptMgr.Push(L, RenderTextureWrap.classType);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_width(IntPtr L)
  {
    RenderTexture luaObject = (RenderTexture) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name width");
      else
        LuaDLL.luaL_error(L, "attempt to index width on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.width);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_height(IntPtr L)
  {
    RenderTexture luaObject = (RenderTexture) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name height");
      else
        LuaDLL.luaL_error(L, "attempt to index height on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.height);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_depth(IntPtr L)
  {
    RenderTexture luaObject = (RenderTexture) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name depth");
      else
        LuaDLL.luaL_error(L, "attempt to index depth on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.depth);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_isPowerOfTwo(IntPtr L)
  {
    RenderTexture luaObject = (RenderTexture) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name isPowerOfTwo");
      else
        LuaDLL.luaL_error(L, "attempt to index isPowerOfTwo on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.isPowerOfTwo);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_sRGB(IntPtr L)
  {
    RenderTexture luaObject = (RenderTexture) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name sRGB");
      else
        LuaDLL.luaL_error(L, "attempt to index sRGB on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.sRGB);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_format(IntPtr L)
  {
    RenderTexture luaObject = (RenderTexture) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name format");
      else
        LuaDLL.luaL_error(L, "attempt to index format on a nil value");
    }
    LuaScriptMgr.Push(L, (Enum) (object) luaObject.format);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_useMipMap(IntPtr L)
  {
    RenderTexture luaObject = (RenderTexture) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name useMipMap");
      else
        LuaDLL.luaL_error(L, "attempt to index useMipMap on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.useMipMap);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_generateMips(IntPtr L)
  {
    RenderTexture luaObject = (RenderTexture) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name generateMips");
      else
        LuaDLL.luaL_error(L, "attempt to index generateMips on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.generateMips);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_isCubemap(IntPtr L)
  {
    RenderTexture luaObject = (RenderTexture) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name isCubemap");
      else
        LuaDLL.luaL_error(L, "attempt to index isCubemap on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.isCubemap);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_isVolume(IntPtr L)
  {
    RenderTexture luaObject = (RenderTexture) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name isVolume");
      else
        LuaDLL.luaL_error(L, "attempt to index isVolume on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.isVolume);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_volumeDepth(IntPtr L)
  {
    RenderTexture luaObject = (RenderTexture) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name volumeDepth");
      else
        LuaDLL.luaL_error(L, "attempt to index volumeDepth on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.volumeDepth);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_antiAliasing(IntPtr L)
  {
    RenderTexture luaObject = (RenderTexture) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name antiAliasing");
      else
        LuaDLL.luaL_error(L, "attempt to index antiAliasing on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.antiAliasing);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_enableRandomWrite(IntPtr L)
  {
    RenderTexture luaObject = (RenderTexture) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name enableRandomWrite");
      else
        LuaDLL.luaL_error(L, "attempt to index enableRandomWrite on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.enableRandomWrite);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_colorBuffer(IntPtr L)
  {
    RenderTexture luaObject = (RenderTexture) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name colorBuffer");
      else
        LuaDLL.luaL_error(L, "attempt to index colorBuffer on a nil value");
    }
    LuaScriptMgr.PushValue(L, (object) luaObject.colorBuffer);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_depthBuffer(IntPtr L)
  {
    RenderTexture luaObject = (RenderTexture) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name depthBuffer");
      else
        LuaDLL.luaL_error(L, "attempt to index depthBuffer on a nil value");
    }
    LuaScriptMgr.PushValue(L, (object) luaObject.depthBuffer);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_active(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Object) RenderTexture.active);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_width(IntPtr L)
  {
    RenderTexture luaObject = (RenderTexture) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name width");
      else
        LuaDLL.luaL_error(L, "attempt to index width on a nil value");
    }
    luaObject.width = (int) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_height(IntPtr L)
  {
    RenderTexture luaObject = (RenderTexture) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name height");
      else
        LuaDLL.luaL_error(L, "attempt to index height on a nil value");
    }
    luaObject.height = (int) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_depth(IntPtr L)
  {
    RenderTexture luaObject = (RenderTexture) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name depth");
      else
        LuaDLL.luaL_error(L, "attempt to index depth on a nil value");
    }
    luaObject.depth = (int) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_isPowerOfTwo(IntPtr L)
  {
    RenderTexture luaObject = (RenderTexture) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name isPowerOfTwo");
      else
        LuaDLL.luaL_error(L, "attempt to index isPowerOfTwo on a nil value");
    }
    luaObject.isPowerOfTwo = LuaScriptMgr.GetBoolean(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_format(IntPtr L)
  {
    RenderTexture luaObject = (RenderTexture) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name format");
      else
        LuaDLL.luaL_error(L, "attempt to index format on a nil value");
    }
    luaObject.format = (RenderTextureFormat) (int) LuaScriptMgr.GetNetObject(L, 3, typeof (RenderTextureFormat));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_useMipMap(IntPtr L)
  {
    RenderTexture luaObject = (RenderTexture) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name useMipMap");
      else
        LuaDLL.luaL_error(L, "attempt to index useMipMap on a nil value");
    }
    luaObject.useMipMap = LuaScriptMgr.GetBoolean(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_generateMips(IntPtr L)
  {
    RenderTexture luaObject = (RenderTexture) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name generateMips");
      else
        LuaDLL.luaL_error(L, "attempt to index generateMips on a nil value");
    }
    luaObject.generateMips = LuaScriptMgr.GetBoolean(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_isCubemap(IntPtr L)
  {
    RenderTexture luaObject = (RenderTexture) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name isCubemap");
      else
        LuaDLL.luaL_error(L, "attempt to index isCubemap on a nil value");
    }
    luaObject.isCubemap = LuaScriptMgr.GetBoolean(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_isVolume(IntPtr L)
  {
    RenderTexture luaObject = (RenderTexture) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name isVolume");
      else
        LuaDLL.luaL_error(L, "attempt to index isVolume on a nil value");
    }
    luaObject.isVolume = LuaScriptMgr.GetBoolean(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_volumeDepth(IntPtr L)
  {
    RenderTexture luaObject = (RenderTexture) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name volumeDepth");
      else
        LuaDLL.luaL_error(L, "attempt to index volumeDepth on a nil value");
    }
    luaObject.volumeDepth = (int) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_antiAliasing(IntPtr L)
  {
    RenderTexture luaObject = (RenderTexture) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name antiAliasing");
      else
        LuaDLL.luaL_error(L, "attempt to index antiAliasing on a nil value");
    }
    luaObject.antiAliasing = (int) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_enableRandomWrite(IntPtr L)
  {
    RenderTexture luaObject = (RenderTexture) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name enableRandomWrite");
      else
        LuaDLL.luaL_error(L, "attempt to index enableRandomWrite on a nil value");
    }
    luaObject.enableRandomWrite = LuaScriptMgr.GetBoolean(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_active(IntPtr L)
  {
    RenderTexture.active = (RenderTexture) LuaScriptMgr.GetUnityObject(L, 3, typeof (RenderTexture));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetTemporary(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 2:
        RenderTexture temporary1 = RenderTexture.GetTemporary((int) LuaScriptMgr.GetNumber(L, 1), (int) LuaScriptMgr.GetNumber(L, 2));
        LuaScriptMgr.Push(L, (Object) temporary1);
        return 1;
      case 3:
        RenderTexture temporary2 = RenderTexture.GetTemporary((int) LuaScriptMgr.GetNumber(L, 1), (int) LuaScriptMgr.GetNumber(L, 2), (int) LuaScriptMgr.GetNumber(L, 3));
        LuaScriptMgr.Push(L, (Object) temporary2);
        return 1;
      case 4:
        RenderTexture temporary3 = RenderTexture.GetTemporary((int) LuaScriptMgr.GetNumber(L, 1), (int) LuaScriptMgr.GetNumber(L, 2), (int) LuaScriptMgr.GetNumber(L, 3), (RenderTextureFormat) (int) LuaScriptMgr.GetNetObject(L, 4, typeof (RenderTextureFormat)));
        LuaScriptMgr.Push(L, (Object) temporary3);
        return 1;
      case 5:
        RenderTexture temporary4 = RenderTexture.GetTemporary((int) LuaScriptMgr.GetNumber(L, 1), (int) LuaScriptMgr.GetNumber(L, 2), (int) LuaScriptMgr.GetNumber(L, 3), (RenderTextureFormat) (int) LuaScriptMgr.GetNetObject(L, 4, typeof (RenderTextureFormat)), (RenderTextureReadWrite) (int) LuaScriptMgr.GetNetObject(L, 5, typeof (RenderTextureReadWrite)));
        LuaScriptMgr.Push(L, (Object) temporary4);
        return 1;
      case 6:
        RenderTexture temporary5 = RenderTexture.GetTemporary((int) LuaScriptMgr.GetNumber(L, 1), (int) LuaScriptMgr.GetNumber(L, 2), (int) LuaScriptMgr.GetNumber(L, 3), (RenderTextureFormat) (int) LuaScriptMgr.GetNetObject(L, 4, typeof (RenderTextureFormat)), (RenderTextureReadWrite) (int) LuaScriptMgr.GetNetObject(L, 5, typeof (RenderTextureReadWrite)), (int) LuaScriptMgr.GetNumber(L, 6));
        LuaScriptMgr.Push(L, (Object) temporary5);
        return 1;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: RenderTexture.GetTemporary");
        return 0;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int ReleaseTemporary(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    RenderTexture.ReleaseTemporary((RenderTexture) LuaScriptMgr.GetUnityObject(L, 1, typeof (RenderTexture)));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int Create(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    bool b = ((RenderTexture) LuaScriptMgr.GetUnityObjectSelf(L, 1, "RenderTexture")).Create();
    LuaScriptMgr.Push(L, b);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int Release(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    ((RenderTexture) LuaScriptMgr.GetUnityObjectSelf(L, 1, "RenderTexture")).Release();
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int IsCreated(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    bool b = ((RenderTexture) LuaScriptMgr.GetUnityObjectSelf(L, 1, "RenderTexture")).IsCreated();
    LuaScriptMgr.Push(L, b);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int DiscardContents(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 1:
        ((RenderTexture) LuaScriptMgr.GetUnityObjectSelf(L, 1, "RenderTexture")).DiscardContents();
        return 0;
      case 3:
        ((RenderTexture) LuaScriptMgr.GetUnityObjectSelf(L, 1, "RenderTexture")).DiscardContents(LuaScriptMgr.GetBoolean(L, 2), LuaScriptMgr.GetBoolean(L, 3));
        return 0;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: RenderTexture.DiscardContents");
        return 0;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int MarkRestoreExpected(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    ((RenderTexture) LuaScriptMgr.GetUnityObjectSelf(L, 1, "RenderTexture")).MarkRestoreExpected();
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int SetGlobalShaderProperty(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    ((RenderTexture) LuaScriptMgr.GetUnityObjectSelf(L, 1, "RenderTexture")).SetGlobalShaderProperty(LuaScriptMgr.GetLuaString(L, 2));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetTexelOffset(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    Vector2 texelOffset = ((RenderTexture) LuaScriptMgr.GetUnityObjectSelf(L, 1, "RenderTexture")).GetTexelOffset();
    LuaScriptMgr.Push(L, texelOffset);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int SupportsStencil(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    bool b = RenderTexture.SupportsStencil((RenderTexture) LuaScriptMgr.GetUnityObject(L, 1, typeof (RenderTexture)));
    LuaScriptMgr.Push(L, b);
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
