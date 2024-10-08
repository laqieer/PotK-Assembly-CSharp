﻿// Decompiled with JetBrains decompiler
// Type: MapEditSaveSlotList
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

public class MapEditSaveSlotList : MonoBehaviour
{
  [SerializeField]
  private UILabel txtSlotName_;
  [SerializeField]
  private GameObject lnkMapIcon_;
  [SerializeField]
  private UILabel txtMapName_;
  [SerializeField]
  private UILabel txtCost_;
  [SerializeField]
  private UILabel txtMapDescription_;
  [SerializeField]
  private UIButton btnSelect_;
  [SerializeField]
  private UIButton btnMapDetail_;
  [SerializeField]
  private GameObject markDefence_;
  private bool initalized_;
  private System.Action<int, PlayerGuildTownSlotPosition[]> eventMapDetail_;
  private System.Action<int> eventSelect_;
  private GameObject prefabIcon_;
  private GameObject instIcon_;
  private const int DEPTH_INTERVAL = 1;

  public int slotId_ { get; private set; }

  public int townId_ { get; private set; }

  public MapTown town_ { get; private set; }

  public PlayerGuildTownSlotPosition[] facilitiesData_ { get; private set; }

  public IEnumerator initialize(
    GameObject prefabIcon,
    PlayerGuildTownSlot slot,
    bool isCurrent,
    bool isDefenceTown,
    System.Action<int, PlayerGuildTownSlotPosition[]> eventMapDetail,
    System.Action<int> eventSelect)
  {
    MapEditSaveSlotList editSaveSlotList = this;
    editSaveSlotList.slotId_ = slot.slot_number;
    if ((UnityEngine.Object) editSaveSlotList.txtSlotName_ != (UnityEngine.Object) null)
    {
      Consts instance = Consts.GetInstance();
      Hashtable hashtable = new Hashtable()
      {
        {
          (object) "name",
          (object) instance.SAVE_SLOT_NAME
        },
        {
          (object) "num",
          (object) (editSaveSlotList.slotId_ + 1)
        }
      };
      editSaveSlotList.txtSlotName_.SetTextLocalize(Consts.Format(instance.MAPEDIT_031_SLOT_NAME, (IDictionary) hashtable));
    }
    editSaveSlotList.prefabIcon_ = prefabIcon;
    IEnumerator e = editSaveSlotList.doReset(slot, isCurrent, isDefenceTown, true);
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    editSaveSlotList.eventMapDetail_ = eventMapDetail;
    if (editSaveSlotList.eventMapDetail_ != null)
      EventDelegate.Set(editSaveSlotList.btnMapDetail_.onClick, new EventDelegate.Callback(editSaveSlotList.onMapDetail));
    else
      editSaveSlotList.btnMapDetail_.onClick.Clear();
    editSaveSlotList.eventSelect_ = eventSelect;
    if (editSaveSlotList.eventSelect_ != null)
      EventDelegate.Set(editSaveSlotList.btnSelect_.onClick, new EventDelegate.Callback(editSaveSlotList.onSelect));
    else
      editSaveSlotList.btnSelect_.onClick.Clear();
  }

  public IEnumerator updateInformation(
    PlayerGuildTownSlot slot,
    bool isCurrent,
    bool isDefenceTown)
  {
    return this.doReset(slot, isCurrent, isDefenceTown, false);
  }

  private IEnumerator doReset(
    PlayerGuildTownSlot slot,
    bool isCurrent,
    bool isDefenceTown,
    bool bInit)
  {
    this.initalized_ = false;
    this.markDefence_.SetActive(isDefenceTown);
    this.facilitiesData_ = slot.facilities_data;
    if (bInit || this.townId_ != slot._master)
    {
      if ((UnityEngine.Object) this.instIcon_ != (UnityEngine.Object) null)
      {
        UnityEngine.Object.Destroy((UnityEngine.Object) this.instIcon_);
        this.instIcon_ = (GameObject) null;
      }
      this.townId_ = slot._master;
      this.town_ = slot.master;
      this.txtMapName_.SetTextLocalize(this.town_.name);
      if ((UnityEngine.Object) this.txtMapDescription_ != (UnityEngine.Object) null)
        this.txtMapDescription_.SetTextLocalize(this.town_.description);
      this.instIcon_ = this.prefabIcon_.Clone(this.lnkMapIcon_.transform);
      UniqueIcons icon = this.instIcon_.GetComponent<UniqueIcons>();
      UIWidget component = this.lnkMapIcon_.GetComponent<UIWidget>();
      icon.SetSize(Mathf.RoundToInt(component.localSize.x), Mathf.RoundToInt(component.localSize.y));
      NGUITools.AdjustDepth(icon.gameObject, component.depth + 1);
      IEnumerator e = icon.SetGuildMap(this.townId_);
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      yield return (object) new WaitForEndOfFrame();
      Transform transform = icon.transform;
      Bounds relativeWidgetBounds = NGUIMath.CalculateRelativeWidgetBounds(transform, transform);
      this.btnMapDetail_.GetComponent<UIWidget>().SetDimensions(Mathf.RoundToInt(relativeWidgetBounds.size.x), Mathf.RoundToInt(relativeWidgetBounds.size.y));
      icon = (UniqueIcons) null;
    }
    PlayerGuildFacility[] playerGuildFacilityArray = SMManager.Get<PlayerGuildFacility[]>();
    Dictionary<int, PlayerGuildFacility> dicFacility = playerGuildFacilityArray != null ? ((IEnumerable<PlayerGuildFacility>) playerGuildFacilityArray).ToDictionary<PlayerGuildFacility, int>((Func<PlayerGuildFacility, int>) (f => f._master)) : new Dictionary<int, PlayerGuildFacility>();
    PlayerGuildFacility playerGuildFacility;
    int num = ((IEnumerable<PlayerGuildTownSlotPosition>) slot.facilities_data).Select<PlayerGuildTownSlotPosition, UnitUnit>((Func<PlayerGuildTownSlotPosition, UnitUnit>) (fp => dicFacility.TryGetValue(fp.master_id, out playerGuildFacility) ? playerGuildFacility.unit : (UnitUnit) null)).Sum<UnitUnit>((Func<UnitUnit, int>) (u => u == null ? 0 : u.cost));
    this.txtCost_.SetTextLocalize(Consts.Format(Consts.GetInstance().MAPEDIT_031_SLOT_COST, (IDictionary) new Hashtable()
    {
      {
        (object) "used",
        (object) num
      },
      {
        (object) "limited",
        (object) this.town_.cost_capacity
      }
    }));
    this.initalized_ = true;
  }

  private void onSelect()
  {
    if (!this.initalized_)
      return;
    this.eventSelect_(this.slotId_);
  }

  private void onMapDetail()
  {
    if (!this.initalized_)
      return;
    this.eventMapDetail_(this.townId_, this.facilitiesData_);
  }
}
