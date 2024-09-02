// Decompiled with JetBrains decompiler
// Type: WeeklyMissionPointRewardPopupController
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using MasterDataTable;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WeeklyMissionPointRewardPopupController : MonoBehaviour
{
  private DailyMissionController controller;
  [SerializeField]
  private UILabel pointAcquiredThisWeekText;
  [SerializeField]
  private List<WeeklyMissionPointRewardItemController> weeklyMissionPointRewardItems;
  [SerializeField]
  private UIGrid grid;
  private System.Action onCloseAction;

  public IEnumerator Init(
    DailyMissionController controller,
    int currentWeeklyPoint,
    List<PointRewardBox> weeklyPointRewardBoxList,
    System.Action onCloseAction,
    System.Action onReceiveAction)
  {
    this.controller = controller;
    this.onCloseAction = onCloseAction;
    ServerTime.NowAppTimeAddDelta();
    this.pointAcquiredThisWeekText.SetTextLocalize(currentWeeklyPoint);
    for (int i = 0; i < this.weeklyMissionPointRewardItems.Count; i++)
    {
      PointRewardBox pointRewardBox = weeklyPointRewardBoxList.FirstOrDefault<PointRewardBox>((Func<PointRewardBox, bool>) (x => x.box_type == i + 1));
      if (pointRewardBox != null)
      {
        this.weeklyMissionPointRewardItems[i].gameObject.SetActive(true);
        this.weeklyMissionPointRewardItems[i].Init(controller, pointRewardBox, currentWeeklyPoint, ((IEnumerable<int?>) SMManager.Get<PlayerDailyMissionPoint>().weekly.received_rewards).Contains<int?>(new int?(pointRewardBox.ID)), onReceiveAction);
      }
      else
        this.weeklyMissionPointRewardItems[i].gameObject.SetActive(false);
    }
    this.grid.Reposition();
    yield return (object) null;
  }

  public void OnClickCloseButton()
  {
    this.onCloseAction();
    Singleton<PopupManager>.GetInstance().dismiss();
  }
}
