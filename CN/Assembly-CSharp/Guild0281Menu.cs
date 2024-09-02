// Decompiled with JetBrains decompiler
// Type: Guild0281Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
public class Guild0281Menu : BackButtonMenuBase
{
  public const int GuildTopAPI = -1;
  public Guild0281Menu.SceneType sceneType = Guild0281Menu.SceneType.NONE;
  public static readonly int GUILDTOP_TO_HQTOP = 2813;
  public static readonly int HQTOP_TO_GUILDTOP = 2831;
  public static readonly int GUILDTOP_TO_OTHER = 28113;
  public static readonly int OTHER_TO_GUILDTOP = 28112;
  public static readonly int HQTOP_TO_OTHER = 28313;
  public static readonly int OTHER_TO_HQTOP = 28312;
  public static readonly int IBTN_TWEENGROUP;
  private UITweener[] tweens;
  private WebAPI.Response.GuildTop resGuildTopData;
  [SerializeField]
  private Transform guildBasePos;
  private GameObject guildBasePrefab;
  private Guild0282GuildBase guildBase;
  [SerializeField]
  private UI2DSprite guildTitleImage;
  private Future<Sprite> futureGuildTitleImage;
  [SerializeField]
  private UILabel guildName;
  [SerializeField]
  private UISprite guildRank1;
  [SerializeField]
  private UISprite guildRank10;
  [SerializeField]
  private UILabel nextExp;
  [SerializeField]
  private NGTweenGaugeScale expGauge;
  [SerializeField]
  private UILabel currentMember;
  [SerializeField]
  private UILabel maxMember;
  [SerializeField]
  private UILabel ranking;
  [SerializeField]
  private UILabel win;
  [SerializeField]
  private UILabel lose;
  [SerializeField]
  private UILabel draw;
  [SerializeField]
  private UILabel role;
  [SerializeField]
  private GuildRegistration guild;
  [SerializeField]
  private GameObject newGift;
  [SerializeField]
  private GameObject newMenu;
  [SerializeField]
  private GameObject bankBadge;
  private GuildInfoPopup guildInfoPopup;
  private GuildMemberObject guildMemberPopup;
  private UI3DModel UIModel;
  [SerializeField]
  private GameObject Model;
  public CircularMotionPositionSet CirculButton;
  [SerializeField]
  protected MypageSlidePanelDragged centerObject;
  private EventInfo eventInfo;
  [SerializeField]
  private GameObject slc_Badge_bikkuri;
  [SerializeField]
  private Guild0281GuildMapButton guildMapButton;
  [SerializeField]
  private Guild0281HuntingButton huntingButton;
  private DateTime serverTime;
  private GameObject hqMainFacilityLevelupAnimObj;
  private GameObject guildBaseLevelupObj;
  private GameObject guildTopLevelupAnimObj;
  [SerializeField]
  private Guild0281FacilityInfoController facilityInfoController;
  [SerializeField]
  private GameObject hqButton;
  private GuildImageCache guildImageCache;
  private GuildImageCache guildImageCacheLevelUp;

  [DebuggerHidden]
  private IEnumerator ResourceLoadGuild(GuildRegistration data)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0281Menu.\u003CResourceLoadGuild\u003Ec__Iterator68D()
    {
      data = data,
      \u003C\u0024\u003Edata = data,
      \u003C\u003Ef__this = this
    };
  }

  private bool JudgeLevelUpEffect()
  {
    return !(Persist.guildTopLevel.Data.guildID != PlayerAffiliation.Current.guild.guild_id) && Persist.guildTopLevel.Data.level < PlayerAffiliation.Current.guild.appearance.level;
  }

  private void SetLocalDataGuildLevel()
  {
    Persist.guildTopLevel.Data.guildID = PlayerAffiliation.Current.guild.guild_id;
    Persist.guildTopLevel.Data.level = PlayerAffiliation.Current.guild.appearance.level;
  }

  [DebuggerHidden]
  public IEnumerator InitializeAsync(Guild0281Menu.SceneType type, WebAPI.Response.GuildTop data = null)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0281Menu.\u003CInitializeAsync\u003Ec__Iterator68E()
    {
      data = data,
      \u003C\u0024\u003Edata = data,
      \u003C\u003Ef__this = this
    };
  }

  public void InitializeGuildTop()
  {
    this.sceneType = Guild0281Menu.SceneType.GuildTop;
    this.SetGuildButton();
    this.SetHuntingButton();
    this.JogDialSetting();
    this.SetGuildData(this.guild);
    this.hqButton.SetActive(PlayerAffiliation.Current.guild.appearance.GuildHQOpen());
    if (this.JudgeLevelUpEffect())
      this.StartCoroutine(this.PlayGuildTopLevelUpEffect());
    this.SetLocalDataGuildLevel();
  }

  public void InitializeHQTop()
  {
    this.sceneType = Guild0281Menu.SceneType.HQTop;
    this.SetGuildData(this.guild);
  }

  [DebuggerHidden]
  public IEnumerator PlayGuildTopLevelUpEffect()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0281Menu.\u003CPlayGuildTopLevelUpEffect\u003Ec__Iterator68F()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator showLevelupAnim(int level, GameObject guildBase, GameObject guildBaseEff)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0281Menu.\u003CshowLevelupAnim\u003Ec__Iterator690()
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

  private void SetGuildButton() => this.guildMapButton.Initialize();

  private void SetHuntingButton()
  {
    int? nullable = ((IEnumerable<EventInfo>) this.resGuildTopData.event_infos).FirstIndexOrNull<EventInfo>((Func<EventInfo, bool>) (x => x.IsGuild()));
    if (nullable.HasValue)
    {
      this.eventInfo = this.resGuildTopData.event_infos[nullable.Value];
      this.huntingButton.Initialize(this.eventInfo, this.serverTime);
    }
    else
      this.huntingButton.EventClose();
  }

  public void onEndScene()
  {
    this.EndAnimation();
    this.facilityInfoController.ClearFacilityLevelUpEffects();
  }

  public void EndAnimation()
  {
    this.CirculButton.condition = CircularMotionPositionSet.CirculCondition.START;
    switch (this.sceneType)
    {
      case Guild0281Menu.SceneType.GuildTop:
        this.PlayTweens(MypageMenu.END_TWEEN_GROUP_JOGDIAL);
        this.PlayTweens(Guild0281Menu.GUILDTOP_TO_OTHER);
        break;
      case Guild0281Menu.SceneType.HQTop:
        this.PlayTweens(Guild0281Menu.HQTOP_TO_OTHER);
        break;
    }
  }

  public void onDestroySceneAsync()
  {
  }

  public void HQLevelUp(GuildBaseType type) => this.guildBase.HQLevelUp(type, this.guildImageCache);

  private void SetGuildData(GuildRegistration data)
  {
    if (this.futureGuildTitleImage != null && Object.op_Inequality((Object) this.futureGuildTitleImage.Result, (Object) null))
      this.guildTitleImage.sprite2D = this.futureGuildTitleImage.Result;
    if (Object.op_Inequality((Object) this.guildBase, (Object) null))
      Object.Destroy((Object) ((Component) this.guildBase).gameObject);
    this.guildBase = this.guildBasePrefab.Clone(((Component) this.guildBasePos).transform).GetComponent<Guild0282GuildBase>();
    ((Collider) ((Component) this.guildBase).GetComponent<BoxCollider>()).enabled = false;
    this.guildBase.SetSprite(data.appearance, this.guildImageCache, this.hqMainFacilityLevelupAnimObj);
    this.guildName.SetTextLocalize(data.guild_name);
    if (data.appearance.level / 10 == 0)
    {
      ((Component) this.guildRank1).gameObject.SetActive(false);
      ((Component) this.guildRank10).gameObject.SetActive(true);
      this.guildRank10.SetSprite(string.Format("slc_text_glv_number{0}.png__GUI__guild_common__guild_common_prefab", (object) (data.appearance.level % 10)));
    }
    else
    {
      ((Component) this.guildRank10).gameObject.SetActive(true);
      this.guildRank10.SetSprite(string.Format("slc_text_glv_number{0}.png__GUI__guild_common__guild_common_prefab", (object) (data.appearance.level / 10)));
      this.guildRank1.SetSprite(string.Format("slc_text_glv_number{0}.png__GUI__guild_common__guild_common_prefab", (object) (data.appearance.level % 10)));
    }
    this.nextExp.SetTextLocalize(Consts.Format(Consts.GetInstance().Guild0281MENU_NEXTEXP, (IDictionary) new Hashtable()
    {
      {
        (object) "nextExp",
        (object) data.appearance.experience_next
      }
    }));
    if (data.appearance.experience_next == 0)
      this.expGauge.setValue(0, 1);
    else
      this.expGauge.setValue(data.appearance.experience, data.appearance.experience + data.appearance.experience_next);
    this.currentMember.SetTextLocalize(Consts.Format(Consts.GetInstance().POPUP_028_1_1_4_CURRENT_MEMBER, (IDictionary) new Hashtable()
    {
      {
        (object) "currentMember",
        (object) data.appearance.membership_num
      }
    }));
    this.maxMember.SetTextLocalize(Consts.Format(Consts.GetInstance().POPUP_028_1_1_4_MAX_MEMBER, (IDictionary) new Hashtable()
    {
      {
        (object) "maxMember",
        (object) data.appearance.membership_capacity
      }
    }));
    this.ranking.SetTextLocalize(data.appearance.ranking_no);
    this.win.SetTextLocalize(data.appearance.win_num);
    this.lose.SetTextLocalize(data.appearance.lose_num);
    this.draw.SetTextLocalize(data.appearance.draw_num);
    this.role.SetTextLocalize(PlayerAffiliation.Current.role_name.name);
    this.SetBudgeForInitialize();
  }

  public void JogDialSetting()
  {
    this.CirculButton.Init(this.centerObject);
    this.CirculButton.condition = CircularMotionPositionSet.CirculCondition.START;
    this.PlayTweens(MypageMenu.START_TWEEN_GROUP_JOGDIAL);
  }

  public void onButtonGuildAbout()
  {
    if (this.IsPushAndSet())
      return;
    GameObject prefab = this.guildInfoPopup.guildInfoPopup.Clone();
    prefab.SetActive(false);
    prefab.GetComponent<Guild028114Popup>().Initialize(this.guildInfoPopup);
    prefab.SetActive(true);
    Singleton<PopupManager>.GetInstance().open(prefab, isCloned: true);
  }

  public void onButonGuildTop()
  {
    if (this.isAnimation())
      return;
    this.PlayTweens(MypageMenu.START_TWEEN_GROUP_JOGDIAL);
    Guild0281Scene.ChangeSceneGuildTop(menu: this);
  }

  public void onButonHQTop()
  {
    if (this.isAnimation())
      return;
    this.PlayTweens(MypageMenu.END_TWEEN_GROUP_JOGDIAL);
    Guild0281Scene.ChangeSceneHQTop(menu: this);
  }

  public void onButonGuildGift()
  {
    if (this.IsPushAndSet())
      return;
    Guild0286Scene.ChangeScene();
  }

  public void onButtonGuildBank()
  {
    if (this.IsPushAndSet())
      return;
    Guild0287Scene.ChangeScene();
  }

  public void onButtonGuildMenu()
  {
    if (this.IsPushAndSet())
      return;
    Guild0283Scene.ChangeScene();
  }

  public void onButtonGuildMap()
  {
    if (this.IsPushAndSet())
      return;
    NGSoundManager instance = Singleton<NGSoundManager>.GetInstance();
    if (Object.op_Inequality((Object) instance, (Object) null))
      instance.playSE("SE_1002");
    this.centerObject = ((Component) this.guildMapButton).GetComponent<MypageSlidePanelDragged>();
    Guild0282Scene.ChangeScene();
  }

  public void onButtonGuildHunting()
  {
    if (this.IsPushAndSet())
      return;
    NGSoundManager instance = Singleton<NGSoundManager>.GetInstance();
    if (Object.op_Inequality((Object) instance, (Object) null))
      instance.playSE("SE_1002");
    this.centerObject = ((Component) this.huntingButton).GetComponent<MypageSlidePanelDragged>();
    Quest00230Scene.ChangeScene(true, this.eventInfo);
  }

  public void onButtonDrawMyGuild()
  {
    if (this.IsPushAndSet())
      return;
    this.StartCoroutine(this.ShowMyMemberList());
  }

  [DebuggerHidden]
  private IEnumerator ShowMyMemberList()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0281Menu.\u003CShowMyMemberList\u003Ec__Iterator691()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator SetCharacterModel()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0281Menu.\u003CSetCharacterModel\u003Ec__Iterator692()
    {
      \u003C\u003Ef__this = this
    };
  }

  protected virtual void OnDisable()
  {
    if (Object.op_Inequality((Object) this.UIModel, (Object) null))
    {
      if (Object.op_Inequality((Object) this.UIModel.model_creater_, (Object) null))
        this.UIModel.DestroyModelCamera();
      if (Object.op_Inequality((Object) ((Component) this.UIModel).gameObject, (Object) null) && ((Object) ((Component) this.UIModel).gameObject).name == "slc_3DModel(Clone)")
        Object.Destroy((Object) ((Component) this.UIModel).gameObject);
    }
    ModelUnits.Instance.DestroyModelUnits();
  }

  public override void onBackButton()
  {
    if (Singleton<PopupManager>.GetInstance().isOpen)
      Singleton<PopupManager>.GetInstance().dismiss();
    else if (Singleton<CommonRoot>.GetInstance().guildChatManager.GetCurrentGuildChatStatus() == GuildChatManager.GuildChatStatus.DetailedView)
      Singleton<CommonRoot>.GetInstance().guildChatManager.CloseDetailedChat();
    else if (this.sceneType == Guild0281Menu.SceneType.HQTop)
      this.onButonGuildTop();
    else
      MypageScene.ChangeScene(false);
  }

  protected override void Update()
  {
    base.Update();
    this.SetBudgeForUpdate();
  }

  private void SetBudgeForInitialize()
  {
    if (Persist.guildSetting.Exists)
    {
      GuildRole? role1 = PlayerAffiliation.Current.role;
      if ((role1.GetValueOrDefault() != GuildRole.master ? 0 : (role1.HasValue ? 1 : 0)) == 0)
      {
        GuildRole? role2 = PlayerAffiliation.Current.role;
        if ((role2.GetValueOrDefault() != GuildRole.sub_master ? 0 : (role2.HasValue ? 1 : 0)) == 0)
        {
          this.newMenu.SetActive(false);
          goto label_5;
        }
      }
      this.newMenu.SetActive(GuildUtil.getBadgeState(GuildUtil.GuildBadgeInfoType.newApplicant));
label_5:
      if (GuildUtil.getBadgeState(GuildUtil.GuildBadgeInfoType.changeRole) || GuildUtil.getBadgeState(GuildUtil.GuildBadgeInfoType.newMember))
        this.slc_Badge_bikkuri.SetActive(true);
      if (GuildUtil.getGuildMemberNum() != PlayerAffiliation.Current.guild.memberships.Length)
      {
        if (!this.slc_Badge_bikkuri.activeSelf && GuildUtil.getGuildMemberNum() != -1)
          this.slc_Badge_bikkuri.SetActive(true);
        GuildUtil.setGuildMemberNum(PlayerAffiliation.Current.guild.memberships.Length);
      }
      this.newGift.SetActive(GuildUtil.getBadgeState(GuildUtil.GuildBadgeInfoType.newGift));
      this.bankBadge.SetActive(false);
      GuildUtil.setBadgeState(GuildUtil.GuildBadgeInfoType.startHuntingEvent, false);
      GuildUtil.setBadgeState(GuildUtil.GuildBadgeInfoType.receiveHuntingReward, false);
      Persist.guildSetting.Flush();
      Singleton<CommonRoot>.GetInstance().DisableGuildFooterBadge();
    }
    SM.GuildSignal.Current.removePlayershipEvent(GuildEventType.apply_applicant);
  }

  private void SetBudgeForUpdate()
  {
    if (!Persist.guildSetting.Exists)
      return;
    GuildRole? role1 = PlayerAffiliation.Current.role;
    if ((role1.GetValueOrDefault() != GuildRole.master ? 0 : (role1.HasValue ? 1 : 0)) == 0)
    {
      GuildRole? role2 = PlayerAffiliation.Current.role;
      if ((role2.GetValueOrDefault() != GuildRole.sub_master ? 0 : (role2.HasValue ? 1 : 0)) == 0)
      {
        this.newMenu.SetActive(false);
        goto label_5;
      }
    }
    this.newMenu.SetActive(GuildUtil.getBadgeState(GuildUtil.GuildBadgeInfoType.newApplicant));
label_5:
    this.newGift.SetActive(GuildUtil.getBadgeState(GuildUtil.GuildBadgeInfoType.newGift));
  }

  public void PlayTweens(int groupID)
  {
    if (this.tweens == null)
      this.tweens = ((IEnumerable<UITweener>) ((Component) this).GetComponentsInChildren<UITweener>()).Where<UITweener>((Func<UITweener, bool>) (x => x.tweenGroup != Guild0281Menu.IBTN_TWEENGROUP)).ToArray<UITweener>();
    NGTween.playTweens(this.tweens, groupID);
  }

  private bool isAnimation()
  {
    if (this.tweens == null)
      this.tweens = ((IEnumerable<UITweener>) ((Component) this).GetComponentsInChildren<UITweener>()).Where<UITweener>((Func<UITweener, bool>) (x => x.tweenGroup != Guild0281Menu.IBTN_TWEENGROUP)).ToArray<UITweener>();
    return ((IEnumerable<UITweener>) this.tweens).Where<UITweener>((Func<UITweener, bool>) (x => ((Behaviour) x).isActiveAndEnabled)).ToArray<UITweener>().Length != 0;
  }

  public enum SceneType
  {
    GuildTop,
    HQTop,
    NONE,
  }
}
