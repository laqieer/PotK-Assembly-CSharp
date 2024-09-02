// Decompiled with JetBrains decompiler
// Type: Unit00499MemoryDeleteConfirm
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using SM;
using System.Collections;
using UnityEngine;

public class Unit00499MemoryDeleteConfirm : Unit00499MemoryBase
{
  public void Initialize(PlayerUnit unit, int index, Unit00499SaveMemorySlotSelect menu)
  {
    this.unit = unit;
    this.index = index;
    this.menu = menu;
    this.before.SetStatusTextMemory(unit);
    this.StartCoroutine(this.LoadUnit());
  }

  public IEnumerator LoadUnit()
  {
    Unit00499MemoryDeleteConfirm memoryDeleteConfirm = this;
    Future<GameObject> prefabF = Res.Prefabs.UnitIcon.normal.Load<GameObject>();
    IEnumerator e = prefabF.Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    UnitIcon unitIcon = prefabF.Result.Clone(memoryDeleteConfirm.before.linkUnit.transform).GetComponent<UnitIcon>();
    prefabF = Res.Prefabs.unit004_9_9.slc_reinforce_memory_slot_icon.Load<GameObject>();
    e = prefabF.Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    prefabF.Result.Clone(memoryDeleteConfirm.dir_reinforce_memory_slot_icon_container).GetComponent<UILabel>().SetTextLocalize(memoryDeleteConfirm.index + 1);
    PlayerUnit[] playerUnits = new PlayerUnit[1]
    {
      memoryDeleteConfirm.unit
    };
    unitIcon.RarityCenter();
    unitIcon.buttonBoxCollider.enabled = true;
    unitIcon.Button.enabled = true;
    unitIcon.SetPressEvent((System.Action) (() => Singleton<PopupManager>.GetInstance().closeAll()));
    e = unitIcon.SetPlayerUnit(memoryDeleteConfirm.unit, playerUnits, (PlayerUnit) null, true, true);
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
  }

  public void IbtnDecision()
  {
    if (this.IsPushAndSet())
      return;
    this.StartCoroutine(this.Delete());
  }
}
