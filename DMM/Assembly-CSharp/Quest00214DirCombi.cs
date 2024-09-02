// Decompiled with JetBrains decompiler
// Type: Quest00214DirCombi
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using UniLinq;
using UnityEngine;

public class Quest00214DirCombi : MonoBehaviour
{
  [SerializeField]
  public UIButton QuestButton;
  [SerializeField]
  public UILabel QuestTitle;
  [SerializeField]
  public UILabel[] UnitName;
  [SerializeField]
  public UI2DSprite[] UnitIconObject;
  [SerializeField]
  public NGxMaskSpriteWithScale[] UnitIconMask;
  [SerializeField]
  public UISprite ReleaseCondition;
  [SerializeField]
  public UILabel ReleaseConditionLv;
  [SerializeField]
  public UISprite ClearIcon;
  [SerializeField]
  public UISprite NewIcon;
  [SerializeField]
  public UISprite Mask;
  [SerializeField]
  public UILabel FriendlyLv;
  public BoxCollider buttonBoxCollider;
  private System.Action<int, int> pushEvent;
  private int mainUnitId;
  private int targetUnitId;

  public void Select()
  {
    if (this.pushEvent == null)
      return;
    this.pushEvent(this.mainUnitId, this.targetUnitId);
  }

  public IEnumerator InitStoryPlayBack(
    QuestHarmonyS questSTable,
    PlayerHarmonyQuestS[] allPlayerHamony,
    GameObject unitIconPrefab,
    System.Action<int, int> buttonEvent = null)
  {
    QuestHarmonyReleaseCondition questReleasseCondition = ((IEnumerable<QuestHarmonyReleaseCondition>) MasterData.QuestHarmonyReleaseConditionList).Where<QuestHarmonyReleaseCondition>((Func<QuestHarmonyReleaseCondition, bool>) (x => x.quest_s_QuestHarmonyS == questSTable.ID)).FirstOrDefault<QuestHarmonyReleaseCondition>();
    this.pushEvent = buttonEvent;
    if (questSTable != null)
    {
      this.mainUnitId = questSTable.unit_UnitUnit;
      this.targetUnitId = questSTable.target_unit_UnitUnit;
      Future<Texture2D> maskF = Res.GUI._002_14_sozai.mask_combi.Load<Texture2D>();
      IEnumerator e = maskF.Wait();
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      Texture2D mask = maskF.Result;
      this.QuestTitle.SetTextLocalize(questSTable.name);
      e = this.SetUnitIcon(this.UnitIconObject[0], questSTable.unit, this.UnitIconMask[0], mask);
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      e = this.SetUnitIcon(this.UnitIconObject[1], questSTable.target_unit, this.UnitIconMask[1], mask);
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      this.UnitName[0].SetTextLocalize(questSTable.unit.name);
      this.UnitName[1].SetTextLocalize(questSTable.target_unit.name);
      this.FriendlyLv.gameObject.SetActive(false);
      this.ClearIcon.gameObject.SetActive(false);
      this.NewIcon.gameObject.SetActive(false);
      this.ReleaseCondition.gameObject.SetActive(false);
      this.ReleaseConditionLv.gameObject.SetActive(false);
      this.ReleaseConditionLv.SetTextLocalize(questReleasseCondition.required_intimacy_level);
      this.Mask.gameObject.SetActive(false);
      this.FriendlyLv.transform.parent.gameObject.SetActive(false);
      maskF = (Future<Texture2D>) null;
      mask = (Texture2D) null;
    }
  }

  public IEnumerator Init(
    QuestHarmonyS questSTable,
    PlayerHarmonyQuestS[] allPlayerHamony,
    System.Action<int, int> buttonEvent = null)
  {
    QuestHarmonyReleaseCondition questReleasseCondition = ((IEnumerable<QuestHarmonyReleaseCondition>) MasterData.QuestHarmonyReleaseConditionList).Where<QuestHarmonyReleaseCondition>((Func<QuestHarmonyReleaseCondition, bool>) (x => x.quest_s_QuestHarmonyS == questSTable.ID)).FirstOrDefault<QuestHarmonyReleaseCondition>();
    PlayerHarmonyQuestS[] playerHarmony = ((IEnumerable<PlayerHarmonyQuestS>) allPlayerHamony).Where<PlayerHarmonyQuestS>((Func<PlayerHarmonyQuestS, bool>) (x => x.quest_harmony_s.unit_UnitUnit == questSTable.unit_UnitUnit)).ToArray<PlayerHarmonyQuestS>();
    this.pushEvent = buttonEvent;
    if (questSTable != null)
    {
      this.mainUnitId = questSTable.unit_UnitUnit;
      this.targetUnitId = questSTable.target_unit_UnitUnit;
      int friendlyLevel = this.GetCharacterIntimate(questSTable.unit_UnitUnit, questSTable.target_unit_UnitUnit);
      Future<Texture2D> maskF = Res.GUI._002_14_sozai.mask_combi.Load<Texture2D>();
      IEnumerator e = maskF.Wait();
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      Texture2D mask_texture = maskF.Result;
      this.QuestTitle.SetTextLocalize(questSTable.name);
      e = this.SetUnitIcon(this.UnitIconObject[0], questSTable.unit, this.UnitIconMask[0], mask_texture);
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      e = this.SetUnitIcon(this.UnitIconObject[1], questSTable.target_unit, this.UnitIconMask[1], mask_texture);
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      this.UnitName[0].SetTextLocalize(questSTable.unit.name);
      this.UnitName[1].SetTextLocalize(questSTable.target_unit.name);
      this.FriendlyLv.SetTextLocalize(friendlyLevel);
      if (playerHarmony.Length == 0)
      {
        this.ClearIcon.gameObject.SetActive(false);
        this.NewIcon.gameObject.SetActive(false);
        this.ReleaseCondition.gameObject.SetActive(true);
        this.ReleaseConditionLv.gameObject.SetActive(true);
        this.ReleaseConditionLv.SetTextLocalize(questReleasseCondition.required_intimacy_level);
        this.Mask.gameObject.SetActive(true);
      }
      else if (friendlyLevel < questReleasseCondition.required_intimacy_level)
      {
        this.ClearIcon.gameObject.SetActive(false);
        this.NewIcon.gameObject.SetActive(false);
        this.ReleaseConditionLv.gameObject.SetActive(true);
        this.ReleaseConditionLv.SetTextLocalize(questReleasseCondition.required_intimacy_level);
        this.Mask.gameObject.SetActive(true);
      }
      else
      {
        this.ClearIcon.gameObject.SetActive(((IEnumerable<PlayerHarmonyQuestS>) playerHarmony).All<PlayerHarmonyQuestS>((Func<PlayerHarmonyQuestS, bool>) (x => x.is_clear)));
        this.NewIcon.gameObject.SetActive(((IEnumerable<PlayerHarmonyQuestS>) playerHarmony).Any<PlayerHarmonyQuestS>((Func<PlayerHarmonyQuestS, bool>) (x => x.is_new)));
        this.ReleaseCondition.gameObject.SetActive(false);
        this.ReleaseConditionLv.gameObject.SetActive(false);
        this.Mask.gameObject.SetActive(false);
      }
      maskF = (Future<Texture2D>) null;
      mask_texture = (Texture2D) null;
    }
  }

  private IEnumerator SetUnitIcon(
    UI2DSprite unitIconSp,
    UnitUnit unit,
    NGxMaskSpriteWithScale mask,
    Texture2D mask_texture)
  {
    Future<UnityEngine.Sprite> spriteF = unit.LoadSpriteThumbnail();
    IEnumerator e = spriteF.Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    unitIconSp.sprite2D = spriteF.Result;
    mask.isTopFit = false;
    mask.MainUI2DSprite = unitIconSp;
    mask.maskTexture = mask_texture;
  }

  private int GetCharacterIntimate(int mainUnitId, int targetUnitId)
  {
    UnitUnit mainUnit = MasterData.UnitUnit[mainUnitId];
    UnitUnit targetUnit = MasterData.UnitUnit[targetUnitId];
    PlayerCharacterIntimate characterIntimate = ((IEnumerable<PlayerCharacterIntimate>) SMManager.Get<PlayerCharacterIntimate[]>()).FirstOrDefault<PlayerCharacterIntimate>((Func<PlayerCharacterIntimate, bool>) (x =>
    {
      if (x._character == mainUnit.character_UnitCharacter && x._target_character == targetUnit.character_UnitCharacter)
        return true;
      return x._character == targetUnit.character_UnitCharacter && x._target_character == mainUnit.character_UnitCharacter;
    }));
    return characterIntimate != null ? characterIntimate.level : 0;
  }
}
