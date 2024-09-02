// Decompiled with JetBrains decompiler
// Type: Startup00017Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
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
      WebAPI.AuthMigrate(this.IdCode.value, (System.Action) (() => this.SuccesPopup.SetActive(true)), (Action<string, int>) ((error, seconds) => this.ErrorPopup(error, seconds)));
    else
      this.CodeError.SetActive(true);
  }

  private void ErrorPopup(string errorCode, int seconds)
  {
    string str = errorCode.Split(new char[1]{ '\n' }, StringSplitOptions.None)[0].ToString();
    string key = str;
    if (key != null)
    {
      // ISSUE: reference to a compiler-generated field
      if (Startup00017Menu.\u003C\u003Ef__switch\u0024map15 == null)
      {
        // ISSUE: reference to a compiler-generated field
        Startup00017Menu.\u003C\u003Ef__switch\u0024map15 = new Dictionary<string, int>(3)
        {
          {
            "パスコードが誤っている",
            0
          },
          {
            "入力誤り回数が三回を超えている",
            1
          },
          {
            "移行元と移行先が同一端末",
            2
          }
        };
      }
      int num;
      // ISSUE: reference to a compiler-generated field
      if (Startup00017Menu.\u003C\u003Ef__switch\u0024map15.TryGetValue(key, out num))
      {
        GameObject gameObject;
        switch (num)
        {
          case 0:
            gameObject = this.CodeError;
            break;
          case 1:
            gameObject = this.InputBlock;
            DateTime blockTime = DateTime.Now.AddSeconds((double) seconds);
            gameObject.GetComponent<Transfer012811Menu>().ChangeDescription(blockTime);
            break;
          case 2:
            gameObject = this.SameTerminal;
            break;
          default:
            goto label_8;
        }
        gameObject.SetActive(true);
        return;
      }
    }
label_8:
    Debug.LogError((object) ("unknonw error code=" + str));
  }
}
