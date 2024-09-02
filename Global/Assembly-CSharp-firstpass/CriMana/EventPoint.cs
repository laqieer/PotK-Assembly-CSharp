// Decompiled with JetBrains decompiler
// Type: CriMana.EventPoint
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E910E095-517B-41AE-AAF8-B85E770EBAF1
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp-firstpass.dll

using System;

#nullable disable
namespace CriMana
{
  public struct EventPoint
  {
    public IntPtr cueName;
    public uint cueNameSize;
    public ulong time;
    public ulong tunit;
    public int type;
    public IntPtr paramString;
    public uint paramStringSize;
    public uint cntCallback;
  }
}
