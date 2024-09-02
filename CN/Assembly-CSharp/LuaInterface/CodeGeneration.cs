// Decompiled with JetBrains decompiler
// Type: LuaInterface.CodeGeneration
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using System.Threading;

#nullable disable
namespace LuaInterface
{
  internal class CodeGeneration
  {
    private Type eventHandlerParent = typeof (LuaEventHandler);
    private Dictionary<Type, Type> eventHandlerCollection = new Dictionary<Type, Type>();
    private Type delegateParent = typeof (LuaDelegate);
    private Dictionary<Type, Type> delegateCollection = new Dictionary<Type, Type>();
    private Type classHelper = typeof (LuaClassHelper);
    private Dictionary<Type, LuaClassType> classCollection = new Dictionary<Type, LuaClassType>();
    private AssemblyName assemblyName;
    private AssemblyBuilder newAssembly;
    private ModuleBuilder newModule;
    private int luaClassNumber = 1;
    private static readonly CodeGeneration instance = new CodeGeneration();

    private CodeGeneration()
    {
      this.assemblyName = new AssemblyName();
      this.assemblyName.Name = "LuaInterface_generatedcode";
      this.newAssembly = Thread.GetDomain().DefineDynamicAssembly(this.assemblyName, AssemblyBuilderAccess.Run);
      this.newModule = this.newAssembly.DefineDynamicModule("LuaInterface_generatedcode");
    }

    public static CodeGeneration Instance => CodeGeneration.instance;

    private Type GenerateEvent(Type eventHandlerType)
    {
      string name;
      lock (this)
      {
        name = "LuaGeneratedClass" + (object) this.luaClassNumber;
        ++this.luaClassNumber;
      }
      TypeBuilder typeBuilder = this.newModule.DefineType(name, TypeAttributes.Public, this.eventHandlerParent);
      Type[] parameterTypes = new Type[2]
      {
        typeof (object),
        eventHandlerType
      };
      Type returnType = typeof (void);
      ILGenerator ilGenerator = typeBuilder.DefineMethod("HandleEvent", MethodAttributes.Public | MethodAttributes.HideBySig, returnType, parameterTypes).GetILGenerator();
      ilGenerator.Emit(OpCodes.Ldarg_0);
      ilGenerator.Emit(OpCodes.Ldarg_1);
      ilGenerator.Emit(OpCodes.Ldarg_2);
      MethodInfo method = this.eventHandlerParent.GetMethod("handleEvent");
      ilGenerator.Emit(OpCodes.Call, method);
      ilGenerator.Emit(OpCodes.Ret);
      return typeBuilder.CreateType();
    }

    private Type GenerateDelegate(Type delegateType)
    {
      string name;
      lock (this)
      {
        name = "LuaGeneratedClass" + (object) this.luaClassNumber;
        ++this.luaClassNumber;
      }
      TypeBuilder typeBuilder = this.newModule.DefineType(name, TypeAttributes.Public, this.delegateParent);
      MethodInfo method1 = delegateType.GetMethod("Invoke");
      ParameterInfo[] parameters = method1.GetParameters();
      Type[] parameterTypes = new Type[parameters.Length];
      Type returnType = method1.ReturnType;
      int num1 = 0;
      int length = 0;
      for (int index = 0; index < parameterTypes.Length; ++index)
      {
        parameterTypes[index] = parameters[index].ParameterType;
        if (!parameters[index].IsIn && parameters[index].IsOut)
          ++num1;
        if (parameterTypes[index].IsByRef)
          ++length;
      }
      int[] numArray = new int[length];
      ILGenerator ilGenerator = typeBuilder.DefineMethod("CallFunction", method1.Attributes, returnType, parameterTypes).GetILGenerator();
      ilGenerator.DeclareLocal(typeof (object[]));
      ilGenerator.DeclareLocal(typeof (object[]));
      ilGenerator.DeclareLocal(typeof (int[]));
      if ((object) returnType != (object) typeof (void))
        ilGenerator.DeclareLocal(returnType);
      else
        ilGenerator.DeclareLocal(typeof (object));
      ilGenerator.Emit(OpCodes.Ldc_I4, parameterTypes.Length);
      ilGenerator.Emit(OpCodes.Newarr, typeof (object));
      ilGenerator.Emit(OpCodes.Stloc_0);
      ilGenerator.Emit(OpCodes.Ldc_I4, parameterTypes.Length - num1);
      ilGenerator.Emit(OpCodes.Newarr, typeof (object));
      ilGenerator.Emit(OpCodes.Stloc_1);
      ilGenerator.Emit(OpCodes.Ldc_I4, length);
      ilGenerator.Emit(OpCodes.Newarr, typeof (int));
      ilGenerator.Emit(OpCodes.Stloc_2);
      int index1 = 0;
      int num2 = 0;
      int index2 = 0;
      for (; index1 < parameterTypes.Length; ++index1)
      {
        ilGenerator.Emit(OpCodes.Ldloc_0);
        ilGenerator.Emit(OpCodes.Ldc_I4, index1);
        ilGenerator.Emit(OpCodes.Ldarg, index1 + 1);
        if (parameterTypes[index1].IsByRef)
        {
          if (parameterTypes[index1].GetElementType().IsValueType)
          {
            ilGenerator.Emit(OpCodes.Ldobj, parameterTypes[index1].GetElementType());
            ilGenerator.Emit(OpCodes.Box, parameterTypes[index1].GetElementType());
          }
          else
            ilGenerator.Emit(OpCodes.Ldind_Ref);
        }
        else if (parameterTypes[index1].IsValueType)
          ilGenerator.Emit(OpCodes.Box, parameterTypes[index1]);
        ilGenerator.Emit(OpCodes.Stelem_Ref);
        if (parameterTypes[index1].IsByRef)
        {
          ilGenerator.Emit(OpCodes.Ldloc_2);
          ilGenerator.Emit(OpCodes.Ldc_I4, index2);
          ilGenerator.Emit(OpCodes.Ldc_I4, index1);
          ilGenerator.Emit(OpCodes.Stelem_I4);
          numArray[index2] = index1;
          ++index2;
        }
        if (parameters[index1].IsIn || !parameters[index1].IsOut)
        {
          ilGenerator.Emit(OpCodes.Ldloc_1);
          ilGenerator.Emit(OpCodes.Ldc_I4, num2);
          ilGenerator.Emit(OpCodes.Ldarg, index1 + 1);
          if (parameterTypes[index1].IsByRef)
          {
            if (parameterTypes[index1].GetElementType().IsValueType)
            {
              ilGenerator.Emit(OpCodes.Ldobj, parameterTypes[index1].GetElementType());
              ilGenerator.Emit(OpCodes.Box, parameterTypes[index1].GetElementType());
            }
            else
              ilGenerator.Emit(OpCodes.Ldind_Ref);
          }
          else if (parameterTypes[index1].IsValueType)
            ilGenerator.Emit(OpCodes.Box, parameterTypes[index1]);
          ilGenerator.Emit(OpCodes.Stelem_Ref);
          ++num2;
        }
      }
      ilGenerator.Emit(OpCodes.Ldarg_0);
      ilGenerator.Emit(OpCodes.Ldloc_0);
      ilGenerator.Emit(OpCodes.Ldloc_1);
      ilGenerator.Emit(OpCodes.Ldloc_2);
      MethodInfo method2 = this.delegateParent.GetMethod("callFunction");
      ilGenerator.Emit(OpCodes.Call, method2);
      if ((object) returnType == (object) typeof (void))
      {
        ilGenerator.Emit(OpCodes.Pop);
        ilGenerator.Emit(OpCodes.Ldnull);
      }
      else if (returnType.IsValueType)
      {
        ilGenerator.Emit(OpCodes.Unbox, returnType);
        ilGenerator.Emit(OpCodes.Ldobj, returnType);
      }
      else
        ilGenerator.Emit(OpCodes.Castclass, returnType);
      ilGenerator.Emit(OpCodes.Stloc_3);
      for (int index3 = 0; index3 < numArray.Length; ++index3)
      {
        ilGenerator.Emit(OpCodes.Ldarg, numArray[index3] + 1);
        ilGenerator.Emit(OpCodes.Ldloc_0);
        ilGenerator.Emit(OpCodes.Ldc_I4, numArray[index3]);
        ilGenerator.Emit(OpCodes.Ldelem_Ref);
        if (parameterTypes[numArray[index3]].GetElementType().IsValueType)
        {
          ilGenerator.Emit(OpCodes.Unbox, parameterTypes[numArray[index3]].GetElementType());
          ilGenerator.Emit(OpCodes.Ldobj, parameterTypes[numArray[index3]].GetElementType());
          ilGenerator.Emit(OpCodes.Stobj, parameterTypes[numArray[index3]].GetElementType());
        }
        else
        {
          ilGenerator.Emit(OpCodes.Castclass, parameterTypes[numArray[index3]].GetElementType());
          ilGenerator.Emit(OpCodes.Stind_Ref);
        }
      }
      if ((object) returnType != (object) typeof (void))
        ilGenerator.Emit(OpCodes.Ldloc_3);
      ilGenerator.Emit(OpCodes.Ret);
      return typeBuilder.CreateType();
    }

    public void GenerateClass(
      Type klass,
      out Type newType,
      out Type[][] returnTypes,
      LuaTable luaTable)
    {
      string name;
      lock (this)
      {
        name = "LuaGeneratedClass" + (object) this.luaClassNumber;
        ++this.luaClassNumber;
      }
      TypeBuilder myType;
      if (klass.IsInterface)
        myType = this.newModule.DefineType(name, TypeAttributes.Public, typeof (object), new Type[2]
        {
          klass,
          typeof (ILuaGeneratedType)
        });
      else
        myType = this.newModule.DefineType(name, TypeAttributes.Public, klass, new Type[1]
        {
          typeof (ILuaGeneratedType)
        });
      FieldBuilder fieldBuilder1 = myType.DefineField("__luaInterface_luaTable", typeof (LuaTable), FieldAttributes.Public);
      FieldBuilder fieldBuilder2 = myType.DefineField("__luaInterface_returnTypes", typeof (Type[][]), FieldAttributes.Public);
      ILGenerator ilGenerator1 = myType.DefineConstructor(MethodAttributes.Public, CallingConventions.Standard, new Type[2]
      {
        typeof (LuaTable),
        typeof (Type[][])
      }).GetILGenerator();
      ilGenerator1.Emit(OpCodes.Ldarg_0);
      if (klass.IsInterface)
        ilGenerator1.Emit(OpCodes.Call, typeof (object).GetConstructor(Type.EmptyTypes));
      else
        ilGenerator1.Emit(OpCodes.Call, klass.GetConstructor(Type.EmptyTypes));
      ilGenerator1.Emit(OpCodes.Ldarg_0);
      ilGenerator1.Emit(OpCodes.Ldarg_1);
      ilGenerator1.Emit(OpCodes.Stfld, (FieldInfo) fieldBuilder1);
      ilGenerator1.Emit(OpCodes.Ldarg_0);
      ilGenerator1.Emit(OpCodes.Ldarg_2);
      ilGenerator1.Emit(OpCodes.Stfld, (FieldInfo) fieldBuilder2);
      ilGenerator1.Emit(OpCodes.Ret);
      BindingFlags bindingAttr = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
      MethodInfo[] methods = klass.GetMethods(bindingAttr);
      returnTypes = new Type[methods.Length][];
      int methodIndex = 0;
      foreach (MethodInfo method in methods)
      {
        if (klass.IsInterface)
        {
          this.GenerateMethod(myType, method, MethodAttributes.Virtual | MethodAttributes.HideBySig | MethodAttributes.VtableLayoutMask, methodIndex, (FieldInfo) fieldBuilder1, (FieldInfo) fieldBuilder2, false, out returnTypes[methodIndex]);
          ++methodIndex;
        }
        else if (!method.IsPrivate && !method.IsFinal && method.IsVirtual && luaTable[method.Name] != null)
        {
          this.GenerateMethod(myType, method, (method.Attributes | MethodAttributes.VtableLayoutMask) ^ MethodAttributes.VtableLayoutMask, methodIndex, (FieldInfo) fieldBuilder1, (FieldInfo) fieldBuilder2, true, out returnTypes[methodIndex]);
          ++methodIndex;
        }
      }
      MethodBuilder methodInfoBody = myType.DefineMethod("__luaInterface_getLuaTable", MethodAttributes.Public | MethodAttributes.Virtual | MethodAttributes.HideBySig, typeof (LuaTable), new Type[0]);
      myType.DefineMethodOverride((MethodInfo) methodInfoBody, typeof (ILuaGeneratedType).GetMethod("__luaInterface_getLuaTable"));
      ILGenerator ilGenerator2 = methodInfoBody.GetILGenerator();
      ilGenerator2.Emit(OpCodes.Ldarg_0);
      ilGenerator2.Emit(OpCodes.Ldfld, (FieldInfo) fieldBuilder1);
      ilGenerator2.Emit(OpCodes.Ret);
      newType = myType.CreateType();
    }

    private void GenerateMethod(
      TypeBuilder myType,
      MethodInfo method,
      MethodAttributes attributes,
      int methodIndex,
      FieldInfo luaTableField,
      FieldInfo returnTypesField,
      bool generateBase,
      out Type[] returnTypes)
    {
      ParameterInfo[] parameters = method.GetParameters();
      Type[] parameterTypes = new Type[parameters.Length];
      List<Type> typeList = new List<Type>();
      int num1 = 0;
      int length = 0;
      Type returnType = method.ReturnType;
      typeList.Add(returnType);
      for (int index = 0; index < parameterTypes.Length; ++index)
      {
        parameterTypes[index] = parameters[index].ParameterType;
        if (!parameters[index].IsIn && parameters[index].IsOut)
          ++num1;
        if (parameterTypes[index].IsByRef)
        {
          typeList.Add(parameterTypes[index].GetElementType());
          ++length;
        }
      }
      int[] numArray = new int[length];
      returnTypes = typeList.ToArray();
      if (generateBase)
      {
        string name = "__luaInterface_base_" + method.Name;
        ILGenerator ilGenerator = myType.DefineMethod(name, MethodAttributes.Public | MethodAttributes.HideBySig | MethodAttributes.VtableLayoutMask, returnType, parameterTypes).GetILGenerator();
        ilGenerator.Emit(OpCodes.Ldarg_0);
        for (int index = 0; index < parameterTypes.Length; ++index)
          ilGenerator.Emit(OpCodes.Ldarg, index + 1);
        ilGenerator.Emit(OpCodes.Call, method);
        ilGenerator.Emit(OpCodes.Ret);
      }
      MethodBuilder methodInfoBody = myType.DefineMethod(method.Name, attributes, returnType, parameterTypes);
      if (myType.BaseType.Equals(typeof (object)))
        myType.DefineMethodOverride((MethodInfo) methodInfoBody, method);
      ILGenerator ilGenerator1 = methodInfoBody.GetILGenerator();
      ilGenerator1.DeclareLocal(typeof (object[]));
      ilGenerator1.DeclareLocal(typeof (object[]));
      ilGenerator1.DeclareLocal(typeof (int[]));
      if ((object) returnType != (object) typeof (void))
        ilGenerator1.DeclareLocal(returnType);
      else
        ilGenerator1.DeclareLocal(typeof (object));
      ilGenerator1.Emit(OpCodes.Ldc_I4, parameterTypes.Length);
      ilGenerator1.Emit(OpCodes.Newarr, typeof (object));
      ilGenerator1.Emit(OpCodes.Stloc_0);
      ilGenerator1.Emit(OpCodes.Ldc_I4, parameterTypes.Length - num1 + 1);
      ilGenerator1.Emit(OpCodes.Newarr, typeof (object));
      ilGenerator1.Emit(OpCodes.Stloc_1);
      ilGenerator1.Emit(OpCodes.Ldc_I4, length);
      ilGenerator1.Emit(OpCodes.Newarr, typeof (int));
      ilGenerator1.Emit(OpCodes.Stloc_2);
      ilGenerator1.Emit(OpCodes.Ldloc_1);
      ilGenerator1.Emit(OpCodes.Ldc_I4_0);
      ilGenerator1.Emit(OpCodes.Ldarg_0);
      ilGenerator1.Emit(OpCodes.Ldfld, luaTableField);
      ilGenerator1.Emit(OpCodes.Stelem_Ref);
      int index1 = 0;
      int num2 = 1;
      int index2 = 0;
      for (; index1 < parameterTypes.Length; ++index1)
      {
        ilGenerator1.Emit(OpCodes.Ldloc_0);
        ilGenerator1.Emit(OpCodes.Ldc_I4, index1);
        ilGenerator1.Emit(OpCodes.Ldarg, index1 + 1);
        if (parameterTypes[index1].IsByRef)
        {
          if (parameterTypes[index1].GetElementType().IsValueType)
          {
            ilGenerator1.Emit(OpCodes.Ldobj, parameterTypes[index1].GetElementType());
            ilGenerator1.Emit(OpCodes.Box, parameterTypes[index1].GetElementType());
          }
          else
            ilGenerator1.Emit(OpCodes.Ldind_Ref);
        }
        else if (parameterTypes[index1].IsValueType)
          ilGenerator1.Emit(OpCodes.Box, parameterTypes[index1]);
        ilGenerator1.Emit(OpCodes.Stelem_Ref);
        if (parameterTypes[index1].IsByRef)
        {
          ilGenerator1.Emit(OpCodes.Ldloc_2);
          ilGenerator1.Emit(OpCodes.Ldc_I4, index2);
          ilGenerator1.Emit(OpCodes.Ldc_I4, index1);
          ilGenerator1.Emit(OpCodes.Stelem_I4);
          numArray[index2] = index1;
          ++index2;
        }
        if (parameters[index1].IsIn || !parameters[index1].IsOut)
        {
          ilGenerator1.Emit(OpCodes.Ldloc_1);
          ilGenerator1.Emit(OpCodes.Ldc_I4, num2);
          ilGenerator1.Emit(OpCodes.Ldarg, index1 + 1);
          if (parameterTypes[index1].IsByRef)
          {
            if (parameterTypes[index1].GetElementType().IsValueType)
            {
              ilGenerator1.Emit(OpCodes.Ldobj, parameterTypes[index1].GetElementType());
              ilGenerator1.Emit(OpCodes.Box, parameterTypes[index1].GetElementType());
            }
            else
              ilGenerator1.Emit(OpCodes.Ldind_Ref);
          }
          else if (parameterTypes[index1].IsValueType)
            ilGenerator1.Emit(OpCodes.Box, parameterTypes[index1]);
          ilGenerator1.Emit(OpCodes.Stelem_Ref);
          ++num2;
        }
      }
      ilGenerator1.Emit(OpCodes.Ldarg_0);
      ilGenerator1.Emit(OpCodes.Ldfld, luaTableField);
      ilGenerator1.Emit(OpCodes.Ldstr, method.Name);
      ilGenerator1.Emit(OpCodes.Call, this.classHelper.GetMethod("getTableFunction"));
      Label label1 = ilGenerator1.DefineLabel();
      ilGenerator1.Emit(OpCodes.Dup);
      ilGenerator1.Emit(OpCodes.Brtrue_S, label1);
      ilGenerator1.Emit(OpCodes.Pop);
      if (!method.IsAbstract)
      {
        ilGenerator1.Emit(OpCodes.Ldarg_0);
        for (int index3 = 0; index3 < parameterTypes.Length; ++index3)
          ilGenerator1.Emit(OpCodes.Ldarg, index3 + 1);
        ilGenerator1.Emit(OpCodes.Call, method);
        if ((object) returnType == (object) typeof (void))
          ilGenerator1.Emit(OpCodes.Pop);
        ilGenerator1.Emit(OpCodes.Ret);
        ilGenerator1.Emit(OpCodes.Ldnull);
      }
      else
        ilGenerator1.Emit(OpCodes.Ldnull);
      Label label2 = ilGenerator1.DefineLabel();
      ilGenerator1.Emit(OpCodes.Br_S, label2);
      ilGenerator1.MarkLabel(label1);
      ilGenerator1.Emit(OpCodes.Ldloc_0);
      ilGenerator1.Emit(OpCodes.Ldarg_0);
      ilGenerator1.Emit(OpCodes.Ldfld, returnTypesField);
      ilGenerator1.Emit(OpCodes.Ldc_I4, methodIndex);
      ilGenerator1.Emit(OpCodes.Ldelem_Ref);
      ilGenerator1.Emit(OpCodes.Ldloc_1);
      ilGenerator1.Emit(OpCodes.Ldloc_2);
      ilGenerator1.Emit(OpCodes.Call, this.classHelper.GetMethod("callFunction"));
      ilGenerator1.MarkLabel(label2);
      if ((object) returnType == (object) typeof (void))
      {
        ilGenerator1.Emit(OpCodes.Pop);
        ilGenerator1.Emit(OpCodes.Ldnull);
      }
      else if (returnType.IsValueType)
      {
        ilGenerator1.Emit(OpCodes.Unbox, returnType);
        ilGenerator1.Emit(OpCodes.Ldobj, returnType);
      }
      else
        ilGenerator1.Emit(OpCodes.Castclass, returnType);
      ilGenerator1.Emit(OpCodes.Stloc_3);
      for (int index4 = 0; index4 < numArray.Length; ++index4)
      {
        ilGenerator1.Emit(OpCodes.Ldarg, numArray[index4] + 1);
        ilGenerator1.Emit(OpCodes.Ldloc_0);
        ilGenerator1.Emit(OpCodes.Ldc_I4, numArray[index4]);
        ilGenerator1.Emit(OpCodes.Ldelem_Ref);
        if (parameterTypes[numArray[index4]].GetElementType().IsValueType)
        {
          ilGenerator1.Emit(OpCodes.Unbox, parameterTypes[numArray[index4]].GetElementType());
          ilGenerator1.Emit(OpCodes.Ldobj, parameterTypes[numArray[index4]].GetElementType());
          ilGenerator1.Emit(OpCodes.Stobj, parameterTypes[numArray[index4]].GetElementType());
        }
        else
        {
          ilGenerator1.Emit(OpCodes.Castclass, parameterTypes[numArray[index4]].GetElementType());
          ilGenerator1.Emit(OpCodes.Stind_Ref);
        }
      }
      if ((object) returnType != (object) typeof (void))
        ilGenerator1.Emit(OpCodes.Ldloc_3);
      ilGenerator1.Emit(OpCodes.Ret);
    }

    public LuaEventHandler GetEvent(Type eventHandlerType, LuaFunction eventHandler)
    {
      Type eventHandler1;
      if (this.eventHandlerCollection.ContainsKey(eventHandlerType))
      {
        eventHandler1 = this.eventHandlerCollection[eventHandlerType];
      }
      else
      {
        eventHandler1 = this.GenerateEvent(eventHandlerType);
        this.eventHandlerCollection[eventHandlerType] = eventHandler1;
      }
      LuaEventHandler instance = (LuaEventHandler) Activator.CreateInstance(eventHandler1);
      instance.handler = eventHandler;
      return instance;
    }

    public Delegate GetDelegate(Type delegateType, LuaFunction luaFunc)
    {
      List<Type> typeList = new List<Type>();
      Type type;
      if (this.delegateCollection.ContainsKey(delegateType))
      {
        type = this.delegateCollection[delegateType];
      }
      else
      {
        type = this.GenerateDelegate(delegateType);
        this.delegateCollection[delegateType] = type;
      }
      MethodInfo method = delegateType.GetMethod("Invoke");
      typeList.Add(method.ReturnType);
      foreach (ParameterInfo parameter in method.GetParameters())
      {
        if (parameter.ParameterType.IsByRef)
          typeList.Add(parameter.ParameterType);
      }
      LuaDelegate instance = (LuaDelegate) Activator.CreateInstance(type);
      instance.function = luaFunc;
      instance.returnTypes = typeList.ToArray();
      return Delegate.CreateDelegate(delegateType, (object) instance, "CallFunction");
    }

    public object GetClassInstance(Type klass, LuaTable luaTable)
    {
      LuaClassType luaClassType;
      if (this.classCollection.ContainsKey(klass))
      {
        luaClassType = this.classCollection[klass];
      }
      else
      {
        luaClassType = new LuaClassType();
        this.GenerateClass(klass, out luaClassType.klass, out luaClassType.returnTypes, luaTable);
        this.classCollection[klass] = luaClassType;
      }
      return Activator.CreateInstance(luaClassType.klass, (object) luaTable, (object) luaClassType.returnTypes);
    }
  }
}
