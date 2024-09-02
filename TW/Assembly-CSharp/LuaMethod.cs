// Decompiled with JetBrains decompiler
// Type: LuaMethod
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using LuaInterface;

#nullable disable
public struct LuaMethod
{
  public string name;
  public LuaCSFunction func;

  public LuaMethod(string str, LuaCSFunction f)
  {
    this.name = str;
    this.func = f;
  }
}
