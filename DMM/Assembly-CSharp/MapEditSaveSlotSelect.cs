// Decompiled with JetBrains decompiler
// Type: MapEditSaveSlotSelect
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using UniLinq;
using UnityEngine;

public class MapEditSaveSlotSelect : MonoBehaviour
{
  [SerializeField]
  private NGxScroll scroll_;
  [SerializeField]
  private UIButton btnClose_;
  private List<MapEditSaveSlotList> slotList_ = new List<MapEditSaveSlotList>();
  private bool initialized_;

  public IEnumerator initialize(
    PlayerGuildTownSlot[] slots,
    int current,
    int defaultSlot,
    System.Action<int, PlayerGuildTownSlotPosition[]> eventMapDetail,
    System.Action<int> eventSelect,
    System.Action eventClose)
  {
    this.initialized_ = false;
    EventDelegate.Set(this.btnClose_.onClick, (EventDelegate.Callback) (() =>
    {
      if (!this.initialized_)
        return;
      eventClose();
    }));
    if (slots == null)
    {
      this.initialized_ = true;
    }
    else
    {
      Future<GameObject> ldprefab = MapEdit.Prefabs.map_slot_list.Load<GameObject>();
      IEnumerator e = ldprefab.Wait();
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      if ((UnityEngine.Object) ldprefab.Result == (UnityEngine.Object) null)
      {
        this.initialized_ = true;
      }
      else
      {
        Future<GameObject> ldMapIcon = Res.Icons.UniqueIconPrefab.Load<GameObject>();
        e = ldMapIcon.Wait();
        while (e.MoveNext())
          yield return e.Current;
        e = (IEnumerator) null;
        if ((UnityEngine.Object) ldMapIcon.Result == (UnityEngine.Object) null)
        {
          this.initialized_ = true;
        }
        else
        {
          this.scroll_.Reset();
          this.slotList_.Clear();
          PlayerGuildTownSlot[] playerGuildTownSlotArray = slots;
          for (int index = 0; index < playerGuildTownSlotArray.Length; ++index)
          {
            PlayerGuildTownSlot slot = playerGuildTownSlotArray[index];
            GameObject gameObject = ldprefab.Result.Clone();
            this.scroll_.Add(gameObject, true);
            MapEditSaveSlotList component = gameObject.GetComponent<MapEditSaveSlotList>();
            this.slotList_.Add(component);
            e = component.initialize(ldMapIcon.Result, slot, slot.slot_number == current, slot.slot_number == defaultSlot, eventMapDetail, eventSelect);
            while (e.MoveNext())
              yield return e.Current;
            e = (IEnumerator) null;
          }
          playerGuildTownSlotArray = (PlayerGuildTownSlot[]) null;
          this.scroll_.GridReposition((UIGrid.OnReposition) (() => this.scroll_.scrollView.ResetPosition()));
          this.initialized_ = true;
        }
      }
    }
  }

  public IEnumerator updateInformation(
    PlayerGuildTownSlot[] slots,
    int current,
    int defaultSlot)
  {
    if (slots != null)
    {
      this.initialized_ = false;
      PlayerGuildTownSlot[] playerGuildTownSlotArray = slots;
      for (int index = 0; index < playerGuildTownSlotArray.Length; ++index)
      {
        PlayerGuildTownSlot slot = playerGuildTownSlotArray[index];
        MapEditSaveSlotList editSaveSlotList = this.slotList_.FirstOrDefault<MapEditSaveSlotList>((Func<MapEditSaveSlotList, bool>) (s => s.slotId_ == slot.slot_number));
        if (!((UnityEngine.Object) editSaveSlotList == (UnityEngine.Object) null))
        {
          IEnumerator e = editSaveSlotList.updateInformation(slot, slot.slot_number == current, slot.slot_number == defaultSlot);
          while (e.MoveNext())
            yield return e.Current;
          e = (IEnumerator) null;
        }
      }
      playerGuildTownSlotArray = (PlayerGuildTownSlot[]) null;
      this.initialized_ = true;
    }
  }
}
