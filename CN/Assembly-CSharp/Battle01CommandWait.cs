// Decompiled with JetBrains decompiler
// Type: Battle01CommandWait
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;

#nullable disable
public class Battle01CommandWait : BattleMonoBehaviour, IButtonEnableBeheviour
{
  private BattleUIController controller;
  private UIButton button;

  public bool buttonEnable
  {
    set => this.button.isEnabled = value;
  }

  [DebuggerHidden]
  public override IEnumerator onInitAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Battle01CommandWait.\u003ConInitAsync\u003Ec__Iterator848()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void onClick()
  {
    if (!this.battleManager.isBattleEnable)
      return;
    this.controller.uiWait();
  }
}
