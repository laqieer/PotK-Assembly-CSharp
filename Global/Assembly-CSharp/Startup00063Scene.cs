// Decompiled with JetBrains decompiler
// Type: Startup00063Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using gu3.Device;
using SM;
using System.Collections;
using UnityEngine;

#nullable disable
public class Startup00063Scene : MonoBehaviour
{
  [SerializeField]
  private UIRoot uiRoot;

  private void Awake() => ModalWindow.setupRootPanel(this.uiRoot);

  public void Mail()
  {
    Player player = SMManager.Get<Player>();
    DeviceManager.LaunchMailer(Consts.Lookup("HELP_CONTACT_ADDRESS"), Consts.Lookup("HELP_CONTACT_TITLE"), Consts.Lookup("HELP_CONTACT_MAIL_BODY", (IDictionary) new Hashtable()
    {
      {
        (object) "ver",
        (object) Revision.DLCVersion
      },
      {
        (object) "id",
        (object) player
      },
      {
        (object) "agent",
        (object) DeviceManager.GetUserAgent()
      }
    }));
  }
}
