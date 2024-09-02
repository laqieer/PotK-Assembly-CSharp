// Decompiled with JetBrains decompiler
// Type: LuaStringBuffer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
