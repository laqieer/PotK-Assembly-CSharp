// Decompiled with JetBrains decompiler
// Type: Unit00499MemoryConfirm
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using SM;
using System.Collections;
using UnityEngine;

public class Unit00499MemoryConfirm : Unit00499MemoryBase
{
  public void Initialize(int index, Unit00499SaveMemorySlotSelect menu)
  {
    this.index = index;
    this.menu = menu;
    this.unit = PlayerTransmigrateMemoryPlayerUnitIds.Current.PlayerUnits()[index];
    this.before.SetStatusText(this.unit);
    this.after.SetStatusTextMemory(this.unit);
    this.StartCoroutine(this.LoadUnit());
  }

  public IEnumerator LoadUnit()
  {
    Unit00499MemoryConfirm unit00499MemoryConfirm = this;
    Future<GameObject> prefabF = Res.Prefabs.UnitIcon.normal.Load<GameObject>();
    IEnumerator e = prefabF.Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    UnitIcon component1 = prefabF.Result.Clone(unit00499MemoryConfirm.before.linkUnit.transform).GetComponent<UnitIcon>();
    PlayerUnit[] units = new PlayerUnit[1]
    {
      unit00499MemoryConfirm.unit
    };
    component1.RarityCenter();
    component1.buttonBoxCollider.enabled = true;
    component1.Button.enabled = true;
    component1.SetPressEvent((System.Action) (() => Singleton<PopupManager>.GetInstance().closeAll()));
    e = component1.SetPlayerUnit(unit00499MemoryConfirm.unit, units, (PlayerUnit) null, true, false);
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    UnitIcon component2 = prefabF.Result.Clone(unit00499MemoryConfirm.after.linkUnit.transform).GetComponent<UnitIcon>();
    component2.RarityCenter();
    component2.buttonBoxCollider.enabled = true;
    component2.Button.enabled = true;
    component2.SetPressEvent((System.Action) (() => Singleton<PopupManager>.GetInstance().closeAll()));
    e = component2.SetPlayerUnit(unit00499MemoryConfirm.unit, units, (PlayerUnit) null, true, true);
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    prefabF = Res.Prefabs.unit004_9_9.slc_reinforce_memory_slot_icon.Load<GameObject>();
    e = prefabF.Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    prefabF.Result.Clone(unit00499MemoryConfirm.dir_reinforce_memory_slot_icon_container).GetComponent<UILabel>().SetTextLocalize(unit00499MemoryConfirm.index + 1);
  }
}
