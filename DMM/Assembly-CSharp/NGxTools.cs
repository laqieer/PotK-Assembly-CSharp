﻿// Decompiled with JetBrains decompiler
// Type: NGxTools
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

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
