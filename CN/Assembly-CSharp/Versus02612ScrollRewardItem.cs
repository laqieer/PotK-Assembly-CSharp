// Decompiled with JetBrains decompiler
// Type: Versus02612ScrollRewardItem
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Versus02612ScrollRewardItem : MonoBehaviour
{
  [SerializeField]
  private UILabel txtDetail;
  [SerializeField]
  private UIButton ibtnDetail;
  [SerializeField]
  private GameObject objLine;
  [SerializeField]
  private GameObject linkTarget;
  private GameObject detailPopup;
  private MasterDataTable.CommonRewardType rewardType;
  private int rewardID;
  private bool isDetail;
  private int[] canDetailItems = new int[6]
  {
    1,
    24,
    3,
    2,
    19,
    21
  };

  [DebuggerHidden]
  public IEnumerator CreateItem(
    MasterDataTable.CommonRewardType rewardType,
    int rewardID,
    string txt,
    bool isLineObj)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Versus02612ScrollRewardItem.\u003CCreateItem\u003Ec__Iterator639()
    {
      txt = txt,
      isLineObj = isLineObj,
      rewardType = rewardType,
      rewardID = rewardID,
      \u003C\u0024\u003Etxt = txt,
      \u003C\u0024\u003EisLineObj = isLineObj,
      \u003C\u0024\u003ErewardType = rewardType,
      \u003C\u0024\u003ErewardID = rewardID,
      \u003C\u003Ef__this = this
    };
  }

  public void IbtnDetail()
  {
    if (this.isDetail)
      return;
    this.isDetail = true;
    this.StartCoroutine(this.onDetail());
  }

  [DebuggerHidden]
  private IEnumerator onDetail()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Versus02612ScrollRewardItem.\u003ConDetail\u003Ec__Iterator63A()
    {
      \u003C\u003Ef__this = this
    };
  }
}
