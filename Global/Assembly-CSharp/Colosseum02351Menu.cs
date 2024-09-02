// Decompiled with JetBrains decompiler
// Type: Colosseum02351Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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
  protected UILabel TxtRankPtFrom;
  [SerializeField]
  protected UILabel TxtRankPtTo;
  [SerializeField]
  protected Colosseum02351RewardItem[] RewardItems;
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
    return (IEnumerator) new Colosseum02351Menu.\u003CInitialize\u003Ec__Iterator52F()
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

  private void IbtnZoom(int index)
  {
    ColosseumRankReward reward = this.RewardItems[index].reward;
    this.OpenPopup(reward.reward_type, reward.reward_id);
  }

  public void IbtnZoom1() => this.IbtnZoom(0);

  public void IbtnZoom2() => this.IbtnZoom(1);

  public void IbtnZoom3() => this.IbtnZoom(2);

  private void OpenPopup(MasterDataTable.CommonRewardType type, int id)
  {
    this.StartCoroutine(this.openPopup(type, id));
  }

  [DebuggerHidden]
  private IEnumerator openPopup(MasterDataTable.CommonRewardType type, int id)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Colosseum02351Menu.\u003CopenPopup\u003Ec__Iterator530()
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
