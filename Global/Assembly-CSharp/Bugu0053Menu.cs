// Decompiled with JetBrains decompiler
// Type: Bugu0053Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Bugu0053Menu : BackButtonMenuBase
{
  private const int DEPTH = 12;
  private const int RARITY_WARNING = 3;
  private const int SELECT_MIN = 2;
  private const int SELECT_MAX = 5;
  [SerializeField]
  protected GameObject[] iconParent;
  [SerializeField]
  protected GameObject[] dir_Add;
  [SerializeField]
  protected GameObject dirPageSilver;
  [SerializeField]
  protected GameObject dirPageGold;
  [SerializeField]
  protected GameObject dirPageRainbow;
  [SerializeField]
  protected GameObject dirRecipe;
  [SerializeField]
  protected UILabel TxtComposite;
  [SerializeField]
  protected UILabel TxtNeededzenie;
  [SerializeField]
  protected UILabel TxtZenie;
  [SerializeField]
  protected UILabel TxtTitle;
  [SerializeField]
  protected GameObject DirRecipeName;
  [SerializeField]
  protected UILabel TxtRecipeName;
  [SerializeField]
  protected GameObject IbtnRecipeObject;
  private bool ViewButtonFlag;
  private bool isInit;
  private ItemIcon gearScript;
  private List<PlayerItem> SendGears = new List<PlayerItem>();
  private List<InventoryItem> playerGears = new List<InventoryItem>();
  private PlayerItem newItem = new PlayerItem();
  public GameObject itemIconPrefab;
  private GameObject recipePopupPrefab;
  private Player playerData;

  [DebuggerHidden]
  public IEnumerator InitGearsSynthesis(List<InventoryItem> playerGears, Player player)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu0053Menu.\u003CInitGearsSynthesis\u003Ec__Iterator320()
    {
      playerGears = playerGears,
      player = player,
      \u003C\u0024\u003EplayerGears = playerGears,
      \u003C\u0024\u003Eplayer = player,
      \u003C\u003Ef__this = this
    };
  }

  public void SetRecipeInfo(List<InventoryItem> gears, string recipeName)
  {
    this.DestroySelectIcon();
    this.InitAddButton();
    this.StartCoroutine(this.CreateMaterialList(gears));
    this.SetZenie();
    this.DirRecipeName.SetActive(true);
    this.TxtRecipeName.SetTextLocalize(recipeName);
  }

  [DebuggerHidden]
  public IEnumerator CreateMaterialList(List<InventoryItem> gears)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu0053Menu.\u003CCreateMaterialList\u003Ec__Iterator321()
    {
      gears = gears,
      \u003C\u0024\u003Egears = gears,
      \u003C\u003Ef__this = this
    };
  }

  public void SetZenie()
  {
    int total_item_level = 0;
    int total_item_rarity = 0;
    int cnt_use_gears = 0;
    this.playerGears.ForEach((Action<InventoryItem>) (item =>
    {
      if (item.Item.gear == null)
        return;
      total_item_level += item.Item.gear.compose_level;
      total_item_rarity += item.Item.gear.rarity.index;
      ++cnt_use_gears;
    }));
    if (cnt_use_gears < 1)
      cnt_use_gears = 1;
    int index = total_item_rarity / cnt_use_gears - 1;
    if (index < 0)
      index = 0;
    this.TxtZenie.SetTextLocalize((int) ((double) (total_item_level * 50) * (double) GearRarity.ComposeRatio(index)));
  }

  public virtual void IbtnBack()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().closeAll();
    this.backScene();
  }

  public override void onBackButton() => this.IbtnBack();

  public virtual void IbtnStartComposite()
  {
    if (this.IsPushAndSet())
      return;
    this.StartCoroutine(this.StartComposite());
  }

  public void IbtnRecipe()
  {
    if (this.IsPushAndSet())
      return;
    this.StartCoroutine(this.OpenRecipePopup());
  }

  [DebuggerHidden]
  public IEnumerator OpenRecipePopup()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu0053Menu.\u003COpenRecipePopup\u003Ec__Iterator322()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void recipeDisable() => this.dirRecipe.SetActive(false);

  private void InitAddButton()
  {
    for (int index = 0; index < 5; ++index)
      this.dir_Add[index].SetActive(false);
  }

  private void InitIcon(int count)
  {
    for (int index = count; index < 5; ++index)
    {
      this.dir_Add[index].SetActive(false);
      if (!this.ViewButtonFlag)
      {
        this.dir_Add[index].SetActive(true);
        this.ViewButtonFlag = true;
      }
    }
  }

  private void DestroySelectIcon()
  {
    foreach (GameObject gameObject in this.iconParent)
      ((IEnumerable<ItemIcon>) gameObject.GetComponentsInChildren<ItemIcon>()).ForEach<ItemIcon>((Action<ItemIcon>) (x => Object.Destroy((Object) ((Component) x).gameObject)));
  }

  [DebuggerHidden]
  private IEnumerator StartComposite()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu0053Menu.\u003CStartComposite\u003Ec__Iterator323()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void CompositeAPIEvent()
  {
    if (this.playerGears.Count >= 2)
      this.StartCoroutine(this.CompositeAPI());
    else
      this.StartCoroutine(PopupCommon.Show(Consts.Lookup("POPUP_005_GEAR_WARNING_TITLE", (IDictionary) new Hashtable()
      {
        {
          (object) "type",
          (object) Consts.Lookup("GEAR_0052_COMPOSITE")
        }
      }), Consts.Lookup("POPUP_005_COMPOSITE_WARNING_MESSAGE")));
  }

  [DebuggerHidden]
  public IEnumerator CompositeAPI()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu0053Menu.\u003CCompositeAPI\u003Ec__Iterator324()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void SelectGear()
  {
    if (this.IsPush)
      return;
    Singleton<PopupManager>.GetInstance().closeAll();
    Bugu0052Scene.changeSceneComposite(false, true, this.SendGears);
  }

  public void onEndScene()
  {
    this.ViewButtonFlag = false;
    this.playerGears.Clear();
  }
}
