// Decompiled with JetBrains decompiler
// Type: LuaInterface.MetaFunctions
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;

#nullable disable
namespace LuaInterface
{
  public class MetaFunctions
  {
    internal static string luaIndexFunction = "\r\n        local function index(obj,name)        \r\n        local meta=getmetatable(obj)\r\n        local cached=meta.cache[name]        \r\n        if cached then\r\n           return cached\r\n        else\r\n           local value,isFunc = get_object_member(obj,name)\r\n           if value==nil and type(isFunc)=='string' then error(isFunc,2) end\r\n           if isFunc then\r\n            meta.cache[name]=value\r\n           end\r\n           return value\r\n         end\r\n    end\r\n    return index";
    private ObjectTranslator translator;
    private Hashtable memberCache = new Hashtable();
    internal LuaCSFunction gcFunction;
    internal LuaCSFunction indexFunction;
    internal LuaCSFunction newindexFunction;
    internal LuaCSFunction baseIndexFunction;
    internal LuaCSFunction classIndexFunction;
    internal LuaCSFunction classNewindexFunction;
    internal LuaCSFunction execDelegateFunction;
    internal LuaCSFunction callConstructorFunction;
    internal LuaCSFunction toStringFunction;

    public MetaFunctions(ObjectTranslator translator)
    {
      this.translator = translator;
      this.gcFunction = new LuaCSFunction(MetaFunctions.collectObject);
      this.toStringFunction = new LuaCSFunction(MetaFunctions.toString);
      this.indexFunction = new LuaCSFunction(MetaFunctions.getMethod);
      this.newindexFunction = new LuaCSFunction(MetaFunctions.setFieldOrProperty);
      this.baseIndexFunction = new LuaCSFunction(MetaFunctions.getBaseMethod);
      this.callConstructorFunction = new LuaCSFunction(MetaFunctions.callConstructor);
      this.classIndexFunction = new LuaCSFunction(MetaFunctions.getClassMethod);
      this.classNewindexFunction = new LuaCSFunction(MetaFunctions.setClassFieldOrProperty);
      this.execDelegateFunction = new LuaCSFunction(MetaFunctions.runFunctionDelegate);
    }

    [MonoPInvokeCallback(typeof (LuaCSFunction))]
    public static int runFunctionDelegate(IntPtr luaState)
    {
      LuaCSFunction rawNetObject = (LuaCSFunction) ObjectTranslator.FromState(luaState).getRawNetObject(luaState, 1);
      LuaDLL.lua_remove(luaState, 1);
      return rawNetObject(luaState);
    }

    [MonoPInvokeCallback(typeof (LuaCSFunction))]
    public static int collectObject(IntPtr luaState)
    {
      int udata = LuaDLL.luanet_rawnetobj(luaState, 1);
      if (udata != -1)
        ObjectTranslator.FromState(luaState).collectObject(udata);
      return 0;
    }

    [MonoPInvokeCallback(typeof (LuaCSFunction))]
    public static int toString(IntPtr luaState)
    {
      ObjectTranslator objectTranslator = ObjectTranslator.FromState(luaState);
      object rawNetObject = objectTranslator.getRawNetObject(luaState, 1);
      if (rawNetObject != null)
        objectTranslator.push(luaState, (object) (rawNetObject.ToString() + ": " + (object) rawNetObject.GetHashCode()));
      else
        LuaDLL.lua_pushnil(luaState);
      return 1;
    }

    public static void dumpStack(ObjectTranslator translator, IntPtr luaState)
    {
      int num = LuaDLL.lua_gettop(luaState);
      for (int index = 1; index <= num; ++index)
      {
        LuaTypes type = LuaDLL.lua_type(luaState, index);
        string str1 = type != LuaTypes.LUA_TTABLE ? LuaDLL.lua_typename(luaState, type) : "table";
        string str2 = LuaDLL.lua_tostring(luaState, index);
        if (type == LuaTypes.LUA_TUSERDATA)
          str2 = translator.getRawNetObject(luaState, index).ToString();
      }
    }

    [MonoPInvokeCallback(typeof (LuaCSFunction))]
    public static int getMethod(IntPtr luaState)
    {
      ObjectTranslator objectTranslator = ObjectTranslator.FromState(luaState);
      object rawNetObject = objectTranslator.getRawNetObject(luaState, 1);
      if (rawNetObject == null)
      {
        objectTranslator.throwError(luaState, "trying to index an invalid object reference");
        LuaDLL.lua_pushnil(luaState);
        return 1;
      }
      object asType = objectTranslator.getObject(luaState, 2);
      string methodName = asType as string;
      Type type = rawNetObject.GetType();
      try
      {
        if (methodName != null)
        {
          if (objectTranslator.metaFunctions.isMemberPresent((IReflect) type, methodName))
            return objectTranslator.metaFunctions.getMember(luaState, (IReflect) type, rawNetObject, methodName, BindingFlags.IgnoreCase | BindingFlags.Instance);
        }
      }
      catch
      {
      }
      bool flag = true;
      if (type.IsArray && asType is double num)
      {
        int index = (int) num;
        Array array = rawNetObject as Array;
        if (index >= array.Length)
          return objectTranslator.pushError(luaState, "array index out of bounds: " + (object) index + " " + (object) array.Length);
        object o = array.GetValue(index);
        objectTranslator.push(luaState, o);
        flag = false;
      }
      else
      {
        foreach (MethodInfo method in type.GetMethods())
        {
          if (method.Name == "get_Item" && method.GetParameters().Length == 1)
          {
            MethodInfo methodInfo = method;
            ParameterInfo[] parameters = (object) methodInfo == null ? (ParameterInfo[]) null : methodInfo.GetParameters();
            if (parameters == null || parameters.Length != 1)
              return objectTranslator.pushError(luaState, "method not found (or no indexer): " + asType);
            asType = objectTranslator.getAsType(luaState, 2, parameters[0].ParameterType);
            try
            {
              object o = methodInfo.Invoke(rawNetObject, new object[1]
              {
                asType
              });
              objectTranslator.push(luaState, o);
              flag = false;
            }
            catch (TargetInvocationException ex)
            {
              if (ex.InnerException is KeyNotFoundException)
                return objectTranslator.pushError(luaState, "key '" + asType + "' not found ");
              return objectTranslator.pushError(luaState, "exception indexing '" + asType + "' " + ex.Message);
            }
          }
        }
      }
      if (flag)
        return objectTranslator.pushError(luaState, "cannot find " + asType);
      LuaDLL.lua_pushboolean(luaState, false);
      return 2;
    }

    [MonoPInvokeCallback(typeof (LuaCSFunction))]
    public static int getBaseMethod(IntPtr luaState)
    {
      ObjectTranslator objectTranslator = ObjectTranslator.FromState(luaState);
      object rawNetObject = objectTranslator.getRawNetObject(luaState, 1);
      if (rawNetObject == null)
      {
        objectTranslator.throwError(luaState, "trying to index an invalid object reference");
        LuaDLL.lua_pushnil(luaState);
        LuaDLL.lua_pushboolean(luaState, false);
        return 2;
      }
      string methodName = LuaDLL.lua_tostring(luaState, 2);
      if (methodName == null)
      {
        LuaDLL.lua_pushnil(luaState);
        LuaDLL.lua_pushboolean(luaState, false);
        return 2;
      }
      objectTranslator.metaFunctions.getMember(luaState, (IReflect) rawNetObject.GetType(), rawNetObject, "__luaInterface_base_" + methodName, BindingFlags.IgnoreCase | BindingFlags.Instance);
      LuaDLL.lua_settop(luaState, -2);
      if (LuaDLL.lua_type(luaState, -1) == LuaTypes.LUA_TNIL)
      {
        LuaDLL.lua_settop(luaState, -2);
        return objectTranslator.metaFunctions.getMember(luaState, (IReflect) rawNetObject.GetType(), rawNetObject, methodName, BindingFlags.IgnoreCase | BindingFlags.Instance);
      }
      LuaDLL.lua_pushboolean(luaState, false);
      return 2;
    }

    private bool isMemberPresent(IReflect objType, string methodName)
    {
      return this.checkMemberCache(this.memberCache, objType, methodName) != null || objType.GetMember(methodName, BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public).Length > 0;
    }

    private int getMember(
      IntPtr luaState,
      IReflect objType,
      object obj,
      string methodName,
      BindingFlags bindingType)
    {
      bool flag = false;
      MemberInfo member1 = (MemberInfo) null;
      object func = this.checkMemberCache(this.memberCache, objType, methodName);
      if (func is LuaCSFunction)
      {
        this.translator.pushFunction(luaState, (LuaCSFunction) func);
        this.translator.push(luaState, (object) true);
        return 2;
      }
      if (func != null)
      {
        member1 = (MemberInfo) func;
      }
      else
      {
        MemberInfo[] member2 = objType.GetMember(methodName, bindingType | BindingFlags.Public | BindingFlags.IgnoreCase);
        if (member2.Length > 0)
        {
          member1 = member2[0];
        }
        else
        {
          MemberInfo[] member3 = objType.GetMember(methodName, bindingType | BindingFlags.Static | BindingFlags.Public | BindingFlags.IgnoreCase);
          if (member3.Length > 0)
          {
            member1 = member3[0];
            flag = true;
          }
        }
      }
      if ((object) member1 != null)
      {
        if (member1.MemberType == MemberTypes.Field)
        {
          FieldInfo fieldInfo = (FieldInfo) member1;
          if (func == null)
            this.setMemberCache(this.memberCache, objType, methodName, (object) member1);
          try
          {
            this.translator.push(luaState, fieldInfo.GetValue(obj));
          }
          catch
          {
            LuaDLL.lua_pushnil(luaState);
          }
        }
        else if (member1.MemberType == MemberTypes.Property)
        {
          PropertyInfo propertyInfo = (PropertyInfo) member1;
          if (func == null)
            this.setMemberCache(this.memberCache, objType, methodName, (object) member1);
          try
          {
            object o = propertyInfo.GetGetMethod().Invoke(obj, (object[]) null);
            this.translator.push(luaState, o);
          }
          catch (ArgumentException ex)
          {
            if ((object) (objType as Type) != null && (object) (Type) objType != (object) typeof (object))
              return this.getMember(luaState, (IReflect) ((Type) objType).BaseType, obj, methodName, bindingType);
            LuaDLL.lua_pushnil(luaState);
          }
          catch (TargetInvocationException ex)
          {
            this.ThrowError(luaState, (Exception) ex);
            LuaDLL.lua_pushnil(luaState);
          }
        }
        else if (member1.MemberType == MemberTypes.Event)
        {
          EventInfo eventInfo = (EventInfo) member1;
          if (func == null)
            this.setMemberCache(this.memberCache, objType, methodName, (object) member1);
          this.translator.push(luaState, (object) new RegisterEventHandler(this.translator.pendingEvents, obj, eventInfo));
        }
        else if (!flag)
        {
          if (member1.MemberType == MemberTypes.NestedType)
          {
            if (func == null)
              this.setMemberCache(this.memberCache, objType, methodName, (object) member1);
            string name = member1.Name;
            Type type = this.translator.FindType(member1.DeclaringType.FullName + "+" + name);
            this.translator.pushType(luaState, type);
          }
          else
          {
            LuaCSFunction luaCsFunction = new LuaCSFunction(new LuaMethodWrapper(this.translator, objType, methodName, bindingType).call);
            if (func == null)
              this.setMemberCache(this.memberCache, objType, methodName, (object) luaCsFunction);
            this.translator.pushFunction(luaState, luaCsFunction);
            this.translator.push(luaState, (object) true);
            return 2;
          }
        }
        else
        {
          this.translator.throwError(luaState, "can't pass instance to static method " + methodName);
          LuaDLL.lua_pushnil(luaState);
        }
      }
      else
      {
        this.translator.throwError(luaState, "unknown member name " + methodName);
        LuaDLL.lua_pushnil(luaState);
      }
      this.translator.push(luaState, (object) false);
      return 2;
    }

    private object checkMemberCache(Hashtable memberCache, IReflect objType, string memberName)
    {
      return ((Hashtable) memberCache[(object) objType])?[(object) memberName];
    }

    private void setMemberCache(
      Hashtable memberCache,
      IReflect objType,
      string memberName,
      object member)
    {
      Hashtable hashtable = (Hashtable) memberCache[(object) objType];
      if (hashtable == null)
      {
        hashtable = new Hashtable();
        memberCache[(object) objType] = (object) hashtable;
      }
      hashtable[(object) memberName] = member;
    }

    [MonoPInvokeCallback(typeof (LuaCSFunction))]
    public static int setFieldOrProperty(IntPtr luaState)
    {
      ObjectTranslator objectTranslator = ObjectTranslator.FromState(luaState);
      object rawNetObject = objectTranslator.getRawNetObject(luaState, 1);
      if (rawNetObject == null)
      {
        objectTranslator.throwError(luaState, "trying to index and invalid object reference");
        return 0;
      }
      Type type = rawNetObject.GetType();
      string detailMessage;
      if (objectTranslator.metaFunctions.trySetMember(luaState, (IReflect) type, rawNetObject, BindingFlags.IgnoreCase | BindingFlags.Instance, out detailMessage))
        return 0;
      try
      {
        if (type.IsArray && LuaDLL.lua_isnumber(luaState, 2))
        {
          int index = (int) LuaDLL.lua_tonumber(luaState, 2);
          Array array = (Array) rawNetObject;
          object asType = objectTranslator.getAsType(luaState, 3, array.GetType().GetElementType());
          array.SetValue(asType, index);
        }
        else
        {
          MethodInfo method = type.GetMethod("set_Item");
          if ((object) method != null)
          {
            ParameterInfo[] parameters1 = method.GetParameters();
            Type parameterType1 = parameters1[1].ParameterType;
            object asType = objectTranslator.getAsType(luaState, 3, parameterType1);
            Type parameterType2 = parameters1[0].ParameterType;
            object[] parameters2 = new object[2]
            {
              objectTranslator.getAsType(luaState, 2, parameterType2),
              asType
            };
            method.Invoke(rawNetObject, parameters2);
          }
          else
            objectTranslator.throwError(luaState, detailMessage);
        }
      }
      catch (SEHException ex)
      {
        throw;
      }
      catch (Exception ex)
      {
        objectTranslator.metaFunctions.ThrowError(luaState, ex);
      }
      return 0;
    }

    private bool trySetMember(
      IntPtr luaState,
      IReflect targetType,
      object target,
      BindingFlags bindingType,
      out string detailMessage)
    {
      detailMessage = (string) null;
      if (LuaDLL.lua_type(luaState, 2) != LuaTypes.LUA_TSTRING)
      {
        detailMessage = "property names must be strings";
        return false;
      }
      string str = LuaDLL.lua_tostring(luaState, 2);
      if (str == null || str.Length < 1 || !char.IsLetter(str[0]) && str[0] != '_')
      {
        detailMessage = "invalid property name";
        return false;
      }
      MemberInfo member1 = (MemberInfo) this.checkMemberCache(this.memberCache, targetType, str);
      if ((object) member1 == null)
      {
        MemberInfo[] member2 = targetType.GetMember(str, bindingType | BindingFlags.Public | BindingFlags.IgnoreCase);
        if (member2.Length > 0)
        {
          member1 = member2[0];
          this.setMemberCache(this.memberCache, targetType, str, (object) member1);
        }
        else
        {
          detailMessage = "field or property '" + str + "' does not exist";
          return false;
        }
      }
      if (member1.MemberType == MemberTypes.Field)
      {
        FieldInfo fieldInfo = (FieldInfo) member1;
        object asType = this.translator.getAsType(luaState, 3, fieldInfo.FieldType);
        try
        {
          fieldInfo.SetValue(target, asType);
        }
        catch (Exception ex)
        {
          this.ThrowError(luaState, ex);
        }
        return true;
      }
      if (member1.MemberType == MemberTypes.Property)
      {
        PropertyInfo propertyInfo = (PropertyInfo) member1;
        object asType = this.translator.getAsType(luaState, 3, propertyInfo.PropertyType);
        try
        {
          propertyInfo.SetValue(target, asType, (object[]) null);
        }
        catch (Exception ex)
        {
          this.ThrowError(luaState, ex);
        }
        return true;
      }
      detailMessage = "'" + str + "' is not a .net field or property";
      return false;
    }

    private int setMember(
      IntPtr luaState,
      IReflect targetType,
      object target,
      BindingFlags bindingType)
    {
      string detailMessage;
      if (!this.trySetMember(luaState, targetType, target, bindingType, out detailMessage))
        this.translator.throwError(luaState, detailMessage);
      return 0;
    }

    private void ThrowError(IntPtr luaState, Exception e)
    {
      if (e is TargetInvocationException invocationException)
        e = invocationException.InnerException;
      this.translator.throwError(luaState, e.Message);
    }

    [MonoPInvokeCallback(typeof (LuaCSFunction))]
    public static int getClassMethod(IntPtr luaState)
    {
      ObjectTranslator objectTranslator = ObjectTranslator.FromState(luaState);
      object rawNetObject = objectTranslator.getRawNetObject(luaState, 1);
      if (rawNetObject == null || !(rawNetObject is IReflect))
      {
        objectTranslator.throwError(luaState, "trying to index an invalid type reference");
        LuaDLL.lua_pushnil(luaState);
        return 1;
      }
      IReflect objType = (IReflect) rawNetObject;
      if (LuaDLL.lua_isnumber(luaState, 2))
      {
        int length = (int) LuaDLL.lua_tonumber(luaState, 2);
        objectTranslator.push(luaState, (object) Array.CreateInstance(objType.UnderlyingSystemType, length));
        return 1;
      }
      string methodName = LuaDLL.lua_tostring(luaState, 2);
      if (methodName != null)
        return objectTranslator.metaFunctions.getMember(luaState, objType, (object) null, methodName, BindingFlags.IgnoreCase | BindingFlags.Static | BindingFlags.FlattenHierarchy);
      LuaDLL.lua_pushnil(luaState);
      return 1;
    }

    [MonoPInvokeCallback(typeof (LuaCSFunction))]
    public static int setClassFieldOrProperty(IntPtr luaState)
    {
      ObjectTranslator objectTranslator = ObjectTranslator.FromState(luaState);
      object rawNetObject = objectTranslator.getRawNetObject(luaState, 1);
      if (rawNetObject == null || !(rawNetObject is IReflect))
      {
        objectTranslator.throwError(luaState, "trying to index an invalid type reference");
        return 0;
      }
      IReflect targetType = (IReflect) rawNetObject;
      return objectTranslator.metaFunctions.setMember(luaState, targetType, (object) null, BindingFlags.IgnoreCase | BindingFlags.Static | BindingFlags.FlattenHierarchy);
    }

    [MonoPInvokeCallback(typeof (LuaCSFunction))]
    public static int callConstructor(IntPtr luaState)
    {
      ObjectTranslator objectTranslator = ObjectTranslator.FromState(luaState);
      MethodCache methodCache = new MethodCache();
      object rawNetObject = objectTranslator.getRawNetObject(luaState, 1);
      if (rawNetObject == null || !(rawNetObject is IReflect))
      {
        LuaDLL.luaL_error(luaState, "trying to call constructor on an invalid type reference");
        LuaDLL.lua_pushnil(luaState);
        return 1;
      }
      IReflect reflect = (IReflect) rawNetObject;
      LuaDLL.lua_remove(luaState, 1);
      ConstructorInfo[] constructors = reflect.UnderlyingSystemType.GetConstructors();
      foreach (ConstructorInfo method in constructors)
      {
        if (objectTranslator.metaFunctions.matchParameters(luaState, (MethodBase) method, ref methodCache))
        {
          try
          {
            objectTranslator.push(luaState, method.Invoke(methodCache.args));
          }
          catch (TargetInvocationException ex)
          {
            objectTranslator.metaFunctions.ThrowError(luaState, (Exception) ex);
            LuaDLL.lua_pushnil(luaState);
          }
          catch
          {
            LuaDLL.lua_pushnil(luaState);
          }
          return 1;
        }
      }
      string str = constructors.Length != 0 ? constructors[0].Name : "unknown";
      LuaDLL.luaL_error(luaState, string.Format("{0} does not contain constructor({1}) argument match", (object) reflect.UnderlyingSystemType, (object) str));
      LuaDLL.lua_pushnil(luaState);
      return 1;
    }

    private static bool IsInteger(double x) => Math.Ceiling(x) == x;

    internal Array TableToArray(object luaParamValue, Type paramArrayType)
    {
      Array instance;
      if (luaParamValue is LuaTable)
      {
        LuaTable luaTable = (LuaTable) luaParamValue;
        IDictionaryEnumerator enumerator = luaTable.GetEnumerator();
        enumerator.Reset();
        instance = Array.CreateInstance(paramArrayType, luaTable.Values.Count);
        int index = 0;
        while (enumerator.MoveNext())
        {
          object int32 = enumerator.Value;
          if ((object) paramArrayType == (object) typeof (object) && int32 != null && (object) int32.GetType() == (object) typeof (double) && MetaFunctions.IsInteger((double) int32))
            int32 = (object) Convert.ToInt32((double) int32);
          instance.SetValue(Convert.ChangeType(int32, paramArrayType), index);
          ++index;
        }
      }
      else
      {
        instance = Array.CreateInstance(paramArrayType, 1);
        instance.SetValue(luaParamValue, 0);
      }
      return instance;
    }

    internal bool matchParameters(IntPtr luaState, MethodBase method, ref MethodCache methodCache)
    {
      bool flag = true;
      ParameterInfo[] parameters = method.GetParameters();
      int num1 = 1;
      int num2 = LuaDLL.lua_gettop(luaState);
      ArrayList arrayList = new ArrayList();
      List<int> intList = new List<int>();
      List<MethodArgs> methodArgsList = new List<MethodArgs>();
      foreach (ParameterInfo currentNetParam in parameters)
      {
        if (!currentNetParam.IsIn && currentNetParam.IsOut)
          intList.Add(arrayList.Add((object) null));
        else if (num1 > num2)
        {
          if (currentNetParam.IsOptional)
          {
            arrayList.Add(currentNetParam.DefaultValue);
          }
          else
          {
            flag = false;
            break;
          }
        }
        else
        {
          ExtractValue extractValue;
          if (this._IsTypeCorrect(luaState, num1, currentNetParam, out extractValue))
          {
            int num3 = arrayList.Add(extractValue(luaState, num1));
            methodArgsList.Add(new MethodArgs()
            {
              index = num3,
              extractValue = extractValue
            });
            if (currentNetParam.ParameterType.IsByRef)
              intList.Add(num3);
            ++num1;
          }
          else if (this._IsParamsArray(luaState, num1, currentNetParam, out extractValue))
          {
            object luaParamValue = extractValue(luaState, num1);
            Type elementType = currentNetParam.ParameterType.GetElementType();
            Array array = this.TableToArray(luaParamValue, elementType);
            int num4 = arrayList.Add((object) array);
            methodArgsList.Add(new MethodArgs()
            {
              index = num4,
              extractValue = extractValue,
              isParamsArray = true,
              paramsArrayType = elementType
            });
            ++num1;
          }
          else if (currentNetParam.IsOptional)
          {
            arrayList.Add(currentNetParam.DefaultValue);
          }
          else
          {
            flag = false;
            break;
          }
        }
      }
      if (num1 != num2 + 1)
        flag = false;
      if (flag)
      {
        methodCache.args = arrayList.ToArray();
        methodCache.cachedMethod = method;
        methodCache.outList = intList.ToArray();
        methodCache.argTypes = methodArgsList.ToArray();
      }
      return flag;
    }

    private bool _IsTypeCorrect(
      IntPtr luaState,
      int currentLuaParam,
      ParameterInfo currentNetParam,
      out ExtractValue extractValue)
    {
      try
      {
        return (extractValue = this.translator.typeChecker.checkType(luaState, currentLuaParam, currentNetParam.ParameterType)) != null;
      }
      catch
      {
        extractValue = (ExtractValue) null;
        return false;
      }
    }

    private bool _IsParamsArray(
      IntPtr luaState,
      int currentLuaParam,
      ParameterInfo currentNetParam,
      out ExtractValue extractValue)
    {
      extractValue = (ExtractValue) null;
      if (currentNetParam.GetCustomAttributes(typeof (ParamArrayAttribute), false).Length > 0)
      {
        LuaTypes luaTypes;
        try
        {
          luaTypes = LuaDLL.lua_type(luaState, currentLuaParam);
        }
        catch (Exception ex)
        {
          extractValue = (ExtractValue) null;
          return false;
        }
        if (luaTypes == LuaTypes.LUA_TTABLE)
        {
          try
          {
            extractValue = this.translator.typeChecker.getExtractor(typeof (LuaTable));
          }
          catch (Exception ex)
          {
          }
          if (extractValue != null)
            return true;
        }
        else
        {
          Type elementType = currentNetParam.ParameterType.GetElementType();
          try
          {
            extractValue = this.translator.typeChecker.checkType(luaState, currentLuaParam, elementType);
          }
          catch (Exception ex)
          {
          }
          if (extractValue != null)
            return true;
        }
      }
      return false;
    }
  }
}
