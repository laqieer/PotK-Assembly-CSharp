﻿// Decompiled with JetBrains decompiler
// Type: DailyMission0271BreakAnimation
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class DailyMission0271BreakAnimation : MonoBehaviour
{
  public void onBreakPanel() => DailyMission0271PanelRoot.isBreakPanel = true;

  public void onEnd() => DailyMission0271PanelRoot.isAnimationEnd = true;
}
