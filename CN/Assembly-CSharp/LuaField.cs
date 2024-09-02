// Decompiled with JetBrains decompiler
// Type: LuaField
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using LuaInterface;

#nullable disable
public struct LuaField
{
  public string name;
  public LuaCSFunction getter;
  public LuaCSFunction setter;

  public LuaField(string str, LuaCSFunction g, LuaCSFunction s)
  {
    this.name = str;
    this.getter = g;
    this.setter = s;
  }
}
