// Decompiled with JetBrains decompiler
// Type: Popup023418Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using System.Collections;
using UnityEngine;

public class Popup023418Menu : BackButtonMenuBase
{
  protected System.Action onCallback;
  [SerializeField]
  private UILabel TxtDescription1;
  [SerializeField]
  private UILabel TxtDescription2;
  [SerializeField]
  private GameObject link_Icon;

  protected string GetRewardTypeText(MasterDataTable.CommonRewardType type, int id)
  {
    string str = "";
    switch (type)
    {
      case MasterDataTable.CommonRewardType.battle_medal:
        str = Consts.GetInstance().UNIQUE_ICON_BATTLE_MEDAL;
        break;
      case MasterDataTable.CommonRewardType.common_ticket:
        str = CommonRewardType.GetRewardName(type, id);
        break;
    }
    return str;
  }

  protected string GetRewardTypeUnitText(MasterDataTable.CommonRewardType type)
  {
    string str = "";
    switch (type)
    {
      case MasterDataTable.CommonRewardType.battle_medal:
        str = Consts.GetInstance().UNIQUE_ICON_MEDAL_COUNT;
        break;
      case MasterDataTable.CommonRewardType.common_ticket:
        str = Consts.GetInstance().UNIQUE_ICON_COMMON_TICKET_COUNT;
        break;
    }
    return str;
  }

  public IEnumerator Init(ResultMenuBase.BonusReward reward, int totalWin)
  {
    Future<GameObject> uniquePrefabF = Res.Icons.UniqueIconPrefab.Load<GameObject>();
    IEnumerator e = uniquePrefabF.Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    e = ColosseumUtility.CreateUniqueIcon(uniquePrefabF.Result, this.link_Icon.transform, (MasterDataTable.CommonRewardType) reward.reward_type_id, reward.reward_id, 0, false);
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    string rewardTypeText = this.GetRewardTypeText((MasterDataTable.CommonRewardType) reward.reward_type_id, reward.reward_id);
    string localizeNumberText = reward.reward_quantity.ToLocalizeNumberText();
    string rewardTypeUnitText = this.GetRewardTypeUnitText((MasterDataTable.CommonRewardType) reward.reward_type_id);
    this.TxtDescription2.SetTextLocalize(Consts.Format(Consts.GetInstance().COLOSSEUM_0023418_TEXT2, (IDictionary) new Hashtable()
    {
      {
        (object) "name",
        (object) rewardTypeText
      },
      {
        (object) "value",
        (object) localizeNumberText
      },
      {
        (object) "unit",
        (object) rewardTypeUnitText
      }
    }));
    this.TxtDescription1.SetTextLocalize(Consts.Format(Consts.GetInstance().COLOSSEUM_0023418_TEXT1, (IDictionary) new Hashtable()
    {
      {
        (object) "cnt",
        (object) totalWin
      }
    }));
  }

  public void SetCallback(System.Action callback) => this.onCallback = callback;

  public virtual void IbtnOK()
  {
    if (this.IsPushAndSet())
      return;
    if (this.onCallback != null)
      this.onCallback();
    Singleton<PopupManager>.GetInstance().onDismiss();
  }

  public override void onBackButton() => this.IbtnOK();
}
