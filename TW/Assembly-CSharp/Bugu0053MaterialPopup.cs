﻿// Decompiled with JetBrains decompiler
// Type: Bugu0053MaterialPopup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using MasterDataTable;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Bugu0053MaterialPopup : BackButtonMenuBase
{
  [SerializeField]
  private UILabel TxtMaterialName;
  [SerializeField]
  private UILabel TxtMaterialNum;
  [SerializeField]
  private UILabel TxtRankNeed;
  [SerializeField]
  private UILabel[] TxtQuestName;
  [SerializeField]
  private GameObject IconMaterial;
  [SerializeField]
  private UISprite[] LineQuest;
  private Bugu0053DirRecipePopup root;
  private List<string> gearDescriptions = new List<string>();

  [DebuggerHidden]
  public IEnumerator Init(
    Bugu0053DirRecipePopup recipePopup,
    GearGear gear,
    GameObject ItemIconPrefab,
    int quantity,
    int requestRank)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu0053MaterialPopup.\u003CInit\u003Ec__Iterator3C5()
    {
      recipePopup = recipePopup,
      gear = gear,
      quantity = quantity,
      requestRank = requestRank,
      ItemIconPrefab = ItemIconPrefab,
      \u003C\u0024\u003ErecipePopup = recipePopup,
      \u003C\u0024\u003Egear = gear,
      \u003C\u0024\u003Equantity = quantity,
      \u003C\u0024\u003ErequestRank = requestRank,
      \u003C\u0024\u003EItemIconPrefab = ItemIconPrefab,
      \u003C\u003Ef__this = this
    };
  }

  public void IbtnNo()
  {
    if (Object.op_Inequality((Object) this.root, (Object) null))
      Singleton<CommonRoot>.GetInstance().StartCoroutine(this.root.BackKeyEnable());
    Singleton<PopupManager>.GetInstance().onDismiss();
  }

  public override void onBackButton() => this.IbtnNo();
}
