// Decompiled with JetBrains decompiler
// Type: Bugu0053Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
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
  private List<GameCore.ItemInfo> SendGears = new List<GameCore.ItemInfo>();
  private List<InventoryItem> playerGears = new List<InventoryItem>();
  public GameObject itemIconPrefab;

  [DebuggerHidden]
  public IEnumerator InitGearsSynthesis(List<InventoryItem> playerGears, Player player)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu0053Menu.\u003CInitGearsSynthesis\u003Ec__Iterator3C6()
    {
      playerGears = playerGears,
      \u003C\u0024\u003EplayerGears = playerGears,
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
    return (IEnumerator) new Bugu0053Menu.\u003CCreateMaterialList\u003Ec__Iterator3C7()
    {
      gears = gears,
      \u003C\u0024\u003Egears = gears,
      \u003C\u003Ef__this = this
    };
  }

  public void SetZenie()
  {
    this.TxtZenie.SetTextLocalize(CalcItemCost.GetCompositeCost(this.playerGears));
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
    Bugu00510Scene.changeSceneRecipe(true);
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
    return (IEnumerator) new Bugu0053Menu.\u003CStartComposite\u003Ec__Iterator3C8()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void CompositeAPIEvent()
  {
    if (this.playerGears.Count >= 2)
      this.StartCoroutine(this.CompositeAPI());
    else
      this.StartCoroutine(PopupCommon.Show(Consts.Format(Consts.GetInstance().POPUP_005_GEAR_WARNING_TITLE, (IDictionary) new Hashtable()
      {
        {
          (object) "type",
          (object) Consts.GetInstance().GEAR_0052_COMPOSITE
        }
      }), Consts.Format(Consts.GetInstance().POPUP_005_COMPOSITE_WARNING_MESSAGE)));
  }

  [DebuggerHidden]
  public IEnumerator CompositeAPI()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu0053Menu.\u003CCompositeAPI\u003Ec__Iterator3C9()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void SelectGear()
  {
    if (this.IsPush)
      return;
    Singleton<PopupManager>.GetInstance().closeAll();
    Debug.LogWarning((object) ("SendGears:" + (object) this.SendGears.Count));
    Bugu00521Scene.ChangeScene(false, this.SendGears);
  }

  public void onEndScene()
  {
    this.ViewButtonFlag = false;
    this.playerGears.Clear();
  }
}
