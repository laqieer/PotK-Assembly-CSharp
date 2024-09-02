// Decompiled with JetBrains decompiler
// Type: CriStructMemory`1
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E910E095-517B-41AE-AAF8-B85E770EBAF1
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp-firstpass.dll

using System;
using System.Runtime.InteropServices;

#nullable disable
public class CriStructMemory<Type> : IDisposable
{
  private GCHandle gch;

  public CriStructMemory()
  {
    this.bytes = new byte[Marshal.SizeOf(typeof (Type))];
    this.gch = GCHandle.Alloc((object) this.bytes, GCHandleType.Pinned);
  }

  public byte[] bytes { get; private set; }

  public IntPtr ptr => this.gch.AddrOfPinnedObject();

  public void Dispose() => this.gch.Free();
}
