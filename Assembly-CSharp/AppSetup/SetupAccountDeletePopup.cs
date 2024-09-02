// Decompiled with JetBrains decompiler
// Type: AppSetup.SetupAccountDeletePopup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using DeviceKit;
using GameCore;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AppSetup
{
  public class SetupAccountDeletePopup : MonoBehaviour
  {
    [SerializeField]
    private UIButton cancelButton;
    [SerializeField]
    private UIButton nextButton;

    public void IbtnCancel() => Singleton<PopupManager>.GetInstance().onDismiss();

    public void IbtnAccountDeleteNext()
    {
      string helpContactAddress = Consts.GetInstance().HELP_CONTACT_ADDRESS;
      string subject = Consts.Format(Consts.GetInstance().ACCOUNT_DELETE_TITLE, (IDictionary) new Dictionary<string, string>()
      {
        {
          "short_id",
          Persist.userInfo.Data.userId
        }
      });
      string str = string.Format("{0}/{1}/{2}/{3}/{4}", (object) Gsc.Device.DeviceInfo.DeviceModel, (object) Gsc.Device.DeviceInfo.DeviceVendor, (object) Gsc.Device.DeviceInfo.OperatingSystem, (object) Gsc.Device.DeviceInfo.ProcessorType, (object) Gsc.Device.DeviceInfo.SystemMemorySize);
      string body = Consts.Format(Consts.GetInstance().ACCOUNT_DELETE_MAIL_BODY, (IDictionary) new Dictionary<string, string>()
      {
        {
          "ver",
          Application.version
        },
        {
          "short_id",
          Persist.userInfo.Data.userId
        },
        {
          "agent",
          str
        }
      }).Replace("\n", "%0A");
      App.LaunchMailer(helpContactAddress, subject, body);
    }
  }
}
