// Decompiled with JetBrains decompiler
// Type: Help0151Button
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using MasterDataTable;
using System;
using System.Collections.Generic;
using UniLinq;
using UnityEngine;

#nullable disable
public class Help0151Button : MonoBehaviour
{
  [SerializeField]
  private UILabel txtHelp01;
  [SerializeField]
  private GameObject btnHelp;
  [SerializeField]
  private GameObject btnContact;
  public UIButton button;
  private BackButtonMenuBase _baseMenu;
  private List<HelpHelp> subCategory = new List<HelpHelp>();

  public void init(BackButtonMenuBase baseMenu) => this._baseMenu = baseMenu;

  public void setTextHelp01(HelpCategory helpCategory, bool isContact)
  {
    HelpHelp[] helpHelpList = MasterData.HelpHelpList;
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
    this.txtHelp01.SetTextLocalize(helpCategory.name);
    this.subCategory = ((IEnumerable<HelpHelp>) helpHelpList).Where<HelpHelp>((Func<HelpHelp, bool>) (x => x.category_HelpCategory == helpCategory.ID)).OrderByDescending<HelpHelp, int>((Func<HelpHelp, int>) (x => x.priority)).ToList<HelpHelp>();
  }

  public void setTextHelp01(string title, bool isContact)
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
    this.txtHelp01.SetTextLocalize(title);
  }

  public void IbtnHelp()
  {
    if (this._baseMenu.IsPushAndSet())
      return;
    Help0152Scene.ChangeScene(true, this.subCategory);
  }
}
