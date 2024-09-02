// Decompiled with JetBrains decompiler
// Type: MaterialWrap
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using LuaInterface;
using System;
using UnityEngine;

#nullable disable
public class MaterialWrap
{
  private static System.Type classType = typeof (Material);

  public static void Register(IntPtr L)
  {
    LuaMethod[] regs = new LuaMethod[29]
    {
      new LuaMethod("SetColor", new LuaCSFunction(MaterialWrap.SetColor)),
      new LuaMethod("GetColor", new LuaCSFunction(MaterialWrap.GetColor)),
      new LuaMethod("SetVector", new LuaCSFunction(MaterialWrap.SetVector)),
      new LuaMethod("GetVector", new LuaCSFunction(MaterialWrap.GetVector)),
      new LuaMethod("SetTexture", new LuaCSFunction(MaterialWrap.SetTexture)),
      new LuaMethod("GetTexture", new LuaCSFunction(MaterialWrap.GetTexture)),
      new LuaMethod("SetTextureOffset", new LuaCSFunction(MaterialWrap.SetTextureOffset)),
      new LuaMethod("GetTextureOffset", new LuaCSFunction(MaterialWrap.GetTextureOffset)),
      new LuaMethod("SetTextureScale", new LuaCSFunction(MaterialWrap.SetTextureScale)),
      new LuaMethod("GetTextureScale", new LuaCSFunction(MaterialWrap.GetTextureScale)),
      new LuaMethod("SetMatrix", new LuaCSFunction(MaterialWrap.SetMatrix)),
      new LuaMethod("GetMatrix", new LuaCSFunction(MaterialWrap.GetMatrix)),
      new LuaMethod("SetFloat", new LuaCSFunction(MaterialWrap.SetFloat)),
      new LuaMethod("GetFloat", new LuaCSFunction(MaterialWrap.GetFloat)),
      new LuaMethod("SetInt", new LuaCSFunction(MaterialWrap.SetInt)),
      new LuaMethod("GetInt", new LuaCSFunction(MaterialWrap.GetInt)),
      new LuaMethod("SetBuffer", new LuaCSFunction(MaterialWrap.SetBuffer)),
      new LuaMethod("HasProperty", new LuaCSFunction(MaterialWrap.HasProperty)),
      new LuaMethod("GetTag", new LuaCSFunction(MaterialWrap.GetTag)),
      new LuaMethod("SetOverrideTag", new LuaCSFunction(MaterialWrap.SetOverrideTag)),
      new LuaMethod("Lerp", new LuaCSFunction(MaterialWrap.Lerp)),
      new LuaMethod("SetPass", new LuaCSFunction(MaterialWrap.SetPass)),
      new LuaMethod("CopyPropertiesFromMaterial", new LuaCSFunction(MaterialWrap.CopyPropertiesFromMaterial)),
      new LuaMethod("EnableKeyword", new LuaCSFunction(MaterialWrap.EnableKeyword)),
      new LuaMethod("DisableKeyword", new LuaCSFunction(MaterialWrap.DisableKeyword)),
      new LuaMethod("IsKeywordEnabled", new LuaCSFunction(MaterialWrap.IsKeywordEnabled)),
      new LuaMethod("New", new LuaCSFunction(MaterialWrap._CreateMaterial)),
      new LuaMethod("GetClassType", new LuaCSFunction(MaterialWrap.GetClassType)),
      new LuaMethod("__eq", new LuaCSFunction(MaterialWrap.Lua_Eq))
    };
    LuaField[] fields = new LuaField[9]
    {
      new LuaField("shader", new LuaCSFunction(MaterialWrap.get_shader), new LuaCSFunction(MaterialWrap.set_shader)),
      new LuaField("color", new LuaCSFunction(MaterialWrap.get_color), new LuaCSFunction(MaterialWrap.set_color)),
      new LuaField("mainTexture", new LuaCSFunction(MaterialWrap.get_mainTexture), new LuaCSFunction(MaterialWrap.set_mainTexture)),
      new LuaField("mainTextureOffset", new LuaCSFunction(MaterialWrap.get_mainTextureOffset), new LuaCSFunction(MaterialWrap.set_mainTextureOffset)),
      new LuaField("mainTextureScale", new LuaCSFunction(MaterialWrap.get_mainTextureScale), new LuaCSFunction(MaterialWrap.set_mainTextureScale)),
      new LuaField("passCount", new LuaCSFunction(MaterialWrap.get_passCount), (LuaCSFunction) null),
      new LuaField("renderQueue", new LuaCSFunction(MaterialWrap.get_renderQueue), new LuaCSFunction(MaterialWrap.set_renderQueue)),
      new LuaField("shaderKeywords", new LuaCSFunction(MaterialWrap.get_shaderKeywords), new LuaCSFunction(MaterialWrap.set_shaderKeywords)),
      new LuaField("globalIlluminationFlags", new LuaCSFunction(MaterialWrap.get_globalIlluminationFlags), new LuaCSFunction(MaterialWrap.set_globalIlluminationFlags))
    };
    LuaScriptMgr.RegisterLib(L, "UnityEngine.Material", typeof (Material), regs, fields, typeof (Object));
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int _CreateMaterial(IntPtr L)
  {
    int num = LuaDLL.lua_gettop(L);
    if (num == 1 && LuaScriptMgr.CheckTypes(L, 1, typeof (Material)))
    {
      Material material = new Material((Material) LuaScriptMgr.GetUnityObject(L, 1, typeof (Material)));
      LuaScriptMgr.Push(L, (Object) material);
      return 1;
    }
    if (num == 1 && LuaScriptMgr.CheckTypes(L, 1, typeof (Shader)))
    {
      Material material = new Material((Shader) LuaScriptMgr.GetUnityObject(L, 1, typeof (Shader)));
      LuaScriptMgr.Push(L, (Object) material);
      return 1;
    }
    LuaDLL.luaL_error(L, "invalid arguments to method: Material.New");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetClassType(IntPtr L)
  {
    LuaScriptMgr.Push(L, MaterialWrap.classType);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_shader(IntPtr L)
  {
    Material luaObject = (Material) LuaScriptMgr.GetLuaObject(L, 1);
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
  private static int get_color(IntPtr L)
  {
    Material luaObject = (Material) LuaScriptMgr.GetLuaObject(L, 1);
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
  private static int get_mainTexture(IntPtr L)
  {
    Material luaObject = (Material) LuaScriptMgr.GetLuaObject(L, 1);
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
  private static int get_mainTextureOffset(IntPtr L)
  {
    Material luaObject = (Material) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name mainTextureOffset");
      else
        LuaDLL.luaL_error(L, "attempt to index mainTextureOffset on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.mainTextureOffset);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_mainTextureScale(IntPtr L)
  {
    Material luaObject = (Material) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name mainTextureScale");
      else
        LuaDLL.luaL_error(L, "attempt to index mainTextureScale on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.mainTextureScale);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_passCount(IntPtr L)
  {
    Material luaObject = (Material) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name passCount");
      else
        LuaDLL.luaL_error(L, "attempt to index passCount on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.passCount);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_renderQueue(IntPtr L)
  {
    Material luaObject = (Material) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name renderQueue");
      else
        LuaDLL.luaL_error(L, "attempt to index renderQueue on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.renderQueue);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_shaderKeywords(IntPtr L)
  {
    Material luaObject = (Material) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name shaderKeywords");
      else
        LuaDLL.luaL_error(L, "attempt to index shaderKeywords on a nil value");
    }
    LuaScriptMgr.PushArray(L, (Array) luaObject.shaderKeywords);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_globalIlluminationFlags(IntPtr L)
  {
    Material luaObject = (Material) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name globalIlluminationFlags");
      else
        LuaDLL.luaL_error(L, "attempt to index globalIlluminationFlags on a nil value");
    }
    LuaScriptMgr.Push(L, (Enum) (object) luaObject.globalIlluminationFlags);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_shader(IntPtr L)
  {
    Material luaObject = (Material) LuaScriptMgr.GetLuaObject(L, 1);
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
  private static int set_color(IntPtr L)
  {
    Material luaObject = (Material) LuaScriptMgr.GetLuaObject(L, 1);
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
  private static int set_mainTexture(IntPtr L)
  {
    Material luaObject = (Material) LuaScriptMgr.GetLuaObject(L, 1);
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
  private static int set_mainTextureOffset(IntPtr L)
  {
    Material luaObject = (Material) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name mainTextureOffset");
      else
        LuaDLL.luaL_error(L, "attempt to index mainTextureOffset on a nil value");
    }
    luaObject.mainTextureOffset = LuaScriptMgr.GetVector2(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_mainTextureScale(IntPtr L)
  {
    Material luaObject = (Material) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name mainTextureScale");
      else
        LuaDLL.luaL_error(L, "attempt to index mainTextureScale on a nil value");
    }
    luaObject.mainTextureScale = LuaScriptMgr.GetVector2(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_renderQueue(IntPtr L)
  {
    Material luaObject = (Material) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name renderQueue");
      else
        LuaDLL.luaL_error(L, "attempt to index renderQueue on a nil value");
    }
    luaObject.renderQueue = (int) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_shaderKeywords(IntPtr L)
  {
    Material luaObject = (Material) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name shaderKeywords");
      else
        LuaDLL.luaL_error(L, "attempt to index shaderKeywords on a nil value");
    }
    luaObject.shaderKeywords = LuaScriptMgr.GetArrayString(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_globalIlluminationFlags(IntPtr L)
  {
    Material luaObject = (Material) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name globalIlluminationFlags");
      else
        LuaDLL.luaL_error(L, "attempt to index globalIlluminationFlags on a nil value");
    }
    luaObject.globalIlluminationFlags = (MaterialGlobalIlluminationFlags) (int) LuaScriptMgr.GetNetObject(L, 3, typeof (MaterialGlobalIlluminationFlags));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int SetColor(IntPtr L)
  {
    int num = LuaDLL.lua_gettop(L);
    if (num == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof (Material), typeof (int), typeof (LuaTable)))
    {
      ((Material) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material")).SetColor((int) LuaDLL.lua_tonumber(L, 2), LuaScriptMgr.GetColor(L, 3));
      return 0;
    }
    if (num == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof (Material), typeof (string), typeof (LuaTable)))
    {
      ((Material) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material")).SetColor(LuaScriptMgr.GetString(L, 2), LuaScriptMgr.GetColor(L, 3));
      return 0;
    }
    LuaDLL.luaL_error(L, "invalid arguments to method: Material.SetColor");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetColor(IntPtr L)
  {
    int num = LuaDLL.lua_gettop(L);
    if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof (Material), typeof (int)))
    {
      Color color = ((Material) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material")).GetColor((int) LuaDLL.lua_tonumber(L, 2));
      LuaScriptMgr.Push(L, color);
      return 1;
    }
    if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof (Material), typeof (string)))
    {
      Color color = ((Material) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material")).GetColor(LuaScriptMgr.GetString(L, 2));
      LuaScriptMgr.Push(L, color);
      return 1;
    }
    LuaDLL.luaL_error(L, "invalid arguments to method: Material.GetColor");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int SetVector(IntPtr L)
  {
    int num = LuaDLL.lua_gettop(L);
    if (num == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof (Material), typeof (int), typeof (LuaTable)))
    {
      ((Material) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material")).SetVector((int) LuaDLL.lua_tonumber(L, 2), LuaScriptMgr.GetVector4(L, 3));
      return 0;
    }
    if (num == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof (Material), typeof (string), typeof (LuaTable)))
    {
      ((Material) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material")).SetVector(LuaScriptMgr.GetString(L, 2), LuaScriptMgr.GetVector4(L, 3));
      return 0;
    }
    LuaDLL.luaL_error(L, "invalid arguments to method: Material.SetVector");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetVector(IntPtr L)
  {
    int num = LuaDLL.lua_gettop(L);
    if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof (Material), typeof (int)))
    {
      Vector4 vector = ((Material) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material")).GetVector((int) LuaDLL.lua_tonumber(L, 2));
      LuaScriptMgr.Push(L, vector);
      return 1;
    }
    if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof (Material), typeof (string)))
    {
      Vector4 vector = ((Material) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material")).GetVector(LuaScriptMgr.GetString(L, 2));
      LuaScriptMgr.Push(L, vector);
      return 1;
    }
    LuaDLL.luaL_error(L, "invalid arguments to method: Material.GetVector");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int SetTexture(IntPtr L)
  {
    int num = LuaDLL.lua_gettop(L);
    if (num == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof (Material), typeof (int), typeof (Texture)))
    {
      ((Material) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material")).SetTexture((int) LuaDLL.lua_tonumber(L, 2), (Texture) LuaScriptMgr.GetLuaObject(L, 3));
      return 0;
    }
    if (num == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof (Material), typeof (string), typeof (Texture)))
    {
      ((Material) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material")).SetTexture(LuaScriptMgr.GetString(L, 2), (Texture) LuaScriptMgr.GetLuaObject(L, 3));
      return 0;
    }
    LuaDLL.luaL_error(L, "invalid arguments to method: Material.SetTexture");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetTexture(IntPtr L)
  {
    int num = LuaDLL.lua_gettop(L);
    if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof (Material), typeof (int)))
    {
      Texture texture = ((Material) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material")).GetTexture((int) LuaDLL.lua_tonumber(L, 2));
      LuaScriptMgr.Push(L, (Object) texture);
      return 1;
    }
    if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof (Material), typeof (string)))
    {
      Texture texture = ((Material) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material")).GetTexture(LuaScriptMgr.GetString(L, 2));
      LuaScriptMgr.Push(L, (Object) texture);
      return 1;
    }
    LuaDLL.luaL_error(L, "invalid arguments to method: Material.GetTexture");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int SetTextureOffset(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 3);
    ((Material) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material")).SetTextureOffset(LuaScriptMgr.GetLuaString(L, 2), LuaScriptMgr.GetVector2(L, 3));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetTextureOffset(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    Vector2 textureOffset = ((Material) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material")).GetTextureOffset(LuaScriptMgr.GetLuaString(L, 2));
    LuaScriptMgr.Push(L, textureOffset);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int SetTextureScale(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 3);
    ((Material) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material")).SetTextureScale(LuaScriptMgr.GetLuaString(L, 2), LuaScriptMgr.GetVector2(L, 3));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetTextureScale(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    Vector2 textureScale = ((Material) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material")).GetTextureScale(LuaScriptMgr.GetLuaString(L, 2));
    LuaScriptMgr.Push(L, textureScale);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int SetMatrix(IntPtr L)
  {
    int num = LuaDLL.lua_gettop(L);
    if (num == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof (Material), typeof (int), typeof (Matrix4x4)))
    {
      ((Material) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material")).SetMatrix((int) LuaDLL.lua_tonumber(L, 2), (Matrix4x4) LuaScriptMgr.GetLuaObject(L, 3));
      return 0;
    }
    if (num == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof (Material), typeof (string), typeof (Matrix4x4)))
    {
      ((Material) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material")).SetMatrix(LuaScriptMgr.GetString(L, 2), (Matrix4x4) LuaScriptMgr.GetLuaObject(L, 3));
      return 0;
    }
    LuaDLL.luaL_error(L, "invalid arguments to method: Material.SetMatrix");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetMatrix(IntPtr L)
  {
    int num = LuaDLL.lua_gettop(L);
    if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof (Material), typeof (int)))
    {
      Matrix4x4 matrix = ((Material) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material")).GetMatrix((int) LuaDLL.lua_tonumber(L, 2));
      LuaScriptMgr.PushValue(L, (object) matrix);
      return 1;
    }
    if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof (Material), typeof (string)))
    {
      Matrix4x4 matrix = ((Material) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material")).GetMatrix(LuaScriptMgr.GetString(L, 2));
      LuaScriptMgr.PushValue(L, (object) matrix);
      return 1;
    }
    LuaDLL.luaL_error(L, "invalid arguments to method: Material.GetMatrix");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int SetFloat(IntPtr L)
  {
    int num = LuaDLL.lua_gettop(L);
    if (num == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof (Material), typeof (int), typeof (float)))
    {
      ((Material) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material")).SetFloat((int) LuaDLL.lua_tonumber(L, 2), (float) LuaDLL.lua_tonumber(L, 3));
      return 0;
    }
    if (num == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof (Material), typeof (string), typeof (float)))
    {
      ((Material) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material")).SetFloat(LuaScriptMgr.GetString(L, 2), (float) LuaDLL.lua_tonumber(L, 3));
      return 0;
    }
    LuaDLL.luaL_error(L, "invalid arguments to method: Material.SetFloat");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetFloat(IntPtr L)
  {
    int num = LuaDLL.lua_gettop(L);
    if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof (Material), typeof (int)))
    {
      float d = ((Material) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material")).GetFloat((int) LuaDLL.lua_tonumber(L, 2));
      LuaScriptMgr.Push(L, d);
      return 1;
    }
    if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof (Material), typeof (string)))
    {
      float d = ((Material) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material")).GetFloat(LuaScriptMgr.GetString(L, 2));
      LuaScriptMgr.Push(L, d);
      return 1;
    }
    LuaDLL.luaL_error(L, "invalid arguments to method: Material.GetFloat");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int SetInt(IntPtr L)
  {
    int num = LuaDLL.lua_gettop(L);
    if (num == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof (Material), typeof (int), typeof (int)))
    {
      ((Material) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material")).SetInt((int) LuaDLL.lua_tonumber(L, 2), (int) LuaDLL.lua_tonumber(L, 3));
      return 0;
    }
    if (num == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof (Material), typeof (string), typeof (int)))
    {
      ((Material) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material")).SetInt(LuaScriptMgr.GetString(L, 2), (int) LuaDLL.lua_tonumber(L, 3));
      return 0;
    }
    LuaDLL.luaL_error(L, "invalid arguments to method: Material.SetInt");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetInt(IntPtr L)
  {
    int num = LuaDLL.lua_gettop(L);
    if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof (Material), typeof (int)))
    {
      int d = ((Material) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material")).GetInt((int) LuaDLL.lua_tonumber(L, 2));
      LuaScriptMgr.Push(L, d);
      return 1;
    }
    if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof (Material), typeof (string)))
    {
      int d = ((Material) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material")).GetInt(LuaScriptMgr.GetString(L, 2));
      LuaScriptMgr.Push(L, d);
      return 1;
    }
    LuaDLL.luaL_error(L, "invalid arguments to method: Material.GetInt");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int SetBuffer(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 3);
    ((Material) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material")).SetBuffer(LuaScriptMgr.GetLuaString(L, 2), (ComputeBuffer) LuaScriptMgr.GetNetObject(L, 3, typeof (ComputeBuffer)));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int HasProperty(IntPtr L)
  {
    int num = LuaDLL.lua_gettop(L);
    if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof (Material), typeof (int)))
    {
      bool b = ((Material) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material")).HasProperty((int) LuaDLL.lua_tonumber(L, 2));
      LuaScriptMgr.Push(L, b);
      return 1;
    }
    if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof (Material), typeof (string)))
    {
      bool b = ((Material) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material")).HasProperty(LuaScriptMgr.GetString(L, 2));
      LuaScriptMgr.Push(L, b);
      return 1;
    }
    LuaDLL.luaL_error(L, "invalid arguments to method: Material.HasProperty");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetTag(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 3:
        string tag1 = ((Material) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material")).GetTag(LuaScriptMgr.GetLuaString(L, 2), LuaScriptMgr.GetBoolean(L, 3));
        LuaScriptMgr.Push(L, tag1);
        return 1;
      case 4:
        string tag2 = ((Material) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material")).GetTag(LuaScriptMgr.GetLuaString(L, 2), LuaScriptMgr.GetBoolean(L, 3), LuaScriptMgr.GetLuaString(L, 4));
        LuaScriptMgr.Push(L, tag2);
        return 1;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: Material.GetTag");
        return 0;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int SetOverrideTag(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 3);
    ((Material) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material")).SetOverrideTag(LuaScriptMgr.GetLuaString(L, 2), LuaScriptMgr.GetLuaString(L, 3));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int Lerp(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 4);
    ((Material) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material")).Lerp((Material) LuaScriptMgr.GetUnityObject(L, 2, typeof (Material)), (Material) LuaScriptMgr.GetUnityObject(L, 3, typeof (Material)), (float) LuaScriptMgr.GetNumber(L, 4));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int SetPass(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    bool b = ((Material) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material")).SetPass((int) LuaScriptMgr.GetNumber(L, 2));
    LuaScriptMgr.Push(L, b);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int CopyPropertiesFromMaterial(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    ((Material) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material")).CopyPropertiesFromMaterial((Material) LuaScriptMgr.GetUnityObject(L, 2, typeof (Material)));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int EnableKeyword(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    ((Material) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material")).EnableKeyword(LuaScriptMgr.GetLuaString(L, 2));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int DisableKeyword(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    ((Material) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material")).DisableKeyword(LuaScriptMgr.GetLuaString(L, 2));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int IsKeywordEnabled(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    bool b = ((Material) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Material")).IsKeywordEnabled(LuaScriptMgr.GetLuaString(L, 2));
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
