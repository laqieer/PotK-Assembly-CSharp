// Decompiled with JetBrains decompiler
// Type: Popup02686Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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
    return (IEnumerator) new Popup02686Menu.\u003CInit\u003Ec__Iterator7F4()
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
