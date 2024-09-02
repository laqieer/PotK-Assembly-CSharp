// Decompiled with JetBrains decompiler
// Type: ItemSortAndFilterButton
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class ItemSortAndFilterButton : SortAndFilterButton
{
  [SerializeField]
  private ItemSortAndFilterButton OppositeBtn;
  [SerializeField]
  private ItemSortAndFilter.ModeTypes modelType;
  [SerializeField]
  private ItemSortAndFilter menu;
  [SerializeField]
  private ItemSortAndFilter.SORT_TYPES sortType;
  [SerializeField]
  private ItemSortAndFilter.FILTER_TYPES filterType;
  [SerializeField]
  private UISprite[] LabelSprite;

  public ItemSortAndFilter.SORT_TYPES SortType => this.sortType;

  public ItemSortAndFilter.FILTER_TYPES FilterType => this.filterType;

  protected override void Awake() => base.Awake();

  private void Update()
  {
    foreach (UIWidget uiWidget in this.LabelSprite)
      uiWidget.color = this.Sprite.color;
  }

  public void TextColorGray(bool flag)
  {
    Color color = Color.gray;
    if (flag)
      color = Color.white;
    foreach (UIWidget uiWidget in this.LabelSprite)
      uiWidget.color = color;
  }

  public override void PressButton()
  {
    switch (this.modelType)
    {
      case ItemSortAndFilter.ModeTypes.Sort:
        this.menu.SetSortCategory(this.sortType);
        break;
      case ItemSortAndFilter.ModeTypes.Filter:
        this.menu.SetFilterType(this.filterType, Color.op_Equality(this.Button.defaultColor, Color.gray));
        break;
    }
    if (!Object.op_Inequality((Object) this.OppositeBtn, (Object) null) || !Color.op_Equality(this.Button.defaultColor, Color.gray) || !Color.op_Equality(this.OppositeBtn.Button.defaultColor, Color.gray))
      return;
    this.OppositeBtn.PressButton();
  }
}
