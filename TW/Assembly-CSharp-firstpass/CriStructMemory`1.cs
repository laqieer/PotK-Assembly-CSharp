// Decompiled with JetBrains decompiler
// Type: CriStructMemory`1
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ECB926DA-6BA5-4E91-81B4-E3750A024FEA
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp-firstpass.dll

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
