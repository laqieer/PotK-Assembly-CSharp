// Decompiled with JetBrains decompiler
// Type: Popup02687Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Popup02687Menu : Popup02610Base
{
  [SerializeField]
  private UILabel txtTitle;
  [SerializeField]
  private UILabel txtTopDescription;
  [SerializeField]
  private UILabel txtSeasonTicket;
  [SerializeField]
  private UILabel txtSeasonTicketNum;
  [SerializeField]
  private UILabel txtBotDescription;
  private bool isTicket;
  private PlayerSeasonTicket ticket;

  [DebuggerHidden]
  public override IEnumerator InitCoroutine(WebAPI.Response.PvpBoot pvpInfo, Versus02610Menu menu)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Popup02687Menu.\u003CInitCoroutine\u003Ec__Iterator968()
    {
      pvpInfo = pvpInfo,
      menu = menu,
      \u003C\u0024\u003EpvpInfo = pvpInfo,
      \u003C\u0024\u003Emenu = menu,
      \u003C\u003Ef__this = this
    };
  }

  public void IbtnOk()
  {
    if (this.IsPushAndSet())
      return;
    if (this.isTicket)
      Singleton<NGGameDataManager>.GetInstance().StartCoroutine(this.UpSeasonAPI());
    else
      Singleton<NGGameDataManager>.GetInstance().StartCoroutine(this.ShortagePopup());
  }

  [DebuggerHidden]
  private IEnumerator UpSeasonAPI()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Popup02687Menu.\u003CUpSeasonAPI\u003Ec__Iterator969()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator CompPopup(int cnt)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Popup02687Menu.\u003CCompPopup\u003Ec__Iterator96A()
    {
      cnt = cnt,
      \u003C\u0024\u003Ecnt = cnt
    };
  }

  [DebuggerHidden]
  private IEnumerator ShortagePopup()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Popup02687Menu.\u003CShortagePopup\u003Ec__Iterator96B()
    {
      \u003C\u003Ef__this = this
    };
  }

  public override void IbtnNo()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().onDismiss();
    Singleton<NGGameDataManager>.GetInstance().StartCoroutine(this.Return2688Popup());
  }

  public override void onBackButton() => this.IbtnNo();
}
