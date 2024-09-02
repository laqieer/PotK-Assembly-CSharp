// Decompiled with JetBrains decompiler
// Type: WeeklyMissionPointRewardItemController
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using MasterDataTable;
using System.Collections;
using UnityEngine;

public class WeeklyMissionPointRewardItemController : MonoBehaviour
{
  private DailyMissionController controller;
  [SerializeField]
  private UILabel rewardPointText;
  [SerializeField]
  private GameObject badge;
  [SerializeField]
  private UIButton rewardItemButton;
  [SerializeField]
  private UI2DSprite rewardIconSprite;
  [SerializeField]
  private UI2DSprite rewardIconBaseSprite;
  private PointRewardBox pointRewardBox;
  private int currentWeeklyPoint;
  private bool isReceived;
  private System.Action updateWeeklyPointRewardItemsAction;

  public void Init(
    DailyMissionController controller,
    PointRewardBox pointRewardBox,
    int currentWeeklyPoint,
    bool isReceived,
    System.Action updateWeeklyPointRewardItemsAction)
  {
    this.controller = controller;
    this.pointRewardBox = pointRewardBox;
    this.currentWeeklyPoint = currentWeeklyPoint;
    this.isReceived = isReceived;
    this.updateWeeklyPointRewardItemsAction = updateWeeklyPointRewardItemsAction;
    this.rewardPointText.SetTextLocalize(pointRewardBox.point);
    if (!isReceived)
    {
      this.badge.SetActive(currentWeeklyPoint >= pointRewardBox.point);
      this.rewardIconSprite.color = Color.white;
      this.rewardIconBaseSprite.color = Color.white;
    }
    else
    {
      this.badge.SetActive(false);
      this.rewardIconSprite.color = Color.grey;
      this.rewardIconBaseSprite.color = Color.grey;
    }
    this.rewardItemButton.isEnabled = true;
  }

  public void OnClickWeeklyMissionPointReward() => this.controller.StartCoroutine(this.OpenMissionPointRewardDetailPopup());

  private IEnumerator OpenMissionPointRewardDetailPopup()
  {
    IEnumerator e = Singleton<PopupManager>.GetInstance().open(this.controller.missionPointRewardDetailPopupPrefab).GetComponent<MissionPointRewardDetailPopupController>().Init(this.controller, this.pointRewardBox, this.currentWeeklyPoint, this.isReceived, this.updateWeeklyPointRewardItemsAction);
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
  }
}
