// Decompiled with JetBrains decompiler
// Type: UITextureWrap
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using LuaInterface;
using System;
using UnityEngine;

#nullable disable
public class UITextureWrap
{
  private static System.Type classType = typeof (UITexture);

  public static void Register(IntPtr L)
  {
    LuaMethod[] regs = new LuaMethod[5]
    {
      new LuaMethod("MakePixelPerfect", new LuaCSFunction(UITextureWrap.MakePixelPerfect)),
      new LuaMethod("OnFill", new LuaCSFunction(UITextureWrap.OnFill)),
      new LuaMethod("New", new LuaCSFunction(UITextureWrap._CreateUITexture)),
      new LuaMethod("GetClassType", new LuaCSFunction(UITextureWrap.GetClassType)),
      new LuaMethod("__eq", new LuaCSFunction(UITextureWrap.Lua_Eq))
    };
    LuaField[] fields = new LuaField[6]
    {
      new LuaField("mainTexture", new LuaCSFunction(UITextureWrap.get_mainTexture), new LuaCSFunction(UITextureWrap.set_mainTexture)),
      new LuaField("material", new LuaCSFunction(UITextureWrap.get_material), new LuaCSFunction(UITextureWrap.set_material)),
      new LuaField("shader", new LuaCSFunction(UITextureWrap.get_shader), new LuaCSFunction(UITextureWrap.set_shader)),
      new LuaField("premultipliedAlpha", new LuaCSFunction(UITextureWrap.get_premultipliedAlpha), (LuaCSFunction) null),
      new LuaField("uvRect", new LuaCSFunction(UITextureWrap.get_uvRect), new LuaCSFunction(UITextureWrap.set_uvRect)),
      new LuaField("drawingDimensions", new LuaCSFunction(UITextureWrap.get_drawingDimensions), (LuaCSFunction) null)
    };
    LuaScriptMgr.RegisterLib(L, "UITexture", typeof (UITexture), regs, fields, typeof (UIWidget));
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int _CreateUITexture(IntPtr L)
  {
    LuaDLL.luaL_error(L, "UITexture class does not have a constructor function");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetClassType(IntPtr L)
  {
    LuaScriptMgr.Push(L, UITextureWrap.classType);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_mainTexture(IntPtr L)
  {
    UITexture luaObject = (UITexture) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name mainTexture");
      else
        LuaDLL.luaL_error(L, "attempt to index mainTexture on a nil value");
    }
    LuaScriptMgr.Push(L, (Object) luaObject.mainTexture);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_material(IntPtr L)
  {
    UITexture luaObject = (UITexture) LuaScriptMgr.GetLuaObject(L, 1);
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
  private static int get_shader(IntPtr L)
  {
    UITexture luaObject = (UITexture) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name shader");
      else
        LuaDLL.luaL_error(L, "attempt to index shader on a nil value");
    }
    LuaScriptMgr.Push(L, (Object) luaObject.shader);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_premultipliedAlpha(IntPtr L)
  {
    UITexture luaObject = (UITexture) LuaScriptMgr.GetLuaObject(L, 1);
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
  private static int get_uvRect(IntPtr L)
  {
    UITexture luaObject = (UITexture) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name uvRect");
      else
        LuaDLL.luaL_error(L, "attempt to index uvRect on a nil value");
    }
    LuaScriptMgr.PushValue(L, (object) luaObject.uvRect);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_drawingDimensions(IntPtr L)
  {
    UITexture luaObject = (UITexture) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name drawingDimensions");
      else
        LuaDLL.luaL_error(L, "attempt to index drawingDimensions on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.drawingDimensions);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_mainTexture(IntPtr L)
  {
    UITexture luaObject = (UITexture) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name mainTexture");
      else
        LuaDLL.luaL_error(L, "attempt to index mainTexture on a nil value");
    }
    luaObject.mainTexture = (Texture) LuaScriptMgr.GetUnityObject(L, 3, typeof (Texture));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_material(IntPtr L)
  {
    UITexture luaObject = (UITexture) LuaScriptMgr.GetLuaObject(L, 1);
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
  private static int set_shader(IntPtr L)
  {
    UITexture luaObject = (UITexture) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name shader");
      else
        LuaDLL.luaL_error(L, "attempt to index shader on a nil value");
    }
    luaObject.shader = (Shader) LuaScriptMgr.GetUnityObject(L, 3, typeof (Shader));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_uvRect(IntPtr L)
  {
    UITexture luaObject = (UITexture) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name uvRect");
      else
        LuaDLL.luaL_error(L, "attempt to index uvRect on a nil value");
    }
    luaObject.uvRect = (Rect) LuaScriptMgr.GetNetObject(L, 3, typeof (Rect));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int MakePixelPerfect(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    ((UITexture) LuaScriptMgr.GetUnityObjectSelf(L, 1, "UITexture")).MakePixelPerfect();
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int OnFill(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 4);
    ((UITexture) LuaScriptMgr.GetUnityObjectSelf(L, 1, "UITexture")).OnFill((BetterList<Vector3>) LuaScriptMgr.GetNetObject(L, 2, typeof (BetterList<Vector3>)), (BetterList<Vector2>) LuaScriptMgr.GetNetObject(L, 3, typeof (BetterList<Vector2>)), (BetterList<Color32>) LuaScriptMgr.GetNetObject(L, 4, typeof (BetterList<Color32>)));
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
