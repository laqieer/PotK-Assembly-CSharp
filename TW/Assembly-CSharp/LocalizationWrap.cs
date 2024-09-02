// Decompiled with JetBrains decompiler
// Type: LocalizationWrap
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using LuaInterface;
using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class LocalizationWrap
{
  private static System.Type classType = typeof (Localization);

  public static void Register(IntPtr L)
  {
    LuaMethod[] regs = new LuaMethod[8]
    {
      new LuaMethod("Load", new LuaCSFunction(LocalizationWrap.Load)),
      new LuaMethod("LoadCSV", new LuaCSFunction(LocalizationWrap.LoadCSV)),
      new LuaMethod("Set", new LuaCSFunction(LocalizationWrap.Set)),
      new LuaMethod("Get", new LuaCSFunction(LocalizationWrap.Get)),
      new LuaMethod("Exists", new LuaCSFunction(LocalizationWrap.Exists)),
      new LuaMethod("New", new LuaCSFunction(LocalizationWrap._CreateLocalization)),
      new LuaMethod("GetClassType", new LuaCSFunction(LocalizationWrap.GetClassType)),
      new LuaMethod("__eq", new LuaCSFunction(LocalizationWrap.Lua_Eq))
    };
    LuaField[] fields = new LuaField[8]
    {
      new LuaField("knownLanguages", new LuaCSFunction(LocalizationWrap.get_knownLanguages), new LuaCSFunction(LocalizationWrap.set_knownLanguages)),
      new LuaField("localizationHasBeenSet", new LuaCSFunction(LocalizationWrap.get_localizationHasBeenSet), new LuaCSFunction(LocalizationWrap.set_localizationHasBeenSet)),
      new LuaField("startingLanguage", new LuaCSFunction(LocalizationWrap.get_startingLanguage), new LuaCSFunction(LocalizationWrap.set_startingLanguage)),
      new LuaField("languages", new LuaCSFunction(LocalizationWrap.get_languages), new LuaCSFunction(LocalizationWrap.set_languages)),
      new LuaField("dictionary", new LuaCSFunction(LocalizationWrap.get_dictionary), (LuaCSFunction) null),
      new LuaField("isActive", new LuaCSFunction(LocalizationWrap.get_isActive), (LuaCSFunction) null),
      new LuaField("instance", new LuaCSFunction(LocalizationWrap.get_instance), (LuaCSFunction) null),
      new LuaField("language", new LuaCSFunction(LocalizationWrap.get_language), new LuaCSFunction(LocalizationWrap.set_language))
    };
    LuaScriptMgr.RegisterLib(L, "Localization", typeof (Localization), regs, fields, typeof (MonoBehaviour));
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int _CreateLocalization(IntPtr L)
  {
    LuaDLL.luaL_error(L, "Localization class does not have a constructor function");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetClassType(IntPtr L)
  {
    LuaScriptMgr.Push(L, LocalizationWrap.classType);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_knownLanguages(IntPtr L)
  {
    LuaScriptMgr.PushArray(L, (Array) Localization.knownLanguages);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_localizationHasBeenSet(IntPtr L)
  {
    LuaScriptMgr.Push(L, Localization.localizationHasBeenSet);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_startingLanguage(IntPtr L)
  {
    Localization luaObject = (Localization) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name startingLanguage");
      else
        LuaDLL.luaL_error(L, "attempt to index startingLanguage on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.startingLanguage);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_languages(IntPtr L)
  {
    Localization luaObject = (Localization) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name languages");
      else
        LuaDLL.luaL_error(L, "attempt to index languages on a nil value");
    }
    LuaScriptMgr.PushArray(L, (Array) luaObject.languages);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_dictionary(IntPtr L)
  {
    LuaScriptMgr.PushObject(L, (object) Localization.dictionary);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_isActive(IntPtr L)
  {
    LuaScriptMgr.Push(L, Localization.isActive);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_instance(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Object) Localization.instance);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_language(IntPtr L)
  {
    LuaScriptMgr.Push(L, Localization.language);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_knownLanguages(IntPtr L)
  {
    Localization.knownLanguages = LuaScriptMgr.GetArrayString(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_localizationHasBeenSet(IntPtr L)
  {
    Localization.localizationHasBeenSet = LuaScriptMgr.GetBoolean(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_startingLanguage(IntPtr L)
  {
    Localization luaObject = (Localization) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name startingLanguage");
      else
        LuaDLL.luaL_error(L, "attempt to index startingLanguage on a nil value");
    }
    luaObject.startingLanguage = LuaScriptMgr.GetString(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_languages(IntPtr L)
  {
    Localization luaObject = (Localization) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name languages");
      else
        LuaDLL.luaL_error(L, "attempt to index languages on a nil value");
    }
    luaObject.languages = LuaScriptMgr.GetArrayObject<TextAsset>(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_language(IntPtr L)
  {
    Localization.language = LuaScriptMgr.GetString(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int Load(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    Localization.Load((TextAsset) LuaScriptMgr.GetUnityObject(L, 1, typeof (TextAsset)));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int LoadCSV(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    bool b = Localization.LoadCSV((TextAsset) LuaScriptMgr.GetUnityObject(L, 1, typeof (TextAsset)));
    LuaScriptMgr.Push(L, b);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int Set(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    Localization.Set(LuaScriptMgr.GetLuaString(L, 1), (Dictionary<string, string>) LuaScriptMgr.GetNetObject(L, 2, typeof (Dictionary<string, string>)));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int Get(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    string str = Localization.Get(LuaScriptMgr.GetLuaString(L, 1));
    LuaScriptMgr.Push(L, str);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int Exists(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    bool b = Localization.Exists(LuaScriptMgr.GetLuaString(L, 1));
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
