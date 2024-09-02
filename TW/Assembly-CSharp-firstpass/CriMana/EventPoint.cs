// Decompiled with JetBrains decompiler
// Type: CriMana.EventPoint
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ECB926DA-6BA5-4E91-81B4-E3750A024FEA
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp-firstpass.dll

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
