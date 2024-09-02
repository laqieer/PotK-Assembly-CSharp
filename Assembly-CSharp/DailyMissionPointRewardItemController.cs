// Decompiled with JetBrains decompiler
// Type: DailyMissionPointRewardItemController
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using MasterDataTable;
using System.Collections;
using UnityEngine;

public class DailyMissionPointRewardItemController : MonoBehaviour
{
  private DailyMissionController controller;
  [SerializeField]
  private GameObject acquiredEffect;
  [SerializeField]
  private UILabel rewardPointText;
  [SerializeField]
  private UI2DSprite rewardIconSprite;
  private PointRewardBox pointRewardBox;
  private int currentDailyPoint;
  private bool isReceived;
  private System.Action updateDailyPointRewardItemsAction;

  public void Init(
    DailyMissionController controller,
    PointRewardBox pointRewardBox,
    int currentDailyPoint,
    bool isReceived,
    System.Action updateDailyPointRewardItemsAction)
  {
    this.controller = controller;
    this.pointRewardBox = pointRewardBox;
    this.currentDailyPoint = currentDailyPoint;
    this.isReceived = isReceived;
    this.updateDailyPointRewardItemsAction = updateDailyPointRewardItemsAction;
    this.rewardPointText.SetTextLocalize(pointRewardBox.point);
    if (!isReceived)
    {
      this.acquiredEffect.SetActive(currentDailyPoint >= pointRewardBox.point);
      this.rewardIconSprite.color = Color.white;
    }
    else
    {
      this.acquiredEffect.SetActive(false);
      this.rewardIconSprite.color = Color.grey;
    }
  }

  public void OnClickDailyMissionPointReward() => this.controller.StartCoroutine(this.OpenMissionPointRewardDetailPopup());

  private IEnumerator OpenMissionPointRewardDetailPopup()
  {
    IEnumerator e = Singleton<PopupManager>.GetInstance().open(this.controller.missionPointRewardDetailPopupPrefab).GetComponent<MissionPointRewardDetailPopupController>().Init(this.controller, this.pointRewardBox, this.currentDailyPoint, this.isReceived, this.updateDailyPointRewardItemsAction);
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
  }
}
