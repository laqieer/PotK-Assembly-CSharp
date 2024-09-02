// Decompiled with JetBrains decompiler
// Type: HpGauge
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class HpGauge : BattleMonoBehaviour
{
  private const int animeFrame = 30;
  [SerializeField]
  protected GameObject gauge;
  [SerializeField]
  protected GameObject dirGearIcon;
  private float gaugeValue;
  private BL.BattleModified<BL.Unit> modified;
  private BL.BattleModified<BL.StructValue<bool>> isViewUnitTypeModified;
  [SerializeField]
  protected HpGauge.ElementIcons[] gears;
  private bool mIsEffectMode;

  public bool isEffectMode
  {
    get => this.mIsEffectMode;
    set => this.mIsEffectMode = value;
  }

  [DebuggerHidden]
  protected override IEnumerator Start_Battle()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new HpGauge.\u003CStart_Battle\u003Ec__IteratorA64()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void setUnit(BL.Unit unit)
  {
    this.modified = BL.Observe<BL.Unit>(unit);
    this.SetGearKind(unit);
  }

  private void SetGearKind(BL.Unit unit)
  {
    ((IEnumerable<HpGauge.ElementIcons>) this.gears).ForEach<HpGauge.ElementIcons>((Action<HpGauge.ElementIcons>) (x =>
    {
      if (!Object.op_Inequality((Object) x.parent, (Object) null))
        return;
      x.parent.SetActive(false);
    }));
    int index = unit.unit.kind_GearKind - 1;
    if (this.gears.Length <= index || !Object.op_Inequality((Object) this.gears[index].parent, (Object) null))
      return;
    HpGauge.ElementIcons gear = this.gears[index];
    gear.parent.SetActive(true);
    ((IEnumerable<GameObject>) gear.icons).ForEach<GameObject>((Action<GameObject>) (x =>
    {
      if (!Object.op_Inequality((Object) x, (Object) null))
        return;
      x.SetActive(false);
    }));
    int element = (int) unit.GetElement();
    if (!Object.op_Inequality((Object) gear.icons[element - 1], (Object) null))
      return;
    gear.icons[element - 1].SetActive(true);
  }

  protected override void LateUpdate_Battle()
  {
    if (!this.mIsEffectMode && this.modified != null && this.modified.isChangedOnce())
      this.setValue(this.modified.value.hp, this.modified.value.parameter.Hp);
    if (!this.isViewUnitTypeModified.isChangedOnce())
      return;
    this.DispUnitTypeIcon(this.isViewUnitTypeModified.value.value);
  }

  private void DispUnitTypeIcon(bool canDisp) => this.dirGearIcon.SetActive(canDisp);

  public void setGauge(int start, int end)
  {
    this.setValue(start, this.modified.value.parameter.Hp);
    this.StartCoroutine(this.gaugeAnim(start, end));
  }

  [DebuggerHidden]
  private IEnumerator gaugeAnim(int start, int end)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new HpGauge.\u003CgaugeAnim\u003Ec__IteratorA65()
    {
      start = start,
      end = end,
      \u003C\u0024\u003Estart = start,
      \u003C\u0024\u003Eend = end,
      \u003C\u003Ef__this = this
    };
  }

  public bool setValue(int n, int max)
  {
    if (Mathf.Approximately((float) max, 0.0f))
      return false;
    float num = (float) n / (float) max;
    if (Mathf.Approximately(this.gaugeValue, num))
      return false;
    this.gauge.transform.localScale = new Vector3(num * 2.54f, this.gauge.transform.localScale.y, this.gauge.transform.localScale.z);
    this.gaugeValue = num;
    return true;
  }

  [Serializable]
  public struct ElementIcons
  {
    public GameObject parent;
    public GameObject[] icons;
  }
}
