// Decompiled with JetBrains decompiler
// Type: DailyMission0272DetailPopup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using SM;
using System.Collections;
using System.Diagnostics;
using System.Text.RegularExpressions;
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
  private readonly string patternOpenUrl = "http(s)?://([\\w-]+\\.)+[\\w-]+(/[\\w- ./?%&=]*)?";
  private int missionId_;
  private DailyMission0272Panel panelObject;
  private string changeScene_ = string.Empty;

  [DebuggerHidden]
  public IEnumerator Init(
    int missionId,
    string title,
    string detail,
    string progres,
    string sceneName,
    DailyMission0272Panel.RewardViewModel r,
    DailyMission0272Panel panel)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DailyMission0272DetailPopup.\u003CInit\u003Ec__Iterator6D0()
    {
      missionId = missionId,
      panel = panel,
      sceneName = sceneName,
      title = title,
      detail = detail,
      progres = progres,
      r = r,
      \u003C\u0024\u003EmissionId = missionId,
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
    bool flag = true;
    if (Regex.Match(this.changeScene_, this.patternOpenUrl).Success)
      this.StartCoroutine("callOpenUrlApi");
    else if (this.changeScene_ == "review")
    {
      this.StartCoroutine(this.callReviewApi());
    }
    else
    {
      if (this.changeScene_ == "quest002_4")
        Quest00240723Scene.ChangeScene0024(true, 1);
      else if (this.changeScene_ == "gacha006_3")
        Singleton<NGSceneManager>.GetInstance().changeScene(this.changeScene_, true, (object) 2);
      else if (this.changeScene_.StartsWith("colosseum023"))
      {
        if (!SMManager.Get<Player>().GetFeatureColosseum() || !SMManager.Get<Player>().GetReleaseColosseum())
        {
          Singleton<PopupManager>.GetInstance().onDismiss();
          this.StartCoroutine(PopupCommon.Show(Consts.GetInstance().DAILY_MISSION_0271_POPUP_TITLE, Consts.GetInstance().DAILY_MISSION_0271_COLOSSEUM));
          flag = false;
        }
        else
          Singleton<NGSceneManager>.GetInstance().changeScene(this.changeScene_, true);
      }
      else
        Singleton<NGSceneManager>.GetInstance().changeScene(this.changeScene_, true);
      if (!flag)
        return;
      Singleton<PopupManager>.GetInstance().onDismiss();
    }
  }

  [DebuggerHidden]
  private IEnumerator callReviewApi()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DailyMission0272DetailPopup.\u003CcallReviewApi\u003Ec__Iterator6D1()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator callOpenUrlApi()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DailyMission0272DetailPopup.\u003CcallOpenUrlApi\u003Ec__Iterator6D2()
    {
      \u003C\u003Ef__this = this
    };
  }
}
