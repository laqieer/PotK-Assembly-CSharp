// Decompiled with JetBrains decompiler
// Type: GuildBattlePreparationPopup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class GuildBattlePreparationPopup : MonoBehaviour
{
  [SerializeField]
  private GameObject dir_guild_battle_stage_entry;
  private GuildBattleSortiePopup sortiePopup;
  [SerializeField]
  private GameObject dir_guild_battle_guest_select;
  private GuildAtkGuestSelectPopup guestSelectPopup;
  private GvgDeck deckInfo;
  private Guild0282Menu guild0282Menu;
  private GuildBattlePreparationPopup.MODE mode;

  public GuildBattlePreparationPopup.MODE Mode => this.mode;

  [DebuggerHidden]
  public IEnumerator InitializeAsync(Guild0282Menu menu, string targetPlayerID, System.Action success = null)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuildBattlePreparationPopup.\u003CInitializeAsync\u003Ec__Iterator718()
    {
      menu = menu,
      targetPlayerID = targetPlayerID,
      success = success,
      \u003C\u0024\u003Emenu = menu,
      \u003C\u0024\u003EtargetPlayerID = targetPlayerID,
      \u003C\u0024\u003Esuccess = success,
      \u003C\u003Ef__this = this
    };
  }

  public void ShowGuestSelect()
  {
    this.dir_guild_battle_stage_entry.SetActive(false);
    this.dir_guild_battle_guest_select.SetActive(true);
    this.guestSelectPopup.InitScrollPosition();
    this.guestSelectPopup.IsPush = false;
    this.guestSelectPopup.SetGvgPopup();
    this.mode = GuildBattlePreparationPopup.MODE.Guest;
  }

  public void ShowSortie()
  {
    this.dir_guild_battle_guest_select.SetActive(false);
    this.dir_guild_battle_stage_entry.SetActive(true);
    this.sortiePopup.IsPush = false;
    this.sortiePopup.SetGvgPopup();
    this.mode = GuildBattlePreparationPopup.MODE.Sortie;
  }

  public enum MODE
  {
    Sortie,
    Guest,
  }
}
