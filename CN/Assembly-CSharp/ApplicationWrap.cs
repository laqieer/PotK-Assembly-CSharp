// Decompiled with JetBrains decompiler
// Type: ApplicationWrap
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using LuaInterface;
using System;
using UnityEngine;

#nullable disable
public class ApplicationWrap
{
  private static System.Type classType = typeof (Application);

  public static void Register(IntPtr L)
  {
    LuaMethod[] regs = new LuaMethod[13]
    {
      new LuaMethod("Quit", new LuaCSFunction(ApplicationWrap.Quit)),
      new LuaMethod("CancelQuit", new LuaCSFunction(ApplicationWrap.CancelQuit)),
      new LuaMethod("GetStreamProgressForLevel", new LuaCSFunction(ApplicationWrap.GetStreamProgressForLevel)),
      new LuaMethod("CanStreamedLevelBeLoaded", new LuaCSFunction(ApplicationWrap.CanStreamedLevelBeLoaded)),
      new LuaMethod("CaptureScreenshot", new LuaCSFunction(ApplicationWrap.CaptureScreenshot)),
      new LuaMethod("HasProLicense", new LuaCSFunction(ApplicationWrap.HasProLicense)),
      new LuaMethod("ExternalCall", new LuaCSFunction(ApplicationWrap.ExternalCall)),
      new LuaMethod("RequestAdvertisingIdentifierAsync", new LuaCSFunction(ApplicationWrap.RequestAdvertisingIdentifierAsync)),
      new LuaMethod("OpenURL", new LuaCSFunction(ApplicationWrap.OpenURL)),
      new LuaMethod("RequestUserAuthorization", new LuaCSFunction(ApplicationWrap.RequestUserAuthorization)),
      new LuaMethod("HasUserAuthorization", new LuaCSFunction(ApplicationWrap.HasUserAuthorization)),
      new LuaMethod("New", new LuaCSFunction(ApplicationWrap._CreateApplication)),
      new LuaMethod("GetClassType", new LuaCSFunction(ApplicationWrap.GetClassType))
    };
    LuaField[] fields = new LuaField[32]
    {
      new LuaField("streamedBytes", new LuaCSFunction(ApplicationWrap.get_streamedBytes), (LuaCSFunction) null),
      new LuaField("isPlaying", new LuaCSFunction(ApplicationWrap.get_isPlaying), (LuaCSFunction) null),
      new LuaField("isEditor", new LuaCSFunction(ApplicationWrap.get_isEditor), (LuaCSFunction) null),
      new LuaField("isWebPlayer", new LuaCSFunction(ApplicationWrap.get_isWebPlayer), (LuaCSFunction) null),
      new LuaField("platform", new LuaCSFunction(ApplicationWrap.get_platform), (LuaCSFunction) null),
      new LuaField("isMobilePlatform", new LuaCSFunction(ApplicationWrap.get_isMobilePlatform), (LuaCSFunction) null),
      new LuaField("isConsolePlatform", new LuaCSFunction(ApplicationWrap.get_isConsolePlatform), (LuaCSFunction) null),
      new LuaField("runInBackground", new LuaCSFunction(ApplicationWrap.get_runInBackground), new LuaCSFunction(ApplicationWrap.set_runInBackground)),
      new LuaField("dataPath", new LuaCSFunction(ApplicationWrap.get_dataPath), (LuaCSFunction) null),
      new LuaField("streamingAssetsPath", new LuaCSFunction(ApplicationWrap.get_streamingAssetsPath), (LuaCSFunction) null),
      new LuaField("persistentDataPath", new LuaCSFunction(ApplicationWrap.get_persistentDataPath), (LuaCSFunction) null),
      new LuaField("temporaryCachePath", new LuaCSFunction(ApplicationWrap.get_temporaryCachePath), (LuaCSFunction) null),
      new LuaField("srcValue", new LuaCSFunction(ApplicationWrap.get_srcValue), (LuaCSFunction) null),
      new LuaField("absoluteURL", new LuaCSFunction(ApplicationWrap.get_absoluteURL), (LuaCSFunction) null),
      new LuaField("unityVersion", new LuaCSFunction(ApplicationWrap.get_unityVersion), (LuaCSFunction) null),
      new LuaField("version", new LuaCSFunction(ApplicationWrap.get_version), (LuaCSFunction) null),
      new LuaField("bundleIdentifier", new LuaCSFunction(ApplicationWrap.get_bundleIdentifier), (LuaCSFunction) null),
      new LuaField("installMode", new LuaCSFunction(ApplicationWrap.get_installMode), (LuaCSFunction) null),
      new LuaField("sandboxType", new LuaCSFunction(ApplicationWrap.get_sandboxType), (LuaCSFunction) null),
      new LuaField("productName", new LuaCSFunction(ApplicationWrap.get_productName), (LuaCSFunction) null),
      new LuaField("companyName", new LuaCSFunction(ApplicationWrap.get_companyName), (LuaCSFunction) null),
      new LuaField("cloudProjectId", new LuaCSFunction(ApplicationWrap.get_cloudProjectId), (LuaCSFunction) null),
      new LuaField("webSecurityEnabled", new LuaCSFunction(ApplicationWrap.get_webSecurityEnabled), (LuaCSFunction) null),
      new LuaField("webSecurityHostUrl", new LuaCSFunction(ApplicationWrap.get_webSecurityHostUrl), (LuaCSFunction) null),
      new LuaField("targetFrameRate", new LuaCSFunction(ApplicationWrap.get_targetFrameRate), new LuaCSFunction(ApplicationWrap.set_targetFrameRate)),
      new LuaField("systemLanguage", new LuaCSFunction(ApplicationWrap.get_systemLanguage), (LuaCSFunction) null),
      new LuaField("stackTraceLogType", new LuaCSFunction(ApplicationWrap.get_stackTraceLogType), new LuaCSFunction(ApplicationWrap.set_stackTraceLogType)),
      new LuaField("backgroundLoadingPriority", new LuaCSFunction(ApplicationWrap.get_backgroundLoadingPriority), new LuaCSFunction(ApplicationWrap.set_backgroundLoadingPriority)),
      new LuaField("internetReachability", new LuaCSFunction(ApplicationWrap.get_internetReachability), (LuaCSFunction) null),
      new LuaField("genuine", new LuaCSFunction(ApplicationWrap.get_genuine), (LuaCSFunction) null),
      new LuaField("genuineCheckAvailable", new LuaCSFunction(ApplicationWrap.get_genuineCheckAvailable), (LuaCSFunction) null),
      new LuaField("isShowingSplashScreen", new LuaCSFunction(ApplicationWrap.get_isShowingSplashScreen), (LuaCSFunction) null)
    };
    LuaScriptMgr.RegisterLib(L, "UnityEngine.Application", typeof (Application), regs, fields, typeof (object));
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int _CreateApplication(IntPtr L)
  {
    if (LuaDLL.lua_gettop(L) == 0)
    {
      Application o = new Application();
      LuaScriptMgr.PushObject(L, (object) o);
      return 1;
    }
    LuaDLL.luaL_error(L, "invalid arguments to method: Application.New");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetClassType(IntPtr L)
  {
    LuaScriptMgr.Push(L, ApplicationWrap.classType);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_streamedBytes(IntPtr L)
  {
    LuaScriptMgr.Push(L, Application.streamedBytes);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_isPlaying(IntPtr L)
  {
    LuaScriptMgr.Push(L, Application.isPlaying);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_isEditor(IntPtr L)
  {
    LuaScriptMgr.Push(L, Application.isEditor);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_isWebPlayer(IntPtr L)
  {
    LuaScriptMgr.Push(L, Application.isWebPlayer);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_platform(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) Application.platform);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_isMobilePlatform(IntPtr L)
  {
    LuaScriptMgr.Push(L, Application.isMobilePlatform);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_isConsolePlatform(IntPtr L)
  {
    LuaScriptMgr.Push(L, Application.isConsolePlatform);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_runInBackground(IntPtr L)
  {
    LuaScriptMgr.Push(L, Application.runInBackground);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_dataPath(IntPtr L)
  {
    LuaScriptMgr.Push(L, Application.dataPath);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_streamingAssetsPath(IntPtr L)
  {
    LuaScriptMgr.Push(L, Application.streamingAssetsPath);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_persistentDataPath(IntPtr L)
  {
    LuaScriptMgr.Push(L, Application.persistentDataPath);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_temporaryCachePath(IntPtr L)
  {
    LuaScriptMgr.Push(L, Application.temporaryCachePath);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_srcValue(IntPtr L)
  {
    LuaScriptMgr.Push(L, Application.srcValue);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_absoluteURL(IntPtr L)
  {
    LuaScriptMgr.Push(L, Application.absoluteURL);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_unityVersion(IntPtr L)
  {
    LuaScriptMgr.Push(L, Application.unityVersion);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_version(IntPtr L)
  {
    LuaScriptMgr.Push(L, Application.version);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_bundleIdentifier(IntPtr L)
  {
    LuaScriptMgr.Push(L, Application.bundleIdentifier);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_installMode(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) Application.installMode);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_sandboxType(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) Application.sandboxType);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_productName(IntPtr L)
  {
    LuaScriptMgr.Push(L, Application.productName);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_companyName(IntPtr L)
  {
    LuaScriptMgr.Push(L, Application.companyName);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_cloudProjectId(IntPtr L)
  {
    LuaScriptMgr.Push(L, Application.cloudProjectId);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_webSecurityEnabled(IntPtr L)
  {
    LuaScriptMgr.Push(L, Application.webSecurityEnabled);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_webSecurityHostUrl(IntPtr L)
  {
    LuaScriptMgr.Push(L, Application.webSecurityHostUrl);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_targetFrameRate(IntPtr L)
  {
    LuaScriptMgr.Push(L, Application.targetFrameRate);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_systemLanguage(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) Application.systemLanguage);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_stackTraceLogType(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) Application.stackTraceLogType);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_backgroundLoadingPriority(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) Application.backgroundLoadingPriority);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_internetReachability(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) Application.internetReachability);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_genuine(IntPtr L)
  {
    LuaScriptMgr.Push(L, Application.genuine);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_genuineCheckAvailable(IntPtr L)
  {
    LuaScriptMgr.Push(L, Application.genuineCheckAvailable);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_isShowingSplashScreen(IntPtr L)
  {
    LuaScriptMgr.Push(L, Application.isShowingSplashScreen);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_runInBackground(IntPtr L)
  {
    Application.runInBackground = LuaScriptMgr.GetBoolean(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_targetFrameRate(IntPtr L)
  {
    Application.targetFrameRate = (int) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_stackTraceLogType(IntPtr L)
  {
    Application.stackTraceLogType = (StackTraceLogType) (int) LuaScriptMgr.GetNetObject(L, 3, typeof (StackTraceLogType));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_backgroundLoadingPriority(IntPtr L)
  {
    Application.backgroundLoadingPriority = (ThreadPriority) (int) LuaScriptMgr.GetNetObject(L, 3, typeof (ThreadPriority));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int Quit(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 0);
    Application.Quit();
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int CancelQuit(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 0);
    Application.CancelQuit();
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetStreamProgressForLevel(IntPtr L)
  {
    int num = LuaDLL.lua_gettop(L);
    if (num == 1 && LuaScriptMgr.CheckTypes(L, 1, typeof (string)))
    {
      float progressForLevel = Application.GetStreamProgressForLevel(LuaScriptMgr.GetString(L, 1));
      LuaScriptMgr.Push(L, progressForLevel);
      return 1;
    }
    if (num == 1 && LuaScriptMgr.CheckTypes(L, 1, typeof (int)))
    {
      float progressForLevel = Application.GetStreamProgressForLevel((int) LuaDLL.lua_tonumber(L, 1));
      LuaScriptMgr.Push(L, progressForLevel);
      return 1;
    }
    LuaDLL.luaL_error(L, "invalid arguments to method: Application.GetStreamProgressForLevel");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int CanStreamedLevelBeLoaded(IntPtr L)
  {
    int num = LuaDLL.lua_gettop(L);
    if (num == 1 && LuaScriptMgr.CheckTypes(L, 1, typeof (string)))
    {
      bool b = Application.CanStreamedLevelBeLoaded(LuaScriptMgr.GetString(L, 1));
      LuaScriptMgr.Push(L, b);
      return 1;
    }
    if (num == 1 && LuaScriptMgr.CheckTypes(L, 1, typeof (int)))
    {
      bool b = Application.CanStreamedLevelBeLoaded((int) LuaDLL.lua_tonumber(L, 1));
      LuaScriptMgr.Push(L, b);
      return 1;
    }
    LuaDLL.luaL_error(L, "invalid arguments to method: Application.CanStreamedLevelBeLoaded");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int CaptureScreenshot(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 1:
        Application.CaptureScreenshot(LuaScriptMgr.GetLuaString(L, 1));
        return 0;
      case 2:
        Application.CaptureScreenshot(LuaScriptMgr.GetLuaString(L, 1), (int) LuaScriptMgr.GetNumber(L, 2));
        return 0;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: Application.CaptureScreenshot");
        return 0;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int HasProLicense(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 0);
    bool b = Application.HasProLicense();
    LuaScriptMgr.Push(L, b);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int ExternalCall(IntPtr L)
  {
    int num = LuaDLL.lua_gettop(L);
    Application.ExternalCall(LuaScriptMgr.GetLuaString(L, 1), LuaScriptMgr.GetParamsObject(L, 2, num - 1));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int RequestAdvertisingIdentifierAsync(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    Application.AdvertisingIdentifierCallback identifierCallback;
    if (LuaDLL.lua_type(L, 1) != LuaTypes.LUA_TFUNCTION)
    {
      identifierCallback = (Application.AdvertisingIdentifierCallback) LuaScriptMgr.GetNetObject(L, 1, typeof (Application.AdvertisingIdentifierCallback));
    }
    else
    {
      LuaFunction func = LuaScriptMgr.GetLuaFunction(L, 1);
      identifierCallback = (Application.AdvertisingIdentifierCallback) ((param0, param1, param2) =>
      {
        int oldTop = func.BeginPCall();
        LuaScriptMgr.Push(L, param0);
        LuaScriptMgr.Push(L, param1);
        LuaScriptMgr.Push(L, param2);
        func.PCall(oldTop, 3);
        func.EndPCall(oldTop);
      });
    }
    bool b = Application.RequestAdvertisingIdentifierAsync(identifierCallback);
    LuaScriptMgr.Push(L, b);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int OpenURL(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    Application.OpenURL(LuaScriptMgr.GetLuaString(L, 1));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int RequestUserAuthorization(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    AsyncOperation o = Application.RequestUserAuthorization((UserAuthorization) (int) LuaScriptMgr.GetNetObject(L, 1, typeof (UserAuthorization)));
    LuaScriptMgr.PushObject(L, (object) o);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int HasUserAuthorization(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    bool b = Application.HasUserAuthorization((UserAuthorization) (int) LuaScriptMgr.GetNetObject(L, 1, typeof (UserAuthorization)));
    LuaScriptMgr.Push(L, b);
    return 1;
  }
}
