// Decompiled with JetBrains decompiler
// Type: MissionPointRewardDetailPopupController
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Scenes/DailyMission/Popup/MissionPointRewardDetailPopupController")]
public class MissionPointRewardDetailPopupController : MonoBehaviour
{
  private static string descriptionTemplate = "ミッション達成数合計[FFFF00]★{0}以上[-]で獲得可能";
  private DailyMissionController controller;
  [SerializeField]
  private UIButton receiveButton;
  [SerializeField]
  private UIButton notClearedButton;
  [SerializeField]
  private UIButton haveReceivedButton;
  [SerializeField]
  private UIScrollView scrollView;
  [SerializeField]
  private UIGrid grid;
  [SerializeField]
  private UILabel description;
  private List<PointReward> pointRewardList;
  private int rewardBoxID;
  private System.Action updateAction;

  public IEnumerator Init(
    DailyMissionController controller,
    PointRewardBox pointRewardBox,
    int currentAcquiredPoint,
    bool isReceived,
    System.Action updateAction)
  {
    this.controller = controller;
    this.rewardBoxID = pointRewardBox.ID;
    this.updateAction = updateAction;
    this.description.SetTextLocalize(string.Format(MissionPointRewardDetailPopupController.descriptionTemplate, (object) pointRewardBox.point));
    this.receiveButton.gameObject.SetActive(false);
    this.notClearedButton.gameObject.SetActive(false);
    this.notClearedButton.isEnabled = false;
    this.haveReceivedButton.gameObject.SetActive(false);
    this.haveReceivedButton.isEnabled = false;
    if (isReceived)
    {
      this.haveReceivedButton.gameObject.SetActive(true);
    }
    else
    {
      bool flag = currentAcquiredPoint >= pointRewardBox.point;
      this.notClearedButton.gameObject.SetActive(!flag);
      this.receiveButton.gameObject.SetActive(flag);
    }
    this.pointRewardList = new List<PointReward>();
    PointReward[] pointRewardItems = pointRewardBox.rewards;
    for (int i = 0; i < pointRewardItems.Length; ++i)
    {
      GameObject gameObject = controller.missionPointRewardDetailItemPrefab.Clone(this.grid.transform);
      gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, -this.grid.cellHeight * (float) i, gameObject.transform.localPosition.z);
      MissionPointRewardDetailItemController component = gameObject.GetComponent<MissionPointRewardDetailItemController>();
      PointReward pointRewardData = pointRewardItems[i];
      this.pointRewardList.Add(pointRewardData);
      IEnumerator e = component.Init(pointRewardData);
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
    }
    this.grid.Reposition();
    this.scrollView.ResetPosition();
  }

  public void OnClickCancelButton() => Singleton<PopupManager>.GetInstance().dismiss();

  public void OnClickReceiveButton()
  {
    Singleton<PopupManager>.GetInstance().closeAll();
    this.controller.StartCoroutine(this.ReceivePointReward());
  }

  public IEnumerator ReceivePointReward()
  {
    CommonRoot commonRoot = Singleton<CommonRoot>.GetInstance();
    commonRoot.ShowLoadingLayer(1);
    Future<WebAPI.Response.DailymissionPointRewardReceive> future = WebAPI.DailymissionPointRewardReceive(this.rewardBoxID, (System.Action<WebAPI.Response.UserError>) (e =>
    {
      WebAPI.DefaultUserErrorCallback(e);
      Singleton<PopupManager>.GetInstance().closeAll();
      commonRoot = Singleton<CommonRoot>.GetInstance();
      commonRoot.HideLoadingLayer();
      commonRoot.DailyMissionController.Hide();
    }));
    IEnumerator e1 = future.Wait();
    while (e1.MoveNext())
      yield return e1.Current;
    e1 = (IEnumerator) null;
    commonRoot.HideLoadingLayer();
    if (future.HasResult && future.Result != null)
    {
      e1 = Singleton<PopupManager>.GetInstance().open(this.controller.getPointRewardEffectPopupPrefab).GetComponent<MissionGetPointRewardEffectPopupController>().Init(this.pointRewardList, this.updateAction);
      while (e1.MoveNext())
        yield return e1.Current;
      e1 = (IEnumerator) null;
      Singleton<NGSoundManager>.GetInstance().playSE("SE_0534");
    }
  }
}
