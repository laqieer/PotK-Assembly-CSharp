// Decompiled with JetBrains decompiler
// Type: Help0156Button
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
  private string webLink;

  public void init(BackButtonMenuBase baseMenu) => this._baseMenu = baseMenu;

  [DebuggerHidden]
  public IEnumerator setTitleText(BeginnerNaviTitle bnTitle)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Help0156Button.\u003CsetTitleText\u003Ec__Iterator5D1()
    {
      bnTitle = bnTitle,
      \u003C\u0024\u003EbnTitle = bnTitle,
      \u003C\u003Ef__this = this
    };
  }

  public void IbtnHelp()
  {
    if (!string.IsNullOrEmpty(this.webLink))
    {
      if (this._baseMenu.IsPush)
        return;
      this.toLink(this.webLink);
    }
    else
    {
      if (this._baseMenu.IsPushAndSet())
        return;
      Singleton<PopupManager>.GetInstance().open(this.popup).GetComponent<Popup0156Menu>().InitPopup(this.detail, this.descSprite, this.questionPrefab, this.answerPrefab);
    }
  }

  private void toLink(string url) => Application.OpenURL(url);
}
