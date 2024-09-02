// Decompiled with JetBrains decompiler
// Type: ReisouSortAndFilterButton
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class ReisouSortAndFilterButton : SortAndFilterButton
{
  [SerializeField]
  private ReisouSortAndFilterButton OppositeBtn;
  [SerializeField]
  private ReisouSortAndFilter.ModeTypes modelType;
  [SerializeField]
  private ReisouSortAndFilter menu;
  [SerializeField]
  private ReisouSortAndFilter.SORT_TYPES sortType;
  [SerializeField]
  private ReisouSortAndFilter.FILTER_TYPES filterType;
  [SerializeField]
  private UISprite[] LabelSprite;

  public ReisouSortAndFilter.SORT_TYPES SortType => this.sortType;

  public ReisouSortAndFilter.FILTER_TYPES FilterType => this.filterType;

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
      case ReisouSortAndFilter.ModeTypes.Sort:
        this.menu.SetSortCategory(this.sortType);
        break;
      case ReisouSortAndFilter.ModeTypes.Filter:
        this.menu.SetFilterType(this.filterType, this.Button.defaultColor == Color.gray);
        break;
    }
    if (!((Object) this.OppositeBtn != (Object) null) || !(this.Button.defaultColor == Color.white) || !(this.OppositeBtn.Button.defaultColor == Color.white))
      return;
    this.OppositeBtn.PressButton();
  }
}
