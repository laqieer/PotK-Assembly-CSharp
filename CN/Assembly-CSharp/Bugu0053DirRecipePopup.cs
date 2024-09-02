// Decompiled with JetBrains decompiler
// Type: Bugu0053DirRecipePopup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using MasterDataTable;
using SM;
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
  private List<GearCombineRecipe> gearRecipes = new List<GearCombineRecipe>();
  public bool isBackKey = true;
  private List<GameObject> recipeObjs = new List<GameObject>();
  private Bugu0053DirRecipeListPrefabs recipeListPopupPrefabs;

  [DebuggerHidden]
  public IEnumerator Init(
    Action<List<InventoryItem>, string> buttonEvent,
    GameObject itemIconPrefab,
    IEnumerable<GearCombineRecipe> gearRecipes,
    Dictionary<int, List<PlayerItem>> playerGearDic,
    Dictionary<int, List<PlayerItem>> playerGearDicDescending)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu0053DirRecipePopup.\u003CInit\u003Ec__Iterator380()
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
    return (IEnumerator) new Bugu0053DirRecipePopup.\u003CBackKeyEnable\u003Ec__Iterator381()
    {
      \u003C\u003Ef__this = this
    };
  }

  public override void onBackButton() => this.IbtnClose();
}
