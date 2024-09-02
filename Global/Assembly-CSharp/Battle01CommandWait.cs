// Decompiled with JetBrains decompiler
// Type: Battle01CommandWait
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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
    return (IEnumerator) new Battle01CommandWait.\u003ConInitAsync\u003Ec__Iterator701()
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
