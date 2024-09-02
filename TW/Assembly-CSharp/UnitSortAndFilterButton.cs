// Decompiled with JetBrains decompiler
// Type: UnitSortAndFilterButton
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class UnitSortAndFilterButton : SortAndFilterButton
{
  [SerializeField]
  private UnitSortAndFilterButton OppositeBtn;
  [SerializeField]
  private UnitSortAndFilter.ModeTypes modelType;
  [SerializeField]
  private UnitSortAndFilter menu;
  [SerializeField]
  private UnitSortAndFilter.SORT_TYPES sortType;
  [SerializeField]
  private UnitSortAndFilter.FILTER_TYPES filterType;
  [SerializeField]
  private UISprite[] LabelSprite;

  public UnitSortAndFilter.ModeTypes ModelType
  {
    get => this.modelType;
    set => this.modelType = value;
  }

  public UnitSortAndFilter Menu
  {
    get => this.menu;
    set => this.menu = value;
  }

  public UnitSortAndFilter.SORT_TYPES SortType => this.sortType;

  public UnitSortAndFilter.FILTER_TYPES FilterType => this.filterType;

  protected override void Awake() => base.Awake();

  protected virtual void Update()
  {
    foreach (UIWidget uiWidget in this.LabelSprite)
      uiWidget.color = this.Sprite.color;
  }

  public virtual void TextColorGray(bool flag)
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
      case UnitSortAndFilter.ModeTypes.Sort:
        this.menu.SetSortCategory(this.sortType);
        break;
      case UnitSortAndFilter.ModeTypes.Filter:
        this.menu.SetFilterType(this.filterType, Color.op_Equality(this.Button.defaultColor, Color.gray));
        break;
    }
    if (!Object.op_Inequality((Object) this.OppositeBtn, (Object) null) || !Color.op_Equality(this.Button.defaultColor, Color.gray) || !Color.op_Equality(this.OppositeBtn.Button.defaultColor, Color.gray))
      return;
    this.OppositeBtn.PressButton();
  }
}
