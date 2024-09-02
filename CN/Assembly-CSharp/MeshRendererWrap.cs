// Decompiled with JetBrains decompiler
// Type: MeshRendererWrap
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using LuaInterface;
using System;
using UnityEngine;

#nullable disable
public class MeshRendererWrap
{
  private static System.Type classType = typeof (MeshRenderer);

  public static void Register(IntPtr L)
  {
    LuaMethod[] regs = new LuaMethod[3]
    {
      new LuaMethod("New", new LuaCSFunction(MeshRendererWrap._CreateMeshRenderer)),
      new LuaMethod("GetClassType", new LuaCSFunction(MeshRendererWrap.GetClassType)),
      new LuaMethod("__eq", new LuaCSFunction(MeshRendererWrap.Lua_Eq))
    };
    LuaField[] fields = new LuaField[1]
    {
      new LuaField("additionalVertexStreams", new LuaCSFunction(MeshRendererWrap.get_additionalVertexStreams), new LuaCSFunction(MeshRendererWrap.set_additionalVertexStreams))
    };
    LuaScriptMgr.RegisterLib(L, "UnityEngine.MeshRenderer", typeof (MeshRenderer), regs, fields, typeof (Renderer));
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int _CreateMeshRenderer(IntPtr L)
  {
    if (LuaDLL.lua_gettop(L) == 0)
    {
      MeshRenderer meshRenderer = new MeshRenderer();
      LuaScriptMgr.Push(L, (Object) meshRenderer);
      return 1;
    }
    LuaDLL.luaL_error(L, "invalid arguments to method: MeshRenderer.New");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetClassType(IntPtr L)
  {
    LuaScriptMgr.Push(L, MeshRendererWrap.classType);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_additionalVertexStreams(IntPtr L)
  {
    MeshRenderer luaObject = (MeshRenderer) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name additionalVertexStreams");
      else
        LuaDLL.luaL_error(L, "attempt to index additionalVertexStreams on a nil value");
    }
    LuaScriptMgr.Push(L, (Object) luaObject.additionalVertexStreams);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_additionalVertexStreams(IntPtr L)
  {
    MeshRenderer luaObject = (MeshRenderer) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name additionalVertexStreams");
      else
        LuaDLL.luaL_error(L, "attempt to index additionalVertexStreams on a nil value");
    }
    luaObject.additionalVertexStreams = (Mesh) LuaScriptMgr.GetUnityObject(L, 3, typeof (Mesh));
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
