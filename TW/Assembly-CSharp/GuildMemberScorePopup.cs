// Decompiled with JetBrains decompiler
// Type: GuildMemberScorePopup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class GuildMemberScorePopup : GuildMemberScoreListBase
{
  private const int Width = 612;
  private const int Height = 160;
  private const int ColumnValue = 1;
  private const int RowValue = 11;
  private const int ScreenValue = 6;
  [SerializeField]
  private UILabel lblPopupTitle;
  [SerializeField]
  private GameObject slc_title_base_one;
  [SerializeField]
  private GameObject slc_title_base_enemy;

  [DebuggerHidden]
  private IEnumerator InitMemberScoreListScroll(GvgPlayerHistory[] scores)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuildMemberScorePopup.\u003CInitMemberScoreListScroll\u003Ec__Iterator75B()
    {
      scores = scores,
      \u003C\u0024\u003Escores = scores,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  protected override IEnumerator CreateScroll(int info_index, int bar_index)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuildMemberScorePopup.\u003CCreateScroll\u003Ec__Iterator75C()
    {
      bar_index = bar_index,
      info_index = info_index,
      \u003C\u0024\u003Ebar_index = bar_index,
      \u003C\u0024\u003Einfo_index = info_index,
      \u003C\u003Ef__this = this
    };
  }

  protected override void Update()
  {
    base.Update();
    this.ScrollUpdate();
  }

  [DebuggerHidden]
  public IEnumerator InitializeAsync(bool isEnemy, GvgPlayerHistory[] scores)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuildMemberScorePopup.\u003CInitializeAsync\u003Ec__Iterator75D()
    {
      isEnemy = isEnemy,
      scores = scores,
      \u003C\u0024\u003EisEnemy = isEnemy,
      \u003C\u0024\u003Escores = scores,
      \u003C\u003Ef__this = this
    };
  }

  public void InitScrollPosition() => this.scroll.scrollView.ResetPosition();

  public override void onBackButton() => Singleton<PopupManager>.GetInstance().dismiss();
}
