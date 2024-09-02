// Decompiled with JetBrains decompiler
// Type: BMUrls
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using LitJson;
using System.Collections.Generic;

#nullable disable
public class BMUrls
{
  public Dictionary<string, string> downloadUrls;
  public Dictionary<string, string> outputs;
  public BuildPlatform bundleTarget = BuildPlatform.Standalones;
  public bool useEditorTarget;
  public bool downloadFromOutput;
  public bool offlineCache;

  public BMUrls()
  {
    this.downloadUrls = new Dictionary<string, string>()
    {
      {
        "WebPlayer",
        string.Empty
      },
      {
        "Standalones",
        string.Empty
      },
      {
        "IOS",
        string.Empty
      },
      {
        "Android",
        string.Empty
      },
      {
        "WP8",
        string.Empty
      }
    };
    this.outputs = new Dictionary<string, string>()
    {
      {
        "WebPlayer",
        string.Empty
      },
      {
        "Standalones",
        string.Empty
      },
      {
        "IOS",
        string.Empty
      },
      {
        "Android",
        string.Empty
      },
      {
        "WP8",
        string.Empty
      }
    };
  }

  public string GetInterpretedDownloadUrl(BuildPlatform platform)
  {
    return BMUtility.InterpretPath(this.downloadUrls[platform.ToString()], platform);
  }

  public string GetInterpretedOutputPath(BuildPlatform platform)
  {
    return BMUtility.InterpretPath(this.outputs[platform.ToString()], platform);
  }

  public static string SerializeToString(BMUrls urls) => JsonMapper.ToJson((object) urls);
}
