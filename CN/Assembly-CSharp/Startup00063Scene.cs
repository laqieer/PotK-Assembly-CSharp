﻿// Decompiled with JetBrains decompiler
// Type: Startup00063Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
    DeviceManager.LaunchMailer(Consts.GetInstance().HELP_CONTACT_ADDRESS, Consts.GetInstance().HELP_CONTACT_TITLE, Consts.Format(Consts.GetInstance().HELP_CONTACT_MAIL_BODY, (IDictionary) new Hashtable()
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
    Singleton<LuaHotFixMgr>.GetInstance().RefreshUsingLua();
  }

  private void Start() => Singleton<LuaHotFixMgr>.GetInstance().RefreshUsingLua();
}
