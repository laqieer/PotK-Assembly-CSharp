// Decompiled with JetBrains decompiler
// Type: Shop00720Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class Shop00720Menu : BackButtonMenuBase
{
  [SerializeField]
  private GameObject Title;
  [SerializeField]
  private GameObject IbtnBack;
  [SerializeField]
  private GameObject MedalInfo;
  [SerializeField]
  private UILabel MedalHeld;
  [SerializeField]
  private GameObject IbtnCheckReward;
  [SerializeField]
  private GameObject IbtnShot;
  [SerializeField]
  private UISprite MedalCost;
  [SerializeField]
  private GameObject IbtnSkip;
  [SerializeField]
  private UISprite[] PaymentAmounts;
  private GameObject slot;
  private Shop00720EffectController effect;
  private Shop00720Prefabs prefabs;
  private bool isInitalize;
  private bool isWaitForShot = true;
  private List<UITweener> tweeners = new List<UITweener>();
  private SlotModule slotModule;

  [DebuggerHidden]
  public IEnumerator Initialize(Shop00720Scene scene)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop00720Menu.\u003CInitialize\u003Ec__Iterator3CE()
    {
      \u003C\u003Ef__this = this
    };
  }

  private string[] GetReelPattern(int row)
  {
    return ((IEnumerable<SlotS001MedalReelDetail>) MasterData.SlotS001MedalReelDetailList).Where<SlotS001MedalReelDetail>((Func<SlotS001MedalReelDetail, bool>) (w => w.reel_detail_id == row)).Select<SlotS001MedalReelDetail, int>((Func<SlotS001MedalReelDetail, int>) (s => s.icon_id)).Select<int, string>((Func<int, string>) (s => this.GetIconFileName(s))).ToArray<string>();
  }

  private string GetIconFileName(int id)
  {
    return ((IEnumerable<SlotS001MedalReelIcon>) MasterData.SlotS001MedalReelIconList).SingleOrDefault<SlotS001MedalReelIcon>((Func<SlotS001MedalReelIcon, bool>) (sd => sd.ID == id)).file_name;
  }

  public void Ready()
  {
    foreach (UITweener tweener in this.tweeners)
      tweener.PlayForward();
    this.MedalHeld.text = Player.Current.medal.ToString();
    this.slotModule = ((IEnumerable<SlotModule>) SMManager.Get<SlotModule[]>()).FirstOrDefault<SlotModule>();
    if (this.slotModule != null)
    {
      SlotModuleSlot slotModuleSlot = ((IEnumerable<SlotModuleSlot>) this.slotModule.slot).FirstOrDefault<SlotModuleSlot>();
      this.MedalCost.SetSprite(string.Format("num_{0}.png__GUI__007-20_sozai__007-20_sozai_prefab", (object) slotModuleSlot.payment_amount));
      UIButton component = this.IbtnShot.GetComponent<UIButton>();
      if (slotModuleSlot.payment_amount > Player.Current.medal)
      {
        component.isEnabled = false;
        foreach (UIWidget paymentAmount in this.PaymentAmounts)
          paymentAmount.color = Consts.GetInstance().UI_SPRITE_DISABLED_COLOR;
      }
      else
      {
        component.isEnabled = true;
        foreach (UIWidget paymentAmount in this.PaymentAmounts)
          paymentAmount.color = Consts.GetInstance().UI_SPRITE_NORMAL_COLOR;
      }
    }
    else
      Debug.LogWarning((object) "No SlotModule has been set");
    this.effect.loadState = false;
    this.isWaitForShot = true;
    this.isInitalize = true;
  }

  private void SetTweeners(List<GameObject> list)
  {
    foreach (GameObject gameObject in list)
      this.tweeners = this.tweeners.Concat<UITweener>((IEnumerable<UITweener>) gameObject.GetComponents<UITweener>()).ToList<UITweener>();
  }

  public void OnIbtnBack()
  {
    if (!this.isWaitForShot || this.IsPushAndSet())
      return;
    this.backScene();
  }

  public override void onBackButton() => this.OnIbtnBack();

  public void OnIbtnShot()
  {
    this.isWaitForShot = false;
    this.StartCoroutine(this.MedalPay());
  }

  private void StartSlotEff()
  {
    foreach (UITweener tweener in this.tweeners)
      tweener.PlayReverse();
    this.effect.Bet();
  }

  [DebuggerHidden]
  private IEnumerator MedalPay()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop00720Menu.\u003CMedalPay\u003Ec__Iterator3CF()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator SetResult(WebAPI.Response.SlotS001MedalPay result)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop00720Menu.\u003CSetResult\u003Ec__Iterator3D0()
    {
      result = result,
      \u003C\u0024\u003Eresult = result,
      \u003C\u003Ef__this = this
    };
  }

  public void OnIbtnSkip()
  {
    this.effect.Bet();
    this.effect.Skip();
    if (!this.effect.Slot_script.isReady)
      return;
    this.Ready();
  }

  public void OnIbtnCheckReward()
  {
    if (this.IsPushAndSet())
      return;
    this.StartCoroutine(this.ShowRewards(this.prefabs));
  }

  [DebuggerHidden]
  private IEnumerator ShowRewards(Shop00720Prefabs prefabs)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop00720Menu.\u003CShowRewards\u003Ec__Iterator3D1()
    {
      prefabs = prefabs,
      \u003C\u0024\u003Eprefabs = prefabs
    };
  }

  public void DestroyEffect() => Object.Destroy((Object) this.slot);

  protected override void Update()
  {
    if (!this.isInitalize)
      return;
    base.Update();
    if (this.effect.Slot_script.isReady)
    {
      this.IbtnSkip.SetActive(false);
      this.IbtnShot.SetActive(true);
      this.IbtnCheckReward.SetActive(true);
      Singleton<CommonRoot>.GetInstance().SetFooterEnable(true);
    }
    else if (this.effect.Slot_script.isEnd)
    {
      Singleton<CommonRoot>.GetInstance().SetFooterEnable(true);
    }
    else
    {
      this.IbtnSkip.SetActive(true);
      this.IbtnShot.SetActive(false);
      this.IbtnCheckReward.SetActive(false);
      Singleton<CommonRoot>.GetInstance().SetFooterEnable(false);
    }
  }
}
