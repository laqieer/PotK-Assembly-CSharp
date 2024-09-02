// Decompiled with JetBrains decompiler
// Type: LuaInterface.LuaGlobalAttribute
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;

#nullable disable
namespace LuaInterface
{
  [AttributeUsage(AttributeTargets.Method)]
  public class LuaGlobalAttribute : Attribute
  {
    private string name;
    private string descript;

    public string Name
    {
      get => this.name;
      set => this.name = value;
    }

    public string Description
    {
      get => this.descript;
      set => this.descript = value;
    }
  }
}
