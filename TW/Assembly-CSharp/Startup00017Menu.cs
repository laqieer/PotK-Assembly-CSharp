// Decompiled with JetBrains decompiler
// Type: Startup00017Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class Startup00017Menu : NGMenuBase
{
  private const int CODE_LENGTH = 8;
  [SerializeField]
  private UIInput inputID;
  [SerializeField]
  private UIInput inputPassword;
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
  [SerializeField]
  private GameObject Unknown;

  private void Start() => this.DecideBtn.isEnabled = false;

  public void InitDataCode()
  {
    this.inputID.keyboardType = UIInput.KeyboardType.ASCIICapable;
    this.inputID.value = string.Empty;
  }

  public void OnCahnge()
  {
    if (string.IsNullOrEmpty(this.inputID.value) || !string.IsNullOrEmpty(this.inputID.value) && this.inputID.value.Length < 1 || string.IsNullOrEmpty(this.inputPassword.value) || !string.IsNullOrEmpty(this.inputPassword.value) && this.inputPassword.value.Length < 8)
      this.DecideBtn.isEnabled = false;
    else
      this.DecideBtn.isEnabled = true;
  }

  public void MigrateAPI()
  {
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
