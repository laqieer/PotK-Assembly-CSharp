// Decompiled with JetBrains decompiler
// Type: RecipeSortAndFilterButton
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class RecipeSortAndFilterButton : SortAndFilterButton
{
  [SerializeField]
  private RecipeSortAndFilterButton oppositeBtn;
  [SerializeField]
  private RecipeSortAndFilter.MODE_TYPES modeType;
  [SerializeField]
  private RecipeSortAndFilter menu;
  [SerializeField]
  private RecipeSortAndFilter.SORT_TYPES sortType;
  [SerializeField]
  private RecipeSortAndFilter.FILTER_TYPES filterType;
  [SerializeField]
  private UISprite[] LabelSprite;

  public RecipeSortAndFilter.SORT_TYPES SortType => this.sortType;

  public RecipeSortAndFilter.FILTER_TYPES FilterType => this.filterType;

  protected override void Awake() => base.Awake();

  private void Update()
  {
    foreach (UIWidget uiWidget in this.LabelSprite)
      uiWidget.color = this.Sprite.color;
  }

  public void TextColorGray(bool flag)
  {
    Color color = flag ? Color.white : Color.gray;
    foreach (UIWidget uiWidget in this.LabelSprite)
      uiWidget.color = color;
  }

  public override void PressButton()
  {
    switch (this.modeType)
    {
      case RecipeSortAndFilter.MODE_TYPES.Sort:
        this.menu.SetSortCategory(this.sortType);
        break;
      case RecipeSortAndFilter.MODE_TYPES.Filter:
        this.menu.SetFilterType(this.filterType, this.Button.defaultColor == Color.gray);
        break;
    }
    if (!((Object) this.oppositeBtn != (Object) null) || !(this.Button.defaultColor == Color.white) || !(this.oppositeBtn.Button.defaultColor == Color.white))
      return;
    this.oppositeBtn.PressButton();
  }
}
