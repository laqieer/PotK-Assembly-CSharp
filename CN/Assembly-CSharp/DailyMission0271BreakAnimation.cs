// Decompiled with JetBrains decompiler
// Type: DailyMission0271BreakAnimation
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class DailyMission0271BreakAnimation : MonoBehaviour
{
  public void onBreakPanel() => DailyMission0271PanelRoot.isBreakPanel = true;

  public void onEnd() => DailyMission0271PanelRoot.isAnimationEnd = true;
}
