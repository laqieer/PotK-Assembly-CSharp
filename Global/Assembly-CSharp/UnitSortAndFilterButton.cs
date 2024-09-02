// Decompiled with JetBrains decompiler
// Type: UnitSortAndFilterButton
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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
  private UILabel[] LabelSprite;
  private static Color buttonOffColor = new Color(0.5f, 0.5f, 0.5f, 1f);
  private static Color buttonOnColor = new Color(1f, 1f, 1f, 1f);

  public UnitSortAndFilter.SORT_TYPES SortType => this.sortType;

  public UnitSortAndFilter.FILTER_TYPES FilterType => this.filterType;

  protected override void Awake() => base.Awake();

  public void TextColorGray(bool flag)
  {
    Color color = UnitSortAndFilterButton.buttonOffColor;
    if (flag)
      color = UnitSortAndFilterButton.buttonOnColor;
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
        this.menu.SetFilterType(this.filterType, Color.op_Equality(this.Button.defaultColor, PunkColor.button_off));
        break;
    }
    if (!Object.op_Inequality((Object) this.OppositeBtn, (Object) null) || !Color.op_Equality(this.Button.defaultColor, PunkColor.button_off) || !Color.op_Equality(this.OppositeBtn.Button.defaultColor, PunkColor.button_off))
      return;
    this.OppositeBtn.PressButton();
  }
}
