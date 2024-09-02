// Decompiled with JetBrains decompiler
// Type: CriFsConfig
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ECB926DA-6BA5-4E91-81B4-E3750A024FEA
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp-firstpass.dll

using System;

#nullable disable
[Serializable]
public class CriFsConfig
{
  public const int defaultAndroidDeviceReadBitrate = 50000000;
  public int numberOfLoaders = 16;
  public int numberOfBinders = 8;
  public int numberOfInstallers = 2;
  public int installBufferSize = CriFsPlugin.defaultInstallBufferSize / 1024;
  public int maxPath = 256;
  public string userAgentString = string.Empty;
  public bool minimizeFileDescriptorUsage;
  public int androidDeviceReadBitrate = 50000000;
}
