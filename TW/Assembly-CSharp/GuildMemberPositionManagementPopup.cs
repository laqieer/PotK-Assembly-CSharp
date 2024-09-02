// Decompiled with JetBrains decompiler
// Type: GuildMemberPositionManagementPopup
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
using UniLinq;
using UnityEngine;

#nullable disable
public class GuildMemberPositionManagementPopup : BackButtonMenuBase
{
  private const int MINIMUM_NUM_RESIGN_MASTER = 2;
  private const int DEFAULT_DLG_WIDTH = 532;
  private const int DEFAULT_DLG_HEIGHT = 322;
  private GuildMemberObject guildMemberObjs;
  private GuildMembership memberInfo;
  private GameObject currentPopup;
  private Guild0282Menu guild282Menu;
  private Guild0282GuildBaseMenu guildBaseMenu;
  private bool isShowMapButton;
  private System.Action actionAfterRoleChange;
  [SerializeField]
  private UILabel popupTitle;
  [SerializeField]
  private UILabel btnLabelResignMaster;
  [SerializeField]
  private UILabel btnLabelTransferMaster;
  [SerializeField]
  private UILabel btnLabelAssignSubMaster;
  [SerializeField]
  private UILabel btnLabelRivestSubMaster;
  [SerializeField]
  private UILabel btnLabelResignSubMaster;
  [SerializeField]
  private UILabel btnLabelVanish;
  [SerializeField]
  private UIButton btnResignMaster;
  [SerializeField]
  private UIButton btnTransferMaster;
  [SerializeField]
  private UIButton btnAssignSubMaster;
  [SerializeField]
  private UIButton btnDivestSubMaster;
  [SerializeField]
  private UIButton btnResignSubMaster;
  [SerializeField]
  private UIButton btnVanish;
  [SerializeField]
  private UIScrollView scroll;
  [SerializeField]
  [Header("Resign master dlg size")]
  private Vector2 resignMasterDlgSize;
  [SerializeField]
  private Vector2 resignMasterFailedDlgSize;
  [SerializeField]
  private Vector2 resignMasterComfirmDlgSize;
  [SerializeField]
  private Vector2 resignMasterResultDlgSize;
  [Header("Transfer master dlg size")]
  [SerializeField]
  private Vector2 transferMasterDlgSize;
  [SerializeField]
  private Vector2 transferMasterComfirmDlgSize;
  [SerializeField]
  private Vector2 transferMasterResultDlgSize;
  [Header("Assign submaster dlg size")]
  [SerializeField]
  private Vector2 assignSubmasterDlgSize;
  [SerializeField]
  private Vector2 assignSubmasterFailedDlgSize;
  [SerializeField]
  private Vector2 assignSubmasterComfirmDlgSize;
  [SerializeField]
  private Vector2 assignSubmasterResultDlgSize;
  [SerializeField]
  [Header("Divest submaster dlg size")]
  private Vector2 divestSubmasterDlgSize;
  [SerializeField]
  private Vector2 divestSubmasterComfirmDlgSize;
  [SerializeField]
  private Vector2 divestSubmasterResultDlgSize;
  [Header("Resign submaster dlg size")]
  [SerializeField]
  private Vector2 resingSubmasterDlgSize;
  [SerializeField]
  private Vector2 resingSubmasterComfirmDlgSize;
  [SerializeField]
  private Vector2 resingSubmasterResultDlgSize;
  [Header("Vanish member dlg size")]
  [SerializeField]
  private Vector2 vanishMemberDlgSize;
  [SerializeField]
  private Vector2 vanishMemberComfirmDlgSize;
  [SerializeField]
  private Vector2 vanishMemberResultDlgSize;

  public void Initialize(
    Guild0282Menu menu,
    GuildMembership info,
    Guild0282GuildBaseMenu baseMenu,
    GuildMemberObject popupObjs,
    System.Action action = null,
    bool showMapButton = true)
  {
    if (Object.op_Inequality((Object) ((Component) this).GetComponent<UIWidget>(), (Object) null))
      ((Component) this).GetComponent<UIWidget>().alpha = 0.0f;
    this.guild282Menu = menu;
    this.guildBaseMenu = baseMenu;
    this.memberInfo = info;
    this.guildMemberObjs = popupObjs;
    this.isShowMapButton = showMapButton;
    this.actionAfterRoleChange = action;
    this.popupTitle.SetTextLocalize(Consts.Format(Consts.GetInstance().POPUP_GUILD_CHANGE_POSITION_TITLE));
    this.SetButtonLabel();
    this.SetButtonDisp();
  }

  private void SetButtonDisp()
  {
    GuildRole? role = PlayerAffiliation.Current.role;
    GuildRole? nullable = new GuildRole?(this.memberInfo.role);
    ((Component) this.btnResignMaster).gameObject.SetActive(false);
    ((Component) this.btnTransferMaster).gameObject.SetActive(false);
    ((Component) this.btnAssignSubMaster).gameObject.SetActive(false);
    ((Component) this.btnResignSubMaster).gameObject.SetActive(false);
    ((Component) this.btnDivestSubMaster).gameObject.SetActive(false);
    ((Component) this.btnVanish).gameObject.SetActive(false);
    if ((role.GetValueOrDefault() != GuildRole.master ? 0 : (role.HasValue ? 1 : 0)) != 0)
    {
      if ((nullable.GetValueOrDefault() != GuildRole.master ? 0 : (nullable.HasValue ? 1 : 0)) != 0)
        ((Component) this.btnResignMaster).gameObject.SetActive(true);
      else if ((nullable.GetValueOrDefault() != GuildRole.sub_master ? 0 : (nullable.HasValue ? 1 : 0)) != 0)
      {
        ((Component) this.btnTransferMaster).gameObject.SetActive(true);
        ((Component) this.btnDivestSubMaster).gameObject.SetActive(true);
        ((Component) this.btnVanish).gameObject.SetActive(true);
      }
      else
      {
        if ((nullable.GetValueOrDefault() != GuildRole.general ? 0 : (nullable.HasValue ? 1 : 0)) == 0)
          return;
        ((Component) this.btnTransferMaster).gameObject.SetActive(true);
        ((Component) this.btnAssignSubMaster).gameObject.SetActive(true);
        ((Component) this.btnVanish).gameObject.SetActive(true);
      }
    }
    else
    {
      if ((role.GetValueOrDefault() != GuildRole.sub_master ? 0 : (role.HasValue ? 1 : 0)) == 0)
        return;
      if (this.memberInfo.player.player_id == Player.Current.id)
      {
        ((Component) this.btnResignSubMaster).gameObject.SetActive(true);
      }
      else
      {
        if (this.memberInfo.role != GuildRole.general)
          return;
        ((Component) this.btnVanish).gameObject.SetActive(true);
      }
    }
  }

  public void ResetScroll()
  {
    ((Component) this.scroll).GetComponent<UIPanel>().UpdateAnchors();
    this.scroll.ResetPosition();
  }

  private void SetButtonLabel()
  {
    this.btnLabelResignMaster.SetTextLocalize(Consts.Format(Consts.GetInstance().POPUP_GUILD_CHANGE_POSITION_LABEL_RESIGN_MASTER));
    this.btnLabelTransferMaster.SetTextLocalize(Consts.Format(Consts.GetInstance().POPUP_GUILD_CHANGE_POSITION_LABEL_TRANSFER_MASTER));
    this.btnLabelAssignSubMaster.SetTextLocalize(Consts.Format(Consts.GetInstance().POPUP_GUILD_CHANGE_POSITION_LABEL_ASSIGN_SUBMASTER));
    this.btnLabelRivestSubMaster.SetTextLocalize(Consts.Format(Consts.GetInstance().POPUP_GUILD_CHANGE_POSITION_LABEL_RIVEST_SUBMASTER));
    this.btnLabelResignSubMaster.SetTextLocalize(Consts.Format(Consts.GetInstance().POPUP_GUILD_CHANGE_POSITION_LABEL_RESIGN_SUBMASTER));
    this.btnLabelVanish.SetTextLocalize(Consts.Format(Consts.GetInstance().POPUP_GUILD_CHANGE_POSITION_LABEL_VANISH));
  }

  private void ShowYesNoPopup(string title, string message, Vector2 size, System.Action yes = null, System.Action no = null)
  {
    GameObject prefab = this.guildMemberObjs.GuildPositionManagementPopupYesNo.Clone();
    prefab.SetActive(false);
    prefab.GetComponent<GuildYesNoPopup>().Initialize(title, message, size, yes, no);
    prefab.SetActive(true);
    Singleton<PopupManager>.GetInstance().open(prefab, isCloned: true);
    this.currentPopup = prefab;
  }

  private void ShowYesNoPopupRecycle(
    string title,
    string message,
    Vector2 size,
    System.Action yes = null,
    System.Action no = null)
  {
    if (Object.op_Equality((Object) this.currentPopup, (Object) null))
      this.currentPopup = this.guildMemberObjs.GuildPositionManagementPopupYesNo.Clone();
    this.currentPopup.SetActive(false);
    this.currentPopup.GetComponent<GuildYesNoPopup>().Initialize(title, message, size, yes, no);
    this.currentPopup.SetActive(true);
    NGTweenParts component = this.currentPopup.GetComponent<NGTweenParts>();
    if (Object.op_Inequality((Object) component, (Object) null))
    {
      component.forceActive(true);
    }
    else
    {
      if (!Object.op_Inequality((Object) this.currentPopup.GetComponent<UIWidget>(), (Object) null))
        return;
      this.currentPopup.GetComponent<UIWidget>().alpha = 1f;
    }
  }

  private void ShowOkPopup(string title, string message, Vector2 size, System.Action ok = null)
  {
    GameObject prefab = this.guildMemberObjs.GuildPositionManagementPopupOk.Clone();
    prefab.SetActive(false);
    prefab.GetComponent<GuildOkPopup>().Initialize(title, message, new Vector2?(size), ok);
    prefab.SetActive(true);
    Singleton<PopupManager>.GetInstance().open(prefab, isCloned: true);
  }

  private void ShowLoading()
  {
    Singleton<CommonRoot>.GetInstance().loadingMode = 1;
    Singleton<CommonRoot>.GetInstance().isLoading = true;
  }

  private void HideLoading()
  {
    Singleton<CommonRoot>.GetInstance().isLoading = false;
    Singleton<CommonRoot>.GetInstance().loadingMode = 0;
  }

  private void HideGuildFooterBadge()
  {
    if (!Persist.guildSetting.Exists || !GuildUtil.getBadgeState(GuildUtil.GuildBadgeInfoType.newApplicant))
      return;
    GuildUtil.setBadgeState(GuildUtil.GuildBadgeInfoType.newApplicant, false);
    Singleton<CommonRoot>.GetInstance().SetGuildFooterBadgeBikkuri();
  }

  [DebuggerHidden]
  private IEnumerator SendResignGuildMaster()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuildMemberPositionManagementPopup.\u003CSendResignGuildMaster\u003Ec__Iterator751()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void onResignGuildMasterButton()
  {
    if (PlayerAffiliation.Current.onGvgOperation)
      this.StartCoroutine(this.showPopupOnGvg());
    else if (PlayerAffiliation.Current.guild.memberships.Length < 2)
      this.ShowOkPopup(Consts.Format(Consts.GetInstance().POPUP_GUILD_CHANGE_POSITION_TITLE), Consts.Format(Consts.GetInstance().POPUP_GUILD_CANNOT_RESIGN_MASTER), this.resignMasterFailedDlgSize, (System.Action) (() => { }));
    else
      this.ShowYesNoPopup(Consts.Format(Consts.GetInstance().POPUP_GUILD_CHANGE_POSITION_TITLE), Consts.Format(Consts.GetInstance().POPUP_GUILD_RESIGN_MASTER), this.resignMasterDlgSize, (System.Action) (() => this.ShowYesNoPopupRecycle(Consts.Format(Consts.GetInstance().POPUP_GUILD_CHANGE_POSITION_CONFIRMATION_TITLE), Consts.Format(Consts.GetInstance().POPUP_GUILD_RESIGN_MASTER_CONFIRMATION), this.resignMasterComfirmDlgSize, (System.Action) (() => this.StartCoroutine(this.SendResignGuildMaster())), (System.Action) (() => { }))), (System.Action) (() => { }));
  }

  [DebuggerHidden]
  private IEnumerator TransferGuildMaster()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuildMemberPositionManagementPopup.\u003CTransferGuildMaster\u003Ec__Iterator752()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void onTransferGuildMasterButton()
  {
    if (PlayerAffiliation.Current.onGvgOperation)
      this.StartCoroutine(this.showPopupOnGvg());
    else
      this.ShowYesNoPopup(Consts.Format(Consts.GetInstance().POPUP_GUILD_CHANGE_POSITION_TITLE), Consts.Format(Consts.GetInstance().POPUP_GUILD_TRANSFER_MASTER), this.transferMasterDlgSize, (System.Action) (() => this.ShowYesNoPopupRecycle(Consts.Format(Consts.GetInstance().POPUP_GUILD_CHANGE_POSITION_CONFIRMATION_TITLE), Consts.Format(Consts.GetInstance().POPUP_GUILD_TRANSFER_MASTER_CONFIRMATION), this.transferMasterComfirmDlgSize, (System.Action) (() => this.StartCoroutine(this.TransferGuildMaster())), (System.Action) (() => this.currentPopup = (GameObject) null))), (System.Action) (() => { }));
  }

  [DebuggerHidden]
  private IEnumerator AssignSubMaster()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuildMemberPositionManagementPopup.\u003CAssignSubMaster\u003Ec__Iterator753()
    {
      \u003C\u003Ef__this = this
    };
  }

  private int GetSubMasterNum()
  {
    return ((IEnumerable<GuildMembership>) PlayerAffiliation.Current.guild.memberships).Count<GuildMembership>((Func<GuildMembership, bool>) (x => x.role == GuildRole.sub_master));
  }

  public void onAssignSubMasterButton()
  {
    if (PlayerAffiliation.Current.onGvgOperation)
    {
      this.StartCoroutine(this.showPopupOnGvg());
    }
    else
    {
      int? nullable = ((IEnumerable<MasterDataTable.GuildSetting>) MasterData.GuildSettingList).FirstIndexOrNull<MasterDataTable.GuildSetting>((Func<MasterDataTable.GuildSetting, bool>) (x => x.ID == 10));
      float result = 0.0f;
      if (nullable.HasValue)
        float.TryParse(MasterData.GuildSettingList[nullable.Value].value, out result);
      if (this.GetSubMasterNum() >= (int) result)
        this.ShowOkPopup(Consts.Format(Consts.GetInstance().POPUP_GUILD_CHANGE_POSITION_TITLE), Consts.Format(Consts.GetInstance().POPUP_GUILD_CANNOT_ASSIGN_SUB_MASTER), this.assignSubmasterFailedDlgSize, (System.Action) (() => { }));
      else
        this.ShowYesNoPopup(Consts.Format(Consts.GetInstance().POPUP_GUILD_CHANGE_POSITION_TITLE), Consts.Format(Consts.GetInstance().POPUP_GUILD_ASSIGN_SUB_MASTER), this.assignSubmasterDlgSize, (System.Action) (() => this.ShowYesNoPopupRecycle(Consts.Format(Consts.GetInstance().POPUP_GUILD_CHANGE_POSITION_CONFIRMATION_TITLE), Consts.Format(Consts.GetInstance().POPUP_GUILD_ASSIGN_SUB_MASTER_CONFIRMATION), this.assignSubmasterComfirmDlgSize, (System.Action) (() => this.StartCoroutine(this.AssignSubMaster())), (System.Action) (() => this.currentPopup = (GameObject) null))), (System.Action) (() => { }));
    }
  }

  [DebuggerHidden]
  private IEnumerator DivestSubMaster()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuildMemberPositionManagementPopup.\u003CDivestSubMaster\u003Ec__Iterator754()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void onDivestSubMasterButton()
  {
    if (PlayerAffiliation.Current.onGvgOperation)
      this.StartCoroutine(this.showPopupOnGvg());
    else
      this.ShowYesNoPopup(Consts.Format(Consts.GetInstance().POPUP_GUILD_CHANGE_POSITION_TITLE), Consts.Format(Consts.GetInstance().POPUP_GUILD_DIVEST_SUB_MASTER), this.divestSubmasterDlgSize, (System.Action) (() => this.ShowYesNoPopupRecycle(Consts.Format(Consts.GetInstance().POPUP_GUILD_CHANGE_POSITION_CONFIRMATION_TITLE), Consts.Format(Consts.GetInstance().POPUP_GUILD_DIVEST_SUB_MASTER_CONFIRMATION), this.divestSubmasterComfirmDlgSize, (System.Action) (() => this.StartCoroutine(this.DivestSubMaster())), (System.Action) (() => this.currentPopup = (GameObject) null))), (System.Action) (() => { }));
  }

  [DebuggerHidden]
  private IEnumerator ResignSubMaster()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuildMemberPositionManagementPopup.\u003CResignSubMaster\u003Ec__Iterator755()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void onResignSubMasterButton()
  {
    if (PlayerAffiliation.Current.onGvgOperation)
      this.StartCoroutine(this.showPopupOnGvg());
    else
      this.ShowYesNoPopup(Consts.Format(Consts.GetInstance().POPUP_GUILD_CHANGE_POSITION_TITLE), Consts.Format(Consts.GetInstance().POPUP_GUILD_RESIGN_SUB_MASTER), this.assignSubmasterDlgSize, (System.Action) (() => this.ShowYesNoPopupRecycle(Consts.Format(Consts.GetInstance().POPUP_GUILD_CHANGE_POSITION_CONFIRMATION_TITLE), Consts.Format(Consts.GetInstance().POPUP_GUILD_RESIGN_SUB_MASTER_CONFIRMATION), this.assignSubmasterComfirmDlgSize, (System.Action) (() => this.StartCoroutine(this.ResignSubMaster())), (System.Action) (() => this.currentPopup = (GameObject) null))), (System.Action) (() => { }));
  }

  [DebuggerHidden]
  private IEnumerator SendDropRequest()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuildMemberPositionManagementPopup.\u003CSendDropRequest\u003Ec__Iterator756()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void onDropFromGuildButton()
  {
    if (PlayerAffiliation.Current.onGvgOperation)
      this.StartCoroutine(this.showPopupOnGvg());
    else
      this.ShowYesNoPopup(Consts.Format(Consts.GetInstance().POPUP_GUILD_DIVEST_MEMBER_TITLE), Consts.Format(Consts.GetInstance().POPUP_GUILD_DIVEST_MEMBER, (IDictionary) new Hashtable()
      {
        {
          (object) "member",
          (object) this.memberInfo.player.player_name
        }
      }), this.vanishMemberDlgSize, (System.Action) (() => this.ShowYesNoPopupRecycle(Consts.Format(Consts.GetInstance().POPUP_GUILD_DIVEST_MEMBER_CONFIRMATION_TITLE), Consts.Format(Consts.GetInstance().POPUP_GUILD_DIVEST_MEMBER_CONFIRMATION), this.vanishMemberComfirmDlgSize, (System.Action) (() => this.StartCoroutine(this.SendDropRequest())), (System.Action) (() => this.currentPopup = (GameObject) null))), (System.Action) (() => { }));
  }

  public override void onBackButton() => Singleton<PopupManager>.GetInstance().dismiss();

  [DebuggerHidden]
  private IEnumerator showMemberDetailPopup()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuildMemberPositionManagementPopup.\u003CshowMemberDetailPopup\u003Ec__Iterator757()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator showPopupOnGvg()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuildMemberPositionManagementPopup.\u003CshowPopupOnGvg\u003Ec__Iterator758()
    {
      \u003C\u003Ef__this = this
    };
  }
}
