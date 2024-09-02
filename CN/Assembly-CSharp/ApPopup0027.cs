// Decompiled with JetBrains decompiler
// Type: ApPopup0027
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
    return (IEnumerator) new ApPopup0027.\u003Cpopup00712\u003Ec__Iterator207()
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
