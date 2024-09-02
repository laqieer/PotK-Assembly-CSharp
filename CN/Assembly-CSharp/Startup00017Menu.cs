// Decompiled with JetBrains decompiler
// Type: Startup00017Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using System;
using UnityEngine;

#nullable disable
public class Startup00017Menu : NGMenuBase
{
  private const int CODE_LENGTH = 8;
  [SerializeField]
  private UILabel InpTxtboxId;
  [SerializeField]
  private UIInput IdCode;
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

  public void InitDataCode()
  {
    this.IdCode.keyboardType = UIInput.KeyboardType.ASCIICapable;
    this.IdCode.characterLimit = 8;
    this.IdCode.value = string.Empty;
  }

  private void Update()
  {
    if (this.IdCode.value.Length < 8)
      this.DecideBtn.isEnabled = false;
    else
      this.DecideBtn.isEnabled = true;
  }

  public void MigrateAPI()
  {
    if (this.IdCode.value.Length == 8)
      WebAPI.AuthMigrate(this.IdCode.value, (System.Action) (() =>
      {
        this.SuccesPopup.SetActive(true);
        this.ClearGuildData();
        this.DeleteUserInfoData();
      }), (Action<string, int>) ((error, seconds) => this.ErrorPopup(error, seconds)));
    else
      this.CodeError.SetActive(true);
  }

  private void ErrorPopup(string errorCode, int seconds)
  {
    string str = errorCode.Split(new char[1]{ '\n' }, StringSplitOptions.None)[0].ToString();
    GameObject gameObject;
    if (str.Equals(Consts.GetInstance().Missing_PASSCODE))
      gameObject = this.CodeError;
    else if (str.Equals(Consts.GetInstance().Locked_PASSCODE))
    {
      gameObject = this.InputBlock;
      DateTime blockTime = DateTime.Now.AddSeconds((double) seconds);
      gameObject.GetComponent<Transfer012811Menu>().ChangeDescription(blockTime);
    }
    else if (str.Equals(Consts.GetInstance().Missing_DEVICE_ID))
    {
      gameObject = this.SameTerminal;
    }
    else
    {
      Debug.LogError((object) ("unknonw error code=" + str));
      return;
    }
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
}
