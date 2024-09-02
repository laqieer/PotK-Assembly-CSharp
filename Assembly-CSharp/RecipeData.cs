// Decompiled with JetBrains decompiler
// Type: RecipeData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using MasterDataTable;
using System;
using System.Collections.Generic;
using UniLinq;

public class RecipeData
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

  public int priority => this.recipes.Count <= 0 ? int.MaxValue : this.recipes.Min<GearCombineRecipe>((Func<GearCombineRecipe, int>) (x => x.priority));

  public List<string> GetResouceNames()
  {
    List<string> stringList = this.combinedGear.ResourcePaths();
    foreach (GearCombineRecipe recipe in this.recipes)
      stringList.AddRange((IEnumerable<string>) recipe.ResourcePaths());
    return stringList;
  }
}
