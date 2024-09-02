﻿// Decompiled with JetBrains decompiler
// Type: QuestHScrollButton
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class QuestHScrollButton : MonoBehaviour
{
  [SerializeField]
  protected UILabel apCost;
  [SerializeField]
  protected UISprite newSprite;
  [SerializeField]
  protected UISprite clearSprite;
  [SerializeField]
  protected UI2DSprite StageNumberSprite;
  [SerializeField]
  protected FloatButton StageButton;
  [SerializeField]
  protected UI2DSprite IdleSprite;
  [SerializeField]
  protected UI2DSprite PressSprite;
  protected float defaultScale;
  protected float changedScale;
  protected float SpaceValue;
  [SerializeField]
  protected List<UIWidget> ObjSprites;
  [SerializeField]
  protected List<UIWidget> ObjWidgets;
  public GameObject Mask;
  protected int StageNumber;
  protected int ID;
  protected int AP;
  protected bool canPlay;
  protected GameObject MissionDescription;
  [SerializeField]
  protected UISprite StageBounas;
  private bool anim;
  private int? folderid;
  public List<bool> missionList;

  public void onSetValue()
  {
    this.defaultScale = 1f;
    this.changedScale = 0.9f;
    this.SpaceValue = ((Component) ((Component) this).transform.parent).GetComponent<UIGrid>().cellWidth;
  }

  private void WidgetGetInit()
  {
    this.ObjWidgets = new List<UIWidget>();
    this.ObjSprites = new List<UIWidget>();
    this.ObjSprites.Add(((Component) ((Component) this.newSprite).transform).GetComponent<UIWidget>());
    this.ObjSprites.Add(((Component) ((Component) this.clearSprite).transform).GetComponent<UIWidget>());
    this.ObjSprites.Add(((Component) ((Component) this.StageButton).transform).GetComponent<UIWidget>());
    this.ObjWidgets.Add(((Component) ((Component) this.apCost).transform).GetComponent<UIWidget>());
    this.ObjWidgets.Add(((Component) this.StageNumberSprite).GetComponent<UIWidget>());
    this.ObjWidgets.Add(((Component) this.IdleSprite).GetComponent<UIWidget>());
    this.ObjWidgets.Add(((Component) this.PressSprite).GetComponent<UIWidget>());
  }

  [DebuggerHidden]
  private IEnumerator ChoiceNumberSprites(string path)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new QuestHScrollButton.\u003CChoiceNumberSprites\u003Ec__Iterator1CE()
    {
      path = path,
      \u003C\u0024\u003Epath = path,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  protected virtual IEnumerator Init(
    int num,
    float gridWidth,
    int center,
    string NumberSpritePath,
    string colorName,
    bool eventQuest = false)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new QuestHScrollButton.\u003CInit\u003Ec__Iterator1CF()
    {
      colorName = colorName,
      eventQuest = eventQuest,
      NumberSpritePath = NumberSpritePath,
      num = num,
      \u003C\u0024\u003EcolorName = colorName,
      \u003C\u0024\u003EeventQuest = eventQuest,
      \u003C\u0024\u003ENumberSpritePath = NumberSpritePath,
      \u003C\u0024\u003Enum = num,
      \u003C\u003Ef__this = this
    };
  }

  protected void InitValue(
    int ap,
    bool is_new,
    bool is_clear,
    int? has_reward,
    float gridWidth,
    int centernum)
  {
    ((Component) this).GetComponent<TweenPosition>().from.x = (float) ((this.StageNumber - centernum - 1) * 139);
    ((Component) this).GetComponent<TweenPosition>().to.x = (float) ((this.StageNumber - centernum - 1) * 139);
    this.apCost.SetTextLocalize(ap);
    ((Component) this.newSprite).gameObject.SetActive(is_new);
    ((Component) this.clearSprite).gameObject.SetActive(is_clear);
    this.SetBonusRewardImage(has_reward, is_clear);
  }

  private void SetBonusRewardImage(int? has_reward, bool is_clear)
  {
    if (!has_reward.HasValue || !has_reward.HasValue)
    {
      ((Component) this.StageBounas).gameObject.SetActive(false);
    }
    else
    {
      List<BattleStageClear> list = ((IEnumerable<BattleStageClear>) MasterData.BattleStageClearList).Where<BattleStageClear>((Func<BattleStageClear, bool>) (x => x.reward_group_id == has_reward.GetValueOrDefault() && has_reward.HasValue)).ToList<BattleStageClear>();
      List<BattleStageClear> battleStageClearList = !is_clear ? list : list.Where<BattleStageClear>((Func<BattleStageClear, bool>) (x => x.only_first == 0)).ToList<BattleStageClear>();
      if (battleStageClearList.Count <= 0)
      {
        ((Component) this.StageBounas).gameObject.SetActive(false);
      }
      else
      {
        ((Component) this.StageBounas).gameObject.SetActive(true);
        UISpriteData uiSpriteData = (UISpriteData) null;
        UISprite component = ((Component) this.StageBounas).GetComponent<UISprite>();
        if (battleStageClearList.Count == 1)
        {
          string name = string.Format("slc_BonusIcon_{0}.png__GUI__002-2_sozai__002-2_sozai_prefab", (object) battleStageClearList[0].entity_type_CommonRewardType);
          uiSpriteData = component.atlas.GetSprite(name);
          if (uiSpriteData != null)
            component.spriteName = name;
        }
        if (uiSpriteData != null || battleStageClearList.Count <= 0)
          return;
        string str = "slc_BonusIcon_Other.png__GUI__002-2_sozai__002-2_sozai_prefab";
        component.spriteName = str;
      }
    }
  }

  public void ChangeToneConditionJudge(float variationValue)
  {
    float num = Mathf.Abs(variationValue) / this.SpaceValue;
    this.ChangeToneCondition((double) num < 1.0 ? ((double) num > 0.0 ? num : 0.0f) : 1f);
  }

  private void ChangeToneCondition(float changeValue)
  {
    float num = (this.defaultScale - this.changedScale) * changeValue;
    Color color1 = Color.Lerp(Color.white, Color.gray, changeValue);
    Color color2 = Color.Lerp(Consts.GetInstance().UI_SPRITE_NORMAL_COLOR, Consts.GetInstance().UI_SPRITE_DISABLED_COLOR, changeValue);
    ((Component) this).transform.localScale = new Vector3(this.defaultScale - num, this.defaultScale - num, this.defaultScale);
    foreach (UIWidget objWidget in this.ObjWidgets)
      objWidget.color = !this.canPlay ? Consts.GetInstance().UI_SPRITE_DISABLED_COLOR : color1;
    foreach (UIWidget objSprite in this.ObjSprites)
      objSprite.color = !this.canPlay ? Color.gray : color2;
  }

  public void NotTouch(bool judge)
  {
    bool flag = judge || !this.canPlay;
    this.Mask.SetActive(flag);
    ((Behaviour) this.StageButton).enabled = !flag;
  }

  public void centerAnimation(bool flag)
  {
    if (this.anim != flag && flag && this.canPlay)
    {
      Color white = Color.white;
      Color spriteNormalColor = Consts.GetInstance().UI_SPRITE_NORMAL_COLOR;
      foreach (UIWidget objWidget in this.ObjWidgets)
        objWidget.color = white;
      foreach (UIWidget objSprite in this.ObjSprites)
        objSprite.color = spriteNormalColor;
      ((Component) this).GetComponent<TweenScale>().PlayForward();
    }
    else if (!this.canPlay)
    {
      Color spriteDisabledColor = Consts.GetInstance().UI_SPRITE_DISABLED_COLOR;
      Color gray = Color.gray;
      foreach (UIWidget objWidget in this.ObjWidgets)
        objWidget.color = spriteDisabledColor;
      foreach (UIWidget objSprite in this.ObjSprites)
        objSprite.color = gray;
      ((Behaviour) ((Component) this).GetComponent<TweenScale>()).enabled = false;
    }
    this.anim = flag;
  }

  [DebuggerHidden]
  private IEnumerator InitButton(string color, bool eventQuest)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new QuestHScrollButton.\u003CInitButton\u003Ec__Iterator1D0()
    {
      color = color,
      eventQuest = eventQuest,
      \u003C\u0024\u003Ecolor = color,
      \u003C\u0024\u003EeventQuest = eventQuest,
      \u003C\u003Ef__this = this
    };
  }

  private void OverOrOut(bool over)
  {
    ((Component) this.IdleSprite).gameObject.SetActive(!over);
    ((Component) this.PressSprite).gameObject.SetActive(over);
  }

  [DebuggerHidden]
  private IEnumerator SetSpritePaths(string colorName, bool eventQuest)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new QuestHScrollButton.\u003CSetSpritePaths\u003Ec__Iterator1D1()
    {
      eventQuest = eventQuest,
      colorName = colorName,
      \u003C\u0024\u003EeventQuest = eventQuest,
      \u003C\u0024\u003EcolorName = colorName,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator CreateSprite(string path, UI2DSprite spriteobj)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new QuestHScrollButton.\u003CCreateSprite\u003Ec__Iterator1D2()
    {
      path = path,
      spriteobj = spriteobj,
      \u003C\u0024\u003Epath = path,
      \u003C\u0024\u003Espriteobj = spriteobj,
      \u003C\u003Ef__this = this
    };
  }

  private void AtacheSprite(Sprite spr, UI2DSprite sprobj)
  {
    UI2DSprite ui2Dsprite1 = sprobj;
    Rect rect1 = spr.rect;
    int num1 = Mathf.FloorToInt(((Rect) ref rect1).width);
    ui2Dsprite1.width = num1;
    UI2DSprite ui2Dsprite2 = sprobj;
    Rect rect2 = spr.rect;
    int num2 = Mathf.FloorToInt(((Rect) ref rect2).height);
    ui2Dsprite2.height = num2;
    sprobj.sprite2D = spr;
  }
}
