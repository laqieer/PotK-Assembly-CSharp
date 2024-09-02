// Decompiled with JetBrains decompiler
// Type: GuildDefTeamPopup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class GuildDefTeamPopup : MonoBehaviour
{
  private bool isEnemy;
  [SerializeField]
  private GameObject dir_guild_DEFteam_teamformation;
  private GuildDefTeamEditPopup teamEditPopup;
  [SerializeField]
  private GameObject dir_guild_battle_guest_select;
  private GuildDefGuestSelectPopup guestSelectPopup;
  private GuildDefTeamPopup.MODE mode;

  public GuildDefTeamPopup.MODE Mode => this.mode;

  [DebuggerHidden]
  public IEnumerator InitializeAsync(
    bool isEnemy,
    Guild0282Menu menu,
    GuildMembership info,
    System.Action success = null)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuildDefTeamPopup.\u003CInitializeAsync\u003Ec__Iterator734()
    {
      isEnemy = isEnemy,
      menu = menu,
      info = info,
      success = success,
      \u003C\u0024\u003EisEnemy = isEnemy,
      \u003C\u0024\u003Emenu = menu,
      \u003C\u0024\u003Einfo = info,
      \u003C\u0024\u003Esuccess = success,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator ShowGuestSelect()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuildDefTeamPopup.\u003CShowGuestSelect\u003Ec__Iterator735()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void ShowTeamEdit()
  {
    this.mode = GuildDefTeamPopup.MODE.Edit;
    this.dir_guild_battle_guest_select.SetActive(false);
    this.dir_guild_DEFteam_teamformation.SetActive(true);
    this.teamEditPopup.IsPush = false;
  }

  public enum MODE
  {
    Edit,
    Guest,
  }
}
