// Decompiled with JetBrains decompiler
// Type: DailyMission0272DetailPopup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class DailyMission0272DetailPopup : BackButtonMonoBehaiviour
{
  [SerializeField]
  private GameObject button1;
  [SerializeField]
  private GameObject button2;
  [SerializeField]
  private UILabel titleLabel;
  [SerializeField]
  private UILabel detailLabel;
  [SerializeField]
  private UILabel rewardNameLabel;
  [SerializeField]
  private UILabel progressLabel;
  [SerializeField]
  private GameObject dirThumbImage;
  private DailyMission0272Panel panelObject;
  private string changeSchene = string.Empty;

  [DebuggerHidden]
  public IEnumerator Init(
    string title,
    string detail,
    string progres,
    string sceneName,
    DailyMission0272Panel.RewardViewModel r,
    DailyMission0272Panel panel)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DailyMission0272DetailPopup.\u003CInit\u003Ec__Iterator5DD()
    {
      panel = panel,
      sceneName = sceneName,
      title = title,
      detail = detail,
      progres = progres,
      r = r,
      \u003C\u0024\u003Epanel = panel,
      \u003C\u0024\u003EsceneName = sceneName,
      \u003C\u0024\u003Etitle = title,
      \u003C\u0024\u003Edetail = detail,
      \u003C\u0024\u003Eprogres = progres,
      \u003C\u0024\u003Er = r,
      \u003C\u003Ef__this = this
    };
  }

  public void IbtnNo() => Singleton<PopupManager>.GetInstance().onDismiss();

  public override void onBackButton() => this.IbtnNo();

  public void onTry()
  {
    if (this.changeSchene == "review")
    {
      this.StartCoroutine(this.callReviewApi());
    }
    else
    {
      if (this.changeSchene == "quest002_4")
        Quest00240723Scene.ChangeScene0024(true, 1);
      else if (this.changeSchene == "gacha006_3")
        Singleton<NGSceneManager>.GetInstance().changeScene(this.changeSchene, true, (object) 2);
      else
        Singleton<NGSceneManager>.GetInstance().changeScene(this.changeSchene, true);
      Singleton<PopupManager>.GetInstance().onDismiss();
    }
  }

  [DebuggerHidden]
  private IEnumerator callReviewApi()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DailyMission0272DetailPopup.\u003CcallReviewApi\u003Ec__Iterator5DE()
    {
      \u003C\u003Ef__this = this
    };
  }
}
