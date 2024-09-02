// Decompiled with JetBrains decompiler
// Type: Bugu0053DirRecipePopup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using MasterDataTable;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Bugu0053DirRecipePopup : BackButtonMenuBase
{
  [SerializeField]
  protected NGxScroll2 ScrollContainer;
  public bool isBackKey = true;
  private List<GameObject> recipeObjs = new List<GameObject>();
  private Bugu0053DirRecipeListPrefabs recipeListPopupPrefabs;

  [DebuggerHidden]
  public IEnumerator Init(
    Action<List<InventoryItem>, string> buttonEvent,
    GameObject itemIconPrefab,
    IEnumerable<GearCombineRecipe> gearRecipes,
    Dictionary<int, Tuple<List<GameCore.ItemInfo>, int>> playerGearDic,
    Dictionary<int, Tuple<List<GameCore.ItemInfo>, int>> playerGearDicDescending)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu0053DirRecipePopup.\u003CInit\u003Ec__Iterator3C1()
    {
      gearRecipes = gearRecipes,
      buttonEvent = buttonEvent,
      playerGearDic = playerGearDic,
      playerGearDicDescending = playerGearDicDescending,
      itemIconPrefab = itemIconPrefab,
      \u003C\u0024\u003EgearRecipes = gearRecipes,
      \u003C\u0024\u003EbuttonEvent = buttonEvent,
      \u003C\u0024\u003EplayerGearDic = playerGearDic,
      \u003C\u0024\u003EplayerGearDicDescending = playerGearDicDescending,
      \u003C\u0024\u003EitemIconPrefab = itemIconPrefab,
      \u003C\u003Ef__this = this
    };
  }

  public void IbtnClose()
  {
    if (this.IsPush)
      return;
    ((Component) this).gameObject.GetComponent<NGTweenParts>().isActive = false;
  }

  [DebuggerHidden]
  public IEnumerator BackKeyEnable()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu0053DirRecipePopup.\u003CBackKeyEnable\u003Ec__Iterator3C2()
    {
      \u003C\u003Ef__this = this
    };
  }

  public override void onBackButton() => this.IbtnClose();
}
