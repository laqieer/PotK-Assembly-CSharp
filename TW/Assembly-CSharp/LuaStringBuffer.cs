// Decompiled with JetBrains decompiler
// Type: LuaStringBuffer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using System.Runtime.InteropServices;

#nullable disable
public class LuaStringBuffer
{
  public byte[] buffer;

  public LuaStringBuffer(IntPtr source, int len)
  {
    this.buffer = new byte[len];
    Marshal.Copy(source, this.buffer, 0, len);
  }

  public LuaStringBuffer(byte[] buf) => this.buffer = buf;
}
