// Decompiled with JetBrains decompiler
// Type: Quest00214DirTrio
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
  private System.Action<int, int[]> pushEvent;
  private System.Action<int, int[], int> pushEventStory;
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

  public IEnumerator InitStoryPlayBack(
    QuestHarmonyS questSTable,
    System.Action<int, int[], int> buttonEvent = null)
  {
    this.questS = questSTable;
    this.pushEventStory = buttonEvent;
    this.questSId = this.questS.ID;
    if (this.questS != null)
    {
      this.mainUnitId = this.questS.unit.ID;
      this.targetUnitIds[0] = this.questS.target_unit.ID;
      this.targetUnitIds[1] = this.questS.target_unit2.ID;
      Future<Texture2D> maskTopF = Res.GUI._002_14_sozai.mask_trio_top.Load<Texture2D>();
      IEnumerator e = maskTopF.Wait();
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      Texture2D mask_top_texture = maskTopF.Result;
      Future<Texture2D> maskBottomF = Res.GUI._002_14_sozai.mask_trio_bottom.Load<Texture2D>();
      e = maskBottomF.Wait();
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      Texture2D mask_bottom_texture = maskBottomF.Result;
      this.QuestTitle.SetTextLocalize(this.questS.name);
      e = this.SetUnitIcon(this.UnitIconObject[0], this.questS.unit, this.UnitIconMask[0], mask_bottom_texture);
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      e = this.SetUnitIcon(this.UnitIconObject[1], this.questS.target_unit, this.UnitIconMask[1], mask_top_texture);
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      e = this.SetUnitIcon(this.UnitIconObject[2], this.questS.target_unit2, this.UnitIconMask[2], mask_bottom_texture);
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      this.UnitName[0].SetTextLocalize(this.questS.unit.name);
      this.UnitName[1].SetTextLocalize(this.questS.target_unit.name);
      this.UnitName[2].SetTextLocalize(this.questS.target_unit2.name);
      this.ClearIcon.gameObject.SetActive(false);
      this.NewIcon.gameObject.SetActive(false);
      this.Mask.gameObject.SetActive(false);
      maskTopF = (Future<Texture2D>) null;
      mask_top_texture = (Texture2D) null;
      maskBottomF = (Future<Texture2D>) null;
      mask_bottom_texture = (Texture2D) null;
    }
  }

  public IEnumerator Init(
    QuestHarmonyS questSTable,
    bool is_playable,
    PlayerHarmonyQuestS[] allPlayerHamony,
    System.Action<int, int[]> buttonEvent = null)
  {
    Quest00214DirTrio quest00214DirTrio = this;
    quest00214DirTrio.questS = questSTable;
    // ISSUE: reference to a compiler-generated method
    PlayerHarmonyQuestS[] playerHarmony = ((IEnumerable<PlayerHarmonyQuestS>) allPlayerHamony).Where<PlayerHarmonyQuestS>(new Func<PlayerHarmonyQuestS, bool>(quest00214DirTrio.\u003CInit\u003Eb__17_0)).ToArray<PlayerHarmonyQuestS>();
    quest00214DirTrio.pushEvent = buttonEvent;
    if (quest00214DirTrio.questS != null)
    {
      quest00214DirTrio.mainUnitId = quest00214DirTrio.questS.unit.ID;
      quest00214DirTrio.targetUnitIds[0] = quest00214DirTrio.questS.target_unit.ID;
      quest00214DirTrio.targetUnitIds[1] = quest00214DirTrio.questS.target_unit2.ID;
      Future<Texture2D> maskTopF = Res.GUI._002_14_sozai.mask_trio_top.Load<Texture2D>();
      IEnumerator e = maskTopF.Wait();
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      Texture2D mask_top_texture = maskTopF.Result;
      Future<Texture2D> maskBottomF = Res.GUI._002_14_sozai.mask_trio_bottom.Load<Texture2D>();
      e = maskBottomF.Wait();
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      Texture2D mask_bottom_texture = maskBottomF.Result;
      quest00214DirTrio.QuestTitle.SetTextLocalize(quest00214DirTrio.questS.name);
      e = quest00214DirTrio.SetUnitIcon(quest00214DirTrio.UnitIconObject[0], quest00214DirTrio.questS.unit, quest00214DirTrio.UnitIconMask[0], mask_bottom_texture);
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      e = quest00214DirTrio.SetUnitIcon(quest00214DirTrio.UnitIconObject[1], quest00214DirTrio.questS.target_unit, quest00214DirTrio.UnitIconMask[1], mask_top_texture);
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      e = quest00214DirTrio.SetUnitIcon(quest00214DirTrio.UnitIconObject[2], quest00214DirTrio.questS.target_unit2, quest00214DirTrio.UnitIconMask[2], mask_bottom_texture);
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      quest00214DirTrio.UnitName[0].SetTextLocalize(quest00214DirTrio.questS.unit.name);
      quest00214DirTrio.UnitName[1].SetTextLocalize(quest00214DirTrio.questS.target_unit.name);
      quest00214DirTrio.UnitName[2].SetTextLocalize(quest00214DirTrio.questS.target_unit2.name);
      if (playerHarmony.Length == 0)
      {
        quest00214DirTrio.ClearIcon.gameObject.SetActive(false);
        quest00214DirTrio.NewIcon.gameObject.SetActive(false);
        quest00214DirTrio.Mask.gameObject.SetActive(true);
      }
      else if (is_playable)
      {
        quest00214DirTrio.ClearIcon.gameObject.SetActive(((IEnumerable<PlayerHarmonyQuestS>) playerHarmony).All<PlayerHarmonyQuestS>((Func<PlayerHarmonyQuestS, bool>) (x => x.is_clear)));
        quest00214DirTrio.NewIcon.gameObject.SetActive(((IEnumerable<PlayerHarmonyQuestS>) playerHarmony).Any<PlayerHarmonyQuestS>((Func<PlayerHarmonyQuestS, bool>) (x => x.is_new)));
        quest00214DirTrio.Mask.gameObject.SetActive(false);
      }
      else
      {
        quest00214DirTrio.ClearIcon.gameObject.SetActive(false);
        quest00214DirTrio.NewIcon.gameObject.SetActive(false);
        quest00214DirTrio.Mask.gameObject.SetActive(true);
      }
      maskTopF = (Future<Texture2D>) null;
      mask_top_texture = (Texture2D) null;
      maskBottomF = (Future<Texture2D>) null;
      mask_bottom_texture = (Texture2D) null;
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
}
