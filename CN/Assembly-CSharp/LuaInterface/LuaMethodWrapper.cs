// Decompiled with JetBrains decompiler
// Type: LuaInterface.LuaMethodWrapper
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace LuaInterface
{
  internal class LuaMethodWrapper
  {
    private ObjectTranslator _Translator;
    private MethodBase _Method;
    private MethodCache _LastCalledMethod = new MethodCache();
    private string _MethodName;
    private MemberInfo[] _Members;
    public IReflect _TargetType;
    private ExtractValue _ExtractTarget;
    private object _Target;
    private BindingFlags _BindingType;

    public LuaMethodWrapper(
      ObjectTranslator translator,
      object target,
      IReflect targetType,
      MethodBase method)
    {
      this._Translator = translator;
      this._Target = target;
      this._TargetType = targetType;
      if (targetType != null)
        this._ExtractTarget = translator.typeChecker.getExtractor(targetType);
      this._Method = method;
      this._MethodName = method.Name;
      if (method.IsStatic)
        this._BindingType = BindingFlags.Static;
      else
        this._BindingType = BindingFlags.Instance;
    }

    public LuaMethodWrapper(
      ObjectTranslator translator,
      IReflect targetType,
      string methodName,
      BindingFlags bindingType)
    {
      this._Translator = translator;
      this._MethodName = methodName;
      this._TargetType = targetType;
      if (targetType != null)
        this._ExtractTarget = translator.typeChecker.getExtractor(targetType);
      this._BindingType = bindingType;
      this._Members = targetType.UnderlyingSystemType.GetMember(methodName, MemberTypes.Method, bindingType | BindingFlags.Public | BindingFlags.IgnoreCase);
    }

    private int SetPendingException(Exception e)
    {
      return this._Translator.interpreter.SetPendingException(e);
    }

    private static bool IsInteger(double x) => Math.Ceiling(x) == x;

    public int call(IntPtr luaState)
    {
      MethodBase method1 = this._Method;
      object obj1 = this._Target;
      bool flag1 = true;
      int num1 = 0;
      if (!LuaDLL.lua_checkstack(luaState, 5))
        throw new LuaException("Lua stack overflow");
      bool flag2 = (this._BindingType & BindingFlags.Static) == BindingFlags.Static;
      this.SetPendingException((Exception) null);
      if ((object) method1 == null)
      {
        obj1 = !flag2 ? this._ExtractTarget(luaState, 1) : (object) null;
        if ((object) this._LastCalledMethod.cachedMethod != null)
        {
          int num2 = !flag2 ? 1 : 0;
          int num3 = LuaDLL.lua_gettop(luaState) - num2;
          MethodBase cachedMethod = this._LastCalledMethod.cachedMethod;
          if (num3 == this._LastCalledMethod.argTypes.Length)
          {
            if (!LuaDLL.lua_checkstack(luaState, this._LastCalledMethod.outList.Length + 6))
              throw new LuaException("Lua stack overflow");
            object[] args = this._LastCalledMethod.args;
            try
            {
              for (int index = 0; index < this._LastCalledMethod.argTypes.Length; ++index)
              {
                MethodArgs argType = this._LastCalledMethod.argTypes[index];
                object luaParamValue = argType.extractValue(luaState, index + 1 + num2);
                args[argType.index] = !this._LastCalledMethod.argTypes[index].isParamsArray ? luaParamValue : (object) this._Translator.tableToArray(luaParamValue, argType.paramsArrayType);
                if (args[argType.index] == null && !LuaDLL.lua_isnil(luaState, index + 1 + num2))
                  throw new LuaException("argument number " + (object) (index + 1) + " is invalid");
              }
              if ((this._BindingType & BindingFlags.Static) == BindingFlags.Static)
                this._Translator.push(luaState, cachedMethod.Invoke((object) null, args));
              else if (this._LastCalledMethod.cachedMethod.IsConstructor)
                this._Translator.push(luaState, ((ConstructorInfo) cachedMethod).Invoke(args));
              else
                this._Translator.push(luaState, cachedMethod.Invoke(obj1, args));
              flag1 = false;
            }
            catch (TargetInvocationException ex)
            {
              return this.SetPendingException(ex.GetBaseException());
            }
            catch (Exception ex)
            {
              if (this._Members.Length == 1)
                return this.SetPendingException(ex);
            }
          }
        }
        if (flag1)
        {
          if (!flag2)
          {
            if (obj1 == null)
            {
              this._Translator.throwError(luaState, string.Format("instance method '{0}' requires a non null target object", (object) this._MethodName));
              LuaDLL.lua_pushnil(luaState);
              return 1;
            }
            LuaDLL.lua_remove(luaState, 1);
          }
          bool flag3 = false;
          string str = (string) null;
          foreach (MemberInfo member in this._Members)
          {
            str = member.Name;
            MethodBase method2 = (MethodBase) member;
            if (this._Translator.matchParameters(luaState, method2, ref this._LastCalledMethod))
            {
              flag3 = true;
              break;
            }
          }
          if (!flag3)
          {
            string message = str != null ? "invalid arguments to method: " + str : "invalid arguments to method call";
            LuaDLL.luaL_error(luaState, message);
            LuaDLL.lua_pushnil(luaState);
            return 1;
          }
        }
      }
      else if (method1.ContainsGenericParameters)
      {
        this._Translator.matchParameters(luaState, method1, ref this._LastCalledMethod);
        if (method1.IsGenericMethodDefinition)
        {
          List<Type> typeList = new List<Type>();
          foreach (object obj2 in this._LastCalledMethod.args)
            typeList.Add(obj2.GetType());
          MethodInfo methodInfo = (method1 as MethodInfo).MakeGenericMethod(typeList.ToArray());
          this._Translator.push(luaState, methodInfo.Invoke(obj1, this._LastCalledMethod.args));
          flag1 = false;
        }
        else if (method1.ContainsGenericParameters)
        {
          LuaDLL.luaL_error(luaState, "unable to invoke method on generic class as the current method is an open generic method");
          LuaDLL.lua_pushnil(luaState);
          return 1;
        }
      }
      else
      {
        if (!method1.IsStatic && !method1.IsConstructor && obj1 == null)
        {
          obj1 = this._ExtractTarget(luaState, 1);
          LuaDLL.lua_remove(luaState, 1);
        }
        if (!this._Translator.matchParameters(luaState, method1, ref this._LastCalledMethod))
        {
          LuaDLL.luaL_error(luaState, "invalid arguments to method call");
          LuaDLL.lua_pushnil(luaState);
          return 1;
        }
      }
      if (flag1)
      {
        if (!LuaDLL.lua_checkstack(luaState, this._LastCalledMethod.outList.Length + 6))
          throw new LuaException("Lua stack overflow");
        try
        {
          if (flag2)
            this._Translator.push(luaState, this._LastCalledMethod.cachedMethod.Invoke((object) null, this._LastCalledMethod.args));
          else if (this._LastCalledMethod.cachedMethod.IsConstructor)
            this._Translator.push(luaState, ((ConstructorInfo) this._LastCalledMethod.cachedMethod).Invoke(this._LastCalledMethod.args));
          else
            this._Translator.push(luaState, this._LastCalledMethod.cachedMethod.Invoke(obj1, this._LastCalledMethod.args));
        }
        catch (TargetInvocationException ex)
        {
          return this.SetPendingException(ex.GetBaseException());
        }
        catch (Exception ex)
        {
          return this.SetPendingException(ex);
        }
      }
      for (int index = 0; index < this._LastCalledMethod.outList.Length; ++index)
      {
        ++num1;
        this._Translator.push(luaState, this._LastCalledMethod.args[this._LastCalledMethod.outList[index]]);
      }
      if (!this._LastCalledMethod.IsReturnVoid && num1 > 0)
        ++num1;
      return num1 < 1 ? 1 : num1;
    }
  }
}
