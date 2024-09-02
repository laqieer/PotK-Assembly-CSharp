// Decompiled with JetBrains decompiler
// Type: Bugu00510Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
  private Dictionary<int, List<PlayerItem>> playerGearDic = new Dictionary<int, List<PlayerItem>>();
  private Dictionary<int, List<PlayerItem>> playerGearDicDescending = new Dictionary<int, List<PlayerItem>>();

  [DebuggerHidden]
  public IEnumerator InitAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu00510Menu.\u003CInitAsync\u003Ec__Iterator370()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator StartAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu00510Menu.\u003CStartAsync\u003Ec__Iterator371()
    {
      \u003C\u003Ef__this = this
    };
  }

  private bool CheckEnableRecipe(List<Tuple<int, int>> playerItemData, GearCombineRecipe recipe)
  {
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
    List<PlayerItem> playerItemList = new List<PlayerItem>();
    Dictionary<int, int> dictionary = new Dictionary<int, int>();
    foreach (Tuple<int, int> tuple in (IEnumerable<Tuple<int, int>>) source.OrderBy<Tuple<int, int>, int>((Func<Tuple<int, int>, int>) (x => x.Item1)).ThenBy<Tuple<int, int>, int>((Func<Tuple<int, int>, int>) (x => x.Item2)))
    {
      Tuple<int, int> part = tuple;
      int startIndex = 0;
      if (dictionary.ContainsKey(part.Item1))
        startIndex = dictionary[part.Item1];
      int index = playerItemData.FindIndex(startIndex, (Predicate<Tuple<int, int>>) (x => x.Item1 == part.Item1 && x.Item2 >= part.Item2));
      if (index < 0)
        return false;
      dictionary[part.Item1] = index + 1;
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
    return (int) ((double) (total_item_level * 50) * (double) GearRarity.ComposeRatio(index));
  }

  private int CheckCanMaterial(PlayerItem gear)
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
    return (IEnumerator) new Bugu00510Menu.\u003CCreateAllIcon\u003Ec__Iterator372()
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
    return (IEnumerator) new Bugu00510Menu.\u003CLoadObject\u003Ec__Iterator373()
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
    return (IEnumerator) new Bugu00510Menu.\u003COpenRecipePopup\u003Ec__Iterator374()
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
    return (IEnumerator) new Bugu00510Menu.\u003CSortIcon\u003Ec__Iterator375()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void PushOK(List<InventoryItem> items, string str)
  {
    this.StartCoroutine(this.StartComposite(items.Select<InventoryItem, PlayerItem>((Func<InventoryItem, PlayerItem>) (x => x.Item)).ToList<PlayerItem>()));
  }

  [DebuggerHidden]
  private IEnumerator StartComposite(List<PlayerItem> sendGears)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu00510Menu.\u003CStartComposite\u003Ec__Iterator376()
    {
      sendGears = sendGears,
      \u003C\u0024\u003EsendGears = sendGears,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator CompositeAPI(List<PlayerItem> sendGears)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Bugu00510Menu.\u003CCompositeAPI\u003Ec__Iterator377()
    {
      sendGears = sendGears,
      \u003C\u0024\u003EsendGears = sendGears
    };
  }

  private new void Update()
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
