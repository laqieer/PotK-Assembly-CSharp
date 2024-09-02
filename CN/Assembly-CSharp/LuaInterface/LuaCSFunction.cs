// Decompiled with JetBrains decompiler
// Type: LuaInterface.LuaCSFunction
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using System.Runtime.InteropServices;

#nullable disable
namespace LuaInterface
{
  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate int LuaCSFunction(IntPtr luaState);
}
