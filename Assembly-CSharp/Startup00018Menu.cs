// Decompiled with JetBrains decompiler
// Type: Startup00018Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

public class Startup00018Menu : NGMenuBase
{
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
  private const int CODE_LENGTH = 8;

  private void Start()
  {
    this.EMail.caretColor = Color.black;
    this.Passcode.caretColor = Color.black;
  }

  public void InitDataCode()
  {
    this.EMail.value = "";
    this.Passcode.value = "";
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
    if (!string.IsNullOrEmpty(this.EMail.value) && !string.IsNullOrEmpty(this.Passcode.value))
    {
      WebAPI.AuthFgGIDMigrate(this.EMail.value, this.Passcode.value, (System.Action) (() =>
      {
        Singleton<NGSoundManager>.GetInstance().playSE("SE_1006");
        this.SuccesPopup.SetActive(true);
        this.ClearGuildData();
        this.DeleteUserInfoData();
        this.DeleteDeckInfoData();
        this.DeleteEarthData();
      }), (System.Action<string, int>) ((error, seconds) => this.ErrorPopup(error, seconds)));
    }
    else
    {
      Singleton<NGSoundManager>.GetInstance().playSE("SE_1006");
      this.CodeError.SetActive(true);
    }
  }

  private void ErrorPopup(string errorCode, int seconds)
  {
    string errorCode1 = errorCode.Split(new char[1]{ '\n' }, StringSplitOptions.None)[0].ToString();
    GameObject gameObject;
    if (!(errorCode1 == "ASE015") && !(errorCode1 == "ASE103") && !(errorCode1 == "Locked Device"))
    {
      if (errorCode1 == "ASE102" || errorCode1 == "Missing DEVICE_ID")
      {
        gameObject = this.SameTerminal;
      }
      else
      {
        gameObject = this.CodeError;
        this.CodeError.GetComponent<Transfer01289Menu>().ChangeDescription(errorCode1);
      }
    }
    else
    {
      gameObject = this.InputBlock;
      DateTime blockTime = DateTime.Now.AddSeconds((double) seconds);
      gameObject.GetComponent<Transfer012811Menu>().ChangeDescription(blockTime, true);
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

  private void DeleteDeckInfoData()
  {
    Persist.customDeckTutorial.DeleteAndClear();
    Persist.deckOrganized.DeleteAndClear();
    Persist.seaDeckOrganized.DeleteAndClear();
    Persist.colosseumDeckOrganized.DeleteAndClear();
    Persist.versusDeckOrganized.DeleteAndClear();
    Persist.guildRaidLastSortie.DeleteAndClear();
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
