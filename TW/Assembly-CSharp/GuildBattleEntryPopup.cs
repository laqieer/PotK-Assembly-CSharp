// Decompiled with JetBrains decompiler
// Type: GuildBattleEntryPopup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;

#nullable disable
public class GuildBattleEntryPopup : BackButtonMenuBase
{
  public void onClickedEntry()
  {
    if (this.IsPushAndSet())
      return;
    this.StartCoroutine(this.coConfirmEntry());
  }

  public override void onBackButton() => this.onClickedClose();

  public void onClickedClose()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().dismiss();
  }

  [DebuggerHidden]
  private IEnumerator coConfirmEntry()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuildBattleEntryPopup.\u003CcoConfirmEntry\u003Ec__Iterator717()
    {
      \u003C\u003Ef__this = this
    };
  }
}
