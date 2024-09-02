// Decompiled with JetBrains decompiler
// Type: Shop00723Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using MasterDataTable;
using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Shop00723Menu : BackButtonMenuBase
{
  private const int QUANTITY_DISPLAY_MAX = 999;
  private const int DEFAULT_UNIT_TYPE = 1;
  private const int MARGIN_FULL_SCREEN_COLLISION = 40;
  private const int DEPTH_FULL_SCREEN_BUTTON = 40;
  [SerializeField]
  private UILabel txtTitle_;
  [SerializeField]
  private UILabel txtDetail_;
  [SerializeField]
  private UILabel txtExpirationDate_;
  [SerializeField]
  private UILabel txtQuantity_;
  [SerializeField]
  private UILabel txtQuantityDesabled_;
  [SerializeField]
  private UILabel txtCost_;
  [SerializeField]
  private NGTweenParts[] firstTweens_;
  [SerializeField]
  private NGTweenParts[] lastTweens_;
  [SerializeField]
  private NGxScroll scroll_;
  private bool isInitialized_;
  private Shop00723Scene scene_;
  private PlayerUnitTicketSummary ticket_;
  private UnitTicketUnitSample[] unitSamples_;
  private GameObject prefabUnit_;
  private GameObject prefabConfirmation_;
  private GameObject prefabSkillList_;
  private GameObject prefabLeader_;
  private GameObject prefabSkill_;
  private GameObject prefabIconUnit_;
  private GameObject prefabIconSkill_;
  private GameObject prefabIconElement_;
  private GameObject prefabIconGenre_;
  private GameObject prefabExchange_;
  private GameObject prefabExecute_;
  private Shop00723UnitSelect[] units_;
  private UnitTicketUnitSample currentSample_;
  private UnitTypeEnum currentType_;
  private int quantity_;
  private Shop00723Menu.Phase phase_;
  private GameObject objEffect_;

  public GameObject prefabLeader => this.prefabLeader_;

  public GameObject prefabSkill => this.prefabSkill_;

  public GameObject prefabIconUnit => this.prefabIconUnit_;

  public GameObject prefabIconSkill => this.prefabIconSkill_;

  public GameObject prefabIconElement => this.prefabIconElement_;

  public GameObject prefabIconGenre => this.prefabIconGenre_;

  [DebuggerHidden]
  public IEnumerator coInitialize(Shop00723Scene scene, PlayerUnitTicketSummary unitTicket)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop00723Menu.\u003CcoInitialize\u003Ec__Iterator4B5()
    {
      scene = scene,
      unitTicket = unitTicket,
      \u003C\u0024\u003Escene = scene,
      \u003C\u0024\u003EunitTicket = unitTicket,
      \u003C\u003Ef__this = this
    };
  }

  private void updateTicketQuantity(bool usedTicket = false)
  {
    if (usedTicket)
      this.quantity_ -= this.ticket_.unit_ticket.cost;
    bool flag = this.quantity_ >= this.ticket_.unit_ticket.cost;
    int num = Mathf.Clamp(this.quantity_, 0, 999);
    if (flag)
    {
      this.txtQuantity_.SetTextLocalize(num);
      ((Component) this.txtQuantity_).gameObject.SetActive(true);
      ((Component) this.txtQuantityDesabled_).gameObject.SetActive(false);
    }
    else
    {
      ((Component) this.txtQuantity_).gameObject.SetActive(false);
      this.txtQuantityDesabled_.SetTextLocalize(num);
      ((Component) this.txtQuantityDesabled_).gameObject.SetActive(true);
    }
    if (this.units_ == null)
      return;
    foreach (Shop00723UnitSelect unit in this.units_)
      unit.btnSelectEnabled = flag;
  }

  [DebuggerHidden]
  private IEnumerator coInitializeUnitSelect()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop00723Menu.\u003CcoInitializeUnitSelect\u003Ec__Iterator4B6()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void onClickSkill(UnitTicketUnitSample unit)
  {
    if (!this.isInitialized_ || this.currentSample_ != null || this.IsPushAndSet())
      return;
    this.currentSample_ = unit;
    this.popupSkillMenu();
  }

  private void popupSkillMenu()
  {
    GameObject prefab = this.prefabSkillList_.Clone();
    prefab.GetComponent<Shop00723PopupSkillMenu>().initialize(this, this.currentSample_);
    Singleton<PopupManager>.GetInstance().open(prefab, isCloned: true, isNonSe: true, isNonOpenAnime: true);
  }

  public void onClosedSkill() => this.currentSample_ = (UnitTicketUnitSample) null;

  public void onClickSelect(UnitTicketUnitSample unit)
  {
    if (!this.isInitialized_ || this.currentSample_ != null || this.IsPushAndSet())
      return;
    this.currentSample_ = unit;
    this.StartCoroutine(this.coPopupSelect());
  }

  [DebuggerHidden]
  private IEnumerator coPopupSelect()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop00723Menu.\u003CcoPopupSelect\u003Ec__Iterator4B7()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void onClosedSelect() => this.currentSample_ = (UnitTicketUnitSample) null;

  public void doExchangeUnit(UnitTypeEnum unitType)
  {
    this.currentType_ = unitType;
    this.StartCoroutine(this.coExchangeUnit());
  }

  [DebuggerHidden]
  private IEnumerator coExchangeUnit()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop00723Menu.\u003CcoExchangeUnit\u003Ec__Iterator4B8()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void OnEnable()
  {
    if (this.phase_ != Shop00723Menu.Phase.EffectGet)
      return;
    this.StartCoroutine(this.coWaitDateTime());
  }

  [DebuggerHidden]
  private IEnumerator coWaitDateTime()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop00723Menu.\u003CcoWaitDateTime\u003Ec__Iterator4B9()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void deleteEffect()
  {
    if (!Object.op_Inequality((Object) this.objEffect_, (Object) null))
      return;
    Object.Destroy((Object) this.objEffect_);
    this.objEffect_ = (GameObject) null;
  }

  private void OnDestroy() => this.deleteEffect();

  [DebuggerHidden]
  private IEnumerator coPlayEffect(WebAPI.Response.UnitticketSpend result)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop00723Menu.\u003CcoPlayEffect\u003Ec__Iterator4BA()
    {
      result = result,
      \u003C\u0024\u003Eresult = result,
      \u003C\u003Ef__this = this
    };
  }

  private GameObject createFullScreenButton()
  {
    GameObject fullScreenButton = new GameObject("btnFullScreen");
    fullScreenButton.AddComponent<UIWidget>().depth = 40;
    fullScreenButton.AddComponent<BoxCollider>().size = Vector2.op_Implicit(new Vector2((float) (Screen.width + 40), (float) (Screen.height + 40)));
    ((Behaviour) fullScreenButton.AddComponent<UIButton>()).enabled = false;
    return fullScreenButton;
  }

  public override void onBackButton() => this.OnIbtnBack();

  public void OnIbtnBack()
  {
    if (this.phase_ != Shop00723Menu.Phase.Normal || this.IsPushAndSet())
      return;
    this.scene_.shopFinish();
    this.backScene();
  }

  private enum Phase
  {
    Normal,
    EffectGet,
  }
}
