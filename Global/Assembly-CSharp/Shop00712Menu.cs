// Decompiled with JetBrains decompiler
// Type: Shop00712Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Shop00712Menu : BackButtonMenuBase
{
  private const int APBP_RECOVERY_SHOP_ID = 10000001;
  private Modified<Player> player;
  [SerializeField]
  private GameObject DirPopup01;
  [SerializeField]
  private GameObject DirPopup02;
  [SerializeField]
  private UILabel TxtDescription01;
  [SerializeField]
  private UILabel TxtDescription02;
  [SerializeField]
  private UILabel TxtDescription03;
  [SerializeField]
  private UILabel TxtPopuptitle;
  [SerializeField]
  private UILabel txtnumber;

  [DebuggerHidden]
  private IEnumerator APRecover()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Shop00712Menu.\u003CAPRecover\u003Ec__Iterator3C9 recoverCIterator3C9 = new Shop00712Menu.\u003CAPRecover\u003Ec__Iterator3C9();
    return (IEnumerator) recoverCIterator3C9;
  }

  public void IbtnPopupYes()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().onDismiss(true);
    Player player = this.player.Value;
    if (player.ap >= player.ap_max)
      Singleton<PopupManager>.GetInstance().closeAll();
    else if (SMManager.Get<Player>().CheckKiseki(1))
      this.StartCoroutine(this.APRecoverAsync());
    else
      this.StartCoroutine(PopupUtility._999_3_1(Consts.Lookup("SHOP_99931_TXT_DESCRIPTION"), string.Empty));
  }

  [DebuggerHidden]
  private IEnumerator APRecoverAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop00712Menu.\u003CAPRecoverAsync\u003Ec__Iterator3CA()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator popup00713()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Shop00712Menu.\u003Cpopup00713\u003Ec__Iterator3CB popup00713CIterator3Cb = new Shop00712Menu.\u003Cpopup00713\u003Ec__Iterator3CB();
    return (IEnumerator) popup00713CIterator3Cb;
  }

  public void IbtnNo()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().onDismiss();
  }

  public override void onBackButton() => this.IbtnNo();

  public void setUserData()
  {
    this.player = SMManager.Observe<Player>();
    Player player = this.player.Value;
    this.TxtDescription02.SetTextLocalize(Consts.Lookup("SHOP_00712_MENU_AP_RECOVERY", (IDictionary) new Hashtable()
    {
      {
        (object) "now",
        (object) player.ap
      },
      {
        (object) "max",
        (object) player.ap_max
      }
    }));
    this.txtnumber.SetTextLocalize(player.coin);
  }
}
