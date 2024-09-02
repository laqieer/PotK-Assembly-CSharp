// Decompiled with JetBrains decompiler
// Type: Help0152Button
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using MasterDataTable;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Help0152Button : MonoBehaviour
{
  [SerializeField]
  private UILabel txtHelp01;
  private HelpHelp help;
  private GameObject popup;
  private GameObject textPrefab;
  private GameObject spritePrefab;
  private Sprite helpSprite;
  private BackButtonMenuBase _baseMenu;

  public void init(BackButtonMenuBase baseMenu) => this._baseMenu = baseMenu;

  [DebuggerHidden]
  public IEnumerator setTextHelp01(string str, HelpHelp help)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Help0152Button.\u003CsetTextHelp01\u003Ec__Iterator4D5()
    {
      help = help,
      str = str,
      \u003C\u0024\u003Ehelp = help,
      \u003C\u0024\u003Estr = str,
      \u003C\u003Ef__this = this
    };
  }

  public void IbtnHelp()
  {
    if (this._baseMenu.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().openAlert(this.popup).GetComponent<Help0153Menu>().InitHelpPopup(this.help, this.helpSprite, this.textPrefab, this.spritePrefab);
  }
}
