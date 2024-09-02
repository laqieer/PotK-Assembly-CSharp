// Decompiled with JetBrains decompiler
// Type: LuaScriptMgr
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using DenaLib;
using LuaInterface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class LuaScriptMgr
{
  public LuaState lua;
  public HashSet<string> fileList;
  private Dictionary<string, LuaBase> dict;
  private LuaFunction updateFunc;
  private LuaFunction lateUpdateFunc;
  private LuaFunction fixedUpdateFunc;
  private LuaFunction levelLoaded;
  private int unpackVec3;
  private int unpackVec2;
  private int unpackVec4;
  private int unpackQuat;
  private int unpackColor;
  private int unpackRay;
  private int unpackBounds;
  private int packVec3;
  private int packVec2;
  private int packVec4;
  private int packQuat;
  private LuaFunction packTouch;
  private int packRay;
  private LuaFunction packRaycastHit;
  private int packColor;
  private int packBounds;
  private int enumMetaRef;
  private int typeMetaRef;
  private int delegateMetaRef;
  private int iterMetaRef;
  private int arrayMetaRef;
  public HFResourceManager ResourceManagerRef;
  public static LockFreeQueue<LuaRef> refGCList = new LockFreeQueue<LuaRef>(1024);
  private static ObjectTranslator _translator = (ObjectTranslator) null;
  private static HashSet<System.Type> checkBaseType = new HashSet<System.Type>();
  private static LuaFunction traceback = (LuaFunction) null;
  private string luaIndex = "        \r\n        local rawget = rawget\r\n        local rawset = rawset\r\n        local getmetatable = getmetatable      \r\n        local type = type  \r\n        local function index(obj,name)  \r\n            local o = obj            \r\n            local meta = getmetatable(o)            \r\n            local parent = meta\r\n            local v = nil\r\n            \r\n            while meta~= nil do\r\n                v = rawget(meta, name)\r\n                \r\n                if v~= nil then\r\n                    if parent ~= meta then rawset(parent, name, v) end\r\n\r\n                    local t = type(v)\r\n\r\n                    if t == 'function' then                    \r\n                        return v\r\n                    else\r\n                        local func = v[1]\r\n                \r\n                        if func ~= nil then\r\n                            return func(obj)                         \r\n                        end\r\n                    end\r\n                    break\r\n                end\r\n                \r\n                meta = getmetatable(meta)\r\n            end\r\n\r\n           error('unknown member name '..name, 2)\r\n           return nil\t        \r\n        end\r\n        return index";
  private string luaNewIndex = "\r\n        local rawget = rawget\r\n        local getmetatable = getmetatable   \r\n        local rawset = rawset     \r\n        local function newindex(obj, name, val)            \r\n            local meta = getmetatable(obj)            \r\n            local parent = meta\r\n            local v = nil\r\n            \r\n            while meta~= nil do\r\n                v = rawget(meta, name)\r\n                \r\n                if v~= nil then\r\n                    if parent ~= meta then rawset(parent, name, v) end\r\n                    local func = v[2]\r\n                    if func ~= nil then                        \r\n                        return func(obj, nil, val)                        \r\n                    end\r\n                    break\r\n                end\r\n                \r\n                meta = getmetatable(meta)\r\n            end  \r\n       \r\n            error('field or property '..name..' does not exist', 2)\r\n            return nil\t\t\r\n        end\r\n        return newindex";
  private string luaTableCall = "\r\n        local rawget = rawget\r\n        local getmetatable = getmetatable     \r\n\r\n        local function call(obj, ...)\r\n            local meta = getmetatable(obj)\r\n            local fun = rawget(meta, 'New')\r\n            \r\n            if fun ~= nil then\r\n                return fun(...)\r\n            else\r\n                error('unknow function __call',2)\r\n            end\r\n        end\r\n\r\n        return call\r\n    ";
  private string luaEnumIndex = "\r\n        local rawget = rawget                \r\n        local getmetatable = getmetatable         \r\n\r\n        local function indexEnum(obj,name)\r\n            local v = rawget(obj, name)\r\n            \r\n            if v ~= nil then\r\n                return v\r\n            end\r\n\r\n            local meta = getmetatable(obj)  \r\n            local func = rawget(meta, name)            \r\n            \r\n            if func ~= nil then\r\n                v = func()\r\n                rawset(obj, name, v)\r\n                return v\r\n            else\r\n                error('field '..name..' does not exist', 2)\r\n            end\r\n        end\r\n\r\n        return indexEnum\r\n    ";
  private static System.Type monoType = typeof (System.Type).GetType();
  private static Dictionary<Enum, object> enumMap = new Dictionary<Enum, object>();

  public LuaScriptMgr()
  {
    if (!Util.CheckEnvironment())
      return;
    LuaScriptMgr.Instance = this;
    LuaStatic.Load = new ReadLuaFile(this.Loader);
    this.lua = new LuaState();
    LuaScriptMgr._translator = this.lua.GetTranslator();
    LuaDLL.luaopen_pb(this.lua.L);
    LuaDLL.luaopen_protobuf_c(this.lua.L);
    LuaDLL.luaopen_lpeg(this.lua.L);
    LuaDLL.luaopen_cjson(this.lua.L);
    LuaDLL.luaopen_cjson_safe(this.lua.L);
    LuaDLL.luaopen_sproto_core(this.lua.L);
    LuaDLL.tolua_openlibs(this.lua.L);
    this.fileList = new HashSet<string>();
    this.dict = new Dictionary<string, LuaBase>();
    LuaDLL.lua_pushstring(this.lua.L, "ToLua_Index");
    LuaDLL.luaL_dostring(this.lua.L, this.luaIndex);
    LuaDLL.lua_rawset(this.lua.L, LuaIndexes.LUA_REGISTRYINDEX);
    LuaDLL.lua_pushstring(this.lua.L, "ToLua_NewIndex");
    LuaDLL.luaL_dostring(this.lua.L, this.luaNewIndex);
    LuaDLL.lua_rawset(this.lua.L, LuaIndexes.LUA_REGISTRYINDEX);
    LuaDLL.lua_pushstring(this.lua.L, "ToLua_TableCall");
    LuaDLL.luaL_dostring(this.lua.L, this.luaTableCall);
    LuaDLL.lua_rawset(this.lua.L, LuaIndexes.LUA_REGISTRYINDEX);
    LuaDLL.lua_pushstring(this.lua.L, "ToLua_EnumIndex");
    LuaDLL.luaL_dostring(this.lua.L, this.luaEnumIndex);
    LuaDLL.lua_rawset(this.lua.L, LuaIndexes.LUA_REGISTRYINDEX);
    this.Bind();
    LuaDLL.lua_pushnumber(this.lua.L, 0.0);
    LuaDLL.lua_setglobal(this.lua.L, "_LuaScriptMgr");
  }

  public static LuaScriptMgr Instance { get; private set; }

  private void SendGMmsg(params string[] param)
  {
    Debugger.Log(nameof (SendGMmsg));
    string str1 = string.Empty;
    int num = 0;
    foreach (string str2 in param)
    {
      if (num > 0)
      {
        str1 = str1 + " " + str2;
        Debugger.Log(str2);
      }
      ++num;
    }
    this.CallLuaFunction("GMMsg", (object) str1);
  }

  private void InitLayers(IntPtr L)
  {
    this.GetLuaTable("Layer").push(L);
    for (int d = 0; d < 32; ++d)
    {
      string name = LayerMask.LayerToName(d);
      if (name != string.Empty)
      {
        LuaDLL.lua_pushstring(L, name);
        LuaScriptMgr.Push(L, d);
        LuaDLL.lua_rawset(L, -3);
      }
    }
    LuaDLL.lua_settop(L, 0);
  }

  private void Bind()
  {
    IntPtr l = this.lua.L;
    this.BindArray(l);
    DelegateFactory.Register(l);
    LuaBinder.Bind(l);
  }

  private void BindArray(IntPtr L)
  {
    LuaDLL.luaL_newmetatable(L, "luaNet_array");
    LuaDLL.lua_pushstring(L, "__index");
    LuaDLL.lua_pushstdcallcfunction(L, new LuaCSFunction(LuaScriptMgr.IndexArray));
    LuaDLL.lua_rawset(L, -3);
    LuaDLL.lua_pushstring(L, "__gc");
    LuaDLL.lua_pushstdcallcfunction(L, new LuaCSFunction(LuaScriptMgr.__gc));
    LuaDLL.lua_rawset(L, -3);
    LuaDLL.lua_pushstring(L, "__newindex");
    LuaDLL.lua_pushstdcallcfunction(L, new LuaCSFunction(LuaScriptMgr.NewIndexArray));
    LuaDLL.lua_rawset(L, -3);
    this.arrayMetaRef = LuaDLL.luaL_ref(this.lua.L, LuaIndexes.LUA_REGISTRYINDEX);
    LuaDLL.lua_settop(L, 0);
  }

  public IntPtr GetL() => this.lua.L;

  private void PrintLua(params string[] param)
  {
    if (param.Length != 2)
      Debugger.Log("PrintLua [ModuleName]");
    else
      this.CallLuaFunction(nameof (PrintLua), (object) param[1]);
  }

  public void LuaGC(params string[] param)
  {
    LuaDLL.lua_gc(this.lua.L, LuaGCOptions.LUA_GCCOLLECT, 0);
  }

  private void LuaMem(params string[] param) => this.CallLuaFunction("mem_report");

  public void Start()
  {
    this.OnBundleLoaded();
    this.enumMetaRef = this.GetTypeMetaRef(typeof (Enum));
    this.typeMetaRef = this.GetTypeMetaRef(typeof (System.Type));
    this.delegateMetaRef = this.GetTypeMetaRef(typeof (Delegate));
    this.iterMetaRef = this.GetTypeMetaRef(typeof (IEnumerator));
    foreach (System.Type type in LuaScriptMgr.checkBaseType)
      Debugger.LogWarning("BaseType {0} not register to lua", (object) type.FullName);
    LuaScriptMgr.checkBaseType.Clear();
  }

  private int GetLuaReference(string str)
  {
    LuaFunction luaFunction = this.GetLuaFunction(str);
    return luaFunction != null ? luaFunction.GetReference() : -1;
  }

  private int GetTypeMetaRef(System.Type t)
  {
    LuaDLL.luaL_getmetatable(this.lua.L, t.AssemblyQualifiedName);
    return LuaDLL.luaL_ref(this.lua.L, LuaIndexes.LUA_REGISTRYINDEX);
  }

  private void OnBundleLoaded()
  {
    this.DoFile("System.Global");
    this.InitLayers(this.lua.L);
    this.unpackVec3 = this.GetLuaReference("Vector3.Get");
    this.unpackVec2 = this.GetLuaReference("Vector2.Get");
    this.unpackVec4 = this.GetLuaReference("Vector4.Get");
    this.unpackQuat = this.GetLuaReference("Quaternion.Get");
    this.unpackColor = this.GetLuaReference("Color.Get");
    this.unpackRay = this.GetLuaReference("Ray.Get");
    this.unpackBounds = this.GetLuaReference("Bounds.Get");
    this.packVec3 = this.GetLuaReference("Vector3.New");
    this.packVec2 = this.GetLuaReference("Vector2.New");
    this.packVec4 = this.GetLuaReference("Vector4.New");
    this.packQuat = this.GetLuaReference("Quaternion.New");
    this.packRaycastHit = this.GetLuaFunction("Raycast.New");
    this.packColor = this.GetLuaReference("Color.New");
    this.packRay = this.GetLuaReference("Ray.New");
    this.packTouch = this.GetLuaFunction("Touch.New");
    this.packBounds = this.GetLuaReference("Bounds.New");
    LuaScriptMgr.traceback = this.GetLuaFunction("traceback");
    this.DoFile("System.Main");
    this.updateFunc = this.GetLuaFunction("Update");
    this.lateUpdateFunc = this.GetLuaFunction("LateUpdate");
    this.fixedUpdateFunc = this.GetLuaFunction("FixedUpdate");
    this.levelLoaded = this.GetLuaFunction("OnLevelWasLoaded");
    this.CallLuaFunction("Main");
  }

  public void OnLevelLoaded(int level) => this.levelLoaded.Call((double) level);

  public void Update()
  {
    if (this.updateFunc != null)
    {
      int oldTop = this.updateFunc.BeginPCall();
      IntPtr luaState = this.updateFunc.GetLuaState();
      LuaScriptMgr.Push(luaState, Time.deltaTime);
      LuaScriptMgr.Push(luaState, Time.unscaledDeltaTime);
      this.updateFunc.PCall(oldTop, 2);
      this.updateFunc.EndPCall(oldTop);
    }
    while (!LuaScriptMgr.refGCList.IsEmpty())
    {
      LuaRef luaRef = LuaScriptMgr.refGCList.Dequeue();
      LuaDLL.lua_unref(luaRef.L, luaRef.reference);
    }
  }

  public void LateUpate()
  {
    if (this.lateUpdateFunc == null)
      return;
    this.lateUpdateFunc.Call();
  }

  public void FixedUpdate()
  {
    if (this.fixedUpdateFunc == null)
      return;
    this.fixedUpdateFunc.Call((double) Time.fixedDeltaTime);
  }

  private void SafeRelease(ref LuaFunction func)
  {
    if (func == null)
      return;
    func.Release();
    func = (LuaFunction) null;
  }

  private void SafeUnRef(ref int reference)
  {
    if (reference <= 0)
      return;
    LuaDLL.lua_unref(this.lua.L, reference);
    reference = -1;
  }

  public void Destroy()
  {
    LuaScriptMgr.Instance = (LuaScriptMgr) null;
    this.SafeUnRef(ref this.enumMetaRef);
    this.SafeUnRef(ref this.typeMetaRef);
    this.SafeUnRef(ref this.delegateMetaRef);
    this.SafeUnRef(ref this.iterMetaRef);
    this.SafeUnRef(ref this.arrayMetaRef);
    this.SafeRelease(ref this.packRaycastHit);
    this.SafeRelease(ref this.packTouch);
    this.SafeRelease(ref this.updateFunc);
    this.SafeRelease(ref this.lateUpdateFunc);
    this.SafeRelease(ref this.fixedUpdateFunc);
    LuaDLL.lua_gc(this.lua.L, LuaGCOptions.LUA_GCCOLLECT, 0);
    foreach (KeyValuePair<string, LuaBase> keyValuePair in this.dict)
      keyValuePair.Value.Dispose();
    this.dict.Clear();
    this.fileList.Clear();
    this.lua.Close();
    this.lua.Dispose();
    this.lua = (LuaState) null;
    DelegateFactory.Clear();
    LuaBinder.wrapList.Clear();
    Debugger.Log("Lua module destroy");
  }

  public object[] DoString(string str) => this.lua.DoString(str);

  public object[] DoFile(string fileName)
  {
    return !this.fileList.Contains(fileName) ? this.lua.DoFile(fileName, (LuaTable) null) : (object[]) null;
  }

  public object[] CallLuaFunction(string name, params object[] args)
  {
    LuaBase luaBase = (LuaBase) null;
    if (this.dict.TryGetValue(name, out luaBase))
      return (luaBase as LuaFunction).Call(args);
    IntPtr l = this.lua.L;
    int newTop = LuaDLL.lua_gettop(l);
    if (!LuaScriptMgr.PushLuaFunction(l, name))
      return (object[]) null;
    LuaFunction luaFunction = new LuaFunction(LuaDLL.luaL_ref(l, LuaIndexes.LUA_REGISTRYINDEX), this.lua);
    LuaDLL.lua_settop(l, newTop);
    object[] objArray = luaFunction.Call(args);
    luaFunction.Dispose();
    return objArray;
  }

  public LuaFunction GetLuaFunction(string name)
  {
    LuaBase luaFunction = (LuaBase) null;
    if (!this.dict.TryGetValue(name, out luaFunction))
    {
      IntPtr l = this.lua.L;
      int newTop = LuaDLL.lua_gettop(l);
      if (LuaScriptMgr.PushLuaFunction(l, name))
      {
        luaFunction = (LuaBase) new LuaFunction(LuaDLL.luaL_ref(l, LuaIndexes.LUA_REGISTRYINDEX), this.lua);
        luaFunction.name = name;
        this.dict.Add(name, luaFunction);
      }
      else
        Debugger.LogError("Lua function {0} not exists", (object) name);
      LuaDLL.lua_settop(l, newTop);
    }
    else
      luaFunction.AddRef();
    return luaFunction as LuaFunction;
  }

  public int GetFunctionRef(string name)
  {
    IntPtr l = this.lua.L;
    int newTop = LuaDLL.lua_gettop(l);
    int functionRef = -1;
    if (LuaScriptMgr.PushLuaFunction(l, name))
      functionRef = LuaDLL.luaL_ref(l, LuaIndexes.LUA_REGISTRYINDEX);
    else
      Debugger.LogWarning("Lua function {0} not exists", (object) name);
    LuaDLL.lua_settop(l, newTop);
    return functionRef;
  }

  public bool IsFuncExists(string name)
  {
    IntPtr l = this.lua.L;
    int newTop = LuaDLL.lua_gettop(l);
    if (!LuaScriptMgr.PushLuaFunction(l, name))
      return false;
    LuaDLL.lua_settop(l, newTop);
    return true;
  }

  public byte[] Loader(string name)
  {
    byte[] numArray = (byte[]) null;
    this.fileList.Add(name);
    string resName = Util.LuaPath(name);
    if (this.ResourceManagerRef != null)
    {
      Object instance = (Object) null;
      if (this.ResourceManagerRef.Load(resName, EResType.EResText, false, out instance, (OnLoadFinished) null) == EResLoadState.ELoadSuccess)
        numArray = (instance as TextAsset).bytes;
    }
    return numArray;
  }

  private static bool PushLuaTable(IntPtr L, string fullPath)
  {
    string[] strArray = fullPath.Split('.');
    int newTop = LuaDLL.lua_gettop(L);
    LuaDLL.lua_pushstring(L, strArray[0]);
    LuaDLL.lua_rawget(L, LuaIndexes.LUA_GLOBALSINDEX);
    if (LuaDLL.lua_type(L, -1) != LuaTypes.LUA_TTABLE)
    {
      LuaDLL.lua_settop(L, newTop);
      LuaDLL.lua_pushnil(L);
      Debugger.LogError("Push lua table {0} failed", (object) strArray[0]);
      return false;
    }
    for (int index = 1; index < strArray.Length; ++index)
    {
      LuaDLL.lua_pushstring(L, strArray[index]);
      LuaDLL.lua_rawget(L, -2);
      if (LuaDLL.lua_type(L, -1) != LuaTypes.LUA_TTABLE)
      {
        LuaDLL.lua_settop(L, newTop);
        Debugger.LogError("Push lua table {0} failed", (object) fullPath);
        return false;
      }
    }
    if (strArray.Length > 1)
    {
      LuaDLL.lua_insert(L, newTop + 1);
      LuaDLL.lua_settop(L, newTop + 1);
    }
    return true;
  }

  private static bool PushLuaFunction(IntPtr L, string fullPath)
  {
    int newTop = LuaDLL.lua_gettop(L);
    int length = fullPath.LastIndexOf('.');
    if (length > 0)
    {
      string fullPath1 = fullPath.Substring(0, length);
      if (LuaScriptMgr.PushLuaTable(L, fullPath1))
      {
        string str = fullPath.Substring(length + 1);
        LuaDLL.lua_pushstring(L, str);
        LuaDLL.lua_rawget(L, -2);
      }
      if (LuaDLL.lua_type(L, -1) != LuaTypes.LUA_TFUNCTION)
      {
        LuaDLL.lua_settop(L, newTop);
        return false;
      }
      LuaDLL.lua_insert(L, newTop + 1);
      LuaDLL.lua_settop(L, newTop + 1);
    }
    else
    {
      LuaDLL.lua_getglobal(L, fullPath);
      if (LuaDLL.lua_type(L, -1) != LuaTypes.LUA_TFUNCTION)
      {
        LuaDLL.lua_settop(L, newTop);
        return false;
      }
    }
    return true;
  }

  public LuaTable GetLuaTable(string tableName)
  {
    LuaBase luaTable = (LuaBase) null;
    if (!this.dict.TryGetValue(tableName, out luaTable))
    {
      IntPtr l = this.lua.L;
      int newTop = LuaDLL.lua_gettop(l);
      if (LuaScriptMgr.PushLuaTable(l, tableName))
      {
        luaTable = (LuaBase) new LuaTable(LuaDLL.luaL_ref(l, LuaIndexes.LUA_REGISTRYINDEX), this.lua);
        luaTable.name = tableName;
        this.dict.Add(tableName, luaTable);
      }
      LuaDLL.lua_settop(l, newTop);
    }
    else
      luaTable.AddRef();
    return luaTable as LuaTable;
  }

  public void RemoveLuaRes(string name) => this.dict.Remove(name);

  private static void CreateTable(IntPtr L, string fullPath)
  {
    string[] strArray = fullPath.Split('.');
    int num = LuaDLL.lua_gettop(L);
    if (strArray.Length > 1)
    {
      LuaDLL.lua_getglobal(L, strArray[0]);
      if (LuaDLL.lua_type(L, -1) == LuaTypes.LUA_TNIL)
      {
        LuaDLL.lua_pop(L, 1);
        LuaDLL.lua_createtable(L, 0, 0);
        LuaDLL.lua_pushstring(L, strArray[0]);
        LuaDLL.lua_pushvalue(L, -2);
        LuaDLL.lua_settable(L, LuaIndexes.LUA_GLOBALSINDEX);
      }
      for (int index = 1; index < strArray.Length - 1; ++index)
      {
        LuaDLL.lua_pushstring(L, strArray[index]);
        LuaDLL.lua_rawget(L, -2);
        if (LuaDLL.lua_type(L, -1) == LuaTypes.LUA_TNIL)
        {
          LuaDLL.lua_pop(L, 1);
          LuaDLL.lua_createtable(L, 0, 0);
          LuaDLL.lua_pushstring(L, strArray[index]);
          LuaDLL.lua_pushvalue(L, -2);
          LuaDLL.lua_rawset(L, -4);
        }
      }
      LuaDLL.lua_pushstring(L, strArray[strArray.Length - 1]);
      LuaDLL.lua_rawget(L, -2);
      if (LuaDLL.lua_type(L, -1) == LuaTypes.LUA_TNIL)
      {
        LuaDLL.lua_pop(L, 1);
        LuaDLL.lua_createtable(L, 0, 0);
        LuaDLL.lua_pushstring(L, strArray[strArray.Length - 1]);
        LuaDLL.lua_pushvalue(L, -2);
        LuaDLL.lua_rawset(L, -4);
      }
    }
    else
    {
      LuaDLL.lua_getglobal(L, strArray[0]);
      if (LuaDLL.lua_type(L, -1) == LuaTypes.LUA_TNIL)
      {
        LuaDLL.lua_pop(L, 1);
        LuaDLL.lua_createtable(L, 0, 0);
        LuaDLL.lua_pushstring(L, strArray[0]);
        LuaDLL.lua_pushvalue(L, -2);
        LuaDLL.lua_settable(L, LuaIndexes.LUA_GLOBALSINDEX);
      }
    }
    LuaDLL.lua_insert(L, num + 1);
    LuaDLL.lua_settop(L, num + 1);
  }

  public static void RegisterLib(IntPtr L, string libName, System.Type t, LuaMethod[] regs)
  {
    LuaScriptMgr.CreateTable(L, libName);
    LuaDLL.luaL_getmetatable(L, t.AssemblyQualifiedName);
    if (LuaDLL.lua_isnil(L, -1))
    {
      LuaDLL.lua_pop(L, 1);
      LuaDLL.luaL_newmetatable(L, t.AssemblyQualifiedName);
    }
    LuaDLL.lua_pushstring(L, "ToLua_EnumIndex");
    LuaDLL.lua_rawget(L, LuaIndexes.LUA_REGISTRYINDEX);
    LuaDLL.lua_setfield(L, -2, "__index");
    LuaDLL.lua_pushstring(L, "__gc");
    LuaDLL.lua_pushstdcallcfunction(L, new LuaCSFunction(LuaScriptMgr.__gc));
    LuaDLL.lua_rawset(L, -3);
    for (int index = 0; index < regs.Length - 1; ++index)
    {
      LuaDLL.lua_pushstring(L, regs[index].name);
      LuaDLL.lua_pushstdcallcfunction(L, regs[index].func);
      LuaDLL.lua_rawset(L, -3);
    }
    int index1 = regs.Length - 1;
    LuaDLL.lua_pushstring(L, regs[index1].name);
    LuaDLL.lua_pushstdcallcfunction(L, regs[index1].func);
    LuaDLL.lua_rawset(L, -4);
    LuaDLL.lua_setmetatable(L, -2);
    LuaDLL.lua_settop(L, 0);
  }

  public static void RegisterLib(IntPtr L, string libName, LuaMethod[] regs)
  {
    LuaScriptMgr.CreateTable(L, libName);
    for (int index = 0; index < regs.Length; ++index)
    {
      LuaDLL.lua_pushstring(L, regs[index].name);
      LuaDLL.lua_pushstdcallcfunction(L, regs[index].func);
      LuaDLL.lua_rawset(L, -3);
    }
    LuaDLL.lua_settop(L, 0);
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  public static int __gc(IntPtr luaState)
  {
    int udata = LuaDLL.luanet_rawnetobj(luaState, 1);
    if (udata != -1)
      ObjectTranslator.FromState(luaState).collectObject(udata);
    return 0;
  }

  public static void RegisterLib(
    IntPtr L,
    string libName,
    System.Type t,
    LuaMethod[] regs,
    LuaField[] fields,
    System.Type baseType)
  {
    LuaScriptMgr.CreateTable(L, libName);
    LuaDLL.luaL_getmetatable(L, t.AssemblyQualifiedName);
    if (LuaDLL.lua_isnil(L, -1))
    {
      LuaDLL.lua_pop(L, 1);
      LuaDLL.luaL_newmetatable(L, t.AssemblyQualifiedName);
    }
    if ((object) baseType != null)
    {
      LuaDLL.luaL_getmetatable(L, baseType.AssemblyQualifiedName);
      if (LuaDLL.lua_isnil(L, -1))
      {
        LuaDLL.lua_pop(L, 1);
        LuaDLL.luaL_newmetatable(L, baseType.AssemblyQualifiedName);
        LuaScriptMgr.checkBaseType.Add(baseType);
      }
      else
        LuaScriptMgr.checkBaseType.Remove(baseType);
      LuaDLL.lua_setmetatable(L, -2);
    }
    LuaDLL.tolua_setindex(L);
    LuaDLL.tolua_setnewindex(L);
    LuaDLL.lua_pushstring(L, "__call");
    LuaDLL.lua_pushstring(L, "ToLua_TableCall");
    LuaDLL.lua_rawget(L, LuaIndexes.LUA_REGISTRYINDEX);
    LuaDLL.lua_rawset(L, -3);
    LuaDLL.lua_pushstring(L, "__gc");
    LuaDLL.lua_pushstdcallcfunction(L, new LuaCSFunction(LuaScriptMgr.__gc));
    LuaDLL.lua_rawset(L, -3);
    for (int index = 0; index < regs.Length; ++index)
    {
      LuaDLL.lua_pushstring(L, regs[index].name);
      LuaDLL.lua_pushstdcallcfunction(L, regs[index].func);
      LuaDLL.lua_rawset(L, -3);
    }
    for (int index = 0; index < fields.Length; ++index)
    {
      LuaDLL.lua_pushstring(L, fields[index].name);
      LuaDLL.lua_createtable(L, 2, 0);
      if (fields[index].getter != null)
      {
        LuaDLL.lua_pushstdcallcfunction(L, fields[index].getter);
        LuaDLL.lua_rawseti(L, -2, 1);
      }
      if (fields[index].setter != null)
      {
        LuaDLL.lua_pushstdcallcfunction(L, fields[index].setter);
        LuaDLL.lua_rawseti(L, -2, 2);
      }
      LuaDLL.lua_rawset(L, -3);
    }
    LuaDLL.lua_setmetatable(L, -2);
    LuaDLL.lua_settop(L, 0);
    LuaScriptMgr.checkBaseType.Remove(t);
  }

  public static double GetNumber(IntPtr L, int stackPos)
  {
    if (LuaDLL.lua_isnumber(L, stackPos))
      return LuaDLL.lua_tonumber(L, stackPos);
    LuaDLL.luaL_typerror(L, stackPos, "number");
    return 0.0;
  }

  public static bool GetBoolean(IntPtr L, int stackPos)
  {
    if (LuaDLL.lua_isboolean(L, stackPos))
      return LuaDLL.lua_toboolean(L, stackPos);
    LuaDLL.luaL_typerror(L, stackPos, "boolean");
    return false;
  }

  public static string GetString(IntPtr L, int stackPos)
  {
    string luaString = LuaScriptMgr.GetLuaString(L, stackPos);
    if (luaString == null)
      LuaDLL.luaL_typerror(L, stackPos, "string");
    return luaString;
  }

  public static LuaFunction GetFunction(IntPtr L, int stackPos)
  {
    if (LuaDLL.lua_type(L, stackPos) != LuaTypes.LUA_TFUNCTION)
      return (LuaFunction) null;
    LuaDLL.lua_pushvalue(L, stackPos);
    return new LuaFunction(LuaDLL.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX), LuaScriptMgr.GetTranslator(L).interpreter);
  }

  public static LuaFunction ToLuaFunction(IntPtr L, int stackPos)
  {
    LuaDLL.lua_pushvalue(L, stackPos);
    return new LuaFunction(LuaDLL.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX), LuaScriptMgr.GetTranslator(L).interpreter);
  }

  public static LuaFunction GetLuaFunction(IntPtr L, int stackPos)
  {
    LuaFunction function = LuaScriptMgr.GetFunction(L, stackPos);
    if (function != null)
      return function;
    LuaDLL.luaL_typerror(L, stackPos, "function");
    return (LuaFunction) null;
  }

  private static LuaTable ToLuaTable(IntPtr L, int stackPos)
  {
    LuaDLL.lua_pushvalue(L, stackPos);
    return new LuaTable(LuaDLL.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX), LuaScriptMgr.GetTranslator(L).interpreter);
  }

  private static LuaTable GetTable(IntPtr L, int stackPos)
  {
    if (LuaDLL.lua_type(L, stackPos) != LuaTypes.LUA_TTABLE)
      return (LuaTable) null;
    LuaDLL.lua_pushvalue(L, stackPos);
    return new LuaTable(LuaDLL.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX), LuaScriptMgr.GetTranslator(L).interpreter);
  }

  public static LuaTable GetLuaTable(IntPtr L, int stackPos)
  {
    LuaTable table = LuaScriptMgr.GetTable(L, stackPos);
    if (table != null)
      return table;
    LuaDLL.luaL_typerror(L, stackPos, "table");
    return (LuaTable) null;
  }

  public static object GetLuaObject(IntPtr L, int stackPos)
  {
    return LuaScriptMgr.GetTranslator(L).getRawNetObject(L, stackPos);
  }

  public static object GetNetObjectSelf(IntPtr L, int stackPos, string type)
  {
    object rawNetObject = LuaScriptMgr.GetTranslator(L).getRawNetObject(L, stackPos);
    if (rawNetObject != null)
      return rawNetObject;
    LuaDLL.luaL_argerror(L, stackPos, string.Format("{0} expected, got nil", (object) type));
    return (object) null;
  }

  public static object GetUnityObjectSelf(IntPtr L, int stackPos, string type)
  {
    object rawNetObject = LuaScriptMgr.GetTranslator(L).getRawNetObject(L, stackPos);
    if (!Object.op_Equality((Object) rawNetObject, (Object) null))
      return rawNetObject;
    LuaDLL.luaL_argerror(L, stackPos, string.Format("{0} expected, got nil", (object) type));
    return (object) null;
  }

  public static object GetTrackedObjectSelf(IntPtr L, int stackPos, string type)
  {
    object rawNetObject = LuaScriptMgr.GetTranslator(L).getRawNetObject(L, stackPos);
    if (!TrackedReference.op_Equality((TrackedReference) rawNetObject, (TrackedReference) null))
      return rawNetObject;
    LuaDLL.luaL_argerror(L, stackPos, string.Format("{0} expected, got nil", (object) type));
    return (object) null;
  }

  public static T GetNetObject<T>(IntPtr L, int stackPos)
  {
    return (T) LuaScriptMgr.GetNetObject(L, stackPos, typeof (T));
  }

  public static object GetNetObject(IntPtr L, int stackPos, System.Type type)
  {
    if (LuaDLL.lua_isnil(L, stackPos))
      return (object) null;
    object luaObject = LuaScriptMgr.GetLuaObject(L, stackPos);
    if (luaObject == null)
    {
      LuaDLL.luaL_argerror(L, stackPos, string.Format("{0} expected, got nil", (object) type.Name));
      return (object) null;
    }
    System.Type type1 = luaObject.GetType();
    if ((object) type == (object) type1 || type.IsAssignableFrom(type1))
      return luaObject;
    LuaDLL.luaL_argerror(L, stackPos, string.Format("{0} expected, got {1}", (object) type.Name, (object) type1.Name));
    return (object) null;
  }

  public static T GetUnityObject<T>(IntPtr L, int stackPos) where T : Object
  {
    return (T) LuaScriptMgr.GetUnityObject(L, stackPos, typeof (T));
  }

  public static Object GetUnityObject(IntPtr L, int stackPos, System.Type type)
  {
    if (LuaDLL.lua_isnil(L, stackPos))
      return (Object) null;
    object luaObject = LuaScriptMgr.GetLuaObject(L, stackPos);
    if (luaObject == null)
    {
      LuaDLL.luaL_argerror(L, stackPos, string.Format("{0} expected, got nil", (object) type.Name));
      return (Object) null;
    }
    Object unityObject = (Object) luaObject;
    if (Object.op_Equality(unityObject, (Object) null))
    {
      LuaDLL.luaL_argerror(L, stackPos, string.Format("{0} expected, got nil", (object) type.Name));
      return (Object) null;
    }
    System.Type type1 = unityObject.GetType();
    if ((object) type == (object) type1 || type1.IsSubclassOf(type))
      return unityObject;
    LuaDLL.luaL_argerror(L, stackPos, string.Format("{0} expected, got {1}", (object) type.Name, (object) type1.Name));
    return (Object) null;
  }

  public static T GetTrackedObject<T>(IntPtr L, int stackPos) where T : TrackedReference
  {
    return (T) LuaScriptMgr.GetTrackedObject(L, stackPos, typeof (T));
  }

  public static TrackedReference GetTrackedObject(IntPtr L, int stackPos, System.Type type)
  {
    if (LuaDLL.lua_isnil(L, stackPos))
      return (TrackedReference) null;
    object luaObject = LuaScriptMgr.GetLuaObject(L, stackPos);
    if (luaObject == null)
    {
      LuaDLL.luaL_argerror(L, stackPos, string.Format("{0} expected, got nil", (object) type.Name));
      return (TrackedReference) null;
    }
    TrackedReference trackedObject = luaObject as TrackedReference;
    if (TrackedReference.op_Equality(trackedObject, (TrackedReference) null))
    {
      LuaDLL.luaL_argerror(L, stackPos, string.Format("{0} expected, got nil", (object) type.Name));
      return (TrackedReference) null;
    }
    System.Type type1 = luaObject.GetType();
    if ((object) type == (object) type1 || type1.IsSubclassOf(type))
      return trackedObject;
    LuaDLL.luaL_argerror(L, stackPos, string.Format("{0} expected, got {1}", (object) type.Name, (object) type1.Name));
    return (TrackedReference) null;
  }

  public static System.Type GetTypeObject(IntPtr L, int stackPos)
  {
    object luaObject = LuaScriptMgr.GetLuaObject(L, stackPos);
    if (luaObject == null || (object) luaObject.GetType() != (object) LuaScriptMgr.monoType)
      LuaDLL.luaL_argerror(L, stackPos, string.Format("Type expected, got {0}", luaObject != null ? (object) luaObject.GetType().Name : (object) "nil"));
    return (System.Type) luaObject;
  }

  public static bool IsClassOf(System.Type child, System.Type parent)
  {
    return (object) child == (object) parent || parent.IsAssignableFrom(child);
  }

  private static ObjectTranslator GetTranslator(IntPtr L)
  {
    return LuaScriptMgr._translator == null ? ObjectTranslator.FromState(L) : LuaScriptMgr._translator;
  }

  public static void PushVarObject(IntPtr L, object o)
  {
    if (o == null)
    {
      LuaDLL.lua_pushnil(L);
    }
    else
    {
      System.Type type = o.GetType();
      if (type.IsValueType)
      {
        if ((object) type == (object) typeof (bool))
        {
          bool flag = (bool) o;
          LuaDLL.lua_pushboolean(L, flag);
        }
        else if (type.IsEnum)
          LuaScriptMgr.Push(L, (Enum) o);
        else if (type.IsPrimitive)
        {
          double number = Convert.ToDouble(o);
          LuaDLL.lua_pushnumber(L, number);
        }
        else if ((object) type == (object) typeof (Vector3))
          LuaScriptMgr.Push(L, (Vector3) o);
        else if ((object) type == (object) typeof (Vector2))
          LuaScriptMgr.Push(L, (Vector2) o);
        else if ((object) type == (object) typeof (Vector4))
          LuaScriptMgr.Push(L, (Vector4) o);
        else if ((object) type == (object) typeof (Quaternion))
          LuaScriptMgr.Push(L, (Quaternion) o);
        else if ((object) type == (object) typeof (Color))
          LuaScriptMgr.Push(L, (Color) o);
        else if ((object) type == (object) typeof (RaycastHit))
          LuaScriptMgr.Push(L, (RaycastHit) o);
        else if ((object) type == (object) typeof (Touch))
          LuaScriptMgr.Push(L, (Touch) o);
        else if ((object) type == (object) typeof (Ray))
          LuaScriptMgr.Push(L, (Ray) o);
        else
          LuaScriptMgr.PushValue(L, o);
      }
      else if (type.IsArray)
        LuaScriptMgr.PushArray(L, (Array) o);
      else if ((object) type == (object) typeof (LuaCSFunction))
        LuaScriptMgr.GetTranslator(L).pushFunction(L, (LuaCSFunction) o);
      else if (type.IsSubclassOf(typeof (Delegate)))
        LuaScriptMgr.Push(L, (Delegate) o);
      else if (LuaScriptMgr.IsClassOf(type, typeof (IEnumerator)))
        LuaScriptMgr.Push(L, (IEnumerator) o);
      else if ((object) type == (object) typeof (string))
      {
        string str = (string) o;
        LuaDLL.lua_pushstring(L, str);
      }
      else if ((object) type == (object) typeof (LuaStringBuffer))
      {
        LuaStringBuffer luaStringBuffer = (LuaStringBuffer) o;
        LuaDLL.lua_pushlstring(L, luaStringBuffer.buffer, luaStringBuffer.buffer.Length);
      }
      else if (type.IsSubclassOf(typeof (Object)))
      {
        if (Object.op_Equality((Object) o, (Object) null))
          LuaDLL.lua_pushnil(L);
        else
          LuaScriptMgr.PushObject(L, o);
      }
      else if ((object) type == (object) typeof (LuaTable))
        ((LuaTable) o).push(L);
      else if ((object) type == (object) typeof (LuaFunction))
        ((LuaFunction) o).push(L);
      else if ((object) type == (object) LuaScriptMgr.monoType)
        LuaScriptMgr.Push(L, (System.Type) o);
      else if (type.IsSubclassOf(typeof (TrackedReference)))
      {
        if (TrackedReference.op_Equality((TrackedReference) o, (TrackedReference) null))
          LuaDLL.lua_pushnil(L);
        else
          LuaScriptMgr.PushObject(L, o);
      }
      else
        LuaScriptMgr.PushObject(L, o);
    }
  }

  public static void PushObject(IntPtr L, object o)
  {
    LuaScriptMgr.GetTranslator(L).pushObject(L, o, "luaNet_metatable");
  }

  public static void Push(IntPtr L, Object obj)
  {
    LuaScriptMgr.PushObject(L, !Object.op_Equality(obj, (Object) null) ? (object) obj : (object) (Object) null);
  }

  public static void Push(IntPtr L, TrackedReference obj)
  {
    LuaScriptMgr.PushObject(L, !TrackedReference.op_Equality(obj, (TrackedReference) null) ? (object) obj : (object) (TrackedReference) null);
  }

  private static void PushMetaObject(IntPtr L, ObjectTranslator translator, object o, int metaRef)
  {
    if (o == null)
    {
      LuaDLL.lua_pushnil(L);
    }
    else
    {
      int weakTableRef = translator.weakTableRef;
      int num = -1;
      if (translator.objectsBackMap.TryGetValue(o, out num))
      {
        if (LuaDLL.tolua_pushudata(L, weakTableRef, num))
          return;
        translator.collectObject(num);
      }
      int index = translator.addObject(o, false);
      LuaDLL.tolua_pushnewudata(L, metaRef, weakTableRef, index);
    }
  }

  public static void Push(IntPtr L, System.Type o)
  {
    LuaScriptMgr mgrFromLuaState = LuaScriptMgr.GetMgrFromLuaState(L);
    ObjectTranslator translator = mgrFromLuaState.lua.translator;
    LuaScriptMgr.PushMetaObject(L, translator, (object) o, mgrFromLuaState.typeMetaRef);
  }

  public static void Push(IntPtr L, Delegate o)
  {
    LuaScriptMgr mgrFromLuaState = LuaScriptMgr.GetMgrFromLuaState(L);
    ObjectTranslator translator = mgrFromLuaState.lua.translator;
    LuaScriptMgr.PushMetaObject(L, translator, (object) o, mgrFromLuaState.delegateMetaRef);
  }

  public static void Push(IntPtr L, IEnumerator o)
  {
    LuaScriptMgr mgrFromLuaState = LuaScriptMgr.GetMgrFromLuaState(L);
    ObjectTranslator translator = mgrFromLuaState.lua.translator;
    LuaScriptMgr.PushMetaObject(L, translator, (object) o, mgrFromLuaState.iterMetaRef);
  }

  public static void PushArray(IntPtr L, Array o)
  {
    LuaScriptMgr mgrFromLuaState = LuaScriptMgr.GetMgrFromLuaState(L);
    ObjectTranslator translator = mgrFromLuaState.lua.translator;
    LuaScriptMgr.PushMetaObject(L, translator, (object) o, mgrFromLuaState.arrayMetaRef);
  }

  public static void PushValue(IntPtr L, object obj)
  {
    LuaScriptMgr.GetTranslator(L).PushValueResult(L, obj);
  }

  public static void Push(IntPtr L, bool b) => LuaDLL.lua_pushboolean(L, b);

  public static void Push(IntPtr L, string str) => LuaDLL.lua_pushstring(L, str);

  public static void Push(IntPtr L, char d) => LuaDLL.lua_pushinteger(L, (int) d);

  public static void Push(IntPtr L, sbyte d) => LuaDLL.lua_pushinteger(L, (int) d);

  public static void Push(IntPtr L, byte d) => LuaDLL.lua_pushinteger(L, (int) d);

  public static void Push(IntPtr L, short d) => LuaDLL.lua_pushinteger(L, (int) d);

  public static void Push(IntPtr L, ushort d) => LuaDLL.lua_pushinteger(L, (int) d);

  public static void Push(IntPtr L, int d) => LuaDLL.lua_pushinteger(L, d);

  public static void Push(IntPtr L, uint d) => LuaDLL.lua_pushnumber(L, (double) d);

  public static void Push(IntPtr L, long d) => LuaDLL.lua_pushnumber(L, (double) d);

  public static void Push(IntPtr L, ulong d) => LuaDLL.lua_pushnumber(L, (double) d);

  public static void Push(IntPtr L, float d) => LuaDLL.lua_pushnumber(L, (double) d);

  public static void Push(IntPtr L, Decimal d) => LuaDLL.lua_pushnumber(L, (double) d);

  public static void Push(IntPtr L, double d) => LuaDLL.lua_pushnumber(L, d);

  public static void Push(IntPtr L, IntPtr p) => LuaDLL.lua_pushlightuserdata(L, p);

  public static void Push(IntPtr L, ILuaGeneratedType o)
  {
    if (o == null)
      LuaDLL.lua_pushnil(L);
    else
      o.__luaInterface_getLuaTable().push(L);
  }

  public static void Push(IntPtr L, LuaTable table)
  {
    if (table == null)
      LuaDLL.lua_pushnil(L);
    else
      table.push(L);
  }

  public static void Push(IntPtr L, LuaFunction func)
  {
    if (func == null)
      LuaDLL.lua_pushnil(L);
    else
      func.push();
  }

  public static void Push(IntPtr L, LuaCSFunction func)
  {
    if (func == null)
      LuaDLL.lua_pushnil(L);
    else
      LuaScriptMgr.GetTranslator(L).pushFunction(L, func);
  }

  public static bool CheckTypes(IntPtr L, int begin, System.Type type0)
  {
    return LuaScriptMgr.CheckType(L, type0, begin);
  }

  public static bool CheckTypes(IntPtr L, int begin, System.Type type0, System.Type type1)
  {
    return LuaScriptMgr.CheckType(L, type0, begin) && LuaScriptMgr.CheckType(L, type1, begin + 1);
  }

  public static bool CheckTypes(IntPtr L, int begin, System.Type type0, System.Type type1, System.Type type2)
  {
    return LuaScriptMgr.CheckType(L, type0, begin) && LuaScriptMgr.CheckType(L, type1, begin + 1) && LuaScriptMgr.CheckType(L, type2, begin + 2);
  }

  public static bool CheckTypes(
    IntPtr L,
    int begin,
    System.Type type0,
    System.Type type1,
    System.Type type2,
    System.Type type3)
  {
    return LuaScriptMgr.CheckType(L, type0, begin) && LuaScriptMgr.CheckType(L, type1, begin + 1) && LuaScriptMgr.CheckType(L, type2, begin + 2) && LuaScriptMgr.CheckType(L, type3, begin + 3);
  }

  public static bool CheckTypes(
    IntPtr L,
    int begin,
    System.Type type0,
    System.Type type1,
    System.Type type2,
    System.Type type3,
    System.Type type4)
  {
    return LuaScriptMgr.CheckType(L, type0, begin) && LuaScriptMgr.CheckType(L, type1, begin + 1) && LuaScriptMgr.CheckType(L, type2, begin + 2) && LuaScriptMgr.CheckType(L, type3, begin + 3) && LuaScriptMgr.CheckType(L, type4, begin + 4);
  }

  public static bool CheckTypes(
    IntPtr L,
    int begin,
    System.Type type0,
    System.Type type1,
    System.Type type2,
    System.Type type3,
    System.Type type4,
    System.Type type5)
  {
    return LuaScriptMgr.CheckType(L, type0, begin) && LuaScriptMgr.CheckType(L, type1, begin + 1) && LuaScriptMgr.CheckType(L, type2, begin + 2) && LuaScriptMgr.CheckType(L, type3, begin + 3) && LuaScriptMgr.CheckType(L, type4, begin + 4) && LuaScriptMgr.CheckType(L, type5, begin + 5);
  }

  public static bool CheckTypes(
    IntPtr L,
    int begin,
    System.Type type0,
    System.Type type1,
    System.Type type2,
    System.Type type3,
    System.Type type4,
    System.Type type5,
    System.Type type6)
  {
    return LuaScriptMgr.CheckType(L, type0, begin) && LuaScriptMgr.CheckType(L, type1, begin + 1) && LuaScriptMgr.CheckType(L, type2, begin + 2) && LuaScriptMgr.CheckType(L, type3, begin + 3) && LuaScriptMgr.CheckType(L, type4, begin + 4) && LuaScriptMgr.CheckType(L, type5, begin + 5) && LuaScriptMgr.CheckType(L, type6, begin + 6);
  }

  public static bool CheckTypes(
    IntPtr L,
    int begin,
    System.Type type0,
    System.Type type1,
    System.Type type2,
    System.Type type3,
    System.Type type4,
    System.Type type5,
    System.Type type6,
    System.Type type7)
  {
    return LuaScriptMgr.CheckType(L, type0, begin) && LuaScriptMgr.CheckType(L, type1, begin + 1) && LuaScriptMgr.CheckType(L, type2, begin + 2) && LuaScriptMgr.CheckType(L, type3, begin + 3) && LuaScriptMgr.CheckType(L, type4, begin + 4) && LuaScriptMgr.CheckType(L, type5, begin + 5) && LuaScriptMgr.CheckType(L, type6, begin + 6) && LuaScriptMgr.CheckType(L, type7, begin + 7);
  }

  public static bool CheckTypes(
    IntPtr L,
    int begin,
    System.Type type0,
    System.Type type1,
    System.Type type2,
    System.Type type3,
    System.Type type4,
    System.Type type5,
    System.Type type6,
    System.Type type7,
    System.Type type8)
  {
    return LuaScriptMgr.CheckType(L, type0, begin) && LuaScriptMgr.CheckType(L, type1, begin + 1) && LuaScriptMgr.CheckType(L, type2, begin + 2) && LuaScriptMgr.CheckType(L, type3, begin + 3) && LuaScriptMgr.CheckType(L, type4, begin + 4) && LuaScriptMgr.CheckType(L, type5, begin + 5) && LuaScriptMgr.CheckType(L, type6, begin + 6) && LuaScriptMgr.CheckType(L, type7, begin + 7) && LuaScriptMgr.CheckType(L, type8, begin + 8);
  }

  public static bool CheckTypes(
    IntPtr L,
    int begin,
    System.Type type0,
    System.Type type1,
    System.Type type2,
    System.Type type3,
    System.Type type4,
    System.Type type5,
    System.Type type6,
    System.Type type7,
    System.Type type8,
    System.Type type9)
  {
    return LuaScriptMgr.CheckType(L, type0, begin) && LuaScriptMgr.CheckType(L, type1, begin + 1) && LuaScriptMgr.CheckType(L, type2, begin + 2) && LuaScriptMgr.CheckType(L, type3, begin + 3) && LuaScriptMgr.CheckType(L, type4, begin + 4) && LuaScriptMgr.CheckType(L, type5, begin + 5) && LuaScriptMgr.CheckType(L, type6, begin + 6) && LuaScriptMgr.CheckType(L, type7, begin + 7) && LuaScriptMgr.CheckType(L, type8, begin + 8) && LuaScriptMgr.CheckType(L, type9, begin + 9);
  }

  public static bool CheckTypes(IntPtr L, int begin, params System.Type[] types)
  {
    for (int index = 0; index < types.Length; ++index)
    {
      if (!LuaScriptMgr.CheckType(L, types[index], index + begin))
        return false;
    }
    return true;
  }

  public static bool CheckParamsType(IntPtr L, System.Type t, int begin, int count)
  {
    if ((object) t == (object) typeof (object))
      return true;
    for (int index = 0; index < count; ++index)
    {
      if (!LuaScriptMgr.CheckType(L, t, index + begin))
        return false;
    }
    return true;
  }

  private static bool CheckTableType(IntPtr L, System.Type t, int stackPos)
  {
    if (t.IsArray || (object) t == (object) typeof (LuaTable))
      return true;
    if (t.IsValueType)
    {
      int newTop = LuaDLL.lua_gettop(L);
      LuaDLL.lua_pushvalue(L, stackPos);
      LuaDLL.lua_pushstring(L, "class");
      LuaDLL.lua_gettable(L, -2);
      string str = LuaDLL.lua_tostring(L, -1);
      LuaDLL.lua_settop(L, newTop);
      switch (str)
      {
        case "Vector3":
          return (object) t == (object) typeof (Vector3);
        case "Vector2":
          return (object) t == (object) typeof (Vector2);
        case "Quaternion":
          return (object) t == (object) typeof (Quaternion);
        case "Color":
          return (object) t == (object) typeof (Color);
        case "Vector4":
          return (object) t == (object) typeof (Vector4);
        case "Ray":
          return (object) t == (object) typeof (Ray);
      }
    }
    return false;
  }

  public static bool CheckType(IntPtr L, System.Type t, int pos)
  {
    if ((object) t == (object) typeof (object))
      return true;
    LuaTypes luaType = LuaDLL.lua_type(L, pos);
    switch (luaType)
    {
      case LuaTypes.LUA_TNIL:
        return (object) t == null;
      case LuaTypes.LUA_TBOOLEAN:
        return (object) t == (object) typeof (bool);
      case LuaTypes.LUA_TNUMBER:
        return t.IsPrimitive;
      case LuaTypes.LUA_TSTRING:
        return (object) t == (object) typeof (string);
      case LuaTypes.LUA_TTABLE:
        return LuaScriptMgr.CheckTableType(L, t, pos);
      case LuaTypes.LUA_TFUNCTION:
        return (object) t == (object) typeof (LuaFunction);
      case LuaTypes.LUA_TUSERDATA:
        return LuaScriptMgr.CheckUserData(L, luaType, t, pos);
      default:
        return false;
    }
  }

  private static bool CheckUserData(IntPtr L, LuaTypes luaType, System.Type t, int pos)
  {
    System.Type type = LuaScriptMgr.GetLuaObject(L, pos).GetType();
    if ((object) t == (object) type)
      return true;
    return (object) t == (object) typeof (System.Type) ? (object) type == (object) LuaScriptMgr.monoType : t.IsAssignableFrom(type);
  }

  public static object[] GetParamsObject(IntPtr L, int stackPos, int count)
  {
    List<object> objectList = new List<object>();
    while (count > 0)
    {
      object varObject = LuaScriptMgr.GetVarObject(L, stackPos);
      ++stackPos;
      --count;
      if (varObject != null)
      {
        objectList.Add(varObject);
      }
      else
      {
        LuaDLL.luaL_argerror(L, stackPos, "object expected, got nil");
        break;
      }
    }
    return objectList.ToArray();
  }

  public static T[] GetParamsObject<T>(IntPtr L, int stackPos, int count)
  {
    List<T> objList = new List<T>();
    T obj1 = default (T);
    while (count > 0)
    {
      object luaObject = LuaScriptMgr.GetLuaObject(L, stackPos);
      ++stackPos;
      --count;
      if (luaObject != null && (object) luaObject.GetType() == (object) typeof (T))
      {
        T obj2 = (T) luaObject;
        objList.Add(obj2);
      }
      else
      {
        LuaDLL.luaL_argerror(L, stackPos, string.Format("{0} expected, got nil", (object) typeof (T).Name));
        break;
      }
    }
    return objList.ToArray();
  }

  public static T[] GetArrayObject<T>(IntPtr L, int stackPos)
  {
    switch (LuaDLL.lua_type(L, stackPos))
    {
      case LuaTypes.LUA_TNIL:
        return (T[]) null;
      case LuaTypes.LUA_TTABLE:
        int index = 1;
        T obj = default (T);
        List<T> objList = new List<T>();
        LuaDLL.lua_pushvalue(L, stackPos);
        System.Type t = typeof (T);
        while (true)
        {
          LuaDLL.lua_rawgeti(L, -1, index);
          if (LuaDLL.lua_type(L, -1) != LuaTypes.LUA_TNIL)
          {
            if (LuaScriptMgr.CheckType(L, t, -1))
            {
              T varObject = (T) LuaScriptMgr.GetVarObject(L, -1);
              objList.Add(varObject);
              LuaDLL.lua_pop(L, 1);
              ++index;
            }
            else
              goto label_5;
          }
          else
            break;
        }
        LuaDLL.lua_pop(L, 1);
        return objList.ToArray();
label_5:
        LuaDLL.lua_pop(L, 1);
        break;
      case LuaTypes.LUA_TUSERDATA:
        T[] netObject = LuaScriptMgr.GetNetObject<T[]>(L, stackPos);
        if (netObject != null)
          return netObject;
        break;
    }
    LuaDLL.luaL_error(L, string.Format("invalid arguments to method: {0}, pos {1}", (object) LuaScriptMgr.GetErrorFunc(1), (object) stackPos));
    return (T[]) null;
  }

  private static string GetErrorFunc(int skip)
  {
    string empty = string.Empty;
    StackTrace stackTrace = new StackTrace(skip, true);
    int num1 = 0;
    StackFrame frame;
    string fileName;
    do
    {
      frame = stackTrace.GetFrame(num1++);
      fileName = frame.GetFileName();
    }
    while (!fileName.Contains("Wrap"));
    int num2 = fileName.LastIndexOf('\\');
    int num3 = fileName.LastIndexOf("Wrap");
    return string.Format("{0}.{1}", (object) fileName.Substring(num2 + 1, num3 - num2 - 1), (object) frame.GetMethod().Name);
  }

  public static string GetLuaString(IntPtr L, int stackPos)
  {
    LuaTypes luaTypes = LuaDLL.lua_type(L, stackPos);
    string luaString1 = (string) null;
    string luaString2;
    switch (luaTypes)
    {
      case LuaTypes.LUA_TNIL:
        return luaString1;
      case LuaTypes.LUA_TBOOLEAN:
        luaString2 = LuaDLL.lua_toboolean(L, stackPos).ToString();
        break;
      case LuaTypes.LUA_TNUMBER:
        luaString2 = LuaDLL.lua_tonumber(L, stackPos).ToString();
        break;
      case LuaTypes.LUA_TSTRING:
        luaString2 = LuaDLL.lua_tostring(L, stackPos);
        break;
      case LuaTypes.LUA_TUSERDATA:
        object luaObject = LuaScriptMgr.GetLuaObject(L, stackPos);
        if (luaObject == null)
        {
          LuaDLL.luaL_argerror(L, stackPos, "string expected, got nil");
          return string.Empty;
        }
        luaString2 = (object) luaObject.GetType() != (object) typeof (string) ? luaObject.ToString() : (string) luaObject;
        break;
      default:
        LuaDLL.lua_getglobal(L, "tostring");
        LuaDLL.lua_pushvalue(L, stackPos);
        LuaDLL.lua_call(L, 1, 1);
        luaString2 = LuaDLL.lua_tostring(L, -1);
        LuaDLL.lua_pop(L, 1);
        break;
    }
    return luaString2;
  }

  public static string[] GetParamsString(IntPtr L, int stackPos, int count)
  {
    List<string> stringList = new List<string>();
    while (count > 0)
    {
      string luaString = LuaScriptMgr.GetLuaString(L, stackPos);
      ++stackPos;
      --count;
      if (luaString == null)
      {
        LuaDLL.luaL_argerror(L, stackPos, "string expected, got nil");
        break;
      }
      stringList.Add(luaString);
    }
    return stringList.ToArray();
  }

  public static string[] GetArrayString(IntPtr L, int stackPos)
  {
    switch (LuaDLL.lua_type(L, stackPos))
    {
      case LuaTypes.LUA_TTABLE:
        int index = 1;
        List<string> stringList = new List<string>();
        LuaDLL.lua_pushvalue(L, stackPos);
        while (true)
        {
          LuaDLL.lua_rawgeti(L, -1, index);
          if (LuaDLL.lua_type(L, -1) != LuaTypes.LUA_TNIL)
          {
            string luaString = LuaScriptMgr.GetLuaString(L, -1);
            stringList.Add(luaString);
            LuaDLL.lua_pop(L, 1);
            ++index;
          }
          else
            break;
        }
        LuaDLL.lua_pop(L, 1);
        return stringList.ToArray();
      case LuaTypes.LUA_TUSERDATA:
        string[] netObject = LuaScriptMgr.GetNetObject<string[]>(L, stackPos);
        if (netObject != null)
          return netObject;
        break;
    }
    LuaDLL.luaL_error(L, string.Format("invalid arguments to method: {0}, pos {1}", (object) LuaScriptMgr.GetErrorFunc(1), (object) stackPos));
    return (string[]) null;
  }

  public static T[] GetArrayNumber<T>(IntPtr L, int stackPos)
  {
    switch (LuaDLL.lua_type(L, stackPos))
    {
      case LuaTypes.LUA_TTABLE:
        int index = 1;
        T obj1 = default (T);
        List<T> objList = new List<T>();
        LuaDLL.lua_pushvalue(L, stackPos);
        while (true)
        {
          LuaDLL.lua_rawgeti(L, -1, index);
          switch (LuaDLL.lua_type(L, -1))
          {
            case LuaTypes.LUA_TNIL:
              goto label_3;
            case LuaTypes.LUA_TNUMBER:
              T obj2 = (T) Convert.ChangeType((object) LuaDLL.lua_tonumber(L, -1), typeof (T));
              objList.Add(obj2);
              LuaDLL.lua_pop(L, 1);
              ++index;
              continue;
            default:
              goto label_7;
          }
        }
label_3:
        LuaDLL.lua_pop(L, 1);
        return objList.ToArray();
      case LuaTypes.LUA_TUSERDATA:
        T[] netObject = LuaScriptMgr.GetNetObject<T[]>(L, stackPos);
        if (netObject != null)
          return netObject;
        break;
    }
label_7:
    LuaDLL.luaL_error(L, string.Format("invalid arguments to method: {0}, pos {1}", (object) LuaScriptMgr.GetErrorFunc(1), (object) stackPos));
    return (T[]) null;
  }

  public static bool[] GetArrayBool(IntPtr L, int stackPos)
  {
    switch (LuaDLL.lua_type(L, stackPos))
    {
      case LuaTypes.LUA_TTABLE:
        int index = 1;
        List<bool> boolList = new List<bool>();
        LuaDLL.lua_pushvalue(L, stackPos);
        while (true)
        {
          LuaDLL.lua_rawgeti(L, -1, index);
          switch (LuaDLL.lua_type(L, -1))
          {
            case LuaTypes.LUA_TNIL:
              goto label_3;
            case LuaTypes.LUA_TNUMBER:
              bool flag = LuaDLL.lua_toboolean(L, -1);
              boolList.Add(flag);
              LuaDLL.lua_pop(L, 1);
              ++index;
              continue;
            default:
              goto label_7;
          }
        }
label_3:
        LuaDLL.lua_pop(L, 1);
        return boolList.ToArray();
      case LuaTypes.LUA_TUSERDATA:
        bool[] netObject = LuaScriptMgr.GetNetObject<bool[]>(L, stackPos);
        if (netObject != null)
          return netObject;
        break;
    }
label_7:
    LuaDLL.luaL_error(L, string.Format("invalid arguments to method: {0}, pos {1}", (object) LuaScriptMgr.GetErrorFunc(1), (object) stackPos));
    return (bool[]) null;
  }

  public static LuaStringBuffer GetStringBuffer(IntPtr L, int stackPos)
  {
    switch (LuaDLL.lua_type(L, stackPos))
    {
      case LuaTypes.LUA_TNIL:
        return (LuaStringBuffer) null;
      case LuaTypes.LUA_TSTRING:
        int strLen = 0;
        return new LuaStringBuffer(LuaDLL.lua_tolstring(L, stackPos, out strLen), strLen);
      default:
        LuaDLL.luaL_typerror(L, stackPos, "string");
        return (LuaStringBuffer) null;
    }
  }

  public static void SetValueObject(IntPtr L, int pos, object obj)
  {
    LuaScriptMgr.GetTranslator(L).SetValueObject(L, pos, obj);
  }

  public static void CheckArgsCount(IntPtr L, int count)
  {
    int num = LuaDLL.lua_gettop(L);
    if (num == count)
      return;
    string message = string.Format("no overload for method '{0}' takes '{1}' arguments", (object) LuaScriptMgr.GetErrorFunc(1), (object) num);
    LuaDLL.luaL_error(L, message);
  }

  public static object GetVarTable(IntPtr L, int stackPos)
  {
    int newTop = LuaDLL.lua_gettop(L);
    LuaDLL.lua_pushvalue(L, stackPos);
    LuaDLL.lua_pushstring(L, "class");
    LuaDLL.lua_gettable(L, -2);
    object varTable;
    if (LuaDLL.lua_isnil(L, -1))
    {
      LuaDLL.lua_settop(L, newTop);
      LuaDLL.lua_pushvalue(L, stackPos);
      varTable = (object) new LuaTable(LuaDLL.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX), LuaScriptMgr.GetTranslator(L).interpreter);
    }
    else
    {
      string str = LuaDLL.lua_tostring(L, -1);
      LuaDLL.lua_settop(L, newTop);
      stackPos = stackPos <= 0 ? stackPos + newTop + 1 : stackPos;
      switch (str)
      {
        case "Vector3":
          varTable = (object) LuaScriptMgr.GetVector3(L, stackPos);
          break;
        case "Vector2":
          varTable = (object) LuaScriptMgr.GetVector2(L, stackPos);
          break;
        case "Quaternion":
          varTable = (object) LuaScriptMgr.GetQuaternion(L, stackPos);
          break;
        case "Color":
          varTable = (object) LuaScriptMgr.GetColor(L, stackPos);
          break;
        case "Vector4":
          varTable = (object) LuaScriptMgr.GetVector4(L, stackPos);
          break;
        case "Ray":
          varTable = (object) LuaScriptMgr.GetRay(L, stackPos);
          break;
        case "Bounds":
          varTable = (object) LuaScriptMgr.GetBounds(L, stackPos);
          break;
        default:
          LuaDLL.lua_pushvalue(L, stackPos);
          varTable = (object) new LuaTable(LuaDLL.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX), LuaScriptMgr.GetTranslator(L).interpreter);
          break;
      }
    }
    return varTable;
  }

  public static object GetVarObject(IntPtr L, int stackPos)
  {
    switch (LuaDLL.lua_type(L, stackPos))
    {
      case LuaTypes.LUA_TBOOLEAN:
        return (object) LuaDLL.lua_toboolean(L, stackPos);
      case LuaTypes.LUA_TNUMBER:
        return (object) LuaDLL.lua_tonumber(L, stackPos);
      case LuaTypes.LUA_TSTRING:
        return (object) LuaDLL.lua_tostring(L, stackPos);
      case LuaTypes.LUA_TTABLE:
        return LuaScriptMgr.GetVarTable(L, stackPos);
      case LuaTypes.LUA_TFUNCTION:
        LuaDLL.lua_pushvalue(L, stackPos);
        return (object) new LuaFunction(LuaDLL.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX), LuaScriptMgr.GetTranslator(L).interpreter);
      case LuaTypes.LUA_TUSERDATA:
        int key = LuaDLL.luanet_rawnetobj(L, stackPos);
        if (key == -1)
          return (object) null;
        object varObject = (object) null;
        LuaScriptMgr.GetTranslator(L).objects.TryGetValue(key, out varObject);
        return varObject;
      default:
        return (object) null;
    }
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  public static int IndexArray(IntPtr L)
  {
    if (!(LuaScriptMgr.GetLuaObject(L, 1) is Array luaObject))
    {
      LuaDLL.luaL_error(L, "trying to index an invalid Array reference");
      LuaDLL.lua_pushnil(L);
      return 1;
    }
    switch (LuaDLL.lua_type(L, 2))
    {
      case LuaTypes.LUA_TNUMBER:
        int index = (int) LuaDLL.lua_tonumber(L, 2);
        if (index >= luaObject.Length)
        {
          LuaDLL.luaL_error(L, "array index out of bounds: " + (object) index + " " + (object) luaObject.Length);
          return 0;
        }
        object o = luaObject.GetValue(index);
        if (o == null)
        {
          LuaDLL.luaL_error(L, string.Format("array index {0} is null", (object) index));
          return 0;
        }
        LuaScriptMgr.PushVarObject(L, o);
        break;
      case LuaTypes.LUA_TSTRING:
        if (LuaScriptMgr.GetLuaString(L, 2) == "Length")
        {
          LuaScriptMgr.Push(L, luaObject.Length);
          break;
        }
        break;
    }
    return 1;
  }

  [MonoPInvokeCallback(typeof (LuaCSFunction))]
  public static int NewIndexArray(IntPtr L)
  {
    if (!(LuaScriptMgr.GetLuaObject(L, 1) is Array luaObject))
    {
      LuaDLL.luaL_error(L, "trying to index and invalid object reference");
      return 0;
    }
    int number = (int) LuaScriptMgr.GetNumber(L, 2);
    object varObject = LuaScriptMgr.GetVarObject(L, 3);
    System.Type elementType = luaObject.GetType().GetElementType();
    if (!LuaScriptMgr.CheckType(L, elementType, 3))
    {
      LuaDLL.luaL_error(L, "trying to set object type is not correct");
      return 0;
    }
    object obj = Convert.ChangeType(varObject, elementType);
    luaObject.SetValue(obj, number);
    return 0;
  }

  public static void DumpStack(IntPtr L)
  {
    int num = LuaDLL.lua_gettop(L);
    for (int index = 1; index <= num; ++index)
    {
      LuaTypes luaTypes = LuaDLL.lua_type(L, index);
      switch (luaTypes)
      {
        case LuaTypes.LUA_TBOOLEAN:
          Debugger.Log(LuaDLL.lua_toboolean(L, index).ToString());
          break;
        case LuaTypes.LUA_TNUMBER:
          Debugger.Log(LuaDLL.lua_tonumber(L, index).ToString());
          break;
        case LuaTypes.LUA_TSTRING:
          Debugger.Log(LuaDLL.lua_tostring(L, index));
          break;
        default:
          Debugger.Log(luaTypes.ToString());
          break;
      }
    }
  }

  private static object GetEnumObj(Enum e)
  {
    object enumObj = (object) null;
    if (!LuaScriptMgr.enumMap.TryGetValue(e, out enumObj))
    {
      enumObj = (object) e;
      LuaScriptMgr.enumMap.Add(e, enumObj);
    }
    return enumObj;
  }

  public static void Push(IntPtr L, Enum e)
  {
    LuaScriptMgr mgrFromLuaState = LuaScriptMgr.GetMgrFromLuaState(L);
    ObjectTranslator translator = mgrFromLuaState.lua.translator;
    int weakTableRef = translator.weakTableRef;
    object enumObj = LuaScriptMgr.GetEnumObj(e);
    int num = -1;
    if (translator.objectsBackMap.TryGetValue(enumObj, out num))
    {
      if (LuaDLL.tolua_pushudata(L, weakTableRef, num))
        return;
      translator.collectObject(num);
    }
    int index = translator.addObject(enumObj, false);
    LuaDLL.tolua_pushnewudata(L, mgrFromLuaState.enumMetaRef, weakTableRef, index);
  }

  public static void Push(IntPtr L, LuaStringBuffer lsb)
  {
    if (lsb != null && lsb.buffer != null)
      LuaDLL.lua_pushlstring(L, lsb.buffer, lsb.buffer.Length);
    else
      LuaDLL.lua_pushnil(L);
  }

  public static LuaScriptMgr GetMgrFromLuaState(IntPtr L) => LuaScriptMgr.Instance;

  public static void ThrowLuaException(IntPtr L)
  {
    throw new LuaScriptException((LuaDLL.lua_tostring(L, -1) ?? "Unknown Lua Error").ToString(), string.Empty);
  }

  public static Vector3 GetVector3(IntPtr L, int stackPos)
  {
    LuaScriptMgr mgrFromLuaState = LuaScriptMgr.GetMgrFromLuaState(L);
    float x = 0.0f;
    float y = 0.0f;
    float z = 0.0f;
    LuaDLL.tolua_getfloat3(L, mgrFromLuaState.unpackVec3, stackPos, ref x, ref y, ref z);
    return new Vector3(x, y, z);
  }

  public static void Push(IntPtr L, Vector3 v3)
  {
    LuaScriptMgr mgrFromLuaState = LuaScriptMgr.GetMgrFromLuaState(L);
    LuaDLL.tolua_pushfloat3(L, mgrFromLuaState.packVec3, v3.x, v3.y, v3.z);
  }

  public static void Push(IntPtr L, Quaternion q)
  {
    LuaScriptMgr mgrFromLuaState = LuaScriptMgr.GetMgrFromLuaState(L);
    LuaDLL.tolua_pushfloat4(L, mgrFromLuaState.packQuat, q.x, q.y, q.z, q.w);
  }

  public static Quaternion GetQuaternion(IntPtr L, int stackPos)
  {
    LuaScriptMgr mgrFromLuaState = LuaScriptMgr.GetMgrFromLuaState(L);
    float x = 0.0f;
    float y = 0.0f;
    float z = 0.0f;
    float w = 1f;
    LuaDLL.tolua_getfloat4(L, mgrFromLuaState.unpackQuat, stackPos, ref x, ref y, ref z, ref w);
    return new Quaternion(x, y, z, w);
  }

  public static Vector2 GetVector2(IntPtr L, int stackPos)
  {
    LuaScriptMgr mgrFromLuaState = LuaScriptMgr.GetMgrFromLuaState(L);
    float x = 0.0f;
    float y = 0.0f;
    LuaDLL.tolua_getfloat2(L, mgrFromLuaState.unpackVec2, stackPos, ref x, ref y);
    return new Vector2(x, y);
  }

  public static void Push(IntPtr L, Vector2 v2)
  {
    LuaScriptMgr mgrFromLuaState = LuaScriptMgr.GetMgrFromLuaState(L);
    LuaDLL.tolua_pushfloat2(L, mgrFromLuaState.packVec2, v2.x, v2.y);
  }

  public static Vector4 GetVector4(IntPtr L, int stackPos)
  {
    LuaScriptMgr mgrFromLuaState = LuaScriptMgr.GetMgrFromLuaState(L);
    float x = 0.0f;
    float y = 0.0f;
    float z = 0.0f;
    float w = 0.0f;
    LuaDLL.tolua_getfloat4(L, mgrFromLuaState.unpackVec4, stackPos, ref x, ref y, ref z, ref w);
    return new Vector4(x, y, z, w);
  }

  public static void Push(IntPtr L, Vector4 v4)
  {
    LuaScriptMgr mgrFromLuaState = LuaScriptMgr.GetMgrFromLuaState(L);
    LuaDLL.tolua_pushfloat4(L, mgrFromLuaState.packVec4, v4.x, v4.y, v4.z, v4.w);
  }

  public static void Push(IntPtr L, RaycastHit hit)
  {
    LuaScriptMgr.GetMgrFromLuaState(L).packRaycastHit.push(L);
    LuaScriptMgr.Push(L, (Object) ((RaycastHit) ref hit).collider);
    LuaScriptMgr.Push(L, ((RaycastHit) ref hit).distance);
    LuaScriptMgr.Push(L, ((RaycastHit) ref hit).normal);
    LuaScriptMgr.Push(L, ((RaycastHit) ref hit).point);
    LuaScriptMgr.Push(L, (Object) ((RaycastHit) ref hit).rigidbody);
    LuaScriptMgr.Push(L, (Object) ((RaycastHit) ref hit).transform);
    LuaDLL.lua_call(L, 6, -1);
  }

  public static void Push(IntPtr L, Ray ray)
  {
    LuaScriptMgr mgrFromLuaState = LuaScriptMgr.GetMgrFromLuaState(L);
    LuaDLL.lua_getref(L, mgrFromLuaState.packRay);
    LuaDLL.tolua_pushfloat3(L, mgrFromLuaState.packVec3, ((Ray) ref ray).direction.x, ((Ray) ref ray).direction.y, ((Ray) ref ray).direction.z);
    LuaDLL.tolua_pushfloat3(L, mgrFromLuaState.packVec3, ((Ray) ref ray).origin.x, ((Ray) ref ray).origin.y, ((Ray) ref ray).origin.z);
    LuaDLL.lua_call(L, 2, -1);
  }

  public static Ray GetRay(IntPtr L, int stackPos)
  {
    LuaScriptMgr mgrFromLuaState = LuaScriptMgr.GetMgrFromLuaState(L);
    float x = 0.0f;
    float y = 0.0f;
    float z = 0.0f;
    float x1 = 0.0f;
    float y1 = 0.0f;
    float z1 = 0.0f;
    LuaDLL.tolua_getfloat6(L, mgrFromLuaState.unpackRay, stackPos, ref x, ref y, ref z, ref x1, ref y1, ref z1);
    Vector3 vector3_1;
    // ISSUE: explicit constructor call
    ((Vector3) ref vector3_1).\u002Ector(x, y, z);
    Vector3 vector3_2;
    // ISSUE: explicit constructor call
    ((Vector3) ref vector3_2).\u002Ector(x1, y1, z1);
    return new Ray(vector3_1, vector3_2);
  }

  public static Bounds GetBounds(IntPtr L, int stackPos)
  {
    LuaScriptMgr mgrFromLuaState = LuaScriptMgr.GetMgrFromLuaState(L);
    float x = 0.0f;
    float y = 0.0f;
    float z = 0.0f;
    float x1 = 0.0f;
    float y1 = 0.0f;
    float z1 = 0.0f;
    LuaDLL.tolua_getfloat6(L, mgrFromLuaState.unpackBounds, stackPos, ref x, ref y, ref z, ref x1, ref y1, ref z1);
    Vector3 vector3_1;
    // ISSUE: explicit constructor call
    ((Vector3) ref vector3_1).\u002Ector(x, y, z);
    Vector3 vector3_2;
    // ISSUE: explicit constructor call
    ((Vector3) ref vector3_2).\u002Ector(x1, y1, z1);
    return new Bounds(vector3_1, vector3_2);
  }

  public static Color GetColor(IntPtr L, int stackPos)
  {
    LuaScriptMgr mgrFromLuaState = LuaScriptMgr.GetMgrFromLuaState(L);
    float x = 0.0f;
    float y = 0.0f;
    float z = 0.0f;
    float w = 0.0f;
    LuaDLL.tolua_getfloat4(L, mgrFromLuaState.unpackColor, stackPos, ref x, ref y, ref z, ref w);
    return new Color(x, y, z, w);
  }

  public static void Push(IntPtr L, Color clr)
  {
    LuaScriptMgr mgrFromLuaState = LuaScriptMgr.GetMgrFromLuaState(L);
    LuaDLL.tolua_pushfloat4(L, mgrFromLuaState.packColor, clr.r, clr.g, clr.b, clr.a);
  }

  public static void Push(IntPtr L, Touch touch)
  {
    LuaScriptMgr mgrFromLuaState = LuaScriptMgr.GetMgrFromLuaState(L);
    mgrFromLuaState.packTouch.push(L);
    LuaDLL.lua_pushinteger(L, ((Touch) ref touch).fingerId);
    LuaDLL.tolua_pushfloat2(L, mgrFromLuaState.packVec2, ((Touch) ref touch).position.x, ((Touch) ref touch).position.y);
    LuaDLL.tolua_pushfloat2(L, mgrFromLuaState.packVec2, ((Touch) ref touch).rawPosition.x, ((Touch) ref touch).rawPosition.y);
    LuaDLL.tolua_pushfloat2(L, mgrFromLuaState.packVec2, ((Touch) ref touch).deltaPosition.x, ((Touch) ref touch).deltaPosition.y);
    LuaDLL.lua_pushnumber(L, (double) ((Touch) ref touch).deltaTime);
    LuaDLL.lua_pushinteger(L, ((Touch) ref touch).tapCount);
    LuaDLL.lua_pushinteger(L, (int) ((Touch) ref touch).phase);
    LuaDLL.lua_call(L, 7, -1);
  }

  public static void Push(IntPtr L, Bounds bound)
  {
    LuaScriptMgr mgrFromLuaState = LuaScriptMgr.GetMgrFromLuaState(L);
    LuaDLL.lua_getref(L, mgrFromLuaState.packBounds);
    LuaScriptMgr.Push(L, ((Bounds) ref bound).center);
    LuaScriptMgr.Push(L, ((Bounds) ref bound).size);
    LuaDLL.lua_call(L, 2, -1);
  }

  public static void PushTraceBack(IntPtr L)
  {
    if (LuaScriptMgr.traceback == null)
      LuaDLL.lua_getglobal(L, "traceback");
    else
      LuaScriptMgr.traceback.push();
  }
}
