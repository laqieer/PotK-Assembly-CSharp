// Decompiled with JetBrains decompiler
// Type: AssetBundleWrap
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using LuaInterface;
using System;
using UnityEngine;

#nullable disable
public class AssetBundleWrap
{
  private static System.Type classType = typeof (AssetBundle);

  public static void Register(IntPtr L)
  {
    LuaMethod[] regs = new LuaMethod[17]
    {
      new LuaMethod("LoadFromFileAsync", new LuaCSFunction(AssetBundleWrap.LoadFromFileAsync)),
      new LuaMethod("LoadFromFile", new LuaCSFunction(AssetBundleWrap.LoadFromFile)),
      new LuaMethod("LoadFromMemoryAsync", new LuaCSFunction(AssetBundleWrap.LoadFromMemoryAsync)),
      new LuaMethod("LoadFromMemory", new LuaCSFunction(AssetBundleWrap.LoadFromMemory)),
      new LuaMethod("Contains", new LuaCSFunction(AssetBundleWrap.Contains)),
      new LuaMethod("LoadAsset", new LuaCSFunction(AssetBundleWrap.LoadAsset)),
      new LuaMethod("LoadAssetAsync", new LuaCSFunction(AssetBundleWrap.LoadAssetAsync)),
      new LuaMethod("LoadAssetWithSubAssets", new LuaCSFunction(AssetBundleWrap.LoadAssetWithSubAssets)),
      new LuaMethod("LoadAssetWithSubAssetsAsync", new LuaCSFunction(AssetBundleWrap.LoadAssetWithSubAssetsAsync)),
      new LuaMethod("LoadAllAssets", new LuaCSFunction(AssetBundleWrap.LoadAllAssets)),
      new LuaMethod("LoadAllAssetsAsync", new LuaCSFunction(AssetBundleWrap.LoadAllAssetsAsync)),
      new LuaMethod("Unload", new LuaCSFunction(AssetBundleWrap.Unload)),
      new LuaMethod("GetAllAssetNames", new LuaCSFunction(AssetBundleWrap.GetAllAssetNames)),
      new LuaMethod("GetAllScenePaths", new LuaCSFunction(AssetBundleWrap.GetAllScenePaths)),
      new LuaMethod("New", new LuaCSFunction(AssetBundleWrap._CreateAssetBundle)),
      new LuaMethod("GetClassType", new LuaCSFunction(AssetBundleWrap.GetClassType)),
      new LuaMethod("__eq", new LuaCSFunction(AssetBundleWrap.Lua_Eq))
    };
    LuaField[] fields = new LuaField[1]
    {
      new LuaField("mainAsset", new LuaCSFunction(AssetBundleWrap.get_mainAsset), (LuaCSFunction) null)
    };
    LuaScriptMgr.RegisterLib(L, "UnityEngine.AssetBundle", typeof (AssetBundle), regs, fields, typeof (Object));
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int _CreateAssetBundle(IntPtr L)
  {
    if (LuaDLL.lua_gettop(L) == 0)
    {
      AssetBundle assetBundle = new AssetBundle();
      LuaScriptMgr.Push(L, (Object) assetBundle);
      return 1;
    }
    LuaDLL.luaL_error(L, "invalid arguments to method: AssetBundle.New");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetClassType(IntPtr L)
  {
    LuaScriptMgr.Push(L, AssetBundleWrap.classType);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_mainAsset(IntPtr L)
  {
    AssetBundle luaObject = (AssetBundle) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name mainAsset");
      else
        LuaDLL.luaL_error(L, "attempt to index mainAsset on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.mainAsset);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int LoadFromFileAsync(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 1:
        AssetBundleCreateRequest o1 = AssetBundle.LoadFromFileAsync(LuaScriptMgr.GetLuaString(L, 1));
        LuaScriptMgr.PushObject(L, (object) o1);
        return 1;
      case 2:
        AssetBundleCreateRequest o2 = AssetBundle.LoadFromFileAsync(LuaScriptMgr.GetLuaString(L, 1), (uint) LuaScriptMgr.GetNumber(L, 2));
        LuaScriptMgr.PushObject(L, (object) o2);
        return 1;
      case 3:
        LuaScriptMgr.GetLuaString(L, 1);
        uint number1 = (uint) LuaScriptMgr.GetNumber(L, 2);
        ulong number2 = (ulong) LuaScriptMgr.GetNumber(L, 3);
        return 1;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: AssetBundle.LoadFromFileAsync");
        return 0;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int LoadFromFile(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 1:
        AssetBundle assetBundle1 = AssetBundle.LoadFromFile(LuaScriptMgr.GetLuaString(L, 1));
        LuaScriptMgr.Push(L, (Object) assetBundle1);
        return 1;
      case 2:
        AssetBundle assetBundle2 = AssetBundle.LoadFromFile(LuaScriptMgr.GetLuaString(L, 1), (uint) LuaScriptMgr.GetNumber(L, 2));
        LuaScriptMgr.Push(L, (Object) assetBundle2);
        return 1;
      case 3:
        LuaScriptMgr.GetLuaString(L, 1);
        uint number1 = (uint) LuaScriptMgr.GetNumber(L, 2);
        ulong number2 = (ulong) LuaScriptMgr.GetNumber(L, 3);
        return 1;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: AssetBundle.LoadFromFile");
        return 0;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int LoadFromMemoryAsync(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 1:
        AssetBundleCreateRequest o1 = AssetBundle.LoadFromMemoryAsync(LuaScriptMgr.GetArrayNumber<byte>(L, 1));
        LuaScriptMgr.PushObject(L, (object) o1);
        return 1;
      case 2:
        AssetBundleCreateRequest o2 = AssetBundle.LoadFromMemoryAsync(LuaScriptMgr.GetArrayNumber<byte>(L, 1), (uint) LuaScriptMgr.GetNumber(L, 2));
        LuaScriptMgr.PushObject(L, (object) o2);
        return 1;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: AssetBundle.LoadFromMemoryAsync");
        return 0;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int LoadFromMemory(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 1:
        AssetBundle assetBundle1 = AssetBundle.LoadFromMemory(LuaScriptMgr.GetArrayNumber<byte>(L, 1));
        LuaScriptMgr.Push(L, (Object) assetBundle1);
        return 1;
      case 2:
        AssetBundle assetBundle2 = AssetBundle.LoadFromMemory(LuaScriptMgr.GetArrayNumber<byte>(L, 1), (uint) LuaScriptMgr.GetNumber(L, 2));
        LuaScriptMgr.Push(L, (Object) assetBundle2);
        return 1;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: AssetBundle.LoadFromMemory");
        return 0;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int Contains(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    bool b = ((AssetBundle) LuaScriptMgr.GetUnityObjectSelf(L, 1, "AssetBundle")).Contains(LuaScriptMgr.GetLuaString(L, 2));
    LuaScriptMgr.Push(L, b);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int LoadAsset(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 2:
        Object object1 = ((AssetBundle) LuaScriptMgr.GetUnityObjectSelf(L, 1, "AssetBundle")).LoadAsset(LuaScriptMgr.GetLuaString(L, 2));
        LuaScriptMgr.Push(L, object1);
        return 1;
      case 3:
        Object object2 = ((AssetBundle) LuaScriptMgr.GetUnityObjectSelf(L, 1, "AssetBundle")).LoadAsset(LuaScriptMgr.GetLuaString(L, 2), LuaScriptMgr.GetTypeObject(L, 3));
        LuaScriptMgr.Push(L, object2);
        return 1;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: AssetBundle.LoadAsset");
        return 0;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int LoadAssetAsync(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 2:
        AssetBundleRequest o1 = ((AssetBundle) LuaScriptMgr.GetUnityObjectSelf(L, 1, "AssetBundle")).LoadAssetAsync(LuaScriptMgr.GetLuaString(L, 2));
        LuaScriptMgr.PushObject(L, (object) o1);
        return 1;
      case 3:
        AssetBundleRequest o2 = ((AssetBundle) LuaScriptMgr.GetUnityObjectSelf(L, 1, "AssetBundle")).LoadAssetAsync(LuaScriptMgr.GetLuaString(L, 2), LuaScriptMgr.GetTypeObject(L, 3));
        LuaScriptMgr.PushObject(L, (object) o2);
        return 1;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: AssetBundle.LoadAssetAsync");
        return 0;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int LoadAssetWithSubAssets(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 2:
        Object[] o1 = ((AssetBundle) LuaScriptMgr.GetUnityObjectSelf(L, 1, "AssetBundle")).LoadAssetWithSubAssets(LuaScriptMgr.GetLuaString(L, 2));
        LuaScriptMgr.PushArray(L, (Array) o1);
        return 1;
      case 3:
        Object[] o2 = ((AssetBundle) LuaScriptMgr.GetUnityObjectSelf(L, 1, "AssetBundle")).LoadAssetWithSubAssets(LuaScriptMgr.GetLuaString(L, 2), LuaScriptMgr.GetTypeObject(L, 3));
        LuaScriptMgr.PushArray(L, (Array) o2);
        return 1;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: AssetBundle.LoadAssetWithSubAssets");
        return 0;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int LoadAssetWithSubAssetsAsync(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 2:
        AssetBundleRequest o1 = ((AssetBundle) LuaScriptMgr.GetUnityObjectSelf(L, 1, "AssetBundle")).LoadAssetWithSubAssetsAsync(LuaScriptMgr.GetLuaString(L, 2));
        LuaScriptMgr.PushObject(L, (object) o1);
        return 1;
      case 3:
        AssetBundleRequest o2 = ((AssetBundle) LuaScriptMgr.GetUnityObjectSelf(L, 1, "AssetBundle")).LoadAssetWithSubAssetsAsync(LuaScriptMgr.GetLuaString(L, 2), LuaScriptMgr.GetTypeObject(L, 3));
        LuaScriptMgr.PushObject(L, (object) o2);
        return 1;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: AssetBundle.LoadAssetWithSubAssetsAsync");
        return 0;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int LoadAllAssets(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 1:
        Object[] o1 = ((AssetBundle) LuaScriptMgr.GetUnityObjectSelf(L, 1, "AssetBundle")).LoadAllAssets();
        LuaScriptMgr.PushArray(L, (Array) o1);
        return 1;
      case 2:
        Object[] o2 = ((AssetBundle) LuaScriptMgr.GetUnityObjectSelf(L, 1, "AssetBundle")).LoadAllAssets(LuaScriptMgr.GetTypeObject(L, 2));
        LuaScriptMgr.PushArray(L, (Array) o2);
        return 1;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: AssetBundle.LoadAllAssets");
        return 0;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int LoadAllAssetsAsync(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 1:
        AssetBundleRequest o1 = ((AssetBundle) LuaScriptMgr.GetUnityObjectSelf(L, 1, "AssetBundle")).LoadAllAssetsAsync();
        LuaScriptMgr.PushObject(L, (object) o1);
        return 1;
      case 2:
        AssetBundleRequest o2 = ((AssetBundle) LuaScriptMgr.GetUnityObjectSelf(L, 1, "AssetBundle")).LoadAllAssetsAsync(LuaScriptMgr.GetTypeObject(L, 2));
        LuaScriptMgr.PushObject(L, (object) o2);
        return 1;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: AssetBundle.LoadAllAssetsAsync");
        return 0;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int Unload(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    ((AssetBundle) LuaScriptMgr.GetUnityObjectSelf(L, 1, "AssetBundle")).Unload(LuaScriptMgr.GetBoolean(L, 2));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetAllAssetNames(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    string[] allAssetNames = ((AssetBundle) LuaScriptMgr.GetUnityObjectSelf(L, 1, "AssetBundle")).GetAllAssetNames();
    LuaScriptMgr.PushArray(L, (Array) allAssetNames);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetAllScenePaths(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    string[] allScenePaths = ((AssetBundle) LuaScriptMgr.GetUnityObjectSelf(L, 1, "AssetBundle")).GetAllScenePaths();
    LuaScriptMgr.PushArray(L, (Array) allScenePaths);
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
