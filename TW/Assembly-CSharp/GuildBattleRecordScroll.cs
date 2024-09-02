// Decompiled with JetBrains decompiler
// Type: GuildBattleRecordScroll
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class GuildBattleRecordScroll : MonoBehaviour
{
  private const string NumSpriteName = "slc_text_number_{0}_60pt.png__GUI__guild_common__guild_common_prefab";
  private bool isEnemy;
  [SerializeField]
  private UILabel opponentGuildName;
  [SerializeField]
  private UI2DSprite opponentGuildTitle;
  [SerializeField]
  private GameObject dir_win;
  [SerializeField]
  private GameObject slc_lose;
  [SerializeField]
  private GameObject slc_draw;
  [SerializeField]
  private UIButton btnMemberScore;
  [SerializeField]
  private UILabel lblData;
  [SerializeField]
  private List<UISprite> spriteStarPlayer;
  [SerializeField]
  private List<UISprite> spriteStarOpponent;
  private GameObject memberScorePopup;
  private GvgHistory record;

  [DebuggerHidden]
  private IEnumerator ShowMemberScorePopup()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuildBattleRecordScroll.\u003CShowMemberScorePopup\u003Ec__Iterator788()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator InitializeAsync(bool isEnemy, GvgHistory record, GameObject memberScorePopup)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuildBattleRecordScroll.\u003CInitializeAsync\u003Ec__Iterator789()
    {
      isEnemy = isEnemy,
      record = record,
      memberScorePopup = memberScorePopup,
      \u003C\u0024\u003EisEnemy = isEnemy,
      \u003C\u0024\u003Erecord = record,
      \u003C\u0024\u003EmemberScorePopup = memberScorePopup,
      \u003C\u003Ef__this = this
    };
  }

  public void onMemberScoreButton() => this.StartCoroutine(this.ShowMemberScorePopup());
}
