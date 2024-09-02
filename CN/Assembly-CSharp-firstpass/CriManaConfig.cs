// Decompiled with JetBrains decompiler
// Type: CriManaConfig
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FC6F22C0-326E-48ED-B5EE-59590337E752
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp-firstpass.dll

using System;

#nullable disable
[Serializable]
public class CriManaConfig
{
  public int numberOfDecoders = 8;
  public int numberOfMaxEntries = 4;
  public readonly bool graphicsMultiThreaded = true;
  public CriManaConfig.VitaH264PlaybackConfig vitaH264PlaybackConfig = new CriManaConfig.VitaH264PlaybackConfig();

  [Serializable]
  public class VitaH264PlaybackConfig
  {
    public bool useH264Playback;
    public int maxWidth = 960;
    public int maxHeight = 544;
  }
}
