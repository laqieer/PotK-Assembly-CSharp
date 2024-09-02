// Decompiled with JetBrains decompiler
// Type: LuaRef
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;

#nullable disable
public class LuaRef
{
  public IntPtr L;
  public int reference;

  public LuaRef(IntPtr L, int reference)
  {
    this.L = L;
    this.reference = reference;
  }
}
