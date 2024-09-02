// Decompiled with JetBrains decompiler
// Type: PopupBuyKiseki
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using SM;
using UnityEngine;

#nullable disable
public class PopupBuyKiseki : BackButtonMenuBase
{
  [SerializeField]
  private UILabel title;
  [SerializeField]
  private UILabel message;
  [SerializeField]
  private UILabel himeMessage;
  [SerializeField]
  private UILabel HimeNum;
  [SerializeField]
  private GameObject slc_Kiseki_Bonus;
  private Modified<CoinBonus[]> coinBonus;

  private void Start()
  {
    this.coinBonus = SMManager.Observe<CoinBonus[]>();
    this.coinBonus.NotifyChanged();
  }

  public void Init(string message)
  {
    this.title.SetTextLocalize(Consts.Lookup("KISEKI_BUY_TITLE"));
    this.himeMessage.SetTextLocalize(Consts.Lookup("KISEKI_BUY_HIME_MESSAGE"));
    this.HimeNum.SetTextLocalize(SMManager.Get<Player>().coin);
    this.message.SetTextLocalize(message);
  }

  public virtual void IbtnRetrun()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().onDismiss();
  }

  public virtual void IbtnBuy()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().dismiss();
    this.StartCoroutine(PopupUtility.BuyKiseki());
  }

  public override void onBackButton() => this.IbtnRetrun();

  protected override void Update()
  {
    base.Update();
    if (!this.coinBonus.IsChangedOnce())
      return;
    this.slc_Kiseki_Bonus.SetActive(this.coinBonus.Value.Length > 0);
  }
}
