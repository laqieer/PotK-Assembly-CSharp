// Decompiled with JetBrains decompiler
// Type: NGxTools
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public static class NGxTools
{
  public static void normalizeAdjustDepth(GameObject g, int depth)
  {
    switch (NGUITools.AdjustDepth(g, depth))
    {
      case 1:
        NGUITools.NormalizePanelDepths();
        break;
      case 2:
        NGUITools.NormalizeWidgetDepths();
        break;
    }
  }
}
