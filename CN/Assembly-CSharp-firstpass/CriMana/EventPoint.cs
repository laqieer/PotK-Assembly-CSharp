// Decompiled with JetBrains decompiler
// Type: CriMana.EventPoint
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FC6F22C0-326E-48ED-B5EE-59590337E752
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp-firstpass.dll

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
