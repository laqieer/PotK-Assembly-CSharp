// Decompiled with JetBrains decompiler
// Type: LuaInterface.LuaGlobalAttribute
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
