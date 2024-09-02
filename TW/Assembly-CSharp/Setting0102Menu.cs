// Decompiled with JetBrains decompiler
// Type: Setting0102Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Setting0102Menu : BackButtonMenuBase
{
  [SerializeField]
  protected UILabel TxtAP;
  [SerializeField]
  protected UILabel TxtCP;
  [SerializeField]
  protected UILabel TxtTitle;
  private bool NotificationAp;
  private bool NotificationBp;
  private bool PushNotification;
  [SerializeField]
  private List<GameObject> IbtnAPONList = new List<GameObject>();
  [SerializeField]
  private List<GameObject> IbtnAPOFFList = new List<GameObject>();
  [SerializeField]
  private List<GameObject> IbtnBPONList = new List<GameObject>();
  [SerializeField]
  private List<GameObject> IbtnBPOFFList = new List<GameObject>();
  [SerializeField]
  private List<GameObject> IbtnPushONList = new List<GameObject>();
  [SerializeField]
  private List<GameObject> IbtnPushOFFList = new List<GameObject>();

  [DebuggerHidden]
  public IEnumerator onInitSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Setting0102Menu.\u003ConInitSceneAsync\u003Ec__Iterator597()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void onEndScene()
  {
    Persist.notification.Data.Ap = this.NotificationAp;
    Persist.notification.Data.Bp = this.NotificationBp;
    Persist.notification.Flush();
    Persist.pushnotification.Data.enablePush = this.PushNotification;
    Persist.pushnotification.Flush();
  }

  public override void onBackButton() => this.IbtnBack();

  public virtual void IbtnBack()
  {
    if (this.IsPushAndSet())
      return;
    this.backScene();
  }

  public virtual void IbtnAPOn()
  {
    if (this.IsPush)
      return;
    this.IbtnAPONList.ToggleOnce(0);
    this.IbtnAPOFFList.ToggleOnce(1);
    this.NotificationAp = true;
  }

  public virtual void IbtnAPOff()
  {
    if (this.IsPush)
      return;
    this.IbtnAPONList.ToggleOnce(1);
    this.IbtnAPOFFList.ToggleOnce(0);
    this.NotificationAp = false;
  }

  public virtual void IbtnBPOn()
  {
    if (this.IsPush)
      return;
    this.IbtnBPONList.ToggleOnce(0);
    this.IbtnBPOFFList.ToggleOnce(1);
    this.NotificationBp = true;
  }

  public virtual void IbtnBPOff()
  {
    if (this.IsPush)
      return;
    this.IbtnBPONList.ToggleOnce(1);
    this.IbtnBPOFFList.ToggleOnce(0);
    this.NotificationBp = false;
  }

  public void IbtnPushOn()
  {
    if (this.IsPush)
      return;
    this.IbtnPushONList.ToggleOnce(0);
    this.IbtnPushOFFList.ToggleOnce(1);
    this.PushNotification = true;
  }

  public void IbtnPushOff()
  {
    if (this.IsPush)
      return;
    this.IbtnPushONList.ToggleOnce(1);
    this.IbtnPushOFFList.ToggleOnce(0);
    this.PushNotification = false;
  }

  private enum ButtonStatus
  {
    ON,
    OFF,
  }
}
