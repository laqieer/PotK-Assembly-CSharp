// Decompiled with JetBrains decompiler
// Type: UnitSortAndFilterGroupButton
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using MasterDataTable;
using UnityEngine;

#nullable disable
public class UnitSortAndFilterGroupButton : UnitSortAndFilterButton
{
  [SerializeField]
  private GameObject slcSortFilterTextBG;
  [SerializeField]
  private UILabel txtLabel;
  [SerializeField]
  private SpriteSelectDirect spriteSelectDirect;
  private UnitGroupHead groupType;
  private int groupID;

  public UnitGroupHead GroupType => this.groupType;

  public int GroupID => this.groupID;

  protected override void Awake() => base.Awake();

  protected override void Update()
  {
  }

  public void Init(
    UnitSortAndFilter menu,
    UnitGroupHead type,
    int id,
    string text,
    string spriteName)
  {
    this.Menu = menu;
    this.groupType = type;
    this.groupID = id;
    this.txtLabel.SetTextLocalize(text);
    this.spriteSelectDirect.SetSpriteName<string>(spriteName);
    if (type != UnitGroupHead.group_all)
      return;
    this.slcSortFilterTextBG.SetActive(false);
  }

  public override void TextColorGray(bool flag)
  {
    Color color = Color.gray;
    if (flag)
      color = Color.white;
    this.txtLabel.color = color;
  }

  public override void PressButton() => this.Menu.SetGroupInfo(this.groupType, this.groupID);
}
