// Decompiled with JetBrains decompiler
// Type: UnitWanted
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using SM;
using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class UnitWanted : MonoBehaviour
{
  [SerializeField]
  private GameObject slcUnitWantedBaseNon;
  [SerializeField]
  private GameObject slcUnitWantedBase;
  [SerializeField]
  private UILabel txtTargetMaxPoint;
  [SerializeField]
  private CreateIconObject dynUnitThum;
  private EnemyTopInfo[] infos;
  private Action<EnemyTopInfo[]> tapAction;

  [DebuggerHidden]
  public IEnumerator Init(EnemyTopInfo[] infos, Action<EnemyTopInfo[]> action)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new UnitWanted.\u003CInit\u003Ec__IteratorADA()
    {
      infos = infos,
      action = action,
      \u003C\u0024\u003Einfos = infos,
      \u003C\u0024\u003Eaction = action,
      \u003C\u003Ef__this = this
    };
  }

  public void DispDetail()
  {
    if (this.tapAction == null)
      return;
    this.tapAction(this.infos);
  }
}
