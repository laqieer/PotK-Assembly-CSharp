// Decompiled with JetBrains decompiler
// Type: DebugInfoScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class DebugInfoScript : MonoBehaviour
{
  public int Stock = 10;
  public Dictionary<string, List<object>> debugInfo = new Dictionary<string, List<object>>();

  public static void Show(string name, object x)
  {
  }
}
