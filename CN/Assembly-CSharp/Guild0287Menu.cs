// Decompiled with JetBrains decompiler
// Type: Guild0287Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Guild0287Menu : GuildBankDonateListBase
{
  private const int Width = 616;
  private const int Height = 156;
  private const int ColumnValue = 1;
  private const int RowValue = 8;
  private const int ScreenValue = 3;
  private GuildBank bank;
  private GuildBank bankBefore;
  private GuildBank bankAfter;
  private GameObject donateResultPopup;
  private GameObject donateListPrefab;
  private GameObject levelUpPrefab;
  private GuildBankDonationInfo donationInfo;
  [SerializeField]
  private UILabel sceneTitle;
  [SerializeField]
  private UISprite lvGauge;
  [SerializeField]
  private UISprite lv10;
  [SerializeField]
  private UISprite lv1;
  [SerializeField]
  private UILabel guild_zeny;
  [SerializeField]
  private UILabel exp_next_level;
  [SerializeField]
  private UILabel guildBankMessage;
  [SerializeField]
  private GameObject dir_donate_done;
  [SerializeField]
  private UILabel txt_donate_done;
  [SerializeField]
  private List<Guild0287Menu.RateButton> rateBtns;
  private int currentScale;
  private GuildImageCache guildImageCache;
  private int[] level_cmp;

  [DebuggerHidden]
  private IEnumerator ResourceLoad()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0287Menu.\u003CResourceLoad\u003Ec__Iterator717()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void SetAppearance()
  {
    this.sceneTitle.SetTextLocalize(Consts.GetInstance().GUILD_BANK_TOP_TITLE);
    this.guildBankMessage.SetTextLocalize(this.bank.message);
    this.guild_zeny.SetTextLocalize(this.bank.money);
    this.SetGuildLevelLabel(this.bank.level);
    this.SetExperienceNextLabel(this.bank.experience_next);
    float num = 0.0f;
    if (this.bank.experience_next > 0)
      num = (float) this.bank.experience / (float) (this.bank.experience + this.bank.experience_next);
    ((Component) this.lvGauge).transform.localScale = new Vector3(num, 1f, 1f);
    this.dir_donate_done.SetActive(!this.bank.available || !this.bank.released);
    if (!this.bank.released)
      this.txt_donate_done.SetTextLocalize(Consts.GetInstance().GUILD_BANK_DONATE_UNAVAILABLE_JOIN_GUILD);
    else
      this.txt_donate_done.SetTextLocalize(Consts.GetInstance().GUILD_BANK_DONATE_UNAVAILABLE);
    this.SetRateButton();
    this.SetRateButtonColor();
  }

  private void SetGuildLevelLabel(int level)
  {
    if (level < 10)
    {
      ((Component) this.lv1).gameObject.SetActive(false);
      ((Component) this.lv10).gameObject.SetActive(true);
      this.lv10.SetSprite(string.Format("slc_text_glv_number{0}.png__GUI__guild_common__guild_common_prefab", (object) level));
    }
    else
    {
      ((Component) this.lv1).gameObject.SetActive(true);
      ((Component) this.lv10).gameObject.SetActive(true);
      this.lv1.SetSprite(string.Format("slc_text_glv_number{0}.png__GUI__guild_common__guild_common_prefab", (object) (level % 10)));
      this.lv10.SetSprite(string.Format("slc_text_glv_number{0}.png__GUI__guild_common__guild_common_prefab", (object) (level / 10)));
    }
  }

  private void SetExperienceNextLabel(int expNext)
  {
    this.exp_next_level.SetTextLocalize(Consts.Format(Consts.GetInstance().GUILD_BANK_EXP_NEXT_LEVEL, (IDictionary) new Hashtable()
    {
      {
        (object) "exp",
        (object) expNext
      }
    }));
  }

  private void SetRateButton()
  {
    for (int index = 0; index < this.bank.scales.Length; ++index)
    {
      if (this.rateBtns.Count <= index)
        break;
      if (!this.bank.available || !this.bank.released)
      {
        ((Component) ((Component) this.rateBtns[index].btn).transform.parent).gameObject.SetActive(false);
      }
      else
      {
        ((Component) ((Component) this.rateBtns[index].btn).transform.parent).gameObject.SetActive(true);
        GuildInvestScale scale1 = this.bank.scales[index];
        int scale = scale1.scale;
        this.rateBtns[index].Scale = scale;
        this.rateBtns[index].btn.isEnabled = this.bank.level >= scale1.release_level;
        this.rateBtns[index].btn.onClick.Clear();
        this.rateBtns[index].btn.onClick.Add(new EventDelegate((EventDelegate.Callback) (() => this.onRateButton(scale))));
        if (this.rateBtns[index].btn.isEnabled)
        {
          if (Object.op_Inequality((Object) this.rateBtns[index].dir_open_condition, (Object) null))
            this.rateBtns[index].dir_open_condition.SetActive(false);
        }
        else
        {
          if (Object.op_Inequality((Object) this.rateBtns[index].dir_open_condition, (Object) null))
            this.rateBtns[index].dir_open_condition.SetActive(true);
          if (Object.op_Inequality((Object) this.rateBtns[index].txt_crest_guild_condition, (Object) null))
            this.rateBtns[index].txt_crest_guild_condition.SetTextLocalize(Consts.Format(Consts.GetInstance().GUILD_BANK_RATEBUTTON_RELEASE, (IDictionary) new Hashtable()
            {
              {
                (object) "level",
                (object) scale1.release_level
              }
            }));
          if (Object.op_Inequality((Object) this.rateBtns[index].txt_crest_guild_condition_shadow, (Object) null))
            this.rateBtns[index].txt_crest_guild_condition_shadow.SetTextLocalize(Consts.Format(Consts.GetInstance().GUILD_BANK_RATEBUTTON_RELEASE, (IDictionary) new Hashtable()
            {
              {
                (object) "level",
                (object) scale1.release_level
              }
            }));
        }
      }
    }
  }

  public void SetRateButtonColor()
  {
    for (int index = 0; index < this.rateBtns.Count; ++index)
    {
      if (this.rateBtns[index].btn.isEnabled)
        ((Component) this.rateBtns[index].btn).GetComponent<UIWidget>().color = this.currentScale != this.rateBtns[index].Scale ? new Color(0.5f, 0.5f, 0.5f) : new Color(1f, 1f, 1f);
    }
  }

  [DebuggerHidden]
  private IEnumerator ExecuteDonation(GuildMoneyRate moneyRate)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0287Menu.\u003CExecuteDonation\u003Ec__Iterator718()
    {
      moneyRate = moneyRate,
      \u003C\u0024\u003EmoneyRate = moneyRate,
      \u003C\u003Ef__this = this
    };
  }

  private void ShowResultPopup(GuildBankDonationInfo info)
  {
    GameObject prefab = this.donateResultPopup.Clone();
    prefab.GetComponent<GuildBankDonateResultPopup>().Initialize(info, (System.Action) (() => this.StartCoroutine(this.StartAnimation())));
    Singleton<PopupManager>.GetInstance().open(prefab, isCloned: true);
  }

  [DebuggerHidden]
  private IEnumerator StartAnimation()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0287Menu.\u003CStartAnimation\u003Ec__Iterator719()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator showLevelupAnim(int level, GameObject guildBase, GameObject guildBaseEff)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0287Menu.\u003CshowLevelupAnim\u003Ec__Iterator71A()
    {
      level = level,
      guildBase = guildBase,
      guildBaseEff = guildBaseEff,
      \u003C\u0024\u003Elevel = level,
      \u003C\u0024\u003EguildBase = guildBase,
      \u003C\u0024\u003EguildBaseEff = guildBaseEff,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  protected override IEnumerator CreateScroll(int info_index, int bar_index)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0287Menu.\u003CCreateScroll\u003Ec__Iterator71B()
    {
      bar_index = bar_index,
      info_index = info_index,
      \u003C\u0024\u003Ebar_index = bar_index,
      \u003C\u0024\u003Einfo_index = info_index,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator InitDonateScroll(GuildMoneyRate[] tokens)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0287Menu.\u003CInitDonateScroll\u003Ec__Iterator71C()
    {
      tokens = tokens,
      \u003C\u0024\u003Etokens = tokens,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator InitializeAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0287Menu.\u003CInitializeAsync\u003Ec__Iterator71D()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void Initialize()
  {
    if (this.bank == null)
      return;
    Singleton<CommonRoot>.GetInstance().isLoading = false;
  }

  private void onRateButton(int scale)
  {
    if (scale == this.currentScale)
      return;
    for (int index = 0; index < this.allDonateBar.Count; ++index)
      this.allDonateBar[index].SetAppearance(scale);
    this.currentScale = scale;
    this.SetRateButtonColor();
  }

  public void onHowtoButton()
  {
    if (this.IsPushAndSet())
      return;
    Guild02871Scene.ChangeScene(true);
  }

  protected override void Update()
  {
    base.Update();
    this.ScrollUpdate();
  }

  public override void onBackButton()
  {
    if (this.IsPushAndSet())
      return;
    this.backScene();
  }

  [Serializable]
  public class RateButton
  {
    private int scale;
    public UIButton btn;
    public GameObject dir_open_condition;
    public UILabel txt_crest_guild_condition;
    public UILabel txt_crest_guild_condition_shadow;

    public int Scale
    {
      set => this.scale = value;
      get => this.scale;
    }
  }
}
