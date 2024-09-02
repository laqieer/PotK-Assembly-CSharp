// Decompiled with JetBrains decompiler
// Type: BattleHorizontalSelect`1
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public abstract class BattleHorizontalSelect<T> : BattleMonoBehaviour where T : BL.ModelBase
{
  private GameObject prefab;
  protected NGHorizontalScrollParts scrollParts;
  protected BL.BattleModified<BL.ClassValue<List<T>>> modified;

  protected abstract void initialize(BE e);

  protected abstract void setParts(GameObject o, T parts);

  public abstract void onClick();

  protected abstract Future<GameObject> resPrefab();

  [DebuggerHidden]
  public override IEnumerator onInitAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleHorizontalSelect<T>.\u003ConInitAsync\u003Ec__Iterator918()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void initCurrent()
  {
    this.scrollParts.destroyParts();
    this.scrollParts.resetScrollView();
    foreach (T parts in this.modified.value.value)
    {
      if (parts.isEnable)
      {
        GameObject gameObject = this.scrollParts.instantiateParts(this.prefab);
        this.setParts(gameObject, parts);
        UIWidget component = ((Component) this).GetComponent<UIWidget>();
        if (Object.op_Inequality((Object) component, (Object) null))
          NGUITools.AdjustDepth(gameObject, component.depth);
        foreach (UIButton componentsInChild in gameObject.GetComponentsInChildren<UIButton>(true))
          EventDelegate.Set(componentsInChild.onClick, new EventDelegate((MonoBehaviour) this, "onClick"));
      }
    }
    this.scrollParts.resetScrollView();
  }

  protected override void LateUpdate_Battle()
  {
    if (this.modified == null || !this.modified.isChangedOnce())
      return;
    this.initCurrent();
  }

  public void setList(List<T> list)
  {
    if (this.modified == null)
      return;
    this.modified.value = new BL.ClassValue<List<T>>(list);
    this.modified.commit();
  }
}
