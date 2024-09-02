// Decompiled with JetBrains decompiler
// Type: SelectBlock
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class SelectBlock
{
  public List<SelectBlock.Data> data = new List<SelectBlock.Data>();
  public int selected = -1;
  public GameObject obj;

  public class Data
  {
    public string msg = string.Empty;
    public string label = string.Empty;
  }
}
