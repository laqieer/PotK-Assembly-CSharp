﻿// Decompiled with JetBrains decompiler
// Type: Bugu005382Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using SM;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Bugu005382Menu : BackButtonMenuBase
{
  private const float LINK_WIDTH = 91f;
  private const float LINK_HEIGHT = 109f;
  private const float LINK_DEFWIDTH = 114f;
  private const float LINK_DEFHEIGHT = 136f;
  private const bool NUM_ODD = false;
  private const bool NUM_EVEN = true;
  [SerializeField]
  private GameObject[] Dir1_linkgears;
  [SerializeField]
  private GameObject[] Dir2_linkgears;
  [SerializeField]
  private GameObject dir_Bugu_Form01;
  [SerializeField]
  private GameObject dir_Bugu_Form02;
  [SerializeField]
  public UIButton yesButton;
  [SerializeField]
  private UILabel lblTitle;
  [SerializeField]
  private UILabel lblDisprict;
  private List<PlayerItem> _playerGears = new List<PlayerItem>();
  private int addNum;

  public List<PlayerItem> playerGears
  {
    get => this._playerGears;
    set => this._playerGears = value;
  }

  [DebuggerHidden]
  public IEnumerator ChangeSprite(List<PlayerItem> gears)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu005382Menu.\u003CChangeSprite\u003Ec__Iterator3A0()
    {
      gears = gears,
      \u003C\u0024\u003Egears = gears,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator SetIcon(List<PlayerItem> gears, GameObject iconPrefab, bool evenFlag)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu005382Menu.\u003CSetIcon\u003Ec__Iterator3A1()
    {
      gears = gears,
      evenFlag = evenFlag,
      iconPrefab = iconPrefab,
      \u003C\u0024\u003Egears = gears,
      \u003C\u0024\u003EevenFlag = evenFlag,
      \u003C\u0024\u003EiconPrefab = iconPrefab,
      \u003C\u003Ef__this = this
    };
  }

  public void ChangeText0058()
  {
    this.lblTitle.text = this.lblTitle.text.Replace(Consts.GetInstance().GEAR_0052_COMPOSITE_TITLE, Consts.GetInstance().GEAR_0052_PAKUPAKU_TITLE);
    this.lblDisprict.text = this.lblDisprict.text.Replace(Consts.GetInstance().GEAR_0052_COMPOSITE, Consts.GetInstance().GEAR_0052_PAKUPAKU);
  }

  public void ChangeText00510()
  {
    this.lblTitle.SetTextLocalize(Consts.GetInstance().GEAR_00510_RECIPE_TITLE);
    this.lblDisprict.SetTextLocalize(Consts.GetInstance().GEAR_00510_PECIPE);
  }

  public void IbtnNo()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().onDismiss();
  }

  public override void onBackButton() => this.IbtnNo();
}
