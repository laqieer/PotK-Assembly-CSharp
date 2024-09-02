// Decompiled with JetBrains decompiler
// Type: Popup0235MenuBase
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Popup0235MenuBase : NGMenuBase
{
  protected System.Action onCallback;

  public void SetCallback(System.Action callback) => this.onCallback = callback;

  [DebuggerHidden]
  public virtual IEnumerator Init(
    ResultMenuBase.CampaignReward reward,
    ResultMenuBase.CampaignNextReward nextReward,
    GameObject gearObject,
    GameObject unitObject,
    GameObject uniqueObject)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Popup0235MenuBase.\u003CInit\u003Ec__Iterator952 initCIterator952 = new Popup0235MenuBase.\u003CInit\u003Ec__Iterator952();
    return (IEnumerator) initCIterator952;
  }

  public void IbtnOK()
  {
    if (this.onCallback != null)
      this.onCallback();
    Singleton<PopupManager>.GetInstance().onDismiss();
  }
}
