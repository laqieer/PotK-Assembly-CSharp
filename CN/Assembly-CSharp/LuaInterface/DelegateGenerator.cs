// Decompiled with JetBrains decompiler
// Type: LuaInterface.DelegateGenerator
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;

#nullable disable
namespace LuaInterface
{
  internal class DelegateGenerator
  {
    private ObjectTranslator translator;
    private Type delegateType;

    public DelegateGenerator(ObjectTranslator translator, Type delegateType)
    {
      this.translator = translator;
      this.delegateType = delegateType;
    }

    public object extractGenerated(IntPtr luaState, int stackPos)
    {
      return (object) CodeGeneration.Instance.GetDelegate(this.delegateType, this.translator.getFunction(luaState, stackPos));
    }
  }
}
