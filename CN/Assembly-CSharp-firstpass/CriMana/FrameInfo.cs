// Decompiled with JetBrains decompiler
// Type: CriMana.FrameInfo
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FC6F22C0-326E-48ED-B5EE-59590337E752
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp-firstpass.dll

using System.Runtime.InteropServices;

#nullable disable
namespace CriMana
{
  [StructLayout(LayoutKind.Sequential)]
  public class FrameInfo
  {
    public int frameNo;
    public int frameNoPerFile;
    public uint width;
    public uint height;
    public uint dispWidth;
    public uint dispHeight;
    public uint framerateN;
    public uint framerateD;
    public ulong time;
    public ulong tunit;
    public uint cntConcatenatedMovie;
    private AlphaType alphaType;
    public uint cntSkippedFrames;
  }
}
