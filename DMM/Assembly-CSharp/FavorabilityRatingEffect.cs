// Decompiled with JetBrains decompiler
// Type: FavorabilityRatingEffect
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

public class FavorabilityRatingEffect : MonoBehaviour
{
  private const int RELEASE_SKILL = 0;
  private const int RELEASE_SKILL_FRAME = 1;
  private FavorabilityRatingEffect.AnimationType animationType;
  private FavorabilityRatingEffect.AnimState animState;
  private bool isTrustUpperLimit;
  private System.Action endAction;
  private Modified<Player> playerModified;
  private PlayerUnit unit;
  [SerializeField]
  private UI2DSprite slc_background;
  [SerializeField]
  private Animator animController;
  [SerializeField]
  private Vector3[] txtDearDegreePos;
  [SerializeField]
  private Vector3[] txtAchievementPos;
  [SerializeField]
  private GameObject txtDearDegree;
  [SerializeField]
  private UILabel txtPercent;
  [SerializeField]
  private GameObject txtAchievement;
  [SerializeField]
  private UI2DSprite dynUnitThum;
  [SerializeField]
  private LoveGaugeController loveGaugeController;
  [SerializeField]
  private GameObject[] slcTextSprite;
  [SerializeField]
  private GameObject dyn_unit;
  [SerializeField]
  private GameObject dir_ballon;
  [SerializeField]
  private UI2DSprite dyn_unit_thum;
  [SerializeField]
  private UILabel txt_unit_name;
  [SerializeField]
  private UILabel txt_message;
  private NGxFaceSprite unitFace;
  private string[] serifs;
  private string[] voices;
  private int serifIndex;
  [SerializeField]
  private UILabel txt_skill_name;
  [SerializeField]
  private UILabel txt_skill_description;
  [SerializeField]
  private UI2DSprite dyn_Unit_Skill;
  [SerializeField]
  private UILabel label_SkillLvMax;
  [SerializeField]
  private Transform skillTargetParent1;
  [SerializeField]
  private Transform skillTargetParent2;
  [SerializeField]
  private AnchorCustomAdjustment anchorCustomAdjustment;
  private bool skipUnitAnimation;

  private GameObject CreateGenreIcon(GameObject prefab, Transform trans)
  {
    GameObject gameObject = prefab.Clone(trans);
    UI2DSprite componentInChildren = gameObject.GetComponentInChildren<UI2DSprite>();
    if (!((UnityEngine.Object) componentInChildren != (UnityEngine.Object) null))
      return gameObject;
    componentInChildren.depth += 150;
    return gameObject;
  }

  private IEnumerator SetBackground(string name)
  {
    Future<UnityEngine.Sprite> bgF = new ResourceObject(string.Format(Consts.GetInstance().BACKGROUND_BASE_PATH, (object) name)).Load<UnityEngine.Sprite>();
    IEnumerator e = bgF.Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    if ((UnityEngine.Object) bgF.Result != (UnityEngine.Object) null)
      this.slc_background.sprite2D = bgF.Result;
  }

  public IEnumerator Init(
    FavorabilityRatingEffect.AnimationType anmType,
    PlayerUnit playerUnit,
    System.Action action,
    bool skipUnitAnimation = false,
    bool isPreview = false)
  {
    FavorabilityRatingEffect favorabilityRatingEffect = this;
    if (favorabilityRatingEffect.playerModified == null)
      favorabilityRatingEffect.playerModified = SMManager.Observe<Player>();
    favorabilityRatingEffect.animationType = anmType;
    favorabilityRatingEffect.endAction = action;
    favorabilityRatingEffect.unit = playerUnit;
    List<SwitchUnitComponentBase> list = ((IEnumerable<SwitchUnitComponentBase>) favorabilityRatingEffect.GetComponentsInChildren<SwitchUnitComponentBase>(true)).ToList<SwitchUnitComponentBase>();
    for (int index = 0; index < list.Count; ++index)
      list[index].SwitchMaterial(favorabilityRatingEffect.unit.unit.ID);
    favorabilityRatingEffect.skipUnitAnimation = skipUnitAnimation;
    favorabilityRatingEffect.animState = FavorabilityRatingEffect.AnimState.Start;
    Future<UnityEngine.Sprite> spriteF = playerUnit.unit.LoadSpriteThumbnail();
    IEnumerator e = spriteF.Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    favorabilityRatingEffect.dynUnitThum.sprite2D = spriteF.Result;
    spriteF = (Future<UnityEngine.Sprite>) null;
    int num = (int) playerUnit.trust_rate;
    if (anmType == FavorabilityRatingEffect.AnimationType.SkillFrameRelease)
      num = PlayerUnit.GetExtraSkillReleaseRate();
    Consts instance = Consts.GetInstance();
    favorabilityRatingEffect.txtPercent.SetTextLocalize(Consts.Format(Consts.GetInstance().UNIT_TRUST_RATE_PERCENT, (IDictionary) new Hashtable()
    {
      {
        (object) "trust_rate",
        (object) string.Format("{0}", (object) (float) ((double) Mathf.FloorToInt((float) num / instance.TRUST_RATE_LEVEL_SIZE) * (double) instance.TRUST_RATE_LEVEL_SIZE))
      }
    }));
    favorabilityRatingEffect.txtDearDegree.transform.localPosition = favorabilityRatingEffect.txtDearDegreePos[(int) favorabilityRatingEffect.animationType];
    favorabilityRatingEffect.txtAchievement.transform.localPosition = favorabilityRatingEffect.txtAchievementPos[(int) favorabilityRatingEffect.animationType];
    ((IEnumerable<GameObject>) favorabilityRatingEffect.slcTextSprite).ToggleOnce((int) favorabilityRatingEffect.animationType);
    if (anmType == FavorabilityRatingEffect.AnimationType.SkillRelease)
    {
      UnitSkillAwake[] awakeSkills = playerUnit.GetAwakeSkills();
      if (awakeSkills != null && awakeSkills.Length != 0)
      {
        GameObject skillGenrePrefab = (GameObject) null;
        Future<GameObject> prefabF = Res.Icons.SkillGenreIcon.Load<GameObject>();
        e = prefabF.Wait();
        while (e.MoveNext())
          yield return e.Current;
        e = (IEnumerator) null;
        skillGenrePrefab = prefabF.Result;
        BattleskillSkill skill = awakeSkills[0].skill;
        favorabilityRatingEffect.txt_skill_name.SetTextLocalize(skill.name);
        favorabilityRatingEffect.txt_skill_description.SetTextLocalize(skill.description);
        favorabilityRatingEffect.label_SkillLvMax.SetTextLocalize(skill.upper_level);
        spriteF = skill.LoadBattleSkillIcon();
        e = spriteF.Wait();
        while (e.MoveNext())
          yield return e.Current;
        e = (IEnumerator) null;
        favorabilityRatingEffect.dyn_Unit_Skill.sprite2D = spriteF.Result;
        favorabilityRatingEffect.CreateGenreIcon(skillGenrePrefab, favorabilityRatingEffect.skillTargetParent1).GetComponent<SkillGenreIcon>().Init(skill.genre1);
        favorabilityRatingEffect.CreateGenreIcon(skillGenrePrefab, favorabilityRatingEffect.skillTargetParent2).GetComponent<SkillGenreIcon>().Init(skill.genre2);
        skillGenrePrefab = (GameObject) null;
        prefabF = (Future<GameObject>) null;
        skill = (BattleskillSkill) null;
        spriteF = (Future<UnityEngine.Sprite>) null;
      }
      e = favorabilityRatingEffect.SettingTrustGaugeMaxInfo(favorabilityRatingEffect.unit);
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      favorabilityRatingEffect.anchorCustomAdjustment.resetAnchors();
      awakeSkills = (UnitSkillAwake[]) null;
    }
    favorabilityRatingEffect.StartCoroutine(favorabilityRatingEffect.loveGaugeController.setValue((int) playerUnit.trust_rate, (int) playerUnit.trust_rate, (int) playerUnit.trust_max_rate, (int) Consts.GetInstance().TRUST_RATE_LEVEL_SIZE, false));
  }

  public void StartEffect()
  {
    if (this.animationType == FavorabilityRatingEffect.AnimationType.SkillRelease)
    {
      if (this.skipUnitAnimation)
        this.animController.SetTrigger("skill_start_without_unit_animation");
      else
        this.animController.SetTrigger("skill_start");
    }
    else
      this.animController.SetTrigger("skill_frame_start");
  }

  private IEnumerator SettingTrustGaugeMaxInfo(PlayerUnit playerUnit)
  {
    FavorabilityRatingEffect favorabilityRatingEffect = this;
    if (favorabilityRatingEffect.skipUnitAnimation)
    {
      favorabilityRatingEffect.animState = FavorabilityRatingEffect.AnimState.Loop;
      favorabilityRatingEffect.animController.SetTrigger("skill_unit_end");
    }
    else
    {
      UnitUnit pUnit = playerUnit.unit;
      favorabilityRatingEffect.dyn_unit.transform.Clear();
      Future<GameObject> future = pUnit.LoadStory();
      IEnumerator e = future.Wait();
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      UnityEngine.Sprite sprite = (UnityEngine.Sprite) null;
      if (pUnit.ExistSpriteStory())
      {
        Future<UnityEngine.Sprite> spriteFuture = pUnit.LoadSpriteStory();
        e = spriteFuture.Wait();
        while (e.MoveNext())
          yield return e.Current;
        e = (IEnumerator) null;
        sprite = spriteFuture.Result;
        spriteFuture = (Future<UnityEngine.Sprite>) null;
      }
      GameObject spriteObject = future.Result.Clone(favorabilityRatingEffect.dyn_unit.transform);
      spriteObject.GetComponent<UIWidget>().depth = 8;
      pUnit.SetStoryData(spriteObject);
      NGxMaskSpriteWithScale component1 = spriteObject.GetComponent<NGxMaskSpriteWithScale>();
      if ((UnityEngine.Object) sprite != (UnityEngine.Object) null)
        component1.MainUI2DSprite.sprite2D = sprite;
      component1.SetMaskEnable(false);
      UIWidget component2 = favorabilityRatingEffect.dyn_unit.GetComponent<UIWidget>();
      if ((UnityEngine.Object) component2 != (UnityEngine.Object) null)
      {
        UIWidget w = spriteObject.GetComponent<UIWidget>();
        w.depth = component2.depth;
        UIWidget[] componentsInChildren = spriteObject.GetComponentsInChildren<UIWidget>();
        ((IEnumerable<UIWidget>) componentsInChildren).Where<UIWidget>((Func<UIWidget, bool>) (v => v.transform.name == "face")).ForEach<UIWidget>((System.Action<UIWidget>) (v => v.depth = w.depth + 1));
        ((IEnumerable<UIWidget>) componentsInChildren).Where<UIWidget>((Func<UIWidget, bool>) (v => v.transform.name == "eye")).ForEach<UIWidget>((System.Action<UIWidget>) (v => v.depth = w.depth + 2));
      }
      Future<UnityEngine.Sprite> thumFuture = pUnit.LoadSpriteThumbnail();
      e = thumFuture.Wait();
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      UnityEngine.Sprite result = thumFuture.Result;
      favorabilityRatingEffect.dyn_unit_thum.sprite2D = result;
      favorabilityRatingEffect.dyn_unit_thum.width = (int) result.rect.width;
      favorabilityRatingEffect.dyn_unit_thum.height = (int) result.rect.height;
      favorabilityRatingEffect.txt_unit_name.SetTextLocalize(pUnit.name);
      favorabilityRatingEffect.serifIndex = 0;
      // ISSUE: reference to a compiler-generated method
      UnitTrustUpperLimitEffect upperLimitData = ((IEnumerable<UnitTrustUpperLimitEffect>) MasterData.UnitTrustUpperLimitEffectList).FirstOrDefault<UnitTrustUpperLimitEffect>(new Func<UnitTrustUpperLimitEffect, bool>(favorabilityRatingEffect.\u003CSettingTrustGaugeMaxInfo\u003Eb__41_0));
      favorabilityRatingEffect.serifs = upperLimitData.GetSerif();
      favorabilityRatingEffect.voices = upperLimitData.GetVoice();
      if (!string.IsNullOrEmpty(upperLimitData.background))
      {
        e = favorabilityRatingEffect.SetBackground(upperLimitData.background);
        while (e.MoveNext())
          yield return e.Current;
        e = (IEnumerator) null;
      }
      favorabilityRatingEffect.unitFace = spriteObject.GetComponent<NGxFaceSprite>();
      favorabilityRatingEffect.unitFace.GetComponent<UIWidget>().depth = 9;
      e = favorabilityRatingEffect.unitFace.ChangeFace(upperLimitData.face);
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      if (!favorabilityRatingEffect.SetSerif(favorabilityRatingEffect.serifs, favorabilityRatingEffect.voices, favorabilityRatingEffect.serifIndex))
      {
        favorabilityRatingEffect.animState = FavorabilityRatingEffect.AnimState.Loop;
        favorabilityRatingEffect.animController.SetTrigger("skill_unit_end");
      }
    }
  }

  private bool SetSerif(string[] serifs, string[] voiceCues, int index)
  {
    Hashtable hashtable = (Hashtable) null;
    int num = ((IEnumerable<string>) serifs).Count<string>();
    if (serifs == null || num < 0 || num <= index)
      return false;
    if (hashtable == null || hashtable != null && !hashtable.ContainsKey((object) "userName"))
    {
      if (hashtable == null)
        hashtable = new Hashtable();
      hashtable.Add((object) "userName", (object) this.playerModified.Value.name);
    }
    this.txt_message.SetTextLocalize(Consts.Format(serifs[index], (IDictionary) hashtable));
    if (((IEnumerable<string>) voiceCues).Count<string>() > index && !string.IsNullOrEmpty(voiceCues[index]))
    {
      Singleton<NGSoundManager>.GetInstance().StopVoice(time: 0.0f);
      Singleton<NGSoundManager>.GetInstance().playVoiceByStringID(this.unit.unit.unitVoicePattern, voiceCues[index]);
    }
    return true;
  }

  public void TapSerif()
  {
    ++this.serifIndex;
    if (this.SetSerif(this.serifs, this.voices, this.serifIndex))
      return;
    this.animState = FavorabilityRatingEffect.AnimState.Loop;
    this.animController.SetTrigger("skill_unit_end");
    Singleton<NGSoundManager>.GetInstance().StopVoice(time: 0.0f);
  }

  public void onClickSkipBtn()
  {
    string name = string.Empty;
    if (this.animationType == FavorabilityRatingEffect.AnimationType.SkillFrameRelease)
    {
      switch (this.animState)
      {
        case FavorabilityRatingEffect.AnimState.Start:
          this.animState = FavorabilityRatingEffect.AnimState.Loop;
          name = "loop";
          break;
        case FavorabilityRatingEffect.AnimState.Loop:
          this.animState = FavorabilityRatingEffect.AnimState.End;
          name = "skill_release_close_anim";
          break;
      }
    }
    else
    {
      switch (this.animState)
      {
        case FavorabilityRatingEffect.AnimState.Loop:
          this.animState = FavorabilityRatingEffect.AnimState.End;
          name = "skill_loop";
          break;
        case FavorabilityRatingEffect.AnimState.End:
          name = "skill_end";
          break;
      }
    }
    if (string.IsNullOrEmpty(name))
      return;
    this.animController.SetTrigger(name);
  }

  public void StartAnimationEnd()
  {
    this.animState = FavorabilityRatingEffect.AnimState.Loop;
    this.animController.SetTrigger("loop");
  }

  public void UnitEndAnimationEnd() => this.animState = FavorabilityRatingEffect.AnimState.Loop;

  public void SkillAnimationEnd()
  {
    this.animState = FavorabilityRatingEffect.AnimState.End;
    this.animController.SetTrigger("skill_loop");
  }

  public void AnimationEnd()
  {
    if (this.endAction == null)
      return;
    this.endAction();
  }

  public enum AnimationType
  {
    None = -1, // 0xFFFFFFFF
    SkillRelease = 0,
    SkillFrameRelease = 1,
    Max = 2,
  }

  private enum AnimState
  {
    Start,
    Loop,
    End,
    Finish,
  }
}
