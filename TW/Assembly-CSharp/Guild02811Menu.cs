// Decompiled with JetBrains decompiler
// Type: Guild02811Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Guild02811Menu : BackButtonMenuBase
{
  private const int GUILD_LIST_MAX = 5;
  [SerializeField]
  private GameObject buildObj;
  [SerializeField]
  private UIButton buildObjButton;
  [SerializeField]
  private GameObject enoughLevel;
  [SerializeField]
  private UILabel enoughLevelLabel;
  [SerializeField]
  private UILabel enoughLevelShadowLabel;
  [SerializeField]
  private GameObject createLimit;
  [SerializeField]
  private NGxScroll scroll;
  private GameObject scrollObj;
  private ModalWindow nowPopup;
  private GameObject searchSettingPopup;
  private GameObject searchNotFoundPopup;
  private GameObject buildSettingPopup;
  private GameObject guildSerachFriendListPopup;
  private GameObject buildSettingCheckPopup;
  private GameObject buildEffectPopup;
  private GuildInfoPopup guildPopup;
  private GuildSetting serchSetting;
  private List<GuildDirectory> guildList;
  private GameObject friendPartsObj;
  private GameObject guildNgWordPopup;

  public GameObject BuildSettingCheckPopup => this.buildSettingCheckPopup;

  public GameObject BuildEffectPopup => this.buildEffectPopup;

  public GuildInfoPopup GuildPopup => this.guildPopup;

  public GameObject GuildNgWordPopup => this.guildNgWordPopup;

  public void Setting(GuildSetting data) => this.serchSetting = data;

  [DebuggerHidden]
  public IEnumerator InitializeAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild02811Menu.\u003CInitializeAsync\u003Ec__Iterator6FF()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void Initialize() => this.DrawGuildList();

  private void CheckStatus()
  {
    int num = 40;
    int? nullable = ((IEnumerable<MasterDataTable.GuildSetting>) MasterData.GuildSettingList).FirstIndexOrNull<MasterDataTable.GuildSetting>((Func<MasterDataTable.GuildSetting, bool>) (x => x.ID == 1));
    if (nullable.HasValue && MasterData.GuildSettingList[nullable.Value].GetIntValue().HasValue)
      num = MasterData.GuildSettingList[nullable.Value].GetIntValue().Value;
    this.enoughLevelLabel.SetTextLocalize(Consts.Format(Consts.GetInstance().Guild0281MENU_ENOUGH_LEVEL, (IDictionary) new Hashtable()
    {
      {
        (object) "enoughLevel",
        (object) num
      }
    }));
    this.enoughLevelShadowLabel.SetTextLocalize(Consts.Format(Consts.GetInstance().Guild0281MENU_ENOUGH_LEVEL, (IDictionary) new Hashtable()
    {
      {
        (object) "enoughLevel",
        (object) num
      }
    }));
    this.buildObjButton.isEnabled = Player.Current.level >= num;
    this.enoughLevel.SetActive(Player.Current.level < num);
    this.createLimit.SetActive(false);
    switch (PlayerAffiliation.Current.status)
    {
      case GuildMembershipStatus.applicant:
        this.buildObjButton.isEnabled = false;
        break;
      case GuildMembershipStatus.membership:
        this.buildObjButton.isEnabled = false;
        if (!SM.GuildSignal.Current.existPlayershipEventType(GuildEventType.apply_applicant) || !Object.op_Equality((Object) this.nowPopup, (Object) null))
          break;
        Singleton<CommonRoot>.GetInstance().isLoading = false;
        Singleton<CommonRoot>.GetInstance().loadingMode = 0;
        this.nowPopup = ModalWindow.Show(Consts.GetInstance().GUILD_APPLY_APPLICANT_TITLE, Consts.GetInstance().GUILD_APPLY_APPLICANT_MESSAGE, (System.Action) (() =>
        {
          Object.DestroyObject((Object) this.nowPopup);
          this.nowPopup = (ModalWindow) null;
          Guild0281Scene.ChangeSceneGuildTop(true);
        }));
        break;
      case GuildMembershipStatus.withdraw:
        this.buildObjButton.isEnabled = false;
        this.createLimit.SetActive(!this.enoughLevel.activeSelf);
        if (!SM.GuildSignal.Current.existGuildEventRelationship(GuildEventType.leave_membership))
          break;
        this.nowPopup = ModalWindow.Show(Consts.GetInstance().GUILD_LEAVE_TITLE, Consts.GetInstance().GUILD_LEAVE_MESSAGE, (System.Action) (() =>
        {
          Singleton<CommonRoot>.GetInstance().SetGuildFooterBadge();
          Object.DestroyObject((Object) this.nowPopup);
          this.nowPopup = (ModalWindow) null;
          SM.GuildSignal.Current.removeRelationshipEvent(GuildEventType.leave_membership);
        }));
        break;
    }
  }

  [DebuggerHidden]
  private IEnumerator ResourceLoad()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild02811Menu.\u003CResourceLoad\u003Ec__Iterator700()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator SearchGuild(System.Action callback = null)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild02811Menu.\u003CSearchGuild\u003Ec__Iterator701()
    {
      callback = callback,
      \u003C\u0024\u003Ecallback = callback,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator SearchBestGuild(System.Action callback = null)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild02811Menu.\u003CSearchBestGuild\u003Ec__Iterator702()
    {
      callback = callback,
      \u003C\u0024\u003Ecallback = callback,
      \u003C\u003Ef__this = this
    };
  }

  public void DrawGuildList()
  {
    this.CheckStatus();
    this.scroll.Clear();
    this.scroll.Reset();
    GameObject obj = Object.Instantiate<GameObject>(this.buildObj);
    obj.SetActive(true);
    this.scroll.Add(obj);
    int? nullable = this.guildList.FirstIndexOrNull<GuildDirectory>((Func<GuildDirectory, bool>) (x => x.guild_id == PlayerAffiliation.Current.guild_id));
    if (nullable.HasValue)
    {
      obj = Object.Instantiate<GameObject>(this.scrollObj);
      Guild02811Scroll component = obj.GetComponent<Guild02811Scroll>();
      if (Object.op_Inequality((Object) component, (Object) null))
      {
        GuildDirectory guild = this.guildList[nullable.Value];
        this.StartCoroutine(component.Initialize(guild, this.guildPopup, true));
      }
      this.scroll.Add(obj);
    }
    this.guildList.ForEach((Action<GuildDirectory>) (x =>
    {
      if (x.guild_id == PlayerAffiliation.Current.guild_id)
        return;
      obj = Object.Instantiate<GameObject>(this.scrollObj);
      Guild02811Scroll component = obj.GetComponent<Guild02811Scroll>();
      if (Object.op_Inequality((Object) component, (Object) null))
        this.StartCoroutine(component.Initialize(x, this.guildPopup, false));
      this.scroll.Add(obj);
    }));
    this.scroll.ResolvePosition();
  }

  public void UpdateApplyGuildLst()
  {
    this.scroll.GridChildren().ForEach<GameObject>((Action<GameObject>) (x =>
    {
      Guild02811Scroll component = x.GetComponent<Guild02811Scroll>();
      if (!Object.op_Inequality((Object) component, (Object) null))
        return;
      component.UpdateApply(PlayerAffiliation.Current.guild.guild_id);
    }));
  }

  [DebuggerHidden]
  public IEnumerator FriendList()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild02811Menu.\u003CFriendList\u003Ec__Iterator703()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void BuildGuildPopupOpen()
  {
    Singleton<PopupManager>.GetInstance().open(this.buildSettingPopup).GetComponent<Guild028301Popup>().Initialize(this);
  }

  public void BuildGuildPopupOpen(GuildSetting setting)
  {
    this.StartCoroutine(Singleton<PopupManager>.GetInstance().open(this.buildSettingPopup).GetComponent<Guild028301Popup>().Initialize(this, setting));
  }

  public void onButtonSetting()
  {
    Singleton<PopupManager>.GetInstance().open(this.searchSettingPopup).GetComponent<Guild028101Popup>().Initialize(this, this.serchSetting);
  }

  public void onButtonUpdate() => this.StartCoroutine(this.GuildListUpdate());

  public void onButtonBuild() => this.BuildGuildPopupOpen();

  public override void onBackButton()
  {
    if (this.IsPushAndSet())
      return;
    this.backScene();
  }

  [DebuggerHidden]
  private IEnumerator GuildListUpdate()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild02811Menu.\u003CGuildListUpdate\u003Ec__Iterator704()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator UpdateHelpers()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Guild02811Menu.\u003CUpdateHelpers\u003Ec__Iterator705 helpersCIterator705 = new Guild02811Menu.\u003CUpdateHelpers\u003Ec__Iterator705();
    return (IEnumerator) helpersCIterator705;
  }

  private void InitWidgetAlpha(MonoBehaviour component)
  {
    if (!Object.op_Inequality((Object) ((Component) component).GetComponent<UIWidget>(), (Object) null))
      return;
    ((Component) component).GetComponent<UIWidget>().alpha = 0.0f;
  }
}
