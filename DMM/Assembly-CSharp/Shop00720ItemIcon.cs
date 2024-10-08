﻿// Decompiled with JetBrains decompiler
// Type: Shop00720ItemIcon
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using System;
using System.Collections;
using System.Collections.Generic;
using UniLinq;
using UnityEngine;

public class Shop00720ItemIcon : EffectController
{
  [SerializeField]
  private List<GameObject> icon_obj_list_;
  [SerializeField]
  private GameObject unit_obj_;
  [SerializeField]
  private UI2DSprite unit_sprite_;
  [SerializeField]
  public UIDragScrollView dragScroll;
  [SerializeField]
  private GameObject num_cross;
  [SerializeField]
  private UI2DSprite num_ones;
  [SerializeField]
  private UI2DSprite num_tens;
  [SerializeField]
  private UnityEngine.Sprite[] digit_sprite;
  [SerializeField]
  private Animator effect_anima;
  [SerializeField]
  private GameObject num_icon_obj;
  [SerializeField]
  private GameObject unit_icon_obj_;
  [SerializeField]
  private UI2DSprite unit_icon_type_;
  [SerializeField]
  private UI2DSprite unit_icon_star_;
  [SerializeField]
  private GameObject unit_icon_new_;
  [SerializeField]
  private GameObject item_icon_obj_;
  [SerializeField]
  private UI2DSprite item_icon_back_;
  [SerializeField]
  private UnityEngine.Sprite[] back_sprite_equipment_units_;
  [SerializeField]
  private UnityEngine.Sprite back_sprite_weapon_;
  [SerializeField]
  private UnityEngine.Sprite[] item_back_sprite_;
  [SerializeField]
  private UI2DSprite item_icon_type_;
  [SerializeField]
  private GameObject item_icon_star_;
  [SerializeField]
  private GameObject item_icon_frame_;
  [SerializeField]
  private List<GameObject> item_icon_star_list_;
  private Vector3 StarIntialLocalPosition;

  public IEnumerator SetIcon(WebAPI.Response.SlotS001MedalPayResult resultData, int num)
  {
    this.StarIntialLocalPosition = this.item_icon_star_.transform.localPosition;
    CommonRewardType crt = new CommonRewardType(resultData.reward_type_id, resultData.reward_result_id, resultData.reward_result_quantity, resultData.is_new);
    this.SetItemNum(num);
    UnitUnit unit = crt.unitUnit;
    GearGear gear = crt.gearGear;
    SupplySupply supplySupply = crt.supplySupply;
    int index = ((IEnumerable<SlotS001MedalRarity>) MasterData.SlotS001MedalRarityList).SingleOrDefault<SlotS001MedalRarity>((Func<SlotS001MedalRarity, bool>) (sd => sd.ID == resultData.rarity_id)).index;
    Future<UnityEngine.Sprite> spritef;
    IEnumerator e;
    if (unit != null)
    {
      spritef = MasterData.UnitUnit[unit.ID].LoadSpriteThumbnail();
      e = spritef.Wait();
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      this.unit_sprite_.sprite2D = spritef.Result;
      this.unit_sprite_.MakePixelPerfect();
      this.SetUnitIcon(unit, resultData.is_new);
      this.icon_obj_list_.Add(this.unit_obj_);
      spritef = (Future<UnityEngine.Sprite>) null;
    }
    else if (gear != null)
    {
      spritef = MasterData.GearGear[gear.ID].LoadSpriteThumbnail();
      e = spritef.Wait();
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      this.unit_sprite_.sprite2D = spritef.Result;
      bool isWeaponMaterial = crt.type_ == 35;
      this.SetItemIcon(gear, isWeaponMaterial, resultData.is_new);
      this.unit_sprite_.transform.localPosition = new Vector3(0.0f, -10f, 0.0f);
      this.icon_obj_list_.Add(this.unit_obj_);
      spritef = (Future<UnityEngine.Sprite>) null;
    }
    else if (supplySupply != null)
    {
      spritef = MasterData.SupplySupply[supplySupply.ID].LoadSpriteThumbnail();
      e = spritef.Wait();
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      this.unit_sprite_.sprite2D = spritef.Result;
      this.SetSupplyIcon();
      this.icon_obj_list_.Add(this.unit_obj_);
      spritef = (Future<UnityEngine.Sprite>) null;
    }
    else
    {
      e = this.SetTextureItemThum(crt, this.unit_sprite_.sprite2D);
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      this.SetSupplyIcon();
      this.unit_sprite_.transform.localPosition = new Vector3(0.0f, -10f, 0.0f);
      this.icon_obj_list_.Add(this.unit_obj_);
    }
  }

  public void IconView(bool view)
  {
    for (int index = 0; index < this.icon_obj_list_.Count; ++index)
      this.icon_obj_list_[index].SetActive(view);
    this.num_icon_obj.SetActive(view);
  }

  private void SetItemNum(int num)
  {
    this.num_cross.SetActive(true);
    if (num < 10)
    {
      this.num_ones.gameObject.SetActive(true);
      this.num_tens.gameObject.SetActive(false);
      this.num_ones.sprite2D = this.digit_sprite[num];
      this.num_ones.MakePixelPerfect();
      this.num_cross.transform.localPosition = new Vector3(19f, this.num_cross.transform.localPosition.y, 0.0f);
    }
    else
    {
      this.num_ones.gameObject.SetActive(true);
      this.num_tens.gameObject.SetActive(true);
      this.num_ones.sprite2D = this.digit_sprite[num % 10];
      this.num_ones.MakePixelPerfect();
      this.num_tens.sprite2D = this.digit_sprite[num / 10];
      this.num_tens.MakePixelPerfect();
      this.num_cross.transform.localPosition = new Vector3(-3f, this.num_cross.transform.localPosition.y, 0.0f);
    }
  }

  private AnimationItemIcon SetCloneItemIcon(
    AnimationItemIcon icon,
    Transform trans,
    GameObject obj,
    GearGear item,
    bool isWeaponMaterial,
    bool new_flag = false)
  {
    if ((UnityEngine.Object) icon != (UnityEngine.Object) null && (UnityEngine.Object) icon.gameObject.transform.parent != (UnityEngine.Object) trans.transform)
    {
      UnityEngine.Object.Destroy((UnityEngine.Object) icon.gameObject);
      icon = (AnimationItemIcon) null;
    }
    if ((UnityEngine.Object) icon == (UnityEngine.Object) null)
      icon = obj.Clone(trans.transform).GetComponent<AnimationItemIcon>();
    else
      icon.gameObject.SetActive(true);
    icon.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
    icon.transform.localRotation = Quaternion.Euler(0.0f, -180f, 0.0f);
    icon.gameObject.name = "AnimationItemIcon";
    icon.Set(item, isWeaponMaterial, new_flag);
    this.SetLayer(icon.gameObject.transform, trans.gameObject.layer);
    return icon;
  }

  private AnimationItemIcon SetCloneSupplyIcon(
    AnimationItemIcon icon,
    Transform trans,
    GameObject obj)
  {
    if ((UnityEngine.Object) icon != (UnityEngine.Object) null && (UnityEngine.Object) icon.gameObject.transform.parent != (UnityEngine.Object) trans.transform)
    {
      UnityEngine.Object.Destroy((UnityEngine.Object) icon.gameObject);
      icon = (AnimationItemIcon) null;
    }
    if ((UnityEngine.Object) icon == (UnityEngine.Object) null)
      icon = obj.Clone(trans.transform).GetComponent<AnimationItemIcon>();
    else
      icon.gameObject.SetActive(true);
    icon.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
    icon.transform.localRotation = Quaternion.Euler(0.0f, -180f, 0.0f);
    icon.gameObject.name = nameof (SetCloneSupplyIcon);
    icon.SetSimpleMode();
    this.SetLayer(icon.gameObject.transform, trans.gameObject.layer);
    return icon;
  }

  private IEnumerator SetTextureItemThum(
    CommonRewardType crt,
    UnityEngine.Sprite sprite,
    GameObject rootObj = null)
  {
    Future<UnityEngine.Sprite> spriteF;
    switch (crt.type_)
    {
      case 4:
        spriteF = Res.Icons.Item_Icon_Zeny.Load<UnityEngine.Sprite>();
        break;
      case 10:
        spriteF = Res.Icons.Item_Icon_Kiseki.Load<UnityEngine.Sprite>();
        break;
      case 14:
        spriteF = Res.Icons.Item_Icon_Medal.Load<UnityEngine.Sprite>();
        break;
      case 15:
        spriteF = Res.Icons.Item_Icon_Point.Load<UnityEngine.Sprite>();
        break;
      case 17:
        spriteF = Res.Icons.Item_Icon_BattleMedal.Load<UnityEngine.Sprite>();
        break;
      case 19:
        spriteF = MasterData.QuestkeyQuestkey[crt.id_].LoadSpriteThumbnail();
        break;
      case 20:
        spriteF = MasterData.GachaTicket[crt.id_].LoadSpriteF();
        break;
      case 21:
        spriteF = MasterData.SeasonTicketSeasonTicket[crt.id_].LoadThumneilF();
        break;
      case 25:
        spriteF = Res.Icons.Item_Icon_Common.Load<UnityEngine.Sprite>();
        break;
      case 29:
        spriteF = MasterData.BattleskillSkill[crt.id_].LoadBattleSkillIcon();
        break;
      case 40:
        spriteF = MasterData.CommonTicket[crt.id_].LoadIconMSpriteF();
        break;
      default:
        if (!((UnityEngine.Object) rootObj != (UnityEngine.Object) null))
        {
          yield break;
        }
        else
        {
          rootObj.SetActive(true);
          yield break;
        }
    }
    IEnumerator e = spriteF.Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    this.unit_sprite_.sprite2D = spriteF.Result;
  }

  private void SetUnitIcon(UnitUnit unit, bool is_new = false)
  {
    this.unit_icon_type_.sprite2D = Resources.Load<UnityEngine.Sprite>(string.Format("Icons/Materials/GearKind_Element_Icon/slc_{0}_{1}_34_30", (object) unit.kind.Enum.ToString(), (object) unit.GetElement().ToString()));
    this.unit_icon_type_.MakePixelPerfect();
    UnityEngine.Sprite sprite = RarityIcon.GetSprite(unit, false);
    this.unit_icon_star_.sprite2D = UnityEngine.Sprite.Create(sprite.texture, sprite.textureRect, new Vector2(0.5f, 0.0f), 1f, 100U, SpriteMeshType.FullRect);
    this.unit_icon_star_.MakePixelPerfect();
    this.unit_icon_star_.gameObject.transform.localPosition = this.StarIntialLocalPosition;
    this.unit_icon_new_.SetActive(is_new);
    this.unit_icon_obj_.SetActive(true);
  }

  private void SetItemIcon(GearGear item, bool isWeaponMaterial, bool is_new = false)
  {
    this.item_icon_back_.sprite2D = !isWeaponMaterial ? (!item.hasSpecificationOfEquipmentUnits ? this.item_back_sprite_[item.customize_flag] : this.back_sprite_equipment_units_[item.customize_flag]) : this.back_sprite_weapon_;
    this.item_icon_back_.MakePixelPerfect();
    if (item.kind.isEquip)
    {
      this.item_icon_type_.gameObject.SetActive(true);
      this.item_icon_type_.sprite2D = Resources.Load<UnityEngine.Sprite>(string.Format("Icons/Materials/GearKind_Element_Icon/slc_{0}_{1}_34_30", (object) item.kind.Enum.ToString(), (object) item.GetElement().ToString()));
      this.item_icon_star_.transform.localPosition = this.StarIntialLocalPosition;
    }
    else
    {
      this.item_icon_type_.gameObject.SetActive(false);
      this.item_icon_star_.transform.localPosition = new Vector3(0.0f, this.item_icon_star_.transform.localPosition.y, this.item_icon_star_.transform.localPosition.z);
    }
    this.item_icon_star_list_.ToggleOnce(item.rarity.index);
    this.item_icon_obj_.SetActive(true);
  }

  private void SetSupplyIcon()
  {
    this.item_icon_back_.sprite2D = this.item_back_sprite_[0];
    this.item_icon_type_.gameObject.SetActive(false);
    this.item_icon_star_.SetActive(false);
    this.item_icon_frame_.SetActive(false);
    this.item_icon_obj_.SetActive(true);
  }
}
