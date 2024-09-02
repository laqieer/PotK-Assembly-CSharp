// Decompiled with JetBrains decompiler
// Type: DailyMission0272Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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

  public override void onBackButton() => this.IbtnBack();

  [DebuggerHidden]
  public IEnumerator Init()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DailyMission0272Menu.\u003CInit\u003Ec__Iterator680()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void IbtnBack()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<NGSceneManager>.GetInstance().destroyCurrentScene();
    MypageScene.ChangeScene(false);
  }

  [DebuggerHidden]
  private IEnumerator createPanel(GameObject prefab, PlayerDailyMissionAchievement pdm)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DailyMission0272Menu.\u003CcreatePanel\u003Ec__Iterator681()
    {
      prefab = prefab,
      pdm = pdm,
      \u003C\u0024\u003Eprefab = prefab,
      \u003C\u0024\u003Epdm = pdm,
      \u003C\u003Ef__this = this
    };
  }
}
