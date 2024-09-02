// Decompiled with JetBrains decompiler
// Type: DebugInfoScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
