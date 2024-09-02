// Decompiled with JetBrains decompiler
// Type: DailyMission0272Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class DailyMission0272Menu : BackButtonMenuBase
{
  [SerializeField]
  private UILabel titleLabel;
  [SerializeField]
  private UILabel messageLabel;
  [SerializeField]
  private UILabel attentionLabel;
  [SerializeField]
  public UIGrid grid;
  [SerializeField]
  public UIScrollView scrollview;
  private GameObject panelPrefab;

  public override void onBackButton() => this.IbtnBack();

  [DebuggerHidden]
  public IEnumerator Init()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DailyMission0272Menu.\u003CInit\u003Ec__Iterator5DF()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void ReloadMissions(PlayerDailyMissionAchievement[] player_missions)
  {
    this.StartCoroutine(this.MakePanels(player_missions));
  }

  [DebuggerHidden]
  public IEnumerator MakePanels(PlayerDailyMissionAchievement[] player_missions)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DailyMission0272Menu.\u003CMakePanels\u003Ec__Iterator5E0()
    {
      player_missions = player_missions,
      \u003C\u0024\u003Eplayer_missions = player_missions,
      \u003C\u003Ef__this = this
    };
  }

  public void IbtnBack()
  {
    if (this.IsPushAndSet())
      return;
    this.backScene();
  }

  [DebuggerHidden]
  private IEnumerator createPanel(GameObject prefab, PlayerDailyMissionAchievement pdm)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DailyMission0272Menu.\u003CcreatePanel\u003Ec__Iterator5E1()
    {
      prefab = prefab,
      pdm = pdm,
      \u003C\u0024\u003Eprefab = prefab,
      \u003C\u0024\u003Epdm = pdm,
      \u003C\u003Ef__this = this
    };
  }
}
