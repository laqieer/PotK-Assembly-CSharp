// Decompiled with JetBrains decompiler
// Type: CommonFooter
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using MasterDataTable;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class CommonFooter : CommonFooterBase
{
  private GameObject coming_soon_Popup;
  [SerializeField]
  private GameObject footerMissionBadge;
  private Modified<Player> modifiedPlayer;
  private Modified<SM.GuildSignal> modifiedGuildSignal;

  private void Start() => this.modifiedGuildSignal = SMManager.Observe<SM.GuildSignal>();

  public new void setDisableColor()
  {
    foreach (UIWidget componentsInChild in ((Component) this).gameObject.GetComponentsInChildren<UISprite>(true))
      componentsInChild.color = new Color(0.4117647f, 0.4117647f, 0.4117647f);
  }

  public new void resetDisableColor()
  {
    foreach (UIWidget componentsInChild in ((Component) this).gameObject.GetComponentsInChildren<UISprite>(true))
      componentsInChild.color = Color.white;
  }

  public void onButtonMypage()
  {
    if (!Singleton<NGSceneManager>.GetInstance().isSceneInitialized)
      return;
    if (Singleton<NGSceneManager>.GetInstance().sceneName == "mypage")
    {
      MypageScene sceneBase = Singleton<NGSceneManager>.GetInstance().sceneBase as MypageScene;
      if (Object.op_Inequality((Object) sceneBase, (Object) null) && sceneBase.isAnimePlaying)
        return;
    }
    Singleton<NGSceneManager>.GetInstance().sceneBase.IsPush = true;
    Singleton<NGGameDataManager>.GetInstance().lastReferenceUnitID = -1;
    Singleton<NGGameDataManager>.GetInstance().lastReferenceUnitIndex = -1;
    Singleton<NGSceneManager>.GetInstance().destroyLoadedScenes();
    Singleton<NGSceneManager>.GetInstance().clearStack();
    MypageScene.ChangeScene(false);
  }

  public void onButtonUnit()
  {
    Singleton<NGSceneManager>.GetInstance().sceneBase.IsPush = true;
    Singleton<NGSceneManager>.GetInstance().destroyLoadedScenes();
    Singleton<NGGameDataManager>.GetInstance().lastReferenceUnitID = -1;
    Singleton<NGGameDataManager>.GetInstance().lastReferenceUnitIndex = -1;
    Unit004topScene.ChangeScene(false);
  }

  public void onButtonWeapon()
  {
    Singleton<NGSceneManager>.GetInstance().sceneBase.IsPush = true;
    Singleton<NGSceneManager>.GetInstance().destroyLoadedScenes();
    Singleton<NGGameDataManager>.GetInstance().lastReferenceUnitID = -1;
    Singleton<NGGameDataManager>.GetInstance().lastReferenceUnitIndex = -1;
    this.changeScene("bugu005_1", false, true);
  }

  public void onButtonGacha()
  {
    Singleton<NGSceneManager>.GetInstance().sceneBase.IsPush = true;
    Singleton<NGSceneManager>.GetInstance().destroyLoadedScenes();
    Singleton<NGGameDataManager>.GetInstance().lastReferenceUnitID = -1;
    Singleton<NGGameDataManager>.GetInstance().lastReferenceUnitIndex = -1;
    Singleton<NGSceneManager>.GetInstance().clearStack();
    if (!Singleton<NGSceneManager>.GetInstance().changeScene("gacha006_3"))
      ;
  }

  public void onButtonShop()
  {
    Singleton<NGSceneManager>.GetInstance().sceneBase.IsPush = true;
    Singleton<NGSceneManager>.GetInstance().destroyLoadedScenes();
    Singleton<NGGameDataManager>.GetInstance().lastReferenceUnitID = -1;
    Singleton<NGGameDataManager>.GetInstance().lastReferenceUnitIndex = -1;
    Singleton<NGSceneManager>.GetInstance().clearStack();
    Shop0071Scene.changeScene(false, true);
  }

  public void onButtonMission()
  {
    Singleton<NGSceneManager>.GetInstance().sceneBase.IsPush = true;
    Singleton<NGSceneManager>.GetInstance().destroyLoadedScenes();
    Singleton<NGGameDataManager>.GetInstance().lastReferenceUnitID = -1;
    Singleton<NGGameDataManager>.GetInstance().lastReferenceUnitIndex = -1;
    DailyMission0272Scene.ChangeScene0272(false);
  }

  public void onButtonGuild()
  {
    Singleton<NGSceneManager>.GetInstance().sceneBase.IsPush = true;
    Singleton<NGSceneManager>.GetInstance().destroyLoadedScenes();
    Singleton<NGGameDataManager>.GetInstance().lastReferenceUnitID = -1;
    Singleton<NGGameDataManager>.GetInstance().lastReferenceUnitIndex = -1;
    Singleton<NGSceneManager>.GetInstance().clearStack();
    this.StartCoroutine(this.ChangeSceneGuild());
  }

  [DebuggerHidden]
  private IEnumerator ChangeSceneGuild()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new CommonFooter.\u003CChangeSceneGuild\u003Ec__IteratorB3B()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void Update()
  {
    if (this.modifiedPlayer == null)
    {
      this.modifiedPlayer = SMManager.Observe<Player>();
      this.modifiedPlayer.NotifyChanged();
    }
    if (this.modifiedPlayer.IsChangedOnce())
      this.footerMissionBadge.SetActive(this.modifiedPlayer.Value.is_open_mission);
    if (this.modifiedGuildSignal == null || Singleton<NGGameDataManager>.GetInstance().IsEarth || SM.GuildSignal.Current == null || !this.modifiedGuildSignal.IsChangedOnce())
      return;
    if (SM.GuildSignal.Current.existGvgEvent(GuildEventType.change_map_info) && Singleton<NGSceneManager>.GetInstance().sceneName == "guild028_2" && Object.op_Inequality((Object) Singleton<NGSceneManager>.GetInstance().sceneBase, (Object) null))
    {
      Guild0282Menu component = ((Component) Singleton<NGSceneManager>.GetInstance().sceneBase).GetComponent<Guild0282Menu>();
      if (Object.op_Inequality((Object) component, (Object) null))
      {
        GuildEventGvg currentGvgEvent = SM.GuildSignal.Current.getCurrentGvgEvent(GuildEventType.change_map_info);
        PlayerAffiliation.Current.guild = currentGvgEvent.guild;
        this.StartCoroutine(component.MapReload(currentGvgEvent));
      }
    }
    this.SetGuildBadge();
  }

  private void SetGuildBadge()
  {
    bool flg = false;
    bool flag1 = false;
    if (PlayerAffiliation.Current == null)
      return;
    if (!Persist.guildSetting.Exists)
    {
      Persist.guildSetting.Data.reset();
      Persist.guildSetting.Flush();
    }
    if (!Persist.guildSetting.Exists)
      Singleton<CommonRoot>.GetInstance().SetGuildFooterBadge();
    else if (!PlayerAffiliation.Current.isGuildMember())
    {
      if (SM.GuildSignal.Current.existRelationshipEventWithoutMyself(GuildEventType.leave_membership))
        Singleton<CommonRoot>.GetInstance().SetGuildFooterBadge(true);
      else
        Singleton<CommonRoot>.GetInstance().SetGuildFooterBadge();
      Singleton<CommonRoot>.GetInstance().SetGuildFooterBadge(GuildUtil.FooterGuildBadge.label, false);
      if (!Persist.gvgBattleEnvironment.Exists)
        return;
      Persist.gvgBattleEnvironment.Delete();
    }
    else
    {
      bool flag2 = Singleton<NGSceneManager>.GetInstance().sceneName.Equals("guild028_1");
      bool flag3 = Object.op_Inequality((Object) Singleton<NGSceneManager>.GetInstance().sceneBase, (Object) null) && Singleton<NGSceneManager>.GetInstance().sceneBase.currentSceneGuildChatDisplayingStatus == NGSceneBase.GuildChatDisplayingStatus.Opened;
      GuildRole? role1 = PlayerAffiliation.Current.role;
      if ((role1.GetValueOrDefault() != GuildRole.master ? 0 : (role1.HasValue ? 1 : 0)) == 0)
      {
        GuildRole? role2 = PlayerAffiliation.Current.role;
        if ((role2.GetValueOrDefault() != GuildRole.sub_master ? 0 : (role2.HasValue ? 1 : 0)) == 0)
        {
          GuildUtil.setBadgeState(GuildUtil.GuildBadgeInfoType.newApplicant, false);
          GuildUtil.setBadgeState(GuildUtil.GuildBadgeInfoType.newMember, false);
          goto label_21;
        }
      }
      if (SM.GuildSignal.Current.existNewApplicant())
      {
        GuildUtil.setBadgeState(GuildUtil.GuildBadgeInfoType.newApplicant, true);
        flag1 = true;
      }
      if (PlayerAffiliation.Current.guild.auto_approval.auto_approval && SM.GuildSignal.Current.existNewMember())
      {
        GuildUtil.setBadgeState(GuildUtil.GuildBadgeInfoType.newMember, true);
        flag1 = true;
      }
label_21:
      if (!flag2 && SM.GuildSignal.Current.existPlayershipEventType(GuildEventType.apply_applicant))
        flg = true;
      if (((IEnumerable<GuildEventGift>) SM.GuildSignal.Current.gift_events).Where<GuildEventGift>((Func<GuildEventGift, bool>) (x => x.event_type == GuildEventType.incoming_gift)).FirstOrDefault<GuildEventGift>() != null)
      {
        GuildUtil.setBadgeState(GuildUtil.GuildBadgeInfoType.newGift, true);
        flag1 = true;
      }
      if (!flag2 && SM.GuildSignal.Current.existPayloadEvent(GuildEventType.level_up))
      {
        GuildUtil.setBadgeState(GuildUtil.GuildBadgeInfoType.guildLevelup, true);
        flag1 = true;
      }
      if (!flag2 && SM.GuildSignal.Current.existBaseEvent(GuildEventType.base_rank_up))
      {
        GuildUtil.setBadgeState(GuildUtil.GuildBadgeInfoType.baseRankUp, true);
        flag1 = true;
      }
      if (!flag3 && SM.GuildSignal.Current.existChatEvent(GuildEventType.post_new_chat))
      {
        GuildUtil.setBadgeState(GuildUtil.GuildBadgeInfoType.postNewChat, true);
        flag1 = true;
      }
      if (GuildUtil.getBadgeState(GuildUtil.GuildBadgeInfoType.newApplicant) || !flag2 && GuildUtil.getBadgeState(GuildUtil.GuildBadgeInfoType.startHuntingEvent) || !flag2 && GuildUtil.getBadgeState(GuildUtil.GuildBadgeInfoType.receiveHuntingReward) || !flag2 && GuildUtil.getBadgeState(GuildUtil.GuildBadgeInfoType.newMember) || GuildUtil.getBadgeState(GuildUtil.GuildBadgeInfoType.newGift) || GuildUtil.getBadgeState(GuildUtil.GuildBadgeInfoType.guildLevelup) || GuildUtil.getBadgeState(GuildUtil.GuildBadgeInfoType.baseRankUp))
        flg = true;
      if (GuildUtil.getBadgeState(GuildUtil.GuildBadgeInfoType.postNewChat))
        Singleton<CommonRoot>.GetInstance().SetGuildFooterBadge(GuildUtil.FooterGuildBadge.chat, true);
      else
        Singleton<CommonRoot>.GetInstance().SetGuildFooterBadge(GuildUtil.FooterGuildBadge.bikkuri, flg);
      if (!GuildUtil.getBadgeState(GuildUtil.GuildBadgeInfoType.changeRole) && SM.GuildSignal.Current.existRoleChange())
      {
        GuildUtil.setBadgeState(GuildUtil.GuildBadgeInfoType.changeRole, true);
        flag1 = true;
      }
      if (!GuildUtil.getBadgeState(GuildUtil.GuildBadgeInfoType.newTitle) && SM.GuildSignal.Current.existNewTitle())
      {
        GuildUtil.setBadgeState(GuildUtil.GuildBadgeInfoType.newTitle, true);
        flag1 = true;
      }
      GuildEvent guildEvent = ((IEnumerable<GuildEvent>) SM.GuildSignal.Current.guild_events).Where<GuildEvent>((Func<GuildEvent, bool>) (x => x.event_type == GuildEventType.gvg_entry || x.event_type == GuildEventType.gvg_matched || x.event_type == GuildEventType.gvg_started || x.event_type == GuildEventType.gvg_finished || x.event_type == GuildEventType.gvg_entry_expired || x.event_type == GuildEventType.gvg_entry_cancel)).OrderByDescending<GuildEvent, DateTime?>((Func<GuildEvent, DateTime?>) (x => x.created_at)).FirstOrDefault<GuildEvent>();
      if (guildEvent != null)
      {
        GuildUtil.setBadgeState(GuildUtil.GuildBadgeInfoType.gvg_entry, false);
        GuildUtil.setBadgeState(GuildUtil.GuildBadgeInfoType.gvg_matched, false);
        GuildUtil.setBadgeState(GuildUtil.GuildBadgeInfoType.gvg_started, false);
        if (guildEvent.event_type == GuildEventType.gvg_entry)
          GuildUtil.setBadgeState(GuildUtil.GuildBadgeInfoType.gvg_entry, true);
        else if (guildEvent.event_type == GuildEventType.gvg_entry_cancel)
          GuildUtil.setBadgeState(GuildUtil.GuildBadgeInfoType.gvg_entry, false);
        else if (guildEvent.event_type == GuildEventType.gvg_matched)
          GuildUtil.setBadgeState(GuildUtil.GuildBadgeInfoType.gvg_matched, true);
        else if (guildEvent.event_type == GuildEventType.gvg_started)
          GuildUtil.setBadgeState(GuildUtil.GuildBadgeInfoType.gvg_started, true);
        flag1 = true;
        if (Persist.gvgBattleEnvironment.Exists)
          Persist.gvgBattleEnvironment.Delete();
      }
      GuildUtil.GuildBadgeLabelType labelType = GuildUtil.GuildBadgeLabelType.none;
      if (GuildUtil.getBadgeState(GuildUtil.GuildBadgeInfoType.gvg_entry))
        labelType = GuildUtil.GuildBadgeLabelType.entry;
      else if (GuildUtil.getBadgeState(GuildUtil.GuildBadgeInfoType.gvg_matched))
        labelType = GuildUtil.GuildBadgeLabelType.prepare;
      else if (GuildUtil.getBadgeState(GuildUtil.GuildBadgeInfoType.gvg_started))
        labelType = GuildUtil.GuildBadgeLabelType.battle;
      if (labelType == GuildUtil.GuildBadgeLabelType.none)
      {
        Singleton<CommonRoot>.GetInstance().SetGuildFooterBadge(GuildUtil.FooterGuildBadge.label, false);
      }
      else
      {
        Singleton<CommonRoot>.GetInstance().SetGuildFooterBadgeLabel(labelType);
        Singleton<CommonRoot>.GetInstance().SetGuildFooterBadge(GuildUtil.FooterGuildBadge.label, true);
      }
      if (!flag1)
        return;
      Persist.guildSetting.Flush();
    }
  }
}
