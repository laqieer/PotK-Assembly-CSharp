// Decompiled with JetBrains decompiler
// Type: LuaInterface.MonoPInvokeCallbackAttribute
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;

#nullable disable
namespace LuaInterface
{
  public class MonoPInvokeCallbackAttribute : Attribute
  {
    private Type type;

    public MonoPInvokeCallbackAttribute(Type t) => this.type = t;
  }
}
