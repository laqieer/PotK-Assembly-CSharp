// Decompiled with JetBrains decompiler
// Type: ColosseumRankPrefab
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class ColosseumRankPrefab : MonoBehaviour
{
  [SerializeField]
  private GameObject BoxObject;
  [SerializeField]
  private GameObject FinishObject;
  [SerializeField]
  private GameObject NextObject;
  [SerializeField]
  private UILabel textRankReward;
  [SerializeField]
  private UILabel textPoint;
  [SerializeField]
  private UILabel textRankName;
  [SerializeField]
  private UILabel textRewardName;
  [SerializeField]
  private UI2DSprite icon;
  [SerializeField]
  private UIButton rankDetailButton;
  private int nextPoint;
  private int fromPoint;
  private ColosseumRank rankInfo;
  private Action<ColosseumRank, int, int> rankDetailAction;
  private Color gray = new Color(0.5f, 0.5f, 0.5f);

  private void CreateUnknownItem(GameObject gearPrefab, Transform parent)
  {
    ItemIcon component = gearPrefab.Clone(parent).GetComponent<ItemIcon>();
    component.SetEmpty(true);
    component.gear.unknown.SetActive(true);
    component.BottomModeValue = ItemIcon.BottomMode.Nothing;
  }

  public void Reset(GameObject unknownObject)
  {
    this.BoxObject.SetActive(false);
    this.NextObject.SetActive(true);
    this.FinishObject.SetActive(false);
    this.textRankReward.SetTextLocalize(Consts.GetInstance().COLOSSEUM_RANK_PREFAB_RESET_01);
    this.textRankReward.color = this.gray;
    this.textRewardName.text = string.Empty;
    this.textRewardName.color = this.gray;
    this.textPoint.SetTextLocalize(Consts.GetInstance().COLOSSEUM_RANK_PREFAB_RESET_02);
    this.textRankName.SetTextLocalize(Consts.GetInstance().COLOSSEUM_RANK_PREFAB_RESET_03);
    this.textPoint.color = this.gray;
    this.textRankName.color = this.gray;
    ((Behaviour) this.icon).enabled = false;
    this.CreateUnknownItem(unknownObject, ((Component) this.icon).transform);
    this.rankDetailAction = (Action<ColosseumRank, int, int>) null;
    this.rankDetailButton.isEnabled = false;
  }

  [DebuggerHidden]
  public IEnumerator Set(
    ColosseumRank rankInfo,
    bool select,
    int fromPoint,
    int nextPoint,
    GameObject gearObject,
    GameObject unitObject,
    GameObject umiqueObject,
    Action<ColosseumRank, int, int> rankDetailAction)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new ColosseumRankPrefab.\u003CSet\u003Ec__IteratorA19()
    {
      nextPoint = nextPoint,
      fromPoint = fromPoint,
      rankInfo = rankInfo,
      rankDetailAction = rankDetailAction,
      select = select,
      gearObject = gearObject,
      unitObject = unitObject,
      umiqueObject = umiqueObject,
      \u003C\u0024\u003EnextPoint = nextPoint,
      \u003C\u0024\u003EfromPoint = fromPoint,
      \u003C\u0024\u003ErankInfo = rankInfo,
      \u003C\u0024\u003ErankDetailAction = rankDetailAction,
      \u003C\u0024\u003Eselect = select,
      \u003C\u0024\u003EgearObject = gearObject,
      \u003C\u0024\u003EunitObject = unitObject,
      \u003C\u0024\u003EumiqueObject = umiqueObject,
      \u003C\u003Ef__this = this
    };
  }

  public void IbtnRankDetail()
  {
    this.rankDetailAction(this.rankInfo, this.fromPoint, this.nextPoint);
  }
}
