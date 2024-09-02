// Decompiled with JetBrains decompiler
// Type: BattleUI05PunitiveExpeditionRewardPopup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
    BattleUI05PunitiveExpeditionRewardPopup.\u003CInit\u003Ec__Iterator988 initCIterator988 = new BattleUI05PunitiveExpeditionRewardPopup.\u003CInit\u003Ec__Iterator988();
    return (IEnumerator) initCIterator988;
  }

  public void SetTapCallBack(System.Action callback) => this.anim.Init(callback);
}
