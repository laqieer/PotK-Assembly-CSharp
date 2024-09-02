// Decompiled with JetBrains decompiler
// Type: Shop00722Product
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using MasterDataTable;
using System.Collections;
using UnityEngine;

public class Shop00722Product : MonoBehaviour
{
  [SerializeField]
  private GameObject dynThum;
  [SerializeField]
  private UILabel txtProductName;
  [SerializeField]
  private UILabel txtProductAmount;
  private System.Action<ShopContent> btnAction;
  private System.Action<SelectTicketSelectSample> btnAction2;
  private ShopContent contentData;
  private SelectTicketSelectSample sampleData;
  private Shop00722Product.SHOPTYPE shopType;

  public IEnumerator Init(
    SelectTicketSelectSample sample,
    System.Action<SelectTicketSelectSample> action)
  {
    this.shopType = Shop00722Product.SHOPTYPE.SelectTicket;
    this.sampleData = sample;
    this.btnAction2 = action;
    MasterDataTable.CommonRewardType type = (MasterDataTable.CommonRewardType) sample.entity_type_CommonRewardType;
    CreateIconObject orAddComponent = this.dynThum.GetOrAddComponent<CreateIconObject>();
    if ((UnityEngine.Object) orAddComponent != (UnityEngine.Object) null)
    {
      bool visibleBottom = true;
      if (sample.entity_type == MasterDataTable.CommonRewardType.supply || sample.entity_type == MasterDataTable.CommonRewardType.quest_key || (sample.entity_type == MasterDataTable.CommonRewardType.season_ticket || sample.entity_type == MasterDataTable.CommonRewardType.challenge_point))
        visibleBottom = false;
      IEnumerator e = orAddComponent.CreateThumbnail(type, sample.reward_id, sample.reward_value, visibleBottom);
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
    }
    this.txtProductName.SetTextLocalize(CommonRewardType.GetRewardName(type, sample.reward_id));
    this.txtProductAmount.SetTextLocalize(CommonRewardType.GetRewardQuantity(type, sample.reward_id, sample.reward_value));
  }

  public void IbtnPush()
  {
    if (this.shopType == Shop00722Product.SHOPTYPE.ShopContent)
    {
      if (this.btnAction == null || this.contentData.entity_type == MasterDataTable.CommonRewardType.battle_medal || (this.contentData.entity_type == MasterDataTable.CommonRewardType.medal || this.contentData.entity_type == MasterDataTable.CommonRewardType.gacha_ticket) || (this.contentData.entity_type == MasterDataTable.CommonRewardType.unit_ticket || this.contentData.entity_type == MasterDataTable.CommonRewardType.stamp || (this.contentData.entity_type == MasterDataTable.CommonRewardType.reincarnation_type_ticket || this.contentData.entity_type == MasterDataTable.CommonRewardType.challenge_point)) || this.contentData.entity_type == MasterDataTable.CommonRewardType.recovery_item)
        return;
      this.btnAction(this.contentData);
    }
    else
    {
      if (this.shopType != Shop00722Product.SHOPTYPE.SelectTicket || this.btnAction2 == null || (this.sampleData.entity_type == MasterDataTable.CommonRewardType.battle_medal || this.sampleData.entity_type == MasterDataTable.CommonRewardType.medal) || (this.sampleData.entity_type == MasterDataTable.CommonRewardType.gacha_ticket || this.sampleData.entity_type == MasterDataTable.CommonRewardType.unit_ticket || (this.sampleData.entity_type == MasterDataTable.CommonRewardType.stamp || this.sampleData.entity_type == MasterDataTable.CommonRewardType.reincarnation_type_ticket)) || (this.sampleData.entity_type == MasterDataTable.CommonRewardType.challenge_point || this.sampleData.entity_type == MasterDataTable.CommonRewardType.recovery_item))
        return;
      this.btnAction2(this.sampleData);
    }
  }

  private void OnDestroy()
  {
    this.btnAction = (System.Action<ShopContent>) null;
    this.btnAction2 = (System.Action<SelectTicketSelectSample>) null;
  }

  private enum SHOPTYPE
  {
    ShopContent,
    SelectTicket,
  }
}
