// Decompiled with JetBrains decompiler
// Type: Help0155Button
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using MasterDataTable;
using System;
using System.Collections.Generic;
using UniLinq;
using UnityEngine;

#nullable disable
public class Help0155Button : MonoBehaviour
{
  [SerializeField]
  private UILabel txtHelp01;
  [SerializeField]
  private GameObject btnHelp;
  [SerializeField]
  private GameObject btnContact;
  public UIButton button;
  private BackButtonMenuBase _baseMenu;
  private List<BeginnerNaviTitle> naviTitles = new List<BeginnerNaviTitle>();

  public void init(BackButtonMenuBase baseMenu) => this._baseMenu = baseMenu;

  public void setNaviText(BeginnerNaviCategory bnCategory, bool isContact)
  {
    if (isContact)
    {
      this.btnContact.gameObject.SetActive(true);
      this.btnHelp.gameObject.SetActive(false);
      this.button = this.btnContact.GetComponent<UIButton>();
    }
    else
    {
      this.btnContact.gameObject.SetActive(false);
      this.btnHelp.gameObject.SetActive(true);
      this.button = this.btnHelp.GetComponent<UIButton>();
    }
    this.txtHelp01.SetTextLocalize(bnCategory.name);
    this.naviTitles = ((IEnumerable<BeginnerNaviTitle>) MasterData.BeginnerNaviTitleList).Where<BeginnerNaviTitle>((Func<BeginnerNaviTitle, bool>) (x => x.category.ID == bnCategory.ID)).OrderBy<BeginnerNaviTitle, int>((Func<BeginnerNaviTitle, int>) (x => x.priority)).ToList<BeginnerNaviTitle>();
  }

  public void IbtnHelp()
  {
    if (this._baseMenu.IsPushAndSet())
      return;
    Singleton<NGSceneManager>.GetInstance().changeScene("help015_6", true, (object) this.naviTitles);
  }
}
