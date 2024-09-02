// Decompiled with JetBrains decompiler
// Type: Shop00721Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Shop00721Menu : BackButtonMenuBase
{
  [SerializeField]
  private NGxScroll scroll;
  [SerializeField]
  private GameObject slcKisekiBonus;
  [SerializeField]
  private UILabel txtOwnnumber;
  private int m_currentShopIdx;
  private GameObject productBannerPrefab;

  public int CurrentShopIDX
  {
    get => this.m_currentShopIdx;
    set => this.m_currentShopIdx = value;
  }

  private void Start()
  {
  }

  protected override void Update()
  {
    base.Update();
    this.UpdateKisekiBonus();
  }

  private void UpdateKisekiBonus()
  {
    Modified<CoinBonus[]> modified = SMManager.Observe<CoinBonus[]>();
    if (modified == null || !modified.IsChangedOnce())
      return;
    this.slcKisekiBonus.SetActive(modified.Value.Length > 0);
  }

  [DebuggerHidden]
  public IEnumerator Init()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop00721Menu.\u003CInit\u003Ec__Iterator4AA()
    {
      \u003C\u003Ef__this = this
    };
  }

  public virtual void Foreground()
  {
  }

  public void IbtnBuyKiseki()
  {
    if (this.IsPushAndSet())
      return;
    this.StartCoroutine(PopupUtility.BuyKiseki());
  }

  public void IbtnFonds()
  {
    if (this.IsPushAndSet())
      return;
    this.StartCoroutine(PopupUtility._007_19());
  }

  public void IbtnSpecific()
  {
    if (this.IsPushAndSet())
      return;
    this.StartCoroutine(PopupUtility._007_18());
  }

  public virtual void IbtnBack()
  {
    if (this.IsPushAndSet())
      return;
    this.CurrentShopIDX = 0;
    Shop0071Scene.changeScene(false, false);
  }

  public override void onBackButton() => this.IbtnBack();

  public virtual void VScrollBar()
  {
  }
}
