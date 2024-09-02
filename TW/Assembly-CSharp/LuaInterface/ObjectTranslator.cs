// Decompiled with JetBrains decompiler
// Type: LuaInterface.ObjectTranslator
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace LuaInterface
{
  public class ObjectTranslator
  {
    internal CheckType typeChecker;
    public readonly Dictionary<int, object> objects = new Dictionary<int, object>();
    public readonly Dictionary<object, int> objectsBackMap = new Dictionary<object, int>((IEqualityComparer<object>) new ObjectTranslator.CompareObject());
    private static Dictionary<System.Type, int> typeMetaMap = new Dictionary<System.Type, int>();
    internal LuaState interpreter;
    public MetaFunctions metaFunctions;
    public List<Assembly> assemblies;
    private LuaCSFunction registerTableFunction;
    private LuaCSFunction unregisterTableFunction;
    private LuaCSFunction getMethodSigFunction;
    private LuaCSFunction getConstructorSigFunction;
    private LuaCSFunction importTypeFunction;
    private LuaCSFunction loadAssemblyFunction;
    private LuaCSFunction ctypeFunction;
    private LuaCSFunction enumFromIntFunction;
    internal EventHandlerContainer pendingEvents = new EventHandlerContainer();
    private static List<ObjectTranslator> list = new List<ObjectTranslator>();
    private static int indexTranslator = 0;
    private static Dictionary<System.Type, bool> valueTypeMap = new Dictionary<System.Type, bool>();
    private int nextObj;

    public ObjectTranslator(LuaState interpreter, IntPtr luaState)
    {
      this.interpreter = interpreter;
      this.weakTableRef = -1;
      this.typeChecker = new CheckType(this);
      this.metaFunctions = new MetaFunctions(this);
      this.assemblies = new List<Assembly>();
      this.assemblies.Add(Assembly.GetExecutingAssembly());
      this.importTypeFunction = new LuaCSFunction(ObjectTranslator.importType);
      this.loadAssemblyFunction = new LuaCSFunction(ObjectTranslator.loadAssembly);
      this.registerTableFunction = new LuaCSFunction(ObjectTranslator.registerTable);
      this.unregisterTableFunction = new LuaCSFunction(ObjectTranslator.unregisterTable);
      this.getMethodSigFunction = new LuaCSFunction(ObjectTranslator.getMethodSignature);
      this.getConstructorSigFunction = new LuaCSFunction(ObjectTranslator.getConstructorSignature);
      this.ctypeFunction = new LuaCSFunction(ObjectTranslator.ctype);
      this.enumFromIntFunction = new LuaCSFunction(ObjectTranslator.enumFromInt);
      this.createLuaObjectList(luaState);
      this.createIndexingMetaFunction(luaState);
      this.createBaseClassMetatable(luaState);
      this.createClassMetatable(luaState);
      this.createFunctionMetatable(luaState);
      this.setGlobalFunctions(luaState);
    }

    public int weakTableRef { get; private set; }

    public static ObjectTranslator FromState(IntPtr luaState)
    {
      LuaDLL.lua_getglobal(luaState, "_translator");
      int index = (int) LuaDLL.lua_tonumber(luaState, -1);
      LuaDLL.lua_pop(luaState, 1);
      return ObjectTranslator.list[index];
    }

    public void PushTranslator(IntPtr L)
    {
      ObjectTranslator.list.Add(this);
      LuaDLL.lua_pushnumber(L, (double) ObjectTranslator.indexTranslator);
      LuaDLL.lua_setglobal(L, "_translator");
      ++ObjectTranslator.indexTranslator;
    }

    public void Destroy()
    {
      IntPtr l = this.interpreter.L;
      foreach (KeyValuePair<System.Type, int> typeMeta in ObjectTranslator.typeMetaMap)
      {
        int reference = typeMeta.Value;
        LuaDLL.lua_unref(l, reference);
      }
      LuaDLL.lua_unref(l, this.weakTableRef);
      ObjectTranslator.typeMetaMap.Clear();
    }

    private void createLuaObjectList(IntPtr luaState)
    {
      LuaDLL.lua_pushstring(luaState, "luaNet_objects");
      LuaDLL.lua_newtable(luaState);
      LuaDLL.lua_pushvalue(luaState, -1);
      this.weakTableRef = LuaDLL.luaL_ref(luaState, LuaIndexes.LUA_REGISTRYINDEX);
      LuaDLL.lua_pushvalue(luaState, -1);
      LuaDLL.lua_setmetatable(luaState, -2);
      LuaDLL.lua_pushstring(luaState, "__mode");
      LuaDLL.lua_pushstring(luaState, "v");
      LuaDLL.lua_settable(luaState, -3);
      LuaDLL.lua_settable(luaState, LuaIndexes.LUA_REGISTRYINDEX);
    }

    private void createIndexingMetaFunction(IntPtr luaState)
    {
      LuaDLL.lua_pushstring(luaState, "luaNet_indexfunction");
      LuaDLL.luaL_dostring(luaState, MetaFunctions.luaIndexFunction);
      LuaDLL.lua_rawset(luaState, LuaIndexes.LUA_REGISTRYINDEX);
    }

    private void createBaseClassMetatable(IntPtr luaState)
    {
      LuaDLL.luaL_newmetatable(luaState, "luaNet_searchbase");
      LuaDLL.lua_pushstring(luaState, "__gc");
      LuaDLL.lua_pushstdcallcfunction(luaState, this.metaFunctions.gcFunction);
      LuaDLL.lua_settable(luaState, -3);
      LuaDLL.lua_pushstring(luaState, "__tostring");
      LuaDLL.lua_pushstdcallcfunction(luaState, this.metaFunctions.toStringFunction);
      LuaDLL.lua_settable(luaState, -3);
      LuaDLL.lua_pushstring(luaState, "__index");
      LuaDLL.lua_pushstdcallcfunction(luaState, this.metaFunctions.baseIndexFunction);
      LuaDLL.lua_settable(luaState, -3);
      LuaDLL.lua_pushstring(luaState, "__newindex");
      LuaDLL.lua_pushstdcallcfunction(luaState, this.metaFunctions.newindexFunction);
      LuaDLL.lua_settable(luaState, -3);
      LuaDLL.lua_settop(luaState, -2);
    }

    private void createClassMetatable(IntPtr luaState)
    {
      LuaDLL.luaL_newmetatable(luaState, "luaNet_class");
      LuaDLL.lua_pushstring(luaState, "__gc");
      LuaDLL.lua_pushstdcallcfunction(luaState, this.metaFunctions.gcFunction);
      LuaDLL.lua_settable(luaState, -3);
      LuaDLL.lua_pushstring(luaState, "__tostring");
      LuaDLL.lua_pushstdcallcfunction(luaState, this.metaFunctions.toStringFunction);
      LuaDLL.lua_settable(luaState, -3);
      LuaDLL.lua_pushstring(luaState, "__index");
      LuaDLL.lua_pushstdcallcfunction(luaState, this.metaFunctions.classIndexFunction);
      LuaDLL.lua_settable(luaState, -3);
      LuaDLL.lua_pushstring(luaState, "__newindex");
      LuaDLL.lua_pushstdcallcfunction(luaState, this.metaFunctions.classNewindexFunction);
      LuaDLL.lua_settable(luaState, -3);
      LuaDLL.lua_pushstring(luaState, "__call");
      LuaDLL.lua_pushstdcallcfunction(luaState, this.metaFunctions.callConstructorFunction);
      LuaDLL.lua_settable(luaState, -3);
      LuaDLL.lua_settop(luaState, -2);
    }

    private void setGlobalFunctions(IntPtr luaState)
    {
      LuaDLL.lua_pushstdcallcfunction(luaState, this.metaFunctions.indexFunction);
      LuaDLL.lua_setglobal(luaState, "get_object_member");
      LuaDLL.lua_pushstdcallcfunction(luaState, this.importTypeFunction);
      LuaDLL.lua_setglobal(luaState, "import_type");
      LuaDLL.lua_pushstdcallcfunction(luaState, this.loadAssemblyFunction);
      LuaDLL.lua_setglobal(luaState, "load_assembly");
      LuaDLL.lua_pushstdcallcfunction(luaState, this.registerTableFunction);
      LuaDLL.lua_setglobal(luaState, "make_object");
      LuaDLL.lua_pushstdcallcfunction(luaState, this.unregisterTableFunction);
      LuaDLL.lua_setglobal(luaState, "free_object");
      LuaDLL.lua_pushstdcallcfunction(luaState, this.getMethodSigFunction);
      LuaDLL.lua_setglobal(luaState, "get_method_bysig");
      LuaDLL.lua_pushstdcallcfunction(luaState, this.getConstructorSigFunction);
      LuaDLL.lua_setglobal(luaState, "get_constructor_bysig");
      LuaDLL.lua_pushstdcallcfunction(luaState, this.ctypeFunction);
      LuaDLL.lua_setglobal(luaState, "ctype");
      LuaDLL.lua_pushstdcallcfunction(luaState, this.enumFromIntFunction);
      LuaDLL.lua_setglobal(luaState, "enum");
    }

    private void createFunctionMetatable(IntPtr luaState)
    {
      LuaDLL.luaL_newmetatable(luaState, "luaNet_function");
      LuaDLL.lua_pushstring(luaState, "__gc");
      LuaDLL.lua_pushstdcallcfunction(luaState, this.metaFunctions.gcFunction);
      LuaDLL.lua_settable(luaState, -3);
      LuaDLL.lua_pushstring(luaState, "__call");
      LuaDLL.lua_pushstdcallcfunction(luaState, this.metaFunctions.execDelegateFunction);
      LuaDLL.lua_settable(luaState, -3);
      LuaDLL.lua_settop(luaState, -2);
    }

    internal void throwError(IntPtr luaState, string message)
    {
      LuaDLL.luaL_error(luaState, message);
    }

    [MonoPInvokeCallback(typeof (LuaCSFunction))]
    public static int loadAssembly(IntPtr luaState)
    {
      ObjectTranslator objectTranslator = ObjectTranslator.FromState(luaState);
      try
      {
        string str = LuaDLL.lua_tostring(luaState, 1);
        Assembly assembly = (Assembly) null;
        try
        {
          assembly = Assembly.Load(str);
        }
        catch (BadImageFormatException ex)
        {
        }
        if ((object) assembly == null)
          assembly = Assembly.Load(AssemblyName.GetAssemblyName(str));
        if ((object) assembly != null)
        {
          if (!objectTranslator.assemblies.Contains(assembly))
            objectTranslator.assemblies.Add(assembly);
        }
      }
      catch (Exception ex)
      {
        objectTranslator.throwError(luaState, ex.Message);
      }
      return 0;
    }

    internal System.Type FindType(string className)
    {
      foreach (Assembly assembly in this.assemblies)
      {
        System.Type type = assembly.GetType(className);
        if ((object) type != null)
          return type;
      }
      return (System.Type) null;
    }

    [MonoPInvokeCallback(typeof (LuaCSFunction))]
    public static int importType(IntPtr luaState)
    {
      ObjectTranslator objectTranslator = ObjectTranslator.FromState(luaState);
      string className = LuaDLL.lua_tostring(luaState, 1);
      System.Type type = objectTranslator.FindType(className);
      if ((object) type != null)
        objectTranslator.pushType(luaState, type);
      else
        LuaDLL.lua_pushnil(luaState);
      return 1;
    }

    [MonoPInvokeCallback(typeof (LuaCSFunction))]
    public static int registerTable(IntPtr luaState)
    {
      ObjectTranslator objectTranslator = ObjectTranslator.FromState(luaState);
      if (LuaDLL.lua_type(luaState, 1) == LuaTypes.LUA_TTABLE)
      {
        LuaTable table = objectTranslator.getTable(luaState, 1);
        string className = LuaDLL.lua_tostring(luaState, 2);
        if (className != null)
        {
          System.Type type = objectTranslator.FindType(className);
          if ((object) type != null)
          {
            object classInstance = CodeGeneration.Instance.GetClassInstance(type, table);
            objectTranslator.pushObject(luaState, classInstance, "luaNet_metatable");
            LuaDLL.lua_newtable(luaState);
            LuaDLL.lua_pushstring(luaState, "__index");
            LuaDLL.lua_pushvalue(luaState, -3);
            LuaDLL.lua_settable(luaState, -3);
            LuaDLL.lua_pushstring(luaState, "__newindex");
            LuaDLL.lua_pushvalue(luaState, -3);
            LuaDLL.lua_settable(luaState, -3);
            LuaDLL.lua_setmetatable(luaState, 1);
            LuaDLL.lua_pushstring(luaState, "base");
            int index = objectTranslator.addObject(classInstance);
            objectTranslator.pushNewObject(luaState, classInstance, index, "luaNet_searchbase");
            LuaDLL.lua_rawset(luaState, 1);
          }
          else
            objectTranslator.throwError(luaState, "register_table: can not find superclass '" + className + "'");
        }
        else
          objectTranslator.throwError(luaState, "register_table: superclass name can not be null");
      }
      else
        objectTranslator.throwError(luaState, "register_table: first arg is not a table");
      return 0;
    }

    [MonoPInvokeCallback(typeof (LuaCSFunction))]
    public static int unregisterTable(IntPtr luaState)
    {
      ObjectTranslator objectTranslator = ObjectTranslator.FromState(luaState);
      try
      {
        if (LuaDLL.lua_getmetatable(luaState, 1) != 0)
        {
          LuaDLL.lua_pushstring(luaState, "__index");
          LuaDLL.lua_gettable(luaState, -2);
          object rawNetObject = objectTranslator.getRawNetObject(luaState, -1);
          if (rawNetObject == null)
            objectTranslator.throwError(luaState, "unregister_table: arg is not valid table");
          FieldInfo field = rawNetObject.GetType().GetField("__luaInterface_luaTable");
          if ((object) field == null)
            objectTranslator.throwError(luaState, "unregister_table: arg is not valid table");
          field.SetValue(rawNetObject, (object) null);
          LuaDLL.lua_pushnil(luaState);
          LuaDLL.lua_setmetatable(luaState, 1);
          LuaDLL.lua_pushstring(luaState, "base");
          LuaDLL.lua_pushnil(luaState);
          LuaDLL.lua_settable(luaState, 1);
        }
        else
          objectTranslator.throwError(luaState, "unregister_table: arg is not valid table");
      }
      catch (Exception ex)
      {
        objectTranslator.throwError(luaState, ex.Message);
      }
      return 0;
    }

    [MonoPInvokeCallback(typeof (LuaCSFunction))]
    public static int getMethodSignature(IntPtr luaState)
    {
      ObjectTranslator translator = ObjectTranslator.FromState(luaState);
      int key = LuaDLL.luanet_checkudata(luaState, 1, "luaNet_class");
      IReflect type;
      object target;
      if (key != -1)
      {
        type = (IReflect) translator.objects[key];
        target = (object) null;
      }
      else
      {
        target = translator.getRawNetObject(luaState, 1);
        if (target == null)
        {
          translator.throwError(luaState, "get_method_bysig: first arg is not type or object reference");
          LuaDLL.lua_pushnil(luaState);
          return 1;
        }
        type = (IReflect) target.GetType();
      }
      string name = LuaDLL.lua_tostring(luaState, 2);
      System.Type[] types = new System.Type[LuaDLL.lua_gettop(luaState) - 2];
      for (int index = 0; index < types.Length; ++index)
        types[index] = translator.FindType(LuaDLL.lua_tostring(luaState, index + 3));
      try
      {
        MethodInfo method = type.GetMethod(name, BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.FlattenHierarchy, (Binder) null, types, (ParameterModifier[]) null);
        translator.pushFunction(luaState, new LuaCSFunction(new LuaMethodWrapper(translator, target, type, (MethodBase) method).call));
      }
      catch (Exception ex)
      {
        translator.throwError(luaState, ex.Message);
        LuaDLL.lua_pushnil(luaState);
      }
      return 1;
    }

    [MonoPInvokeCallback(typeof (LuaCSFunction))]
    public static int getConstructorSignature(IntPtr luaState)
    {
      ObjectTranslator translator = ObjectTranslator.FromState(luaState);
      IReflect targetType = (IReflect) null;
      int key = LuaDLL.luanet_checkudata(luaState, 1, "luaNet_class");
      if (key != -1)
        targetType = (IReflect) translator.objects[key];
      if (targetType == null)
        translator.throwError(luaState, "get_constructor_bysig: first arg is invalid type reference");
      System.Type[] types = new System.Type[LuaDLL.lua_gettop(luaState) - 1];
      for (int index = 0; index < types.Length; ++index)
        types[index] = translator.FindType(LuaDLL.lua_tostring(luaState, index + 2));
      try
      {
        ConstructorInfo constructor = targetType.UnderlyingSystemType.GetConstructor(types);
        translator.pushFunction(luaState, new LuaCSFunction(new LuaMethodWrapper(translator, (object) null, targetType, (MethodBase) constructor).call));
      }
      catch (Exception ex)
      {
        translator.throwError(luaState, ex.Message);
        LuaDLL.lua_pushnil(luaState);
      }
      return 1;
    }

    private System.Type typeOf(IntPtr luaState, int idx)
    {
      int key = LuaDLL.luanet_checkudata(luaState, 1, "luaNet_class");
      return key == -1 ? (System.Type) null : ((ProxyType) this.objects[key]).UnderlyingSystemType;
    }

    public int pushError(IntPtr luaState, string msg)
    {
      LuaDLL.lua_pushnil(luaState);
      LuaDLL.lua_pushstring(luaState, msg);
      return 2;
    }

    [MonoPInvokeCallback(typeof (LuaCSFunction))]
    public static int ctype(IntPtr luaState)
    {
      ObjectTranslator objectTranslator = ObjectTranslator.FromState(luaState);
      System.Type o = objectTranslator.typeOf(luaState, 1);
      if ((object) o == null)
        return objectTranslator.pushError(luaState, "not a CLR class");
      objectTranslator.pushObject(luaState, (object) o, "luaNet_metatable");
      return 1;
    }

    [MonoPInvokeCallback(typeof (LuaCSFunction))]
    public static int enumFromInt(IntPtr luaState)
    {
      ObjectTranslator objectTranslator = ObjectTranslator.FromState(luaState);
      System.Type enumType = objectTranslator.typeOf(luaState, 1);
      if ((object) enumType == null || !enumType.IsEnum)
        return objectTranslator.pushError(luaState, "not an enum");
      object o = (object) null;
      switch (LuaDLL.lua_type(luaState, 2))
      {
        case LuaTypes.LUA_TNUMBER:
          int num = (int) LuaDLL.lua_tonumber(luaState, 2);
          o = Enum.ToObject(enumType, num);
          break;
        case LuaTypes.LUA_TSTRING:
          string str = LuaDLL.lua_tostring(luaState, 2);
          string msg = (string) null;
          try
          {
            o = Enum.Parse(enumType, str);
          }
          catch (ArgumentException ex)
          {
            msg = ex.Message;
          }
          if (msg != null)
            return objectTranslator.pushError(luaState, msg);
          break;
        default:
          return objectTranslator.pushError(luaState, "second argument must be a integer or a string");
      }
      objectTranslator.pushObject(luaState, o, "luaNet_metatable");
      return 1;
    }

    internal void pushType(IntPtr luaState, System.Type t)
    {
      this.pushObject(luaState, (object) new ProxyType(t), "luaNet_class");
    }

    internal void pushFunction(IntPtr luaState, LuaCSFunction func)
    {
      this.pushObject(luaState, (object) func, "luaNet_function");
    }

    private bool IsValueType(System.Type t)
    {
      bool flag = false;
      if (!ObjectTranslator.valueTypeMap.TryGetValue(t, out flag))
      {
        flag = t.IsValueType;
        ObjectTranslator.valueTypeMap.Add(t, flag);
      }
      return flag;
    }

    public void pushObject(IntPtr luaState, object o, string metatable)
    {
      if (o == null)
      {
        LuaDLL.lua_pushnil(luaState);
      }
      else
      {
        int num = -1;
        bool isValueType = o.GetType().IsValueType;
        if (!isValueType && this.objectsBackMap.TryGetValue(o, out num))
        {
          if (LuaDLL.tolua_pushudata(luaState, this.weakTableRef, num))
            return;
          this.collectObject(o, num);
        }
        num = this.addObject(o, isValueType);
        this.pushNewObject(luaState, o, num, metatable);
      }
    }

    private static void PushMetaTable(IntPtr L, System.Type t)
    {
      int reference = -1;
      if (!ObjectTranslator.typeMetaMap.TryGetValue(t, out reference))
      {
        LuaDLL.luaL_getmetatable(L, t.AssemblyQualifiedName);
        if (LuaDLL.lua_isnil(L, -1))
          return;
        LuaDLL.lua_pushvalue(L, -1);
        int num = LuaDLL.luaL_ref(L, LuaIndexes.LUA_REGISTRYINDEX);
        ObjectTranslator.typeMetaMap.Add(t, num);
      }
      else
        LuaDLL.lua_getref(L, reference);
    }

    private void pushNewObject(IntPtr luaState, object o, int index, string metatable)
    {
      LuaDLL.lua_getref(luaState, this.weakTableRef);
      LuaDLL.luanet_newudata(luaState, index);
      if (metatable == "luaNet_metatable")
      {
        System.Type type = o.GetType();
        ObjectTranslator.PushMetaTable(luaState, o.GetType());
        if (LuaDLL.lua_isnil(luaState, -1))
        {
          string assemblyQualifiedName = type.AssemblyQualifiedName;
          Debugger.LogWarning("Create not wrap ulua type:" + assemblyQualifiedName);
          LuaDLL.lua_settop(luaState, -2);
          LuaDLL.luaL_newmetatable(luaState, assemblyQualifiedName);
          LuaDLL.lua_pushstring(luaState, "cache");
          LuaDLL.lua_newtable(luaState);
          LuaDLL.lua_rawset(luaState, -3);
          LuaDLL.lua_pushlightuserdata(luaState, LuaDLL.luanet_gettag());
          LuaDLL.lua_pushnumber(luaState, 1.0);
          LuaDLL.lua_rawset(luaState, -3);
          LuaDLL.lua_pushstring(luaState, "__index");
          LuaDLL.lua_pushstring(luaState, "luaNet_indexfunction");
          LuaDLL.lua_rawget(luaState, LuaIndexes.LUA_REGISTRYINDEX);
          LuaDLL.lua_rawset(luaState, -3);
          LuaDLL.lua_pushstring(luaState, "__gc");
          LuaDLL.lua_pushstdcallcfunction(luaState, this.metaFunctions.gcFunction);
          LuaDLL.lua_rawset(luaState, -3);
          LuaDLL.lua_pushstring(luaState, "__tostring");
          LuaDLL.lua_pushstdcallcfunction(luaState, this.metaFunctions.toStringFunction);
          LuaDLL.lua_rawset(luaState, -3);
          LuaDLL.lua_pushstring(luaState, "__newindex");
          LuaDLL.lua_pushstdcallcfunction(luaState, this.metaFunctions.newindexFunction);
          LuaDLL.lua_rawset(luaState, -3);
        }
      }
      else
        LuaDLL.luaL_getmetatable(luaState, metatable);
      LuaDLL.lua_setmetatable(luaState, -2);
      LuaDLL.lua_pushvalue(luaState, -1);
      LuaDLL.lua_rawseti(luaState, -3, index);
      LuaDLL.lua_remove(luaState, -2);
    }

    public void PushNewValueObject(IntPtr luaState, object o, int index)
    {
      LuaDLL.luanet_newudata(luaState, index);
      System.Type type = o.GetType();
      ObjectTranslator.PushMetaTable(luaState, o.GetType());
      if (LuaDLL.lua_isnil(luaState, -1))
      {
        string assemblyQualifiedName = type.AssemblyQualifiedName;
        Debugger.LogWarning("Create not wrap ulua type:" + assemblyQualifiedName);
        LuaDLL.lua_settop(luaState, -2);
        LuaDLL.luaL_newmetatable(luaState, assemblyQualifiedName);
        LuaDLL.lua_pushstring(luaState, "cache");
        LuaDLL.lua_newtable(luaState);
        LuaDLL.lua_rawset(luaState, -3);
        LuaDLL.lua_pushlightuserdata(luaState, LuaDLL.luanet_gettag());
        LuaDLL.lua_pushnumber(luaState, 1.0);
        LuaDLL.lua_rawset(luaState, -3);
        LuaDLL.lua_pushstring(luaState, "__index");
        LuaDLL.lua_pushstring(luaState, "luaNet_indexfunction");
        LuaDLL.lua_rawget(luaState, LuaIndexes.LUA_REGISTRYINDEX);
        LuaDLL.lua_rawset(luaState, -3);
        LuaDLL.lua_pushstring(luaState, "__gc");
        LuaDLL.lua_pushstdcallcfunction(luaState, this.metaFunctions.gcFunction);
        LuaDLL.lua_rawset(luaState, -3);
        LuaDLL.lua_pushstring(luaState, "__tostring");
        LuaDLL.lua_pushstdcallcfunction(luaState, this.metaFunctions.toStringFunction);
        LuaDLL.lua_rawset(luaState, -3);
        LuaDLL.lua_pushstring(luaState, "__newindex");
        LuaDLL.lua_pushstdcallcfunction(luaState, this.metaFunctions.newindexFunction);
        LuaDLL.lua_rawset(luaState, -3);
      }
      LuaDLL.lua_setmetatable(luaState, -2);
    }

    internal object getAsType(IntPtr luaState, int stackPos, System.Type paramType)
    {
      ExtractValue extractValue = this.typeChecker.checkType(luaState, stackPos, paramType);
      return extractValue != null ? extractValue(luaState, stackPos) : (object) null;
    }

    internal void collectObject(int udata)
    {
      object key;
      if (!this.objects.TryGetValue(udata, out key))
        return;
      this.objects.Remove(udata);
      if (key == null || key.GetType().IsValueType)
        return;
      this.objectsBackMap.Remove(key);
    }

    private void collectObject(object o, int udata)
    {
      this.objectsBackMap.Remove(o);
      this.objects.Remove(udata);
    }

    public int addObject(object obj)
    {
      int key = this.nextObj++;
      this.objects[key] = obj;
      if (!obj.GetType().IsValueType)
        this.objectsBackMap[obj] = key;
      return key;
    }

    public int addObject(object obj, bool isValueType)
    {
      int key = this.nextObj++;
      this.objects[key] = obj;
      if (!isValueType)
        this.objectsBackMap[obj] = key;
      return key;
    }

    public object getObject(IntPtr luaState, int index)
    {
      return LuaScriptMgr.GetVarObject(luaState, index);
    }

    internal LuaTable getTable(IntPtr luaState, int index)
    {
      LuaDLL.lua_pushvalue(luaState, index);
      return new LuaTable(LuaDLL.luaL_ref(luaState, LuaIndexes.LUA_REGISTRYINDEX), this.interpreter);
    }

    internal LuaFunction getFunction(IntPtr luaState, int index)
    {
      LuaDLL.lua_pushvalue(luaState, index);
      return new LuaFunction(LuaDLL.luaL_ref(luaState, LuaIndexes.LUA_REGISTRYINDEX), this.interpreter);
    }

    internal object getNetObject(IntPtr luaState, int index)
    {
      int key = LuaDLL.luanet_tonetobject(luaState, index);
      return key != -1 ? this.objects[key] : (object) null;
    }

    internal object getRawNetObject(IntPtr luaState, int index)
    {
      int key = LuaDLL.luanet_rawnetobj(luaState, index);
      object rawNetObject = (object) null;
      this.objects.TryGetValue(key, out rawNetObject);
      return rawNetObject;
    }

    public void SetValueObject(IntPtr luaState, int stackPos, object obj)
    {
      int key = LuaDLL.luanet_rawnetobj(luaState, stackPos);
      if (key == -1)
        return;
      this.objects[key] = obj;
    }

    internal int returnValues(IntPtr luaState, object[] returnValues)
    {
      if (!LuaDLL.lua_checkstack(luaState, returnValues.Length + 5))
        return 0;
      for (int index = 0; index < returnValues.Length; ++index)
        this.push(luaState, returnValues[index]);
      return returnValues.Length;
    }

    internal object[] popValues(IntPtr luaState, int oldTop)
    {
      int num = LuaDLL.lua_gettop(luaState);
      if (oldTop == num)
        return (object[]) null;
      List<object> objectList = new List<object>();
      for (int index = oldTop + 1; index <= num; ++index)
        objectList.Add(this.getObject(luaState, index));
      LuaDLL.lua_settop(luaState, oldTop);
      return objectList.ToArray();
    }

    internal object[] popValues(IntPtr luaState, int oldTop, System.Type[] popTypes)
    {
      int num = LuaDLL.lua_gettop(luaState);
      if (oldTop == num)
        return (object[]) null;
      List<object> objectList = new List<object>();
      int index = (object) popTypes[0] != (object) typeof (void) ? 0 : 1;
      for (int stackPos = oldTop + 1; stackPos <= num; ++stackPos)
      {
        objectList.Add(this.getAsType(luaState, stackPos, popTypes[index]));
        ++index;
      }
      LuaDLL.lua_settop(luaState, oldTop);
      return objectList.ToArray();
    }

    private static bool IsILua(object o)
    {
      return o is ILuaGeneratedType && (object) o.GetType().GetInterface("ILuaGeneratedType") != null;
    }

    internal void push(IntPtr luaState, object o) => LuaScriptMgr.PushVarObject(luaState, o);

    internal void PushValueResult(IntPtr lua, object o)
    {
      int index = this.addObject(o, true);
      this.PushNewValueObject(lua, o, index);
    }

    internal bool matchParameters(IntPtr luaState, MethodBase method, ref MethodCache methodCache)
    {
      return this.metaFunctions.matchParameters(luaState, method, ref methodCache);
    }

    internal Array tableToArray(object luaParamValue, System.Type paramArrayType)
    {
      return this.metaFunctions.TableToArray(luaParamValue, paramArrayType);
    }

    private class CompareObject : IEqualityComparer<object>
    {
      public bool Equals(object x, object y) => x == y;

      public int GetHashCode(object obj) => obj != null ? obj.GetHashCode() : 0;
    }
  }
}
