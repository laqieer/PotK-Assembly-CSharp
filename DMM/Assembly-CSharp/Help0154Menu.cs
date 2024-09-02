// Decompiled with JetBrains decompiler
// Type: Help0154Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using DeviceKit;
using GameCore;
using SM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    string helpContactAddress = Consts.GetInstance().HELP_CONTACT_ADDRESS;
    string subject = Consts.Format(Consts.GetInstance().HELP_CONTACT_TITLE, (IDictionary) new Dictionary<string, string>()
    {
      {
        "short_id",
        this.short_id
      }
    });
    string str = string.Format("{0}/{1}/{2}/{3}/{4}", (object) Gsc.Device.DeviceInfo.DeviceModel, (object) Gsc.Device.DeviceInfo.DeviceVendor, (object) Gsc.Device.DeviceInfo.OperatingSystem, (object) Gsc.Device.DeviceInfo.ProcessorType, (object) Gsc.Device.DeviceInfo.SystemMemorySize);
    string body = Consts.Format(Consts.GetInstance().HELP_CONTACT_MAIL_BODY, (IDictionary) new Dictionary<string, string>()
    {
      {
        "ver",
        Revision.DLCVersion
      },
      {
        "player_id",
        this.player_id
      },
      {
        "short_id",
        this.short_id
      },
      {
        "agent",
        str
      }
    }).Replace("\n", "%0A");
    App.LaunchMailer(helpContactAddress, subject, body);
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
