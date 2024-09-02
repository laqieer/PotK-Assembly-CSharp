// Decompiled with JetBrains decompiler
// Type: Bugu00510Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class Bugu00510Menu : BackButtonMenuBase
{
  [SerializeField]
  private UIScrollView ScrollView;
  private readonly Bugu00510Menu.SortType[] sortTypes = new Bugu00510Menu.SortType[3]
  {
    Bugu00510Menu.SortType.Recommend,
    Bugu00510Menu.SortType.Category,
    Bugu00510Menu.SortType.Rarity
  };
  [SerializeField]
  private NGxScroll2 scroll;
  [SerializeField]
  private GameObject[] SortLabel;
  [SerializeField]
  private GameObject recipeRoot;
  private List<Bugu00510Menu.RecipeData> recipeDataList;
  private List<ItemIcon> allItemIcon = new List<ItemIcon>();
  private int sortIndex;
  private float scroolStartY;
  private bool isInitialize;
  private GameObject recipePopupPrefab;
  private GameObject kakuninnPopupPrefab;
  private GameObject itemIconPrefab;
  private Bugu0053DirRecipePopup dirRecipe;
  private Dictionary<int, Tuple<List<GameCore.ItemInfo>, int>> playerGearDic = new Dictionary<int, Tuple<List<GameCore.ItemInfo>, int>>();
  private Dictionary<int, Tuple<List<GameCore.ItemInfo>, int>> playerGearDicDescending = new Dictionary<int, Tuple<List<GameCore.ItemInfo>, int>>();

  [DebuggerHidden]
  public IEnumerator InitAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu00510Menu.\u003CInitAsync\u003Ec__Iterator3B1()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator StartAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu00510Menu.\u003CStartAsync\u003Ec__Iterator3B2()
    {
      \u003C\u003Ef__this = this
    };
  }

  private bool CheckEnableRecipe(
    List<Tuple<int, GameCore.ItemInfo, int>> playerItemData,
    GearCombineRecipe recipe)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Bugu00510Menu.\u003CCheckEnableRecipe\u003Ec__AnonStorey1025 recipeCAnonStorey1025_1 = new Bugu00510Menu.\u003CCheckEnableRecipe\u003Ec__AnonStorey1025();
    List<Tuple<int, int>> source = new List<Tuple<int, int>>();
    source.Add(new Tuple<int, int>(recipe.material1_gear_id, !recipe.material1_gear_rank.HasValue ? 0 : recipe.material1_gear_rank.Value));
    if (recipe.material2_gear_id.HasValue)
      source.Add(new Tuple<int, int>(recipe.material2_gear_id.Value, !recipe.material2_gear_rank.HasValue ? 0 : recipe.material2_gear_rank.Value));
    if (recipe.material3_gear_id.HasValue)
      source.Add(new Tuple<int, int>(recipe.material3_gear_id.Value, !recipe.material3_gear_rank.HasValue ? 0 : recipe.material3_gear_rank.Value));
    if (recipe.material4_gear_id.HasValue)
      source.Add(new Tuple<int, int>(recipe.material4_gear_id.Value, !recipe.material4_gear_rank.HasValue ? 0 : recipe.material4_gear_rank.Value));
    if (recipe.material5_gear_id.HasValue)
      source.Add(new Tuple<int, int>(recipe.material5_gear_id.Value, !recipe.material5_gear_rank.HasValue ? 0 : recipe.material5_gear_rank.Value));
    Dictionary<int, int> dictionary1 = new Dictionary<int, int>();
    // ISSUE: reference to a compiler-generated field
    recipeCAnonStorey1025_1.usebleItemInfoList = new List<GameCore.ItemInfo>();
    foreach (Tuple<int, int> tuple1 in (IEnumerable<Tuple<int, int>>) source.OrderBy<Tuple<int, int>, int>((Func<Tuple<int, int>, int>) (x => x.Item1)).ThenBy<Tuple<int, int>, int>((Func<Tuple<int, int>, int>) (x => x.Item2)))
    {
      Tuple<int, int> part = tuple1;
      Tuple<int, GameCore.ItemInfo, int> tuple2 = playerItemData.Find((Predicate<Tuple<int, GameCore.ItemInfo, int>>) (x =>
      {
        // ISSUE: variable of a compiler-generated type
        Bugu00510Menu.\u003CCheckEnableRecipe\u003Ec__AnonStorey1025 recipeCAnonStorey1025 = recipeCAnonStorey1025_1;
        // ISSUE: variable of a compiler-generated type
        Bugu00510Menu.\u003CCheckEnableRecipe\u003Ec__AnonStorey1024 recipeCAnonStorey1024 = this;
        Tuple<int, GameCore.ItemInfo, int> x1 = x;
        return x1.Item1 == part.Item1 && x1.Item2.gearLevel >= part.Item2 && !usebleItemInfoList.Any<GameCore.ItemInfo>((Func<GameCore.ItemInfo, bool>) (y => x1.Item2 == y));
      }));
      if (tuple2 == null)
        return false;
      if (MasterData.GearGear[tuple2.Item2.masterID].isMaterial())
      {
        if (!dictionary1.ContainsKey(part.Item1))
        {
          dictionary1[part.Item1] = 1;
        }
        else
        {
          Dictionary<int, int> dictionary2;
          int key;
          (dictionary2 = dictionary1)[key = part.Item1] = dictionary2[key] + 1;
        }
        if (dictionary1[part.Item1] > tuple2.Item3)
          return false;
      }
      else
      {
        // ISSUE: reference to a compiler-generated field
        recipeCAnonStorey1025_1.usebleItemInfoList.Add(tuple2.Item2);
      }
    }
    return SMManager.Get<Player>().CheckZeny(this.SetZenie(source.Select<Tuple<int, int>, GearGear>((Func<Tuple<int, int>, GearGear>) (x => ((IEnumerable<GearGear>) MasterData.GearGearList).FirstOrDefault<GearGear>((Func<GearGear, bool>) (gear => gear.group_id == x.Item1))))));
  }

  public int SetZenie(IEnumerable<GearGear> gears)
  {
    int total_item_level = 0;
    int total_item_rarity = 0;
    int cnt_use_gears = 0;
    gears.ForEach<GearGear>((Action<GearGear>) (item =>
    {
      if (item == null)
        return;
      total_item_level += item.compose_level;
      total_item_rarity += item.rarity.index;
      ++cnt_use_gears;
    }));
    if (cnt_use_gears < 1)
      cnt_use_gears = 1;
    int index = total_item_rarity / cnt_use_gears - 1;
    if (index < 0)
      index = 0;
    NGGameDataManager.Boost boostInfo = Singleton<NGGameDataManager>.GetInstance().BoostInfo;
    return (int) ((boostInfo != null ? boostInfo.DiscountGearCombine : 1.0M) * (Decimal) total_item_level * 50M * (Decimal) GearRarity.ComposeRatio(index));
  }

  private int CheckCanMaterial(GameCore.ItemInfo gear)
  {
    int num = 0;
    if (gear.broken)
      ++num;
    if (gear.favorite)
      ++num;
    if (gear.ForBattle)
      ++num;
    return num;
  }

  private void Sort()
  {
    ((IEnumerable<GameObject>) this.SortLabel).ToggleOnce(this.sortIndex);
    switch (this.sortTypes[this.sortIndex])
    {
      case Bugu00510Menu.SortType.Recommend:
        this.recipeDataList = this.recipeDataList.OrderBy<Bugu00510Menu.RecipeData, int>((Func<Bugu00510Menu.RecipeData, int>) (x => x.priority)).ThenByDescending<Bugu00510Menu.RecipeData, int>((Func<Bugu00510Menu.RecipeData, int>) (x => x.combinedGear.rarity.index)).ThenBy<Bugu00510Menu.RecipeData, int>((Func<Bugu00510Menu.RecipeData, int>) (x => x.combinedGear.resource_reference_gear_id_GearGear)).ToList<Bugu00510Menu.RecipeData>();
        break;
      case Bugu00510Menu.SortType.Category:
        this.recipeDataList = this.recipeDataList.OrderBy<Bugu00510Menu.RecipeData, int>((Func<Bugu00510Menu.RecipeData, int>) (x => x.combinedGear.resource_reference_gear_id_GearGear)).ThenByDescending<Bugu00510Menu.RecipeData, int>((Func<Bugu00510Menu.RecipeData, int>) (x => x.combinedGear.rarity.index)).ToList<Bugu00510Menu.RecipeData>();
        break;
      case Bugu00510Menu.SortType.Rarity:
        this.recipeDataList = this.recipeDataList.OrderByDescending<Bugu00510Menu.RecipeData, int>((Func<Bugu00510Menu.RecipeData, int>) (x => x.combinedGear.rarity.index)).ThenBy<Bugu00510Menu.RecipeData, int>((Func<Bugu00510Menu.RecipeData, int>) (x => x.combinedGear.resource_reference_gear_id_GearGear)).ToList<Bugu00510Menu.RecipeData>();
        break;
    }
  }

  private void SetScrollItem()
  {
    this.scroll.Reset();
    for (int index = 0; index < Mathf.Min(ItemIcon.MaxValue, this.recipeDataList.Count); ++index)
    {
      ItemIcon itemIcon = this.allItemIcon[index];
      this.scroll.Add(((Component) itemIcon).gameObject, ItemIcon.Width, ItemIcon.Height);
      ((Component) itemIcon).gameObject.SetActive(true);
    }
    this.scroll.CreateScrollPoint(ItemIcon.Height, this.recipeDataList.Count);
    this.scroll.ResolvePosition();
  }

  [DebuggerHidden]
  private IEnumerator CreateAllIcon()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu00510Menu.\u003CCreateAllIcon\u003Ec__Iterator3B3()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void IconClicked(ItemIcon itemIcon)
  {
    if (this.IsPush)
      return;
    Singleton<CommonRoot>.GetInstance().loadingMode = 1;
    Singleton<CommonRoot>.GetInstance().isLoading = true;
    this.StartCoroutine(this.OpenRecipePopup(this.recipeDataList.FirstOrDefault<Bugu00510Menu.RecipeData>((Func<Bugu00510Menu.RecipeData, bool>) (x => Object.op_Equality((Object) x.icon, (Object) itemIcon)))));
  }

  private void GearDetail(ItemIcon itemIcon)
  {
    Bugu00510Menu.RecipeData recipeData = this.recipeDataList.FirstOrDefault<Bugu00510Menu.RecipeData>((Func<Bugu00510Menu.RecipeData, bool>) (x => Object.op_Equality((Object) x.icon, (Object) itemIcon)));
    string empty = string.Empty;
    string sceneName = recipeData.combinedGear.kind.Enum == GearKindEnum.smith ? (recipeData.combinedGear.compose_kind.kind.Enum == GearKindEnum.smith ? "guide011_4_2c" : "guide011_4_2b") : "guide011_4_2";
    Singleton<NGSceneManager>.GetInstance().changeScene(sceneName, true, (object) recipeData.combinedGear, (object) false);
  }

  [DebuggerHidden]
  private IEnumerator LoadObject()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu00510Menu.\u003CLoadObject\u003Ec__Iterator3B4()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void ScrollIconUpdate(int recipeIndex, int iconCount)
  {
    if (this.recipeDataList[recipeIndex] != null && Object.op_Equality((Object) this.recipeDataList[recipeIndex].icon, (Object) this.allItemIcon[iconCount]))
      return;
    this.recipeDataList.Where<Bugu00510Menu.RecipeData>((Func<Bugu00510Menu.RecipeData, bool>) (a => Object.op_Equality((Object) a.icon, (Object) this.allItemIcon[iconCount]))).ForEach<Bugu00510Menu.RecipeData>((Action<Bugu00510Menu.RecipeData>) (b => b.icon = (ItemIcon) null));
    this.recipeDataList[recipeIndex].icon = this.allItemIcon[iconCount];
    this.StartCoroutine(this.allItemIcon[iconCount].InitByGear(this.recipeDataList[recipeIndex].combinedGear, this.recipeDataList[recipeIndex].combinedGear.GetElement()));
    this.allItemIcon[iconCount].Gray = !this.recipeDataList[recipeIndex].isCombinEnable;
  }

  [DebuggerHidden]
  private IEnumerator OpenRecipePopup(Bugu00510Menu.RecipeData recipe)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu00510Menu.\u003COpenRecipePopup\u003Ec__Iterator3B5()
    {
      recipe = recipe,
      \u003C\u0024\u003Erecipe = recipe,
      \u003C\u003Ef__this = this
    };
  }

  public void IbtnBack()
  {
    if (this.IsPushAndSet())
      return;
    this.backScene();
  }

  public void IbtnSort()
  {
    if (this.IsPush)
      return;
    Singleton<CommonRoot>.GetInstance().loadingMode = 1;
    Singleton<CommonRoot>.GetInstance().isLoading = true;
    this.StartCoroutine("SortIcon");
  }

  [DebuggerHidden]
  private IEnumerator SortIcon()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu00510Menu.\u003CSortIcon\u003Ec__Iterator3B6()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void PushOK(List<InventoryItem> items, string str)
  {
    this.StartCoroutine(this.StartComposite(items.Select<InventoryItem, GameCore.ItemInfo>((Func<InventoryItem, GameCore.ItemInfo>) (x => x.Item)).ToList<GameCore.ItemInfo>()));
  }

  [DebuggerHidden]
  private IEnumerator StartComposite(List<GameCore.ItemInfo> sendGears)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu00510Menu.\u003CStartComposite\u003Ec__Iterator3B7()
    {
      sendGears = sendGears,
      \u003C\u0024\u003EsendGears = sendGears,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator CompositeAPI(List<GameCore.ItemInfo> sendGears)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu00510Menu.\u003CCompositeAPI\u003Ec__Iterator3B8()
    {
      sendGears = sendGears,
      \u003C\u0024\u003EsendGears = sendGears
    };
  }

  protected override void Update()
  {
    base.Update();
    if (!this.isInitialize || this.recipeDataList.Count <= ItemIcon.ScreenValue)
      return;
    int num1 = ItemIcon.Height * 2;
    float num2 = ((Component) this.scroll.scrollView).transform.localPosition.y - this.scroolStartY;
    float num3 = (float) (Mathf.Max(0, this.recipeDataList.Count - ItemIcon.ScreenValue - 1) / ItemIcon.ColumnValue * ItemIcon.Height);
    float num4 = (float) (ItemIcon.Height * ItemIcon.RowValue);
    if ((double) num2 < 0.0)
      num2 = 0.0f;
    if ((double) num2 > (double) num3)
      num2 = num3;
    bool flag;
    do
    {
      flag = false;
      int iconCount = 0;
      foreach (GameObject gameObject in this.scroll)
      {
        GameObject item = gameObject;
        float num5 = item.transform.localPosition.y + num2;
        int? nullable = this.recipeDataList.FirstIndexOrNull<Bugu00510Menu.RecipeData>((Func<Bugu00510Menu.RecipeData, bool>) (v => Object.op_Inequality((Object) v.icon, (Object) null) && Object.op_Equality((Object) ((Component) v.icon).gameObject, (Object) item)));
        if ((double) num5 > (double) num1)
        {
          item.transform.localPosition = new Vector3(item.transform.localPosition.x, item.transform.localPosition.y - num4, 0.0f);
          if (nullable.HasValue && nullable.Value + ItemIcon.MaxValue < (this.recipeDataList.Count + 4) / 5 * 5)
          {
            if (nullable.Value + ItemIcon.MaxValue >= this.recipeDataList.Count)
              item.SetActive(false);
            else
              this.ScrollIconUpdate(nullable.Value + ItemIcon.MaxValue, iconCount);
            flag = true;
          }
        }
        else if ((double) num5 < -((double) num4 - (double) num1))
        {
          int num6 = ItemIcon.MaxValue;
          if (!item.activeSelf)
          {
            item.SetActive(true);
            num6 = 0;
          }
          if (nullable.HasValue && nullable.Value - num6 >= 0)
          {
            item.transform.localPosition = new Vector3(item.transform.localPosition.x, item.transform.localPosition.y + num4, 0.0f);
            this.ScrollIconUpdate(nullable.Value - num6, iconCount);
            flag = true;
          }
        }
        else
          this.ScrollIconUpdate(nullable.Value, iconCount);
        ++iconCount;
      }
    }
    while (flag);
  }

  private void OnDestroy()
  {
  }

  public override void onBackButton()
  {
    if (((Component) this.dirRecipe).gameObject.activeSelf)
      return;
    if (Singleton<PopupManager>.GetInstance().isOpen)
      Singleton<PopupManager>.GetInstance().onDismiss();
    else
      this.backScene();
  }

  private enum SortType
  {
    Recommend,
    Category,
    Rarity,
  }

  private class RecipeData
  {
    public GearGear combinedGear;
    public List<GearCombineRecipe> recipes;
    public bool isCombinEnable;
    public ItemIcon icon;

    public RecipeData(IEnumerable<GearCombineRecipe> recipeDatas, bool isEnable)
    {
      this.combinedGear = MasterData.GearGear[recipeDatas.First<GearCombineRecipe>().combined_gear_id];
      this.recipes = recipeDatas.OrderBy<GearCombineRecipe, int>((Func<GearCombineRecipe, int>) (x => x.priority)).ThenBy<GearCombineRecipe, int>((Func<GearCombineRecipe, int>) (x => x.combined_gear_id)).ToList<GearCombineRecipe>();
      this.isCombinEnable = isEnable;
      this.icon = (ItemIcon) null;
    }

    public int priority
    {
      get
      {
        return this.recipes.Count > 0 ? this.recipes.Min<GearCombineRecipe>((Func<GearCombineRecipe, int>) (x => x.priority)) : int.MaxValue;
      }
    }
  }
}
