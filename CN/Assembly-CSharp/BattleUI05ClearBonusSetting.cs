// Decompiled with JetBrains decompiler
// Type: BattleUI05ClearBonusSetting
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using MasterDataTable;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class BattleUI05ClearBonusSetting : MonoBehaviour
{
  [SerializeField]
  private List<GameObject> linkObjects;
  [SerializeField]
  private UISprite slcTxtBox;
  [SerializeField]
  private UILabel txtRwardMessage;
  [SerializeField]
  private GameObject[] objTragerBox;
  [SerializeField]
  private GameObject objHimeishi;
  [SerializeField]
  private GameObject dirEffect;

  [DebuggerHidden]
  public IEnumerator SetClearBonus(List<BattleStageClear> Rewards)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleUI05ClearBonusSetting.\u003CSetClearBonus\u003Ec__Iterator89F()
    {
      Rewards = Rewards,
      \u003C\u0024\u003ERewards = Rewards,
      \u003C\u003Ef__this = this
    };
  }
}
