﻿// Decompiled with JetBrains decompiler
// Type: DailyMission02712BreakAnimation
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class DailyMission02712BreakAnimation : MonoBehaviour
{
  public void onBreakPanel() => DailyMission02712PanelRoot.isBreakPanel = true;

  public void onEnd() => DailyMission02712PanelRoot.isAnimationEnd = true;
}
