// Decompiled with JetBrains decompiler
// Type: Shop0071Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Shop0071Menu : BackButtonMenuBase
{
  [SerializeField]
  protected UILabel TxtOwnnumber;
  [SerializeField]
  private GameObject slc_Kiseki_Bonus;
  [SerializeField]
  private Shop0071BattleMedalShopButton colosseumButtom;
  [SerializeField]
  private Shop0071BattleMedalShopButton colosseumButtomBeforeSlot;
  [SerializeField]
  private List<GameObject> ShopButtonGroup;
  [SerializeField]
  public FloatButton BtnFormation;
  [SerializeField]
  public UI2DSprite IdleSprite;
  [SerializeField]
  public UI2DSprite PressSprite;
  [SerializeField]
  private GameObject dynBannerLimit;
  private Modified<CoinBonus[]> coinBonus;
  private PlayerShopArticle shop;
  public Shop0071LeaderStand leaderStand;
  private GameObject modalPopup;
  private GameObject bannerLimitEmphasiePrefab;
  private BannerLimitEmphasie bannerLimitEmphasie;

  private void Start() => this.coinBonus = SMManager.Observe<CoinBonus[]>();

  private void ModalWindowNoBtn() => Object.DestroyObject((Object) this.modalPopup);

  [DebuggerHidden]
  public IEnumerator Init(WebAPI.Response.ShopStatus shopStatus, bool specialShopError)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop0071Menu.\u003CInit\u003Ec__Iterator3BC()
    {
      specialShopError = specialShopError,
      shopStatus = shopStatus,
      \u003C\u0024\u003EspecialShopError = specialShopError,
      \u003C\u0024\u003EshopStatus = shopStatus,
      \u003C\u003Ef__this = this
    };
  }

  public void onOver()
  {
    ((Component) this.IdleSprite).gameObject.SetActive(false);
    ((Component) this.PressSprite).gameObject.SetActive(true);
  }

  public void onOut()
  {
    ((Component) this.IdleSprite).gameObject.SetActive(true);
    ((Component) this.PressSprite).gameObject.SetActive(false);
  }

  public void onStartScene()
  {
    bool featureColosseum = Player.Current.GetFeatureColosseum();
    bool releaseColosseum = Player.Current.GetReleaseColosseum();
    bool releaseSlot = Player.Current.GetReleaseSlot();
    if (releaseSlot)
      this.InitButtonColosseum(this.colosseumButtom, featureColosseum, releaseColosseum);
    else
      this.InitButtonColosseum(this.colosseumButtomBeforeSlot, featureColosseum, releaseColosseum);
    this.ShopButtonGroup.ToggleOnce(!releaseSlot ? 1 : 0);
    Queue<string> advices = new Queue<string>();
    advices.Enqueue(!releaseSlot ? "shop007_1_base" : "shop007_1_base_slot");
    if (featureColosseum)
      advices.Enqueue(!releaseColosseum ? "shop007_1_colosseum_closed" : "shop007_1_colosseum");
    Queue<int> advicesId = new Queue<int>();
    advicesId.Enqueue(!releaseSlot ? 5 : 22);
    if (featureColosseum)
      advicesId.Enqueue(!releaseColosseum ? 21 : 20);
    this.showAdvice(advices, advicesId);
  }

  private void InitButtonColosseum(
    Shop0071BattleMedalShopButton button,
    bool feature,
    bool release)
  {
    ((Component) button.ColosseumButton).GetComponent<Collider>().enabled = release;
    ((Component) button.ColosseumButtonLabel).gameObject.SetActive(release);
    ((Component) button.ColosseumButtonDisabledLabel).gameObject.SetActive(!release);
    ((Behaviour) button.ColosseumButton).enabled = true;
    ((Component) button.ColosseumButton).gameObject.SetActive(feature);
  }

  private void showAdvice(Queue<string> advices)
  {
    if (advices.Count == 0)
      return;
    string sceneName = advices.Dequeue();
    if (Singleton<TutorialRoot>.GetInstance().ShowAdvice(sceneName, finishCallback: (System.Action) (() => this.showAdvice(advices))))
      return;
    this.showAdvice(advices);
  }

  private void showAdvice(Queue<string> advices, Queue<int> advicesId)
  {
    if (advices.Count == 0 || advicesId.Count == 0)
      return;
    string sceneName = advices.Dequeue();
    int id = advicesId.Dequeue();
    if (Singleton<TutorialRoot>.GetInstance().ShowAdvice(sceneName, id, (System.Action) (() => this.showAdvice(advices, advicesId))))
      return;
    this.showAdvice(advices, advicesId);
  }

  public void SetInitalView(string stone, string status, string unit, string item)
  {
    this.TxtOwnnumber.SetTextLocalize(stone);
    this.leaderStand.SetLeaderCharacter();
  }

  public void SetTextData(string stone, string status, string unit, string item)
  {
    this.TxtOwnnumber.SetTextLocalize(stone);
  }

  [DebuggerHidden]
  private IEnumerator popup999111AP()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Shop0071Menu.\u003Cpopup999111AP\u003Ec__Iterator3BD popup999111ApCIterator3Bd = new Shop0071Menu.\u003Cpopup999111AP\u003Ec__Iterator3BD();
    return (IEnumerator) popup999111ApCIterator3Bd;
  }

  [DebuggerHidden]
  private IEnumerator popup00712()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Shop0071Menu.\u003Cpopup00712\u003Ec__Iterator3BE popup00712CIterator3Be = new Shop0071Menu.\u003Cpopup00712\u003Ec__Iterator3BE();
    return (IEnumerator) popup00712CIterator3Be;
  }

  [DebuggerHidden]
  private IEnumerator popupAlert999111()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop0071Menu.\u003CpopupAlert999111\u003Ec__Iterator3BF()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator popup00714()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Shop0071Menu.\u003Cpopup00714\u003Ec__Iterator3C0 popup00714CIterator3C0 = new Shop0071Menu.\u003Cpopup00714\u003Ec__Iterator3C0();
    return (IEnumerator) popup00714CIterator3C0;
  }

  [DebuggerHidden]
  private IEnumerator popupAlert999121()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop0071Menu.\u003CpopupAlert999121\u003Ec__Iterator3C1()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator popup00716()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Shop0071Menu.\u003Cpopup00716\u003Ec__Iterator3C2 popup00716CIterator3C2 = new Shop0071Menu.\u003Cpopup00716\u003Ec__Iterator3C2();
    return (IEnumerator) popup00716CIterator3C2;
  }

  protected override void Update()
  {
    base.Update();
    if (!this.coinBonus.IsChangedOnce())
      return;
    this.slc_Kiseki_Bonus.SetActive(this.coinBonus.Value.Length > 0);
  }

  public override void onBackButton()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<NGSceneManager>.GetInstance().clearStack();
    Singleton<NGSceneManager>.GetInstance().destroyCurrentScene();
    MypageScene.ChangeScene(false);
  }

  public virtual void IbtnBuyKiseki()
  {
    if (this.IsPushAndSet())
      return;
    this.StartCoroutine(PopupUtility.BuyKiseki());
  }

  public virtual void IbtnFonds()
  {
    if (this.IsPushAndSet())
      return;
    this.StartCoroutine(PopupUtility._007_19());
  }

  public virtual void IbtnItemPlus()
  {
    if (this.IsPushAndSet())
      return;
    if (SMManager.Observe<Player>().Value.CheckLimitMaxItem())
      this.StartCoroutine(this.popupAlert999121());
    else
      this.StartCoroutine(this.popup00716());
  }

  public virtual void IbtnMedalshop()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<NGSceneManager>.GetInstance().changeScene("shop007_4_1", true);
  }

  public virtual void IbtnMedalSlot()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<NGSceneManager>.GetInstance().changeScene("shop007_20", true);
  }

  public virtual void IbtnSpecific()
  {
    if (this.IsPushAndSet())
      return;
    this.StartCoroutine(PopupUtility._007_18());
  }

  public virtual void IbtnStatusPlus()
  {
    if (this.IsPushAndSet())
      return;
    if (SMManager.Observe<Player>().Value.CheckApFull())
      this.StartCoroutine(this.popup999111AP());
    else
      this.StartCoroutine(this.popup00712());
  }

  public virtual void IbtnUnitPlus()
  {
    if (this.IsPushAndSet())
      return;
    if (SMManager.Observe<Player>().Value.CheckLimitMaxUnit())
      this.StartCoroutine(this.popupAlert999111());
    else
      this.StartCoroutine(this.popup00714());
  }

  public virtual void IbtnZenyshop()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<NGSceneManager>.GetInstance().changeScene("shop007_4", true);
  }

  public virtual void IbtnChara()
  {
  }

  public void IbtnBattleMedalshop()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<NGSceneManager>.GetInstance().changeScene("shop007_4_3", true);
  }

  public void IbtnSpecialShop() => Shop00721Scene.changeScene(true, true);
}
