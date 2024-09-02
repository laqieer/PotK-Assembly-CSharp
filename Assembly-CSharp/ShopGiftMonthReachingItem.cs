// Decompiled with JetBrains decompiler
// Type: ShopGiftMonthReachingItem
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using SM;
using System.Collections;
using UnityEngine;

public class ShopGiftMonthReachingItem : MonoBehaviour
{
  [SerializeField]
  private Transform IconParent;
  [SerializeField]
  private UILabel description;

  public IEnumerator Init(GameObject withLoupeIcon, MonthlyPackExtraReward reward)
  {
    IEnumerator e = withLoupeIcon.Clone(this.IconParent).GetComponent<ItemIconDetail>().Init((MasterDataTable.CommonRewardType) reward.reward_type_id, reward.reward_id, reward.reward_quantity);
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    this.description.text = string.Format("{0}日目に確定", (object) reward.days);
  }
}
