﻿// Decompiled with JetBrains decompiler
// Type: BattleHorizontalSelect`1
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BattleHorizontalSelect<T> : BattleMonoBehaviour where T : BL.ModelBase
{
  private GameObject prefab;
  protected NGHorizontalScrollParts scrollParts;
  protected BL.BattleModified<BL.ClassValue<List<T>>> modified;

  protected abstract void initialize(BE e);

  protected abstract void setParts(GameObject o, T parts);

  public abstract void onClick();

  protected abstract Future<GameObject> resPrefab();

  public override IEnumerator onInitAsync()
  {
    BattleHorizontalSelect<T> horizontalSelect = this;
    horizontalSelect.scrollParts = horizontalSelect.GetComponent<NGHorizontalScrollParts>();
    UIRect rect = horizontalSelect.scrollParts.GetComponent<UIRect>();
    if ((Object) rect != (Object) null)
      rect.alpha = 0.0f;
    Future<GameObject> f = horizontalSelect.resPrefab();
    IEnumerator e = f.Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    horizontalSelect.prefab = f.Result;
    horizontalSelect.initialize(Singleton<NGBattleManager>.GetInstance().environment);
    if ((Object) rect != (Object) null)
      rect.alpha = 1f;
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
        UIWidget component = this.GetComponent<UIWidget>();
        if ((Object) component != (Object) null)
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
