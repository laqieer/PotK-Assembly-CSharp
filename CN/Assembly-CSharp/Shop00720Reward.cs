// Decompiled with JetBrains decompiler
// Type: Shop00720Reward
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Shop00720Reward : MonoBehaviour
{
  [SerializeField]
  private GameObject Thumbnail;
  [SerializeField]
  private UILabel Label;

  [DebuggerHidden]
  public IEnumerator Init(MasterDataTable.CommonRewardType rewardType, int rewardID, int quantity, string txt)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop00720Reward.\u003CInit\u003Ec__Iterator457()
    {
      txt = txt,
      rewardType = rewardType,
      rewardID = rewardID,
      quantity = quantity,
      \u003C\u0024\u003Etxt = txt,
      \u003C\u0024\u003ErewardType = rewardType,
      \u003C\u0024\u003ErewardID = rewardID,
      \u003C\u0024\u003Equantity = quantity,
      \u003C\u003Ef__this = this
    };
  }
}
