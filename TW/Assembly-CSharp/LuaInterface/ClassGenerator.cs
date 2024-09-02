// Decompiled with JetBrains decompiler
// Type: LuaInterface.ClassGenerator
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;

#nullable disable
namespace LuaInterface
{
  internal class ClassGenerator
  {
    private ObjectTranslator translator;
    private Type klass;

    public ClassGenerator(ObjectTranslator translator, Type klass)
    {
      this.translator = translator;
      this.klass = klass;
    }

    public object extractGenerated(IntPtr luaState, int stackPos)
    {
      return CodeGeneration.Instance.GetClassInstance(this.klass, this.translator.getTable(luaState, stackPos));
    }
  }
}
