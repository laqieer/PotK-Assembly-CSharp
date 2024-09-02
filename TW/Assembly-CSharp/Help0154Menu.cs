// Decompiled with JetBrains decompiler
// Type: Help0154Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using gu3.Device;
using SM;
using System.Collections;
using UnityEngine;

#nullable disable
public class Help0154Menu : BackButtonMenuBase
{
  [SerializeField]
  protected UILabel TxtPopuptitle;
  [SerializeField]
  protected UILabel TxtPopuptitle2;
  [SerializeField]
  protected UILabel TxtREADME;
  [SerializeField]
  private NGxScroll text_scroll;
  [SerializeField]
  protected UILabel m_supportMailAddress;
  private string player_id;
  private string short_id;

  public virtual void Foreground()
  {
  }

  public virtual void VScrollBar()
  {
  }

  public void InitContact(Player player)
  {
    this.player_id = player.id;
    this.short_id = player.short_id;
    this.text_scroll.ResolvePosition();
    this.text_scroll.ResolvePosition();
  }

  public void LaunchMailer()
  {
    DeviceManager.LaunchMailer(Consts.GetInstance().HELP_CONTACT_ADDRESS, Consts.GetInstance().HELP_CONTACT_TITLE, Consts.Format(Consts.GetInstance().HELP_CONTACT_MAIL_BODY, (IDictionary) new Hashtable()
    {
      {
        (object) "ver",
        (object) Revision.DLCVersion
      },
      {
        (object) "player_id",
        (object) this.player_id
      },
      {
        (object) "short_id",
        (object) this.short_id
      },
      {
        (object) "agent",
        (object) DeviceManager.GetUserAgent()
      }
    }));
  }

  public virtual void IbtnPopupClose()
  {
    if (this.IsPushAndSet())
      return;
    this.backScene();
  }

  public void IbtnBack()
  {
    if (this.IsPushAndSet())
      return;
    this.backScene();
  }

  public override void onBackButton() => this.IbtnBack();
}
