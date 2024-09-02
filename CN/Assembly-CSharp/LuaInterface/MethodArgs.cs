// Decompiled with JetBrains decompiler
// Type: LuaInterface.MethodArgs
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;

#nullable disable
namespace LuaInterface
{
  internal struct MethodArgs
  {
    public int index;
    public ExtractValue extractValue;
    public bool isParamsArray;
    public Type paramsArrayType;
  }
}
