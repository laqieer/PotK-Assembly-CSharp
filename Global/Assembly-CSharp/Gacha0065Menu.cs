// Decompiled with JetBrains decompiler
// Type: Gacha0065Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Gacha0065Menu : BackButtonMenuBase
{
  [SerializeField]
  private string gacha_name_;
  [SerializeField]
  private int play_num_;
  [SerializeField]
  private UILabel TxtBonus;
  [SerializeField]
  private UILabel TxtDescription;
  [SerializeField]
  private UILabel TxtBonusDescription;
  [SerializeField]
  private UILabel TxtManaNumber;
  [SerializeField]
  private UILabel TxtNumber;
  [SerializeField]
  private UILabel TxtPopuptitle;
  [SerializeField]
  private GameObject bonusObj;
  [SerializeField]
  private GameObject normalObj;
  private Gacha0063Scene scene;
  private bool is_new;

  public GachaModuleGacha gacha_data_ { get; set; }

  public void IbtnNo()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().dismiss();
  }

  public override void onBackButton() => this.IbtnNo();

  public void IbtnGacha()
  {
    if (this.IsPushAndSet())
      return;
    this.StartCoroutine(this.Shot());
  }

  public void Init(string name, GachaModuleGacha gacha_data, Gacha0063Scene scene = null)
  {
    this.gacha_name_ = name;
    this.gacha_data_ = gacha_data;
    this.play_num_ = this.gacha_data_.roll_count;
    this.scene = scene;
    int coin = SMManager.Get<Player>().coin;
    int paymentAmount = this.gacha_data_.payment_amount;
    this.ChangeBonusMode(gacha_data.remain_count_for_reward, paymentAmount);
    this.TxtManaNumber.SetText(Consts.Lookup("GACHA_0065MENU_DESCRIPTION02"));
    this.TxtNumber.SetText(Consts.Lookup("GACHA_0065MENU_DESCRIPTION03", (IDictionary) new Hashtable()
    {
      {
        (object) "nowcrystal",
        (object) coin.ToString().ToConverter()
      }
    }));
    this.TxtPopuptitle.SetText(Consts.Lookup("GACHA_0065MENU_DESCRIPTION04"));
  }

  [DebuggerHidden]
  public IEnumerator Shot()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Gacha0065Menu.\u003CShot\u003Ec__Iterator38B()
    {
      \u003C\u003Ef__this = this
    };
  }

  private bool IsGachaEX()
  {
    return !Object.op_Equality((Object) this.scene, (Object) null) && this.scene.GachaType != Consts.GachaType.KISEKI && this.scene.GachaType != Consts.GachaType.FRIEND && this.scene.GachaType != Consts.GachaType.TICKET && this.scene.GachaType != Consts.GachaType.SHEET;
  }

  private void ChangeBonusMode(int? bonusCountDown, int lostCristal)
  {
    bool flag1 = bonusCountDown.HasValue && bonusCountDown.GetValueOrDefault() == 1 && bonusCountDown.HasValue;
    bool flag2 = bonusCountDown.HasValue && bonusCountDown.HasValue && bonusCountDown.Value > 0;
    this.bonusObj.SetActive(flag2);
    this.normalObj.SetActive(!flag2);
    string text1 = Consts.Lookup("GACHA_0065MENU_DESCRIPTION01", (IDictionary) new Hashtable()
    {
      {
        (object) "lostcrystal",
        (object) lostCristal.ToString().ToConverter()
      }
    });
    if (flag2)
    {
      string text2;
      if (flag1)
        text2 = Consts.Lookup("GACHA_0065MENU_DESCRIPTION06");
      else
        text2 = Consts.Lookup("GACHA_0065MENU_DESCRIPTION05", (IDictionary) new Hashtable()
        {
          {
            (object) nameof (bonusCountDown),
            (object) bonusCountDown.ToString().ToConverter()
          }
        });
      this.TxtBonus.SetText(text2);
      this.TxtBonusDescription.SetText(text1);
    }
    else
      this.TxtDescription.SetText(text1);
  }
}
