// Decompiled with JetBrains decompiler
// Type: CriManaConfig
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E910E095-517B-41AE-AAF8-B85E770EBAF1
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp-firstpass.dll

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
