// Decompiled with JetBrains decompiler
// Type: LuaInterface.LuaClassHelper
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;

#nullable disable
namespace LuaInterface
{
  public class LuaClassHelper
  {
    public static LuaFunction getTableFunction(LuaTable luaTable, string name)
    {
      object obj = luaTable.rawget(name);
      return obj is LuaFunction ? (LuaFunction) obj : (LuaFunction) null;
    }

    public static object callFunction(
      LuaFunction function,
      object[] args,
      Type[] returnTypes,
      object[] inArgs,
      int[] outArgs)
    {
      object[] objArray = function.call(inArgs, returnTypes);
      object obj;
      int index1;
      if ((object) returnTypes[0] == (object) typeof (void))
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
