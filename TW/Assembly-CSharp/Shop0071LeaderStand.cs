// Decompiled with JetBrains decompiler
// Type: Shop0071LeaderStand
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using MasterDataTable;
using SM;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class Shop0071LeaderStand : MonoBehaviour
{
  private NGSoundManager soundManager;
  private PlayerUnit _playerUnit;

  private void OnDisable()
  {
    if (!Object.op_Inequality((Object) this.soundManager, (Object) null))
      return;
    this.soundManager.stopVoice();
  }

  [DebuggerHidden]
  public IEnumerator SetLeaderCharacter(int id)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop0071LeaderStand.\u003CSetLeaderCharacter\u003Ec__Iterator486()
    {
      id = id,
      \u003C\u0024\u003Eid = id,
      \u003C\u003Ef__this = this
    };
  }

  public void SetLeaderCharacter()
  {
    UnitUnit unitUnit = ShopTopUnit.GetShopTopUnit();
    if (unitUnit == null)
    {
      PlayerDeck[] playerDeckArray = SMManager.Get<PlayerDeck[]>();
      PlayerUnit playerUnit = ((IEnumerable<PlayerUnit>) playerDeckArray[Persist.deckOrganized.Data.number].player_units).FirstOrDefault<PlayerUnit>();
      if (playerUnit == (PlayerUnit) null)
        playerUnit = ((IEnumerable<PlayerUnit>) playerDeckArray[0].player_units).First<PlayerUnit>();
      unitUnit = playerUnit.unit;
    }
    this.StartCoroutine(this.SetLeaderCharacter(unitUnit.ID));
  }
}
