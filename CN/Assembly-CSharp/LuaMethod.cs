// Decompiled with JetBrains decompiler
// Type: LuaMethod
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
