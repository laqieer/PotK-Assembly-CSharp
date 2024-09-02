// Decompiled with JetBrains decompiler
// Type: NGUIToolsWrap
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using LuaInterface;
using System;
using UnityEngine;

#nullable disable
public class NGUIToolsWrap
{
  private static System.Type classType = typeof (NGUITools);

  public static void Register(IntPtr L)
  {
    LuaMethod[] regs = new LuaMethod[42]
    {
      new LuaMethod("PlaySound", new LuaCSFunction(NGUIToolsWrap.PlaySound)),
      new LuaMethod("OpenURL", new LuaCSFunction(NGUIToolsWrap.OpenURL)),
      new LuaMethod("RandomRange", new LuaCSFunction(NGUIToolsWrap.RandomRange)),
      new LuaMethod("GetHierarchy", new LuaCSFunction(NGUIToolsWrap.GetHierarchy)),
      new LuaMethod("FindCameraForLayer", new LuaCSFunction(NGUIToolsWrap.FindCameraForLayer)),
      new LuaMethod("AddWidgetCollider", new LuaCSFunction(NGUIToolsWrap.AddWidgetCollider)),
      new LuaMethod("UpdateWidgetCollider", new LuaCSFunction(NGUIToolsWrap.UpdateWidgetCollider)),
      new LuaMethod("GetTypeName", new LuaCSFunction(NGUIToolsWrap.GetTypeName)),
      new LuaMethod("RegisterUndo", new LuaCSFunction(NGUIToolsWrap.RegisterUndo)),
      new LuaMethod("SetDirty", new LuaCSFunction(NGUIToolsWrap.SetDirty)),
      new LuaMethod("AddChild", new LuaCSFunction(NGUIToolsWrap.AddChild)),
      new LuaMethod("CalculateRaycastDepth", new LuaCSFunction(NGUIToolsWrap.CalculateRaycastDepth)),
      new LuaMethod("CalculateNextDepth", new LuaCSFunction(NGUIToolsWrap.CalculateNextDepth)),
      new LuaMethod("AdjustDepth", new LuaCSFunction(NGUIToolsWrap.AdjustDepth)),
      new LuaMethod("BringForward", new LuaCSFunction(NGUIToolsWrap.BringForward)),
      new LuaMethod("PushBack", new LuaCSFunction(NGUIToolsWrap.PushBack)),
      new LuaMethod("NormalizeDepths", new LuaCSFunction(NGUIToolsWrap.NormalizeDepths)),
      new LuaMethod("NormalizeWidgetDepths", new LuaCSFunction(NGUIToolsWrap.NormalizeWidgetDepths)),
      new LuaMethod("NormalizePanelDepths", new LuaCSFunction(NGUIToolsWrap.NormalizePanelDepths)),
      new LuaMethod("CreateUI", new LuaCSFunction(NGUIToolsWrap.CreateUI)),
      new LuaMethod("SetChildLayer", new LuaCSFunction(NGUIToolsWrap.SetChildLayer)),
      new LuaMethod("AddSprite", new LuaCSFunction(NGUIToolsWrap.AddSprite)),
      new LuaMethod("GetRoot", new LuaCSFunction(NGUIToolsWrap.GetRoot)),
      new LuaMethod("Destroy", new LuaCSFunction(NGUIToolsWrap.Destroy)),
      new LuaMethod("DestroyImmediate", new LuaCSFunction(NGUIToolsWrap.DestroyImmediate)),
      new LuaMethod("Broadcast", new LuaCSFunction(NGUIToolsWrap.Broadcast)),
      new LuaMethod("IsChild", new LuaCSFunction(NGUIToolsWrap.IsChild)),
      new LuaMethod("SetActive", new LuaCSFunction(NGUIToolsWrap.SetActive)),
      new LuaMethod("SetActiveChildren", new LuaCSFunction(NGUIToolsWrap.SetActiveChildren)),
      new LuaMethod("GetActive", new LuaCSFunction(NGUIToolsWrap.GetActive)),
      new LuaMethod("SetActiveSelf", new LuaCSFunction(NGUIToolsWrap.SetActiveSelf)),
      new LuaMethod("SetLayer", new LuaCSFunction(NGUIToolsWrap.SetLayer)),
      new LuaMethod("Round", new LuaCSFunction(NGUIToolsWrap.Round)),
      new LuaMethod("MakePixelPerfect", new LuaCSFunction(NGUIToolsWrap.MakePixelPerfect)),
      new LuaMethod("Save", new LuaCSFunction(NGUIToolsWrap.Save)),
      new LuaMethod("Load", new LuaCSFunction(NGUIToolsWrap.Load)),
      new LuaMethod("ApplyPMA", new LuaCSFunction(NGUIToolsWrap.ApplyPMA)),
      new LuaMethod("MarkParentAsChanged", new LuaCSFunction(NGUIToolsWrap.MarkParentAsChanged)),
      new LuaMethod("GetSides", new LuaCSFunction(NGUIToolsWrap.GetSides)),
      new LuaMethod("GetWorldCorners", new LuaCSFunction(NGUIToolsWrap.GetWorldCorners)),
      new LuaMethod("New", new LuaCSFunction(NGUIToolsWrap._CreateNGUITools)),
      new LuaMethod("GetClassType", new LuaCSFunction(NGUIToolsWrap.GetClassType))
    };
    LuaField[] fields = new LuaField[3]
    {
      new LuaField("soundVolume", new LuaCSFunction(NGUIToolsWrap.get_soundVolume), new LuaCSFunction(NGUIToolsWrap.set_soundVolume)),
      new LuaField("fileAccess", new LuaCSFunction(NGUIToolsWrap.get_fileAccess), (LuaCSFunction) null),
      new LuaField("clipboard", new LuaCSFunction(NGUIToolsWrap.get_clipboard), new LuaCSFunction(NGUIToolsWrap.set_clipboard))
    };
    LuaScriptMgr.RegisterLib(L, "NGUITools", typeof (NGUITools), regs, fields, (System.Type) null);
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int _CreateNGUITools(IntPtr L)
  {
    LuaDLL.luaL_error(L, "NGUITools class does not have a constructor function");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetClassType(IntPtr L)
  {
    LuaScriptMgr.Push(L, NGUIToolsWrap.classType);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_soundVolume(IntPtr L)
  {
    LuaScriptMgr.Push(L, NGUITools.soundVolume);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_fileAccess(IntPtr L)
  {
    LuaScriptMgr.Push(L, NGUITools.fileAccess);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_clipboard(IntPtr L)
  {
    LuaScriptMgr.Push(L, NGUITools.clipboard);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_soundVolume(IntPtr L)
  {
    NGUITools.soundVolume = (float) LuaScriptMgr.GetNumber(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_clipboard(IntPtr L)
  {
    NGUITools.clipboard = LuaScriptMgr.GetString(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int PlaySound(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 1:
        AudioSource audioSource1 = NGUITools.PlaySound((AudioClip) LuaScriptMgr.GetUnityObject(L, 1, typeof (AudioClip)));
        LuaScriptMgr.Push(L, (Object) audioSource1);
        return 1;
      case 2:
        AudioSource audioSource2 = NGUITools.PlaySound((AudioClip) LuaScriptMgr.GetUnityObject(L, 1, typeof (AudioClip)), (float) LuaScriptMgr.GetNumber(L, 2));
        LuaScriptMgr.Push(L, (Object) audioSource2);
        return 1;
      case 3:
        AudioSource audioSource3 = NGUITools.PlaySound((AudioClip) LuaScriptMgr.GetUnityObject(L, 1, typeof (AudioClip)), (float) LuaScriptMgr.GetNumber(L, 2), (float) LuaScriptMgr.GetNumber(L, 3));
        LuaScriptMgr.Push(L, (Object) audioSource3);
        return 1;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: NGUITools.PlaySound");
        return 0;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int OpenURL(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 1:
        WWW o1 = NGUITools.OpenURL(LuaScriptMgr.GetLuaString(L, 1));
        LuaScriptMgr.PushObject(L, (object) o1);
        return 1;
      case 2:
        WWW o2 = NGUITools.OpenURL(LuaScriptMgr.GetLuaString(L, 1), (WWWForm) LuaScriptMgr.GetNetObject(L, 2, typeof (WWWForm)));
        LuaScriptMgr.PushObject(L, (object) o2);
        return 1;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: NGUITools.OpenURL");
        return 0;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int RandomRange(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    int d = NGUITools.RandomRange((int) LuaScriptMgr.GetNumber(L, 1), (int) LuaScriptMgr.GetNumber(L, 2));
    LuaScriptMgr.Push(L, d);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetHierarchy(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    string hierarchy = NGUITools.GetHierarchy((GameObject) LuaScriptMgr.GetUnityObject(L, 1, typeof (GameObject)));
    LuaScriptMgr.Push(L, hierarchy);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int FindCameraForLayer(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    Camera cameraForLayer = NGUITools.FindCameraForLayer((int) LuaScriptMgr.GetNumber(L, 1));
    LuaScriptMgr.Push(L, (Object) cameraForLayer);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int AddWidgetCollider(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 1:
        BoxCollider boxCollider1 = NGUITools.AddWidgetCollider((GameObject) LuaScriptMgr.GetUnityObject(L, 1, typeof (GameObject)));
        LuaScriptMgr.Push(L, (Object) boxCollider1);
        return 1;
      case 2:
        BoxCollider boxCollider2 = NGUITools.AddWidgetCollider((GameObject) LuaScriptMgr.GetUnityObject(L, 1, typeof (GameObject)), LuaScriptMgr.GetBoolean(L, 2));
        LuaScriptMgr.Push(L, (Object) boxCollider2);
        return 1;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: NGUITools.AddWidgetCollider");
        return 0;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int UpdateWidgetCollider(IntPtr L)
  {
    int num = LuaDLL.lua_gettop(L);
    if (num == 1 && LuaScriptMgr.CheckTypes(L, 1, typeof (BoxCollider)))
    {
      NGUITools.UpdateWidgetCollider((BoxCollider) LuaScriptMgr.GetLuaObject(L, 1));
      return 0;
    }
    if (num == 1 && LuaScriptMgr.CheckTypes(L, 1, typeof (GameObject)))
    {
      NGUITools.UpdateWidgetCollider((GameObject) LuaScriptMgr.GetLuaObject(L, 1));
      return 0;
    }
    if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof (BoxCollider), typeof (bool)))
    {
      NGUITools.UpdateWidgetCollider((BoxCollider) LuaScriptMgr.GetLuaObject(L, 1), LuaDLL.lua_toboolean(L, 2));
      return 0;
    }
    if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof (GameObject), typeof (bool)))
    {
      NGUITools.UpdateWidgetCollider((GameObject) LuaScriptMgr.GetLuaObject(L, 1), LuaDLL.lua_toboolean(L, 2));
      return 0;
    }
    LuaDLL.luaL_error(L, "invalid arguments to method: NGUITools.UpdateWidgetCollider");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetTypeName(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    string typeName = NGUITools.GetTypeName(LuaScriptMgr.GetUnityObject(L, 1, typeof (Object)));
    LuaScriptMgr.Push(L, typeName);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int RegisterUndo(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    NGUITools.RegisterUndo(LuaScriptMgr.GetUnityObject(L, 1, typeof (Object)), LuaScriptMgr.GetLuaString(L, 2));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int SetDirty(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    NGUITools.SetDirty(LuaScriptMgr.GetUnityObject(L, 1, typeof (Object)));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int AddChild(IntPtr L)
  {
    int num = LuaDLL.lua_gettop(L);
    if (num == 1)
    {
      GameObject gameObject = NGUITools.AddChild((GameObject) LuaScriptMgr.GetUnityObject(L, 1, typeof (GameObject)));
      LuaScriptMgr.Push(L, (Object) gameObject);
      return 1;
    }
    if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof (GameObject), typeof (GameObject)))
    {
      GameObject gameObject = NGUITools.AddChild((GameObject) LuaScriptMgr.GetLuaObject(L, 1), (GameObject) LuaScriptMgr.GetLuaObject(L, 2));
      LuaScriptMgr.Push(L, (Object) gameObject);
      return 1;
    }
    if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof (GameObject), typeof (bool)))
    {
      GameObject gameObject = NGUITools.AddChild((GameObject) LuaScriptMgr.GetLuaObject(L, 1), LuaDLL.lua_toboolean(L, 2));
      LuaScriptMgr.Push(L, (Object) gameObject);
      return 1;
    }
    LuaDLL.luaL_error(L, "invalid arguments to method: NGUITools.AddChild");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int CalculateRaycastDepth(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    int raycastDepth = NGUITools.CalculateRaycastDepth((GameObject) LuaScriptMgr.GetUnityObject(L, 1, typeof (GameObject)));
    LuaScriptMgr.Push(L, raycastDepth);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int CalculateNextDepth(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 1:
        int nextDepth1 = NGUITools.CalculateNextDepth((GameObject) LuaScriptMgr.GetUnityObject(L, 1, typeof (GameObject)));
        LuaScriptMgr.Push(L, nextDepth1);
        return 1;
      case 2:
        int nextDepth2 = NGUITools.CalculateNextDepth((GameObject) LuaScriptMgr.GetUnityObject(L, 1, typeof (GameObject)), LuaScriptMgr.GetBoolean(L, 2));
        LuaScriptMgr.Push(L, nextDepth2);
        return 1;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: NGUITools.CalculateNextDepth");
        return 0;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int AdjustDepth(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    int d = NGUITools.AdjustDepth((GameObject) LuaScriptMgr.GetUnityObject(L, 1, typeof (GameObject)), (int) LuaScriptMgr.GetNumber(L, 2));
    LuaScriptMgr.Push(L, d);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int BringForward(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    NGUITools.BringForward((GameObject) LuaScriptMgr.GetUnityObject(L, 1, typeof (GameObject)));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int PushBack(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    NGUITools.PushBack((GameObject) LuaScriptMgr.GetUnityObject(L, 1, typeof (GameObject)));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int NormalizeDepths(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 0);
    NGUITools.NormalizeDepths();
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int NormalizeWidgetDepths(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 0);
    NGUITools.NormalizeWidgetDepths();
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int NormalizePanelDepths(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 0);
    NGUITools.NormalizePanelDepths();
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int CreateUI(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 1:
        UIPanel ui1 = NGUITools.CreateUI(LuaScriptMgr.GetBoolean(L, 1));
        LuaScriptMgr.Push(L, (Object) ui1);
        return 1;
      case 2:
        UIPanel ui2 = NGUITools.CreateUI(LuaScriptMgr.GetBoolean(L, 1), (int) LuaScriptMgr.GetNumber(L, 2));
        LuaScriptMgr.Push(L, (Object) ui2);
        return 1;
      case 3:
        UIPanel ui3 = NGUITools.CreateUI((Transform) LuaScriptMgr.GetUnityObject(L, 1, typeof (Transform)), LuaScriptMgr.GetBoolean(L, 2), (int) LuaScriptMgr.GetNumber(L, 3));
        LuaScriptMgr.Push(L, (Object) ui3);
        return 1;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: NGUITools.CreateUI");
        return 0;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int SetChildLayer(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    NGUITools.SetChildLayer((Transform) LuaScriptMgr.GetUnityObject(L, 1, typeof (Transform)), (int) LuaScriptMgr.GetNumber(L, 2));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int AddSprite(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 3);
    UISprite uiSprite = NGUITools.AddSprite((GameObject) LuaScriptMgr.GetUnityObject(L, 1, typeof (GameObject)), (UIAtlas) LuaScriptMgr.GetUnityObject(L, 2, typeof (UIAtlas)), LuaScriptMgr.GetLuaString(L, 3));
    LuaScriptMgr.Push(L, (Object) uiSprite);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetRoot(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    GameObject root = NGUITools.GetRoot((GameObject) LuaScriptMgr.GetUnityObject(L, 1, typeof (GameObject)));
    LuaScriptMgr.Push(L, (Object) root);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int Destroy(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    NGUITools.Destroy(LuaScriptMgr.GetUnityObject(L, 1, typeof (Object)));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int DestroyImmediate(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    NGUITools.DestroyImmediate(LuaScriptMgr.GetUnityObject(L, 1, typeof (Object)));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int Broadcast(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 1:
        NGUITools.Broadcast(LuaScriptMgr.GetLuaString(L, 1));
        return 0;
      case 2:
        NGUITools.Broadcast(LuaScriptMgr.GetLuaString(L, 1), LuaScriptMgr.GetVarObject(L, 2));
        return 0;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: NGUITools.Broadcast");
        return 0;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int IsChild(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    bool b = NGUITools.IsChild((Transform) LuaScriptMgr.GetUnityObject(L, 1, typeof (Transform)), (Transform) LuaScriptMgr.GetUnityObject(L, 2, typeof (Transform)));
    LuaScriptMgr.Push(L, b);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int SetActive(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 2:
        NGUITools.SetActive((GameObject) LuaScriptMgr.GetUnityObject(L, 1, typeof (GameObject)), LuaScriptMgr.GetBoolean(L, 2));
        return 0;
      case 3:
        NGUITools.SetActive((GameObject) LuaScriptMgr.GetUnityObject(L, 1, typeof (GameObject)), LuaScriptMgr.GetBoolean(L, 2), LuaScriptMgr.GetBoolean(L, 3));
        return 0;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: NGUITools.SetActive");
        return 0;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int SetActiveChildren(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    NGUITools.SetActiveChildren((GameObject) LuaScriptMgr.GetUnityObject(L, 1, typeof (GameObject)), LuaScriptMgr.GetBoolean(L, 2));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetActive(IntPtr L)
  {
    int num = LuaDLL.lua_gettop(L);
    if (num == 1 && LuaScriptMgr.CheckTypes(L, 1, typeof (GameObject)))
    {
      bool active = NGUITools.GetActive((GameObject) LuaScriptMgr.GetLuaObject(L, 1));
      LuaScriptMgr.Push(L, active);
      return 1;
    }
    if (num == 1 && LuaScriptMgr.CheckTypes(L, 1, typeof (Behaviour)))
    {
      bool active = NGUITools.GetActive((Behaviour) LuaScriptMgr.GetLuaObject(L, 1));
      LuaScriptMgr.Push(L, active);
      return 1;
    }
    LuaDLL.luaL_error(L, "invalid arguments to method: NGUITools.GetActive");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int SetActiveSelf(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    NGUITools.SetActiveSelf((GameObject) LuaScriptMgr.GetUnityObject(L, 1, typeof (GameObject)), LuaScriptMgr.GetBoolean(L, 2));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int SetLayer(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    NGUITools.SetLayer((GameObject) LuaScriptMgr.GetUnityObject(L, 1, typeof (GameObject)), (int) LuaScriptMgr.GetNumber(L, 2));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int Round(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    Vector3 v3 = NGUITools.Round(LuaScriptMgr.GetVector3(L, 1));
    LuaScriptMgr.Push(L, v3);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int MakePixelPerfect(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    NGUITools.MakePixelPerfect((Transform) LuaScriptMgr.GetUnityObject(L, 1, typeof (Transform)));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int Save(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    bool b = NGUITools.Save(LuaScriptMgr.GetLuaString(L, 1), LuaScriptMgr.GetArrayNumber<byte>(L, 2));
    LuaScriptMgr.Push(L, b);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int Load(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    byte[] o = NGUITools.Load(LuaScriptMgr.GetLuaString(L, 1));
    LuaScriptMgr.PushArray(L, (Array) o);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int ApplyPMA(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    Color clr = NGUITools.ApplyPMA(LuaScriptMgr.GetColor(L, 1));
    LuaScriptMgr.Push(L, clr);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int MarkParentAsChanged(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    NGUITools.MarkParentAsChanged((GameObject) LuaScriptMgr.GetUnityObject(L, 1, typeof (GameObject)));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetSides(IntPtr L)
  {
    int num = LuaDLL.lua_gettop(L);
    if (num == 1)
    {
      Vector3[] sides = ((Camera) LuaScriptMgr.GetUnityObject(L, 1, typeof (Camera))).GetSides();
      LuaScriptMgr.PushArray(L, (Array) sides);
      return 1;
    }
    if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof (Camera), typeof (Transform)))
    {
      Vector3[] sides = ((Camera) LuaScriptMgr.GetLuaObject(L, 1)).GetSides((Transform) LuaScriptMgr.GetLuaObject(L, 2));
      LuaScriptMgr.PushArray(L, (Array) sides);
      return 1;
    }
    if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof (Camera), typeof (float)))
    {
      Vector3[] sides = ((Camera) LuaScriptMgr.GetLuaObject(L, 1)).GetSides((float) LuaDLL.lua_tonumber(L, 2));
      LuaScriptMgr.PushArray(L, (Array) sides);
      return 1;
    }
    if (num == 3)
    {
      Vector3[] sides = ((Camera) LuaScriptMgr.GetUnityObject(L, 1, typeof (Camera))).GetSides((float) LuaScriptMgr.GetNumber(L, 2), (Transform) LuaScriptMgr.GetUnityObject(L, 3, typeof (Transform)));
      LuaScriptMgr.PushArray(L, (Array) sides);
      return 1;
    }
    LuaDLL.luaL_error(L, "invalid arguments to method: NGUITools.GetSides");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetWorldCorners(IntPtr L)
  {
    int num = LuaDLL.lua_gettop(L);
    if (num == 1)
    {
      Vector3[] worldCorners = ((Camera) LuaScriptMgr.GetUnityObject(L, 1, typeof (Camera))).GetWorldCorners();
      LuaScriptMgr.PushArray(L, (Array) worldCorners);
      return 1;
    }
    if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof (Camera), typeof (Transform)))
    {
      Vector3[] worldCorners = ((Camera) LuaScriptMgr.GetLuaObject(L, 1)).GetWorldCorners((Transform) LuaScriptMgr.GetLuaObject(L, 2));
      LuaScriptMgr.PushArray(L, (Array) worldCorners);
      return 1;
    }
    if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof (Camera), typeof (float)))
    {
      Vector3[] worldCorners = ((Camera) LuaScriptMgr.GetLuaObject(L, 1)).GetWorldCorners((float) LuaDLL.lua_tonumber(L, 2));
      LuaScriptMgr.PushArray(L, (Array) worldCorners);
      return 1;
    }
    if (num == 3)
    {
      Vector3[] worldCorners = ((Camera) LuaScriptMgr.GetUnityObject(L, 1, typeof (Camera))).GetWorldCorners((float) LuaScriptMgr.GetNumber(L, 2), (Transform) LuaScriptMgr.GetUnityObject(L, 3, typeof (Transform)));
      LuaScriptMgr.PushArray(L, (Array) worldCorners);
      return 1;
    }
    LuaDLL.luaL_error(L, "invalid arguments to method: NGUITools.GetWorldCorners");
    return 0;
  }
}
