// Decompiled with JetBrains decompiler
// Type: Popup02682MenuBase
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Popup02682MenuBase : MonoBehaviour
{
  protected System.Action onCallback;

  public void SetCallback(System.Action callback) => this.onCallback = callback;

  [DebuggerHidden]
  public virtual IEnumerator Init(
    Versus0268Menu.PvpParam.CampaignReward reward,
    Versus0268Menu.PvpParam.CampaignNextReward nextReward)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Popup02682MenuBase.\u003CInit\u003Ec__IteratorA34 initCIteratorA34 = new Popup02682MenuBase.\u003CInit\u003Ec__IteratorA34();
    return (IEnumerator) initCIteratorA34;
  }

  public void IbtnOK()
  {
    if (this.onCallback != null)
      this.onCallback();
    Singleton<PopupManager>.GetInstance().onDismiss();
  }
}
