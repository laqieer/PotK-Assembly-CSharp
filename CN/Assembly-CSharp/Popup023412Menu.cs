// Decompiled with JetBrains decompiler
// Type: Popup023412Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Popup023412Menu : NGMenuBase
{
  public GameObject[] CpOnObject;
  public UILabel HimeNum;

  public void Init()
  {
    Player player = SMManager.Get<Player>();
    this.HimeNum.SetTextLocalize(player.coin);
    for (int index = 0; index < this.CpOnObject.Length; ++index)
      this.CpOnObject[index].SetActive(index < player.bp);
  }

  public virtual void IbtnYes()
  {
    if (SMManager.Get<Player>().coin > 0)
      this.StartCoroutine(this.CpRecovery());
    else
      this.StartCoroutine(this.ShowStoneAlert());
  }

  public virtual void IbtnNo() => Singleton<PopupManager>.GetInstance().onDismiss();

  [DebuggerHidden]
  private IEnumerator CpRecovery()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Popup023412Menu.\u003CCpRecovery\u003Ec__Iterator947 recoveryCIterator947 = new Popup023412Menu.\u003CCpRecovery\u003Ec__Iterator947();
    return (IEnumerator) recoveryCIterator947;
  }

  [DebuggerHidden]
  private IEnumerator ShowStoneAlert()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Popup023412Menu.\u003CShowStoneAlert\u003Ec__Iterator948 alertCIterator948 = new Popup023412Menu.\u003CShowStoneAlert\u003Ec__Iterator948();
    return (IEnumerator) alertCIterator948;
  }
}
