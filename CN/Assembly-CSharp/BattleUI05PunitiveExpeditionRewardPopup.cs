// Decompiled with JetBrains decompiler
// Type: BattleUI05PunitiveExpeditionRewardPopup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class BattleUI05PunitiveExpeditionRewardPopup : MonoBehaviour
{
  [SerializeField]
  private BattleUI05PunitiveExpeditionRewardPopupAnim anim;
  [SerializeField]
  private GameObject popupObj;

  [DebuggerHidden]
  public IEnumerator Init()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    BattleUI05PunitiveExpeditionRewardPopup.\u003CInit\u003Ec__Iterator8BB initCIterator8Bb = new BattleUI05PunitiveExpeditionRewardPopup.\u003CInit\u003Ec__Iterator8BB();
    return (IEnumerator) initCIterator8Bb;
  }

  public void SetTapCallBack(System.Action callback) => this.anim.Init(callback);
}
