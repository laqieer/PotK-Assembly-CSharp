// Decompiled with JetBrains decompiler
// Type: Colosseum02351Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using MasterDataTable;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Colosseum02351Menu : BackButtonMenuBase
{
  [SerializeField]
  protected UILabel TxtRank;
  [SerializeField]
  protected UILabel TxtRankPt;
  [SerializeField]
  protected UILabel TxtRankPtFrom;
  [SerializeField]
  protected UILabel TxtRankPtTo;
  [SerializeField]
  protected UILabel TxtReward;
  [SerializeField]
  protected UILabel TxtReward2;
  [SerializeField]
  protected UILabel TxtRewardNum;
  [SerializeField]
  protected UILabel TxtRewardNum2;
  [SerializeField]
  protected GameObject RewardItem;
  [SerializeField]
  protected GameObject[] RewardPrize;
  [SerializeField]
  protected UIButton ZoomBtn;
  private GameObject popupObject;
  private MasterDataTable.CommonRewardType type;
  private int rewardID;
  private Colosseum0235Scene.Param param;
  private bool canChangeScene;
  [SerializeField]
  private UI2DSprite Emblem;

  public override void onBackButton() => this.IbtnBack();

  [DebuggerHidden]
  public IEnumerator Initialize(
    Colosseum0235Scene.Param param,
    ColosseumRank rank,
    int fromPoint,
    int nextPoint)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Colosseum02351Menu.\u003CInitialize\u003Ec__Iterator5D8()
    {
      param = param,
      rank = rank,
      fromPoint = fromPoint,
      nextPoint = nextPoint,
      \u003C\u0024\u003Eparam = param,
      \u003C\u0024\u003Erank = rank,
      \u003C\u0024\u003EfromPoint = fromPoint,
      \u003C\u0024\u003EnextPoint = nextPoint,
      \u003C\u003Ef__this = this
    };
  }

  public virtual void IbtnBack()
  {
    if (this.IsPushAndSet())
      return;
    bool flag = Object.op_Inequality((Object) Singleton<PopupManager>.GetInstanceOrNull(), (Object) null) && Singleton<PopupManager>.GetInstance().isOpen;
    if (!this.canChangeScene || flag)
      return;
    this.canChangeScene = false;
    Singleton<NGSceneManager>.GetInstance().destroyCurrentScene();
    Colosseum0235Scene.ChangeScene(this.param);
  }

  public virtual void IbtnZoom()
  {
    if (this.IsPushAndSet())
      return;
    this.StartCoroutine(this.openPopup(this.type, this.rewardID));
  }

  [DebuggerHidden]
  private IEnumerator openPopup(MasterDataTable.CommonRewardType type, int id)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Colosseum02351Menu.\u003CopenPopup\u003Ec__Iterator5D9()
    {
      type = type,
      id = id,
      \u003C\u0024\u003Etype = type,
      \u003C\u0024\u003Eid = id,
      \u003C\u003Ef__this = this
    };
  }

  private enum IconIndex
  {
    EQUIP,
    UNIT,
    UNIQUE,
  }
}
