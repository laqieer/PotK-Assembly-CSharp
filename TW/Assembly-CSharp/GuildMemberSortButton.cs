// Decompiled with JetBrains decompiler
// Type: GuildMemberSortButton
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class GuildMemberSortButton : SortAndFilterButton
{
  [SerializeField]
  private GuildMemberSort menu;
  [SerializeField]
  private GuildMemberSort.SORT_TYPES sortType;
  [SerializeField]
  private UISprite[] LabelSprite;

  public GuildMemberSort.SORT_TYPES SortType => this.sortType;

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

  public override void PressButton() => this.menu.SetSortCategory(this.sortType);
}
