// Decompiled with JetBrains decompiler
// Type: Guild028114Popup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Guild028114Popup : BackButtonMenuBase
{
  [SerializeField]
  private Transform guildBasePos;
  private GameObject guildBasePrefab;
  private Guild0282GuildBase guildBase;
  private GuildInfoPopup guildPopup;
  private GuildRegistration guildRegistration;
  private GuildDirectory guildDirectory;
  [SerializeField]
  private UILabel guildStatement;
  [SerializeField]
  private UILabel guildMasterLabel;
  [SerializeField]
  private UILabel guildMasterName;
  [SerializeField]
  private UILabel guildJoinConditionLabel;
  [SerializeField]
  private UILabel guildJoinCondition1;
  [SerializeField]
  private UILabel guildJoinCondition2;
  [SerializeField]
  private UILabel guildJoinCondition3;
  [SerializeField]
  private UI2DSprite guildTitleImage;
  [SerializeField]
  private UILabel guildName;
  [SerializeField]
  private UILabel guildRank;
  [SerializeField]
  private UILabel nextExp;
  [SerializeField]
  private UILabel currentMember;
  [SerializeField]
  private UILabel maxMember;
  [SerializeField]
  private UILabel txt_guild_results_win;
  [SerializeField]
  private UILabel win;
  [SerializeField]
  private UILabel txt_guild_results;
  [SerializeField]
  private UILabel battleCount;
  [SerializeField]
  private UIButton btnSendRequest;
  [SerializeField]
  private UIButton btnCancelRequest;
  [SerializeField]
  private UIButton btnStatement;
  [SerializeField]
  private UISprite gaugeExp;
  [SerializeField]
  private UISprite guildLv_10;
  [SerializeField]
  private UISprite guildLv_1;
  [SerializeField]
  private UIScrollView scrollView;
  [SerializeField]
  private GameObject dir_frame_own;
  [SerializeField]
  private GameObject dir_frame_enemy;
  private GuildImageCache guildImageCache;
  private bool isEnemy;

  public void Initialize(GuildInfoPopup popup, GuildRegistration registration = null, bool isEnemy = false)
  {
    this.guildPopup = popup;
    this.guildDirectory = (GuildDirectory) null;
    this.isEnemy = isEnemy;
    this.StartCoroutine(this.SetGuildData(registration != null ? registration : PlayerAffiliation.Current.guild));
    this.SetButton(popup);
    this.initPanelAlpha();
  }

  public void Initialize(GuildDirectory guildData, GuildInfoPopup popup)
  {
    this.guildPopup = popup;
    this.guildRegistration = (GuildRegistration) null;
    this.StartCoroutine(this.SetGuildData(guildData));
    this.SetButton(popup);
    this.initPanelAlpha();
  }

  private void initPanelAlpha()
  {
    UIWidget component = ((Component) this).GetComponent<UIWidget>();
    if (!Object.op_Inequality((Object) component, (Object) null))
      return;
    component.alpha = 0.0f;
  }

  private void SetButton(GuildInfoPopup popup)
  {
    if (this.guildDirectory != null)
    {
      if (PlayerAffiliation.Current.isGuildMember())
      {
        ((Component) this.btnSendRequest).gameObject.SetActive(false);
        ((Component) this.btnCancelRequest).gameObject.SetActive(false);
      }
      else if (PlayerAffiliation.Current.status == GuildMembershipStatus.applicant && PlayerAffiliation.Current.guild_id == this.guildDirectory.guild_id)
      {
        ((Component) this.btnSendRequest).gameObject.SetActive(false);
        ((Component) this.btnCancelRequest).gameObject.SetActive(true);
      }
      else
      {
        ((Component) this.btnSendRequest).gameObject.SetActive(true);
        ((Component) this.btnCancelRequest).gameObject.SetActive(false);
      }
    }
    else
    {
      ((Component) this.btnSendRequest).gameObject.SetActive(false);
      ((Component) this.btnCancelRequest).gameObject.SetActive(false);
    }
    if (this.guildDirectory == null && !this.isEnemy)
    {
      GuildRole? role1 = PlayerAffiliation.Current.role;
      if ((role1.GetValueOrDefault() != GuildRole.master ? 0 : (role1.HasValue ? 1 : 0)) == 0)
      {
        GuildRole? role2 = PlayerAffiliation.Current.role;
        if ((role2.GetValueOrDefault() != GuildRole.sub_master ? 0 : (role2.HasValue ? 1 : 0)) == 0)
        {
          ((Component) this.btnStatement).gameObject.SetActive(false);
          return;
        }
      }
      ((Component) this.btnStatement).gameObject.SetActive(true);
    }
    else
      ((Component) this.btnStatement).gameObject.SetActive(false);
  }

  [DebuggerHidden]
  private IEnumerator SetGuildData(GuildRegistration data)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild028114Popup.\u003CSetGuildData\u003Ec__Iterator6F1()
    {
      data = data,
      \u003C\u0024\u003Edata = data,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator SetGuildData(GuildDirectory data)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild028114Popup.\u003CSetGuildData\u003Ec__Iterator6F2()
    {
      data = data,
      \u003C\u0024\u003Edata = data,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator ResetScrollPosition()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild028114Popup.\u003CResetScrollPosition\u003Ec__Iterator6F3()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void SetGuildData(GuildAppearance data, string guildID)
  {
    if (Object.op_Inequality((Object) this.guildBase, (Object) null))
      Object.Destroy((Object) this.guildBase);
    this.guildBase = this.guildBasePrefab.Clone(((Component) this.guildBasePos).transform).GetComponent<Guild0282GuildBase>();
    ((Collider) ((Component) this.guildBase).GetComponent<BoxCollider>()).enabled = false;
    this.guildBase.SetSprite(data, this.guildImageCache);
    this.guildMasterName.SetTextLocalize(data.master_player_name);
    this.guildMasterLabel.SetTextLocalize(Consts.Format(Consts.GetInstance().POPUP_028_1_1_4_GUILDMASTER_LABEL));
    this.guildJoinConditionLabel.SetTextLocalize(Consts.Format(Consts.GetInstance().POPUP_028_1_1_4_CONDITION_LABEL));
    this.guildRank.SetTextLocalize(Consts.Format(Consts.GetInstance().Guild0281MENU_RANKING, (IDictionary) new Hashtable()
    {
      {
        (object) "ranking",
        (object) data.ranking_no
      }
    }));
    this.nextExp.SetTextLocalize(Consts.Format(Consts.GetInstance().Guild0281MENU_NEXTEXP, (IDictionary) new Hashtable()
    {
      {
        (object) "nextExp",
        (object) data.experience_next
      }
    }));
    if (data.level < 10)
    {
      ((Component) this.guildLv_1).gameObject.SetActive(false);
      ((Component) this.guildLv_10).gameObject.SetActive(true);
      this.guildLv_10.SetSprite(string.Format("slc_text_glv_number{0}.png__GUI__guild_common__guild_common_prefab", (object) data.level));
    }
    else
    {
      ((Component) this.guildLv_1).gameObject.SetActive(true);
      ((Component) this.guildLv_10).gameObject.SetActive(true);
      this.guildLv_1.SetSprite(string.Format("slc_text_glv_number{0}.png__GUI__guild_common__guild_common_prefab", (object) (data.level % 10)));
      this.guildLv_10.SetSprite(string.Format("slc_text_glv_number{0}.png__GUI__guild_common__guild_common_prefab", (object) (data.level / 10)));
    }
    float num = 0.0f;
    if (data.experience_next > 0)
      num = (float) data.experience / (float) (data.experience + data.experience_next);
    ((Component) this.gaugeExp).transform.localScale = new Vector3(num, 1f, 1f);
    this.currentMember.SetTextLocalize(Consts.Format(Consts.GetInstance().POPUP_028_1_1_4_CURRENT_MEMBER, (IDictionary) new Hashtable()
    {
      {
        (object) "currentMember",
        (object) data.membership_num
      }
    }));
    this.maxMember.SetTextLocalize(Consts.Format(Consts.GetInstance().POPUP_028_1_1_4_MAX_MEMBER, (IDictionary) new Hashtable()
    {
      {
        (object) "maxMember",
        (object) data.membership_capacity
      }
    }));
    this.battleCount.SetTextLocalize(data.win_num + data.lose_num + data.draw_num);
    this.win.SetTextLocalize(data.win_num);
    this.txt_guild_results_win.SetTextLocalize(Consts.GetInstance().POPUP_028_1_1_4_TXT_WIN_NUM);
    this.txt_guild_results.SetTextLocalize(Consts.GetInstance().POPUP_028_1_1_4_TXT_MATCH_NUM);
    this.guildStatement.SetTextLocalize(data.broadcast_message);
  }

  private void SetCondition(
    GuildApprovalPolicy app_pol,
    GuildAtmosphere atmos,
    GuildAutoApproval auto_app)
  {
    string text1 = app_pol != null ? app_pol.name : Consts.GetInstance().GUILD_SETTING_CONDITIONS_NULL;
    string text2 = atmos != null ? atmos.name : Consts.GetInstance().GUILD_SETTING_CONDITIONS_NULL;
    string text3 = auto_app != null ? auto_app.name : Consts.GetInstance().GUILD_SETTING_CONDITIONS_NULL;
    this.guildJoinCondition1.SetTextLocalize(text1);
    this.guildJoinCondition2.SetTextLocalize(text2);
    this.guildJoinCondition3.SetTextLocalize(text3);
  }

  public override void onBackButton()
  {
    if (Singleton<NGSceneManager>.GetInstance().sceneName.Equals("guild028_1"))
    {
      if (Object.op_Inequality((Object) Singleton<NGSceneManager>.GetInstance().sceneBase, (Object) null) && Object.op_Inequality((Object) ((Component) Singleton<NGSceneManager>.GetInstance().sceneBase).GetComponent<Guild0281Menu>(), (Object) null))
        ((Component) Singleton<NGSceneManager>.GetInstance().sceneBase).GetComponent<Guild0281Menu>().isOpenGuildMemberOrInfoPopup = false;
    }
    else if (Singleton<NGSceneManager>.GetInstance().sceneName.Equals("guild028_2") && Object.op_Inequality((Object) Singleton<NGSceneManager>.GetInstance().sceneBase, (Object) null) && Object.op_Inequality((Object) ((Component) Singleton<NGSceneManager>.GetInstance().sceneBase).GetComponent<Guild0282Menu>(), (Object) null))
      ((Component) Singleton<NGSceneManager>.GetInstance().sceneBase).GetComponent<Guild0282Menu>().isClosePopupByBackBtn = true;
    Singleton<PopupManager>.GetInstance().dismiss();
  }

  public void onButtonSendRequest()
  {
    GameObject gameObject = Singleton<PopupManager>.GetInstance().open(this.guildPopup.guildSendRequestPopup);
    if (Object.op_Inequality((Object) ((Component) gameObject.GetComponent<Guild028115Popup>()).GetComponent<UIWidget>(), (Object) null))
      ((Component) gameObject.GetComponent<Guild028115Popup>()).GetComponent<UIWidget>().alpha = 0.0f;
    if (this.guildDirectory == null)
      gameObject.GetComponent<Guild028115Popup>().Initialize(this.guildRegistration, this.guildPopup);
    else
      gameObject.GetComponent<Guild028115Popup>().Initialize(this.guildDirectory, this.guildPopup);
  }

  public void onButtonCancelRequest()
  {
    GameObject gameObject = Singleton<PopupManager>.GetInstance().open(this.guildPopup.guildCancelRequestPopup);
    if (Object.op_Inequality((Object) ((Component) gameObject.GetComponent<Guild028116Popup>()).GetComponent<UIWidget>(), (Object) null))
      ((Component) gameObject.GetComponent<Guild028116Popup>()).GetComponent<UIWidget>().alpha = 0.0f;
    if (this.guildDirectory == null)
      gameObject.GetComponent<Guild028116Popup>().Initialize(this.guildRegistration, this.guildPopup);
    else
      gameObject.GetComponent<Guild028116Popup>().Initialize(this.guildDirectory, this.guildPopup);
  }

  public void onButtonEditStatement() => this.StartCoroutine(this.ShowGuildStatementPopup());

  [DebuggerHidden]
  private IEnumerator ShowGuildStatementPopup()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild028114Popup.\u003CShowGuildStatementPopup\u003Ec__Iterator6F4()
    {
      \u003C\u003Ef__this = this
    };
  }
}
