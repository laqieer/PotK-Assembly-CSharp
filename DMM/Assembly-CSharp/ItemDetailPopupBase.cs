// Decompiled with JetBrains decompiler
// Type: ItemDetailPopupBase
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using MasterDataTable;
using System.Collections;
using UnityEngine;

public class ItemDetailPopupBase : BackButtonMenuBase
{
  [SerializeField]
  private GameObject itemDetails_01;
  [SerializeField]
  private GameObject itemDetails_02;
  [SerializeField]
  protected GameObject commonPop;
  [SerializeField]
  protected Shop00742Unit unitPop;
  [SerializeField]
  protected Shop00742Item itemPop;
  [SerializeField]
  protected Shop00742Bugu buguPop;
  [SerializeField]
  protected Shop00742Key keyPop;
  [SerializeField]
  protected Shop00742KisekiAndMedal kisekiPop;
  [SerializeField]
  protected Shop00742BuguOther buguOtherPop;
  [SerializeField]
  protected Shop00742UnitOther unitOtherPop;
  [SerializeField]
  protected Shop00742SeasonTicket seasonTicketPop;
  [SerializeField]
  protected Shop00742AwakeSkill awakeSkill;
  [SerializeField]
  protected Shop00742Bugu buguCrystal;
  [SerializeField]
  protected Shop00742CommonPoint commonPoint;
  [SerializeField]
  protected Shop00742CommonTicket commonTicket;
  private System.Action noAction;

  public void SetAction(System.Action act) => this.noAction = act;

  public IEnumerator SetInfo(MasterDataTable.CommonRewardType type, int entity_id, int count = 0)
  {
    ItemDetailPopupBase itemDetailPopupBase = this;
    itemDetailPopupBase.GetComponent<UIWidget>().alpha = 0.0f;
    itemDetailPopupBase.unitPop.gameObject.SetActive(false);
    itemDetailPopupBase.itemPop.gameObject.SetActive(false);
    itemDetailPopupBase.buguPop.gameObject.SetActive(false);
    itemDetailPopupBase.keyPop.gameObject.SetActive(false);
    itemDetailPopupBase.buguOtherPop.gameObject.SetActive(false);
    itemDetailPopupBase.unitOtherPop.gameObject.SetActive(false);
    itemDetailPopupBase.seasonTicketPop.gameObject.SetActive(false);
    itemDetailPopupBase.awakeSkill.gameObject.SetActive(false);
    itemDetailPopupBase.buguCrystal.gameObject.SetActive(false);
    IEnumerator e;
    if (type == MasterDataTable.CommonRewardType.unit || type == MasterDataTable.CommonRewardType.material_unit)
    {
      UnitUnit target = MasterData.UnitUnit[entity_id];
      if (target.IsNormalUnit)
      {
        itemDetailPopupBase.unitPop.gameObject.SetActive(true);
        e = itemDetailPopupBase.unitPop.Init(target);
        while (e.MoveNext())
          yield return e.Current;
        e = (IEnumerator) null;
      }
      else
      {
        itemDetailPopupBase.unitOtherPop.gameObject.SetActive(true);
        e = itemDetailPopupBase.unitOtherPop.Initialize(target);
        while (e.MoveNext())
          yield return e.Current;
        e = (IEnumerator) null;
      }
    }
    else if (type == MasterDataTable.CommonRewardType.money || type == MasterDataTable.CommonRewardType.player_exp || type == MasterDataTable.CommonRewardType.friend_point)
    {
      itemDetailPopupBase.itemDetails_01.SetActive(false);
      itemDetailPopupBase.itemDetails_02.SetActive(true);
      itemDetailPopupBase.commonPoint.gameObject.SetActive(true);
      itemDetailPopupBase.commonPoint.Init(type, count);
    }
    else if (type == MasterDataTable.CommonRewardType.supply)
    {
      itemDetailPopupBase.itemPop.gameObject.SetActive(true);
      e = itemDetailPopupBase.itemPop.Init(entity_id);
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
    }
    else if (type == MasterDataTable.CommonRewardType.gear || type == MasterDataTable.CommonRewardType.material_gear)
    {
      GearGear target = MasterData.GearGear[entity_id];
      if (target.kind.isEquip)
      {
        itemDetailPopupBase.buguPop.gameObject.SetActive(true);
        e = itemDetailPopupBase.buguPop.Init(target);
        while (e.MoveNext())
          yield return e.Current;
        e = (IEnumerator) null;
      }
      else
      {
        itemDetailPopupBase.buguOtherPop.gameObject.SetActive(true);
        e = itemDetailPopupBase.buguOtherPop.Initialize(target);
        while (e.MoveNext())
          yield return e.Current;
        e = (IEnumerator) null;
      }
    }
    else if (type == MasterDataTable.CommonRewardType.gear_body)
    {
      GearGear target = MasterData.GearGear[entity_id];
      itemDetailPopupBase.buguCrystal.gameObject.SetActive(true);
      e = itemDetailPopupBase.buguCrystal.Init(target);
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
    }
    else if (type == MasterDataTable.CommonRewardType.coin || type == MasterDataTable.CommonRewardType.medal || type == MasterDataTable.CommonRewardType.battle_medal)
    {
      itemDetailPopupBase.keyPop.gameObject.SetActive(true);
      itemDetailPopupBase.kisekiPop.enabled = true;
      itemDetailPopupBase.keyPop.enabled = false;
      e = itemDetailPopupBase.kisekiPop.Init(type);
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
    }
    else
    {
      switch (type)
      {
        case MasterDataTable.CommonRewardType.quest_key:
          itemDetailPopupBase.keyPop.gameObject.SetActive(true);
          itemDetailPopupBase.keyPop.enabled = true;
          itemDetailPopupBase.kisekiPop.enabled = false;
          e = itemDetailPopupBase.keyPop.Init(entity_id);
          while (e.MoveNext())
            yield return e.Current;
          e = (IEnumerator) null;
          break;
        case MasterDataTable.CommonRewardType.season_ticket:
          itemDetailPopupBase.seasonTicketPop.gameObject.SetActive(true);
          e = itemDetailPopupBase.seasonTicketPop.Init(entity_id);
          while (e.MoveNext())
            yield return e.Current;
          e = (IEnumerator) null;
          break;
        case MasterDataTable.CommonRewardType.awake_skill:
          itemDetailPopupBase.commonPop.gameObject.SetActive(false);
          itemDetailPopupBase.awakeSkill.gameObject.SetActive(true);
          e = itemDetailPopupBase.awakeSkill.Init(entity_id, itemDetailPopupBase);
          while (e.MoveNext())
            yield return e.Current;
          e = (IEnumerator) null;
          break;
        default:
          if (type == MasterDataTable.CommonRewardType.gacha_ticket || type == MasterDataTable.CommonRewardType.unit_ticket || (type == MasterDataTable.CommonRewardType.reincarnation_type_ticket || type == MasterDataTable.CommonRewardType.stamp) || (type == MasterDataTable.CommonRewardType.recovery_item || type == MasterDataTable.CommonRewardType.common_ticket))
          {
            itemDetailPopupBase.itemDetails_01.SetActive(false);
            itemDetailPopupBase.itemDetails_02.SetActive(true);
            itemDetailPopupBase.commonTicket.gameObject.SetActive(true);
            e = itemDetailPopupBase.commonTicket.Init(type, entity_id);
            while (e.MoveNext())
              yield return e.Current;
            e = (IEnumerator) null;
            break;
          }
          break;
      }
    }
    itemDetailPopupBase.GetComponent<UIWidget>().alpha = 1f;
  }

  public virtual void IbtnNo()
  {
    if (this.noAction == null)
    {
      if (this.IsPushAndSet())
        return;
      Singleton<PopupManager>.GetInstance().onDismiss();
    }
    else
      this.noAction();
  }

  public override void onBackButton() => this.IbtnNo();
}
