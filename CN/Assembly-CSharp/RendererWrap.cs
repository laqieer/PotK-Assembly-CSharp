// Decompiled with JetBrains decompiler
// Type: RendererWrap
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using LuaInterface;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

#nullable disable
public class RendererWrap
{
  private static System.Type classType = typeof (Renderer);

  public static void Register(IntPtr L)
  {
    LuaMethod[] regs = new LuaMethod[6]
    {
      new LuaMethod("SetPropertyBlock", new LuaCSFunction(RendererWrap.SetPropertyBlock)),
      new LuaMethod("GetPropertyBlock", new LuaCSFunction(RendererWrap.GetPropertyBlock)),
      new LuaMethod("GetClosestReflectionProbes", new LuaCSFunction(RendererWrap.GetClosestReflectionProbes)),
      new LuaMethod("New", new LuaCSFunction(RendererWrap._CreateRenderer)),
      new LuaMethod("GetClassType", new LuaCSFunction(RendererWrap.GetClassType)),
      new LuaMethod("__eq", new LuaCSFunction(RendererWrap.Lua_Eq))
    };
    LuaField[] fields = new LuaField[22]
    {
      new LuaField("isPartOfStaticBatch", new LuaCSFunction(RendererWrap.get_isPartOfStaticBatch), (LuaCSFunction) null),
      new LuaField("worldToLocalMatrix", new LuaCSFunction(RendererWrap.get_worldToLocalMatrix), (LuaCSFunction) null),
      new LuaField("localToWorldMatrix", new LuaCSFunction(RendererWrap.get_localToWorldMatrix), (LuaCSFunction) null),
      new LuaField("enabled", new LuaCSFunction(RendererWrap.get_enabled), new LuaCSFunction(RendererWrap.set_enabled)),
      new LuaField("shadowCastingMode", new LuaCSFunction(RendererWrap.get_shadowCastingMode), new LuaCSFunction(RendererWrap.set_shadowCastingMode)),
      new LuaField("receiveShadows", new LuaCSFunction(RendererWrap.get_receiveShadows), new LuaCSFunction(RendererWrap.set_receiveShadows)),
      new LuaField("material", new LuaCSFunction(RendererWrap.get_material), new LuaCSFunction(RendererWrap.set_material)),
      new LuaField("sharedMaterial", new LuaCSFunction(RendererWrap.get_sharedMaterial), new LuaCSFunction(RendererWrap.set_sharedMaterial)),
      new LuaField("materials", new LuaCSFunction(RendererWrap.get_materials), new LuaCSFunction(RendererWrap.set_materials)),
      new LuaField("sharedMaterials", new LuaCSFunction(RendererWrap.get_sharedMaterials), new LuaCSFunction(RendererWrap.set_sharedMaterials)),
      new LuaField("bounds", new LuaCSFunction(RendererWrap.get_bounds), (LuaCSFunction) null),
      new LuaField("lightmapIndex", new LuaCSFunction(RendererWrap.get_lightmapIndex), new LuaCSFunction(RendererWrap.set_lightmapIndex)),
      new LuaField("realtimeLightmapIndex", new LuaCSFunction(RendererWrap.get_realtimeLightmapIndex), new LuaCSFunction(RendererWrap.set_realtimeLightmapIndex)),
      new LuaField("lightmapScaleOffset", new LuaCSFunction(RendererWrap.get_lightmapScaleOffset), new LuaCSFunction(RendererWrap.set_lightmapScaleOffset)),
      new LuaField("realtimeLightmapScaleOffset", new LuaCSFunction(RendererWrap.get_realtimeLightmapScaleOffset), new LuaCSFunction(RendererWrap.set_realtimeLightmapScaleOffset)),
      new LuaField("isVisible", new LuaCSFunction(RendererWrap.get_isVisible), (LuaCSFunction) null),
      new LuaField("useLightProbes", new LuaCSFunction(RendererWrap.get_useLightProbes), new LuaCSFunction(RendererWrap.set_useLightProbes)),
      new LuaField("probeAnchor", new LuaCSFunction(RendererWrap.get_probeAnchor), new LuaCSFunction(RendererWrap.set_probeAnchor)),
      new LuaField("reflectionProbeUsage", new LuaCSFunction(RendererWrap.get_reflectionProbeUsage), new LuaCSFunction(RendererWrap.set_reflectionProbeUsage)),
      new LuaField("sortingLayerName", new LuaCSFunction(RendererWrap.get_sortingLayerName), new LuaCSFunction(RendererWrap.set_sortingLayerName)),
      new LuaField("sortingLayerID", new LuaCSFunction(RendererWrap.get_sortingLayerID), new LuaCSFunction(RendererWrap.set_sortingLayerID)),
      new LuaField("sortingOrder", new LuaCSFunction(RendererWrap.get_sortingOrder), new LuaCSFunction(RendererWrap.set_sortingOrder))
    };
    LuaScriptMgr.RegisterLib(L, "UnityEngine.Renderer", typeof (Renderer), regs, fields, typeof (Component));
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int _CreateRenderer(IntPtr L)
  {
    if (LuaDLL.lua_gettop(L) == 0)
    {
      Renderer renderer = new Renderer();
      LuaScriptMgr.Push(L, (Object) renderer);
      return 1;
    }
    LuaDLL.luaL_error(L, "invalid arguments to method: Renderer.New");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetClassType(IntPtr L)
  {
    LuaScriptMgr.Push(L, RendererWrap.classType);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_isPartOfStaticBatch(IntPtr L)
  {
    Renderer luaObject = (Renderer) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name isPartOfStaticBatch");
      else
        LuaDLL.luaL_error(L, "attempt to index isPartOfStaticBatch on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.isPartOfStaticBatch);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_worldToLocalMatrix(IntPtr L)
  {
    Renderer luaObject = (Renderer) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name worldToLocalMatrix");
      else
        LuaDLL.luaL_error(L, "attempt to index worldToLocalMatrix on a nil value");
    }
    LuaScriptMgr.PushValue(L, (object) luaObject.worldToLocalMatrix);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_localToWorldMatrix(IntPtr L)
  {
    Renderer luaObject = (Renderer) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name localToWorldMatrix");
      else
        LuaDLL.luaL_error(L, "attempt to index localToWorldMatrix on a nil value");
    }
    LuaScriptMgr.PushValue(L, (object) luaObject.localToWorldMatrix);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_enabled(IntPtr L)
  {
    Renderer luaObject = (Renderer) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name enabled");
      else
        LuaDLL.luaL_error(L, "attempt to index enabled on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.enabled);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_shadowCastingMode(IntPtr L)
  {
    Renderer luaObject = (Renderer) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name shadowCastingMode");
      else
        LuaDLL.luaL_error(L, "attempt to index shadowCastingMode on a nil value");
    }
    LuaScriptMgr.Push(L, (Enum) (object) luaObject.shadowCastingMode);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_receiveShadows(IntPtr L)
  {
    Renderer luaObject = (Renderer) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name receiveShadows");
      else
        LuaDLL.luaL_error(L, "attempt to index receiveShadows on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.receiveShadows);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_material(IntPtr L)
  {
    Renderer luaObject = (Renderer) LuaScriptMgr.GetLuaObject(L, 1);
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
  private static int get_sharedMaterial(IntPtr L)
  {
    Renderer luaObject = (Renderer) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name sharedMaterial");
      else
        LuaDLL.luaL_error(L, "attempt to index sharedMaterial on a nil value");
    }
    LuaScriptMgr.Push(L, (Object) luaObject.sharedMaterial);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_materials(IntPtr L)
  {
    Renderer luaObject = (Renderer) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name materials");
      else
        LuaDLL.luaL_error(L, "attempt to index materials on a nil value");
    }
    LuaScriptMgr.PushArray(L, (Array) luaObject.materials);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_sharedMaterials(IntPtr L)
  {
    Renderer luaObject = (Renderer) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name sharedMaterials");
      else
        LuaDLL.luaL_error(L, "attempt to index sharedMaterials on a nil value");
    }
    LuaScriptMgr.PushArray(L, (Array) luaObject.sharedMaterials);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_bounds(IntPtr L)
  {
    Renderer luaObject = (Renderer) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name bounds");
      else
        LuaDLL.luaL_error(L, "attempt to index bounds on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.bounds);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_lightmapIndex(IntPtr L)
  {
    Renderer luaObject = (Renderer) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name lightmapIndex");
      else
        LuaDLL.luaL_error(L, "attempt to index lightmapIndex on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.lightmapIndex);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_realtimeLightmapIndex(IntPtr L)
  {
    Renderer luaObject = (Renderer) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name realtimeLightmapIndex");
      else
        LuaDLL.luaL_error(L, "attempt to index realtimeLightmapIndex on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.realtimeLightmapIndex);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_lightmapScaleOffset(IntPtr L)
  {
    Renderer luaObject = (Renderer) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name lightmapScaleOffset");
      else
        LuaDLL.luaL_error(L, "attempt to index lightmapScaleOffset on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.lightmapScaleOffset);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_realtimeLightmapScaleOffset(IntPtr L)
  {
    Renderer luaObject = (Renderer) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name realtimeLightmapScaleOffset");
      else
        LuaDLL.luaL_error(L, "attempt to index realtimeLightmapScaleOffset on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.realtimeLightmapScaleOffset);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_isVisible(IntPtr L)
  {
    Renderer luaObject = (Renderer) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name isVisible");
      else
        LuaDLL.luaL_error(L, "attempt to index isVisible on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.isVisible);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_useLightProbes(IntPtr L)
  {
    Renderer luaObject = (Renderer) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name useLightProbes");
      else
        LuaDLL.luaL_error(L, "attempt to index useLightProbes on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.useLightProbes);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_probeAnchor(IntPtr L)
  {
    Renderer luaObject = (Renderer) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name probeAnchor");
      else
        LuaDLL.luaL_error(L, "attempt to index probeAnchor on a nil value");
    }
    LuaScriptMgr.Push(L, (Object) luaObject.probeAnchor);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_reflectionProbeUsage(IntPtr L)
  {
    Renderer luaObject = (Renderer) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name reflectionProbeUsage");
      else
        LuaDLL.luaL_error(L, "attempt to index reflectionProbeUsage on a nil value");
    }
    LuaScriptMgr.Push(L, (Enum) (object) luaObject.reflectionProbeUsage);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_sortingLayerName(IntPtr L)
  {
    Renderer luaObject = (Renderer) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name sortingLayerName");
      else
        LuaDLL.luaL_error(L, "attempt to index sortingLayerName on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.sortingLayerName);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_sortingLayerID(IntPtr L)
  {
    Renderer luaObject = (Renderer) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name sortingLayerID");
      else
        LuaDLL.luaL_error(L, "attempt to index sortingLayerID on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.sortingLayerID);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_sortingOrder(IntPtr L)
  {
    Renderer luaObject = (Renderer) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name sortingOrder");
      else
        LuaDLL.luaL_error(L, "attempt to index sortingOrder on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.sortingOrder);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_enabled(IntPtr L)
  {
    Renderer luaObject = (Renderer) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name enabled");
      else
        LuaDLL.luaL_error(L, "attempt to index enabled on a nil value");
    }
    luaObject.enabled = LuaScriptMgr.GetBoolean(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_shadowCastingMode(IntPtr L)
  {
    Renderer luaObject = (Renderer) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name shadowCastingMode");
      else
        LuaDLL.luaL_error(L, "attempt to index shadowCastingMode on a nil value");
    }
    luaObject.shadowCastingMode = (ShadowCastingMode) (int) LuaScriptMgr.GetNetObject(L, 3, typeof (ShadowCastingMode));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_receiveShadows(IntPtr L)
  {
    Renderer luaObject = (Renderer) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name receiveShadows");
      else
        LuaDLL.luaL_error(L, "attempt to index receiveShadows on a nil value");
    }
    luaObject.receiveShadows = LuaScriptMgr.GetBoolean(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_material(IntPtr L)
  {
    Renderer luaObject = (Renderer) LuaScriptMgr.GetLuaObject(L, 1);
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
  private static int set_sharedMaterial(IntPtr L)
  {
    Renderer luaObject = (Renderer) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name sharedMaterial");
      else
        LuaDLL.luaL_error(L, "attempt to index sharedMaterial on a nil value");
    }
    luaObject.sharedMaterial = (Material) LuaScriptMgr.GetUnityObject(L, 3, typeof (Material));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_materials(IntPtr L)
  {
    Renderer luaObject = (Renderer) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name materials");
      else
        LuaDLL.luaL_error(L, "attempt to index materials on a nil value");
    }
    luaObject.materials = LuaScriptMgr.GetArrayObject<Material>(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_sharedMaterials(IntPtr L)
  {
    Renderer luaObject = (Renderer) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name sharedMaterials");
      else
        LuaDLL.luaL_error(L, "attempt to index sharedMaterials on a nil value");
    }
    luaObject.sharedMaterials = LuaScriptMgr.GetArrayObject<Material>(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_lightmapIndex(IntPtr L)
  {
    Renderer luaObject = (Renderer) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name lightmapIndex");
      else
        LuaDLL.luaL_error(L, "attempt to index lightmapIndex on a nil value");
    }
    luaObject.lightmapIndex = (int) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_realtimeLightmapIndex(IntPtr L)
  {
    Renderer luaObject = (Renderer) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name realtimeLightmapIndex");
      else
        LuaDLL.luaL_error(L, "attempt to index realtimeLightmapIndex on a nil value");
    }
    luaObject.realtimeLightmapIndex = (int) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_lightmapScaleOffset(IntPtr L)
  {
    Renderer luaObject = (Renderer) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name lightmapScaleOffset");
      else
        LuaDLL.luaL_error(L, "attempt to index lightmapScaleOffset on a nil value");
    }
    luaObject.lightmapScaleOffset = LuaScriptMgr.GetVector4(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_realtimeLightmapScaleOffset(IntPtr L)
  {
    Renderer luaObject = (Renderer) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name realtimeLightmapScaleOffset");
      else
        LuaDLL.luaL_error(L, "attempt to index realtimeLightmapScaleOffset on a nil value");
    }
    luaObject.realtimeLightmapScaleOffset = LuaScriptMgr.GetVector4(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_useLightProbes(IntPtr L)
  {
    Renderer luaObject = (Renderer) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name useLightProbes");
      else
        LuaDLL.luaL_error(L, "attempt to index useLightProbes on a nil value");
    }
    luaObject.useLightProbes = LuaScriptMgr.GetBoolean(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_probeAnchor(IntPtr L)
  {
    Renderer luaObject = (Renderer) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name probeAnchor");
      else
        LuaDLL.luaL_error(L, "attempt to index probeAnchor on a nil value");
    }
    luaObject.probeAnchor = (Transform) LuaScriptMgr.GetUnityObject(L, 3, typeof (Transform));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_reflectionProbeUsage(IntPtr L)
  {
    Renderer luaObject = (Renderer) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name reflectionProbeUsage");
      else
        LuaDLL.luaL_error(L, "attempt to index reflectionProbeUsage on a nil value");
    }
    luaObject.reflectionProbeUsage = (ReflectionProbeUsage) (int) LuaScriptMgr.GetNetObject(L, 3, typeof (ReflectionProbeUsage));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_sortingLayerName(IntPtr L)
  {
    Renderer luaObject = (Renderer) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name sortingLayerName");
      else
        LuaDLL.luaL_error(L, "attempt to index sortingLayerName on a nil value");
    }
    luaObject.sortingLayerName = LuaScriptMgr.GetString(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_sortingLayerID(IntPtr L)
  {
    Renderer luaObject = (Renderer) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name sortingLayerID");
      else
        LuaDLL.luaL_error(L, "attempt to index sortingLayerID on a nil value");
    }
    luaObject.sortingLayerID = (int) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_sortingOrder(IntPtr L)
  {
    Renderer luaObject = (Renderer) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name sortingOrder");
      else
        LuaDLL.luaL_error(L, "attempt to index sortingOrder on a nil value");
    }
    luaObject.sortingOrder = (int) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int SetPropertyBlock(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    ((Renderer) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Renderer")).SetPropertyBlock((MaterialPropertyBlock) LuaScriptMgr.GetNetObject(L, 2, typeof (MaterialPropertyBlock)));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetPropertyBlock(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    ((Renderer) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Renderer")).GetPropertyBlock((MaterialPropertyBlock) LuaScriptMgr.GetNetObject(L, 2, typeof (MaterialPropertyBlock)));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetClosestReflectionProbes(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    ((Renderer) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Renderer")).GetClosestReflectionProbes((List<ReflectionProbeBlendInfo>) LuaScriptMgr.GetNetObject(L, 2, typeof (List<ReflectionProbeBlendInfo>)));
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
