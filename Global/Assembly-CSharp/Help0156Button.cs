// Decompiled with JetBrains decompiler
// Type: Help0156Button
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using MasterDataTable;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Help0156Button : MonoBehaviour
{
  [SerializeField]
  private UILabel txtHelp01;
  [SerializeField]
  private string[] answerPrefabs;
  private BeginnerNaviDetail detail;
  private GameObject popup;
  private GameObject questionPrefab;
  private GameObject answerPrefab;
  private Sprite descSprite;
  private BackButtonMenuBase _baseMenu;

  public void init(BackButtonMenuBase baseMenu) => this._baseMenu = baseMenu;

  [DebuggerHidden]
  public IEnumerator setTitleText(BeginnerNaviTitle bnTitle)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Help0156Button.\u003CsetTitleText\u003Ec__Iterator4DC()
    {
      bnTitle = bnTitle,
      \u003C\u0024\u003EbnTitle = bnTitle,
      \u003C\u003Ef__this = this
    };
  }

  public void IbtnHelp()
  {
    if (this._baseMenu.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().open(this.popup).GetComponent<Popup0156Menu>().InitPopup(this.detail, this.descSprite, this.questionPrefab, this.answerPrefab);
  }
}
