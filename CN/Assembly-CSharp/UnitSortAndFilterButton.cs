// Decompiled with JetBrains decompiler
// Type: UnitSortAndFilterButton
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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

  public UnitSortAndFilter.SORT_TYPES SortType => this.sortType;

  public UnitSortAndFilter.FILTER_TYPES FilterType => this.filterType;

  protected override void Awake() => base.Awake();

  private void Update()
  {
    foreach (UIWidget uiWidget in this.LabelSprite)
      uiWidget.color = this.Sprite.color;
  }

  public void TextColorGray(bool flag)
  {
    Color color = PunkColor.button_off;
    if (flag)
      color = PunkColor.button_on;
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
