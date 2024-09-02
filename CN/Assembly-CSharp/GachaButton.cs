// Decompiled with JetBrains decompiler
// Type: GachaButton
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class GachaButton : MonoBehaviour
{
  public Consts.GachaType gachaType;
  public Gacha0063Menu menu_;
  public string gacha_name_;
  public int max_play_num_;
  public Startup00010ScoreDraw use_point_;
  public Startup00010ScoreDraw play_num_;
  public Transform slc_GachaPTNeed;
  public Transform dir_GachaPointUse;
  public Transform san_slc_GachaPTNeedPosition;
  public Transform san_dir_GachaPointUsePosition;
  public Transform yon_slc_GachaPTNeedPosition;
  public Transform yon_dir_GachaPointUsePosition;

  public GachaModuleGacha gacha_data_ { get; set; }

  public GachaModule gacha_module_data_ { get; set; }

  public void Init(string name, GachaModuleGacha data, Gacha0063Menu menu, int gachaType)
  {
    this.gacha_name_ = name;
    this.gacha_data_ = data;
    this.menu_ = menu;
    this.gachaType = (Consts.GachaType) gachaType;
    if (this.gacha_data_.payment_amount > 999)
    {
      if (Object.op_Implicit((Object) this.slc_GachaPTNeed))
        this.slc_GachaPTNeed.localPosition = this.yon_slc_GachaPTNeedPosition.localPosition;
      if (Object.op_Implicit((Object) this.dir_GachaPointUse))
        this.dir_GachaPointUse.localPosition = this.yon_dir_GachaPointUsePosition.localPosition;
    }
    else
    {
      if (Object.op_Implicit((Object) this.slc_GachaPTNeed))
        this.slc_GachaPTNeed.localPosition = this.san_slc_GachaPTNeedPosition.localPosition;
      if (Object.op_Implicit((Object) this.dir_GachaPointUse))
        this.dir_GachaPointUse.localPosition = this.san_dir_GachaPointUsePosition.localPosition;
    }
    if (!Object.op_Implicit((Object) this.use_point_))
      return;
    this.use_point_.Draw(this.gacha_data_.payment_amount);
  }

  public void SetMaxPlayNum(int max_play_nam)
  {
    this.max_play_num_ = max_play_nam;
    if (max_play_nam * this.gacha_data_.payment_amount > 999)
    {
      if (Object.op_Implicit((Object) this.slc_GachaPTNeed))
        this.slc_GachaPTNeed.localPosition = this.yon_slc_GachaPTNeedPosition.localPosition;
      if (Object.op_Implicit((Object) this.dir_GachaPointUse))
        this.dir_GachaPointUse.localPosition = this.yon_dir_GachaPointUsePosition.localPosition;
    }
    else
    {
      if (Object.op_Implicit((Object) this.slc_GachaPTNeed))
        this.slc_GachaPTNeed.localPosition = this.san_slc_GachaPTNeedPosition.localPosition;
      if (Object.op_Implicit((Object) this.dir_GachaPointUse))
        this.dir_GachaPointUse.localPosition = this.san_dir_GachaPointUsePosition.localPosition;
    }
    if (Object.op_Implicit((Object) this.use_point_))
      this.use_point_.Draw(max_play_nam * this.gacha_data_.payment_amount);
    if (!Object.op_Implicit((Object) this.play_num_))
      return;
    this.play_num_.Draw(max_play_nam);
  }

  public void IbtnGachaCharge()
  {
    if (!this.menu_.CheckGachaCharge(this.gacha_data_) || this.menu_.IsPushAndSet())
      return;
    this.menu_.scene.GachaType = this.gachaType;
    Singleton<PopupManager>.GetInstance().open(this.menu_.gachaChargePrefab).GetComponent<Gacha0065Menu>().Init(this.gacha_name_, this.gacha_data_, this.menu_.scene);
  }

  public void IbtnGachaChargeMulti()
  {
    if (!this.menu_.CheckGachaCharge(this.gacha_data_) || this.menu_.IsPushAndSet())
      return;
    this.menu_.scene.GachaType = this.gachaType;
    Singleton<PopupManager>.GetInstance().open(this.menu_.gachaChargePrefab).GetComponent<Gacha0065Menu>().Init(this.gacha_name_, this.gacha_data_, this.menu_.scene);
  }

  public void IbtnGachaPt()
  {
    if (!this.menu_.CheckGachaPt(this.gacha_data_) || this.menu_.IsPushAndSet())
      return;
    this.menu_.scene.GachaType = this.gachaType;
    this.StartCoroutine(this.Play(gacha_data: this.gacha_data_));
  }

  public void IbtnGachasPt()
  {
    if (!this.menu_.CheckGachaPt(this.gacha_data_, this.max_play_num_) || this.menu_.IsPushAndSet())
      return;
    this.menu_.scene.GachaType = this.gachaType;
    this.StartCoroutine(this.Play(this.max_play_num_, this.gacha_data_));
  }

  public void IbtnGachaTicket()
  {
    if (!this.menu_.CheckGachaTicket(this.gacha_data_) || this.menu_.IsPushAndSet())
      return;
    this.menu_.scene.GachaType = this.gachaType;
    Singleton<PopupManager>.GetInstance().open(this.menu_.gachaTicketPopupPrefab).GetComponent<Popup00635Menu>().Init(this.gacha_data_, new System.Action(this.PlayGachaTicket));
  }

  private void PlayGachaTicket() => this.StartCoroutine(this.PlayTicket(1, this.gacha_data_));

  public void IbtnSheetGachaCharge()
  {
    if (!this.menu_.CheckGachaCharge(this.gacha_data_) || this.menu_.IsPushAndSet())
      return;
    this.menu_.scene.GachaType = this.gachaType;
    Singleton<PopupManager>.GetInstance().open(this.menu_.gachaChargePrefab).GetComponent<Gacha0065Menu>().Init(this.gacha_name_, this.gacha_data_, this.menu_.scene);
  }

  public void IbtnSheetGachaChargeMulti()
  {
    if (!this.menu_.CheckGachaCharge(this.gacha_data_) || this.menu_.IsPushAndSet())
      return;
    this.menu_.scene.GachaType = this.gachaType;
    Singleton<PopupManager>.GetInstance().open(this.menu_.gachaChargePrefab).GetComponent<Gacha0065Menu>().Init(this.gacha_name_, this.gacha_data_, this.menu_.scene);
  }

  [DebuggerHidden]
  public IEnumerator Play(int num = 1, GachaModuleGacha gacha_data = null)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GachaButton.\u003CPlay\u003Ec__Iterator3ED()
    {
      num = num,
      gacha_data = gacha_data,
      \u003C\u0024\u003Enum = num,
      \u003C\u0024\u003Egacha_data = gacha_data,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator PlayTicket(int num, GachaModuleGacha gacha_data)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GachaButton.\u003CPlayTicket\u003Ec__Iterator3EE()
    {
      num = num,
      gacha_data = gacha_data,
      \u003C\u0024\u003Enum = num,
      \u003C\u0024\u003Egacha_data = gacha_data
    };
  }

  public void ChangeButtonEvent(GachaModule gachaModule)
  {
    UIButton component = ((Component) this).gameObject.GetComponent<UIButton>();
    if (Object.op_Equality((Object) component, (Object) null))
      Debug.LogWarning((object) "UIButtonが外れている");
    else if (gachaModule.type == 6)
    {
      if (gachaModule.gacha[0].roll_count == 1)
        EventDelegate.Set(component.onClick, new EventDelegate.Callback(this.IbtnGachaCharge));
      else
        EventDelegate.Set(component.onClick, new EventDelegate.Callback(this.IbtnGachaChargeMulti));
    }
    else if (gachaModule.gacha[0].roll_count == 1)
      EventDelegate.Set(component.onClick, new EventDelegate.Callback(this.IbtnGachaCharge));
    else
      EventDelegate.Set(component.onClick, new EventDelegate.Callback(this.IbtnGachaChargeMulti));
  }

  public void SetGachaButton(int payment_amount, int quantity)
  {
    if (payment_amount <= quantity)
      return;
    ((Component) this).gameObject.GetComponent<UIButton>().isEnabled = false;
  }
}
