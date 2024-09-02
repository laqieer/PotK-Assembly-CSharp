// Decompiled with JetBrains decompiler
// Type: Guild0283Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using MasterDataTable;
using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Guild0283Menu : BackButtonMenuBase
{
  [SerializeField]
  private NGxScroll ngxScroll;
  [SerializeField]
  private UILabel menuTitle;
  [SerializeField]
  private UIButton buttonTitle;
  [SerializeField]
  private UIButton buttonSetting;
  [SerializeField]
  private UIButton buttonApplicants;
  [SerializeField]
  private UIButton buttonLeave;
  [SerializeField]
  private UIButton buttonDismiss;
  [SerializeField]
  private GameObject applicantBadge;
  [SerializeField]
  private GameObject titleBadge;
  private GameObject guildSettingPopup;
  private GameObject guildSettingConfirmPopup;
  private GameObject guildBrakeupUnavailablePopup;
  private GameObject guildBrakeupPopup;
  private GameObject guildBrakeupConfirmPopup;
  private GameObject guildResignUnavailablePopup;
  private GameObject guildResignPopup;
  private GameObject guildResignConfirmPopup;
  private GameObject guildNgWordPopup;

  public GameObject GuildSettingPopup => this.guildSettingPopup;

  public GameObject GuildSettingConfirmPopup => this.guildSettingConfirmPopup;

  public GameObject GuildBreakupUnavailablePopup => this.guildBrakeupUnavailablePopup;

  public GameObject GuildBrakeupPopup => this.guildBrakeupPopup;

  public GameObject GuildBrakeUpConfirmPopup => this.guildBrakeupConfirmPopup;

  public GameObject GuildResignUnavailablePopup => this.guildResignUnavailablePopup;

  public GameObject GuildResignPopup => this.guildResignPopup;

  public GameObject GuildResignConfirmPopup => this.guildResignConfirmPopup;

  public GameObject GuildNgWordPopup => this.guildNgWordPopup;

  [DebuggerHidden]
  public IEnumerator InitializeAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0283Menu.\u003CInitializeAsync\u003Ec__Iterator6DA()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void Initialize()
  {
  }

  [DebuggerHidden]
  private IEnumerator ResourceLoad()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0283Menu.\u003CResourceLoad\u003Ec__Iterator6DB()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void InitWidgetAlpha(MonoBehaviour component)
  {
    if (!Object.op_Inequality((Object) ((Component) component).GetComponent<UIWidget>(), (Object) null))
      return;
    ((Component) component).GetComponent<UIWidget>().alpha = 0.0f;
  }

  public override void onBackButton()
  {
    if (this.IsPushAndSet())
      return;
    this.backScene();
  }

  public void onGuildTitleButton() => Guild0284Scene.ChangeScene();

  [DebuggerHidden]
  private IEnumerator ShowGuildOption()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0283Menu.\u003CShowGuildOption\u003Ec__Iterator6DC()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void onGuildOptionButton() => this.StartCoroutine(this.ShowGuildOption());

  public void onMemberRequestCheckButton() => Guild0285Scene.ChangeScene();

  public void onGuildResignButton()
  {
    Debug.Log((object) ("role:" + (object) PlayerAffiliation.Current.role));
    GuildRole? role = PlayerAffiliation.Current.role;
    if ((role.GetValueOrDefault() != GuildRole.master ? 0 : (role.HasValue ? 1 : 0)) != 0)
      Singleton<PopupManager>.GetInstance().open(this.guildResignUnavailablePopup).GetComponent<Guild02833Popup>().Initialize();
    else
      Singleton<PopupManager>.GetInstance().open(this.guildResignPopup).GetComponent<Guild028341Popup>().Initialize(this);
  }

  public void onGuildBrakeupButton()
  {
    if (PlayerAffiliation.Current.guild.memberships.Length >= 2)
      Singleton<PopupManager>.GetInstance().open(this.guildBrakeupUnavailablePopup).GetComponent<Guild02831Popup>().Initialize();
    else
      Singleton<PopupManager>.GetInstance().open(this.guildBrakeupPopup).GetComponent<Guild028321Popup>().Initialize(this);
  }
}
