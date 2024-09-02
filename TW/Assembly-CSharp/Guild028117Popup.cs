// Decompiled with JetBrains decompiler
// Type: Guild028117Popup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Guild028117Popup : BackButtonMenuBase
{
  private GuildInfoPopup guildPopup;
  private bool ngWord;
  private bool maintenance;
  [SerializeField]
  private UILabel popupTitle;
  [SerializeField]
  private UILabel maxWord;
  private int statementCount;
  [SerializeField]
  private UILabel statement;
  [SerializeField]
  private UIInput input;
  [SerializeField]
  private UIScrollView scrollView;
  [SerializeField]
  private UIWidget scrollContainerWidget;
  [SerializeField]
  private UIWidget dragScrollViewWidget;
  [SerializeField]
  private SpreadColorButton decideButton;
  private BoxCollider inputFieldCollision;
  private BoxCollider dragScrollCollision;

  private void Start() => this.input.isSelected = true;

  public void Initialize(GuildInfoPopup popup)
  {
    this.guildPopup = popup;
    this.popupTitle.SetTextLocalize(Consts.Format(Consts.GetInstance().POPUP_028_1_1_7_TITLE));
    this.statement.SetTextLocalize(PlayerAffiliation.Current.guild.appearance.broadcast_message);
    this.input.value = PlayerAffiliation.Current.guild.appearance.broadcast_message.ToConverter();
    this.maxWord.SetTextLocalize(Consts.Format(Consts.GetInstance().POPUP_028_1_1_7_STATEMENT_LIMIT, (IDictionary) new Hashtable()
    {
      {
        (object) "now",
        (object) this.input.value.Length
      },
      {
        (object) "max",
        (object) this.input.characterLimit
      }
    }));
    UIWidget component = ((Component) this).GetComponent<UIWidget>();
    if (Object.op_Inequality((Object) component, (Object) null))
      component.alpha = 0.0f;
    this.dragScrollCollision = ((Component) this.dragScrollViewWidget).GetComponent<BoxCollider>();
  }

  public void Initialize(GuildDirectory guild, GuildInfoPopup popup)
  {
    this.guildPopup = popup;
    this.ngWord = false;
    this.maintenance = false;
    this.popupTitle.SetTextLocalize(Consts.Format(Consts.GetInstance().POPUP_028_1_1_7_TITLE));
  }

  [DebuggerHidden]
  private IEnumerator SendGuildStatement()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild028117Popup.\u003CSendGuildStatement\u003Ec__Iterator6FA()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void ErrorCallback(WebAPI.Response.UserError error)
  {
    if (error.Code.Equals("GLD011"))
    {
      this.ngWord = true;
      Singleton<PopupManager>.GetInstance().open(this.guildPopup.guildNgWordPopup).GetComponent<Guild028NgWordPopup>().Initialize((System.Action) (() => { }));
    }
    else if (error.Code.Equals("GLD014"))
    {
      this.maintenance = true;
      WebAPI.DefaultUserErrorCallback(error);
    }
    else
      WebAPI.DefaultUserErrorCallback(error);
  }

  public void UpdateDrawScrollViewAnchor()
  {
    if (((Component) this.statement).GetComponent<UIWidget>().height > this.scrollContainerWidget.height)
    {
      this.dragScrollViewWidget.bottomAnchor.target = ((Component) this.statement).transform;
      this.dragScrollViewWidget.bottomAnchor.rect = (UIRect) this.statement;
      this.dragScrollViewWidget.bottomAnchor.relative = 0.0f;
      this.dragScrollViewWidget.UpdateAnchors();
    }
    else
    {
      this.dragScrollViewWidget.bottomAnchor.target = (Transform) null;
      this.dragScrollViewWidget.SetDimensions((int) this.scrollContainerWidget.localSize.x, (int) this.scrollContainerWidget.localSize.y);
    }
  }

  public void UpdateDragScrollViewBoxCollider()
  {
    this.dragScrollCollision.size = new Vector3(this.dragScrollCollision.size.x, this.dragScrollViewWidget.localSize.y);
    this.dragScrollCollision.center = new Vector3(this.dragScrollCollision.center.x, (float) (-(double) this.dragScrollViewWidget.localSize.y * 0.5));
  }

  public override void onBackButton() => Singleton<PopupManager>.GetInstance().dismiss();

  public void onDecideButton() => this.StartCoroutine(this.SendGuildStatement());

  public void onChangeStatement()
  {
    if (!Object.op_Inequality((Object) ((Component) this.input).GetComponent<UILabel>(), (Object) null))
      return;
    this.statement.SetTextLocalize(this.input.value);
    this.maxWord.SetTextLocalize(Consts.Format(Consts.GetInstance().POPUP_028_1_1_7_STATEMENT_LIMIT, (IDictionary) new Hashtable()
    {
      {
        (object) "now",
        (object) this.input.value.Length
      },
      {
        (object) "max",
        (object) this.input.characterLimit
      }
    }));
    this.UpdateDrawScrollViewAnchor();
    this.scrollView.UpdatePosition();
    this.decideButton.isEnabled = !this.input.value.isEmptyOrWhitespace();
    if (!string.IsNullOrEmpty(this.statement.text))
      return;
    this.input.defaultText = string.Empty;
  }

  public void ResetScrollPosition() => this.scrollView.ResetPosition();

  public void EditButton() => this.input.isSelected = !this.input.isSelected;
}
