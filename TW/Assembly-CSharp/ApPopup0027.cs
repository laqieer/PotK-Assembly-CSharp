// Decompiled with JetBrains decompiler
// Type: ApPopup0027
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;

#nullable disable
public class ApPopup0027 : BackButtonMenuBase
{
  private System.Action btnAct;

  public void ibtnYes() => this.StartCoroutine(this.popup00712());

  public void SetBtnAct(System.Action questChangeScene) => this.btnAct = questChangeScene;

  [DebuggerHidden]
  private IEnumerator popup00712()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new ApPopup0027.\u003Cpopup00712\u003Ec__Iterator23D()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void IbtnNo()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().onDismiss();
  }

  public override void onBackButton() => this.IbtnNo();
}
