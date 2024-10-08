﻿// Decompiled with JetBrains decompiler
// Type: QualitySettingsWrap
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using LuaInterface;
using System;
using UnityEngine;

#nullable disable
public class QualitySettingsWrap
{
  private static System.Type classType = typeof (QualitySettings);

  public static void Register(IntPtr L)
  {
    LuaMethod[] regs = new LuaMethod[7]
    {
      new LuaMethod("GetQualityLevel", new LuaCSFunction(QualitySettingsWrap.GetQualityLevel)),
      new LuaMethod("SetQualityLevel", new LuaCSFunction(QualitySettingsWrap.SetQualityLevel)),
      new LuaMethod("IncreaseLevel", new LuaCSFunction(QualitySettingsWrap.IncreaseLevel)),
      new LuaMethod("DecreaseLevel", new LuaCSFunction(QualitySettingsWrap.DecreaseLevel)),
      new LuaMethod("New", new LuaCSFunction(QualitySettingsWrap._CreateQualitySettings)),
      new LuaMethod("GetClassType", new LuaCSFunction(QualitySettingsWrap.GetClassType)),
      new LuaMethod("__eq", new LuaCSFunction(QualitySettingsWrap.Lua_Eq))
    };
    LuaField[] fields = new LuaField[24]
    {
      new LuaField("names", new LuaCSFunction(QualitySettingsWrap.get_names), (LuaCSFunction) null),
      new LuaField("pixelLightCount", new LuaCSFunction(QualitySettingsWrap.get_pixelLightCount), new LuaCSFunction(QualitySettingsWrap.set_pixelLightCount)),
      new LuaField("shadowProjection", new LuaCSFunction(QualitySettingsWrap.get_shadowProjection), new LuaCSFunction(QualitySettingsWrap.set_shadowProjection)),
      new LuaField("shadowCascades", new LuaCSFunction(QualitySettingsWrap.get_shadowCascades), new LuaCSFunction(QualitySettingsWrap.set_shadowCascades)),
      new LuaField("shadowDistance", new LuaCSFunction(QualitySettingsWrap.get_shadowDistance), new LuaCSFunction(QualitySettingsWrap.set_shadowDistance)),
      new LuaField("shadowNearPlaneOffset", new LuaCSFunction(QualitySettingsWrap.get_shadowNearPlaneOffset), new LuaCSFunction(QualitySettingsWrap.set_shadowNearPlaneOffset)),
      new LuaField("shadowCascade2Split", new LuaCSFunction(QualitySettingsWrap.get_shadowCascade2Split), new LuaCSFunction(QualitySettingsWrap.set_shadowCascade2Split)),
      new LuaField("shadowCascade4Split", new LuaCSFunction(QualitySettingsWrap.get_shadowCascade4Split), new LuaCSFunction(QualitySettingsWrap.set_shadowCascade4Split)),
      new LuaField("masterTextureLimit", new LuaCSFunction(QualitySettingsWrap.get_masterTextureLimit), new LuaCSFunction(QualitySettingsWrap.set_masterTextureLimit)),
      new LuaField("anisotropicFiltering", new LuaCSFunction(QualitySettingsWrap.get_anisotropicFiltering), new LuaCSFunction(QualitySettingsWrap.set_anisotropicFiltering)),
      new LuaField("lodBias", new LuaCSFunction(QualitySettingsWrap.get_lodBias), new LuaCSFunction(QualitySettingsWrap.set_lodBias)),
      new LuaField("maximumLODLevel", new LuaCSFunction(QualitySettingsWrap.get_maximumLODLevel), new LuaCSFunction(QualitySettingsWrap.set_maximumLODLevel)),
      new LuaField("particleRaycastBudget", new LuaCSFunction(QualitySettingsWrap.get_particleRaycastBudget), new LuaCSFunction(QualitySettingsWrap.set_particleRaycastBudget)),
      new LuaField("softVegetation", new LuaCSFunction(QualitySettingsWrap.get_softVegetation), new LuaCSFunction(QualitySettingsWrap.set_softVegetation)),
      new LuaField("realtimeReflectionProbes", new LuaCSFunction(QualitySettingsWrap.get_realtimeReflectionProbes), new LuaCSFunction(QualitySettingsWrap.set_realtimeReflectionProbes)),
      new LuaField("billboardsFaceCameraPosition", new LuaCSFunction(QualitySettingsWrap.get_billboardsFaceCameraPosition), new LuaCSFunction(QualitySettingsWrap.set_billboardsFaceCameraPosition)),
      new LuaField("maxQueuedFrames", new LuaCSFunction(QualitySettingsWrap.get_maxQueuedFrames), new LuaCSFunction(QualitySettingsWrap.set_maxQueuedFrames)),
      new LuaField("vSyncCount", new LuaCSFunction(QualitySettingsWrap.get_vSyncCount), new LuaCSFunction(QualitySettingsWrap.set_vSyncCount)),
      new LuaField("antiAliasing", new LuaCSFunction(QualitySettingsWrap.get_antiAliasing), new LuaCSFunction(QualitySettingsWrap.set_antiAliasing)),
      new LuaField("desiredColorSpace", new LuaCSFunction(QualitySettingsWrap.get_desiredColorSpace), (LuaCSFunction) null),
      new LuaField("activeColorSpace", new LuaCSFunction(QualitySettingsWrap.get_activeColorSpace), (LuaCSFunction) null),
      new LuaField("blendWeights", new LuaCSFunction(QualitySettingsWrap.get_blendWeights), new LuaCSFunction(QualitySettingsWrap.set_blendWeights)),
      new LuaField("asyncUploadTimeSlice", new LuaCSFunction(QualitySettingsWrap.get_asyncUploadTimeSlice), new LuaCSFunction(QualitySettingsWrap.set_asyncUploadTimeSlice)),
      new LuaField("asyncUploadBufferSize", new LuaCSFunction(QualitySettingsWrap.get_asyncUploadBufferSize), new LuaCSFunction(QualitySettingsWrap.set_asyncUploadBufferSize))
    };
    LuaScriptMgr.RegisterLib(L, "UnityEngine.QualitySettings", typeof (QualitySettings), regs, fields, typeof (Object));
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int _CreateQualitySettings(IntPtr L)
  {
    if (LuaDLL.lua_gettop(L) == 0)
    {
      QualitySettings qualitySettings = new QualitySettings();
      LuaScriptMgr.Push(L, (Object) qualitySettings);
      return 1;
    }
    LuaDLL.luaL_error(L, "invalid arguments to method: QualitySettings.New");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetClassType(IntPtr L)
  {
    LuaScriptMgr.Push(L, QualitySettingsWrap.classType);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_names(IntPtr L)
  {
    LuaScriptMgr.PushArray(L, (Array) QualitySettings.names);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_pixelLightCount(IntPtr L)
  {
    LuaScriptMgr.Push(L, QualitySettings.pixelLightCount);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_shadowProjection(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) QualitySettings.shadowProjection);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_shadowCascades(IntPtr L)
  {
    LuaScriptMgr.Push(L, QualitySettings.shadowCascades);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_shadowDistance(IntPtr L)
  {
    LuaScriptMgr.Push(L, QualitySettings.shadowDistance);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_shadowNearPlaneOffset(IntPtr L)
  {
    LuaScriptMgr.Push(L, QualitySettings.shadowNearPlaneOffset);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_shadowCascade2Split(IntPtr L)
  {
    LuaScriptMgr.Push(L, QualitySettings.shadowCascade2Split);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_shadowCascade4Split(IntPtr L)
  {
    LuaScriptMgr.Push(L, QualitySettings.shadowCascade4Split);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_masterTextureLimit(IntPtr L)
  {
    LuaScriptMgr.Push(L, QualitySettings.masterTextureLimit);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_anisotropicFiltering(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) QualitySettings.anisotropicFiltering);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_lodBias(IntPtr L)
  {
    LuaScriptMgr.Push(L, QualitySettings.lodBias);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_maximumLODLevel(IntPtr L)
  {
    LuaScriptMgr.Push(L, QualitySettings.maximumLODLevel);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_particleRaycastBudget(IntPtr L)
  {
    LuaScriptMgr.Push(L, QualitySettings.particleRaycastBudget);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_softVegetation(IntPtr L)
  {
    LuaScriptMgr.Push(L, QualitySettings.softVegetation);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_realtimeReflectionProbes(IntPtr L)
  {
    LuaScriptMgr.Push(L, QualitySettings.realtimeReflectionProbes);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_billboardsFaceCameraPosition(IntPtr L)
  {
    LuaScriptMgr.Push(L, QualitySettings.billboardsFaceCameraPosition);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_maxQueuedFrames(IntPtr L)
  {
    LuaScriptMgr.Push(L, QualitySettings.maxQueuedFrames);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_vSyncCount(IntPtr L)
  {
    LuaScriptMgr.Push(L, QualitySettings.vSyncCount);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_antiAliasing(IntPtr L)
  {
    LuaScriptMgr.Push(L, QualitySettings.antiAliasing);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_desiredColorSpace(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) QualitySettings.desiredColorSpace);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_activeColorSpace(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) QualitySettings.activeColorSpace);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_blendWeights(IntPtr L)
  {
    LuaScriptMgr.Push(L, (Enum) (object) QualitySettings.blendWeights);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_asyncUploadTimeSlice(IntPtr L)
  {
    LuaScriptMgr.Push(L, QualitySettings.asyncUploadTimeSlice);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_asyncUploadBufferSize(IntPtr L)
  {
    LuaScriptMgr.Push(L, QualitySettings.asyncUploadBufferSize);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_pixelLightCount(IntPtr L)
  {
    QualitySettings.pixelLightCount = (int) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_shadowProjection(IntPtr L)
  {
    QualitySettings.shadowProjection = (ShadowProjection) (int) LuaScriptMgr.GetNetObject(L, 3, typeof (ShadowProjection));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_shadowCascades(IntPtr L)
  {
    QualitySettings.shadowCascades = (int) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_shadowDistance(IntPtr L)
  {
    QualitySettings.shadowDistance = (float) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_shadowNearPlaneOffset(IntPtr L)
  {
    QualitySettings.shadowNearPlaneOffset = (float) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_shadowCascade2Split(IntPtr L)
  {
    QualitySettings.shadowCascade2Split = (float) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_shadowCascade4Split(IntPtr L)
  {
    QualitySettings.shadowCascade4Split = LuaScriptMgr.GetVector3(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_masterTextureLimit(IntPtr L)
  {
    QualitySettings.masterTextureLimit = (int) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_anisotropicFiltering(IntPtr L)
  {
    QualitySettings.anisotropicFiltering = (AnisotropicFiltering) (int) LuaScriptMgr.GetNetObject(L, 3, typeof (AnisotropicFiltering));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_lodBias(IntPtr L)
  {
    QualitySettings.lodBias = (float) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_maximumLODLevel(IntPtr L)
  {
    QualitySettings.maximumLODLevel = (int) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_particleRaycastBudget(IntPtr L)
  {
    QualitySettings.particleRaycastBudget = (int) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_softVegetation(IntPtr L)
  {
    QualitySettings.softVegetation = LuaScriptMgr.GetBoolean(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_realtimeReflectionProbes(IntPtr L)
  {
    QualitySettings.realtimeReflectionProbes = LuaScriptMgr.GetBoolean(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_billboardsFaceCameraPosition(IntPtr L)
  {
    QualitySettings.billboardsFaceCameraPosition = LuaScriptMgr.GetBoolean(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_maxQueuedFrames(IntPtr L)
  {
    QualitySettings.maxQueuedFrames = (int) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_vSyncCount(IntPtr L)
  {
    QualitySettings.vSyncCount = (int) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_antiAliasing(IntPtr L)
  {
    QualitySettings.antiAliasing = (int) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_blendWeights(IntPtr L)
  {
    QualitySettings.blendWeights = (BlendWeights) (int) LuaScriptMgr.GetNetObject(L, 3, typeof (BlendWeights));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_asyncUploadTimeSlice(IntPtr L)
  {
    QualitySettings.asyncUploadTimeSlice = (int) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_asyncUploadBufferSize(IntPtr L)
  {
    QualitySettings.asyncUploadBufferSize = (int) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetQualityLevel(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 0);
    int qualityLevel = QualitySettings.GetQualityLevel();
    LuaScriptMgr.Push(L, qualityLevel);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int SetQualityLevel(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 1:
        QualitySettings.SetQualityLevel((int) LuaScriptMgr.GetNumber(L, 1));
        return 0;
      case 2:
        QualitySettings.SetQualityLevel((int) LuaScriptMgr.GetNumber(L, 1), LuaScriptMgr.GetBoolean(L, 2));
        return 0;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: QualitySettings.SetQualityLevel");
        return 0;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int IncreaseLevel(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 0:
        QualitySettings.IncreaseLevel();
        return 0;
      case 1:
        QualitySettings.IncreaseLevel(LuaScriptMgr.GetBoolean(L, 1));
        return 0;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: QualitySettings.IncreaseLevel");
        return 0;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int DecreaseLevel(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 0:
        QualitySettings.DecreaseLevel();
        return 0;
      case 1:
        QualitySettings.DecreaseLevel(LuaScriptMgr.GetBoolean(L, 1));
        return 0;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: QualitySettings.DecreaseLevel");
        return 0;
    }
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
