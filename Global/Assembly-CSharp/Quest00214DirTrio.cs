// Decompiled with JetBrains decompiler
// Type: Quest00214DirTrio
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using MasterDataTable;
using SM;
using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Quest00214DirTrio : MonoBehaviour
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
  public UISprite ClearIcon;
  [SerializeField]
  public UISprite NewIcon;
  [SerializeField]
  public UISprite Mask;
  public BoxCollider buttonBoxCollider;
  private QuestHarmonyS questS;
  private Action<int, int[]> pushEvent;
  private Action<int, int[], int> pushEventStory;
  private int mainUnitId;
  private int[] targetUnitIds = new int[2];
  public int questSId;

  public void Select()
  {
    if (this.pushEvent != null)
    {
      this.pushEvent(this.mainUnitId, this.targetUnitIds);
    }
    else
    {
      if (this.pushEventStory == null)
        return;
      this.pushEventStory(this.mainUnitId, this.targetUnitIds, this.questSId);
    }
  }

  [DebuggerHidden]
  public IEnumerator InitStoryPlayBack(
    QuestHarmonyS questSTable,
    Action<int, int[], int> buttonEvent = null)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00214DirTrio.\u003CInitStoryPlayBack\u003Ec__Iterator181()
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
    bool is_playable,
    PlayerHarmonyQuestS[] allPlayerHamony,
    Action<int, int[]> buttonEvent = null)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest00214DirTrio.\u003CInit\u003Ec__Iterator182()
    {
      questSTable = questSTable,
      allPlayerHamony = allPlayerHamony,
      buttonEvent = buttonEvent,
      is_playable = is_playable,
      \u003C\u0024\u003EquestSTable = questSTable,
      \u003C\u0024\u003EallPlayerHamony = allPlayerHamony,
      \u003C\u0024\u003EbuttonEvent = buttonEvent,
      \u003C\u0024\u003Eis_playable = is_playable,
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
    return (IEnumerator) new Quest00214DirTrio.\u003CSetUnitIcon\u003Ec__Iterator183()
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
}
