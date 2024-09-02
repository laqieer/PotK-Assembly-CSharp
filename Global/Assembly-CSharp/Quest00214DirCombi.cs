// Decompiled with JetBrains decompiler
// Type: Quest00214DirCombi
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using MasterDataTable;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
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
  private Action<int, int> pushEvent;
  private int mainUnitId;
  private int targetUnitId;

  public void Select()
  {
    if (this.pushEvent == null)
      return;
    this.pushEvent(this.mainUnitId, this.targetUnitId);
  }

  [DebuggerHidden]
  public IEnumerator InitStoryPlayBack(
    QuestHarmonyS questSTable,
    PlayerHarmonyQuestS[] allPlayerHamony,
    GameObject unitIconPrefab,
    Action<int, int> buttonEvent = null)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00214DirCombi.\u003CInitStoryPlayBack\u003Ec__Iterator17E()
    {
      questSTable = questSTable,
      buttonEvent = buttonEvent,
      \u003C\u0024\u003EquestSTable = questSTable,
      \u003C\u0024\u003EbuttonEvent = buttonEvent,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator Init(
    QuestHarmonyS questSTable,
    PlayerHarmonyQuestS[] allPlayerHamony,
    Action<int, int> buttonEvent = null)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00214DirCombi.\u003CInit\u003Ec__Iterator17F()
    {
      questSTable = questSTable,
      allPlayerHamony = allPlayerHamony,
      buttonEvent = buttonEvent,
      \u003C\u0024\u003EquestSTable = questSTable,
      \u003C\u0024\u003EallPlayerHamony = allPlayerHamony,
      \u003C\u0024\u003EbuttonEvent = buttonEvent,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator SetUnitIcon(
    UI2DSprite unitIconSp,
    UnitUnit unit,
    NGxMaskSpriteWithScale mask,
    Texture2D mask_texture)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00214DirCombi.\u003CSetUnitIcon\u003Ec__Iterator180()
    {
      unit = unit,
      unitIconSp = unitIconSp,
      mask = mask,
      mask_texture = mask_texture,
      \u003C\u0024\u003Eunit = unit,
      \u003C\u0024\u003EunitIconSp = unitIconSp,
      \u003C\u0024\u003Emask = mask,
      \u003C\u0024\u003Emask_texture = mask_texture
    };
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
