// Decompiled with JetBrains decompiler
// Type: Gacha99931Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using SM;
using UnityEngine;

#nullable disable
public class Gacha99931Menu : BackButtonMenuBase
{
  [SerializeField]
  private UIButton uiBuyButton;
  [SerializeField]
  private UIButton uiBackButton;
  [SerializeField]
  private UILabel TxtDescription01;
  [SerializeField]
  private UILabel TxtDescription02;
  [SerializeField]
  private UILabel TxtDescription03;
  [SerializeField]
  private UILabel TxtPopupTitle;
  [SerializeField]
  private GameObject slc_Kiseki_Bonus;
  private Modified<CoinBonus[]> coinBonus;

  private void Awake() => this.slc_Kiseki_Bonus.SetActive(false);

  private void Start()
  {
    this.coinBonus = SMManager.Observe<CoinBonus[]>();
    this.coinBonus.NotifyChanged();
  }

  public void IbtnNo()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().onDismiss();
  }

  public void IbtnBuyKiseki()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().dismiss(true);
    this.StartCoroutine(PopupUtility.BuyKiseki());
  }

  public void SetText(string text1 = "", string text2 = "")
  {
    Player player = SMManager.Get<Player>();
    this.TxtDescription02.SetText(Consts.GetInstance().GACHA_99931MENU_DESCRIPTION03.ToConverter());
    this.TxtDescription03.SetText(player.coin.ToString().ToConverter());
    if (Object.op_Equality((Object) this.uiBuyButton, (Object) null))
      this.uiBuyButton = ((Component) ((Component) this).transform.FindChild("ibtn_Buy_Kiseki")).GetComponent<UIButton>();
    if (Object.op_Equality((Object) this.uiBackButton, (Object) null))
      this.uiBackButton = ((Component) ((Component) this).transform.FindChild("ibtn_Popup_Back")).GetComponent<UIButton>();
    if (text1 == string.Empty)
      this.TxtDescription01.SetText(Consts.Format(Consts.GetInstance().GACHA_99931MENU_DESCRIPTION01));
    else
      this.TxtDescription01.SetText(text1);
    if (text2 == string.Empty)
      this.TxtPopupTitle.SetText(Consts.Format(Consts.GetInstance().GACHA_99931MENU_DESCRIPTION02));
    else
      this.TxtPopupTitle.SetText(text2);
  }

  protected override void Update()
  {
    base.Update();
    if (!this.coinBonus.IsChangedOnce())
      return;
    this.slc_Kiseki_Bonus.SetActive(this.coinBonus.Value.Length > 0);
  }

  public override void onBackButton() => this.IbtnNo();
}
