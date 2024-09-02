// Decompiled with JetBrains decompiler
// Type: Guide01122Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class Guide01122Menu : BackButtonMenuBase
{
  [SerializeField]
  private NGHorizontalScrollParts informationScrollView;
  [SerializeField]
  private UnitDetailGroupButton[] groupBtns;
  [SerializeField]
  private SpriteSelectDirectButton[] groupSprites;
  [SerializeField]
  private UIGrid groupBtnGrid;
  [SerializeField]
  private GameObject floatingGroupDialog;
  private GameObject floatingGroupDialogObject;
  public UILabel txt_CharacterName;
  public UILabel txt_number;
  public UI2DSprite DynCharacter;
  public UI2DSprite rarityStarsIcon;
  public GearKindIcon GearKindIcon;
  public List<GuideUnitEvolution> unitEvolutionList = new List<GuideUnitEvolution>();
  public GuideUnitDeteilIndicator deteilIndicator;
  public DetailMenuScrollView04 characterIndicator;
  public DetailMenuScrollView05 desctiptionIndicator;
  private UnitUnit unit_;

  public virtual void IbtnEvolution2()
  {
  }

  public virtual void IbtnEvolution3()
  {
  }

  public virtual void IbtnZoom()
  {
    if (this.IsPushAndSet())
      return;
    Unit0043Scene.changeScene(true, this.unit_, true);
  }

  public virtual void IbtnBack()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<NGSoundManager>.GetInstance().stopVoice();
    this.backScene();
  }

  public override void onBackButton() => this.IbtnBack();

  private void OnDestroy() => Singleton<NGSoundManager>.GetInstance().stopVoice();

  public virtual void IbtnEvolution(GuideUnitEvolution guideUnitEvolution)
  {
    if (this.IsPush)
      return;
    this.StartCoroutine(this.onStartSceneAsync(guideUnitEvolution.unitData, false));
  }

  [DebuggerHidden]
  public IEnumerator onStartSceneAsync(UnitUnit unit, bool voiceFlag)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guide01122Menu.\u003ConStartSceneAsync\u003Ec__Iterator5A2()
    {
      unit = unit,
      voiceFlag = voiceFlag,
      \u003C\u0024\u003Eunit = unit,
      \u003C\u0024\u003EvoiceFlag = voiceFlag,
      \u003C\u003Ef__this = this
    };
  }

  public void onEndScene()
  {
  }

  [DebuggerHidden]
  public IEnumerator onEndSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    Guide01122Menu.\u003ConEndSceneAsync\u003Ec__Iterator5A3 asyncCIterator5A3 = new Guide01122Menu.\u003ConEndSceneAsync\u003Ec__Iterator5A3();
    return (IEnumerator) asyncCIterator5A3;
  }

  private void ShowGroupDescription(string title, string description, string spriteName)
  {
    Unit0042FloatingGroupDialog component = this.floatingGroupDialogObject.GetComponent<Unit0042FloatingGroupDialog>();
    component.Init(title, description, spriteName);
    component.Show();
  }

  private void DisplayGroupLogo(UnitUnit playerUnit)
  {
    int index = 0;
    ((IEnumerable<UnitDetailGroupButton>) this.groupBtns).ForEach<UnitDetailGroupButton>((Action<UnitDetailGroupButton>) (x => ((Component) x).gameObject.SetActive(false)));
    UnitGroup groupInfo = ((IEnumerable<UnitGroup>) MasterData.UnitGroupList).FirstOrDefault<UnitGroup>((Func<UnitGroup, bool>) (x => x.unit_id == playerUnit.ID));
    if (groupInfo == null)
      return;
    UnitGroupLargeCategory groupLargeCategory = ((IEnumerable<UnitGroupLargeCategory>) MasterData.UnitGroupLargeCategoryList).FirstOrDefault<UnitGroupLargeCategory>((Func<UnitGroupLargeCategory, bool>) (x => x.ID == groupInfo.group_large_category_id_UnitGroupLargeCategory));
    UnitGroupSmallCategory groupSmallCategory = ((IEnumerable<UnitGroupSmallCategory>) MasterData.UnitGroupSmallCategoryList).FirstOrDefault<UnitGroupSmallCategory>((Func<UnitGroupSmallCategory, bool>) (x => x.ID == groupInfo.group_small_category_id_UnitGroupSmallCategory));
    UnitGroupClothingCategory clothingCategory = ((IEnumerable<UnitGroupClothingCategory>) MasterData.UnitGroupClothingCategoryList).FirstOrDefault<UnitGroupClothingCategory>((Func<UnitGroupClothingCategory, bool>) (x => x.ID == groupInfo.group_clothing_category_id_UnitGroupClothingCategory));
    UnitGroupGenerationCategory generationCategory = ((IEnumerable<UnitGroupGenerationCategory>) MasterData.UnitGroupGenerationCategoryList).FirstOrDefault<UnitGroupGenerationCategory>((Func<UnitGroupGenerationCategory, bool>) (x => x.ID == groupInfo.group_generation_category_id_UnitGroupGenerationCategory));
    if (groupLargeCategory == null && groupSmallCategory == null && clothingCategory == null && generationCategory == null)
      return;
    if (groupLargeCategory != null && groupLargeCategory.ID != 1)
    {
      this.groupSprites[index].SetSpriteName<string>(groupLargeCategory.GetSpriteName());
      this.groupBtns[index].Init(new Action<string, string, string>(this.ShowGroupDescription), groupLargeCategory.name, groupLargeCategory.description, groupLargeCategory.GetSpriteName());
      ((Component) this.groupBtns[index]).gameObject.SetActive(true);
      ++index;
    }
    if (groupSmallCategory != null && groupSmallCategory.ID != 1)
    {
      this.groupSprites[index].SetSpriteName<string>(groupSmallCategory.GetSpriteName());
      this.groupBtns[index].Init(new Action<string, string, string>(this.ShowGroupDescription), groupSmallCategory.name, groupSmallCategory.description, groupSmallCategory.GetSpriteName());
      ((Component) this.groupBtns[index]).gameObject.SetActive(true);
      ++index;
    }
    if (clothingCategory != null && clothingCategory.ID != 1)
    {
      this.groupSprites[index].SetSpriteName<string>(clothingCategory.GetSpriteName());
      this.groupBtns[index].Init(new Action<string, string, string>(this.ShowGroupDescription), clothingCategory.name, clothingCategory.description, clothingCategory.GetSpriteName());
      ((Component) this.groupBtns[index]).gameObject.SetActive(true);
      ++index;
    }
    if (generationCategory != null && generationCategory.ID != 1)
    {
      this.groupSprites[index].SetSpriteName<string>(generationCategory.GetSpriteName());
      this.groupBtns[index].Init(new Action<string, string, string>(this.ShowGroupDescription), generationCategory.name, generationCategory.description, generationCategory.GetSpriteName());
      ((Component) this.groupBtns[index]).gameObject.SetActive(true);
      int num = index + 1;
    }
    this.groupBtnGrid.repositionNow = true;
  }

  public void SetUnitNmae(UnitUnit unit) => this.txt_CharacterName.SetTextLocalize(unit.name);

  public void SetNumber(UnitUnit unit)
  {
    this.txt_number.SetTextLocalize("NO." + (unit.history_group_number % 1000).ToString().PadLeft(3, '0'));
  }

  public void SetUnitRarity(UnitUnit unit)
  {
    RarityIcon.SetRarity(unit, this.rarityStarsIcon, true, true);
  }

  public void SetUnitGearType(UnitUnit unit)
  {
    this.GearKindIcon.Init(unit.initial_gear.kind, unit.GetElement());
  }

  [DebuggerHidden]
  public IEnumerator SetUnitImg(UnitUnit unit)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guide01122Menu.\u003CSetUnitImg\u003Ec__Iterator5A4()
    {
      unit = unit,
      \u003C\u0024\u003Eunit = unit,
      \u003C\u003Ef__this = this
    };
  }

  public void SetEvolutionUnit(
    UnitUnit unit,
    UnitUnit[] commonUnitList,
    PlayerUnitHistory[] history)
  {
    commonUnitList = ((IEnumerable<UnitUnit>) commonUnitList).OrderBy<UnitUnit, int>((Func<UnitUnit, int>) (x => x.ID)).ToArray<UnitUnit>();
    int sabun = this.unitEvolutionList.Count - commonUnitList.Length;
    for (int i = 0; i < this.unitEvolutionList.Count; ++i)
    {
      if (sabun > i)
        ((Component) this.unitEvolutionList[i]).gameObject.SetActive(false);
      else if (!((IEnumerable<PlayerUnitHistory>) history).FirstIndexOrNull<PlayerUnitHistory>((Func<PlayerUnitHistory, bool>) (x => x.unit_id == commonUnitList[i - sabun].ID)).HasValue)
        this.unitEvolutionList[i].Set(commonUnitList[i - sabun], false, true);
      else if (unit.ID == commonUnitList[i - sabun].ID)
        this.unitEvolutionList[i].Set(commonUnitList[i - sabun], true, false);
      else
        this.unitEvolutionList[i].Set(commonUnitList[i - sabun], false, false);
    }
  }
}
