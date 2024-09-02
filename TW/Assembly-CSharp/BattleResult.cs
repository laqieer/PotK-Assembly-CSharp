// Decompiled with JetBrains decompiler
// Type: BattleResult
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using System;
using System.Collections.Generic;
using UniLinq;
using UnityEngine;

#nullable disable
public class BattleResult : MonoBehaviour
{
  [SerializeField]
  private GameObject[] countOwn;
  [SerializeField]
  private GameObject[] countEnemy;
  [SerializeField]
  private UILabel damageOwn;
  [SerializeField]
  private UILabel damageEnemy;
  [SerializeField]
  private UIButton btnReplay;

  public void Initialize(System.Action replayCallBack)
  {
    ((Component) this.damageOwn).gameObject.SetActive(true);
    ((Component) this.damageEnemy).gameObject.SetActive(true);
    ((IEnumerable<GameObject>) this.countOwn).ForEach<GameObject>((Action<GameObject>) (x => x.SetActive(false)));
    ((IEnumerable<GameObject>) this.countEnemy).ForEach<GameObject>((Action<GameObject>) (x => x.SetActive(false)));
    this.dispReplay(false);
    EventDelegate.Set(this.btnReplay.onClick, (EventDelegate.Callback) (() => replayCallBack()));
  }

  public void SetBattleResult(GameCore.ColosseumResult result)
  {
    this.DispPoint(result);
    this.SetTotalDamage(result);
  }

  private void DispPoint(GameCore.ColosseumResult result)
  {
    // ISSUE: object of a compiler-generated type is created
    foreach (\u003C\u003E__AnonType3<GameObject, int> anonType3 in ((IEnumerable<GameObject>) this.countOwn).Select<GameObject, \u003C\u003E__AnonType3<GameObject, int>>((Func<GameObject, int, \u003C\u003E__AnonType3<GameObject, int>>) ((s, i) => new \u003C\u003E__AnonType3<GameObject, int>(s, i))))
    {
      bool flag = anonType3.i == result.win_count;
      anonType3.s.SetActive(flag);
    }
    // ISSUE: object of a compiler-generated type is created
    foreach (\u003C\u003E__AnonType3<GameObject, int> anonType3 in ((IEnumerable<GameObject>) this.countEnemy).Select<GameObject, \u003C\u003E__AnonType3<GameObject, int>>((Func<GameObject, int, \u003C\u003E__AnonType3<GameObject, int>>) ((s, i) => new \u003C\u003E__AnonType3<GameObject, int>(s, i))))
    {
      bool flag = anonType3.i == result.lose_count;
      anonType3.s.SetActive(flag);
    }
  }

  private void SetTotalDamage(GameCore.ColosseumResult result)
  {
    this.damageOwn.SetTextLocalize(result.myTotalDamage);
    this.damageEnemy.SetTextLocalize(result.opponetTotalDamage);
  }

  public void dispReplay(bool canDisp)
  {
    ((Component) this.btnReplay).gameObject.SetActive(canDisp);
  }
}
