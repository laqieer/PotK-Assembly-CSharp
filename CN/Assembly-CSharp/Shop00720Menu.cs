// Decompiled with JetBrains decompiler
// Type: Shop00720Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
  private GameObject IbtnCheckReward;
  [SerializeField]
  private GameObject IbtnSkip;
  [SerializeField]
  private Shop00720Menu.SlotButtonSetting[] SlotButtons;
  private GameObject slot;
  private Shop00720EffectController effect;
  private Shop00720Prefabs prefabs;
  private bool isInitalize;
  private bool isWaitForShot = true;
  private int currentSlot;
  private int currentDeck;
  private int currentConsecutive;
  private List<UITweener> tweeners = new List<UITweener>();
  public Touch2NextAuto touchScript;
  private List<SlotModuleSlot> slotModuleSlots = new List<SlotModuleSlot>();

  private void Awake()
  {
    this.touchScript = ((Component) this).gameObject.AddComponent<Touch2NextAuto>();
  }

  [DebuggerHidden]
  public IEnumerator Initialize(Shop00720Scene scene)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop00720Menu.\u003CInitialize\u003Ec__Iterator452()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void SetEventOnClick()
  {
    foreach (Shop00720Menu.SlotButtonSetting slotButton in this.SlotButtons)
    {
      if (!Object.op_Equality((Object) slotButton.Button, (Object) null))
      {
        UIButton component = slotButton.Button.GetComponent<UIButton>();
        if (!Object.op_Equality((Object) component, (Object) null))
        {
          Shop00720Menu.SlotNShot slotNshot = new Shop00720Menu.SlotNShot(this, slotButton.Consecutive);
          EventDelegate.Set(component.onClick, new EventDelegate.Callback(slotNshot.OnClick));
        }
      }
    }
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
    Debug.Log((object) nameof (Ready));
    this.setActiveButtonBack(true);
    foreach (UITweener tweener in this.tweeners)
      tweener.PlayForward();
    this.SetMedalInfo(Player.Current.medal);
    this.slotModuleSlots.Clear();
    foreach (SlotModule slotModule in SMManager.Get<SlotModule[]>())
    {
      if (slotModule != null)
      {
        foreach (SlotModuleSlot slotModuleSlot in slotModule.slot)
        {
          if (slotModuleSlot != null)
            this.slotModuleSlots.Add(slotModuleSlot);
        }
      }
    }
    if (this.slotModuleSlots.Count == 0)
    {
      Debug.LogError((object) "NOTHING SLOTMODULES!!!");
      this.effect.loadState = false;
      this.isWaitForShot = true;
      this.isInitalize = true;
    }
    else
    {
      this.currentDeck = this.slotModuleSlots.First<SlotModuleSlot>().deck_id;
      foreach (Shop00720Menu.SlotButtonSetting slotButton in this.SlotButtons)
      {
        Shop00720Menu.SlotButtonSetting sbs = slotButton;
        SlotModuleSlot slotModuleSlot = this.slotModuleSlots.Find((Predicate<SlotModuleSlot>) (s => sbs.Consecutive == s.roll_count));
        if (sbs.Consecutive == 1 && slotModuleSlot == null)
          slotModuleSlot = this.slotModuleSlots.FirstOrDefault<SlotModuleSlot>();
        if (slotModuleSlot == null)
        {
          sbs.enabled = false;
          sbs.slotId = 0;
        }
        else
        {
          sbs.enabled = true;
          sbs.slotId = slotModuleSlot.id;
        }
        int num1 = (int) (Math.Pow(10.0, (double) sbs.Cost.Length) - 1.0);
        int num2 = !sbs.enabled ? 0 : slotModuleSlot.payment_amount;
        if (num1 < num2)
        {
          sbs.enabled = false;
          num2 = num1;
        }
        int y = sbs.Cost.Length - 1;
        do
        {
          int num3 = (int) Math.Pow(10.0, (double) y);
          sbs.Cost[y].SetSprite(string.Format("num_{0}.png__GUI__007-20_sozai__007-20_sozai_prefab", (object) (num2 / num3)));
          num2 %= num3;
          --y;
        }
        while (y >= 0);
        UIButton component = sbs.Button.GetComponent<UIButton>();
        if (!sbs.enabled || slotModuleSlot.payment_amount > Player.Current.medal)
        {
          component.isEnabled = false;
          foreach (UIWidget paymentAmount in sbs.PaymentAmounts)
            paymentAmount.color = new Color(0.5f, 0.5f, 0.5f);
        }
        else
        {
          component.isEnabled = true;
          foreach (UIWidget paymentAmount in sbs.PaymentAmounts)
            paymentAmount.color = new Color(1f, 1f, 1f);
        }
      }
      this.effect.loadState = false;
      this.isWaitForShot = true;
      this.isInitalize = true;
    }
  }

  private void SetTweeners(List<GameObject> list)
  {
    foreach (GameObject gameObject in list)
      this.tweeners = this.tweeners.Concat<UITweener>((IEnumerable<UITweener>) gameObject.GetComponents<UITweener>()).ToList<UITweener>();
  }

  private void SetMedalInfo(int num)
  {
    this.MedalInfo.GetComponentInChildren<UILabel>().SetTextLocalize(num);
  }

  public void OnIbtnBack()
  {
    if (!this.isWaitForShot || this.IsPushAndSet())
      return;
    Singleton<CommonRoot>.GetInstance().SetFooterEnable(true);
    this.backScene();
  }

  public override void onBackButton() => this.OnIbtnBack();

  public void OnIbtnShotN(int count)
  {
    this.isWaitForShot = false;
    this.currentConsecutive = count;
    this.currentSlot = 0;
    bool flag = false;
    foreach (Shop00720Menu.SlotButtonSetting slotButton in this.SlotButtons)
    {
      if (slotButton.Consecutive == count)
      {
        this.currentSlot = slotButton.slotId;
        flag = true;
        break;
      }
    }
    if (!flag)
    {
      Debug.LogError((object) string.Format("{0}連スロット情報が準備できていません", (object) count));
      this.isWaitForShot = true;
    }
    else
    {
      this.setActiveButtonBack(false);
      this.StartCoroutine(this.MedalPay());
    }
  }

  private void setActiveButtonBack(bool bactive)
  {
    UIButton component = this.IbtnBack.GetComponent<UIButton>();
    if (!Object.op_Inequality((Object) component, (Object) null))
      return;
    component.isEnabled = bactive;
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
    return (IEnumerator) new Shop00720Menu.\u003CMedalPay\u003Ec__Iterator453()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator SetResult(WebAPI.Response.SlotS001MedalPay result)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop00720Menu.\u003CSetResult\u003Ec__Iterator454()
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
    this.StartCoroutine(this.ShowRewards(this.prefabs, this.currentDeck));
  }

  [DebuggerHidden]
  private IEnumerator ShowRewards(Shop00720Prefabs prefabs, int deckID)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop00720Menu.\u003CShowRewards\u003Ec__Iterator455()
    {
      prefabs = prefabs,
      deckID = deckID,
      \u003C\u0024\u003Eprefabs = prefabs,
      \u003C\u0024\u003EdeckID = deckID
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
      this.touchScript.touch2Next.SetActive(false);
      foreach (Shop00720Menu.SlotButtonSetting slotButton in this.SlotButtons)
        slotButton.Button.SetActive(true);
      this.IbtnCheckReward.SetActive(true);
      Singleton<CommonRoot>.GetInstance().SetFooterEnable(true);
    }
    else if (this.effect.Slot_script.isEnd)
    {
      this.touchScript.touch2Next.SetActive(true);
      Singleton<CommonRoot>.GetInstance().SetFooterEnable(true);
    }
    else
    {
      this.IbtnSkip.SetActive(true);
      foreach (Shop00720Menu.SlotButtonSetting slotButton in this.SlotButtons)
        slotButton.Button.SetActive(false);
      this.IbtnCheckReward.SetActive(false);
      Singleton<CommonRoot>.GetInstance().SetFooterEnable(false);
    }
  }

  [Serializable]
  private class SlotButtonSetting
  {
    [NonSerialized]
    public bool enabled;
    [NonSerialized]
    public int slotId;
    public int Consecutive;
    public GameObject Button;
    public UISprite[] Cost;
    public UISprite[] PaymentAmounts;
  }

  private class SlotNShot
  {
    private Shop00720Menu shop_;
    private int count_;

    public SlotNShot(Shop00720Menu shop, int count)
    {
      this.shop_ = shop;
      this.count_ = count;
    }

    public void OnClick() => this.shop_.OnIbtnShotN(this.count_);
  }
}
