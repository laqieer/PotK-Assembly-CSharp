// Decompiled with JetBrains decompiler
// Type: BundleData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System.Collections.Generic;

#nullable disable
public class BundleData
{
  public string name = string.Empty;
  public List<string> includs = new List<string>();
  public List<string> dependAssets = new List<string>();
  public List<string> includeGUIDs = new List<string>();
  public List<string> dependGUIDs = new List<string>();
  public bool sceneBundle;
  public int priority;
  public string parent = string.Empty;
  public List<string> children = new List<string>();
}
