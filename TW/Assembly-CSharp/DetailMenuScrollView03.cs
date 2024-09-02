// Decompiled with JetBrains decompiler
// Type: DetailMenuScrollView03
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using MasterDataTable;
using SM;
using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class DetailMenuScrollView03 : DetailMenuScrollViewBase
{
  [SerializeField]
  private GameObject floatingSkillDialog;
  [SerializeField]
  protected UILabel txt_WeaponName;
  [SerializeField]
  protected UILabel txt_WeaponRange;
  [SerializeField]
  protected UI2DSprite dyn_WeaponType;
  [SerializeField]
  protected UI2DSprite dyn_WeaponSpType01;
  [SerializeField]
  protected UI2DSprite dyn_WeaponSpType02;
  [SerializeField]
  protected UILabel[] txt_MagicNames;
  [SerializeField]
  protected UILabel[] txt_MagicRanges;
  [SerializeField]
  protected UI2DSprite[] dyn_MagicElementTypes;
  [SerializeField]
  protected UI2DSprite[] dyn_MagicSpTypes01;
  [SerializeField]
  protected UI2DSprite[] dyn_MagicSpTypes02;
  private UIButton[] magicButtons;
  private Action<BattleskillSkill> showSkillDialog;
  private Action<int, int> showSkillLevel;
  [SerializeField]
  private DetailMenu menu;
  private Battle0171111Event floatingSkillDialogObject;
  private GameObject gearKindIconObject;
  private GameObject[] magicElemmentObject;

  private void Awake() => this.magicElemmentObject = new GameObject[this.txt_MagicNames.Length];

  public override bool Init(PlayerUnit playerUnit)
  {
    GearGear equippedGearOrInitial = playerUnit.equippedGearOrInitial;
    ((Component) this).gameObject.SetActive(true);
    this.txt_WeaponName.SetTextLocalize(playerUnit.equippedGearName);
    this.txt_WeaponRange.SetTextLocalize(equippedGearOrInitial.min_range.ToString() + "-" + (object) equippedGearOrInitial.max_range);
    return true;
  }

  [DebuggerHidden]
  public override IEnumerator initAsync(PlayerUnit playerUnit, GameObject[] prefabs)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DetailMenuScrollView03.\u003CinitAsync\u003Ec__IteratorB0E()
    {
      playerUnit = playerUnit,
      prefabs = prefabs,
      \u003C\u0024\u003EplayerUnit = playerUnit,
      \u003C\u0024\u003Eprefabs = prefabs,
      \u003C\u003Ef__this = this
    };
  }

  private GameObject createIcon(GameObject prefab, Transform trans)
  {
    trans.Clear();
    GameObject icon = prefab.Clone(trans);
    UI2DSprite componentInChildren1 = icon.GetComponentInChildren<UI2DSprite>();
    BoxCollider componentInChildren2 = ((Component) trans).GetComponentInChildren<BoxCollider>();
    UI2DSprite componentInChildren3 = ((Component) trans).GetComponentInChildren<UI2DSprite>();
    componentInChildren1.SetDimensions((int) componentInChildren2.size.x, (int) componentInChildren2.size.y);
    componentInChildren1.depth = componentInChildren3.depth + 1;
    return icon;
  }
}
