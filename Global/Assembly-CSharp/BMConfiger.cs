// Decompiled with JetBrains decompiler
// Type: BMConfiger
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

#nullable disable
public class BMConfiger
{
  public bool compress = true;
  public bool deterministicBundle;
  public string bundleSuffix = "assetBundle";
  public string buildOutputPath = string.Empty;
  public bool useCache = true;
  public bool useCRC;
  public int downloadThreadsCount = 1;
  public int downloadRetryTime = 2;
  public int bmVersion;
}
