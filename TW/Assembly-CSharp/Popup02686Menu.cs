// Decompiled with JetBrains decompiler
// Type: Popup02686Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Popup02686Menu : MonoBehaviour
{
  [SerializeField]
  private GameObject link_icon;
  [SerializeField]
  private UILabel txtDescription;
  [SerializeField]
  private UILabel txtTitle;
  [SerializeField]
  private UILabel txtShowText;
  private System.Action onCallback;

  [DebuggerHidden]
  public IEnumerator Init(Versus0268Menu.PvpParam.FirstBattleReward reward)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Popup02686Menu.\u003CInit\u003Ec__IteratorA38()
    {
      reward = reward,
      \u003C\u0024\u003Ereward = reward,
      \u003C\u003Ef__this = this
    };
  }

  public void SetCallback(System.Action callback) => this.onCallback = callback;

  public void IbtnOK()
  {
    if (this.onCallback != null)
      this.onCallback();
    Singleton<PopupManager>.GetInstance().onDismiss();
  }
}
