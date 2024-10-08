﻿// Decompiled with JetBrains decompiler
// Type: Tower029TowerClearAnim
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using System.Collections;
using UnityEngine;

public class Tower029TowerClearAnim : ResultMenuBase
{
  private GameObject animPrefab;
  private GameObject effectObj;
  private int floor;
  private bool isEndAnim;

  public override IEnumerator Init(
    BattleInfo info,
    WebAPI.Response.TowerBattleFinish result)
  {
    if ((UnityEngine.Object) this.animPrefab == (UnityEngine.Object) null)
    {
      Future<GameObject> f = new ResourceObject(string.Format("Prefabs/tower/dir_TowerClearAnim")).Load<GameObject>();
      IEnumerator e = f.Wait();
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
      this.animPrefab = f.Result;
      f = (Future<GameObject>) null;
    }
    this.floor = result.floor;
  }

  public override IEnumerator Run()
  {
    Tower029TowerClearAnim tower029TowerClearAnim = this;
    if (!((UnityEngine.Object) tower029TowerClearAnim.animPrefab == (UnityEngine.Object) null))
    {
      tower029TowerClearAnim.effectObj = tower029TowerClearAnim.animPrefab.Clone();
      // ISSUE: reference to a compiler-generated method
      tower029TowerClearAnim.effectObj.GetComponent<Tower029TowerClearAnimPopup>().Initialize(tower029TowerClearAnim.floor, new System.Action(tower029TowerClearAnim.\u003CRun\u003Eb__6_0));
      Singleton<PopupManager>.GetInstance().open(tower029TowerClearAnim.effectObj, isCloned: true);
      while (!tower029TowerClearAnim.isEndAnim)
        yield return (object) null;
      yield return (object) new WaitForSeconds(0.14f);
      Singleton<PopupManager>.GetInstance().dismiss();
    }
  }

  private delegate IEnumerator Runner();
}
