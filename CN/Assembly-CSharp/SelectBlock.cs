// Decompiled with JetBrains decompiler
// Type: SelectBlock
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
