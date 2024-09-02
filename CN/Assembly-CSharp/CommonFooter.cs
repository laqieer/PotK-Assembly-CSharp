// Decompiled with JetBrains decompiler
// Type: CommonFooter
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
    if (SMManager.Get<Player>().is_bingo_end)
      DailyMission0272Scene.ChangeScene0272(false);
    else
      DailyMission0271Scene.ChangeScene0271(false);
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
    return (IEnumerator) new CommonFooter.\u003CChangeSceneGuild\u003Ec__IteratorA5B()
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
    {
      if (this.modifiedPlayer.Value.is_bingo_end)
        this.footerMissionBadge.SetActive(this.modifiedPlayer.Value.is_open_mission);
      else
        this.footerMissionBadge.SetActive(this.modifiedPlayer.Value.is_open_bingo);
    }
    if (this.modifiedGuildSignal == null || Singleton<NGGameDataManager>.GetInstance().IsEarth || !this.modifiedGuildSignal.IsChangedOnce())
      return;
    this.SetGuildBadge();
  }

  private void SetGuildBadge()
  {
    bool flag1 = false;
    bool flag2 = false;
    if (PlayerAffiliation.Current == null)
      return;
    if (!Persist.guildSetting.Exists)
    {
      Persist.guildSetting.Data.reset();
      Persist.guildSetting.Flush();
    }
    if (!PlayerAffiliation.Current.isGuildMember())
    {
      if (SM.GuildSignal.Current.existRelationshipEventWithoutMyself(GuildEventType.leave_membership))
        Singleton<CommonRoot>.GetInstance().SetGuildFooterBadge(true);
      else
        Singleton<CommonRoot>.GetInstance().SetGuildFooterBadge(false);
    }
    else
    {
      bool flag3 = Singleton<NGSceneManager>.GetInstance().sceneName.Equals("guild028_1");
      GuildRole? role1 = PlayerAffiliation.Current.role;
      if ((role1.GetValueOrDefault() != GuildRole.master ? 0 : (role1.HasValue ? 1 : 0)) == 0)
      {
        GuildRole? role2 = PlayerAffiliation.Current.role;
        if ((role2.GetValueOrDefault() != GuildRole.sub_master ? 0 : (role2.HasValue ? 1 : 0)) == 0)
        {
          GuildUtil.setBadgeState(GuildUtil.GuildBadgeInfoType.newApplicant, false);
          GuildUtil.setBadgeState(GuildUtil.GuildBadgeInfoType.newMember, false);
          goto label_16;
        }
      }
      if (SM.GuildSignal.Current.existNewApplicant())
      {
        GuildUtil.setBadgeState(GuildUtil.GuildBadgeInfoType.newApplicant, true);
        flag2 = true;
      }
      if (PlayerAffiliation.Current.guild.auto_approval.auto_approval && SM.GuildSignal.Current.existNewMember())
      {
        GuildUtil.setBadgeState(GuildUtil.GuildBadgeInfoType.newMember, true);
        flag2 = true;
      }
label_16:
      if (!flag3 && SM.GuildSignal.Current.existPlayershipEventType(GuildEventType.apply_applicant))
        flag1 = true;
      if (((IEnumerable<GuildEventGift>) SM.GuildSignal.Current.gift_events).Where<GuildEventGift>((Func<GuildEventGift, bool>) (x => x.event_type == GuildEventType.incoming_gift)).FirstOrDefault<GuildEventGift>() != null)
      {
        GuildUtil.setBadgeState(GuildUtil.GuildBadgeInfoType.newGift, true);
        flag2 = true;
      }
      if (GuildUtil.getBadgeState(GuildUtil.GuildBadgeInfoType.newApplicant) || !flag3 && GuildUtil.getBadgeState(GuildUtil.GuildBadgeInfoType.startHuntingEvent) || !flag3 && GuildUtil.getBadgeState(GuildUtil.GuildBadgeInfoType.receiveHuntingReward) || !flag3 && GuildUtil.getBadgeState(GuildUtil.GuildBadgeInfoType.newMember) || GuildUtil.getBadgeState(GuildUtil.GuildBadgeInfoType.newGift))
        flag1 = true;
      Singleton<CommonRoot>.GetInstance().SetGuildFooterBadge(flag1 || Singleton<CommonRoot>.GetInstance().GuildFooterBadgeVisible());
      if (!GuildUtil.getBadgeState(GuildUtil.GuildBadgeInfoType.changeRole) && SM.GuildSignal.Current.existRoleChange())
      {
        GuildUtil.setBadgeState(GuildUtil.GuildBadgeInfoType.changeRole, true);
        flag2 = true;
      }
      if (!GuildUtil.getBadgeState(GuildUtil.GuildBadgeInfoType.newTitle) && SM.GuildSignal.Current.existNewTitle())
      {
        GuildUtil.setBadgeState(GuildUtil.GuildBadgeInfoType.newTitle, true);
        flag2 = true;
      }
      if (!flag2)
        return;
      Persist.guildSetting.Flush();
    }
  }
}
