// Decompiled with JetBrains decompiler
// Type: Battle01GrandStatus
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using System;
using System.Collections;
using UnityEngine;

public class Battle01GrandStatus : NGBattleMenuBase
{
  [SerializeField]
  private UILabel place;
  [SerializeField]
  private UILabel hit;
  [SerializeField]
  private UILabel pDefense;
  [SerializeField]
  private UILabel mDefense;
  [SerializeField]
  private UILabel stay;
  [SerializeField]
  private GameObject descriptionRoot;
  [SerializeField]
  private UILabel description;
  [SerializeField]
  private NGTweenParts descriptionTween;
  [SerializeField]
  private UILabel[] landformTagLabels;
  private Transform[] skillLandformTagLabelAnchorDefaultTarget;
  private float[] skillLandformTagLabelAnchorDefaultRelative;
  private int[] skillLandformTagLabelAnchorDefaultAbsolute;
  private BL.BattleModified<BL.ClassValue<BL.Panel>> modified;

  private void OnEnable()
  {
    if (this.env == null || this.env.core.fieldCurrent.value == null)
      return;
    this.updateTagLabels(this.env.core.fieldCurrent.value);
  }

  private string numberString(int v) => v <= 0 ? string.Concat((object) v) : "+" + (object) v;

  private string percentString(int v) => v <= 0 ? v.ToString() + "%" : "+" + (object) v + "%";

  public override IEnumerator onInitAsync()
  {
    // ISSUE: reference to a compiler-generated field
    int num = this.\u003C\u003E1__state;
    Battle01GrandStatus battle01GrandStatus = this;
    if (num != 0)
      return false;
    // ISSUE: reference to a compiler-generated field
    this.\u003C\u003E1__state = -1;
    battle01GrandStatus.modified = BL.Observe<BL.ClassValue<BL.Panel>>(battle01GrandStatus.env.core.fieldCurrent);
    return false;
  }

  public void setText(UILabel label, int v, float? ratio)
  {
    if (ratio.HasValue)
    {
      int v1 = Mathf.RoundToInt((float) ((double) ratio.Value * 100.0 - 100.0));
      this.setText(label, this.percentString(v1));
    }
    else
      this.setText(label, this.numberString(v));
  }

  protected override void LateUpdate_Battle()
  {
    if (!this.modified.isChangedOnce() || this.env.core.fieldCurrent.value == null)
      return;
    BattleLandform landform = this.env.core.fieldCurrent.value.landform;
    BattleLandformIncr displayIncr = landform.GetDisplayIncr();
    this.setText(this.place, landform.name);
    this.setText(this.hit, displayIncr.hit_incr, displayIncr.hit_ratio_incr);
    this.setText(this.pDefense, displayIncr.physical_defense_incr, displayIncr.physical_defense_ratio_incr);
    this.setText(this.mDefense, displayIncr.magic_defense_incr, displayIncr.magic_defense_ratio_incr);
    this.setText(this.stay, displayIncr.evasion_incr, displayIncr.evasion_ratio_incr);
    this.updateTagLabels(this.env.core.fieldCurrent.value);
    BL.Unit unit = this.env.core.unitCurrent.unit;
    if (unit == (BL.Unit) null || this.env.core.currentUnitPosition != null && unit.isView && !this.env.unitResource[unit].unitParts_.isMoving)
    {
      this.SetTextLandformDescription(landform.description);
    }
    else
    {
      if (this.env.core.currentUnitPosition == null || !unit.isView || !this.env.unitResource[unit].unitParts_.isMoving)
        return;
      this.descriptionTween.isActive = false;
    }
  }

  private void SetTextLandformDescription(string descriptionText)
  {
    if ((UnityEngine.Object) this.descriptionTween == (UnityEngine.Object) null)
      return;
    if (string.IsNullOrEmpty(descriptionText))
    {
      this.descriptionTween.isActive = false;
    }
    else
    {
      this.setText(this.description, descriptionText);
      this.descriptionTween.isActive = true;
    }
  }

  private void updateTagLabels(BL.Panel panel)
  {
    if (this.landformTagLabels == null || this.landformTagLabels.Length < 4)
      return;
    BL.SkillEffect skillEffect = panel.getSkillEffects().value.Find((Predicate<BL.SkillEffect>) (x => x.effect.EffectLogic.Enum == BattleskillEffectLogicEnum.invest_land_tag));
    int num = skillEffect != null ? skillEffect.effect.GetInt(BattleskillEffectLogicArgumentEnum.land_tag) : 0;
    if (this.skillLandformTagLabelAnchorDefaultTarget == null)
    {
      this.skillLandformTagLabelAnchorDefaultTarget = new Transform[4];
      this.skillLandformTagLabelAnchorDefaultTarget[0] = this.landformTagLabels[3].leftAnchor.target;
      this.skillLandformTagLabelAnchorDefaultTarget[1] = this.landformTagLabels[3].rightAnchor.target;
      this.skillLandformTagLabelAnchorDefaultTarget[2] = this.landformTagLabels[3].bottomAnchor.target;
      this.skillLandformTagLabelAnchorDefaultTarget[3] = this.landformTagLabels[3].topAnchor.target;
      this.skillLandformTagLabelAnchorDefaultRelative = new float[4];
      this.skillLandformTagLabelAnchorDefaultRelative[0] = this.landformTagLabels[3].leftAnchor.relative;
      this.skillLandformTagLabelAnchorDefaultRelative[1] = this.landformTagLabels[3].rightAnchor.relative;
      this.skillLandformTagLabelAnchorDefaultRelative[2] = this.landformTagLabels[3].bottomAnchor.relative;
      this.skillLandformTagLabelAnchorDefaultRelative[3] = this.landformTagLabels[3].topAnchor.relative;
      this.skillLandformTagLabelAnchorDefaultAbsolute = new int[4];
      this.skillLandformTagLabelAnchorDefaultAbsolute[0] = this.landformTagLabels[3].leftAnchor.absolute;
      this.skillLandformTagLabelAnchorDefaultAbsolute[1] = this.landformTagLabels[3].rightAnchor.absolute;
      this.skillLandformTagLabelAnchorDefaultAbsolute[2] = this.landformTagLabels[3].bottomAnchor.absolute;
      this.skillLandformTagLabelAnchorDefaultAbsolute[3] = this.landformTagLabels[3].topAnchor.absolute;
    }
    BattleLandform landform = panel.landform;
    int[] numArray = new int[4]
    {
      landform.tag1,
      landform.tag2,
      landform.tag3,
      num
    };
    UILabel uiLabel = (UILabel) null;
    for (int index = 0; index < 4; ++index)
    {
      BattleLandformTag battleLandformTag;
      if (numArray[index] != 0 && MasterData.BattleLandformTag.TryGetValue(numArray[index], out battleLandformTag))
      {
        this.landformTagLabels[index].gameObject.SetActive(true);
        this.setText(this.landformTagLabels[index], battleLandformTag.type);
        if (index == 3)
        {
          UILabel landformTagLabel = this.landformTagLabels[3];
          if ((UnityEngine.Object) uiLabel != (UnityEngine.Object) null)
          {
            landformTagLabel.leftAnchor.target = uiLabel.leftAnchor.target;
            landformTagLabel.rightAnchor.target = uiLabel.rightAnchor.target;
            landformTagLabel.topAnchor.target = uiLabel.topAnchor.target;
            landformTagLabel.bottomAnchor.target = uiLabel.bottomAnchor.target;
            landformTagLabel.leftAnchor.relative = uiLabel.leftAnchor.relative;
            landformTagLabel.rightAnchor.relative = uiLabel.rightAnchor.relative;
            landformTagLabel.topAnchor.relative = uiLabel.topAnchor.relative;
            landformTagLabel.bottomAnchor.relative = uiLabel.bottomAnchor.relative;
            landformTagLabel.leftAnchor.absolute = uiLabel.leftAnchor.absolute;
            landformTagLabel.rightAnchor.absolute = uiLabel.rightAnchor.absolute;
            landformTagLabel.topAnchor.absolute = uiLabel.topAnchor.absolute;
            landformTagLabel.bottomAnchor.absolute = uiLabel.bottomAnchor.absolute;
          }
          else
          {
            landformTagLabel.leftAnchor.target = this.skillLandformTagLabelAnchorDefaultTarget[0];
            landformTagLabel.rightAnchor.target = this.skillLandformTagLabelAnchorDefaultTarget[1];
            landformTagLabel.bottomAnchor.target = this.skillLandformTagLabelAnchorDefaultTarget[2];
            landformTagLabel.topAnchor.target = this.skillLandformTagLabelAnchorDefaultTarget[3];
            landformTagLabel.leftAnchor.relative = this.skillLandformTagLabelAnchorDefaultRelative[0];
            landformTagLabel.rightAnchor.relative = this.skillLandformTagLabelAnchorDefaultRelative[1];
            landformTagLabel.bottomAnchor.relative = this.skillLandformTagLabelAnchorDefaultRelative[2];
            landformTagLabel.topAnchor.relative = this.skillLandformTagLabelAnchorDefaultRelative[3];
            landformTagLabel.leftAnchor.absolute = this.skillLandformTagLabelAnchorDefaultAbsolute[0];
            landformTagLabel.rightAnchor.absolute = this.skillLandformTagLabelAnchorDefaultAbsolute[1];
            landformTagLabel.bottomAnchor.absolute = this.skillLandformTagLabelAnchorDefaultAbsolute[2];
            landformTagLabel.topAnchor.absolute = this.skillLandformTagLabelAnchorDefaultAbsolute[3];
          }
          landformTagLabel.ResetAnchors();
          landformTagLabel.UpdateAnchors();
        }
        this.landformTagLabels[index].MakePixelPerfect();
      }
      else
      {
        if ((UnityEngine.Object) uiLabel == (UnityEngine.Object) null)
          uiLabel = this.landformTagLabels[index];
        this.setText(this.landformTagLabels[index], "");
        this.landformTagLabels[index].gameObject.SetActive(false);
      }
      this.landformTagLabels[index].SetDirty();
    }
  }
}
