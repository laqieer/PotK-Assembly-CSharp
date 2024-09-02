// Decompiled with JetBrains decompiler
// Type: Startup00018Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class Startup00018Menu : NGMenuBase
{
  private const int CODE_LENGTH = 8;
  [SerializeField]
  private UIInput EMail;
  [SerializeField]
  private UIInput Passcode;
  [SerializeField]
  private UIButton DecideBtn;
  [SerializeField]
  private GameObject SuccesPopup;
  [SerializeField]
  private GameObject CodeError;
  [SerializeField]
  private GameObject InputBlock;
  [SerializeField]
  private GameObject SameTerminal;

  private void Start()
  {
  }

  public void InitDataCode()
  {
    this.EMail.value = string.Empty;
    this.Passcode.value = string.Empty;
  }

  private void Update()
  {
    if (string.IsNullOrEmpty(this.EMail.value) || string.IsNullOrEmpty(this.Passcode.value))
      this.DecideBtn.isEnabled = false;
    else
      this.DecideBtn.isEnabled = true;
  }

  public void FgGIDMigrateAPI()
  {
  }

  private void ErrorPopup(string errorCode, int seconds)
  {
    string errorCode1 = errorCode.Split(new char[1]{ '\n' }, StringSplitOptions.None)[0].ToString();
    string key = errorCode1;
    GameObject gameObject;
    if (key != null)
    {
      // ISSUE: reference to a compiler-generated field
      if (Startup00018Menu.\u003C\u003Ef__switch\u0024map14 == null)
      {
        // ISSUE: reference to a compiler-generated field
        Startup00018Menu.\u003C\u003Ef__switch\u0024map14 = new Dictionary<string, int>(5)
        {
          {
            "ASE015",
            0
          },
          {
            "ASE103",
            0
          },
          {
            "Locked Device",
            0
          },
          {
            "ASE102",
            1
          },
          {
            "Missing DEVICE_ID",
            1
          }
        };
      }
      int num;
      // ISSUE: reference to a compiler-generated field
      if (Startup00018Menu.\u003C\u003Ef__switch\u0024map14.TryGetValue(key, out num))
      {
        switch (num)
        {
          case 0:
            gameObject = this.InputBlock;
            DateTime blockTime = DateTime.Now.AddSeconds((double) seconds);
            gameObject.GetComponent<Transfer012811Menu>().ChangeDescription(blockTime, true);
            goto label_8;
          case 1:
            gameObject = this.SameTerminal;
            goto label_8;
        }
      }
    }
    gameObject = this.CodeError;
    this.CodeError.GetComponent<Transfer01289Menu>().ChangeDescription(errorCode1);
label_8:
    gameObject.SetActive(true);
  }

  private void ClearGuildData()
  {
    if (!Persist.guildSetting.Exists)
      return;
    Persist.guildSetting.Data.reset();
    Persist.guildSetting.Flush();
  }

  private void DeleteUserInfoData()
  {
    if (!Persist.userInfo.Exists)
      return;
    Persist.userInfo.Delete();
  }

  private void DeleteEarthData()
  {
    if (Persist.earthData.Exists)
      Persist.earthData.Delete();
    if (!Persist.earthBattleEnvironment.Exists)
      return;
    Persist.earthBattleEnvironment.Delete();
  }
}
