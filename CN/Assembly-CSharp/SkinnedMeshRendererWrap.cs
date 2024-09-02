// Decompiled with JetBrains decompiler
// Type: SkinnedMeshRendererWrap
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using LuaInterface;
using System;
using UnityEngine;

#nullable disable
public class SkinnedMeshRendererWrap
{
  private static System.Type classType = typeof (SkinnedMeshRenderer);

  public static void Register(IntPtr L)
  {
    LuaMethod[] regs = new LuaMethod[6]
    {
      new LuaMethod("BakeMesh", new LuaCSFunction(SkinnedMeshRendererWrap.BakeMesh)),
      new LuaMethod("GetBlendShapeWeight", new LuaCSFunction(SkinnedMeshRendererWrap.GetBlendShapeWeight)),
      new LuaMethod("SetBlendShapeWeight", new LuaCSFunction(SkinnedMeshRendererWrap.SetBlendShapeWeight)),
      new LuaMethod("New", new LuaCSFunction(SkinnedMeshRendererWrap._CreateSkinnedMeshRenderer)),
      new LuaMethod("GetClassType", new LuaCSFunction(SkinnedMeshRendererWrap.GetClassType)),
      new LuaMethod("__eq", new LuaCSFunction(SkinnedMeshRendererWrap.Lua_Eq))
    };
    LuaField[] fields = new LuaField[6]
    {
      new LuaField("bones", new LuaCSFunction(SkinnedMeshRendererWrap.get_bones), new LuaCSFunction(SkinnedMeshRendererWrap.set_bones)),
      new LuaField("rootBone", new LuaCSFunction(SkinnedMeshRendererWrap.get_rootBone), new LuaCSFunction(SkinnedMeshRendererWrap.set_rootBone)),
      new LuaField("quality", new LuaCSFunction(SkinnedMeshRendererWrap.get_quality), new LuaCSFunction(SkinnedMeshRendererWrap.set_quality)),
      new LuaField("sharedMesh", new LuaCSFunction(SkinnedMeshRendererWrap.get_sharedMesh), new LuaCSFunction(SkinnedMeshRendererWrap.set_sharedMesh)),
      new LuaField("updateWhenOffscreen", new LuaCSFunction(SkinnedMeshRendererWrap.get_updateWhenOffscreen), new LuaCSFunction(SkinnedMeshRendererWrap.set_updateWhenOffscreen)),
      new LuaField("localBounds", new LuaCSFunction(SkinnedMeshRendererWrap.get_localBounds), new LuaCSFunction(SkinnedMeshRendererWrap.set_localBounds))
    };
    LuaScriptMgr.RegisterLib(L, "UnityEngine.SkinnedMeshRenderer", typeof (SkinnedMeshRenderer), regs, fields, typeof (Renderer));
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int _CreateSkinnedMeshRenderer(IntPtr L)
  {
    if (LuaDLL.lua_gettop(L) == 0)
    {
      SkinnedMeshRenderer skinnedMeshRenderer = new SkinnedMeshRenderer();
      LuaScriptMgr.Push(L, (Object) skinnedMeshRenderer);
      return 1;
    }
    LuaDLL.luaL_error(L, "invalid arguments to method: SkinnedMeshRenderer.New");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetClassType(IntPtr L)
  {
    LuaScriptMgr.Push(L, SkinnedMeshRendererWrap.classType);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_bones(IntPtr L)
  {
    SkinnedMeshRenderer luaObject = (SkinnedMeshRenderer) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name bones");
      else
        LuaDLL.luaL_error(L, "attempt to index bones on a nil value");
    }
    LuaScriptMgr.PushArray(L, (Array) luaObject.bones);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_rootBone(IntPtr L)
  {
    SkinnedMeshRenderer luaObject = (SkinnedMeshRenderer) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name rootBone");
      else
        LuaDLL.luaL_error(L, "attempt to index rootBone on a nil value");
    }
    LuaScriptMgr.Push(L, (Object) luaObject.rootBone);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_quality(IntPtr L)
  {
    SkinnedMeshRenderer luaObject = (SkinnedMeshRenderer) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name quality");
      else
        LuaDLL.luaL_error(L, "attempt to index quality on a nil value");
    }
    LuaScriptMgr.Push(L, (Enum) (object) luaObject.quality);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_sharedMesh(IntPtr L)
  {
    SkinnedMeshRenderer luaObject = (SkinnedMeshRenderer) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name sharedMesh");
      else
        LuaDLL.luaL_error(L, "attempt to index sharedMesh on a nil value");
    }
    LuaScriptMgr.Push(L, (Object) luaObject.sharedMesh);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_updateWhenOffscreen(IntPtr L)
  {
    SkinnedMeshRenderer luaObject = (SkinnedMeshRenderer) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name updateWhenOffscreen");
      else
        LuaDLL.luaL_error(L, "attempt to index updateWhenOffscreen on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.updateWhenOffscreen);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_localBounds(IntPtr L)
  {
    SkinnedMeshRenderer luaObject = (SkinnedMeshRenderer) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name localBounds");
      else
        LuaDLL.luaL_error(L, "attempt to index localBounds on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.localBounds);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_bones(IntPtr L)
  {
    SkinnedMeshRenderer luaObject = (SkinnedMeshRenderer) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name bones");
      else
        LuaDLL.luaL_error(L, "attempt to index bones on a nil value");
    }
    luaObject.bones = LuaScriptMgr.GetArrayObject<Transform>(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_rootBone(IntPtr L)
  {
    SkinnedMeshRenderer luaObject = (SkinnedMeshRenderer) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name rootBone");
      else
        LuaDLL.luaL_error(L, "attempt to index rootBone on a nil value");
    }
    luaObject.rootBone = (Transform) LuaScriptMgr.GetUnityObject(L, 3, typeof (Transform));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_quality(IntPtr L)
  {
    SkinnedMeshRenderer luaObject = (SkinnedMeshRenderer) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name quality");
      else
        LuaDLL.luaL_error(L, "attempt to index quality on a nil value");
    }
    luaObject.quality = (SkinQuality) (int) LuaScriptMgr.GetNetObject(L, 3, typeof (SkinQuality));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_sharedMesh(IntPtr L)
  {
    SkinnedMeshRenderer luaObject = (SkinnedMeshRenderer) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name sharedMesh");
      else
        LuaDLL.luaL_error(L, "attempt to index sharedMesh on a nil value");
    }
    luaObject.sharedMesh = (Mesh) LuaScriptMgr.GetUnityObject(L, 3, typeof (Mesh));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_updateWhenOffscreen(IntPtr L)
  {
    SkinnedMeshRenderer luaObject = (SkinnedMeshRenderer) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name updateWhenOffscreen");
      else
        LuaDLL.luaL_error(L, "attempt to index updateWhenOffscreen on a nil value");
    }
    luaObject.updateWhenOffscreen = LuaScriptMgr.GetBoolean(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_localBounds(IntPtr L)
  {
    SkinnedMeshRenderer luaObject = (SkinnedMeshRenderer) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name localBounds");
      else
        LuaDLL.luaL_error(L, "attempt to index localBounds on a nil value");
    }
    luaObject.localBounds = LuaScriptMgr.GetBounds(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int BakeMesh(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    ((SkinnedMeshRenderer) LuaScriptMgr.GetUnityObjectSelf(L, 1, "SkinnedMeshRenderer")).BakeMesh((Mesh) LuaScriptMgr.GetUnityObject(L, 2, typeof (Mesh)));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetBlendShapeWeight(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    float blendShapeWeight = ((SkinnedMeshRenderer) LuaScriptMgr.GetUnityObjectSelf(L, 1, "SkinnedMeshRenderer")).GetBlendShapeWeight((int) LuaScriptMgr.GetNumber(L, 2));
    LuaScriptMgr.Push(L, blendShapeWeight);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int SetBlendShapeWeight(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 3);
    ((SkinnedMeshRenderer) LuaScriptMgr.GetUnityObjectSelf(L, 1, "SkinnedMeshRenderer")).SetBlendShapeWeight((int) LuaScriptMgr.GetNumber(L, 2), (float) LuaScriptMgr.GetNumber(L, 3));
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
