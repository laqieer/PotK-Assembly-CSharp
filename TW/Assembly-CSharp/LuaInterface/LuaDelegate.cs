// Decompiled with JetBrains decompiler
// Type: LuaInterface.LuaDelegate
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;

#nullable disable
namespace LuaInterface
{
  public class LuaDelegate
  {
    public Type[] returnTypes;
    public LuaFunction function;

    public LuaDelegate()
    {
      this.function = (LuaFunction) null;
      this.returnTypes = (Type[]) null;
    }

    public object callFunction(object[] args, object[] inArgs, int[] outArgs)
    {
      object[] objArray = this.function.call(inArgs, this.returnTypes);
      object obj;
      int index1;
      if ((object) this.returnTypes[0] == (object) typeof (void))
      {
        obj = (object) null;
        index1 = 0;
      }
      else
      {
        obj = objArray[0];
        index1 = 1;
      }
      for (int index2 = 0; index2 < outArgs.Length; ++index2)
      {
        args[outArgs[index2]] = objArray[index1];
        ++index1;
      }
      return obj;
    }
  }
}
