// Decompiled with JetBrains decompiler
// Type: LuaRef
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
