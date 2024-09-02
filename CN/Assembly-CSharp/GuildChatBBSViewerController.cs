// Decompiled with JetBrains decompiler
// Type: GuildChatBBSViewerController
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
public class GuildChatBBSViewerController : MonoBehaviour
{
  [SerializeField]
  private UILabel textMessage;
  [SerializeField]
  private UIButton OKButton;
  [SerializeField]
  private UIButton EditButton;
  private GuildChatManager guildChatManager;

  private void Start()
  {
  }

  private void Update()
  {
  }

  public void InitializeBBSViewerDialog()
  {
    this.guildChatManager = Singleton<CommonRoot>.GetInstance().guildChatManager;
    GuildMembership guildMembership = ((IEnumerable<GuildMembership>) PlayerAffiliation.Current.guild.memberships).First<GuildMembership>((Func<GuildMembership, bool>) (x => x.player.player_id == Player.Current.id));
    if (guildMembership != null && guildMembership.role == GuildRole.master)
      ((Component) this.EditButton).gameObject.SetActive(true);
    else
      ((Component) this.EditButton).gameObject.SetActive(false);
    this.textMessage.SetTextLocalize(PlayerAffiliation.Current.guild.private_message);
  }

  public void OnBBSViewerOKButtonClicked() => Singleton<PopupManager>.GetInstance().dismiss();

  public void OnBBSViewerEditButtonClicked()
  {
    Singleton<PopupManager>.GetInstance().dismiss();
    this.StartCoroutine(this.OpenBBSEditorDialog());
  }

  [DebuggerHidden]
  private IEnumerator OpenBBSEditorDialog()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    GuildChatBBSViewerController.\u003COpenBBSEditorDialog\u003Ec__IteratorA43 dialogCIteratorA43 = new GuildChatBBSViewerController.\u003COpenBBSEditorDialog\u003Ec__IteratorA43();
    return (IEnumerator) dialogCIteratorA43;
  }
}
