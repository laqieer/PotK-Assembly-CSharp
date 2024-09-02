// Decompiled with JetBrains decompiler
// Type: LuaInterface.ProxyType
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using System.Globalization;
using System.Reflection;

#nullable disable
namespace LuaInterface
{
  public class ProxyType : IReflect
  {
    private Type proxy;

    public ProxyType(Type proxy) => this.proxy = proxy;

    public override string ToString() => "ProxyType(" + (object) this.UnderlyingSystemType + ")";

    public Type UnderlyingSystemType => this.proxy;

    public FieldInfo GetField(string name, BindingFlags bindingAttr)
    {
      return this.proxy.GetField(name, bindingAttr);
    }

    public FieldInfo[] GetFields(BindingFlags bindingAttr) => this.proxy.GetFields(bindingAttr);

    public MemberInfo[] GetMember(string name, BindingFlags bindingAttr)
    {
      return this.proxy.GetMember(name, bindingAttr);
    }

    public MemberInfo[] GetMembers(BindingFlags bindingAttr) => this.proxy.GetMembers(bindingAttr);

    public MethodInfo GetMethod(string name, BindingFlags bindingAttr)
    {
      return this.proxy.GetMethod(name, bindingAttr);
    }

    public MethodInfo GetMethod(
      string name,
      BindingFlags bindingAttr,
      Binder binder,
      Type[] types,
      ParameterModifier[] modifiers)
    {
      return this.proxy.GetMethod(name, bindingAttr, binder, types, modifiers);
    }

    public MethodInfo[] GetMethods(BindingFlags bindingAttr) => this.proxy.GetMethods(bindingAttr);

    public PropertyInfo GetProperty(string name, BindingFlags bindingAttr)
    {
      return this.proxy.GetProperty(name, bindingAttr);
    }

    public PropertyInfo GetProperty(
      string name,
      BindingFlags bindingAttr,
      Binder binder,
      Type returnType,
      Type[] types,
      ParameterModifier[] modifiers)
    {
      return this.proxy.GetProperty(name, bindingAttr, binder, returnType, types, modifiers);
    }

    public PropertyInfo[] GetProperties(BindingFlags bindingAttr)
    {
      return this.proxy.GetProperties(bindingAttr);
    }

    public object InvokeMember(
      string name,
      BindingFlags invokeAttr,
      Binder binder,
      object target,
      object[] args,
      ParameterModifier[] modifiers,
      CultureInfo culture,
      string[] namedParameters)
    {
      return this.proxy.InvokeMember(name, invokeAttr, binder, target, args, modifiers, culture, namedParameters);
    }
  }
}
