﻿// Decompiled with JetBrains decompiler
// Type: AnimationItemIcon
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using MasterDataTable;
using SM;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class AnimationItemIcon : MonoBehaviour
{
  [SerializeField]
  private SpriteRenderer break_;
  [SerializeField]
  private SpriteRenderer frame_;
  [SerializeField]
  private SpriteRenderer favorite_;
  [SerializeField]
  private SpriteRenderer type_;
  [SerializeField]
  private GameObject star_;
  [SerializeField]
  private SpriteRenderer rank_;
  [SerializeField]
  private GameObject new_;
  [SerializeField]
  private List<GameObject> star_list_;
  [SerializeField]
  private List<Sprite> rank_list_;
  [SerializeField]
  private SpriteRenderer back_;
  private Vector3 m_starIntialLocalPosition;
  public Sprite[] backSprite;
  public Sprite[] backSpriteSpecificationOfEquipmentUnits;

  public PlayerItem player_item_ { get; set; }

  private void Awake()
  {
    if (Debug.isDebugBuild)
      Debug.Log((object) "Save original star position.");
    this.m_starIntialLocalPosition = this.star_.transform.localPosition;
    if (!Debug.isDebugBuild)
      return;
    Debug.Log((object) ("m_starIntialLocalPosition.x: " + this.m_starIntialLocalPosition.x.ToString()));
  }

  public void SetBroken(bool flag) => ((Component) this.break_).gameObject.SetActive(flag);

  public void SetFavorite(bool flag) => ((Component) this.favorite_).gameObject.SetActive(flag);

  public void SetNew(bool flag) => this.new_.gameObject.SetActive(flag);

  private Sprite GetGearTypeIcon(GearKindEnum kind, CommonElement element)
  {
    return Resources.Load<Sprite>(string.Format("Icons/Materials/GearKind_Element_Icon/slc_{0}_{1}_34_30", (object) kind.ToString(), (object) element.ToString()));
  }

  public void SetType(GearKind kind, CommonElement element)
  {
    if (kind.isEquip)
    {
      ((Component) this.type_).gameObject.SetActive(true);
      this.type_.sprite = this.GetGearTypeIcon(kind.Enum, element);
      this.star_.transform.localPosition = this.m_starIntialLocalPosition;
    }
    else
    {
      ((Component) this.type_).gameObject.SetActive(false);
      this.star_.transform.localPosition = new Vector3(0.0f, this.star_.transform.localPosition.y, this.star_.transform.localPosition.z);
    }
    if (!Debug.isDebugBuild)
      return;
    Debug.Log((object) ("Moved star. star_.transform.localPosition.x: " + this.star_.transform.localPosition.x.ToString()));
  }

  public void SetStar(GearRarity rarity)
  {
    this.star_.gameObject.SetActive(true);
    this.star_list_.ToggleOnce(rarity.index);
  }

  public void SetRank(int id)
  {
    if (!this.player_item_.gear.kind.isEquip)
    {
      ((Component) this.rank_).gameObject.SetActive(false);
    }
    else
    {
      ((Component) this.rank_).gameObject.SetActive(true);
      this.rank_.sprite = this.rank_list_[id];
    }
  }

  public void Set(PlayerItem player_item, bool is_new = false)
  {
    ((Component) this.frame_).gameObject.SetActive(true);
    if (player_item.gear == null)
      return;
    this.back_.sprite = this.backSprite[0];
    if (player_item.gear != null)
      this.back_.sprite = !player_item.gear.hasSpecificationOfEquipmentUnits ? this.backSprite[player_item.gear.customize_flag] : this.backSpriteSpecificationOfEquipmentUnits[player_item.gear.customize_flag];
    this.player_item_ = player_item;
    this.SetBroken(this.player_item_.broken);
    this.SetFavorite(this.player_item_.favorite);
    this.SetType(this.player_item_.gear.kind, this.player_item_.GetElement());
    this.SetStar(this.player_item_.gear.rarity);
    this.SetRank(this.player_item_.gear_level);
    this.SetNew(is_new);
  }

  public void Set(GearGear item, bool is_new = false)
  {
    ((Component) this.frame_).gameObject.SetActive(true);
    this.back_.sprite = !item.hasSpecificationOfEquipmentUnits ? this.backSprite[item.customize_flag] : this.backSpriteSpecificationOfEquipmentUnits[item.customize_flag];
    this.SetBroken(false);
    this.SetFavorite(false);
    this.SetType(item.kind, item.GetElement());
    this.SetStar(item.rarity);
    ((Component) this.rank_).gameObject.SetActive(false);
    this.SetNew(is_new);
  }

  public void SetSimpleMode()
  {
    this.SetBroken(false);
    this.SetFavorite(false);
    ((Component) this.type_).gameObject.SetActive(false);
    ((Component) this.rank_).gameObject.SetActive(false);
    this.SetNew(false);
    ((Component) this.frame_).gameObject.SetActive(false);
    this.star_.gameObject.SetActive(false);
  }
}
