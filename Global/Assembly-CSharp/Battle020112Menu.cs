﻿// Decompiled with JetBrains decompiler
// Type: Battle020112Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using MasterDataTable;
using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Battle020112Menu : NGMenuBase
{
  private const float LINK_WIDTH = 136f;
  private const float LINK_DEFWIDTH = 136f;
  private const float scale = 1f;
  [SerializeField]
  protected UILabel TxtCharaname22;
  [SerializeField]
  protected UILabel TxtDescription20;
  [SerializeField]
  protected UILabel TxtDescription224;
  [SerializeField]
  protected UILabel TxtPopuptitle26;
  [SerializeField]
  private GameObject linkChar;
  private System.Action onCallback;

  public void Init(int deckno, int charno)
  {
    this.StartCoroutine(this.SetUnitPrefab(SMManager.Get<PlayerDeck[]>()[deckno].player_units[charno]));
  }

  public void Init(int unitId)
  {
    this.StartCoroutine(this.SetUnitPrefab(MasterData.UnitUnit[unitId]));
  }

  [DebuggerHidden]
  public IEnumerator Init(QuestCharacterS quest)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Battle020112Menu.\u003CInit\u003Ec__Iterator6E6()
    {
      quest = quest,
      \u003C\u0024\u003Equest = quest,
      \u003C\u003Ef__this = this
    };
  }

  public void SetText(string name, int episodeNo, string episodeTitle)
  {
    this.TxtCharaname22.SetTextLocalize(name);
    this.TxtDescription20.SetTextLocalize("Episode" + (object) episodeNo);
    this.TxtDescription224.SetTextLocalize(episodeTitle);
  }

  [DebuggerHidden]
  public IEnumerator SetUnitPrefab(PlayerUnit unit)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Battle020112Menu.\u003CSetUnitPrefab\u003Ec__Iterator6E7()
    {
      unit = unit,
      \u003C\u0024\u003Eunit = unit,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator SetUnitPrefab(UnitUnit unit)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Battle020112Menu.\u003CSetUnitPrefab\u003Ec__Iterator6E8()
    {
      unit = unit,
      \u003C\u0024\u003Eunit = unit,
      \u003C\u003Ef__this = this
    };
  }

  public virtual void PopUpTap()
  {
    Singleton<PopupManager>.GetInstance().dismiss();
    if (this.onCallback == null)
      return;
    this.onCallback();
  }

  public void SetCallback(System.Action callback) => this.onCallback = callback;
}
