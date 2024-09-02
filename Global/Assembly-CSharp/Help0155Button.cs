// Decompiled with JetBrains decompiler
// Type: Help0155Button
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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
  private BackButtonMenuBase _baseMenu;
  private List<BeginnerNaviTitle> naviTitles = new List<BeginnerNaviTitle>();

  public void init(BackButtonMenuBase baseMenu) => this._baseMenu = baseMenu;

  public void setNaviText(BeginnerNaviCategory bnCategory, bool isContact)
  {
    if (isContact)
    {
      this.btnContact.gameObject.SetActive(true);
      this.btnHelp.gameObject.SetActive(false);
    }
    else
    {
      this.btnContact.gameObject.SetActive(false);
      this.btnHelp.gameObject.SetActive(true);
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
