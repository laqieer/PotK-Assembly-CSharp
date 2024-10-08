﻿// Decompiled with JetBrains decompiler
// Type: ExtraSkillInfo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ExtraSkillInfo : MonoBehaviour
{
  [SerializeField]
  private UI2DSprite dynExtraSkill;
  [SerializeField]
  private UILabel txtSkillName;
  [SerializeField]
  private UILabel txtSkillDescription;
  [SerializeField]
  private UILabel txtSkillLevel;
  [SerializeField]
  private GameObject[] dynSkillGenreIcons;
  [SerializeField]
  private GameObject[] ibtnFavoritei;
  [SerializeField]
  private UILabel txtCategoryDescription;
  private System.Action<bool> favoriteAction;
  private GameObject skillDetailPrefab;
  private PlayerAwakeSkill targetSkill;

  private GameObject createGenreIcon(GameObject prefab, Transform trans)
  {
    GameObject gameObject = prefab.Clone(trans);
    UI2DSprite componentInChildren = gameObject.GetComponentInChildren<UI2DSprite>();
    if (!((UnityEngine.Object) componentInChildren != (UnityEngine.Object) null))
      return gameObject;
    componentInChildren.depth += 150;
    return gameObject;
  }

  public IEnumerator Init(
    PlayerAwakeSkill skill,
    bool favorite,
    UnityEngine.Sprite skillSprite,
    GameObject genrePrefab,
    System.Action<bool> favoriteAct = null)
  {
    BattleskillSkill masterData = skill.masterData;
    this.favoriteAction = favoriteAct;
    this.targetSkill = skill;
    IEnumerator e;
    if ((UnityEngine.Object) skillSprite != (UnityEngine.Object) null)
    {
      this.dynExtraSkill.sprite2D = skillSprite;
    }
    else
    {
      Future<UnityEngine.Sprite> spriteF = masterData.LoadBattleSkillIcon();
      e = spriteF.Wait();
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      this.dynExtraSkill.sprite2D = spriteF.Result;
      spriteF = (Future<UnityEngine.Sprite>) null;
    }
    this.txtSkillName.SetTextLocalize(masterData.name);
    this.txtSkillDescription.SetTextLocalize(masterData.description);
    this.txtSkillLevel.SetTextLocalize(Consts.Format(Consts.GetInstance().extra_skillI_thumb_skill_level_text, (IDictionary) new Hashtable()
    {
      {
        (object) "level",
        (object) skill.level
      },
      {
        (object) "max",
        (object) masterData.upper_level
      }
    }));
    this.txtCategoryDescription.SetTextLocalize(AwakeSkillCategory.GetEquipableText(masterData.awake_skill_category_id));
    GameObject prefab = genrePrefab;
    Future<GameObject> prefabF;
    if ((UnityEngine.Object) prefab == (UnityEngine.Object) null)
    {
      prefabF = Res.Icons.SkillGenreIcon.Load<GameObject>();
      e = prefabF.Wait();
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      prefab = prefabF.Result;
      prefabF = (Future<GameObject>) null;
    }
    this.dynSkillGenreIcons[0].transform.Clear();
    this.dynSkillGenreIcons[1].transform.Clear();
    this.createGenreIcon(prefab, this.dynSkillGenreIcons[0].transform).GetComponent<SkillGenreIcon>().Init(masterData.genre1);
    this.createGenreIcon(prefab, this.dynSkillGenreIcons[1].transform).GetComponent<SkillGenreIcon>().Init(masterData.genre2);
    if ((UnityEngine.Object) this.skillDetailPrefab == (UnityEngine.Object) null)
    {
      prefabF = PopupSkillDetails.createPrefabLoader(false);
      yield return (object) prefabF.Wait();
      this.skillDetailPrefab = prefabF.Result;
      prefabF = (Future<GameObject>) null;
    }
    if (favorite)
      ((IEnumerable<GameObject>) this.ibtnFavoritei).ToggleOnce(0);
    else
      ((IEnumerable<GameObject>) this.ibtnFavoritei).ToggleOnce(1);
  }

  public void setEnableFavoriteSwitch(bool bEnabled)
  {
    foreach (UIButtonColor uiButtonColor in ((IEnumerable<GameObject>) this.ibtnFavoritei).Select<GameObject, UIButton>((Func<GameObject, UIButton>) (x => x.GetComponentInChildren<UIButton>(true))))
      uiButtonColor.isEnabled = bEnabled;
  }

  public void onClickFavoriteON()
  {
    ((IEnumerable<GameObject>) this.ibtnFavoritei).ToggleOnce(1);
    if (this.favoriteAction == null)
      return;
    this.favoriteAction(false);
  }

  public void onClickFavoriteOFF()
  {
    ((IEnumerable<GameObject>) this.ibtnFavoritei).ToggleOnce(0);
    if (this.favoriteAction == null)
      return;
    this.favoriteAction(true);
  }

  public void onClickSkillZoom()
  {
    if (this.targetSkill == null || (UnityEngine.Object) this.skillDetailPrefab == (UnityEngine.Object) null)
      return;
    PopupSkillDetails.show(this.skillDetailPrefab, PopupSkillDetails.Param.createBySkillView(this.targetSkill));
  }

  private enum FavoriteIdx
  {
    ON,
    OFF,
  }
}
