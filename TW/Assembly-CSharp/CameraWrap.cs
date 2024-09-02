// Decompiled with JetBrains decompiler
// Type: CameraWrap
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using LuaInterface;
using System;
using UnityEngine;
using UnityEngine.Rendering;

#nullable disable
public class CameraWrap
{
  private static System.Type classType = typeof (Camera);

  public static void Register(IntPtr L)
  {
    LuaMethod[] regs = new LuaMethod[35]
    {
      new LuaMethod("SetTargetBuffers", new LuaCSFunction(CameraWrap.SetTargetBuffers)),
      new LuaMethod("ResetWorldToCameraMatrix", new LuaCSFunction(CameraWrap.ResetWorldToCameraMatrix)),
      new LuaMethod("ResetProjectionMatrix", new LuaCSFunction(CameraWrap.ResetProjectionMatrix)),
      new LuaMethod("ResetAspect", new LuaCSFunction(CameraWrap.ResetAspect)),
      new LuaMethod("ResetFieldOfView", new LuaCSFunction(CameraWrap.ResetFieldOfView)),
      new LuaMethod("SetStereoViewMatrices", new LuaCSFunction(CameraWrap.SetStereoViewMatrices)),
      new LuaMethod("ResetStereoViewMatrices", new LuaCSFunction(CameraWrap.ResetStereoViewMatrices)),
      new LuaMethod("SetStereoProjectionMatrices", new LuaCSFunction(CameraWrap.SetStereoProjectionMatrices)),
      new LuaMethod("ResetStereoProjectionMatrices", new LuaCSFunction(CameraWrap.ResetStereoProjectionMatrices)),
      new LuaMethod("WorldToScreenPoint", new LuaCSFunction(CameraWrap.WorldToScreenPoint)),
      new LuaMethod("WorldToViewportPoint", new LuaCSFunction(CameraWrap.WorldToViewportPoint)),
      new LuaMethod("ViewportToWorldPoint", new LuaCSFunction(CameraWrap.ViewportToWorldPoint)),
      new LuaMethod("ScreenToWorldPoint", new LuaCSFunction(CameraWrap.ScreenToWorldPoint)),
      new LuaMethod("ScreenToViewportPoint", new LuaCSFunction(CameraWrap.ScreenToViewportPoint)),
      new LuaMethod("ViewportToScreenPoint", new LuaCSFunction(CameraWrap.ViewportToScreenPoint)),
      new LuaMethod("ViewportPointToRay", new LuaCSFunction(CameraWrap.ViewportPointToRay)),
      new LuaMethod("ScreenPointToRay", new LuaCSFunction(CameraWrap.ScreenPointToRay)),
      new LuaMethod("GetAllCameras", new LuaCSFunction(CameraWrap.GetAllCameras)),
      new LuaMethod("Render", new LuaCSFunction(CameraWrap.Render)),
      new LuaMethod("RenderWithShader", new LuaCSFunction(CameraWrap.RenderWithShader)),
      new LuaMethod("SetReplacementShader", new LuaCSFunction(CameraWrap.SetReplacementShader)),
      new LuaMethod("ResetReplacementShader", new LuaCSFunction(CameraWrap.ResetReplacementShader)),
      new LuaMethod("RenderDontRestore", new LuaCSFunction(CameraWrap.RenderDontRestore)),
      new LuaMethod("SetupCurrent", new LuaCSFunction(CameraWrap.SetupCurrent)),
      new LuaMethod("RenderToCubemap", new LuaCSFunction(CameraWrap.RenderToCubemap)),
      new LuaMethod("CopyFrom", new LuaCSFunction(CameraWrap.CopyFrom)),
      new LuaMethod("AddCommandBuffer", new LuaCSFunction(CameraWrap.AddCommandBuffer)),
      new LuaMethod("RemoveCommandBuffer", new LuaCSFunction(CameraWrap.RemoveCommandBuffer)),
      new LuaMethod("RemoveCommandBuffers", new LuaCSFunction(CameraWrap.RemoveCommandBuffers)),
      new LuaMethod("RemoveAllCommandBuffers", new LuaCSFunction(CameraWrap.RemoveAllCommandBuffers)),
      new LuaMethod("GetCommandBuffers", new LuaCSFunction(CameraWrap.GetCommandBuffers)),
      new LuaMethod("CalculateObliqueMatrix", new LuaCSFunction(CameraWrap.CalculateObliqueMatrix)),
      new LuaMethod("New", new LuaCSFunction(CameraWrap._CreateCamera)),
      new LuaMethod("GetClassType", new LuaCSFunction(CameraWrap.GetClassType)),
      new LuaMethod("__eq", new LuaCSFunction(CameraWrap.Lua_Eq))
    };
    LuaField[] fields = new LuaField[44]
    {
      new LuaField("onPreCull", new LuaCSFunction(CameraWrap.get_onPreCull), new LuaCSFunction(CameraWrap.set_onPreCull)),
      new LuaField("onPreRender", new LuaCSFunction(CameraWrap.get_onPreRender), new LuaCSFunction(CameraWrap.set_onPreRender)),
      new LuaField("onPostRender", new LuaCSFunction(CameraWrap.get_onPostRender), new LuaCSFunction(CameraWrap.set_onPostRender)),
      new LuaField("fieldOfView", new LuaCSFunction(CameraWrap.get_fieldOfView), new LuaCSFunction(CameraWrap.set_fieldOfView)),
      new LuaField("nearClipPlane", new LuaCSFunction(CameraWrap.get_nearClipPlane), new LuaCSFunction(CameraWrap.set_nearClipPlane)),
      new LuaField("farClipPlane", new LuaCSFunction(CameraWrap.get_farClipPlane), new LuaCSFunction(CameraWrap.set_farClipPlane)),
      new LuaField("renderingPath", new LuaCSFunction(CameraWrap.get_renderingPath), new LuaCSFunction(CameraWrap.set_renderingPath)),
      new LuaField("actualRenderingPath", new LuaCSFunction(CameraWrap.get_actualRenderingPath), (LuaCSFunction) null),
      new LuaField("hdr", new LuaCSFunction(CameraWrap.get_hdr), new LuaCSFunction(CameraWrap.set_hdr)),
      new LuaField("orthographicSize", new LuaCSFunction(CameraWrap.get_orthographicSize), new LuaCSFunction(CameraWrap.set_orthographicSize)),
      new LuaField("orthographic", new LuaCSFunction(CameraWrap.get_orthographic), new LuaCSFunction(CameraWrap.set_orthographic)),
      new LuaField("opaqueSortMode", new LuaCSFunction(CameraWrap.get_opaqueSortMode), new LuaCSFunction(CameraWrap.set_opaqueSortMode)),
      new LuaField("transparencySortMode", new LuaCSFunction(CameraWrap.get_transparencySortMode), new LuaCSFunction(CameraWrap.set_transparencySortMode)),
      new LuaField("depth", new LuaCSFunction(CameraWrap.get_depth), new LuaCSFunction(CameraWrap.set_depth)),
      new LuaField("aspect", new LuaCSFunction(CameraWrap.get_aspect), new LuaCSFunction(CameraWrap.set_aspect)),
      new LuaField("cullingMask", new LuaCSFunction(CameraWrap.get_cullingMask), new LuaCSFunction(CameraWrap.set_cullingMask)),
      new LuaField("eventMask", new LuaCSFunction(CameraWrap.get_eventMask), new LuaCSFunction(CameraWrap.set_eventMask)),
      new LuaField("backgroundColor", new LuaCSFunction(CameraWrap.get_backgroundColor), new LuaCSFunction(CameraWrap.set_backgroundColor)),
      new LuaField("rect", new LuaCSFunction(CameraWrap.get_rect), new LuaCSFunction(CameraWrap.set_rect)),
      new LuaField("pixelRect", new LuaCSFunction(CameraWrap.get_pixelRect), new LuaCSFunction(CameraWrap.set_pixelRect)),
      new LuaField("targetTexture", new LuaCSFunction(CameraWrap.get_targetTexture), new LuaCSFunction(CameraWrap.set_targetTexture)),
      new LuaField("pixelWidth", new LuaCSFunction(CameraWrap.get_pixelWidth), (LuaCSFunction) null),
      new LuaField("pixelHeight", new LuaCSFunction(CameraWrap.get_pixelHeight), (LuaCSFunction) null),
      new LuaField("cameraToWorldMatrix", new LuaCSFunction(CameraWrap.get_cameraToWorldMatrix), (LuaCSFunction) null),
      new LuaField("worldToCameraMatrix", new LuaCSFunction(CameraWrap.get_worldToCameraMatrix), new LuaCSFunction(CameraWrap.set_worldToCameraMatrix)),
      new LuaField("projectionMatrix", new LuaCSFunction(CameraWrap.get_projectionMatrix), new LuaCSFunction(CameraWrap.set_projectionMatrix)),
      new LuaField("velocity", new LuaCSFunction(CameraWrap.get_velocity), (LuaCSFunction) null),
      new LuaField("clearFlags", new LuaCSFunction(CameraWrap.get_clearFlags), new LuaCSFunction(CameraWrap.set_clearFlags)),
      new LuaField("stereoEnabled", new LuaCSFunction(CameraWrap.get_stereoEnabled), (LuaCSFunction) null),
      new LuaField("stereoSeparation", new LuaCSFunction(CameraWrap.get_stereoSeparation), new LuaCSFunction(CameraWrap.set_stereoSeparation)),
      new LuaField("stereoConvergence", new LuaCSFunction(CameraWrap.get_stereoConvergence), new LuaCSFunction(CameraWrap.set_stereoConvergence)),
      new LuaField("cameraType", new LuaCSFunction(CameraWrap.get_cameraType), new LuaCSFunction(CameraWrap.set_cameraType)),
      new LuaField("stereoMirrorMode", new LuaCSFunction(CameraWrap.get_stereoMirrorMode), new LuaCSFunction(CameraWrap.set_stereoMirrorMode)),
      new LuaField("targetDisplay", new LuaCSFunction(CameraWrap.get_targetDisplay), new LuaCSFunction(CameraWrap.set_targetDisplay)),
      new LuaField("main", new LuaCSFunction(CameraWrap.get_main), (LuaCSFunction) null),
      new LuaField("current", new LuaCSFunction(CameraWrap.get_current), (LuaCSFunction) null),
      new LuaField("allCameras", new LuaCSFunction(CameraWrap.get_allCameras), (LuaCSFunction) null),
      new LuaField("allCamerasCount", new LuaCSFunction(CameraWrap.get_allCamerasCount), (LuaCSFunction) null),
      new LuaField("useOcclusionCulling", new LuaCSFunction(CameraWrap.get_useOcclusionCulling), new LuaCSFunction(CameraWrap.set_useOcclusionCulling)),
      new LuaField("layerCullDistances", new LuaCSFunction(CameraWrap.get_layerCullDistances), new LuaCSFunction(CameraWrap.set_layerCullDistances)),
      new LuaField("layerCullSpherical", new LuaCSFunction(CameraWrap.get_layerCullSpherical), new LuaCSFunction(CameraWrap.set_layerCullSpherical)),
      new LuaField("depthTextureMode", new LuaCSFunction(CameraWrap.get_depthTextureMode), new LuaCSFunction(CameraWrap.set_depthTextureMode)),
      new LuaField("clearStencilAfterLightingPass", new LuaCSFunction(CameraWrap.get_clearStencilAfterLightingPass), new LuaCSFunction(CameraWrap.set_clearStencilAfterLightingPass)),
      new LuaField("commandBufferCount", new LuaCSFunction(CameraWrap.get_commandBufferCount), (LuaCSFunction) null)
    };
    LuaScriptMgr.RegisterLib(L, "UnityEngine.Camera", typeof (Camera), regs, fields, typeof (Behaviour));
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int _CreateCamera(IntPtr L)
  {
    if (LuaDLL.lua_gettop(L) == 0)
    {
      Camera camera = new Camera();
      LuaScriptMgr.Push(L, (Object) camera);
      return 1;
    }
    LuaDLL.luaL_error(L, "invalid arguments to method: Camera.New");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetClassType(IntPtr L)
  {
    LuaScriptMgr.Push(L, CameraWrap.classType);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_onPreCull(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Delegate) Camera.onPreCull);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_onPreRender(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Delegate) Camera.onPreRender);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_onPostRender(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Delegate) Camera.onPostRender);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_fieldOfView(IntPtr L)
  {
    Camera luaObject = (Camera) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name fieldOfView");
      else
        LuaDLL.luaL_error(L, "attempt to index fieldOfView on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.fieldOfView);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_nearClipPlane(IntPtr L)
  {
    Camera luaObject = (Camera) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name nearClipPlane");
      else
        LuaDLL.luaL_error(L, "attempt to index nearClipPlane on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.nearClipPlane);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_farClipPlane(IntPtr L)
  {
    Camera luaObject = (Camera) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name farClipPlane");
      else
        LuaDLL.luaL_error(L, "attempt to index farClipPlane on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.farClipPlane);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_renderingPath(IntPtr L)
  {
    Camera luaObject = (Camera) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name renderingPath");
      else
        LuaDLL.luaL_error(L, "attempt to index renderingPath on a nil value");
    }
    LuaScriptMgr.Push(L, (Enum) (object) luaObject.renderingPath);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_actualRenderingPath(IntPtr L)
  {
    Camera luaObject = (Camera) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name actualRenderingPath");
      else
        LuaDLL.luaL_error(L, "attempt to index actualRenderingPath on a nil value");
    }
    LuaScriptMgr.Push(L, (Enum) (object) luaObject.actualRenderingPath);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_hdr(IntPtr L)
  {
    Camera luaObject = (Camera) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name hdr");
      else
        LuaDLL.luaL_error(L, "attempt to index hdr on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.hdr);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_orthographicSize(IntPtr L)
  {
    Camera luaObject = (Camera) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name orthographicSize");
      else
        LuaDLL.luaL_error(L, "attempt to index orthographicSize on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.orthographicSize);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_orthographic(IntPtr L)
  {
    Camera luaObject = (Camera) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name orthographic");
      else
        LuaDLL.luaL_error(L, "attempt to index orthographic on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.orthographic);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_opaqueSortMode(IntPtr L)
  {
    Camera luaObject = (Camera) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name opaqueSortMode");
      else
        LuaDLL.luaL_error(L, "attempt to index opaqueSortMode on a nil value");
    }
    LuaScriptMgr.Push(L, (Enum) (object) luaObject.opaqueSortMode);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_transparencySortMode(IntPtr L)
  {
    Camera luaObject = (Camera) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name transparencySortMode");
      else
        LuaDLL.luaL_error(L, "attempt to index transparencySortMode on a nil value");
    }
    LuaScriptMgr.Push(L, (Enum) (object) luaObject.transparencySortMode);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_depth(IntPtr L)
  {
    Camera luaObject = (Camera) LuaScriptMgr.GetLuaObject(L, 1);
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
  private static int get_aspect(IntPtr L)
  {
    Camera luaObject = (Camera) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name aspect");
      else
        LuaDLL.luaL_error(L, "attempt to index aspect on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.aspect);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_cullingMask(IntPtr L)
  {
    Camera luaObject = (Camera) LuaScriptMgr.GetLuaObject(L, 1);
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
  private static int get_eventMask(IntPtr L)
  {
    Camera luaObject = (Camera) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name eventMask");
      else
        LuaDLL.luaL_error(L, "attempt to index eventMask on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.eventMask);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_backgroundColor(IntPtr L)
  {
    Camera luaObject = (Camera) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name backgroundColor");
      else
        LuaDLL.luaL_error(L, "attempt to index backgroundColor on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.backgroundColor);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_rect(IntPtr L)
  {
    Camera luaObject = (Camera) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name rect");
      else
        LuaDLL.luaL_error(L, "attempt to index rect on a nil value");
    }
    LuaScriptMgr.PushValue(L, (object) luaObject.rect);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_pixelRect(IntPtr L)
  {
    Camera luaObject = (Camera) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name pixelRect");
      else
        LuaDLL.luaL_error(L, "attempt to index pixelRect on a nil value");
    }
    LuaScriptMgr.PushValue(L, (object) luaObject.pixelRect);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_targetTexture(IntPtr L)
  {
    Camera luaObject = (Camera) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name targetTexture");
      else
        LuaDLL.luaL_error(L, "attempt to index targetTexture on a nil value");
    }
    LuaScriptMgr.Push(L, (Object) luaObject.targetTexture);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_pixelWidth(IntPtr L)
  {
    Camera luaObject = (Camera) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name pixelWidth");
      else
        LuaDLL.luaL_error(L, "attempt to index pixelWidth on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.pixelWidth);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_pixelHeight(IntPtr L)
  {
    Camera luaObject = (Camera) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name pixelHeight");
      else
        LuaDLL.luaL_error(L, "attempt to index pixelHeight on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.pixelHeight);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_cameraToWorldMatrix(IntPtr L)
  {
    Camera luaObject = (Camera) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name cameraToWorldMatrix");
      else
        LuaDLL.luaL_error(L, "attempt to index cameraToWorldMatrix on a nil value");
    }
    LuaScriptMgr.PushValue(L, (object) luaObject.cameraToWorldMatrix);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_worldToCameraMatrix(IntPtr L)
  {
    Camera luaObject = (Camera) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name worldToCameraMatrix");
      else
        LuaDLL.luaL_error(L, "attempt to index worldToCameraMatrix on a nil value");
    }
    LuaScriptMgr.PushValue(L, (object) luaObject.worldToCameraMatrix);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_projectionMatrix(IntPtr L)
  {
    Camera luaObject = (Camera) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name projectionMatrix");
      else
        LuaDLL.luaL_error(L, "attempt to index projectionMatrix on a nil value");
    }
    LuaScriptMgr.PushValue(L, (object) luaObject.projectionMatrix);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_velocity(IntPtr L)
  {
    Camera luaObject = (Camera) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name velocity");
      else
        LuaDLL.luaL_error(L, "attempt to index velocity on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.velocity);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_clearFlags(IntPtr L)
  {
    Camera luaObject = (Camera) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name clearFlags");
      else
        LuaDLL.luaL_error(L, "attempt to index clearFlags on a nil value");
    }
    LuaScriptMgr.Push(L, (Enum) (object) luaObject.clearFlags);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_stereoEnabled(IntPtr L)
  {
    Camera luaObject = (Camera) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name stereoEnabled");
      else
        LuaDLL.luaL_error(L, "attempt to index stereoEnabled on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.stereoEnabled);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_stereoSeparation(IntPtr L)
  {
    Camera luaObject = (Camera) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name stereoSeparation");
      else
        LuaDLL.luaL_error(L, "attempt to index stereoSeparation on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.stereoSeparation);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_stereoConvergence(IntPtr L)
  {
    Camera luaObject = (Camera) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name stereoConvergence");
      else
        LuaDLL.luaL_error(L, "attempt to index stereoConvergence on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.stereoConvergence);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_cameraType(IntPtr L)
  {
    Camera luaObject = (Camera) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name cameraType");
      else
        LuaDLL.luaL_error(L, "attempt to index cameraType on a nil value");
    }
    LuaScriptMgr.Push(L, (Enum) (object) luaObject.cameraType);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_stereoMirrorMode(IntPtr L)
  {
    Camera luaObject = (Camera) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name stereoMirrorMode");
      else
        LuaDLL.luaL_error(L, "attempt to index stereoMirrorMode on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.stereoMirrorMode);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_targetDisplay(IntPtr L)
  {
    Camera luaObject = (Camera) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name targetDisplay");
      else
        LuaDLL.luaL_error(L, "attempt to index targetDisplay on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.targetDisplay);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_main(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Object) Camera.main);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_current(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Object) Camera.current);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_allCameras(IntPtr L)
  {
    LuaScriptMgr.PushArray(L, (Array) Camera.allCameras);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_allCamerasCount(IntPtr L)
  {
    LuaScriptMgr.Push(L, Camera.allCamerasCount);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_useOcclusionCulling(IntPtr L)
  {
    Camera luaObject = (Camera) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name useOcclusionCulling");
      else
        LuaDLL.luaL_error(L, "attempt to index useOcclusionCulling on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.useOcclusionCulling);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_layerCullDistances(IntPtr L)
  {
    Camera luaObject = (Camera) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name layerCullDistances");
      else
        LuaDLL.luaL_error(L, "attempt to index layerCullDistances on a nil value");
    }
    LuaScriptMgr.PushArray(L, (Array) luaObject.layerCullDistances);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_layerCullSpherical(IntPtr L)
  {
    Camera luaObject = (Camera) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name layerCullSpherical");
      else
        LuaDLL.luaL_error(L, "attempt to index layerCullSpherical on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.layerCullSpherical);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_depthTextureMode(IntPtr L)
  {
    Camera luaObject = (Camera) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name depthTextureMode");
      else
        LuaDLL.luaL_error(L, "attempt to index depthTextureMode on a nil value");
    }
    LuaScriptMgr.Push(L, (Enum) (object) luaObject.depthTextureMode);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_clearStencilAfterLightingPass(IntPtr L)
  {
    Camera luaObject = (Camera) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name clearStencilAfterLightingPass");
      else
        LuaDLL.luaL_error(L, "attempt to index clearStencilAfterLightingPass on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.clearStencilAfterLightingPass);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_commandBufferCount(IntPtr L)
  {
    Camera luaObject = (Camera) LuaScriptMgr.GetLuaObject(L, 1);
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
  private static int set_onPreCull(IntPtr L)
  {
    if (LuaDLL.lua_type(L, 3) != LuaTypes.LUA_TFUNCTION)
    {
      Camera.onPreCull = (Camera.CameraCallback) LuaScriptMgr.GetNetObject(L, 3, typeof (Camera.CameraCallback));
    }
    else
    {
      LuaFunction func = LuaScriptMgr.ToLuaFunction(L, 3);
      Camera.onPreCull = (Camera.CameraCallback) (param0 =>
      {
        int oldTop = func.BeginPCall();
        LuaScriptMgr.Push(L, (Object) param0);
        func.PCall(oldTop, 1);
        func.EndPCall(oldTop);
      });
    }
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_onPreRender(IntPtr L)
  {
    if (LuaDLL.lua_type(L, 3) != LuaTypes.LUA_TFUNCTION)
    {
      Camera.onPreRender = (Camera.CameraCallback) LuaScriptMgr.GetNetObject(L, 3, typeof (Camera.CameraCallback));
    }
    else
    {
      LuaFunction func = LuaScriptMgr.ToLuaFunction(L, 3);
      Camera.onPreRender = (Camera.CameraCallback) (param0 =>
      {
        int oldTop = func.BeginPCall();
        LuaScriptMgr.Push(L, (Object) param0);
        func.PCall(oldTop, 1);
        func.EndPCall(oldTop);
      });
    }
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_onPostRender(IntPtr L)
  {
    if (LuaDLL.lua_type(L, 3) != LuaTypes.LUA_TFUNCTION)
    {
      Camera.onPostRender = (Camera.CameraCallback) LuaScriptMgr.GetNetObject(L, 3, typeof (Camera.CameraCallback));
    }
    else
    {
      LuaFunction func = LuaScriptMgr.ToLuaFunction(L, 3);
      Camera.onPostRender = (Camera.CameraCallback) (param0 =>
      {
        int oldTop = func.BeginPCall();
        LuaScriptMgr.Push(L, (Object) param0);
        func.PCall(oldTop, 1);
        func.EndPCall(oldTop);
      });
    }
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_fieldOfView(IntPtr L)
  {
    Camera luaObject = (Camera) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name fieldOfView");
      else
        LuaDLL.luaL_error(L, "attempt to index fieldOfView on a nil value");
    }
    luaObject.fieldOfView = (float) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_nearClipPlane(IntPtr L)
  {
    Camera luaObject = (Camera) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name nearClipPlane");
      else
        LuaDLL.luaL_error(L, "attempt to index nearClipPlane on a nil value");
    }
    luaObject.nearClipPlane = (float) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_farClipPlane(IntPtr L)
  {
    Camera luaObject = (Camera) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name farClipPlane");
      else
        LuaDLL.luaL_error(L, "attempt to index farClipPlane on a nil value");
    }
    luaObject.farClipPlane = (float) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_renderingPath(IntPtr L)
  {
    Camera luaObject = (Camera) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name renderingPath");
      else
        LuaDLL.luaL_error(L, "attempt to index renderingPath on a nil value");
    }
    luaObject.renderingPath = (RenderingPath) (int) LuaScriptMgr.GetNetObject(L, 3, typeof (RenderingPath));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_hdr(IntPtr L)
  {
    Camera luaObject = (Camera) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name hdr");
      else
        LuaDLL.luaL_error(L, "attempt to index hdr on a nil value");
    }
    luaObject.hdr = LuaScriptMgr.GetBoolean(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_orthographicSize(IntPtr L)
  {
    Camera luaObject = (Camera) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name orthographicSize");
      else
        LuaDLL.luaL_error(L, "attempt to index orthographicSize on a nil value");
    }
    luaObject.orthographicSize = (float) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_orthographic(IntPtr L)
  {
    Camera luaObject = (Camera) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name orthographic");
      else
        LuaDLL.luaL_error(L, "attempt to index orthographic on a nil value");
    }
    luaObject.orthographic = LuaScriptMgr.GetBoolean(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_opaqueSortMode(IntPtr L)
  {
    Camera luaObject = (Camera) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name opaqueSortMode");
      else
        LuaDLL.luaL_error(L, "attempt to index opaqueSortMode on a nil value");
    }
    luaObject.opaqueSortMode = (OpaqueSortMode) (int) LuaScriptMgr.GetNetObject(L, 3, typeof (OpaqueSortMode));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_transparencySortMode(IntPtr L)
  {
    Camera luaObject = (Camera) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name transparencySortMode");
      else
        LuaDLL.luaL_error(L, "attempt to index transparencySortMode on a nil value");
    }
    luaObject.transparencySortMode = (TransparencySortMode) (int) LuaScriptMgr.GetNetObject(L, 3, typeof (TransparencySortMode));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_depth(IntPtr L)
  {
    Camera luaObject = (Camera) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name depth");
      else
        LuaDLL.luaL_error(L, "attempt to index depth on a nil value");
    }
    luaObject.depth = (float) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_aspect(IntPtr L)
  {
    Camera luaObject = (Camera) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name aspect");
      else
        LuaDLL.luaL_error(L, "attempt to index aspect on a nil value");
    }
    luaObject.aspect = (float) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_cullingMask(IntPtr L)
  {
    Camera luaObject = (Camera) LuaScriptMgr.GetLuaObject(L, 1);
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
  private static int set_eventMask(IntPtr L)
  {
    Camera luaObject = (Camera) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name eventMask");
      else
        LuaDLL.luaL_error(L, "attempt to index eventMask on a nil value");
    }
    luaObject.eventMask = (int) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_backgroundColor(IntPtr L)
  {
    Camera luaObject = (Camera) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name backgroundColor");
      else
        LuaDLL.luaL_error(L, "attempt to index backgroundColor on a nil value");
    }
    luaObject.backgroundColor = LuaScriptMgr.GetColor(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_rect(IntPtr L)
  {
    Camera luaObject = (Camera) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name rect");
      else
        LuaDLL.luaL_error(L, "attempt to index rect on a nil value");
    }
    luaObject.rect = (Rect) LuaScriptMgr.GetNetObject(L, 3, typeof (Rect));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_pixelRect(IntPtr L)
  {
    Camera luaObject = (Camera) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name pixelRect");
      else
        LuaDLL.luaL_error(L, "attempt to index pixelRect on a nil value");
    }
    luaObject.pixelRect = (Rect) LuaScriptMgr.GetNetObject(L, 3, typeof (Rect));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_targetTexture(IntPtr L)
  {
    Camera luaObject = (Camera) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name targetTexture");
      else
        LuaDLL.luaL_error(L, "attempt to index targetTexture on a nil value");
    }
    luaObject.targetTexture = (RenderTexture) LuaScriptMgr.GetUnityObject(L, 3, typeof (RenderTexture));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_worldToCameraMatrix(IntPtr L)
  {
    Camera luaObject = (Camera) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name worldToCameraMatrix");
      else
        LuaDLL.luaL_error(L, "attempt to index worldToCameraMatrix on a nil value");
    }
    luaObject.worldToCameraMatrix = (Matrix4x4) LuaScriptMgr.GetNetObject(L, 3, typeof (Matrix4x4));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_projectionMatrix(IntPtr L)
  {
    Camera luaObject = (Camera) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name projectionMatrix");
      else
        LuaDLL.luaL_error(L, "attempt to index projectionMatrix on a nil value");
    }
    luaObject.projectionMatrix = (Matrix4x4) LuaScriptMgr.GetNetObject(L, 3, typeof (Matrix4x4));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_clearFlags(IntPtr L)
  {
    Camera luaObject = (Camera) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name clearFlags");
      else
        LuaDLL.luaL_error(L, "attempt to index clearFlags on a nil value");
    }
    luaObject.clearFlags = (CameraClearFlags) (int) LuaScriptMgr.GetNetObject(L, 3, typeof (CameraClearFlags));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_stereoSeparation(IntPtr L)
  {
    Camera luaObject = (Camera) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name stereoSeparation");
      else
        LuaDLL.luaL_error(L, "attempt to index stereoSeparation on a nil value");
    }
    luaObject.stereoSeparation = (float) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_stereoConvergence(IntPtr L)
  {
    Camera luaObject = (Camera) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name stereoConvergence");
      else
        LuaDLL.luaL_error(L, "attempt to index stereoConvergence on a nil value");
    }
    luaObject.stereoConvergence = (float) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_cameraType(IntPtr L)
  {
    Camera luaObject = (Camera) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name cameraType");
      else
        LuaDLL.luaL_error(L, "attempt to index cameraType on a nil value");
    }
    luaObject.cameraType = (CameraType) (int) LuaScriptMgr.GetNetObject(L, 3, typeof (CameraType));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_stereoMirrorMode(IntPtr L)
  {
    Camera luaObject = (Camera) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name stereoMirrorMode");
      else
        LuaDLL.luaL_error(L, "attempt to index stereoMirrorMode on a nil value");
    }
    luaObject.stereoMirrorMode = LuaScriptMgr.GetBoolean(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_targetDisplay(IntPtr L)
  {
    Camera luaObject = (Camera) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name targetDisplay");
      else
        LuaDLL.luaL_error(L, "attempt to index targetDisplay on a nil value");
    }
    luaObject.targetDisplay = (int) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_useOcclusionCulling(IntPtr L)
  {
    Camera luaObject = (Camera) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name useOcclusionCulling");
      else
        LuaDLL.luaL_error(L, "attempt to index useOcclusionCulling on a nil value");
    }
    luaObject.useOcclusionCulling = LuaScriptMgr.GetBoolean(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_layerCullDistances(IntPtr L)
  {
    Camera luaObject = (Camera) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name layerCullDistances");
      else
        LuaDLL.luaL_error(L, "attempt to index layerCullDistances on a nil value");
    }
    luaObject.layerCullDistances = LuaScriptMgr.GetArrayNumber<float>(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_layerCullSpherical(IntPtr L)
  {
    Camera luaObject = (Camera) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name layerCullSpherical");
      else
        LuaDLL.luaL_error(L, "attempt to index layerCullSpherical on a nil value");
    }
    luaObject.layerCullSpherical = LuaScriptMgr.GetBoolean(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_depthTextureMode(IntPtr L)
  {
    Camera luaObject = (Camera) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name depthTextureMode");
      else
        LuaDLL.luaL_error(L, "attempt to index depthTextureMode on a nil value");
    }
    luaObject.depthTextureMode = (DepthTextureMode) (int) LuaScriptMgr.GetNetObject(L, 3, typeof (DepthTextureMode));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_clearStencilAfterLightingPass(IntPtr L)
  {
    Camera luaObject = (Camera) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name clearStencilAfterLightingPass");
      else
        LuaDLL.luaL_error(L, "attempt to index clearStencilAfterLightingPass on a nil value");
    }
    luaObject.clearStencilAfterLightingPass = LuaScriptMgr.GetBoolean(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int SetTargetBuffers(IntPtr L)
  {
    int num = LuaDLL.lua_gettop(L);
    if (num == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof (Camera), typeof (RenderBuffer[]), typeof (RenderBuffer)))
    {
      ((Camera) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Camera")).SetTargetBuffers(LuaScriptMgr.GetArrayObject<RenderBuffer>(L, 2), (RenderBuffer) LuaScriptMgr.GetLuaObject(L, 3));
      return 0;
    }
    if (num == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof (Camera), typeof (RenderBuffer), typeof (RenderBuffer)))
    {
      ((Camera) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Camera")).SetTargetBuffers((RenderBuffer) LuaScriptMgr.GetLuaObject(L, 2), (RenderBuffer) LuaScriptMgr.GetLuaObject(L, 3));
      return 0;
    }
    LuaDLL.luaL_error(L, "invalid arguments to method: Camera.SetTargetBuffers");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int ResetWorldToCameraMatrix(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    ((Camera) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Camera")).ResetWorldToCameraMatrix();
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int ResetProjectionMatrix(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    ((Camera) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Camera")).ResetProjectionMatrix();
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int ResetAspect(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    ((Camera) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Camera")).ResetAspect();
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int ResetFieldOfView(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    ((Camera) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Camera")).ResetFieldOfView();
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int SetStereoViewMatrices(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 3);
    ((Camera) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Camera")).SetStereoViewMatrices((Matrix4x4) LuaScriptMgr.GetNetObject(L, 2, typeof (Matrix4x4)), (Matrix4x4) LuaScriptMgr.GetNetObject(L, 3, typeof (Matrix4x4)));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int ResetStereoViewMatrices(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    ((Camera) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Camera")).ResetStereoViewMatrices();
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int SetStereoProjectionMatrices(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 3);
    ((Camera) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Camera")).SetStereoProjectionMatrices((Matrix4x4) LuaScriptMgr.GetNetObject(L, 2, typeof (Matrix4x4)), (Matrix4x4) LuaScriptMgr.GetNetObject(L, 3, typeof (Matrix4x4)));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int ResetStereoProjectionMatrices(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    ((Camera) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Camera")).ResetStereoProjectionMatrices();
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int WorldToScreenPoint(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    Vector3 screenPoint = ((Camera) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Camera")).WorldToScreenPoint(LuaScriptMgr.GetVector3(L, 2));
    LuaScriptMgr.Push(L, screenPoint);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int WorldToViewportPoint(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    Vector3 viewportPoint = ((Camera) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Camera")).WorldToViewportPoint(LuaScriptMgr.GetVector3(L, 2));
    LuaScriptMgr.Push(L, viewportPoint);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int ViewportToWorldPoint(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    Vector3 worldPoint = ((Camera) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Camera")).ViewportToWorldPoint(LuaScriptMgr.GetVector3(L, 2));
    LuaScriptMgr.Push(L, worldPoint);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int ScreenToWorldPoint(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    Vector3 worldPoint = ((Camera) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Camera")).ScreenToWorldPoint(LuaScriptMgr.GetVector3(L, 2));
    LuaScriptMgr.Push(L, worldPoint);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int ScreenToViewportPoint(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    Vector3 viewportPoint = ((Camera) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Camera")).ScreenToViewportPoint(LuaScriptMgr.GetVector3(L, 2));
    LuaScriptMgr.Push(L, viewportPoint);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int ViewportToScreenPoint(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    Vector3 screenPoint = ((Camera) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Camera")).ViewportToScreenPoint(LuaScriptMgr.GetVector3(L, 2));
    LuaScriptMgr.Push(L, screenPoint);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int ViewportPointToRay(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    Ray ray = ((Camera) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Camera")).ViewportPointToRay(LuaScriptMgr.GetVector3(L, 2));
    LuaScriptMgr.Push(L, ray);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int ScreenPointToRay(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    Ray ray = ((Camera) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Camera")).ScreenPointToRay(LuaScriptMgr.GetVector3(L, 2));
    LuaScriptMgr.Push(L, ray);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetAllCameras(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    int allCameras = Camera.GetAllCameras(LuaScriptMgr.GetArrayObject<Camera>(L, 1));
    LuaScriptMgr.Push(L, allCameras);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int Render(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    ((Camera) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Camera")).Render();
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int RenderWithShader(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 3);
    ((Camera) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Camera")).RenderWithShader((Shader) LuaScriptMgr.GetUnityObject(L, 2, typeof (Shader)), LuaScriptMgr.GetLuaString(L, 3));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int SetReplacementShader(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 3);
    ((Camera) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Camera")).SetReplacementShader((Shader) LuaScriptMgr.GetUnityObject(L, 2, typeof (Shader)), LuaScriptMgr.GetLuaString(L, 3));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int ResetReplacementShader(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    ((Camera) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Camera")).ResetReplacementShader();
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int RenderDontRestore(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    ((Camera) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Camera")).RenderDontRestore();
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int SetupCurrent(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    Camera.SetupCurrent((Camera) LuaScriptMgr.GetUnityObject(L, 1, typeof (Camera)));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int RenderToCubemap(IntPtr L)
  {
    int num = LuaDLL.lua_gettop(L);
    if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof (Camera), typeof (RenderTexture)))
    {
      bool cubemap = ((Camera) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Camera")).RenderToCubemap((RenderTexture) LuaScriptMgr.GetLuaObject(L, 2));
      LuaScriptMgr.Push(L, cubemap);
      return 1;
    }
    if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof (Camera), typeof (Cubemap)))
    {
      bool cubemap = ((Camera) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Camera")).RenderToCubemap((Cubemap) LuaScriptMgr.GetLuaObject(L, 2));
      LuaScriptMgr.Push(L, cubemap);
      return 1;
    }
    if (num == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof (Camera), typeof (RenderTexture), typeof (int)))
    {
      bool cubemap = ((Camera) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Camera")).RenderToCubemap((RenderTexture) LuaScriptMgr.GetLuaObject(L, 2), (int) LuaDLL.lua_tonumber(L, 3));
      LuaScriptMgr.Push(L, cubemap);
      return 1;
    }
    if (num == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof (Camera), typeof (Cubemap), typeof (int)))
    {
      bool cubemap = ((Camera) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Camera")).RenderToCubemap((Cubemap) LuaScriptMgr.GetLuaObject(L, 2), (int) LuaDLL.lua_tonumber(L, 3));
      LuaScriptMgr.Push(L, cubemap);
      return 1;
    }
    LuaDLL.luaL_error(L, "invalid arguments to method: Camera.RenderToCubemap");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int CopyFrom(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    ((Camera) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Camera")).CopyFrom((Camera) LuaScriptMgr.GetUnityObject(L, 2, typeof (Camera)));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int AddCommandBuffer(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 3);
    ((Camera) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Camera")).AddCommandBuffer((CameraEvent) (int) LuaScriptMgr.GetNetObject(L, 2, typeof (CameraEvent)), (CommandBuffer) LuaScriptMgr.GetNetObject(L, 3, typeof (CommandBuffer)));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int RemoveCommandBuffer(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 3);
    ((Camera) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Camera")).RemoveCommandBuffer((CameraEvent) (int) LuaScriptMgr.GetNetObject(L, 2, typeof (CameraEvent)), (CommandBuffer) LuaScriptMgr.GetNetObject(L, 3, typeof (CommandBuffer)));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int RemoveCommandBuffers(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    ((Camera) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Camera")).RemoveCommandBuffers((CameraEvent) (int) LuaScriptMgr.GetNetObject(L, 2, typeof (CameraEvent)));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int RemoveAllCommandBuffers(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    ((Camera) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Camera")).RemoveAllCommandBuffers();
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetCommandBuffers(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    CommandBuffer[] commandBuffers = ((Camera) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Camera")).GetCommandBuffers((CameraEvent) (int) LuaScriptMgr.GetNetObject(L, 2, typeof (CameraEvent)));
    LuaScriptMgr.PushArray(L, (Array) commandBuffers);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int CalculateObliqueMatrix(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    Matrix4x4 obliqueMatrix = ((Camera) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Camera")).CalculateObliqueMatrix(LuaScriptMgr.GetVector4(L, 2));
    LuaScriptMgr.PushValue(L, (object) obliqueMatrix);
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
