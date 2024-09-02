// Decompiled with JetBrains decompiler
// Type: LuaInterface.DelegateGenerator
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
