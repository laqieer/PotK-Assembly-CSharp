// Decompiled with JetBrains decompiler
// Type: CriMana.MovieInfo
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E910E095-517B-41AE-AAF8-B85E770EBAF1
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp-firstpass.dll

using System.Runtime.InteropServices;

#nullable disable
namespace CriMana
{
  [StructLayout(LayoutKind.Sequential)]
  public class MovieInfo
  {
    private uint _reserved1;
    private uint _hasAlpha;
    public uint width;
    public uint height;
    public uint dispWidth;
    public uint dispHeight;
    public uint framerateN;
    public uint framerateD;
    public uint totalFrames;
    private uint _codecType;
    private uint _alphaCodecType;
    public uint numAudioStreams;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
    public AudioInfo[] audioPrm;
    public uint numSubtitleChannels;
    public uint maxSubtitleSize;

    public bool hasAlpha
    {
      get => this._hasAlpha == 1U;
      set => this._hasAlpha = !value ? 0U : 1U;
    }

    public CodecType codecType
    {
      get => (CodecType) this._codecType;
      set => this._codecType = (uint) value;
    }

    public CodecType alphaCodecType
    {
      get => (CodecType) this._alphaCodecType;
      set => this._codecType = (uint) value;
    }
  }
}
