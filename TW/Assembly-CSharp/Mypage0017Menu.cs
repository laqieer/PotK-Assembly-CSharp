// Decompiled with JetBrains decompiler
// Type: Mypage0017Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class Mypage0017Menu : BackButtonMenuBase
{
  private const int iconWidth = 604;
  private const int iconHeight = 135;
  private const int iconColumnValue = 1;
  private const int iconRowValue = 12;
  private const int iconScreenValue = 8;
  private const int iconMaxValue = 12;
  private const int MAX_RECEIVE = 60;
  public UIButton IBtnGetAll;
  public UIButton IBtnDeleteAll;
  [SerializeField]
  protected UILabel TxtDate18;
  [SerializeField]
  protected UILabel TxtExplanation22;
  [SerializeField]
  protected UILabel TxtPresetname24;
  [SerializeField]
  protected UILabel TxtTime18;
  [SerializeField]
  protected UILabel TxtTitle30;
  public NGxScroll2 scroll;
  private PlayerPresent[] Presents;
  private List<Mypage0017Scroll> allScroll = new List<Mypage0017Scroll>();
  private List<PresentInfo> allPresentInfos = new List<PresentInfo>();
  private bool isInitialize;
  private float scrool_start_y;

  public virtual void Foreground() => Debug.Log((object) "click default event Foreground");

  public virtual void IbtnReceive() => Debug.Log((object) "click default event IbtnReceive");

  public virtual void VScrollBar() => Debug.Log((object) "click default event VScrollBar");

  public static Tuple<List<PlayerPresent>, bool> createReceiveList(PlayerPresent[] presents)
  {
    List<PlayerPresent> playerPresentList = new List<PlayerPresent>();
    Player player = SMManager.Get<Player>();
    PlayerUnit[] playerUnitArray = SMManager.Get<PlayerUnit[]>();
    int num1 = ((IEnumerable<PlayerItem>) ((IEnumerable<PlayerItem>) SMManager.Get<PlayerItem[]>()).Where<PlayerItem>((Func<PlayerItem, bool>) (x => x.entity_type == MasterDataTable.CommonRewardType.gear)).ToArray<PlayerItem>()).Count<PlayerItem>();
    int num2 = 0;
    int num3 = 0;
    int num4 = 0;
    int num5 = 0;
    int num6 = 0;
    int[] numArray = new int[MasterData.SupplySupply.Count<KeyValuePair<int, SupplySupply>>() + 1];
    Dictionary<int, int> dictionary1 = new Dictionary<int, int>();
    PlayerItem[] source1 = SMManager.Get<PlayerItem[]>().AllSupplies();
    int num7 = 0;
    int idx = 1;
    while (num7 < MasterData.SupplySupply.Count<KeyValuePair<int, SupplySupply>>())
    {
      int cnt = 0;
      ((IEnumerable<PlayerItem>) source1).Where<PlayerItem>((Func<PlayerItem, bool>) (x => x.supply.ID == MasterData.SupplySupply[idx].ID)).ForEach<PlayerItem>((Action<PlayerItem>) (x => cnt += x.quantity));
      numArray[MasterData.SupplySupply[idx].ID] = cnt;
      ++num7;
      ++idx;
    }
    PlayerQuestKey[] source2 = SMManager.Get<PlayerQuestKey[]>();
    foreach (PlayerQuestKey playerQuestKey in source2)
      dictionary1.Add(playerQuestKey.quest_key_id, playerQuestKey.quantity);
    bool flag = false;
    Dictionary<int, bool> dictionary2 = new Dictionary<int, bool>();
    for (int index = presents.Length - 1; index >= 0; --index)
    {
      PlayerPresent present = presents[index];
      if (present.received_at.HasValue)
      {
        present.isReceivable = new bool?(false);
      }
      else
      {
        int num8 = present.reward_type_id.Value;
        switch (num8)
        {
          case 14:
            if (player.medal + (num6 + present.reward_quantity.Value) <= Consts.GetInstance().MEDAL_MAX)
            {
              num6 += present.reward_quantity.Value;
              present.isReceivable = new bool?(true);
              dictionary2[present.reward_type_id.Value] = true;
              continue;
            }
            present.isReceivable = new bool?(false);
            dictionary2[present.reward_type_id.Value] = false;
            continue;
          case 15:
            if (player.friend_point + (num5 + present.reward_quantity.Value) <= Consts.GetInstance().FRIEND_POINT_MAX)
            {
              num5 += present.reward_quantity.Value;
              present.isReceivable = new bool?(true);
              dictionary2[present.reward_type_id.Value] = true;
              continue;
            }
            present.isReceivable = new bool?(false);
            dictionary2[present.reward_type_id.Value] = false;
            continue;
          case 19:
            PlayerQuestKey playerQuestKey = ((IEnumerable<PlayerQuestKey>) source2).Where<PlayerQuestKey>((Func<PlayerQuestKey, bool>) (x =>
            {
              int questKeyId = x.quest_key_id;
              int? rewardId = present.reward_id;
              int valueOrDefault = rewardId.GetValueOrDefault();
              return questKeyId == valueOrDefault && rewardId.HasValue;
            })).FirstOrDefault<PlayerQuestKey>();
            int num9;
            if (playerQuestKey != null)
            {
              int? rewardQuantity = present.reward_quantity;
              int? nullable = !rewardQuantity.HasValue ? new int?() : new int?(rewardQuantity.Value + dictionary1[playerQuestKey.quest_key_id]);
              num9 = !nullable.HasValue ? 0 : (nullable.Value <= playerQuestKey.max_quantity ? 1 : 0);
            }
            else
              num9 = 1;
            if (num9 != 0)
            {
              Dictionary<int, int> dictionary3;
              Dictionary<int, int> dictionary4 = dictionary3 = dictionary1;
              int? rewardId = present.reward_id;
              int key1;
              int key2 = key1 = rewardId.Value;
              int num10 = dictionary4[key2] + present.reward_quantity.Value;
              dictionary3[key1] = num10;
              present.isReceivable = new bool?(true);
              dictionary2[present.reward_type_id.Value] = true;
              continue;
            }
            present.isReceivable = new bool?(false);
            dictionary2[present.reward_type_id.Value] = false;
            continue;
          default:
            switch (num8 - 1)
            {
              case 0:
                UnitUnit unitUnit;
                if (present.reward_id.HasValue && MasterData.UnitUnit.TryGetValue(present.reward_id.Value, out unitUnit))
                {
                  if (unitUnit.IsNormalUnit)
                  {
                    if (playerUnitArray.Length + num2 < player.max_units)
                    {
                      present.isReceivable = new bool?(true);
                      dictionary2[present.reward_type_id.Value] = true;
                      ++num2;
                      continue;
                    }
                    present.isReceivable = new bool?(false);
                    dictionary2[present.reward_type_id.Value] = false;
                    continue;
                  }
                  present.isReceivable = new bool?(true);
                  dictionary2[present.reward_type_id.Value] = true;
                  continue;
                }
                present.isReceivable = new bool?(false);
                dictionary2[present.reward_type_id.Value] = false;
                continue;
              case 2:
                GearGear gearGear;
                if (present.reward_id.HasValue && MasterData.GearGear.TryGetValue(present.reward_id.Value, out gearGear))
                {
                  if (gearGear.isMaterial())
                  {
                    present.isReceivable = new bool?(true);
                    dictionary2[present.reward_type_id.Value] = true;
                    continue;
                  }
                  if (num1 + num3 < player.max_items)
                  {
                    ++num3;
                    present.isReceivable = new bool?(true);
                    dictionary2[present.reward_type_id.Value] = true;
                    continue;
                  }
                  present.isReceivable = new bool?(false);
                  dictionary2[present.reward_type_id.Value] = false;
                  continue;
                }
                continue;
              case 3:
                if (player.money + (num4 + present.reward_quantity.Value) <= Consts.GetInstance().MONEY_MAX)
                {
                  num4 += present.reward_quantity.Value;
                  present.isReceivable = new bool?(true);
                  dictionary2[present.reward_type_id.Value] = true;
                  continue;
                }
                present.isReceivable = new bool?(false);
                dictionary2[present.reward_type_id.Value] = false;
                continue;
              default:
                if (num8 != 24)
                {
                  present.isReceivable = new bool?(true);
                  dictionary2[present.reward_type_id.Value] = true;
                  continue;
                }
                goto case 0;
            }
        }
      }
    }
    foreach (PlayerPresent present in presents)
    {
      if (!present.received_at.HasValue && playerPresentList.Count < 60)
      {
        bool? isReceivable = present.isReceivable;
        if ((isReceivable.GetValueOrDefault() ? 1 : (!isReceivable.HasValue ? 1 : 0)) != 0)
          playerPresentList.Add(present);
        else
          flag = true;
      }
    }
    return new Tuple<List<PlayerPresent>, bool>(playerPresentList, flag);
  }

  [DebuggerHidden]
  public IEnumerator Init(PlayerPresent[] presents)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Mypage0017Menu.\u003CInit\u003Ec__Iterator1C1()
    {
      presents = presents,
      \u003C\u0024\u003Epresents = presents,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator UpdateList(PlayerPresent[] presents)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Mypage0017Menu.\u003CUpdateList\u003Ec__Iterator1C2()
    {
      presents = presents,
      \u003C\u0024\u003Epresents = presents,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator UnitOverPopup(Player player, int haveUnit)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Mypage0017Menu.\u003CUnitOverPopup\u003Ec__Iterator1C3()
    {
      haveUnit = haveUnit,
      player = player,
      \u003C\u0024\u003EhaveUnit = haveUnit,
      \u003C\u0024\u003Eplayer = player
    };
  }

  [DebuggerHidden]
  private IEnumerator ItemOverPopup(Player player, int haveItem)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Mypage0017Menu.\u003CItemOverPopup\u003Ec__Iterator1C4()
    {
      haveItem = haveItem,
      player = player,
      \u003C\u0024\u003EhaveItem = haveItem,
      \u003C\u0024\u003Eplayer = player
    };
  }

  [DebuggerHidden]
  private IEnumerator LimitOverPopup(string str)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Mypage0017Menu.\u003CLimitOverPopup\u003Ec__Iterator1C5()
    {
      str = str,
      \u003C\u0024\u003Estr = str
    };
  }

  [DebuggerHidden]
  private IEnumerator ReceiveConnection(PlayerPresent present)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Mypage0017Menu.\u003CReceiveConnection\u003Ec__Iterator1C6()
    {
      present = present,
      \u003C\u0024\u003Epresent = present,
      \u003C\u003Ef__this = this
    };
  }

  private void IbtnReceive(PlayerPresent present)
  {
    if (this.IsPushAndSet())
      return;
    Player player = SMManager.Get<Player>();
    PlayerUnit[] playerUnitArray = SMManager.Get<PlayerUnit[]>();
    PlayerItem[] source1 = SMManager.Get<PlayerItem[]>();
    PlayerQuestKey[] source2 = SMManager.Get<PlayerQuestKey[]>();
    int num = ((IEnumerable<PlayerItem>) ((IEnumerable<PlayerItem>) source1).Where<PlayerItem>((Func<PlayerItem, bool>) (x => x.entity_type == MasterDataTable.CommonRewardType.gear)).ToArray<PlayerItem>()).Count<PlayerItem>();
    if (present.reward_type_id.Value == 1 || present.reward_type_id.Value == 24)
    {
      UnitUnit unitUnit;
      if (!present.reward_id.HasValue || !MasterData.UnitUnit.TryGetValue(present.reward_id.Value, out unitUnit))
        return;
      if (unitUnit.IsNormalUnit)
      {
        if (playerUnitArray.Length >= player.max_units)
          this.StartCoroutine(this.UnitOverPopup(player, playerUnitArray.Length));
        else
          this.StartCoroutine(this.ReceiveConnection(present));
      }
      else
        this.StartCoroutine(this.ReceiveConnection(present));
    }
    else if (present.reward_type_id.Value == 3)
    {
      GearGear gearGear;
      if (!present.reward_id.HasValue || !MasterData.GearGear.TryGetValue(present.reward_id.Value, out gearGear))
        return;
      if (gearGear.isMaterial())
        this.StartCoroutine(this.ReceiveConnection(present));
      else if (num >= player.max_items)
        this.StartCoroutine(this.ItemOverPopup(player, ((IEnumerable<PlayerItem>) source1).Where<PlayerItem>((Func<PlayerItem, bool>) (x => x.entity_type == MasterDataTable.CommonRewardType.gear)).ToArray<PlayerItem>().Length));
      else
        this.StartCoroutine(this.ReceiveConnection(present));
    }
    else if (present.reward_type_id.Value == 19)
    {
      PlayerQuestKey playerQuestKey = ((IEnumerable<PlayerQuestKey>) source2).Where<PlayerQuestKey>((Func<PlayerQuestKey, bool>) (x =>
      {
        int questKeyId = x.quest_key_id;
        int? rewardId = present.reward_id;
        int valueOrDefault = rewardId.GetValueOrDefault();
        return questKeyId == valueOrDefault && rewardId.HasValue;
      })).FirstOrDefault<PlayerQuestKey>();
      if (playerQuestKey != null)
      {
        int? rewardQuantity = present.reward_quantity;
        int? nullable = !rewardQuantity.HasValue ? new int?() : new int?(playerQuestKey.quantity + rewardQuantity.Value);
        if ((!nullable.HasValue ? 0 : (nullable.Value <= playerQuestKey.max_quantity ? 1 : 0)) == 0)
        {
          if (playerQuestKey != null)
          {
            this.StartCoroutine(this.LimitOverPopup(MasterData.QuestkeyQuestkey[playerQuestKey.quest_key_id].name));
            return;
          }
          this.StartCoroutine(this.LimitOverPopup(Consts.GetInstance().UNIQUE_ICON_KEY));
          return;
        }
      }
      this.StartCoroutine(this.ReceiveConnection(present));
    }
    else if (present.reward_type_id.Value == 4)
    {
      if (player.money + present.reward_quantity.Value <= Consts.GetInstance().MONEY_MAX)
        this.StartCoroutine(this.ReceiveConnection(present));
      else
        this.StartCoroutine(this.LimitOverPopup(Consts.GetInstance().UNIQUE_ICON_ZENY));
    }
    else if (present.reward_type_id.Value == 15)
    {
      if (player.friend_point + present.reward_quantity.Value <= Consts.GetInstance().FRIEND_POINT_MAX)
        this.StartCoroutine(this.ReceiveConnection(present));
      else
        this.StartCoroutine(this.LimitOverPopup(Consts.GetInstance().UNIQUE_ICON_POINT));
    }
    else if (present.reward_type_id.Value == 14)
    {
      if (player.medal + present.reward_quantity.Value <= Consts.GetInstance().MEDAL_MAX)
        this.StartCoroutine(this.ReceiveConnection(present));
      else
        this.StartCoroutine(this.LimitOverPopup(Consts.GetInstance().UNIQUE_ICON_MEDAL));
    }
    else
      this.StartCoroutine(this.ReceiveConnection(present));
  }

  [DebuggerHidden]
  private IEnumerator HavePresentShow(PlayerPresent present)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Mypage0017Menu.\u003CHavePresentShow\u003Ec__Iterator1C7()
    {
      present = present,
      \u003C\u0024\u003Epresent = present,
      \u003C\u003Ef__this = this
    };
  }

  private void IbtnHavePresent(PlayerPresent present)
  {
    if (this.IsPushAndSet())
      return;
    this.StartCoroutine(this.HavePresentShow(present));
  }

  public virtual void IbtnBack()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().closeAll();
    Singleton<NGSceneManager>.GetInstance().destroyCurrentScene();
    MypageScene.ChangeScene(false);
  }

  public override void onBackButton() => this.IbtnBack();

  [DebuggerHidden]
  private IEnumerator ReceiveAll()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Mypage0017Menu.\u003CReceiveAll\u003Ec__Iterator1C8()
    {
      \u003C\u003Ef__this = this
    };
  }

  public virtual void IbtnGetall()
  {
    if (this.IsPushAndSet())
      return;
    this.StartCoroutine(this.ReceiveAll());
  }

  [DebuggerHidden]
  private IEnumerator DeleteAll()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Mypage0017Menu.\u003CDeleteAll\u003Ec__Iterator1C9()
    {
      \u003C\u003Ef__this = this
    };
  }

  public virtual void IbtnDeleteall()
  {
    if (this.IsPushAndSet())
      return;
    this.StartCoroutine(this.DeleteAll());
  }

  public void Initialize()
  {
    this.isInitialize = false;
    this.scroll.Clear();
  }

  private void InitializeEnd()
  {
    this.scrool_start_y = ((Component) this.scroll.scrollView).transform.localPosition.y;
    this.isInitialize = true;
  }

  protected override void Update()
  {
    base.Update();
    this.ScrollUpdate();
  }

  protected void ScrollUpdate()
  {
    if (!this.isInitialize || this.allPresentInfos.Count <= 8)
      return;
    int num1 = 270;
    float num2 = ((Component) this.scroll.scrollView).transform.localPosition.y - this.scrool_start_y;
    float num3 = (float) (Mathf.Max(0, this.allPresentInfos.Count - 8 - 1) / 1 * 135);
    float num4 = 1620f;
    if ((double) num2 < 0.0)
      num2 = 0.0f;
    if ((double) num2 > (double) num3)
      num2 = num3;
    bool flag;
    do
    {
      flag = false;
      int num5 = 0;
      foreach (GameObject gameObject in this.scroll)
      {
        GameObject unit = gameObject;
        float num6 = unit.transform.localPosition.y + num2;
        if ((double) num6 > (double) num1)
        {
          int? nullable = this.allPresentInfos.FirstIndexOrNull<PresentInfo>((Func<PresentInfo, bool>) (v => Object.op_Inequality((Object) v.scroll, (Object) null) && Object.op_Equality((Object) ((Component) v.scroll).gameObject, (Object) unit)));
          int info_index = !nullable.HasValue ? this.allPresentInfos.Count : nullable.Value + 12;
          if (nullable.HasValue && info_index < this.allPresentInfos.Count)
          {
            unit.transform.localPosition = new Vector3(unit.transform.localPosition.x, unit.transform.localPosition.y - num4, 0.0f);
            if (info_index >= this.allPresentInfos.Count)
            {
              unit.SetActive(false);
            }
            else
            {
              this.ResetScroll(num5);
              this.StartCoroutine(this.CreateScroll(info_index, num5));
            }
            flag = true;
          }
        }
        else if ((double) num6 < -((double) num4 - (double) num1))
        {
          int num7 = 12;
          if (!unit.activeSelf)
          {
            unit.SetActive(true);
            num7 = 0;
          }
          int? nullable = this.allPresentInfos.FirstIndexOrNull<PresentInfo>((Func<PresentInfo, bool>) (v => Object.op_Inequality((Object) v.scroll, (Object) null) && Object.op_Equality((Object) ((Component) v.scroll).gameObject, (Object) unit)));
          int info_index = !nullable.HasValue ? -1 : nullable.Value - num7;
          if (nullable.HasValue && info_index >= 0)
          {
            unit.transform.localPosition = new Vector3(unit.transform.localPosition.x, unit.transform.localPosition.y + num4, 0.0f);
            this.ResetScroll(num5);
            this.StartCoroutine(this.CreateScroll(info_index, num5));
            flag = true;
          }
        }
        ++num5;
      }
    }
    while (flag);
  }

  private void InitializePresentInfo(PlayerPresent[] presents)
  {
    this.allPresentInfos.Clear();
    foreach (PlayerPresent present in presents)
      this.allPresentInfos.Add(new PresentInfo()
      {
        present = present
      });
  }

  private void ResetScroll(int index)
  {
    Mypage0017Scroll scroll = this.allScroll[index];
    ((Component) scroll).gameObject.SetActive(false);
    this.allPresentInfos.Where<PresentInfo>((Func<PresentInfo, bool>) (a => Object.op_Equality((Object) a.scroll, (Object) scroll))).ForEach<PresentInfo>((Action<PresentInfo>) (b => b.scroll = (Mypage0017Scroll) null));
  }

  [DebuggerHidden]
  private IEnumerator CreateScrollBase(GameObject prefab)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Mypage0017Menu.\u003CCreateScrollBase\u003Ec__Iterator1CA()
    {
      prefab = prefab,
      \u003C\u0024\u003Eprefab = prefab,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator CreateScroll(int info_index, int unit_index)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Mypage0017Menu.\u003CCreateScroll\u003Ec__Iterator1CB()
    {
      unit_index = unit_index,
      info_index = info_index,
      \u003C\u0024\u003Eunit_index = unit_index,
      \u003C\u0024\u003Einfo_index = info_index,
      \u003C\u003Ef__this = this
    };
  }
}
