// Decompiled with JetBrains decompiler
// Type: GuildBattleRecordPopup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class GuildBattleRecordPopup : GuildBattleRecordListBase
{
  private const int Width = 618;
  private const int Height = 169;
  private const int ColumnValue = 1;
  private const int RowValue = 12;
  private const int ScreenValue = 6;
  private bool isEnemy;
  [SerializeField]
  private UILabel lblPopupTitle;
  [SerializeField]
  private GameObject slc_title_base_one;
  [SerializeField]
  private GameObject slc_title_base_enemy;
  private GameObject memberScorePopup;

  [DebuggerHidden]
  private IEnumerator InitRecordListScroll(GvgHistory[] records)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuildBattleRecordPopup.\u003CInitRecordListScroll\u003Ec__Iterator71B()
    {
      records = records,
      \u003C\u0024\u003Erecords = records,
      \u003C\u003Ef__this = this
    };
  }

  private void SetLabel()
  {
    this.lblPopupTitle.SetTextLocalize(Consts.GetInstance().POPUP_GUILD_BATTLE_RECORD_TITLE);
  }

  [DebuggerHidden]
  protected override IEnumerator CreateScroll(int info_index, int bar_index)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuildBattleRecordPopup.\u003CCreateScroll\u003Ec__Iterator71C()
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
  public IEnumerator InitializeAsync(
    bool isEnemy,
    string guild_id,
    GameObject memberScorePopup,
    System.Action success = null)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuildBattleRecordPopup.\u003CInitializeAsync\u003Ec__Iterator71D()
    {
      isEnemy = isEnemy,
      guild_id = guild_id,
      memberScorePopup = memberScorePopup,
      success = success,
      \u003C\u0024\u003EisEnemy = isEnemy,
      \u003C\u0024\u003Eguild_id = guild_id,
      \u003C\u0024\u003EmemberScorePopup = memberScorePopup,
      \u003C\u0024\u003Esuccess = success,
      \u003C\u003Ef__this = this
    };
  }

  public void InitScrollPosition() => this.scroll.scrollView.ResetPosition();

  public override void onBackButton()
  {
    if (Singleton<NGSceneManager>.GetInstance().sceneName.Equals("guild028_2") && Object.op_Inequality((Object) Singleton<NGSceneManager>.GetInstance().sceneBase, (Object) null) && Object.op_Inequality((Object) ((Component) Singleton<NGSceneManager>.GetInstance().sceneBase).GetComponent<Guild0282Menu>(), (Object) null))
      ((Component) Singleton<NGSceneManager>.GetInstance().sceneBase).GetComponent<Guild0282Menu>().isClosePopupByBackBtn = true;
    Singleton<PopupManager>.GetInstance().dismiss();
  }
}
