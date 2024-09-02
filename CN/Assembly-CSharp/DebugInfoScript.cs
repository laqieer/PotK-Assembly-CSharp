// Decompiled with JetBrains decompiler
// Type: DebugInfoScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
