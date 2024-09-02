// Decompiled with JetBrains decompiler
// Type: RestoreRequestMailLauncher
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using gu3.Device;
using System.Collections;
using UnityEngine;

#nullable disable
public class RestoreRequestMailLauncher : MonoBehaviour
{
  private bool paused;
  private string address;
  [SerializeField]
  private UILabel infoLabel;
  [SerializeField]
  private UIScrollView scrollView;
  [SerializeField]
  private bool resetPosition;

  private void Awake()
  {
    if (Object.op_Equality((Object) this.infoLabel, (Object) null))
      return;
    this.address = Consts.Lookup("RESTORE_REQUEST_ADDRESS");
    this.infoLabel.text = string.Format("{0}\n\n[u][b][url={1}]{1}[/url][/b][/u]\n\n{2}", (object) Consts.Lookup("UI_TITLE_RESTORE_INFO_TOP"), (object) this.address, (object) Consts.Lookup("UI_TITLE_RESTORE_INFO_BOTTOM"));
    if (!Object.op_Inequality((Object) this.scrollView, (Object) null))
      return;
    this.scrollView.ResetPosition();
  }

  private void OnClick()
  {
    string urlAtPosition = this.infoLabel.GetUrlAtPosition(((RaycastHit) ref UICamera.lastHit).point);
    if (urlAtPosition == null || !urlAtPosition.Equals(this.address) || this.paused)
      return;
    this.paused = true;
    DeviceManager.LaunchMailer(this.address, Consts.Lookup("RESTORE_REQUEST_TITLE"), Consts.Lookup("RESTORE_REQUEST_MAIL_BODY", (IDictionary) new Hashtable()
    {
      {
        (object) "agent",
        (object) DeviceManager.GetUserAgent()
      }
    }));
  }

  private void OnApplicationPause(bool pauseStatus) => this.paused = pauseStatus;
}
