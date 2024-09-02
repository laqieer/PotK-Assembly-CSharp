// Decompiled with JetBrains decompiler
// Type: AnimationWrap
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using LuaInterface;
using System;
using System.Collections;
using UnityEngine;

#nullable disable
public class AnimationWrap
{
  private static System.Type classType = typeof (Animation);

  public static void Register(IntPtr L)
  {
    LuaMethod[] regs = new LuaMethod[19]
    {
      new LuaMethod("Stop", new LuaCSFunction(AnimationWrap.Stop)),
      new LuaMethod("Rewind", new LuaCSFunction(AnimationWrap.Rewind)),
      new LuaMethod("Sample", new LuaCSFunction(AnimationWrap.Sample)),
      new LuaMethod("IsPlaying", new LuaCSFunction(AnimationWrap.IsPlaying)),
      new LuaMethod("get_Item", new LuaCSFunction(AnimationWrap.get_Item)),
      new LuaMethod("Play", new LuaCSFunction(AnimationWrap.Play)),
      new LuaMethod("CrossFade", new LuaCSFunction(AnimationWrap.CrossFade)),
      new LuaMethod("Blend", new LuaCSFunction(AnimationWrap.Blend)),
      new LuaMethod("CrossFadeQueued", new LuaCSFunction(AnimationWrap.CrossFadeQueued)),
      new LuaMethod("PlayQueued", new LuaCSFunction(AnimationWrap.PlayQueued)),
      new LuaMethod("AddClip", new LuaCSFunction(AnimationWrap.AddClip)),
      new LuaMethod("RemoveClip", new LuaCSFunction(AnimationWrap.RemoveClip)),
      new LuaMethod("GetClipCount", new LuaCSFunction(AnimationWrap.GetClipCount)),
      new LuaMethod("SyncLayer", new LuaCSFunction(AnimationWrap.SyncLayer)),
      new LuaMethod("GetEnumerator", new LuaCSFunction(AnimationWrap.GetEnumerator)),
      new LuaMethod("GetClip", new LuaCSFunction(AnimationWrap.GetClip)),
      new LuaMethod("New", new LuaCSFunction(AnimationWrap._CreateAnimation)),
      new LuaMethod("GetClassType", new LuaCSFunction(AnimationWrap.GetClassType)),
      new LuaMethod("__eq", new LuaCSFunction(AnimationWrap.Lua_Eq))
    };
    LuaField[] fields = new LuaField[7]
    {
      new LuaField("clip", new LuaCSFunction(AnimationWrap.get_clip), new LuaCSFunction(AnimationWrap.set_clip)),
      new LuaField("playAutomatically", new LuaCSFunction(AnimationWrap.get_playAutomatically), new LuaCSFunction(AnimationWrap.set_playAutomatically)),
      new LuaField("wrapMode", new LuaCSFunction(AnimationWrap.get_wrapMode), new LuaCSFunction(AnimationWrap.set_wrapMode)),
      new LuaField("isPlaying", new LuaCSFunction(AnimationWrap.get_isPlaying), (LuaCSFunction) null),
      new LuaField("animatePhysics", new LuaCSFunction(AnimationWrap.get_animatePhysics), new LuaCSFunction(AnimationWrap.set_animatePhysics)),
      new LuaField("cullingType", new LuaCSFunction(AnimationWrap.get_cullingType), new LuaCSFunction(AnimationWrap.set_cullingType)),
      new LuaField("localBounds", new LuaCSFunction(AnimationWrap.get_localBounds), new LuaCSFunction(AnimationWrap.set_localBounds))
    };
    LuaScriptMgr.RegisterLib(L, "UnityEngine.Animation", typeof (Animation), regs, fields, typeof (Behaviour));
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int _CreateAnimation(IntPtr L)
  {
    if (LuaDLL.lua_gettop(L) == 0)
    {
      Animation animation = new Animation();
      LuaScriptMgr.Push(L, (Object) animation);
      return 1;
    }
    LuaDLL.luaL_error(L, "invalid arguments to method: Animation.New");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetClassType(IntPtr L)
  {
    LuaScriptMgr.Push(L, AnimationWrap.classType);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_clip(IntPtr L)
  {
    Animation luaObject = (Animation) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name clip");
      else
        LuaDLL.luaL_error(L, "attempt to index clip on a nil value");
    }
    LuaScriptMgr.Push(L, (Object) luaObject.clip);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_playAutomatically(IntPtr L)
  {
    Animation luaObject = (Animation) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name playAutomatically");
      else
        LuaDLL.luaL_error(L, "attempt to index playAutomatically on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.playAutomatically);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_wrapMode(IntPtr L)
  {
    Animation luaObject = (Animation) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name wrapMode");
      else
        LuaDLL.luaL_error(L, "attempt to index wrapMode on a nil value");
    }
    LuaScriptMgr.Push(L, (Enum) (object) luaObject.wrapMode);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_isPlaying(IntPtr L)
  {
    Animation luaObject = (Animation) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name isPlaying");
      else
        LuaDLL.luaL_error(L, "attempt to index isPlaying on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.isPlaying);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_animatePhysics(IntPtr L)
  {
    Animation luaObject = (Animation) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name animatePhysics");
      else
        LuaDLL.luaL_error(L, "attempt to index animatePhysics on a nil value");
    }
    LuaScriptMgr.Push(L, luaObject.animatePhysics);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_cullingType(IntPtr L)
  {
    Animation luaObject = (Animation) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name cullingType");
      else
        LuaDLL.luaL_error(L, "attempt to index cullingType on a nil value");
    }
    LuaScriptMgr.Push(L, (Enum) (object) luaObject.cullingType);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_localBounds(IntPtr L)
  {
    Animation luaObject = (Animation) LuaScriptMgr.GetLuaObject(L, 1);
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
  private static int set_clip(IntPtr L)
  {
    Animation luaObject = (Animation) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name clip");
      else
        LuaDLL.luaL_error(L, "attempt to index clip on a nil value");
    }
    luaObject.clip = (AnimationClip) LuaScriptMgr.GetUnityObject(L, 3, typeof (AnimationClip));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_playAutomatically(IntPtr L)
  {
    Animation luaObject = (Animation) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name playAutomatically");
      else
        LuaDLL.luaL_error(L, "attempt to index playAutomatically on a nil value");
    }
    luaObject.playAutomatically = LuaScriptMgr.GetBoolean(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_wrapMode(IntPtr L)
  {
    Animation luaObject = (Animation) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name wrapMode");
      else
        LuaDLL.luaL_error(L, "attempt to index wrapMode on a nil value");
    }
    luaObject.wrapMode = (WrapMode) (int) LuaScriptMgr.GetNetObject(L, 3, typeof (WrapMode));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_animatePhysics(IntPtr L)
  {
    Animation luaObject = (Animation) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name animatePhysics");
      else
        LuaDLL.luaL_error(L, "attempt to index animatePhysics on a nil value");
    }
    luaObject.animatePhysics = LuaScriptMgr.GetBoolean(L, 3);
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_cullingType(IntPtr L)
  {
    Animation luaObject = (Animation) LuaScriptMgr.GetLuaObject(L, 1);
    if (Object.op_Equality((Object) luaObject, (Object) null))
    {
      if (LuaDLL.lua_type(L, 1) == LuaTypes.LUA_TTABLE)
        LuaDLL.luaL_error(L, "unknown member name cullingType");
      else
        LuaDLL.luaL_error(L, "attempt to index cullingType on a nil value");
    }
    luaObject.cullingType = (AnimationCullingType) (int) LuaScriptMgr.GetNetObject(L, 3, typeof (AnimationCullingType));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int set_localBounds(IntPtr L)
  {
    Animation luaObject = (Animation) LuaScriptMgr.GetLuaObject(L, 1);
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
  private static int Stop(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 1:
        ((Animation) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Animation")).Stop();
        return 0;
      case 2:
        ((Animation) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Animation")).Stop(LuaScriptMgr.GetLuaString(L, 2));
        return 0;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: Animation.Stop");
        return 0;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int Rewind(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 1:
        ((Animation) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Animation")).Rewind();
        return 0;
      case 2:
        ((Animation) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Animation")).Rewind(LuaScriptMgr.GetLuaString(L, 2));
        return 0;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: Animation.Rewind");
        return 0;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int Sample(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    ((Animation) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Animation")).Sample();
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int IsPlaying(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    bool b = ((Animation) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Animation")).IsPlaying(LuaScriptMgr.GetLuaString(L, 2));
    LuaScriptMgr.Push(L, b);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int get_Item(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    AnimationState animationState = ((Animation) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Animation"))[LuaScriptMgr.GetLuaString(L, 2)];
    LuaScriptMgr.Push(L, (TrackedReference) animationState);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int Play(IntPtr L)
  {
    int num = LuaDLL.lua_gettop(L);
    if (num == 1)
    {
      bool b = ((Animation) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Animation")).Play();
      LuaScriptMgr.Push(L, b);
      return 1;
    }
    if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof (Animation), typeof (string)))
    {
      bool b = ((Animation) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Animation")).Play(LuaScriptMgr.GetString(L, 2));
      LuaScriptMgr.Push(L, b);
      return 1;
    }
    if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof (Animation), typeof (PlayMode)))
    {
      bool b = ((Animation) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Animation")).Play((PlayMode) (int) LuaScriptMgr.GetLuaObject(L, 2));
      LuaScriptMgr.Push(L, b);
      return 1;
    }
    if (num == 3)
    {
      bool b = ((Animation) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Animation")).Play(LuaScriptMgr.GetLuaString(L, 2), (PlayMode) (int) LuaScriptMgr.GetNetObject(L, 3, typeof (PlayMode)));
      LuaScriptMgr.Push(L, b);
      return 1;
    }
    LuaDLL.luaL_error(L, "invalid arguments to method: Animation.Play");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int CrossFade(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 2:
        ((Animation) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Animation")).CrossFade(LuaScriptMgr.GetLuaString(L, 2));
        return 0;
      case 3:
        ((Animation) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Animation")).CrossFade(LuaScriptMgr.GetLuaString(L, 2), (float) LuaScriptMgr.GetNumber(L, 3));
        return 0;
      case 4:
        ((Animation) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Animation")).CrossFade(LuaScriptMgr.GetLuaString(L, 2), (float) LuaScriptMgr.GetNumber(L, 3), (PlayMode) (int) LuaScriptMgr.GetNetObject(L, 4, typeof (PlayMode)));
        return 0;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: Animation.CrossFade");
        return 0;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int Blend(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 2:
        ((Animation) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Animation")).Blend(LuaScriptMgr.GetLuaString(L, 2));
        return 0;
      case 3:
        ((Animation) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Animation")).Blend(LuaScriptMgr.GetLuaString(L, 2), (float) LuaScriptMgr.GetNumber(L, 3));
        return 0;
      case 4:
        ((Animation) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Animation")).Blend(LuaScriptMgr.GetLuaString(L, 2), (float) LuaScriptMgr.GetNumber(L, 3), (float) LuaScriptMgr.GetNumber(L, 4));
        return 0;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: Animation.Blend");
        return 0;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int CrossFadeQueued(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 2:
        AnimationState animationState1 = ((Animation) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Animation")).CrossFadeQueued(LuaScriptMgr.GetLuaString(L, 2));
        LuaScriptMgr.Push(L, (TrackedReference) animationState1);
        return 1;
      case 3:
        AnimationState animationState2 = ((Animation) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Animation")).CrossFadeQueued(LuaScriptMgr.GetLuaString(L, 2), (float) LuaScriptMgr.GetNumber(L, 3));
        LuaScriptMgr.Push(L, (TrackedReference) animationState2);
        return 1;
      case 4:
        AnimationState animationState3 = ((Animation) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Animation")).CrossFadeQueued(LuaScriptMgr.GetLuaString(L, 2), (float) LuaScriptMgr.GetNumber(L, 3), (QueueMode) (int) LuaScriptMgr.GetNetObject(L, 4, typeof (QueueMode)));
        LuaScriptMgr.Push(L, (TrackedReference) animationState3);
        return 1;
      case 5:
        AnimationState animationState4 = ((Animation) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Animation")).CrossFadeQueued(LuaScriptMgr.GetLuaString(L, 2), (float) LuaScriptMgr.GetNumber(L, 3), (QueueMode) (int) LuaScriptMgr.GetNetObject(L, 4, typeof (QueueMode)), (PlayMode) (int) LuaScriptMgr.GetNetObject(L, 5, typeof (PlayMode)));
        LuaScriptMgr.Push(L, (TrackedReference) animationState4);
        return 1;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: Animation.CrossFadeQueued");
        return 0;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int PlayQueued(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 2:
        AnimationState animationState1 = ((Animation) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Animation")).PlayQueued(LuaScriptMgr.GetLuaString(L, 2));
        LuaScriptMgr.Push(L, (TrackedReference) animationState1);
        return 1;
      case 3:
        AnimationState animationState2 = ((Animation) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Animation")).PlayQueued(LuaScriptMgr.GetLuaString(L, 2), (QueueMode) (int) LuaScriptMgr.GetNetObject(L, 3, typeof (QueueMode)));
        LuaScriptMgr.Push(L, (TrackedReference) animationState2);
        return 1;
      case 4:
        AnimationState animationState3 = ((Animation) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Animation")).PlayQueued(LuaScriptMgr.GetLuaString(L, 2), (QueueMode) (int) LuaScriptMgr.GetNetObject(L, 3, typeof (QueueMode)), (PlayMode) (int) LuaScriptMgr.GetNetObject(L, 4, typeof (PlayMode)));
        LuaScriptMgr.Push(L, (TrackedReference) animationState3);
        return 1;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: Animation.PlayQueued");
        return 0;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int AddClip(IntPtr L)
  {
    switch (LuaDLL.lua_gettop(L))
    {
      case 3:
        ((Animation) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Animation")).AddClip((AnimationClip) LuaScriptMgr.GetUnityObject(L, 2, typeof (AnimationClip)), LuaScriptMgr.GetLuaString(L, 3));
        return 0;
      case 5:
        ((Animation) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Animation")).AddClip((AnimationClip) LuaScriptMgr.GetUnityObject(L, 2, typeof (AnimationClip)), LuaScriptMgr.GetLuaString(L, 3), (int) LuaScriptMgr.GetNumber(L, 4), (int) LuaScriptMgr.GetNumber(L, 5));
        return 0;
      case 6:
        ((Animation) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Animation")).AddClip((AnimationClip) LuaScriptMgr.GetUnityObject(L, 2, typeof (AnimationClip)), LuaScriptMgr.GetLuaString(L, 3), (int) LuaScriptMgr.GetNumber(L, 4), (int) LuaScriptMgr.GetNumber(L, 5), LuaScriptMgr.GetBoolean(L, 6));
        return 0;
      default:
        LuaDLL.luaL_error(L, "invalid arguments to method: Animation.AddClip");
        return 0;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int RemoveClip(IntPtr L)
  {
    int num = LuaDLL.lua_gettop(L);
    if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof (Animation), typeof (string)))
    {
      ((Animation) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Animation")).RemoveClip(LuaScriptMgr.GetString(L, 2));
      return 0;
    }
    if (num == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof (Animation), typeof (AnimationClip)))
    {
      ((Animation) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Animation")).RemoveClip((AnimationClip) LuaScriptMgr.GetLuaObject(L, 2));
      return 0;
    }
    LuaDLL.luaL_error(L, "invalid arguments to method: Animation.RemoveClip");
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetClipCount(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    int clipCount = ((Animation) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Animation")).GetClipCount();
    LuaScriptMgr.Push(L, clipCount);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int SyncLayer(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    ((Animation) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Animation")).SyncLayer((int) LuaScriptMgr.GetNumber(L, 2));
    return 0;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetEnumerator(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 1);
    IEnumerator enumerator = ((Animation) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Animation")).GetEnumerator();
    LuaScriptMgr.Push(L, enumerator);
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  private static int GetClip(IntPtr L)
  {
    LuaScriptMgr.CheckArgsCount(L, 2);
    AnimationClip clip = ((Animation) LuaScriptMgr.GetUnityObjectSelf(L, 1, "Animation")).GetClip(LuaScriptMgr.GetLuaString(L, 2));
    LuaScriptMgr.Push(L, (Object) clip);
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
